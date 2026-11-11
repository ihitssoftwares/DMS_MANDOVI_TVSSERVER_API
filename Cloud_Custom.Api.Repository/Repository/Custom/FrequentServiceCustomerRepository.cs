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
    public class FrequentServiceCustomerRepository : IFrequentServiceCustomerRepository
    {

        private readonly ISqlConnectionProvider _sql;
        public FrequentServiceCustomerRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<FrequentServiceCustomer> GetList(UserBase user, int WorkShop)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                    new SqlParameter("@WorkShop",WorkShop)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_FREQUENTSERVICE_CUSTOMER_LIST]", sqlparameters);
                return SummeryList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private FrequentServiceCustomer SummeryList(DataSet ds)
        {
            FrequentServiceCustomer model = new FrequentServiceCustomer();
            List<FrequentServiceCustomer> List = new List<FrequentServiceCustomer>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new FrequentServiceCustomer();



                    item.Name = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.RegistrationNo = MakeSafe.ToSafeString(row["RegistrationNo"]);

                    item.Address = MakeSafe.ToSafeString(row["Address"]);



                    item.Phone = MakeSafe.ToSafeInt32(row["Phone"]);
                    item.Email = MakeSafe.ToSafeString(row["Email"]);

                    item.TotalVisits = MakeSafe.ToSafeInt32(row["TotalVisits"]);

                    item.TotalRevenue = MakeSafe.ToSafeDecimal(row["TotalRevenue"]);
                    item.LastVisit = MakeSafe.ToSafeDateTime(row["LastVisit"]);



                    List.Add(item);
                }
                model.List = List;
            }

            return model;

        }
    }
}
