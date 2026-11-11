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
    public class ColdCallEnquireRepository : IColdCallEnquireRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ColdCallEnquireRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<ColdCallEnquire> GetList(UserBase user)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_COLD CALL_ENQUIRE_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public ColdCallEnquire PopulateGetList(DataSet ds)
        {
            ColdCallEnquire model = new ColdCallEnquire();
            model.ColdCallEnquireList = new List<ColdCallEnquire>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new ColdCallEnquire
                    {
                        
                        ColdCallNo = MakeSafe.ToSafeString(row["EnqNo"]),

                        EnquireDate = MakeSafe.ToSafeString(row["EnquiryDate"]),
                        CustomerName = MakeSafe.ToSafeString(row["Name"]),
                        Mobilno = MakeSafe.ToSafeString(row["MobileNo"]),
                        IntrestedModel = MakeSafe.ToSafeString(row["InterestedModel"]),
                        SourceOfEnquiry = MakeSafe.ToSafeString(row["SourceOfEnquiry"]),
                        Statuss = MakeSafe.ToSafeString(row["Status"]),

                    };

                    model.ColdCallEnquireList.Add(item);
                }
            }

            return model;
        }


        public async Task<ColdCallEnquireItem> GetEmployeeDetails(UserBase user,string ColdCallNo)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@EnqCode",ColdCallNo),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_COLD CALL_ENQUIRE_DETAILS]", sqlparameters);

            return PopulateGetEmployeeDetails(ds);

        }
        public ColdCallEnquireItem PopulateGetEmployeeDetails(DataSet ds)
        {

            ColdCallEnquireItem model = new ColdCallEnquireItem();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {

                DataRow row = ds.Tables[0].Rows[0];


                model = new ColdCallEnquireItem

                {
                    TrnCode = MakeSafe.ToSafeInt32(row["TrnCode"]),
                    ColdCallNo = MakeSafe.ToSafeString(row["EnqNo"]),

                    EnquireDate = MakeSafe.ToSafeString(row["EnquiryDate"]),
                    CustomerName = MakeSafe.ToSafeString(row["Name"]),
                    Mobilno = MakeSafe.ToSafeString(row["MobileNo"]),
                    EmailId = MakeSafe.ToSafeString(row["EmailID"]),
                    IntrestedModel = MakeSafe.ToSafeString(row["InterestedModel"]),
                    SourceOfEnquiry = MakeSafe.ToSafeString(row["SourceOfEnquiry"]),


                };
            }

            return model;
        }
        public async Task<ResponseEntity> Save(UserBase user, ColdCallEnquire model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_COLD_CALL_ENQUIRY_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }

}
    

    

