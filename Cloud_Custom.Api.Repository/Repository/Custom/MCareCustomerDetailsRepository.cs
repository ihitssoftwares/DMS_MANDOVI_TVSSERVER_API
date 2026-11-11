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
    public class MCareCustomerDetailsRepository: IMCareCustomerDetailsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public MCareCustomerDetailsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<MCareCustomerDetails> GetList(string RegNo)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
              
                 new SqlParameter("@RegNo",RegNo),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MCareCustomerDetails_LIST]", sqlparameters);
                return CustomerList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MCareCustomerDetails CustomerList(DataSet dataSet)
        {
            MCareCustomerDetails model = new MCareCustomerDetails();
            model.List = new List<MCareCustomerDetails>();
            model.CustomerServiceDetails = new List<ServiceDetails>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new MCareCustomerDetails();

                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.Phone = MakeSafe.ToSafeString(row["Phone"]);
                    item.Mail = MakeSafe.ToSafeString(row["Mail"]);
                    item.RegistrationDate = MakeSafe.ToSafeString(row["RegistrationDate"]);
                    item.EndDate = MakeSafe.ToSafeString(row["EndDate"]);
                    item.VehRegNo = MakeSafe.ToSafeString(row["VehRegNo"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.Variant = MakeSafe.ToSafeString(row["Variant"]);
                    item.PlanName = MakeSafe.ToSafeString(row["PlanName"]);
                    item.Duration = MakeSafe.ToSafeString(row["Duration"]);

                    model.List.Add(item);
                }
            }

            if (dataSet.Tables.Count > 1 && (dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new ServiceDetails();

                    item.ServiceCode = MakeSafe.ToSafeInt32(row["ServiceCode"]);
                    item.Name = MakeSafe.ToSafeString(row["Name"]);

                    model.CustomerServiceDetails.Add(item);
                }
            }

            return model;
        }
    }
}
