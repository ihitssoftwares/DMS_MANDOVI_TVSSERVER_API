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
     public class ServiceAchievedRepository : IServiceAchievedRepository
    {

        private readonly ISqlConnectionProvider _sql;
        public ServiceAchievedRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<ServiceAchieved> GetList(UserBase user,int Month, int Designation, int Parameter)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Month",Month),
                 new SqlParameter("@Designation",Designation),
                 new SqlParameter("@Parameter",Parameter),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_ACHIEVED_LIST]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private ServiceAchieved DesignationVsParameterList(DataSet dataSet)
        {
            ServiceAchieved model = new ServiceAchieved();
            List<ServiceAchieved> List = new List<ServiceAchieved>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceAchieved();
                    model.Month = new Dropdown();
                    model.Parameter = new Dropdown();
                    model.SalesDesignation = new Dropdown();


                    item.SlNo = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.UserCode = MakeSafe.ToSafeInt32(row["UserCode"]);
                    item.EmpCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);
                    item.EmpPosition = MakeSafe.ToSafeString(row["EmployeePosition"]);
                    //item.TeamLead = MakeSafe.ToSafeString(row["TeamLead"]);
                    item.Branch = MakeSafe.ToSafeString(row["BranchName"]);
                    item.DealerName = MakeSafe.ToSafeString(row["DealershipName"]);
                    item.incentiveGroupname = MakeSafe.ToSafeString(row["IncentiveGroupName"]);
                    item.Value = MakeSafe.ToSafeDecimal(row["Value"]);
                    item.GrossPay = MakeSafe.ToSafeDecimal(row["GrossPay"]);
                    model.Month.Code = MakeSafe.ToSafeInt32(row["Month"]);
                    model.Parameter.Code = MakeSafe.ToSafeInt32(row["Designation"]);
                    model.SalesDesignation.Code = MakeSafe.ToSafeInt32(row["Parameter"]);

                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, ServiceAchieved Model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@JSONDATA",JsonHelper.ToJson(Model)),
                ResponseKey,ResponseStatus
            };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_SERVICE_ACHIVEMENT_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
