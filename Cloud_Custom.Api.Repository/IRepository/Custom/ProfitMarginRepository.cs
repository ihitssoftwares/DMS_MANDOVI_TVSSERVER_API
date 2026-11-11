using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public class ProfitMarginRepository : IProfitMarginRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ProfitMarginRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<ProfitMargin> GetList(UserBase user, int VechicleModel)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                  new SqlParameter("@VechicleModel",VechicleModel),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_PROFIT_MARGIN_EXTENDED_MARGIN_LIST]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }


        private ProfitMargin DesignationVsParameterList(DataSet dataSet)
        {
            ProfitMargin model = new ProfitMargin();
            List<ProfitMargin> List = new List<ProfitMargin>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ProfitMargin();


                    item.Extendedwarantycode = MakeSafe.ToSafeInt32(row["Extendedwarantycode"]);
                    item.Name = MakeSafe.ToSafeString(row["Name"]);
                    item.WarrantyPrice = MakeSafe.ToSafeInt32(row["Warrantyprize"]);
                    item.Commission = MakeSafe.ToSafeInt32(row["commission"]);
                    item.Amount = MakeSafe.ToSafeDecimal(row["Amount"]);
                    



                    List.Add(item);
                }
                model.List = List;
            }


           
            return model;
        }



        public async Task<ProfitMargin> GetTabList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                  new SqlParameter("@Type",TabIndex)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_PROFIT_MARGIN_INSURANCE_FINANACE_LIST]", sqlparameters);
                return SalesPositionList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private ProfitMargin SalesPositionList(DataSet dataSet)
        {
            ProfitMargin model = new ProfitMargin();
            List<ProfitMargin> List = new List<ProfitMargin>();
            
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ProfitMargin();


                    item.Code = MakeSafe.ToSafeInt32(row["Code"]);
                    item.Name = MakeSafe.ToSafeString(row["Name"]);
                    item.Commission = MakeSafe.ToSafeInt32(row["commission"]);



                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }



        public async Task<ResponseEntity> SettingsSave(UserBase User, ProfitMargin model, int VechicleModel)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 250, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
                IDbDataParameter[] sqlParameters =
                {
                    new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                    new SqlParameter("@CompanyGI",User.CompanyGuid),
                    new SqlParameter("@UserGI",User.UserGuid),
                    new SqlParameter("@VechicleModel",VechicleModel),
            ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_PROFIT_MARGIN_EXTENDED_WARRANTY_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException EX)
            {
                var ErrorMsg = EX.Message.ToString();
                throw new Exception(ErrorMsg, EX);
            }
        }



        public async Task<ResponseEntity> Save(UserBase User, ProfitMargin model, string TabIndex)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 250, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
                IDbDataParameter[] sqlParameters =
                {
                    new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                    new SqlParameter("@CompanyGI",User.CompanyGuid),
                    new SqlParameter("@UserGI",User.UserGuid),
                    new SqlParameter("@TabIndex",TabIndex),
            ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_PROFIT_MARGIN_INSURANCENCE_AND_BANK_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException EX)
            {
                var ErrorMsg = EX.Message.ToString();
                throw new Exception(ErrorMsg, EX);
            }
        }
    }
}
