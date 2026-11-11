using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Repository.IRepository.General;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
    public class JobCardDetailsAIRepository : IJobCardDetailsAIRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly HttpClient _httpClient;
        private readonly ICommonRepository _common;
        public JobCardDetailsAIRepository(ISqlConnectionProvider sql, HttpClient httpClient, ICommonRepository common)
        {
            _sql = sql;
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromMinutes(10);
            _common = common;
        }
        public async Task<JobCardDetailsAI>JobCardDetailsExtractedList(UserBase user)
        {
            try
            {

                IDbDataParameter[] sqlParams =
                {
                    new SqlParameter("@CompanyGI",user.CompanyGuid),
                    new SqlParameter("@UserGI",user.UserGuid)};

                var ds =await _sql.GetDataSetAsync("[DMS].[SP_JOB_CARD_DETAILS_AI_GET_PATH]",sqlParams);

                if (ds.Tables.Count == 0)
                    return new JobCardDetailsAI();

                string folderPath =Convert.ToString(ds.Tables[0].Rows[0]["FolderPath"]);

                /*STEP 2:Send to python */

                var payload = new
                {
                    folder_path = folderPath
                };

                var json =JsonConvert.SerializeObject(payload);
                var response = await _httpClient.PostAsync( "http://127.0.0.1:5050/api/jobcardextraction",new StringContent(json,Encoding.UTF8,"application/json"));
                var resultString =await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception(resultString);

                /*STEP 3:Save extracted data*/

                SqlParameter ResponseKey =new SqlParameter{ParameterName = "@ResponseKey",SqlDbType = SqlDbType.VarChar,Size = 500,Direction =ParameterDirection.Output};
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] saveParams =
                {
                    new SqlParameter("@JSONDATA",resultString),
                    new SqlParameter("@UserGuid",user.UserGuid),
                    ResponseKey,ResponseStatus
                };

                await _sql.ExecuteNonQueryAsync("[DMS].[SP_JOB_CARD_DETAILS_AI_SAVE]",saveParams,CommandType.StoredProcedure);

                /*STEP 4:Load list from db*/

                IDbDataParameter[] listParams =
                {
                    new SqlParameter("@CompanyGI",user.CompanyGuid),
                    new SqlParameter("@UserGI",user.UserGuid)
                };

                var listDs =await _sql.GetDataSetAsync("[DMS].[SP_JOB_CARD_DETAILS_AI_EXTRACTED_LIST]",listParams);
                return PopulateList(listDs);

            }
            catch (Exception ex)
            {
                throw new Exception(
                    ex.Message);
            }
        }
        private JobCardDetailsAI PopulateList(DataSet ds)
        {
            JobCardDetailsAI model =new JobCardDetailsAI();
            List<JobCardDetailItem> list =new List<JobCardDetailItem>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    JobCardDetailItem item = new JobCardDetailItem();

                    item.JobCardEntryCode = MakeSafe.ToSafeInt32(row["JobCardEntryCode"]);
                    item.JobCardNo =MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.CustomerMobile = MakeSafe.ToSafeString(row["CustomerMobile"]);
                    item.VehicleNo =MakeSafe.ToSafeString(row["VehicleNo"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.JobCardDate = MakeSafe.ToSafeDateTime(row["JobDate"]);
                    item.ServiceAdvisorName = MakeSafe.ToSafeString(row["ServiceAdvisor"]);
                    item.ServisorAdvisorMobile = MakeSafe.ToSafeString(row["ServisorAdvisorMobile"]);
                    item.Mechanic = MakeSafe.ToSafeString(row["Mechanic"]);
                    item.DeliveryDate = MakeSafe.ToSafeDateTime(row["DeliveryDate"]);

                    list.Add(item);
                }
            }
            model.List = list;
            return model;
        }
        public async Task<ResponseEntity<JobCardPhotoResponse>> JobCardPhotoSave(UserBase user, JobCardPhotoAI model)
        {
            try
            {
                model.User = user;
                model.Status = "Pending";

               var uploadResponse =await _common.UploadIformFileToBLOB(user,model.File,"JobCardPhoto");

               if (!uploadResponse.Success)
               {
                    return new ResponseEntity<JobCardPhotoResponse>
                     (
                        uploadResponse.Message,false,null
                     );
               }

                model.File = uploadResponse.Data;

                SqlParameter ResponseKey =new SqlParameter{ParameterName = "@ResponseKey",SqlDbType = SqlDbType.VarChar,Size = 200,Direction = ParameterDirection.Output};
                SqlParameter ResponseStatus =new SqlParameter{ParameterName = "@ResponseStatus",SqlDbType = SqlDbType.Bit,Direction = ParameterDirection.Output};
                SqlParameter JobCardPhotoEntryCode =new SqlParameter{ParameterName = "@JobCardPhotoEntryCode",SqlDbType = SqlDbType.Int,Direction = ParameterDirection.Output};

                IDbDataParameter[] saveParams =
                {
                    new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                    JobCardPhotoEntryCode,ResponseKey,ResponseStatus
                };

                await _sql.ExecuteNonQueryAsync("[DMS].[SP_JOB_CARD_PHOTO_AI_SAVE]",saveParams,CommandType.StoredProcedure);

                if (JobCardPhotoEntryCode.Value == DBNull.Value)
                {
                    return new ResponseEntity<JobCardPhotoResponse>
                    (
                        "Failed to save Job Card Photo",
                        false,
                        null
                    );
                }
                model.JobCardPhotoEntryCode =Convert.ToInt32(JobCardPhotoEntryCode.Value);

                var requestData = new
                {
                    jobCardPhotoEntryCode = model.JobCardPhotoEntryCode,
                    image_url = model.File.AbsoluteUri
                };


                var json = JsonConvert.SerializeObject(requestData);

                var response =await _httpClient.PostAsync("http://127.0.0.1:5050/api/jobcard_blob_extract",new StringContent(json,Encoding.UTF8,"application/json"));

                var responseString =await response.Content.ReadAsStringAsync();

                model.AIResponse =responseString;
                model.Status ="Completed";

                IDbDataParameter[] updateParams =
                {
                    new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                    new SqlParameter{ParameterName = "@ResponseKey",SqlDbType = SqlDbType.VarChar,Size = 200,Direction = ParameterDirection.Output},
                    new SqlParameter{ParameterName = "@ResponseStatus",SqlDbType = SqlDbType.Bit,Direction = ParameterDirection.Output}
                };

                await _sql.ExecuteNonQueryAsync("[DMS].[SP_JOB_CARD_PHOTO_UPDATE]",updateParams,CommandType.StoredProcedure);

                IDbDataParameter[] getParams =
                {
                    new SqlParameter("@JobCardPhotoEntryCode",model.JobCardPhotoEntryCode)
                };

                var ds =await _sql.GetDataSetAsync("[DMS].[SP_JOB_CARD_PHOTO_GET]",getParams);

                JobCardPhotoResponse responseModel =PopulatePhotoResponse(ds);

                return new ResponseEntity<JobCardPhotoResponse>
                (
                    "Success",
                    true,
                    responseModel
                );
            }

            catch (Exception ex)
            {
                return new ResponseEntity<JobCardPhotoResponse>
                (
                    ex.Message,
                    false,
                    null
                );
            }
        }
        private JobCardPhotoResponse PopulatePhotoResponse(DataSet ds)
        {
            JobCardPhotoResponse model =new JobCardPhotoResponse();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row =ds.Tables[0].Rows[0];

                model.JobCardPhotoEntryCode =MakeSafe.ToSafeInt32(row["JobCardPhotoEntryCode"]);
                model.Status = MakeSafe.ToSafeString(row["Status"]);
                model.JobCardNo =MakeSafe.ToSafeString(row["JobCardNo"]);
                model.CustomerID =MakeSafe.ToSafeString(row["CustomerID"]);
                model.CustomerName =MakeSafe.ToSafeString(row["CustomerName"]);
                model.CustomerMobile =MakeSafe.ToSafeString(row["CustomerMobile"]);
                model.VehicleNo =MakeSafe.ToSafeString(row["RegNo"]);
                model.Chassis =MakeSafe.ToSafeString(row["Chassis"]);
                model.KeyNo =MakeSafe.ToSafeString(row["KeyNo"]);
                model.Mileage =MakeSafe.ToSafeString(row["Mileage"]);
                model.Model =MakeSafe.ToSafeString(row["Model"]);
                model.Engine =MakeSafe.ToSafeString(row["Engine"]);
                model.ServiceAdvisor =MakeSafe.ToSafeString(row["ServiceAdvisor"]);
                model.SAMobile =MakeSafe.ToSafeString(row["SAMobile"]);
                model.EstimatedDate =MakeSafe.ToSafeString(row["EstimatedDate"]);
                model.EstimatedTime =MakeSafe.ToSafeString(row["EstimatedTime"]);
                model.AbsoluteUri =MakeSafe.ToSafeString(row["AbsoluteUri"]);
                model.ServiceType =MakeSafe.ToSafeString(row["ServiceType"]);
            }

            return model;
        }
    }
}
