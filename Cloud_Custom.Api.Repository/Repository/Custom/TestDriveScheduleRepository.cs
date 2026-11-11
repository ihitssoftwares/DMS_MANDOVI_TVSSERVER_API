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
  public  class TestDriveScheduleRepository : ITestDriveScheduleRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public TestDriveScheduleRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<TestDriveSchedule> GetList(UserBase User)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_TEST_DRIVE_SCHEDULED_LIST]", sqlparameters);
                return ScheduleList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private TestDriveSchedule ScheduleList(DataSet dataSet)
        {
            TestDriveSchedule model = new TestDriveSchedule();
            List<TestDriveSchedule> List = new List<TestDriveSchedule>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new TestDriveSchedule();



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
                model.TestDriveScheduleList = List;
            }
            return model;

        }
        public async Task<TestDriveScheduleDetails> GetEmployeeDetails(UserBase user, string LeadNo)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@LeadNo",LeadNo),


            };
          
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_TEST_DRIVE_SCHEDULE_DETAILS]", sqlparameters);
            
           
            var result = PopulateGetEmployeeDetails(ds);
          
            return result;

        }


        public TestDriveScheduleDetails PopulateGetEmployeeDetails(DataSet ds)
        {
            TestDriveScheduleDetails model = new TestDriveScheduleDetails();
            model.TestDriveScheduleDetailsList = new List<TestDriveScheduleDetails>();
            model.Time = new Dropdown();
            model.Vehicle = new Dropdown();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                model.LeadNo = MakeSafe.ToSafeString(row["RequestNo"]);
                model.Customer = MakeSafe.ToSafeString(row["Name"]);
                model.MobileNo = MakeSafe.ToSafeString(row["MobileNo"]);
                model.PrefDate = MakeSafe.ToSafeString(row["PrefDate"]);
                model.PrefTime = MakeSafe.ToSafeString(row["PrefTime"]);
                model.ScheduleDate = MakeSafe.ToSafeString(row["PrefDate"]);
                model.Time.Code = MakeSafe.ToSafeInt32(row["ScheduleTime"]);
                model.Vehicle.Code = MakeSafe.ToSafeInt32(row["VehicleCode"]);
                model.ModelName = MakeSafe.ToSafeString(row["ModeName"]);
                model.VariantName = MakeSafe.ToSafeString(row["VariantName"]);
            }

            
            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    var item = new TestDriveScheduleDetails
                    {
                        BranchName = MakeSafe.ToSafeString(row["BranchName"]),
                        VehicleCode = MakeSafe.ToSafeInt32(row["VehicleCode"]),
                        Name = MakeSafe.ToSafeString(row["Name"]),
                        RegnNo = MakeSafe.ToSafeString(row["RegnNo"]),
                        ScheduledDate = MakeSafe.ToSafeDateTime(row["ScheduledDate"]),
                        ScheduleTime = MakeSafe.ToSafeString(row["ScheduleTime"]),
                        TestDate = MakeSafe.ToSafeString(row["TestDate"]),
                        TestTime = MakeSafe.ToSafeString(row["TestTime"]),
                        Availability = MakeSafe.ToSafeString(row["Availability"])
                    };

                    model.TestDriveScheduleDetailsList.Add(item);
                }
            }

            return model;
        }

        public async Task<ResponseEntity> Save(UserBase user, TestDriveSchedule model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_TEST_DRIVE_SCHEDULE_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
