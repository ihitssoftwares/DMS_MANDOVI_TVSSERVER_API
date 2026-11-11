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
   public  class SalesTargetRepository : ISalesTargetRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public SalesTargetRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<SalesTarget> GetList(UserBase user, int month, int Branch)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@month",month),
                  new SqlParameter("@Branch",Branch),
                

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SalesTarget_LIST]", sqlparameters);
                return SalesTargetList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private SalesTarget SalesTargetList(DataSet dataSet)
        {
            SalesTarget model = new SalesTarget();
            List<SalesTarget> List = new List<SalesTarget>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new SalesTarget();
                    item.Branch = new Dropdown();
                    item.Month = new Dropdown();

                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    item.Store = MakeSafe.ToSafeString(row["Store"]);
                    item.TeamLeadCode = MakeSafe.ToSafeInt32(row["TeamLeadCode"]);
                    item.TeamLead = MakeSafe.ToSafeString(row["TeamLead"]);
                    item.DSE = MakeSafe.ToSafeString(row["DSE"]);
                    item.Enquire = MakeSafe.ToSafeInt32(row["Enquire"]);
                    item.Booking = MakeSafe.ToSafeInt32(row["booking"]);
                    item.RetailTarget = MakeSafe.ToSafeInt32(row["Retailtarget"]);
                    item.Vahan = MakeSafe.ToSafeInt32(row["vahan"]);

                    item.EnquirePre = MakeSafe.ToSafeDecimal(row["EnquirePre"]);
                    item.Bookingpre = MakeSafe.ToSafeDecimal(row["bookingPre"]);
                    item.RetailTargetPre = MakeSafe.ToSafeDecimal(row["RetailtargetPre"]);
                    item.VahanPre = MakeSafe.ToSafeDecimal(row["vahanPre"]);


                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }

        public async Task<SalesTarget> GetEmployeeDetails(UserBase user, int month, int Type,int TeamLeadCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@month",month),
                  new SqlParameter("@Branch",Type),
                    new SqlParameter("@TeamLeadCode",TeamLeadCode),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_EMPLOYEE_DETAILS_LIST]", sqlparameters);
                return EmpList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private SalesTarget EmpList(DataSet dataSet)
        {
            SalesTarget model = new SalesTarget();
            List<SalesTarget> List = new List<SalesTarget>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new SalesTarget();
                    item.Branch = new Dropdown();
                    item.Month = new Dropdown();



                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    item.Store = MakeSafe.ToSafeString(row["Store"]);
                    
                    item.TeamLead = MakeSafe.ToSafeString(row["TeamLead"]);
                    item.DSE = MakeSafe.ToSafeString(row["DSE"]);
                    item.Enquire = MakeSafe.ToSafeInt32(row["Enquire"]);
                    item.Booking = MakeSafe.ToSafeInt32(row["booking"]);
                    item.RetailTarget = MakeSafe.ToSafeInt32(row["Retailtarget"]);
                    item.Vahan = MakeSafe.ToSafeInt32(row["vahan"]);

                    item.EnquirePre = MakeSafe.ToSafeDecimal(row["EnquirePre"]);
                    item.Bookingpre = MakeSafe.ToSafeDecimal(row["bookingPre"]);
                    item.RetailTargetPre = MakeSafe.ToSafeDecimal(row["RetailtargetPre"]);
                    item.VahanPre = MakeSafe.ToSafeDecimal(row["vahanPre"]);


                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }
        public async Task<ResponseEntity> EmpSave(SalesTarget Model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@JSONDATA",JsonHelper.ToJson(Model)),
                ResponseKey,ResponseStatus
            };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_EmployeeSave]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
