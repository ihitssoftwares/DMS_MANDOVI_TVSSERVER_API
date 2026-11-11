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
    public class ServiceIncentiveProcessingLockRepository: IServiceIncentiveProcessingLockRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ServiceIncentiveProcessingLockRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<ServiceIncentiveProcessingLock> GetList(UserBase user, int Month)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),


                new SqlParameter("@Month",Month),
                
            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_INCENTIVE_LOCK_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public ServiceIncentiveProcessingLock PopulateGetList(DataSet ds)
        {
            ServiceIncentiveProcessingLock model = new ServiceIncentiveProcessingLock();
            model.ServiceIncentiveProcessingLockList = new List<ServiceIncentiveProcessingLock>();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ServiceIncentiveProcessingLock item = new ServiceIncentiveProcessingLock
                    {
                        
                        Region = MakeSafe.ToSafeString(row["RegionName"]),
                         RegionCode= MakeSafe.ToSafeInt32(row["RegionCode"]),
                        ProcessedDate = MakeSafe.ToSafeDateTime(row["ProcessedDate"]),
                        ProcessedUser = MakeSafe.ToSafeString(row["ProcessedUser"]),
                        IsLocked = MakeSafe.ToSafeInt32(row["IsLocked"]),


                    };

                    model.ServiceIncentiveProcessingLockList.Add(item);
                }
            }

            return model;
        }

        public async Task<ResponseEntity> Save(ServiceIncentiveProcessingLock model, UserBase User)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 250, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                     new SqlParameter("@CompanyGI",User.CompanyGuid),
                      new SqlParameter("@UserGuid",User.UserGuid),


            new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
            ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_SERVICE_INCENTIVE_LOCK_SAVE]", sqlParameters, CommandType.StoredProcedure);
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
