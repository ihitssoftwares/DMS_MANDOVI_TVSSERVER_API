using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class OrderBookingUpload
    {
        public File ImportFromExcel { get; set; }
        public string Message { get; set; }
        public List<OrderBookingUploadModel> OrderBookingUploadModel { get; set; }
        public List<BookingReportModel> BookingReportModel { get; set; }
        public List<OrderBookingUploadModel> OrderBookingUploadList { get; set; }
        public Dropdown Month { get; set; }

    }


}
public class OrderBookingUploadModel
{
    public string LeadNum { get; set; }
    public string OrderNo { get; set; }
    public string orderDate { get; set; }
    public string SalesExecutive { get; set; }
    public string Customer { get; set; }
    public string CustomerCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Model { get; set; }
    public string Variant { get; set; }
    public string Color { get; set; }
    public string FuelType { get; set; }
    public string Amount { get; set; }
    public string Branch { get; set; }
    public string OrderStatus { get; set; }


}
public class BookingReportModel
{
    public string Zone { get; set; }
    public string DealerRegionCode { get; set; }
    public string SalesDealerCode { get; set; }
    public string OutletType { get; set; }
    public string DealerName { get; set; }

    public string BookingNum { get; set; }
    public string BookingDate { get; set; }

    public string EnquiryNum { get; set; }
    public string EnquiryDate { get; set; }

    public string CustomerCode { get; set; }
    public string CustomerTitle { get; set; }
    public string CustomerName { get; set; }
    public string CustomerCity { get; set; }
    public string CustomerState { get; set; }

    public string TestDriveDate { get; set; }
    public string PromisedDeliveryDate { get; set; }

    public string BuyerType { get; set; }
    public string Model { get; set; }
    public string FuelDescription { get; set; }
    public string Variant { get; set; }
    public string Color { get; set; }

    public string AllotmentFlag { get; set; }
    public string AgeingBucket { get; set; }

    public string ReceiptAmtAgainstBooking { get; set; }

    public string EnquirySource { get; set; }
    public string TLName { get; set; }
    public string DSEName { get; set; }
    public string DSEEmployeeDesignation { get; set; }
    public string DesignationCategory { get; set; }

    public string DelayedFlag { get; set; }
    public string DelayFlagDate { get; set; }
    public string DelayRemarks { get; set; }
    public string DelayedExpDeliveryDate { get; set; }
    public string DelayDeFlagDate { get; set; }

    public string AllotmentDate { get; set; }
    public string AllotmentNo { get; set; }

    public string NewCarVariant { get; set; }
    public string Corporate { get; set; }
    public string BookingAmountFlag { get; set; }

    public string PendingBookingCount { get; set; }
    public string Message { get; set; }

    public string ReferenceNo { get; set; }
    public string NoofTimesBookingwasByPassed { get; set; }

    public string TradeIn { get; set; }
    public string HomeVisitDate { get; set; }
    public string EnquiryCustomeType { get; set; }

    public string BookingTehsil { get; set; }

    public string VariantColor { get; set; }

    public string Financier { get; set; }
    public string EnquiryMode { get; set; }

    public string OrderStatus { get; set; }
    public string AgeofBooking { get; set; }

    public string BookingCancelDate { get; set; }

    public string InvoiceNum { get; set; }
    public string InvoiceDate { get; set; }

    public string MGABooked { get; set; }

    public string SchemeCode1 { get; set; }
    public string SchemeName1 { get; set; }

    public string SchemeCode2 { get; set; }
    public string SchemeName2 { get; set; }

    public string EvaluatorCode { get; set; }
    public string EvaluatorMSPINNo { get; set; }
    public string EvaluatorName { get; set; }
    public string EvaluationDate { get; set; }
    public string BoughtDate { get; set; }

    public string OldCarRegNum { get; set; }
    public string OldCarModel { get; set; }
    public string OldCarSubModel { get; set; }

    public string OFFOfferedPrice { get; set; }
    public string CustomerExpectedPrice { get; set; }
    public string ReofferedPrice { get; set; }
    public string BuyingPrice { get; set; }
    public string ReferencePrice { get; set; }

    public string DateOfReg { get; set; }
    public string OldCarYOM { get; set; }

    public string ColorCode { get; set; }

    public string BookingAmt { get; set; }

    public string SuzukiConnect { get; set; }
    public string TestDriveMode { get; set; }
    public string DSEMSPIN { get; set; }

    public string BCRDate { get; set; }
    public string RevisedBCRDate { get; set; }

    public string Quadrant { get; set; }
    public string EnquiryStrength { get; set; }

    public string MultipleOutletVisitCount { get; set; }
    public string MultipleOutletVisitFlag { get; set; }

    public string MultipleEvaluationsFlag { get; set; }
    public string MultipleEvaluationsCount { get; set; }

    public string VisitedwithFamilyFlag { get; set; }
    public string EvaluationGapFlag { get; set; }
    public string DuplicateEnquiriesFlag { get; set; }
    public string PIDroponWebsite { get; set; }

    public string DeliveryScheduledDate { get; set; }
    public string RFCRaisedDate { get; set; }

    public string CustomerProfile { get; set; }
    public string BAType { get; set; }

    public string ACRMInfluence { get; set; }

    public string CampaignCode { get; set; }
    public string CampaignName { get; set; }

    public string InterestedinLoyaltyCard { get; set; }

    public string BookingCount { get; set; }
}


