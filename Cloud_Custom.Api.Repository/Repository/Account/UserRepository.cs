using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Infrastructure.ISecurity;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Account;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Account
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly IHash _hash;

        public UserRepository(ISqlConnectionProvider sql, IHash hash)
        {
            _sql = sql;
            _hash = hash;
        }

        public async Task<User> GetUserList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
            new SqlParameter("@CompanyGI", user.CompanyGuid),
            new SqlParameter("@UserGuid", user.UserGuid),
            new SqlParameter("@GroupCompanyGI", user.GroupCompanyGI),
            new SqlParameter("@Type", TabIndex),

        };

                var ds = await _sql.GetDataSetAsync("[HRMS].[SP_USER_MASTER_LIST]", sqlparameters);
                return PopulateActiveUserList(ds);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private User PopulateActiveUserList(DataSet dataSet)
        {
            User model = new User();
            List<UserList> list = new List<UserList>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                model.ActiveCount = MakeSafe.ToSafeInt32(dataSet.Tables[0].Rows[0]["ActiveCount"]);
                model.InactiveCount = MakeSafe.ToSafeInt32(dataSet.Tables[0].Rows[0]["InactiveCount"]);
            }

            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    UserList item = new UserList();

                    item.UserMasterGI = MakeSafe.ToSafeGuid(row["UserGI"]);
                    item.UserCode = MakeSafe.ToSafeInt32(row["UserCode"]);
                    item.UserName = MakeSafe.ToSafeString(row["Name"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["EmpName"]);
                    item.UserRole = MakeSafe.ToSafeString(row["UserRoleName"]);
                    item.Email = MakeSafe.ToSafeString(row["Email"]);
                    item.Mobile = MakeSafe.ToSafeString(row["Mobile"]);
                    item.ValidTo = MakeSafe.ToSafeDateTime(row["ActiveTo"]);
                    item.PasswordExpiry = MakeSafe.ToSafeDateTime(row["PasswordExpiredOn"]);
                    item.FullPermission = MakeSafe.ToSafeString(row["FullPermission"]);
                    item.active = MakeSafe.ToSafeInt32(row["Active"]);

                    list.Add(item);
                }

                model.UserList = list;
            }

            return model;
        }

        
        public async Task<User> GetUserDetails(UserBase user, Guid UserMasterGI, Guid LogGI, string Type)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI", user.CompanyGuid),
        new SqlParameter("@UserGI", UserMasterGI),
        new SqlParameter("@LogGI", LogGI),
        new SqlParameter("@Type", Type)
    };

            var ds = await _sql.GetDataSetAsync("[HRMS].[SP_USER_MASTER_DETAILS]", sqlParameters);
            return PopulateUserDetails(ds);
        }

        private User PopulateUserDetails(DataSet dataSet)
        {
            User model = new User();
            model.UserRole = new UserRole();
            model.UserVsEmployeeApplicability = new UserVsEmployeeApplicability();          // ← add this
            model.UserVsEmployeeApplicability.GroupCompany = new List<GroupCompany>();      // ← add this
            model.UserVsEmployeeApplicability.Region = new List<Region>();
            model.UserVsEmployeeApplicability.Branch = new List<StoreOrBranch>();
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    model.UserMasterGI = MakeSafe.ToSafeGuid(row["UserGI"]);
                    model.LogGI = MakeSafe.ToSafeGuid(row["LogGI"]);
                    model.Code = MakeSafe.ToSafeInt32(row["UserCode"]);
                    model.Name = MakeSafe.ToSafeString(row["Name"]);
                    model.UserRole.Code = MakeSafe.ToSafeInt32(row["UserRoleCode"]);
                    model.UserRole.Name = MakeSafe.ToSafeString(row["UserRoleName"]);
                    model.FullPermission = MakeSafe.ToSafeBool(row["FullPermission"]);
                    model.Mobile = MakeSafe.ToSafeString(row["MobileNo"]);
                    model.Email = MakeSafe.ToSafeString(row["Email"]);
                    model.ActiveFrom = MakeSafe.ToSafeDateTime(row["ActiveFrom"]);
                    model.ActiveTo = MakeSafe.ToSafeDateTime(row["ActiveTo"]);
                    model.PasswordExpiredOn = MakeSafe.ToSafeString(row["PasswordExpiredOn"]);
                    model.Active = MakeSafe.ToSafeBool(row["Active"]);
                    model.Remarks = MakeSafe.ToSafeString(row["Remarks"]);
                    model.ExcelPassword = MakeSafe.ToSafeString(row["ExcelPassword"]);
                }
            }
            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    model.UserVsEmployeeApplicability.Branch.Add(new StoreOrBranch
                    {
                        Code = MakeSafe.ToSafeInt32(row["Code"]),
                        Name = MakeSafe.ToSafeString(row["Name"]),
                        Applicable = MakeSafe.ToSafeBool(row["Applicable"])
                    });
                }
            }

            if ((dataSet.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[2].Rows)
                {
                    model.UserVsEmployeeApplicability.GroupCompany.Add(new GroupCompany
                    {
                        Code = MakeSafe.ToSafeInt32(row["Code"]),
                        Name = MakeSafe.ToSafeString(row["Name"]),
                        Applicable = MakeSafe.ToSafeBool(row["Applicable"])
                    });
                }
            }
            
           

            return model;
        }
        public async Task<User> GetApplicableMenus(UserBase user, int UserRoleCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
            new SqlParameter("@CompanyGI", user.CompanyGuid),
            new SqlParameter("@UserRoleCode", UserRoleCode)
        };

                var ds = await _sql.GetDataSetAsync("[HRMS].[SP_USER_MASTER_ROLE_PERMISSIONS]", sqlparameters);
                return PopulateApplicableMenus(ds);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private User PopulateApplicableMenus(DataSet dataSet)
        {
            User model = new User();
            List<ApplicableMenus> list = new List<ApplicableMenus>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ApplicableMenus();
                    item.Module = MakeSafe.ToSafeString(row["Module"]);
                    item.SubModule = MakeSafe.ToSafeString(row["SubModule"]);
                    item.Menus = MakeSafe.ToSafeString(row["MenuName"]);
                    list.Add(item);
                }
            }

            model.ApplicableMenus = list;
            return model;
        }

        public async Task<ResponseEntity> UserSave(User model)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                if (model.Mode == "CREATE")
                {
                    string hash_N, salt_N;
                    _hash.CreatePasswordHash(model.NonEmployeePassword, out hash_N, out salt_N);
                    model.PasswordHash = hash_N;
                    model.PasswordSalt = salt_N;
                }

                IDbDataParameter[] sqlParameters =
                {
            new SqlParameter("@JSONDATA",   JsonHelper.ToJson(model)),
            new SqlParameter("@USER_TYPE",  "USER"),
            ResponseKey, ResponseStatus
                 };

                await _sql.ExecuteNonQueryAsync("[HRMS].[SP_USER_MASTER_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ResponseEntity> UserDelete(User model)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
            new SqlParameter("@CompanyGI",  model.UserBase.CompanyGuid),
            new SqlParameter("@AuthUserGI", model.UserMasterGI),
            new SqlParameter("@UserGI",     model.UserBase.UserGuid),
            ResponseKey, ResponseStatus
        };

                await _sql.ExecuteNonQueryAsync("[HRMS].[SP_USER_MASTER_DELETE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ResponseEntity> ResetPassword(UserBase user, Guid UserMasterGI, string Password)
        {
            try
            {
                string hash, salt;
                _hash.CreatePasswordHash(Password, out hash, out salt);

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
            new SqlParameter("@CompanyGI",    user.CompanyGuid),
            new SqlParameter("@UserGI",       user.UserGuid),
            new SqlParameter("@AuthUserGI",   UserMasterGI),
            new SqlParameter("@PasswordHash", hash),
            new SqlParameter("@PasswordSalt", salt),
            ResponseKey, ResponseStatus
        };

                await _sql.ExecuteNonQueryAsync("[HRMS].[SP_USER_MASTER_RESET_PASSWORD]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ResponseEntity> GetMasterInactiveValidation(UserBase user, string name, int code)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
            new SqlParameter("@CompanyGI", user.CompanyGuid),
            new SqlParameter("@Name",      name),
            new SqlParameter("@Code",      code),
            ResponseKey, ResponseStatus
        };

                await _sql.ExecuteNonQueryAsync("[HRMS].[SP_MASTER_INACTIVE_VALIDATION]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
