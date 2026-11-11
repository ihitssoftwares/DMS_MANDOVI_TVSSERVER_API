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
  public   class TestDriveRepository : ITestDriveRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public TestDriveRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<TestDrive> GetList(UserBase user, String Type)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                    new SqlParameter("@Type",Type)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_TEST_DRIVE_LIST]", sqlparameters);
                return ModelList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private TestDrive ModelList(DataSet dataSet)
        {
            TestDrive model = new TestDrive();
            List<TestDrive> List = new List<TestDrive>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new TestDrive();
                    


                    item.LeadNo = MakeSafe.ToSafeString(row["LeadNo"]);
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
                model.TestDriveList = List;
            }
            return model;

        }

        public async Task<TestDrive> GetLead(UserBase user, String Customer)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),
                    new SqlParameter("@Customer",Customer)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_GETLEAD]", sqlparameters);
                return leadList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public TestDrive leadList(DataSet dataSet)
        {
            TestDrive model = new TestDrive();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];

                model.TrnCode = MakeSafe.ToSafeInt32(row["TrnCode"]);
                model.LeadNo = MakeSafe.ToSafeString(row["LeadNo"]);
                model.MobileNo = MakeSafe.ToSafeString(row["MobileNo"]);
            }

            return model;
        }
        public async Task<ResponseEntity> Save(UserBase user, TestDrive model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_TEST_DRIVE_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }

        public async Task<TestDriveDetails> GetEmployeeDetails(UserBase user, string LeadNo)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@LeadNo",LeadNo),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_TEST_DRIVE_DETAILS]", sqlparameters);

            return PopulateGetEmployeeDetails(ds);

        }
        public TestDriveDetails PopulateGetEmployeeDetails(DataSet ds)
        {

            TestDriveDetails model = new TestDriveDetails();
            model.TestDriveDetailsList = new List<TestDriveDetails>();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new TestDriveDetails
                    {
                       
                        leadNo = MakeSafe.ToSafeString(row["leadCode"]),
                        Name= MakeSafe.ToSafeString(row["Name"]),

                        interestedModel = MakeSafe.ToSafeString(row["ModelDetails"]),
                        FuelType = MakeSafe.ToSafeString(row["FuelType"]),
                        Transmission = MakeSafe.ToSafeString(row["Transmission"]),
                        NextFollowDate = MakeSafe.ToSafeString(row["NextDate"]),
                        LeadStatus = MakeSafe.ToSafeString(row["Status"]),
                       

                    };

                    model.TestDriveDetailsList.Add(item);
                }

            }
            return model;
        }
    }
}
