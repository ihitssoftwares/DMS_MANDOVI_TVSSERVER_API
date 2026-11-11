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
     public class UserRoleRepository: IUserRoleRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public UserRoleRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<UserRole> GetUserRoleList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Type",TabIndex)

            };
                var ds = await _sql.GetDataSetAsync("[HRMS].[SP_USER_ROLE_LIST]", sqlparameters);

                if (TabIndex == "APPROVAL_PENDING")
                    return PopulateUserRolePendingList(ds);
                else
                    return PopulateUserRoleList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private UserRole PopulateUserRoleList(DataSet dataSet)
        {
            UserRole model = new UserRole();
            List<UserRole> List = new List<UserRole>();
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    model.ActiveCount = MakeSafe.ToSafeInt32(row["ActiveCount"]);
                    model.InactiveCount = MakeSafe.ToSafeInt32(row["InactiveCount"]);
                    model.PendingCount = MakeSafe.ToSafeInt32(row["PendingCount"]);

                }
            }

            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new UserRole();
                  
                    item.userrole = MakeSafe.ToSafeString(row["Name"]);
                    item.ShortName = MakeSafe.ToSafeString(row["ShortName"]);
                    item.GI = MakeSafe.ToSafeGuid(row["UserRoleGI"]);
                    item.Code = MakeSafe.ToSafeInt32(row["UserRoleCode"]);
                   // item.SalaryVisibility.Name = MakeSafe.ToSafeString(row["ViewSalary"]);
                    item.PermittedActions = MakeSafe.ToSafeString(row["Permission"]);
                    item.MakerChecker = MakeSafe.ToSafeBool(row["MakerChecker"]);
                    item.EditActive = MakeSafe.ToSafeBool(row["EditActive"]);
                    List.Add(item);
                }
                model.UserRoleList = List;
            }

            return model;

        }
        private UserRole PopulateUserRolePendingList(DataSet dataSet)
        {
            UserRole model = new UserRole();
            List<UserRole> List = new List<UserRole>();
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    model.ActiveCount = MakeSafe.ToSafeInt32(row["ActiveCount"]);
                    model.InactiveCount = MakeSafe.ToSafeInt32(row["InactiveCount"]);
                    model.PendingCount = MakeSafe.ToSafeInt32(row["PendingCount"]);

                }
            }

            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new UserRole();
                    //item.SalaryVisibility = new SalaryVisibility();
                    item.userrole = MakeSafe.ToSafeString(row["Name"]);
                    item.ShortName = MakeSafe.ToSafeString(row["ShortName"]);
                    item.GI = MakeSafe.ToSafeGuid(row["UserRoleGI"]);
                    item.Code = MakeSafe.ToSafeInt32(row["UserRoleCode"]);
                    item.LogGI = MakeSafe.ToSafeGuid(row["LogGI"]);
                    item.SalaryVisibility.Name = MakeSafe.ToSafeString(row["ViewSalary"]);
                    item.PermittedActions = MakeSafe.ToSafeString(row["Permission"]);
                    item.EntryType = MakeSafe.ToSafeString(row["EntryMode"]);
                    item.MakerChecker = MakeSafe.ToSafeBool(row["MakerChecker"]);
                    item.EditActive = MakeSafe.ToSafeBool(row["EditActive"]);
                    List.Add(item);
                }
                model.UserRoleList = List;
            }

            return model;

        }
        public async Task<UserRole> GetUserRoleTabDetails(UserBase user, Guid UserRoleGI)
        {

            IDbDataParameter[] sqlParameters =
             {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@UserRoleGI",UserRoleGI),

            };
            var ds = await _sql.GetDataSetAsync("[HRMS].[SP_USER_ROLE_TAB_APPLICABILITY_LIST]", sqlParameters);
            return PopulateUserRoleTabDetails(ds);

        }

        private UserRole PopulateUserRoleTabDetails(DataSet dataSet)
        {
            int Tablecount = dataSet.Tables.Count;
            UserRole model = new UserRole();
            List<FormPermissionMenuTab> UserVsMenuTab = new List<FormPermissionMenuTab>();
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {

                    FormPermissionMenuTab list = new FormPermissionMenuTab()
                    {
                        GI = MakeSafe.ToSafeGuid(row["UserRoleGI"]),
                        TabCode = MakeSafe.ToSafeInt32(row["TabCode"]),
                        MenuCode = MakeSafe.ToSafeInt32(row["MenuCode"]),
                        MenuName = MakeSafe.ToSafeString(row["MenuName"]),
                        TabName = MakeSafe.ToSafeString(row["TabName"]),
                        Applicable = MakeSafe.ToSafeBool(row["Applicability"])

                    };
                    UserVsMenuTab.Add(list);
                    model.UserVsMenuTab = UserVsMenuTab;
                }


            }


            return model;
        }
        public async Task<UserRole> GetUserRoleDetails(UserBase user, Guid UserRoleGI, Guid LogGI, string Type)
        {

            IDbDataParameter[] sqlParameters =
             {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserRoleGI",UserRoleGI),
                 new SqlParameter("@LogGI",LogGI),
                  new SqlParameter("@Type",Type),

            };
            var ds = await _sql.GetDataSetAsync("[HRMS].[SP_USER_ROLE_DETAILS]", sqlParameters);
            return PopulateUserRoleDetails(ds);

        }

        private UserRole PopulateUserRoleDetails(DataSet dataSet)
        {
            int Tablecount = dataSet.Tables.Count;
            UserRole model = new UserRole();
            List<FormPermissionModule> UserVsModule = new List<FormPermissionModule>();
            List<FormPermissionSubModule> UserVsSubModule = new List<FormPermissionSubModule>();
            List<FormPermissionMenu> UserVsMenu = new List<FormPermissionMenu>();
            model.SalaryVisibility = new SalaryVisibility();
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {


                model.userrole = MakeSafe.ToSafeString(dataSet.Tables[0].Rows[0]["Name"]);
                model.ShortName = MakeSafe.ToSafeString(dataSet.Tables[0].Rows[0]["ShortName"]);
                model.Active = MakeSafe.ToSafeBool(dataSet.Tables[0].Rows[0]["Active"]);
                model.SalaryVisibility.Code = MakeSafe.ToSafeInt32(dataSet.Tables[0].Rows[0]["ViewSalary"]);
                model.View = MakeSafe.ToSafeBool(dataSet.Tables[0].Rows[0]["MasterView"]);
                model.Create = MakeSafe.ToSafeBool(dataSet.Tables[0].Rows[0]["MasterCreate"]);
                model.Modify = MakeSafe.ToSafeBool(dataSet.Tables[0].Rows[0]["MasterEdit"]);
                model.Approve = MakeSafe.ToSafeBool(dataSet.Tables[0].Rows[0]["MasterApprove"]);// not in db side
                model.Delete = MakeSafe.ToSafeBool(dataSet.Tables[0].Rows[0]["MasterDelete"]);
                model.Remarks = MakeSafe.ToSafeString(dataSet.Tables[0].Rows[0]["Remarks"]);
                model.GI = MakeSafe.ToSafeGuid(dataSet.Tables[0].Rows[0]["UserRoleGI"]);
                model.LogGI = MakeSafe.ToSafeGuid(dataSet.Tables[0].Rows[0]["LogGI"]);
                model.Code = MakeSafe.ToSafeInt32(dataSet.Tables[0].Rows[0]["UserRoleCode"]);


            }

            if ((dataSet.Tables[3]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[3].Rows)
                {

                    FormPermissionMenu list = new FormPermissionMenu()
                    {
                        Code = MakeSafe.ToSafeInt32(row["MenuCode"]),
                        Name = MakeSafe.ToSafeString(row["MenuName"]),
                        ModuleName = MakeSafe.ToSafeString(row["ModuleName"]),
                        SubModuleName = MakeSafe.ToSafeString(row["SubModuleName"]),
                        Applicable = MakeSafe.ToSafeBool(row["Applicable"])

                    };
                    UserVsMenu.Add(list);
                    model.UserVsMenu = UserVsMenu;
                }

            }
            if ((dataSet.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[2].Rows)
                {

                    FormPermissionSubModule list = new FormPermissionSubModule()
                    {
                        Code = MakeSafe.ToSafeInt32(row["SubModuleCode"]),
                        Name = MakeSafe.ToSafeString(row["SubModuleName"]),
                        ModuleName = MakeSafe.ToSafeString(row["ModuleName"]),
                        Applicable = MakeSafe.ToSafeBool(row["Applicable"])

                    };
                    UserVsSubModule.Add(list);
                    model.UserVsSubModule = UserVsSubModule;
                }

            }
            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {

                    FormPermissionModule list = new FormPermissionModule()
                    {
                        Code = MakeSafe.ToSafeInt32(row["ModuleCode"]),
                        Name = MakeSafe.ToSafeString(row["ModuleName"]),
                        Applicable = MakeSafe.ToSafeBool(row["Applicable"])

                    };
                    UserVsModule.Add(list);
                    model.UserVsModule = UserVsModule;
                }

            }
            return model;
        }
        public async Task<UserRole> GetApplicabilityDetails(UserBase user, Head input)
        {

            IDbDataParameter[] sqlParameters =
             {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@JSONDATA",JsonHelper.ToJson(input)),

            };
            var ds = await _sql.GetDataSetAsync("[HRMS].[SP_USER_ROLE_MODULE_CHANGED]", sqlParameters);
            return PopulateApplicabilityDetails(ds);

        }

        private UserRole PopulateApplicabilityDetails(DataSet dataSet)
        {
            int Tablecount = dataSet.Tables.Count;
            UserRole model = new UserRole();
            List<FormPermissionModule> UserVsModule = new List<FormPermissionModule>();
            List<FormPermissionSubModule> UserVsSubModule = new List<FormPermissionSubModule>();
            List<FormPermissionMenu> UserVsMenu = new List<FormPermissionMenu>();


            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {

                    FormPermissionModule list = new FormPermissionModule()
                    {
                        Code = MakeSafe.ToSafeInt32(row["ModuleCode"]),
                        Name = MakeSafe.ToSafeString(row["ModuleName"]),
                        Applicable = MakeSafe.ToSafeBool(row["Applicable"])

                    };
                    UserVsModule.Add(list);
                    model.UserVsModule = UserVsModule;
                }

            }
            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {

                    FormPermissionSubModule list = new FormPermissionSubModule()
                    {
                        Code = MakeSafe.ToSafeInt32(row["SubModuleCode"]),
                        ModuleName = MakeSafe.ToSafeString(row["ModuleName"]),
                        Name = MakeSafe.ToSafeString(row["SubModuleName"]),
                        Applicable = MakeSafe.ToSafeBool(row["Applicable"])

                    };
                    UserVsSubModule.Add(list);
                    model.UserVsSubModule = UserVsSubModule;
                }

            }
            if ((dataSet.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[2].Rows)
                {

                    FormPermissionMenu list = new FormPermissionMenu()
                    {
                        Code = MakeSafe.ToSafeInt32(row["MenuCode"]),
                        ModuleName = MakeSafe.ToSafeString(row["ModuleName"]),
                        SubModuleName = MakeSafe.ToSafeString(row["SubModuleName"]),
                        Name = MakeSafe.ToSafeString(row["MenuName"]),
                        Applicable = MakeSafe.ToSafeBool(row["Applicable"])

                    };
                    UserVsMenu.Add(list);
                    model.UserVsMenu = UserVsMenu;
                }

            }
            return model;
        }
        public async Task<ResponseEntity> UserRoleSave(UserRole input)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
            new SqlParameter("@JSONDATA",JsonHelper.ToJson(input)),
            ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[HRMS].[SP_USER_ROLE_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }

        }
        public async Task<ResponseEntity> TabApplicabilitySave(UserRole input)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
            new SqlParameter("@JSONDATA",JsonHelper.ToJson(input)),
            ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[HRMS].[SP_USER_ROLE_TAB_APPLICABILITY_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }

        }

        public async Task<ResponseEntity> UserRoleDelete(UserBase user, Guid UserRoleGI)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {

                    new SqlParameter("@CompanyGI",user.CompanyGuid),
                    new SqlParameter("@UserGI",user.UserGuid),
                    new SqlParameter("@UserRoleGI",UserRoleGI),
                    ResponseKey,ResponseStatus
                };
                await _sql.ExecuteNonQueryAsync("[HRMS].[SP_USER_ROLE_DELETE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));

            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }



        public async Task<ResponseEntity> UserRoleApproveOrReject(UserRole model)
        {

            try
            {
                //model.User.UserGuid= Guid.Parse("3DCE5EF0-8B83-47A1-A238-B969B334463A");
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
            new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
            ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[HRMS].[SP_USER_ROLE_APPROVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }

        }

    }
}
