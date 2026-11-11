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
    public class BayMovementIdleRepository : IBayMovementIdleRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public BayMovementIdleRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<BayMovementIdle> GetList(UserBase user, int WorkShop)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                    new SqlParameter("@WorkShop",WorkShop)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_BAYMOVEMENT_LIST]", sqlparameters);
                return SummeryList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private BayMovementIdle SummeryList(DataSet ds)
        {
            BayMovementIdle model = new BayMovementIdle();
            List<BayMovementIdle> List = new List<BayMovementIdle>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new BayMovementIdle();



                    item.JCEntryCode = MakeSafe.ToSafeInt32(row["JobCardEntryCode"]);
                    item.JCNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.JCDateTime = MakeSafe.ToSafeDateTime(row["JobCardDateTime"]);
                    item.RegNumber = MakeSafe.ToSafeString(row["RegistrationNumber"]);
                    item.FromBayCode = MakeSafe.ToSafeInt32(row["FromBayCode"]);
                    item.FromBay = MakeSafe.ToSafeString(row["FromBay"]);
                    item.ToBayCode = MakeSafe.ToSafeInt32(row["ToBayCode"]);
                    item.ToBay = MakeSafe.ToSafeString(row["ToBay"]);
                    item.FromBayOutTime = MakeSafe.ToSafeDateTime(row["FromBayOutTime"]);
                    item.ToBayInTime = MakeSafe.ToSafeDateTime(row["ToBayInTime"]);
                    item.IdleMinutes = MakeSafe.ToSafeInt32(row["IdleMinutes"]);

                   

                    List.Add(item);
                }
                model.List = List;
            }

            return model;

        }
    }
}
