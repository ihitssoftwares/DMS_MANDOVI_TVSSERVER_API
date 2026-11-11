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
   public  class TestDriveCompletedRepository : ITestDriveCompletedRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public TestDriveCompletedRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<TestDriveCompleted> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_TEST_DRIVE_COMPLETED_LIST]", sqlparameters);
                return ModelList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private TestDriveCompleted ModelList(DataSet dataSet)
        {
            TestDriveCompleted model = new TestDriveCompleted();
            List<TestDriveCompleted> List = new List<TestDriveCompleted>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new TestDriveCompleted();



                    item.LeadNo = MakeSafe.ToSafeString(row["LeadCode"]);
                    item.ReqNo = MakeSafe.ToSafeString(row["RequestCode"]);
                    item.ReqDate = MakeSafe.ToSafeString(row["RequestDate"]);
                    item.Salesexecutive = MakeSafe.ToSafeString(row["SalesExective"]);
                    item.Customer = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.ModelDetails = MakeSafe.ToSafeString(row["ModelDetails"]);
                    item.PrefDate = MakeSafe.ToSafeString(row["PrefDate"]);
                    item.Pretime = MakeSafe.ToSafeString(row["PrefTime"]);
                    item.Status = MakeSafe.ToSafeString(row["Status"]);


                    List.Add(item);
                }
                model.TestDriveCompletedList = List;
            }
            return model;

        }
        public async Task<TestDriveCompletedDetails> GetEmployeeDetails(UserBase user, string LeadNo)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@LeadNo",LeadNo),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_TEST_DRIVE_COMPLETED_DETAILS]", sqlparameters);

            return PopulateGetEmployeeDetails(ds);

        }
        public TestDriveCompletedDetails PopulateGetEmployeeDetails(DataSet ds)
        {

            TestDriveCompletedDetails model = new TestDriveCompletedDetails();
            model.TestDriveCompletedDetailsList = new List<TestDriveCompletedDetails>();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new TestDriveCompletedDetails
                    {

                        SchNo = MakeSafe.ToSafeString(row["SchNo"]),
                        ReqNo = MakeSafe.ToSafeInt32(row["ReqTrnNo"]),
                        Customer = MakeSafe.ToSafeString(row["CustomerName"]),
                        Model = MakeSafe.ToSafeString(row["ModeName"]),
                        ScheduleDate = MakeSafe.ToSafeString(row["ScheduledDate"]),
                        ScheduleTime = MakeSafe.ToSafeString(row["ScheduleTime"]),
                        


                    };

                    model.TestDriveCompletedDetailsList.Add(item);
                }

            }
            return model;
        }
        public async Task<ResponseEntity> Save(UserBase user, TestDriveCompleted model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_TEST_DRIVE_COMPLETED_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
