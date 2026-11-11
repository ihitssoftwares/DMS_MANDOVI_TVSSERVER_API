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
    public class WareHouseRepository : IWareHouseRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public WareHouseRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<WareHouse> GetList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Type",TabIndex)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_WAREHOUSE_LIST_LIST]", sqlparameters);
                return WarehouseList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private WareHouse WarehouseList(DataSet dataSet)
        {
            WareHouse model = new WareHouse();
            List<WareHouse> List = new List<WareHouse>();
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
                    var item = new WareHouse();



                    item.Slno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.WareHouseCode = MakeSafe.ToSafeInt32(row["WareHouseCode"]);
                    item.WareHouseName = MakeSafe.ToSafeString(row["WareHouseName"]);
                    item.ShortName = MakeSafe.ToSafeString(row["WareHouseShortName"]);
                    item.Region = MakeSafe.ToSafeString(row["RegionName"]);
                    item.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);


                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }

        public async Task<ResponseEntity> Save(UserBase user, string mode, WareHouse input)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_WAREHOUSE_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        public async Task<WareHouse> GetWareHouseDetails(UserBase User, int WareHouseCode, string mode, string Type)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@WareHouseCode",WareHouseCode),


            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_WAREHOUSE_DETAILS]", sqlParameters);
            return PopulateWareHouseDetails(dataSet);

        }

        private WareHouse PopulateWareHouseDetails(DataSet dataSet)
        {
            WareHouse model = new WareHouse();
            

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];

                model.Regionn = new Dropdown()
                {
                    Name = MakeSafe.ToSafeString(row["RegionName"]),
                    Code = MakeSafe.ToSafeInt32(row["RegionCode"])
                };
                model.WareHouseCode = MakeSafe.ToSafeInt32(row["WareHouseCode"]);
                model.WareHouseName = MakeSafe.ToSafeString(row["WareHouseName"]);
                model.ShortName = MakeSafe.ToSafeString(row["WareHouseShortName"]);
                

                model.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);
                model.Active = MakeSafe.ToSafeBool(row["IsActive"]);
            }

            return model;
        }
        public async Task<ResponseEntity> DeleteWareHouse(UserBase user, WareHouse model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_WAREHOUSE_DELETE]", sqlParameters, CommandType.StoredProcedure);
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

