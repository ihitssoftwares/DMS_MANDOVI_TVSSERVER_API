using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
    public class LeadEnquiryUploadRepository : ILeadEnquiryUploadRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public LeadEnquiryUploadRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<ResponseEntity<List<LeadEnquiryUploadImportModel>>> ImportFromExcel(UserBase user, LeadEnquiryUpload model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),

                     new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };


            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_LEAD_ENQUIRY_IMPORT_EXCEL]", sqlParameters);
            var unmatchedDetails = PopulateUnmatchedDetails(ds);

            return new ResponseEntity<List<LeadEnquiryUploadImportModel>>(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value), unmatchedDetails);
        }
        public List<LeadEnquiryUploadImportModel> PopulateUnmatchedDetails(DataSet ds)
        {
            List<LeadEnquiryUploadImportModel> list = new List<LeadEnquiryUploadImportModel>();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new LeadEnquiryUploadImportModel
                    {
                        LeadNo = MakeSafe.ToSafeString(row["DealerCode"]),
                        Name = MakeSafe.ToSafeString(row["CustomerName"]),
                        SourceOfEnquiry = MakeSafe.ToSafeString(row["EnquiryNumber"]),
                        modelName = MakeSafe.ToSafeString(row["Message"]),
                    };

                    list.Add(item);
                }
            }

            return list;
        }


        public async Task<LeadEnquiryUpload> GetList(UserBase user, Filter filter, int Month)
        {

            IDbDataParameter[] sqlparameters =
           {
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(filter)),
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@Month",Month),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_LEAD_ENQUIRY_DOWNLOAD_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public LeadEnquiryUpload PopulateGetList(DataSet ds)
        {
            LeadEnquiryUpload model = new LeadEnquiryUpload();
            model.LeadEnquiryUploadImportModel = new List<LeadEnquiryUploadImportModel>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new LeadEnquiryUploadImportModel
                    {
                        DEnquiryNum = MakeSafe.ToSafeString(row["LeadNo"]),
                        DProspectName = MakeSafe.ToSafeString(row["Name"]),
                        DEnquirySource = MakeSafe.ToSafeString(row["SourceOfEnquiry"]),
                        DModel = MakeSafe.ToSafeString(row["InterestedModel"]),
                        DColorCode = MakeSafe.ToSafeString(row["Color"]),
                        DNewCarEnquiryStatus = MakeSafe.ToSafeString(row["LeadStatus"]),
                        DEnquiryMode = MakeSafe.ToSafeString(row["modeofcontact"]),
                        DNextFollowupPlannedDate = MakeSafe.ToSafeString(row["nextfollowupdate"]),
                        active = MakeSafe.ToSafeInt32(row["ACTIVE"]),
                        totalRecords = MakeSafe.ToSafeInt32(row["TotalCount"])

                };

                    model.LeadEnquiryUploadImportModel.Add(item);
                }
            }

            return model;
        }
    }
}
