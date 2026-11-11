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
   public  class TLvsSTRepository : ITLvsSTRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public TLvsSTRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<TLvsST> GetList(UserBase user, string data)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@data",data)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_TLvsST_LIST]", sqlparameters);
                return TLvsSTList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private TLvsST TLvsSTList(DataSet dataSet)
        {
            TLvsST model = new TLvsST();
            List<TLvsST> List = new List<TLvsST>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new TLvsST();



                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.TrnCode = MakeSafe.ToSafeInt32(row["TrnCode"]);
                    item.SMempCode = MakeSafe.ToSafeInt32(row["EmployeeCodeTL"]);
                    item.SMempname = MakeSafe.ToSafeString(row["TeamLeader"]);
                    item.TLEmpCode = MakeSafe.ToSafeInt32(row["EmployeeCodeSM"]);
                    item.TLEmpname = MakeSafe.ToSafeString(row["StoreManager"]);

                    item.ActiveFrom = MakeSafe.ToSafeDateTime(row["ActiveFrom"]);
                    item.ActiveTo = MakeSafe.ToSafeDateTime(row["ActiveTo"]);

                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, string mode, TLvsST input)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_TLvsST_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        public async Task<TLvsST> GetTLvsSTDetails(UserBase User, int TrnCode, string mode)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@TrnCode",TrnCode),


            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_TLvsSM_DETAILS]", sqlParameters);
            return PopulateModelDetails(dataSet);

        }

        private TLvsST PopulateModelDetails(DataSet dataSet)
        {
            TLvsST model = new TLvsST();
            model.Store = new Dropdown();
            model.TeamLeader = new Dropdown();
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
                model.Store.Code = MakeSafe.ToSafeInt32(row["EmployeeCodeSM"]);
                model.TeamLeader.Code = MakeSafe.ToSafeInt32(row["EmployeeCodeTL"]);
                model.Store.Name = MakeSafe.ToSafeString(row["StoreManager"]);
                model.TeamLeader.Name = MakeSafe.ToSafeString(row["TeamLeader"]);

            }

            return model;
        }
        public async Task<ResponseEntity> DeleteTLvsST(UserBase user, TLvsST model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_TLvsST_DELETE]", sqlParameters, CommandType.StoredProcedure);
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
