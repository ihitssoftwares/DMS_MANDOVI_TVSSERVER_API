using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.General;
using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Mobile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cloud_Custom.Api.Repository.Repository.MobileApp
{
    public class GatePassRepository : IGatePassRepository
    {
        private readonly ISqlConnectionProvider _sql;   
        private readonly ICommonRepository _common;
        private readonly HttpClient _http;
        public GatePassRepository(ISqlConnectionProvider sql,  ICommonRepository common, HttpClient http)
        {
            _sql = sql;    
            _common = common;
            _http = http;
        }
        public async Task<ResponseEntity<GatePassResponse>>GatePassSave(UserBase user, GatePass model)
        {
            try
            {
                model.User = user;
                model.Status = "Pending";
                var uploadResponse = await _common.UploadIformFileToBLOB(user, model.File, "GatePass");
                if (!uploadResponse.Success)
                {
                    return new ResponseEntity<GatePassResponse>
                    (
                        uploadResponse.Message,
                        false,
                        null
                    );
                }
                model.File = uploadResponse.Data;

                SqlParameter ResponseKey = new SqlParameter{ParameterName = "@ResponseKey",SqlDbType = SqlDbType.VarChar,Size = 200,Direction = ParameterDirection.Output};
                SqlParameter ResponseStatus =new SqlParameter{ParameterName = "@ResponseStatus",SqlDbType = SqlDbType.Bit,Direction = ParameterDirection.Output};
                SqlParameter GatePassEntryCode = new SqlParameter{ParameterName = "@GatePassEntryCode",SqlDbType = SqlDbType.Int,Direction = ParameterDirection.Output};

                IDbDataParameter[] saveParams =
                    { 
                        new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                        GatePassEntryCode,ResponseKey,ResponseStatus
                    };


                await _sql.ExecuteNonQueryAsync("[DMS].[SP_GATEPASS_VEHICLE_NUMBER_SAVE]",saveParams,CommandType.StoredProcedure);

                model.GatePassEntryCode =Convert.ToInt32(GatePassEntryCode.Value);

                if (model.GatePassEntryCode <= 0)
                {
                    return new ResponseEntity<GatePassResponse>
                    (
                        "Failed to create GatePass",
                        false,
                        null
                    );
                }


                //------------------------------------
                // Python Call
                //------------------------------------

                var requestData = new
                {
                    gatePassEntryCode = model.GatePassEntryCode,
                    image_url = model.File.AbsoluteUri
                };


                var json =JsonConvert.SerializeObject(requestData);
                var content =new StringContent(json,Encoding.UTF8,"application/json");

                var response = await _http.PostAsync("http://127.0.0.1:5050/api/numberplateextraction",content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    model.Status = "Failed";
                    model.AIResponse = responseString;

                    SqlParameter FailedResponseKey = new SqlParameter{ParameterName = "@ResponseKey",SqlDbType = SqlDbType.VarChar,Size = 200,Direction = ParameterDirection.Output};
                    SqlParameter FailedResponseStatus =new SqlParameter{ParameterName = "@ResponseStatus",SqlDbType = SqlDbType.Bit,Direction = ParameterDirection.Output};

                    IDbDataParameter[] failedParams =
                    {
                        new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                        FailedResponseKey,FailedResponseStatus
                    };

                    await _sql.ExecuteNonQueryAsync("[DMS].[SP_GATEPASS_VEHICLE_NUMBER_UPDATE]",failedParams,CommandType.StoredProcedure);

                    return new ResponseEntity<GatePassResponse>
                    (
                        responseString,
                        false,
                        null
                    );
                }

                var result = JsonConvert.DeserializeObject<NumberPlateResponse>(responseString);

                if (result == null || string.IsNullOrWhiteSpace(result.number))
                {
                    model.Status = "Failed";
                    model.AIResponse = responseString;

                    SqlParameter FailedResponseKey =new SqlParameter{ParameterName = "@ResponseKey",SqlDbType = SqlDbType.VarChar,Size = 200, Direction = ParameterDirection.Output };
                    SqlParameter FailedResponseStatus = new SqlParameter{ParameterName = "@ResponseStatus",SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output};

                    IDbDataParameter[] failedParams =
                    {
                        new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                        FailedResponseKey,FailedResponseStatus
                    };

                    await _sql.ExecuteNonQueryAsync("[DMS].[SP_GATEPASS_VEHICLE_NUMBER_UPDATE]",failedParams, CommandType.StoredProcedure);
                    return new ResponseEntity<GatePassResponse>
                    (
                        "Vehicle number not detected",
                        false,
                        null
                    );
                }


                model.VehicleNumber = result.number;
                model.AIResponse = responseString;
                model.Status = "Completed";

                SqlParameter UpdateResponseKey =new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar,Size = 200,Direction = ParameterDirection.Output};
                SqlParameter UpdateResponseStatus = new SqlParameter{ParameterName = "@ResponseStatus",SqlDbType = SqlDbType.Bit,Direction = ParameterDirection.Output };

                IDbDataParameter[] updateParams =
                {
                    new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                    UpdateResponseKey, UpdateResponseStatus
                };

                var dt = await _sql.GetDataTableAsync("[DMS].[SP_GATEPASS_VEHICLE_NUMBER_UPDATE]",updateParams,CommandType.StoredProcedure);

                if (dt == null || dt.Rows.Count == 0)
                {
                    return new ResponseEntity<GatePassResponse>
                    (
                        "No data returned from update procedure",
                        false,
                        null
                    );
                }

                var responseObject = new GatePassResponse
                {
                    GatePassEntryCode =
                    Convert.ToInt32(dt.Rows[0]["GatePassEntryCode"]),

                    VehicleNumber =
                    dt.Rows[0]["VehicleNumber"].ToString()
                };

                return new ResponseEntity<GatePassResponse>
                (
                    "Success",
                    true,
                    responseObject
                );
            }

            catch (Exception ex)
            {
                return new ResponseEntity<GatePassResponse>
                (
                    ex.Message,
                    false,
                    null
                );
            }
        }

        public async Task<ResponseEntity> GetVehichleGatePassCodeSave(UserBase user, GatePass model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_VEHICHLE_GATE_PASS_ENTRY_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
