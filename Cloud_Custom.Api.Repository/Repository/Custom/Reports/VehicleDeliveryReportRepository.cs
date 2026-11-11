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

namespace Cloud_Custom.Api.Repository.Repository.Custom.Reports
{
   public  class VehicleDeliveryReportRepository: IVehicleDeliveryReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public VehicleDeliveryReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<VehicleDeliveryReport> GetList(UserBase user, int Month, int Branch)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@monthCode",Month),

                 new SqlParameter("@BranchCode",Branch)



                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_VEHICLES_DELIVERY_REPORT_LIST]", sqlparameters);
                return VehiclesDeliveryReportList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private VehicleDeliveryReport VehiclesDeliveryReportList(DataSet dataSet)
        {
            VehicleDeliveryReport model = new VehicleDeliveryReport();
            List<VehicleDeliveryReport> List = new List<VehicleDeliveryReport>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new VehicleDeliveryReport();



                    item.InvoiceNumber = MakeSafe.ToSafeString(row["Invoice Number"]);
                    item.InvoiceDate = MakeSafe.ToSafeString(row["Invoice Date"]);

                    item.BranchCode = MakeSafe.ToSafeInt32(row["Branch Code"]);
                    item.BranchName = MakeSafe.ToSafeString(row["Branch Name"]);

                    item.Customer = MakeSafe.ToSafeString(row["Customer"]);

                    item.ModelCode = MakeSafe.ToSafeInt32(row["Model Code"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);

                    item.VarientCode = MakeSafe.ToSafeInt32(row["Variant Code"]);
                    item.Varient = MakeSafe.ToSafeString(row["Variant"]);

                    item.ColourCode = MakeSafe.ToSafeInt32(row["Colour Code"]);
                    item.Colour = MakeSafe.ToSafeString(row["Colour"]);

                    item.VinNo = MakeSafe.ToSafeString(row["VIN No"]);
                    item.Executive = MakeSafe.ToSafeString(row["Executive"]);

                    item.SalesAmount = MakeSafe.ToSafeDecimal(row["Sales Amount"]);

                    item.OrderBookingNo = MakeSafe.ToSafeString(row["Order Booking No"]);
                    item.OrderTrnCode = MakeSafe.ToSafeInt32(row["Order Trn Code"]);
                    item.VehicleDeliveryDate = MakeSafe.ToSafeString(row["Delivery Date"]);



                    List.Add(item);
                }
                model.List = List;
            }

            return model;

        }

    }
}
