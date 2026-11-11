using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Custom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
    public class LateHourConfirmationRepository : ILateHourConfirmationRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public LateHourConfirmationRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<AttendanceWagesConfirmation> ConfirmationList_PROFANT(UserBase user, string TabIndex, int Month, Filter filter)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@GroupCompanyGI",user.GroupCompanyGI),
                new SqlParameter("@TabIndex",TabIndex),
                new SqlParameter("@SalaryPeriodCode",Month),
                new SqlParameter("@JSONDATA",JsonHelper.ToJson(filter)),
            };
            var ds = await _sql.GetDataSetAsync("[HRMS].[SP_LESS_HOUR_CONFIRMATION_LIST_PROFANT]", sqlparameters);

            return PopulateConfirmationList_PROFANT(ds);

        }
        private AttendanceWagesConfirmation PopulateConfirmationList_PROFANT(DataSet ds)
        {
            AttendanceWagesConfirmation model = new AttendanceWagesConfirmation();
            model.ConfirmationList = new List<AttendanceWagesConfirmationDetails>();
            List<AttendanceWagesConfirmationDetails> List = new List<AttendanceWagesConfirmationDetails>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new AttendanceWagesConfirmationDetails();
                    item.Designation = new Dropdown();
                    item.Department = new Dropdown();
                    item.Location = new Dropdown();

                    item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    item.EmployeeGI = MakeSafe.ToSafeGuid(row["EmployeeGI"]);
                    item.EmployeeID = MakeSafe.ToSafeString(row["EmployeeID"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);
                    item.Designation.Name = MakeSafe.ToSafeString(row["DesignationName"]);
                    item.Department.Name = MakeSafe.ToSafeString(row["DepartmentName"]);
                    item.Location.Name = MakeSafe.ToSafeString(row["LocationName"]);
                    item.MinutesToCut = MakeSafe.ToSafeDecimal(row["MinutesToCut"]);
                    item.TotalDay = MakeSafe.ToSafeDecimal(row["TotalDays"]);
                    item.DeductionDays = MakeSafe.ToSafeDecimal(row["DeductionDays"]);
                    item.totalRecords = MakeSafe.ToSafeInt32(row["TotalCount"]);
                    item.active = MakeSafe.ToSafeInt32(row["ACTIVE"]);
                    List.Add(item);
                }

                model.ConfirmationList = List;
            }
            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.PendingCount = MakeSafe.ToSafeInt32(row["PENDING"]);
                    model.ConfirmedCount = MakeSafe.ToSafeInt32(row["CONFIRMED"]);
                }

            }
            return model;

        }


        public async Task<AttendanceWagesConfirmation> GetEmployeeAttnDetails_PROFANT(UserBase user, int Month, Guid EmployeeGI)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
               {
                new SqlParameter("@CompanyGuid",user.CompanyGuid),
                new SqlParameter("@SalaryPeriodCode",Month),
                new SqlParameter("@EmployeeGI",EmployeeGI),
            };
                var ds = await _sql.GetDataSetAsync("[HRMS].[SP_LESS_HOUR_CONFIRMATION_EMPLOYEE_ATTENDANCE_DETAILS_PROFANT]", sqlparameters);

                return PopulateEmployeeAttnDetails_PROFANT(ds);

            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private AttendanceWagesConfirmation PopulateEmployeeAttnDetails_PROFANT(DataSet ds)
        {
            AttendanceWagesConfirmation model = new AttendanceWagesConfirmation();
            model.AttnDetails = new List<AttnDetails>();
            List<AttnDetails> List = new List<AttnDetails>();


            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                model.EmployeeName = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["EmployeeName"]);
            }
            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    var item = new AttnDetails();

                    item.Date = MakeSafe.ToSafeString(row["PunchingDate"]);
                    item.IN = MakeSafe.ToSafeString(row["PunchIn"]);
                    item.Out = MakeSafe.ToSafeString(row["PunchOut"]);
                    item.LateIn = MakeSafe.ToSafeString(row["LateIn"]);
                    item.EarlyOut = MakeSafe.ToSafeString(row["EarlyOut"]);
                    item.Total = MakeSafe.ToSafeString(row["TotalHours"]);
                    List.Add(item);
                }
                model.AttnDetails = List;
            }
            return model;

        }

        public async Task<ResponseEntity> LessHourConfirmationSave_PROFANT(AttendanceWagesConfirmation Model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@JSONDATA",JsonHelper.ToJson(Model)),
                ResponseKey,ResponseStatus
            };
            await _sql.ExecuteNonQueryAsync("[HRMS].[SP_LESS_HOURS_CONFIRMATION_SAVE_PROFANT]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }


        public async Task<DataSet> ConfirmationList_PROFANT_EXCEL(UserBase user, int Month, string Tab, Filter filter)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
           {

                new SqlParameter("@JSONDATA",JsonHelper.ToJson(filter)),
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@GroupCompanyGI",user.GroupCompanyGI),
                new SqlParameter("@SalaryPeriodCode",Month),
                new SqlParameter("@TabIndex",Tab),
                new SqlParameter("@ReturnType","EXCEL"),

            };
                var ds = await _sql.GetDataSetAsync("[HRMS].[SP_LESS_HOUR_CONFIRMATION_LIST_PROFANT]", sqlparameters);
                return (ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }


        private AttendanceWagesConfirmation PopulateDetailsProfant(DataSet ds)
        {
            var item = new AttendanceWagesConfirmation();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {

                item.DeductionDays = MakeSafe.ToSafeDecimal(ds.Tables[0].Rows[0]["ConfirmedValue"]);

                item.EmployeeName = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["Name"]);
                return item;
            }
            return null;
        }
        public async Task<ResponseEntity> Update_PROFANT(AttendanceWagesConfirmation model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
             {
            new SqlParameter("@CompanyGI",model.User.CompanyGuid),
                new SqlParameter("@UserGuid",model.User.UserGuid),
                new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
            ResponseKey,ResponseStatus//,ResponseGuid
            };
            await _sql.ExecuteNonQueryAsync("[HRMS].[SP_LESS_HOUR_CONFIRMATION_UPDATE_PROFANT]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
