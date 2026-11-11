using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
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
   public  class SalesEmpRepository : ISalesEmpRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public SalesEmpRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<SalesEmp> GetList(UserBase user, Filter filter, int Dearler,int Branch,int SalesDes,int Incentive, int Department,int Region,int SeniorRegManager)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                    new SqlParameter("@JSONDATA",JsonHelper.ToJson(filter)),
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Dealer",Dearler),
                 new SqlParameter("@Branch",Branch),
                 new SqlParameter("@SalesDes",SalesDes),
                 new SqlParameter("@Incentive",Incentive),
                 new SqlParameter("@Position",Department),
                 new SqlParameter("@Region",Region),
                 new SqlParameter("@SeniorRegManager",SeniorRegManager)

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SALESEMP_LIST]", sqlparameters);
                return EmpList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private SalesEmp EmpList(DataSet dataSet)
        {
            SalesEmp model = new SalesEmp();
            List<SalesEmp> List = new List<SalesEmp>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new SalesEmp();



                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.UserCode = MakeSafe.ToSafeString(row["UserCode"]);
                    item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);
                    item.EmpPosition = MakeSafe.ToSafeString(row["EmployeePosition"]);
         
                    item.TeamLead = MakeSafe.ToSafeString(row["TeamLead"]);
                    item.Branch = MakeSafe.ToSafeString(row["BranchName"]);
                    item.DealerName = MakeSafe.ToSafeString(row["DealershipName"]);
                    item.incentiveGroupname = MakeSafe.ToSafeString(row["IncentiveGroupName"]);
                   
                    item.GrossPay = MakeSafe.ToSafeDecimal(row["GrossPay"]);
                    item.MSPin = MakeSafe.ToSafeString(row["MSPin"]);
                    item.Region = MakeSafe.ToSafeString(row["RegionName"]);
                    item.SRM = MakeSafe.ToSafeInt32(row["SRM"]);
                    item.RM = MakeSafe.ToSafeInt32(row["RM"]);
                    item.active = MakeSafe.ToSafeInt32(row["ACTIVE"]);
                    item.totalRecords = MakeSafe.ToSafeInt32(row["TotalCount"]);

                    List.Add(item);
                }
                model.List = List;
            }
                return model;

        }

        public async Task<ResponseEntity> Save(UserBase user, string mode, SalesEmp input)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(input)),
                 new SqlParameter("@Mode",mode),
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_SALES_EMPLOYEE_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        public async Task<SalesEmp> GetEmployeeDetails(UserBase User, int EmployeeCode, string mode)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@EmployeeCode",EmployeeCode),
                

            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_GET_EMPLOYEE_DETAILS]", sqlParameters);
            return PopulateEmployeeDetails(dataSet);

        }

        private SalesEmp PopulateEmployeeDetails(DataSet dataSet)
        {
            SalesEmp model = new SalesEmp();
            model.teamLeader = new Dropdown();
            model.Incentive = new Dropdown();
            model.SalesDes = new Dropdown();
            model.Branchs = new Dropdown();
            model.Dearler = new Dropdown();
            model.Position = new Dropdown();
            model.Department = new Dropdown();
            model.UserRole = new Dropdown();

            model.District = new Dropdown();
            model.Gender = new Dropdown();
            model.Division = new Dropdown();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
                model.UserCode = MakeSafe.ToSafeString(row["UserCode"]);
                model.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                model.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);
                model.Department.Code = MakeSafe.ToSafeInt32(row["DepartmentCode"]);
                model.Department.Name = MakeSafe.ToSafeString(row["DepartmentName"]);
                model.Position.Code = MakeSafe.ToSafeInt32(row["PositionCode"]);
                model.Position.Name = MakeSafe.ToSafeString(row["PositionName"]);
                model.Dearler.Code = MakeSafe.ToSafeInt32(row["DelearshipCode"]);
                model.Dearler.Name = MakeSafe.ToSafeString(row["DealershipName"]);
                model.teamLeader.Code = MakeSafe.ToSafeInt32(row["EmployeeCodeTL"]);
                model.teamLeader.Name = MakeSafe.ToSafeString(row["EmployeeNameTL"]);
                model.Branchs.Code = MakeSafe.ToSafeInt32(row["BranchCode"]);
                model.Branchs.Name = MakeSafe.ToSafeString(row["BranchName"]);
                model.SalesDes.Code = MakeSafe.ToSafeInt32(row["SalesDesignationCode"]);
                model.SalesDes.Name = MakeSafe.ToSafeString(row["SalesDesignationName"]);
                model.Incentive.Code = MakeSafe.ToSafeInt32(row["IncentiveGroupCode"]);
                model.Incentive.Name = MakeSafe.ToSafeString(row["IncentiveGroupName"]);
                model.UserRole.Code = MakeSafe.ToSafeInt32(row["UserRoleCode"]);
                model.UserRole.Name = MakeSafe.ToSafeString(row["UserRoleName"]);
                model.Status = MakeSafe.ToSafeString(row["Status"]);
                model.GrossPay = MakeSafe.ToSafeDecimal(row["GrossPay"]);
                model.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);

                model.District.Code = MakeSafe.ToSafeInt32(row["DistrictCode"]);
                model.District.Name = MakeSafe.ToSafeString(row["DistrictName"]);
                model.Gender.Code = MakeSafe.ToSafeInt32(row["GenderCode"]);
                model.Gender.Name = MakeSafe.ToSafeString(row["GenderName"]);
                model.Division.Code = MakeSafe.ToSafeInt32(row["DivisionCode"]);
                model.Division.Name = MakeSafe.ToSafeString(row["DivisionName"]);
                model.MSPin = MakeSafe.ToSafeString(row["MSPin"]);
                model.SRM = MakeSafe.ToSafeInt32(row["SRM"]);
                model.RM = MakeSafe.ToSafeInt32(row["RM"]);

            }
            return model;
        }
        public async Task<ResponseEntity> DeleteSalesEmp(UserBase user, SalesEmp model)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),

                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_SALES_EMPLOYEE_DELETE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }




        public async Task<ResponseEntity> PopupSave(UserBase user, SalesEmp model)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                // new SqlParameter("@Mode",mode),
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_EMPPOPUP_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        public async Task<SalesEmp> GetPopupList(UserBase user, int EmployeeCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                  new SqlParameter("@EmployeeCode",EmployeeCode),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_EMPPOPUP_LIST]", sqlparameters);
                return Popuplist(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private SalesEmp Popuplist(DataSet dataSet)
        {
            SalesEmp model = new SalesEmp();
            List<SalesEmp> PopupList = new List<SalesEmp>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new SalesEmp();




                    item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    item.DtCode = MakeSafe.ToSafeInt32(row["DtCode"]);


                    item.MatchingName = MakeSafe.ToSafeString(row["MatchingName"]);





                    PopupList.Add(item);
                }
                model.List = PopupList;
            }
            return model;

        }


        public async Task<ResponseEntity> DeletePopup(UserBase user, int EmployeeCode, int DtCode)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                // new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                 new SqlParameter("@EmployeeCode",EmployeeCode),
                  new SqlParameter("@DtCode",DtCode),

                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_EMPPOPUP_DELETE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        public async Task<SalesEmp> GetExportToExcel(UserBase user, int Dealer, int Branch, int SalesDes, int Incentive, int Department, int Region)
        {
            try
            {

                IDbDataParameter[] sqlparameters =
                {
                     new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Dealer",Dealer),
                 new SqlParameter("@Branch",Branch),
                 new SqlParameter("@SalesDes",SalesDes),
                 new SqlParameter("@Incentive",Incentive),
                 new SqlParameter("@Position",Department),
                 new SqlParameter("@Region",Region)
                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SALESEMP_EXPORTTOEXEL]", sqlparameters);
                return EmpExportList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private SalesEmp EmpExportList(DataSet dataSet)
        {
            SalesEmp model = new SalesEmp();
            List<SalesEmp> List = new List<SalesEmp>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new SalesEmp();



                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.UserCode = MakeSafe.ToSafeString(row["UserCode"]);
                    item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);
                    item.EmpPosition = MakeSafe.ToSafeString(row["EmployeePosition"]);

                    item.TeamLead = MakeSafe.ToSafeString(row["TeamLead"]);
                    item.Branch = MakeSafe.ToSafeString(row["BranchName"]);
                    item.DealerName = MakeSafe.ToSafeString(row["DealershipName"]);
                    item.incentiveGroupname = MakeSafe.ToSafeString(row["IncentiveGroupName"]);
                    item.Status = MakeSafe.ToSafeString(row["Status"]);
                    item.GrossPay = MakeSafe.ToSafeDecimal(row["GrossPay"]);
                    item.MSPin = MakeSafe.ToSafeString(row["MSPin"]);
                    item.Region = MakeSafe.ToSafeString(row["RegionName"]);
                    item.active = MakeSafe.ToSafeInt32(row["ACTIVE"]);
                    item.totalRecords = MakeSafe.ToSafeInt32(row["TotalCount"]);

                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }

    }
}
