using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.General;
using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Mobile;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.MobileApp
{
    public class InvoiceDetailsAIRepository : IInvoiceDetailsAIRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly ICommonRepository _common;
        private readonly HttpClient _http;
        public InvoiceDetailsAIRepository(ISqlConnectionProvider sql, ICommonRepository common, HttpClient http)
        {
            _sql = sql;
            _common = common;
            _http = http;
            _http.Timeout = TimeSpan.FromMinutes(10);
        }

        public async Task<ResponseEntity<InvoiceDetailsResponse>> InvoiceSave(UserBase user,InvoiceDetailsAI model)
        {
            try
            {
                model.User = user;
                model.Status = "Pending";

                var uploadResponse =await _common.UploadIformFileToBLOB(user,model.File,"Invoice");

                if (!uploadResponse.Success)
                {
                    return new ResponseEntity<InvoiceDetailsResponse>
                    (
                        uploadResponse.Message,
                        false,
                        null
                    );
                }

                model.File = uploadResponse.Data;

                SqlParameter ResponseKey =new SqlParameter{ParameterName = "@ResponseKey",SqlDbType = SqlDbType.VarChar,Size = 200,Direction = ParameterDirection.Output};
                SqlParameter ResponseStatus =new SqlParameter {ParameterName = "@ResponseStatus",SqlDbType = SqlDbType.Bit,Direction = ParameterDirection.Output};
                SqlParameter InvoiceEntryCode =new SqlParameter{ParameterName = "@InvoiceEntryCode",SqlDbType = SqlDbType.Int,Direction = ParameterDirection.Output};

                IDbDataParameter[] saveParams =
                {
                    new SqlParameter("@JSONDATA", JsonHelper.ToJson(model)),
                    InvoiceEntryCode,ResponseKey,ResponseStatus
                };

                await _sql.ExecuteNonQueryAsync("[DMS].[SP_INVOICE_AI_SAVE]",saveParams,CommandType.StoredProcedure);

                if (InvoiceEntryCode.Value == DBNull.Value)
                {
                    return new ResponseEntity<InvoiceDetailsResponse>
                    (
                        "Failed to save Invoice",
                        false,
                        null
                    );
                }

                model.InvoiceEntryCode =Convert.ToInt32(InvoiceEntryCode.Value);

                var requestData = new
                {
                    invoiceEntryCode = model.InvoiceEntryCode,
                    image_url = model.File.AbsoluteUri
                };

                var json =JsonConvert.SerializeObject(requestData);

                var response =await _http.PostAsync("http://127.0.0.1:5050/api/invoiceextraction",new StringContent(json,Encoding.UTF8,"application/json"));
                var responseString =await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseEntity<InvoiceDetailsResponse>
                    (
                        responseString,
                        false,
                        null
                    );
                }

                model.AIResponse = responseString;

                if (response.IsSuccessStatusCode)
                {
                    model.Status = "Completed";
                }
                else
                {
                    model.Status = "Failed";
                }

                IDbDataParameter[] updateParams =
                {
                    new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                    new SqlParameter{ParameterName="@ResponseKey",SqlDbType=SqlDbType.VarChar, Size=200,Direction=ParameterDirection.Output},
                    new SqlParameter{ParameterName="@ResponseStatus",SqlDbType=SqlDbType.Bit,Direction=ParameterDirection.Output}
                };

                await _sql.ExecuteNonQueryAsync("[DMS].[SP_INVOICE_AI_UPDATE]",updateParams,CommandType.StoredProcedure);

                IDbDataParameter[] getParams =
                {
                    new SqlParameter("@InvoiceEntryCode",model.InvoiceEntryCode)
                };

                var ds =await _sql.GetDataSetAsync("[DMS].[SP_INVOICE_AI_GET]",getParams);
                var responseModel = PopulateInvoiceResponse(ds);

                return new ResponseEntity<InvoiceDetailsResponse>
                (
                    "Success",
                    true,
                    responseModel
                );
            }
            catch (Exception ex)
            {
                return new ResponseEntity<InvoiceDetailsResponse>
                (
                    ex.Message,
                    false,
                    null
                );
            }
        }
        private InvoiceDetailsResponse PopulateInvoiceResponse(DataSet ds)
        {
            InvoiceDetailsResponse model =new InvoiceDetailsResponse();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                model.InvoiceEntryCode = MakeSafe.ToSafeInt32(row["InvoiceEntryCode"]);
                model.Status = MakeSafe.ToSafeString(row["Status"]);
                model.AbsoluteUri =MakeSafe.ToSafeString(row["AbsoluteUri"]);
                model.InvoiceNo =MakeSafe.ToSafeString(row["InvoiceNo"]);
                model.InvoiceDate =MakeSafe.ToSafeString(row["InvoiceDate"]);
                model.JobCardNo =MakeSafe.ToSafeString(row["JobCardNo"]);
                model.RegNo =MakeSafe.ToSafeString(row["RegNo"]);
                model.NetPayableAmount =MakeSafe.ToSafeDecimal(row["NetPayableAmount"]);
            }
            return model;
        }
        public async Task<ResponseEntity> MobileInvoiceSave(UserBase user, InvoiceDetailsResponse input)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                new SqlParameter("@CompanyGI", user.CompanyGuid),
                new SqlParameter("@UserGuid", user.UserGuid),
                new SqlParameter("@JSONDATA", JsonHelper.ToJson(input)),
                ResponseKey, ResponseStatus
            };

                await _sql.ExecuteNonQueryAsync("[DMS].[SP_MOBILE_INVOICE_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }


}
