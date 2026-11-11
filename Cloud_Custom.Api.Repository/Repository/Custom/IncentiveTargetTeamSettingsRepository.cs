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
    public class IncentiveTargetTeamSettingsRepository : IIncentiveTargetTeamSettingsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public IncentiveTargetTeamSettingsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<IncentiveTargetTeamSettings> GetBranch(UserBase user, int EmployeeCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@EmployeeCode",EmployeeCode),
                

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_EMPLOYEE_BRANCH_TARGET_TEAM_LIST]", sqlparameters);
                return PopulateList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private IncentiveTargetTeamSettings PopulateList(DataSet dataSet)
        {
            IncentiveTargetTeamSettings model = new IncentiveTargetTeamSettings();
            
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                model.BranchName = MakeSafe.ToSafeString(dataSet.Tables[0].Rows[0]["BranchName"]);
                

            }
            return model;


        }

        public async Task<IncentiveTargetTeamSettings> GetList(UserBase user, int EmployeeCode,int Branch)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@EmployeeCode",EmployeeCode),
                 new SqlParameter("@Branch",Branch),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_TARGET_INCENTIVE_TEAM_SETTINGS_LIST]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private IncentiveTargetTeamSettings DesignationVsParameterList(DataSet dataSet)
        {
            IncentiveTargetTeamSettings model = new IncentiveTargetTeamSettings();
            List<IncentiveTargetTeamSettings> List = new List<IncentiveTargetTeamSettings>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new IncentiveTargetTeamSettings();



                    item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);
                    item.Designation = MakeSafe.ToSafeString(row["Designation"]);
                    item.IncentiveGroupName = MakeSafe.ToSafeString(row["IncentiveGroupName"]);
                    item.IncentiveGroupCode = MakeSafe.ToSafeInt32(row["IncentiveGroupCode"]);
                    item.IsApplicable = MakeSafe.ToSafeBool(row["Applicabilty"]);


                    List.Add(item);
                }
                model.List = List;
            }


            //if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            //{
            //    foreach (DataRow row in dataSet.Tables[1].Rows)
            //    {

            //        model.PendingCount = MakeSafe.ToSafeInt32(row["PendingCount"]);

            //    }
            //}
            return model;
        }











        public async Task<ResponseEntity> IncentiveSettingsSave(UserBase user, IncentiveTargetTeamSettings model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_INCENTIVE_TARGET_TEAM_SETTINGS_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }



    }
}
