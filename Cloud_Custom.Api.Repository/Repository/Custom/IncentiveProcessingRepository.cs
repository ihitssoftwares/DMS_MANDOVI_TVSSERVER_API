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
    public class IncentiveProcessingRepository : IIncentiveProcessingRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public IncentiveProcessingRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<IncentiveProcessing> GetList(UserBase user,  int Month, int Delearship, int Designation, int Incentive)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),


                new SqlParameter("@Month",Month),
                 new SqlParameter("@DealershipCode",Delearship),
                  new SqlParameter("@IncentiveTypeCode",Incentive),
                 new SqlParameter("@SalesDesignationCode",Designation),
            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_INCENTIVE_PROCESSED_LIST_ALL]", sqlparameters);

            return PopulateGetList(ds);

        }
        public IncentiveProcessing PopulateGetList(DataSet ds)
        {
            IncentiveProcessing model = new IncentiveProcessing();
            model.IncentiveList = new List<IncentiveProcessing>();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    IncentiveProcessing item = new IncentiveProcessing
                    {
                        HDCode = MakeSafe.ToSafeInt32(row["HDCode"]),
                        EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]),
                        EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]),
                        Empid = MakeSafe.ToSafeString(row["EmployeeId"]),
                        BranchName = MakeSafe.ToSafeString(row["BranchName"]),
                        IsSubmitted = MakeSafe.ToSafeString(row["IsSubmitted"]),
                        TotalTarget = MakeSafe.ToSafeDecimal(row["TotalTarget"]),
                        TotalAchieved = MakeSafe.ToSafeDecimal(row["TotalAchieved"]),
                        MinimumPercentageNeededForIncentive =
                            MakeSafe.ToSafeDecimal(row["MinimumPercentageNeededForIncentive"]),
                        TotalAchievedPercentage =
                            MakeSafe.ToSafeDecimal(row["TotalAchievedPercentage"]),
                        IncentiveAmountAcheived =
                            MakeSafe.ToSafeDecimal(row["IncentiveAmountAcheived"])
                    };

                    model.IncentiveList.Add(item);
                }
            }

            return model;
        }



        public async Task<ResponseEntity> EmployeeWiseUpdate(UserBase user, IncentiveProcessing model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_EMPLOYEE_INCENTIVE_PROCESSING_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }


        public async Task<ResponseEntity> Process(UserBase user,int Month, int Delearship, int Designation, int Incentive)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {       new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),


                new SqlParameter("@Month",Month),
                 new SqlParameter("@DealershipCode",Delearship),
                  new SqlParameter("@IncentiveTypeCode",Incentive),
                 new SqlParameter("@SalesDesignationCode",Designation),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_INCENTIVE_PROCESSING]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }


        public async Task<ResponseEntity> Validate(UserBase user, int Month, int Delearship, int Designation, int Incentive)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 500, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {       new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),


                new SqlParameter("@Month",Month),
                 new SqlParameter("@DealershipCode",Delearship),
                  new SqlParameter("@IncentiveTypeCode",Incentive),
                 new SqlParameter("@SalesDesignationCode",Designation),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_INCENTIVE_PROCESSING_VALIDATE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }



        public async Task<IncentiveProcessing> GetEmployeeDetails(UserBase user, int HDCode, int EmployeeCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),


                new SqlParameter("@HDCode",HDCode),
                 new SqlParameter("@EmployeeCode",EmployeeCode),
                
            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_INCENTIVE_PROCESSED_EMPLOYEE_DETAILS_LIST]", sqlparameters);

            return PopulateGetEmployeeDetails(ds);

        }
        public IncentiveProcessing PopulateGetEmployeeDetails(DataSet ds)
        {
            IncentiveProcessing model = new IncentiveProcessing();
            model.EmployeeDetailsList = new List<EmployeeDetails>();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    EmployeeDetails item = new EmployeeDetails
                    {
                        EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]),
                        EmployeeID = MakeSafe.ToSafeString(row["EmployeeID"]),
                        EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]),
                        ModelName = MakeSafe.ToSafeString(row["ModelName"]),
                        PerUnitIncentiveAmount = MakeSafe.ToSafeDecimal(row["PerUnitIncentiveAmount"]),
                        AchievedTarget = MakeSafe.ToSafeInt32(row["AchievedTarget"]),
                        IncentiveAmountAchieved = MakeSafe.ToSafeDecimal(row["IncentiveAmountAchieved"])
                    };

                    model.EmployeeDetailsList.Add(item);
                }
            }

            return model;
        }

    }
}

