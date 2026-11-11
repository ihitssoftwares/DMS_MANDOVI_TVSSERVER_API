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
   public class DSEvsTLRepository : IDSEvsTLRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public DSEvsTLRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<DSEvsTL> GetList(UserBase user, string Code, string branch,string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Code", string.IsNullOrEmpty(Code) ? "0" : Code),
                 new SqlParameter("@branch", string.IsNullOrEmpty(branch) ? "0" : branch),
                
                 new SqlParameter("@Type",TabIndex)

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_DSEvsTL_LIST]", sqlparameters);
                return DSEvsTLList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private DSEvsTL DSEvsTLList(DataSet dataSet)
        {
            DSEvsTL model = new DSEvsTL();
            List<DSEvsTL> List = new List<DSEvsTL>();
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
                    var item = new DSEvsTL();



                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.TrnCode = MakeSafe.ToSafeInt32(row["TrnCode"]);
                    item.DSEempCode = MakeSafe.ToSafeInt32(row["DSEEmployeeCode"]);
                    item.DSEempname = MakeSafe.ToSafeString(row["DSEEmployee"]);
                    item.TLEmpCode = MakeSafe.ToSafeInt32(row["TLEmployeeCode"]);
                    item.TLEmpname = MakeSafe.ToSafeString(row["TeamLeader"]);
                    item.ActiveFrom = MakeSafe.ToSafeDateTime(row["ActiveFrom"]);
                    //item.ActiveTo = MakeSafe.ToSafeDateTime(row["ActiveTo"]);
                    




                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, string mode, DSEvsTL input)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(input)),
                 new SqlParameter("@Mode",mode),
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_DSEvsTL_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        public async Task<DSEvsTL> GetDSEvsTLDetails(UserBase User, int TrnCode, string mode, int EmpCode)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@TrnCode",TrnCode),
                new SqlParameter("@EmpCode",EmpCode),


            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_DSEvsTL_DETAILS]", sqlParameters);
            return PopulateModelDetails(dataSet);

        }

        private DSEvsTL PopulateModelDetails(DataSet dataSet)
        {
            DSEvsTL model = new DSEvsTL();
            model.DSEemp = new Dropdown();
            model.TeamLeader = new Dropdown();
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
                model.DSEemp.Code = MakeSafe.ToSafeInt32(row["EmployeeCodeDse"]);
                model.TeamLeader.Code = MakeSafe.ToSafeInt32(row["EmployeeCodeTL"]);
                model.DSEemp.Name = MakeSafe.ToSafeString(row["DSEEmployee"]);
                

            }

            return model;
        }
        public async Task<ResponseEntity> DeleteDSEvsTL(UserBase user, DSEvsTL model)
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

                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_DSEvsTL_DELETE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<DSEvsTL> GetUpdatedDetails(UserBase user, int Trnno)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@EmpCode",Trnno),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_UPDATED_PLANSETTINGS_POPUP_DETAILS]", sqlparameters);

            return PopulateGetUpdatedDetails(ds);

        }
        public DSEvsTL PopulateGetUpdatedDetails(DataSet ds)
        {
            var model = new DSEvsTL();
            model.List = new List<DSEvsTL>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.List.Add(new DSEvsTL
                    {
                        DSEempCode = MakeSafe.ToSafeInt32(row["DSEEmployeeCode"]),
                        DSEempname = MakeSafe.ToSafeString(row["DSEEmployee"]),
                        TLEmpCode = MakeSafe.ToSafeInt32(row["TLEmployeeCode"]),
                        TLEmpname = MakeSafe.ToSafeString(row["TeamLeader"]),
                        ActiveFrom = MakeSafe.ToSafeDateTime(row["ActiveFrom"]),
                        ActiveTo = MakeSafe.ToSafeDateTime(row["ActiveTo"])
                    });
                }
            }

            return model;
        }
    }
}
