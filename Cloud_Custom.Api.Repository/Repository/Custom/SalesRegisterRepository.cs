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

    public class SalesRegisterRepository : ISalesRegisterRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public SalesRegisterRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<SalesRegister> GetList(UserBase user, string FromDate, string ToDate, int Region, int Branch, int Model, int Executive,int Month)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
            
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate),
                new SqlParameter("@Region",Region),
                new SqlParameter("@Branch",Branch),
                new SqlParameter("@Model",Model),
                new SqlParameter("@Executive",Executive),
                new SqlParameter("@Month",Month),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_SALES_REGISTER_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public SalesRegister PopulateGetList(DataSet ds)
        {
            SalesRegister model = new SalesRegister();
            model.SalesRegisterList = new List<SalesRegister>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new SalesRegister
                    {
                        InvoiceNo = MakeSafe.ToSafeString(row["INVOICENO"]),
                        InvoiceDate = MakeSafe.ToSafeString(row["INVOICEDATE"]),
                        Regionname = MakeSafe.ToSafeString(row["REGION"]),
                        Branchname = MakeSafe.ToSafeString(row["BRANCH"]),
                        modelname = MakeSafe.ToSafeString(row["MODEL"]),
                        custname = MakeSafe.ToSafeString(row["CUSTNAME"]),
                        SaleAmount = MakeSafe.ToSafeInt32(row["SALEAMT"]),
                        Revenue = MakeSafe.ToSafeInt32(row["REVENUE"]),
                        Discount = MakeSafe.ToSafeInt32(row["DISCOUNT"]),
                        NetAmount = MakeSafe.ToSafeInt32(row["NETAMT"]),
                        Executivename = MakeSafe.ToSafeString(row["EXECUTIVE"]),

                         Address= MakeSafe.ToSafeString(row["ADDRESS"]),
                     
                        Variant = MakeSafe.ToSafeString(row["VARIANT"]),
                        Color = MakeSafe.ToSafeString(row["COLOR"]),
                        ChassisNo = MakeSafe.ToSafeString(row["CHASSISNO"]),
                        EngineNo = MakeSafe.ToSafeString(row["ENGINENO"]),
                        VinNo = MakeSafe.ToSafeString(row["VINNO"]),
                    };

                    model.SalesRegisterList.Add(item);
                }
            }
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                var d = ds.Tables[1].Rows[0];
                model.FromDate = d["FromDate"] == DBNull.Value ? null : MakeSafe.ToSafeString(d["FromDate"]);
                model.ToDate = d["ToDate"] == DBNull.Value ? null : MakeSafe.ToSafeString(d["ToDate"]);
            }

            return model;
        }

    }
}
    
