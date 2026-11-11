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
    public class MCareServiceReportRepository : IMCareServiceReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public MCareServiceReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<MCareServiceReport> GetList(UserBase user, int PlanCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                    new SqlParameter("@PlanCode",PlanCode)
                    
            };
                var ds = await _sql.GetDataSetAsync("[MCARE].[MCARE_SERVICE_REPORT]", sqlparameters);
                return SummeryList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MCareServiceReport SummeryList(DataSet ds)
        {
            MCareServiceReport model = new MCareServiceReport();
            List<MCareServiceReport> list = new List<MCareServiceReport>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new MCareServiceReport();

                    item.RegEntryCode = MakeSafe.ToSafeInt32(row["RegistrationEntryCode"]);
                    item.EntryNo = MakeSafe.ToSafeString(row["EntryNo"]);
                    item.RegistrationDate = MakeSafe.ToSafeDateTime(row["RegistrationDate"]);
                    item.PlanName = MakeSafe.ToSafeString(row["PlanName"]);
                    item.PackageDuration = MakeSafe.ToSafeString(row["PackageDuration"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.Phone = MakeSafe.ToSafeString(row["Phone"]);
                    item.VehicleRegistrationNumber = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.Variant = MakeSafe.ToSafeString(row["Variant"]);
                    item.Colour = MakeSafe.ToSafeString(row["Colour"]);
                    item.ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]);
                    item.EngineNo = MakeSafe.ToSafeString(row["EngineNo"]);
                    item.PlanAmount = MakeSafe.ToSafeDecimal(row["PlanAmount"]);
                    item.StartDate = MakeSafe.ToSafeDateTime(row["StartDate"]);
                    item.EndDate = MakeSafe.ToSafeDateTime(row["EndDate"]);
                    item.Status = MakeSafe.ToSafeString(row["Status"]);
                    item.Qty = MakeSafe.ToSafeInt32(row["QTY"]);

                    list.Add(item);
                }

                model.List = list;
            }

            return model;
        }


        public async Task<ServicePopUpDetails> GetPopupDetails(UserBase user, int RegEntryCode, int CustomerCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@RegEntryCode",RegEntryCode),
                new SqlParameter("@CustomerCode",CustomerCode),


            };
            var ds = await _sql.GetDataSetAsync("[MCARE].[SP_MCARE_SERVICE_REPORT_DETAILS_LIST]", sqlparameters);

            return PopulateGetBayDetails(ds);

        }
        public ServicePopUpDetails PopulateGetBayDetails(DataSet ds)
        {

            ServicePopUpDetails model = new ServicePopUpDetails();
            List<ServicePopUpDetails> AllList = new List<ServicePopUpDetails>();
            List<ServicePopUpDetails> AfterList = new List<ServicePopUpDetails>();
            List<ServicePopUpDetails> ServiceList = new List<ServicePopUpDetails>();
            List<ServicePopUpDetails> PopUpList = new List<ServicePopUpDetails>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new ServicePopUpDetails();

                    item.LabourCode = MakeSafe.ToSafeString(row["LabourCode"]);
                    item.LabourDescription = MakeSafe.ToSafeString(row["LabourDescription"]);
                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.BasicAmount = MakeSafe.ToSafeDecimal(row["BasicAmount"]);
                    item.DiscountAmount = MakeSafe.ToSafeDecimal(row["DiscountAmount"]);
                    item.ChargesAmount = MakeSafe.ToSafeDecimal(row["ChargesAmount"]);
                    item.BillAmout = MakeSafe.ToSafeDecimal(row["BillAmout"]);
                    item.VehicleRegistrationNumber = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);
                    item.JcDate = MakeSafe.ToSafeDateTime(row["JcDate"]);
                    item.BillNo = MakeSafe.ToSafeString(row["BillNo"]);
                    item.BillDate = MakeSafe.ToSafeDateTime(row["BillDate"]);

                    AllList.Add(item);
                }

                model.AllList = AllList;
            }


            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    var item = new ServicePopUpDetails();

                    item.LabourCode = MakeSafe.ToSafeString(row["LabourCode"]);
                    item.LabourDescription = MakeSafe.ToSafeString(row["LabourDescription"]);
                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.BasicAmount = MakeSafe.ToSafeDecimal(row["BasicAmount"]);
                    item.DiscountAmount = MakeSafe.ToSafeDecimal(row["DiscountAmount"]);
                    item.ChargesAmount = MakeSafe.ToSafeDecimal(row["ChargesAmount"]);
                    item.BillAmout = MakeSafe.ToSafeDecimal(row["BillAmout"]);
                    item.VehicleRegistrationNumber = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);
                    item.JcDate = MakeSafe.ToSafeDateTime(row["JcDate"]);
                    item.BillNo = MakeSafe.ToSafeString(row["BillNo"]);
                    item.BillDate = MakeSafe.ToSafeDateTime(row["BillDate"]);

                    AfterList.Add(item);
                }

                model.AfterList = AfterList;
            }

            if ((ds.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    var item = new ServicePopUpDetails();

                    item.LabourCode = MakeSafe.ToSafeString(row["LabourCode"]);
                    item.LabourDescription = MakeSafe.ToSafeString(row["LabourDescription"]);
                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.BasicAmount = MakeSafe.ToSafeDecimal(row["BasicAmount"]);
                    item.DiscountAmount = MakeSafe.ToSafeDecimal(row["DiscountAmount"]);
                    item.ChargesAmount = MakeSafe.ToSafeDecimal(row["ChargesAmount"]);
                    item.BillAmout = MakeSafe.ToSafeDecimal(row["BillAmout"]);
                    item.VehicleRegistrationNumber = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);
                    item.JcDate = MakeSafe.ToSafeDateTime(row["JcDate"]);
                    item.BillNo = MakeSafe.ToSafeString(row["BillNo"]);
                    item.BillDate = MakeSafe.ToSafeDateTime(row["BillDate"]);
                    item.ServiceName = MakeSafe.ToSafeString(row["Servicename"]);


                    ServiceList.Add(item);
                }

                model.ServiceList = ServiceList;
            }

            if ((ds.Tables[3]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[3].Rows)
                {
                    var item = new ServicePopUpDetails();

                    item.ServiceCode = MakeSafe.ToSafeInt32(row["ServiceCode"]);
                    item.Customer = MakeSafe.ToSafeString(row["Customer"]);
                    item.McareEntryNo = MakeSafe.ToSafeString(row["McareEntryNo"]);
                    item.ServiceName = MakeSafe.ToSafeString(row["ServiceName"]);
                    item.Limit = MakeSafe.ToSafeInt32(row["Limit"]);
                    item.Alreadytaken = MakeSafe.ToSafeInt32(row["Alreadytaken"]);
                    item.precentage = MakeSafe.ToSafeInt32(row["precentage"]);
                    item.RegEntryCode = MakeSafe.ToSafeInt32(row["RegistrationEntryCode"]);
                    item.taxtypecode = MakeSafe.ToSafeInt32(row["taxtypecode"]);
                    




                    PopUpList.Add(item);
                }
                model.PopUpList = PopUpList;
            }
            return model;

        }
    }
}
