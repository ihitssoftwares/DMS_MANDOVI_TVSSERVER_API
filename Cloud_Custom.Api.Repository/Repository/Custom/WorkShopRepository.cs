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
    public class WorkShopRepository : IWorkShopRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public WorkShopRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<WorkShop> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_WORKSHOP_LIST]", sqlparameters);
                return WorkShopList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private WorkShop WorkShopList(DataSet dataSet)
        {
            WorkShop model = new WorkShop();
            List<WorkShop> List = new List<WorkShop>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new WorkShop();



                    item.Slno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.WorkShopCode = MakeSafe.ToSafeInt32(row["WorkShopCode"]);
                    item.WorkShopName = MakeSafe.ToSafeString(row["WorkShopName"]);
                    item.ShortName = MakeSafe.ToSafeString(row["ShortName"]);
                    item.Region = MakeSafe.ToSafeString(row["RegionName"]);
                    item.WsType = MakeSafe.ToSafeString(row["WorkShopType"]);
                    item.Capacity = MakeSafe.ToSafeInt32(row["Capacity"]);
                    item.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);


                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }

        public async Task<ResponseEntity> Save(UserBase user, string mode, WorkShop input)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_WORKSHOP_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<WorkShop> GetWorkShopDetails(UserBase User, int WorkShopCode, string mode)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@WorkShopCode",WorkShopCode),


            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_WORKSHOP_DETAILS]", sqlParameters);
            return PopulateWorkShopDetails(dataSet);

        }

        private WorkShop PopulateWorkShopDetails(DataSet dataSet)
        {
            WorkShop model = new WorkShop();


            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];

                model.Regionn = new Dropdown()
                {
                    Name = MakeSafe.ToSafeString(row["RegionName"]),
                    Code = MakeSafe.ToSafeInt32(row["RegionCode"])
                };
                model.Type = new Dropdown()
                {
                    Name = MakeSafe.ToSafeString(row["Name"]),
                    Code = MakeSafe.ToSafeInt32(row["WorkShopTypeCode"])
                };
                model.WorkShopCode = MakeSafe.ToSafeInt32(row["WorkShopCode"]);
                model.WorkShopName = MakeSafe.ToSafeString(row["WorkShopName"]);
                model.ShortName = MakeSafe.ToSafeString(row["ShortName"]);

                model.Capacity = MakeSafe.ToSafeInt32(row["Capacity"]);
                model.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);
            }

            return model;
        }
        public async Task<ResponseEntity> DeleteWorkShop(UserBase user, WorkShop model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_WORKSHOP_DELETE]", sqlParameters, CommandType.StoredProcedure);
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
