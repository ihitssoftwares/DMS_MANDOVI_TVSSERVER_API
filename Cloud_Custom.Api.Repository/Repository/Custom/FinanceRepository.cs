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
    public class FinanceRepository : IFinanceRepository
    {

        private readonly ISqlConnectionProvider _sql;
        public FinanceRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<Finance> GetList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@TabIndex",TabIndex),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[GET_FINANCE_LIST]", sqlparameters);
                return FinanceList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private Finance FinanceList(DataSet dataSet)
        {
            Finance model = new Finance();
            List<Finance> List = new List<Finance>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new Finance();


                    item.FinancierCode = MakeSafe.ToSafeInt32(row["FinancierCode"]);
                    item.FinancierName = MakeSafe.ToSafeString(row["FinancierName"]);
                    item.ShortName = MakeSafe.ToSafeString(row["ShortName"]);
                    item.FinancierType = MakeSafe.ToSafeString(row["FinancierType"]);
                   
                    item.MSSF = MakeSafe.ToSafeBool(row["MSSF"]);

                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, string mode, Finance model)
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
               new SqlParameter("@Mode",mode),
                ResponseKey,ResponseStatus
                };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_FINANCE_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<Finance> GetFinanceDetails(UserBase User, int FinancierCode, string mode)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@FinancierCode",FinancierCode),


            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[GET_FINANCE_DETAILS]", sqlParameters);
            return PopulateFinanceDetails(dataSet);

        }

        private Finance PopulateFinanceDetails(DataSet dataSet)
        {
            Finance model = new Finance();


            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];


                model.FinancierCode = MakeSafe.ToSafeInt32(row["FinancierCode"]);
                model.FinancierName = MakeSafe.ToSafeString(row["FinancierName"]);
                model.ShortName = MakeSafe.ToSafeString(row["ShortName"]);
                model.FinancierType = MakeSafe.ToSafeString(row["FinancierType"]);
                model.Active = MakeSafe.ToSafeBool(row["Active"]);
                model.MSSF = MakeSafe.ToSafeBool(row["MSSF"]);
            }

            return model;
        }

        public async Task<ResponseEntity> FinanceDelete(UserBase User, Finance model)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),

                        ResponseKey,ResponseStatus
                };

                await _sql.ExecuteNonQueryAsync("[DMS].[SP_FINANCE_DELETE]", sqlParameters, CommandType.StoredProcedure);
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
