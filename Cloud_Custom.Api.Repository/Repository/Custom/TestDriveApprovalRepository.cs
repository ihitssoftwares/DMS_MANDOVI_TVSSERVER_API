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
  public   class TestDriveApprovalRepository : ITestDriveApprovalRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public TestDriveApprovalRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<TestDriveApproval> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                   
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_TEST_DRIVE_APPROVAL_LIST]", sqlparameters);
                return ModelList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private TestDriveApproval ModelList(DataSet dataSet)
        {
            TestDriveApproval model = new TestDriveApproval();
            List<TestDriveApproval> List = new List<TestDriveApproval>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new TestDriveApproval();



                    item.LeadNo = MakeSafe.ToSafeString(row["LeadNo"]);
                    item.ReqNo = MakeSafe.ToSafeString(row["RequestCode"]);
                    item.ReqDate = MakeSafe.ToSafeString(row["RequestDate"]);
                    item.Salesexecutive = MakeSafe.ToSafeString(row["SalesExective"]);
                    item.Customer = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.ModelDetails = MakeSafe.ToSafeString(row["ModelDetails"]);
                    item.PrefDate = MakeSafe.ToSafeString(row["PrefDate"]);
                    item.Pretime = MakeSafe.ToSafeString(row["PrefTime"]);
                    item.PrefLoc = MakeSafe.ToSafeString(row["PrefLocation"]);
                    item.Address = MakeSafe.ToSafeString(row["Address"]);
                    item.Status = MakeSafe.ToSafeString(row["Status"]);


                    List.Add(item);
                }
                model.TestDriveApprovalList = List;
            }
            return model;

        }
        public async Task<TestDriveApprovalDetails> GetEmployeeDetails(UserBase user, string LeadNo)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@LeadNo",LeadNo),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_TEST_DRIVE_APPROVAL_DETAILS]", sqlparameters);

            return PopulateGetEmployeeDetails(ds);

        }
        public TestDriveApprovalDetails PopulateGetEmployeeDetails(DataSet ds)
        {

            TestDriveApprovalDetails model = new TestDriveApprovalDetails();
            model.TestDriveApprovalDetailsList = new List<TestDriveApprovalDetails>();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new TestDriveApprovalDetails
                    {

                        leadNo = MakeSafe.ToSafeString(row["leadCode"]),
                        Name = MakeSafe.ToSafeString(row["Name"]),
                        Mobilno = MakeSafe.ToSafeString(row["MobileNo"]),
                        EmailId = MakeSafe.ToSafeString(row["EmailID"]),
                        interestedModel = MakeSafe.ToSafeString(row["Model"]),
                        Color = MakeSafe.ToSafeString(row["Color"]),
                        Variant = MakeSafe.ToSafeString(row["Variant"]),
                        FuelType = MakeSafe.ToSafeString(row["FuelType"]),
                        Transmission = MakeSafe.ToSafeString(row["Transmission"]),
                        SalesExec = MakeSafe.ToSafeString(row["SalesExec"]),
                        NextFollowDate = MakeSafe.ToSafeString(row["NextDate"]),
                        LeadDate = MakeSafe.ToSafeString(row["LeadDate"]),
                        LeadStatus = MakeSafe.ToSafeString(row["Status"]),


                    };

                    model.TestDriveApprovalDetailsList.Add(item);
                }

            }
            return model;
        }
        public async Task<ResponseEntity> Save(UserBase user, TestDriveApprovalDetails model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_TEST_DRIVE_APPROVAL_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
