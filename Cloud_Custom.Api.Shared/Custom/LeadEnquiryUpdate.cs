using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public class LeadEnquiryUpdate
    {

        public int EnqCode { get; set; }
        public Dropdown Month { get; set; }
        public string LeadNo { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string Model { get; set; }
        public int ModelCode { get; set; }
        public string SalesExecutive { get; set; }
        public string StoreName { get; set; }
        public List<LeadEnquiryUpdate> LeadEnquiryUpdateList { get; set; }
    }
    public class OrderBooking
    {
        public string DateFilterType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Dropdown Month { get; set; }
        public int OrderTrnCode { get; set; }
        public int LeadEnqCode { get; set; }
        public DateTime OrderDate { get; set; }
        public string LeadNo { get; set; }
        public string OrderNo { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string SalesExecutive { get; set; }
        public int Executive { get; set; }
        public string FatherOrSpouse { get; set; }
        public string AlternateMobileNo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public int State { get; set; }
        public int? PinCode { get; set; }
        public string PanNo { get; set; }
        public string AadharNo { get; set; }
        public string GstNo { get; set; }
        public int Model { get; set; }
        public int Variant { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public int Color { get; set; }
        public decimal ExactShowroomPrice { get; set; }
        public decimal RTOCharges { get; set; }
        public decimal Insurance { get; set; }
        public decimal ExtendedWarranty { get; set; }
        public decimal Accessories { get; set; }
        public decimal HandlingCharges { get; set; }
        public decimal OtherCharges { get; set; }
        public decimal GrossTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal NetOnRoadPrice { get; set; }
        public decimal BookingAmountPaid { get; set; }
        public int PaymentMode { get; set; }
        public string ChequeOrTransNo { get; set; }
        public decimal BalanceAmount { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }

        public bool FianceRequired { get; set; }
        public int BankOrNBFC { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal DownPayment { get; set; }
        public int LoanTenure { get; set; }
        public string ExchangeModel { get; set; }
        public string RegistrationNo { get; set; }
        public int Year { get; set; }
        public decimal ExchangeAmount { get; set; }
        public string ModelName { get; set; }
        public int WarrantyYears { get; set; }
        public int InsuranceType { get; set; }
        public int InsuranceCompany { get; set; }
        public string VariantName { get; set; }
        public string ColorName { get; set; }
        public string PaymentType { get; set; }
        public string BankName { get; set; }
        public string YearsOfWarranty { get; set; }
        public string InsuranceName { get; set; }
        public string InsuranceTypeName { get; set; }
        public decimal ItemRate { get; set; }
        public List<OrderBooking> OrderBookingList { get; set; }
        public List<Accessories> AccessoriesList { get; set; }
        public List<CostPrice> CostPriceList { get; set; }
    }
    public class Accessories
    {
        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
    }
    public class CostPrice
    {
        public int CostCode { get; set; }
        public string CostName { get; set; }
        public decimal Amount { get; set; }
     
    }
}
