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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public DepartmentRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<Department> GetList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Type",TabIndex)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_DEPARTMENT_LIST]", sqlparameters);
                return DepartmentList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private Department DepartmentList(DataSet dataSet)
        {
            
            Department model = new Department();
            List<Department> GetList = new List<Department>();
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    model.ActiveCount = MakeSafe.ToSafeInt32(row["ActiveCount"]);
                    model.InactiveCount = MakeSafe.ToSafeInt32(row["InactiveCount"]);


                }
            }
            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new Department();



                    item.Slno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.DepartmentCode = MakeSafe.ToSafeInt32(row["DepartmentCode"]);
                    item.DepartmentName = MakeSafe.ToSafeString(row["Name"]);
                    item.ShortName = MakeSafe.ToSafeString(row["ShortName"]);
                    item.DtType = MakeSafe.ToSafeString(row["DeptType"]);
                    item.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);


                    GetList.Add(item);
                }
                model.List = GetList;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, string mode, Department input)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_DEPARTMENT_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<Department> GetDepartmentDetails(UserBase User, int DepartmentCode, string mode, string Type)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@DepartmentCode",DepartmentCode),


            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_DEPARTMENT_DETAILS]", sqlParameters);
            return PopulateDepartmentDetails(dataSet);

        }

        private Department PopulateDepartmentDetails(DataSet dataSet)
        {
            Department model = new Department();


            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];

                
                model.Type = new Dropdown()
                {
                    Name = MakeSafe.ToSafeString(row["DepartmentTypeName"]),
                    Code = MakeSafe.ToSafeInt32(row["DepartmentTypeCode"])
                };
                model.DepartmentCode = MakeSafe.ToSafeInt32(row["DepartmentCode"]);
                model.DepartmentName = MakeSafe.ToSafeString(row["DepartmentName"]);
                model.ShortName = MakeSafe.ToSafeString(row["ShortName"]);
                model.DMSCode = MakeSafe.ToSafeString(row["DmsCode"]);
                model.Active = MakeSafe.ToSafeBool(row["IsActive"]);
            }

            return model;
        }
        public async Task<ResponseEntity> DeleteDepartment(UserBase user, Department model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_DEPARTMENT_DELETE]", sqlParameters, CommandType.StoredProcedure);
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
