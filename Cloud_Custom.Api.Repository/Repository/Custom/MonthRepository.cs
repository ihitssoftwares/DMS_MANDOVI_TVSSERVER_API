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
   public  class MonthRepository : IMonthRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public MonthRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<Month> GetList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Type",TabIndex)
           
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_Month_LIST]", sqlparameters);
                return MonthList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private Month MonthList(DataSet dataSet)
        {
            Month model = new Month();
            List<Month> List = new List<Month>();
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
                    var item = new Month();



                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.MonthCode = MakeSafe.ToSafeInt32(row["MonthCode"]);
                    item.Monthname = MakeSafe.ToSafeString(row["MonthName"]);
                    item.year = MakeSafe.ToSafeString(row["MonthYear"]);
                    item.FromDate = MakeSafe.ToSafeString(row["FROMDATE"]);
                    item.Todate = MakeSafe.ToSafeString(row["TODATE"]);
                    item.FinancialYear = MakeSafe.ToSafeString(row["FinancialYear"]);



                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, string mode, Month model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_MONTH_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<Month> GetMonthDetails(UserBase User, int MonthCode, string mode, string Type)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@MonthCode",MonthCode),
                new SqlParameter("@Type",Type),

            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_MONTH_DETAILS]", sqlParameters);
            return PopulateMonthDetails(dataSet);

        }
        private Month PopulateMonthDetails(DataSet dataSet)
        {
            Month model = new Month();


            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];


                model.MonthCode = MakeSafe.ToSafeInt32(row["MonthCode"]);
                model.Monthname = MakeSafe.ToSafeString(row["MonthName"]);
                model.FromDate = Convert.ToDateTime(row["FROMDATE"]).ToString("yyyy-MM-dd");
                model.Todate = Convert.ToDateTime(row["TODATE"]).ToString("yyyy-MM-dd");
                model.year = MakeSafe.ToSafeString(row["MonthYear"]);
                model.FinancialYear = MakeSafe.ToSafeString(row["FinancialYear"]);
                model.Active = MakeSafe.ToSafeBool(row["IsActive"]);
            }

            return model;
        }
    }
}
