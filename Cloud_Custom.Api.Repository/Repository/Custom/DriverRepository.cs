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
    public  class DriverRepository : IDriverRepository
    {

        private readonly ISqlConnectionProvider _sql;
        public DriverRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<Driver> DriverDetails(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_DRIVER_DASHBOARD_TILE_DETAILS]", sqlparameters);
                return DriverDetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private Driver DriverDetails(DataSet ds)
        {
            Driver model = new Driver();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                model.TotalCount = MakeSafe.ToSafeInt32(ds.Tables[0].Rows[0]["TotalPickups"]);
                model.PendingCount = MakeSafe.ToSafeInt32(ds.Tables[0].Rows[0]["Pending"]);
                model.Kilometers = MakeSafe.ToSafeInt32(ds.Tables[0].Rows[0]["TotalKMTravelled"]);
                model.Completed = MakeSafe.ToSafeInt32(ds.Tables[0].Rows[0]["Completed"]);
            }
            return model;
        }
        public async Task<Driver> PickupList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_DRIVER_DASHBOARD_PICKUP_LIST]", sqlparameters);
                return PickupList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private Driver PickupList(DataSet ds)
        {
            Driver model = new Driver();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                List<Driver> list = new List<Driver>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new Driver();
                    item.BookingCode = MakeSafe.ToSafeInt32(row["BookingCode"]);
                    item.RegistrationNo = MakeSafe.ToSafeString(row["RegistrationNo"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.Address = MakeSafe.ToSafeString(row["CustomerAddress"]);
                    item.Mobile = MakeSafe.ToSafeString(row["MobileNo"]);
                    item.AlternateMobileNo = MakeSafe.ToSafeString(row["AlternateMobileNo"]);
                    item.PreferredDate = MakeSafe.ToSafeString(row["PreferredDate"]);
                    item.PickupAddress = MakeSafe.ToSafeString(row["PickupAddress"]);
                    item.Status = MakeSafe.ToSafeString(row["PickupStatus"]);
                    list.Add(item);
                }
                model.List = list;
            }
            return model;
        }

        public async Task<ResponseEntity> UpdateEntryStatus(UserBase user, Driver input)
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
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_MOBILE_DRIVER_DASHBOARD_UPDATE_ENTRY_STATUS]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<ResponseEntity> UpdateExitStatus(UserBase user, Driver input)
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
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_MOBILE_DRIVER_DASHBOARD_UPDATE_EXIT_STATUS]", sqlParameters, CommandType.StoredProcedure);
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
