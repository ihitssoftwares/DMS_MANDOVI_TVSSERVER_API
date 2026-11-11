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
    public class ServicePartsRepository: IServicePartsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ServicePartsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<ServiceParts> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid)
                 
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICEPARTS_LIST]", sqlparameters);
                return WarehouseList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private ServiceParts WarehouseList(DataSet dataSet)
        {
            ServiceParts model = new ServiceParts();
            List<ServiceParts> List = new List<ServiceParts>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceParts();



                  
                    item.ServicePartsCode = MakeSafe.ToSafeInt32(row["ServicePartsCode"]);
                    item.ShortName = MakeSafe.ToSafeString(row["ShortName"]);
                    item.Name = MakeSafe.ToSafeString(row["Name"]);
                    item.ServiceType = MakeSafe.ToSafeString(row["ServiceType"]);
                    item.ServiceCategory = MakeSafe.ToSafeString(row["ServiceCategory"]);


                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }

        //public async Task<ResponseEntity> Save(UserBase user, string mode, WareHouse input)
        //{
        //    try
        //    {

        //        SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
        //        SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

        //        IDbDataParameter[] sqlParameters =
        //        {
        //         new SqlParameter("@CompanyGI",user.CompanyGuid),
        //         new SqlParameter("@UserGuid",user.UserGuid),
        //         new SqlParameter("@JSONDATA",JsonHelper.ToJson(input)),
        //         new SqlParameter("@Mode",mode),
        //            ResponseKey,ResponseStatus
        //    };
        //        await _sql.ExecuteNonQueryAsync("[DMS].[SP_WAREHOUSE_SAVE]", sqlParameters, CommandType.StoredProcedure);
        //        return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        //    }
        //    catch (SqlException ex)
        //    {
        //        var ErrorMsg = ex.Message.ToString();
        //        throw new Exception(ErrorMsg, ex);
        //    }
        //}

        //public async Task<WareHouse> GetWareHouseDetails(UserBase User, int WareHouseCode, string mode, string Type)
        //{

        //    IDbDataParameter[] sqlParameters =
        //     {
        //        new SqlParameter("@CompanyGI",User.CompanyGuid),
        //         new SqlParameter("@UserGuid",User.UserGuid),
        //        new SqlParameter("@WareHouseCode",WareHouseCode),


        //    };
        //    var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_WAREHOUSE_DETAILS]", sqlParameters);
        //    return PopulateWareHouseDetails(dataSet);

        //}

        //private WareHouse PopulateWareHouseDetails(DataSet dataSet)
        //{
        //    WareHouse model = new WareHouse();


        //    if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        //    {
        //        DataRow row = dataSet.Tables[0].Rows[0];

        //        model.Regionn = new Dropdown()
        //        {
        //            Name = MakeSafe.ToSafeString(row["RegionName"]),
        //            Code = MakeSafe.ToSafeInt32(row["RegionCode"])
        //        };
        //        model.WareHouseCode = MakeSafe.ToSafeInt32(row["WareHouseCode"]);
        //        model.WareHouseName = MakeSafe.ToSafeString(row["WareHouseName"]);
        //        model.ShortName = MakeSafe.ToSafeString(row["WareHouseShortName"]);


        //        model.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);
        //        model.Active = MakeSafe.ToSafeBool(row["IsActive"]);
        //    }

        //    return model;
        //}
        //public async Task<ResponseEntity> DeleteWareHouse(UserBase user, WareHouse model)
        //{
        //    try
        //    {

        //        SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
        //        SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

        //        IDbDataParameter[] sqlParameters =
        //        {
        //         new SqlParameter("@CompanyGI",user.CompanyGuid),
        //         new SqlParameter("@UserGuid",user.UserGuid),
        //         new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),

        //            ResponseKey,ResponseStatus
        //    };
        //        await _sql.ExecuteNonQueryAsync("[DMS].[SP_WAREHOUSE_DELETE]", sqlParameters, CommandType.StoredProcedure);
        //        return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        //    }
        //    catch (SqlException ex)
        //    {
        //        var ErrorMsg = ex.Message.ToString();
        //        throw new Exception(ErrorMsg, ex);
        //    }
        //}
    }
}
