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
    public class SalesDumpVsDispatchDumpRepository : ISalesDumpVsDispatchDumpRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public SalesDumpVsDispatchDumpRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


      


        public async Task<SalesDumpVsDispatchDump> GetList(UserBase user, Filter filter, int Month, int Status, int Branch)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                    new SqlParameter("@JSONDATA",JsonHelper.ToJson(filter)),
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                   new SqlParameter("@Month", Month),
                new SqlParameter("@Status", Status),
                new SqlParameter("@Branch", Branch)

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SALESDUMPVSDISPATCHDUMP_LIST]", sqlparameters);
                return PopulateGetList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }


        public SalesDumpVsDispatchDump PopulateGetList(DataSet ds)
        {
            SalesDumpVsDispatchDump model = new SalesDumpVsDispatchDump();
            model.SalesDumpVsDispatchDumpList = new List<SalesDumpVsDispatchDump>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.SalesDumpVsDispatchDumpList.Add(new SalesDumpVsDispatchDump
                    {
                        VinNumber = MakeSafe.ToSafeString(row["VinNumber"]),
                        InvNo = MakeSafe.ToSafeString(row["InvNo"]),
                        Date = MakeSafe.ToSafeString(row["Date"]),
                        StoreOrBranch = MakeSafe.ToSafeString(row["StoreOrBranch"]),
                        Variant = MakeSafe.ToSafeString(row["Variant"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                       
                        EngineNo = MakeSafe.ToSafeString(row["EngineNo"]),
                        ChasisNo = MakeSafe.ToSafeString(row["ChasisNo"]),
                        saleChasisNo = MakeSafe.ToSafeString(row["saleChasisNo"]),
                        saleEngineNo = MakeSafe.ToSafeString(row["saleEngineNo"]),
                        Status = MakeSafe.ToSafeString(row["Status"]),
                        RegionName = MakeSafe.ToSafeString(row["RegionName"]),
                        active = MakeSafe.ToSafeInt32(row["ACTIVE"]),
                        totalRecords = MakeSafe.ToSafeInt32(row["TotalCount"])

                    });
                }
            }

            if (ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                DataRow row = ds.Tables[1].Rows[0];
                model.NOTDESPATCHED = MakeSafe.ToSafeInt32(row["NOTDESPATCHED"]);
                model.DESPATCHED = MakeSafe.ToSafeInt32(row["DESPATCHED"]);

               

            }

            return model;
        }



        
    }
}
