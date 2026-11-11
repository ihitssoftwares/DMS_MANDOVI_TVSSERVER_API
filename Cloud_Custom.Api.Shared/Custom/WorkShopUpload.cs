using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class WorkShopUpload

    {

        public List<Dictionary<string, string>> DynamicData { get; set; }
        public List<FileColumnOrder> Columns { get; set; }
        public DateTime PickedDate { get; set; }
        public string selectDate { get; set; }
        public int SlNo { get; set; }
        public int PaticularCode { get; set; }
        public string PaticularName { get; set; }
        public string Message { get; set; }
        public string EntrybyDate { get; set; }
        public bool Uploadstatus { get; set; }
        public bool ImportStatus { get; set; }
        public int Noofrows { get; set; }
        public File ImportFromExcel { get; set; }

        public List<WorkShopUpload> List { get; set; }
        public List<Labourr> LabourList { get; set; }
        public List<Loadd> Load { get; set; }
        public List<MCPP> MCPList { get; set; }
        public List<MGAA> MGAList { get; set; }
        public List<PMSS> PMSList { get; set; }
        public List<PMSPartss> PMSPartsList { get; set; }
        public List<SPARESS> SPARESList { get; set; }
        public List<SYNTHETICOILL> SYNTHETICOILList { get; set; }
        public List<TrueValuee> TrueValueList { get; set; }
        public List<TYRE> TyreList { get; set; }
        public List<BATTERY> BatteryList { get; set; }
        public List<CCPP> CCPList { get; set; }
        public List<ExtendedWarrantyy> ExtendedWarrantyList { get; set; }
        public List<Labourr> EntryLabourList { get; set; }
        public List<Loadd> EntryLoadList { get; set; }
        public List<MCPP> EntryMCPList { get; set; }
        public List<MGAA> EntryMGAList { get; set; }
        public List<PMSS> EntryPMSList { get; set; }
        public List<PMSPartss> EntryPMSPartsList { get; set; }
        public List<SPARESS> EntrySPARESList { get; set; }
        public List<SYNTHETICOILL> EntrySYNTHETICOILList { get; set; }
        public List<TrueValuee> EntryTrueValueList { get; set; }
        public List<TYRE> EntryTyreList { get; set; }
        public List<BATTERY> EntryBatteryList { get; set; }
        public List<CCPP> EntryCCPList { get; set; }
        public List<ExtendedWarrantyy> EntryExtendedWarrantyList { get; set; }
        public List<Workshop> WorkshopList { get; set; }
        public List<WorkShopUpload> EntryDateList { get; set; }
        public List<Workshop> EntryDateWorkShopList { get; set; }
        public string FileName { get; set; }
        public List<string> InvalidColumns { get; set; }
        public List<string> SuggestedColumns { get; set; }
        public bool IsAutoFix { get; set; }
    }

    public class Labourr
    {
        public string DealerName { get; set; }
        public string DealerCity { get; set; }
        public string Location { get; set; }

        public string LabourCode { get; set; }
        public string LabourDesc { get; set; }

        public string ServiceAdvisorOrTechnicianName { get; set; }

        public string JCNo { get; set; }
        public string JCDate { get; set; }

        public string CustomerName { get; set; }
        public string RegistrationNo { get; set; }
        public string Model { get; set; }

        public string BillNo { get; set; }
        public string BillDate { get; set; }
        public string BillDesc { get; set; }

        public string BasicAmt { get; set; }
        public string DiscountAmt { get; set; }
        public string ChargesAmt { get; set; }
        public string BillAmt { get; set; }
    }
    public class Loadd
    {

        public string DealerName { get; set; }
        public string DealerCity { get; set; }
        public string Location { get; set; }
        public string JobCardNo { get; set; }
        public string JCDateTime { get; set; }
        public string ServiceType { get; set; }
        public string RepeatRevisit { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string MobileNo { get; set; }
        public string CustomerCategory { get; set; }
        public string PSFStatus { get; set; }
        public string RegistrationNo { get; set; }
        public string Chassis { get; set; }
        public string EngineNum { get; set; }
        public string Color { get; set; }
        public string Variant { get; set; }
        public string Model { get; set; }
        public string MI_YN { get; set; }
        public string SaleDate { get; set; }
        public string Group { get; set; }
        public string ServiceAdvisor { get; set; }
        public string Technician { get; set; }
        public string CircularNo { get; set; }
        public string ServiceType2 { get; set; }
        public string Mileage { get; set; }
        public string EstLabAmt { get; set; }
        public string EstPartAmt { get; set; }
        public string PromisedDate { get; set; }
        public string RevPromisedDate { get; set; }
        public string ReadyDateTime { get; set; }
        public string RevEstPartAmt { get; set; }
        public string RevEstLabAmt { get; set; }
        public string JCSource { get; set; }
        public string AppSentDate { get; set; }
        public string AppRejDate { get; set; }
        public string ApprovalStatus { get; set; }
        public string CustRemarks { get; set; }
        public string DlrRemarks { get; set; }
        public string Status { get; set; }
        public string BillNo { get; set; }
        public string BillDate { get; set; }
        public string LabourAmt { get; set; }
        public string PartAmt { get; set; }
        public string PickupRequired { get; set; }
        public string PickupDate { get; set; }
        public string PickupLocation { get; set; }
        public string BillAmount { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
        public string DOB { get; set; }
        public string DOA { get; set; }
        public string Email { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
    }

    public class MCPP
    {
        public string Location { get; set; }
        public string MCPEnrollmentNo { get; set; }
        public string MCPInvoiceNo { get; set; }
        public string MCPDate { get; set; }
        public string MCPStatus { get; set; }
        public string CustomerName { get; set; }
        public string CustAddr1 { get; set; }
        public string CustAddr2 { get; set; }
        public string CustAddr3 { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Model { get; set; }
        public string Vin { get; set; }
        public string RegNum { get; set; }
        public string VehInvDt { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }
        public string MCPStartDate { get; set; }
        public string MCPEndDate { get; set; }
        public string PackageCode { get; set; }
        public string PackageDesc { get; set; }
        public string NoOfServiceOffered { get; set; }
        public string NoOfServicesAvailed { get; set; }
        public string BalanceServices { get; set; }
        public string AmountCollected { get; set; }
        public string DiscountedLabour { get; set; }
        public string DiscountedParts { get; set; }
        public string DiscountedConsumablesOil { get; set; }
        public string SGSTAmount { get; set; }
        public string CGSTAmount { get; set; }
        public string IGSTAmount { get; set; }
        public string AmountUsed { get; set; }
        public string UsedLabour { get; set; }
        public string UsedParts { get; set; }
        public string UsedConsumablesOil { get; set; }
        public string BalanceAmount { get; set; }
        public string BalancedDiscountedLabour { get; set; }
        public string BalancedDiscountedParts { get; set; }
        public string BalancedDiscountedConsumablesOil { get; set; }
        public string CancellationReason { get; set; }
        public string Executive { get; set; }
    }
    public class MGAA
    {

        public string HeaderName { get; set; }
        public string Region { get; set; }
        public string DealerCode { get; set; }
        public string FORCode { get; set; }
        public string OutletCode { get; set; }
        public string Column1 { get; set; }
        public string City { get; set; }
        public string Branch { get; set; }
        public string DealerName { get; set; }
        public string ServiceAdvisor { get; set; }

        public string Consumption { get; set; }
        public string Load { get; set; }
        public string MGALoad { get; set; }

        public string ACFilter { get; set; }
        public string Screenwash { get; set; }
        public string Perfumes { get; set; }
        public string Mats { get; set; }
        public string ACGas { get; set; }
    }
    public class FileColumnOrderr
    {
        public int Order { get; set; }
        public string FileName { get; set; }
    }
    public class PMSS
    {

        public string Region { get; set; }
        public string Dealer { get; set; }
        public string DealerCode { get; set; }
        public string Outlet { get; set; }
        public string DealerCity { get; set; }
        public string Location { get; set; }
        public string JCNo { get; set; }
        public string RegNo { get; set; }
        public string VIN { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }

        public string SaleDate { get; set; }
        public string Service { get; set; }
        public string Mileage { get; set; }

        public string JCOpenDate { get; set; }
        public string JCCloseDate { get; set; }
        public string BillDate { get; set; }
        public string PromisedDate { get; set; }

        public string JCOpenedBy { get; set; }
        public string JCOpenedByDesg { get; set; }
        public string JCSource { get; set; }

        public string JCLabourAmt { get; set; }
        public string JCPartAmt { get; set; }
        public string JCBillAmt { get; set; }

        public string EWName { get; set; }
        public string EWConverted { get; set; }
        public string EWCancel { get; set; }
        public string EWActiveExpire { get; set; }

        public string MCPName { get; set; }
        public string MCPActiveExpire { get; set; }

        public string QRCode { get; set; }
        public string ScanType { get; set; }
        public string AudioCount { get; set; }
        public string ApprovalStatus { get; set; }

        public string RFIDTag { get; set; }
        public string FSCBarCode { get; set; }
        public string BSCValue { get; set; }

        public string SellingDealerRegion { get; set; }
        public string SellingParentGroup { get; set; }
        public string SellingDealerCode { get; set; }
        public string SellingDealerName { get; set; }

        public string PreviousDealerRegion { get; set; }
        public string PreviousDealerName { get; set; }
        public string PreviousDealerParentGroup { get; set; }
        public string PreviousSubServiceType { get; set; }
        public string PreviousServiceDealerCode { get; set; }

        public string WashType { get; set; }
        public string TotalLabDiscount { get; set; }
        public string TotalPartDiscount { get; set; }

        public string PartAmountWithoutGST { get; set; }
        public string LabourAmountWithoutGST { get; set; }
        public string BillAmountWithoutGST { get; set; }

        public string ServiceAdvisorMSPIN { get; set; }

        public string OCASCount { get; set; }
        public string OCASSavedCount { get; set; }
        public string OCASSentCount { get; set; }

        public string OpenToClose { get; set; }
        public string CloseToBill { get; set; }
        public string OpenToBill { get; set; }
        public string TimeOpenToClose { get; set; }
    }
    public class PMSPartss
    {


        public string ParentGroup { get; set; }
        public string LocationCode { get; set; }
        public string ServiceAdvisorName { get; set; }
        public string MonthYear { get; set; }
        public string Day { get; set; }
        public string VariantName { get; set; }
        public string VariantCode { get; set; }
        public string RequiredPartGroupDescription { get; set; }
        public string BaseModelName { get; set; }
        public string BaseModel { get; set; }
        public string PMSRequired { get; set; }
        public string PMSChanged { get; set; }
        public string PMSPercentage { get; set; }
    }
    public class SPARESS
    {

        public string SrlNo { get; set; }
        public string DealerName { get; set; }
        public string DealerCity { get; set; }
        public string Location { get; set; }
        public string GroupBy { get; set; }
        public string BillNo { get; set; }
        public string MCPNo { get; set; }
        public string InsClaimNumber { get; set; }
        public string InsClaimDate { get; set; }
        public string BillDate { get; set; }
        public string JobCardNo { get; set; }
        public string ServiceType { get; set; }
        public string RegistrationNo { get; set; }
        public string CustomerID { get; set; }
        public string PartyName { get; set; }
        public string GSTNum { get; set; }
        public string PlaceOfSupply { get; set; }

        public string PartsBasicAmount { get; set; }
        public string PartsDiscount { get; set; }
        public string PartsCharges { get; set; }

        public string LabourBasicAmt { get; set; }
        public string LabourDiscount { get; set; }
        public string LabourCharges { get; set; }

        public string RoundOffAmt { get; set; }
        public string BillAmt { get; set; }
        public string Salvage { get; set; }
        public string Deductible { get; set; }
    }
    public class SYNTHETICOILL
    {


        public string Region { get; set; }
        public string DealerCity { get; set; }
        public string LocationCode { get; set; }
        public string LocationDescription { get; set; }
        public string PartNum { get; set; }
        public string MonthYear { get; set; }
        public string Day { get; set; }
        public string ModelName { get; set; }
        public string JobCardNum { get; set; }
        public string ServiceAdvisorName { get; set; }
        public string NetRetailQty { get; set; }
        public string ServiceLoad { get; set; }
    }
    public class TrueValuee
    {
        public string Id { get; set; }

        public string DealerCity { get; set; }
        public string Date { get; set; }
        public string BuyerType { get; set; }
        public string EnquiryStatus { get; set; }
        public string EnquirySource { get; set; }
        public string EnquiryMode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string PIN { get; set; }
        public string SalesExecutiveName { get; set; }
        public string VehicleRegistrationNo { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string ModelCode { get; set; }
        public string SubModel { get; set; }
        public string FuelType { get; set; }
        public string VehicleBuyCategory { get; set; }
        public string VehicleSoldCategory { get; set; }
        public string VehicleCategory { get; set; }
        public string YOM { get; set; }
        public string AgeOfOldCar { get; set; }
        public string SaleType { get; set; }
        public string BookingToSale { get; set; }
        public string Enquiry { get; set; }
        public string NetBooking { get; set; }
        public string GrossBooking { get; set; }
        public string BookingCancelled { get; set; }
        public string NetSale { get; set; }
        public string GrossSale { get; set; }
        public string EnquiryLost { get; set; }
        public string NetworkStock { get; set; }
        public string BuyingPrice { get; set; }
        public string SellingPrice { get; set; }
        public string TotalActualRF { get; set; }
        public string ProfitMargin { get; set; }
        public string ReferenceSalesPrice { get; set; }
        public string WarrantyCharges { get; set; }
        public string AdvanceAmountPaid { get; set; }
        public string PendingAmount { get; set; }
    }
    public class TYRE
    {

        public string LocationCode { get; set; }
        public string PartDescription { get; set; }
        public string MonthYear { get; set; }
        public string Day { get; set; }
        public string ServiceAdvisorName { get; set; }
        public string Channel { get; set; }
        public string NetRetailQty { get; set; }
        public string NetRetailDDL { get; set; }
        public string NetRetailSelling { get; set; }
    }
    public class BATTERY
    {


        public string LocationCode { get; set; }
        public string PartDescription { get; set; }
        public string MonthYear { get; set; }
        public string Day { get; set; }
        public string ServiceAdvisorName { get; set; }
        public string Channel { get; set; }
        public string NetRetailQty { get; set; }
        public string NetRetailDDL { get; set; }
        public string NetRetailSelling { get; set; }
    }
    public class CCPP
    {
        public string Region { get; set; }
        public string DealerCode { get; set; }
        public string DealerName { get; set; }
        public string Location { get; set; }
        public string PaymentLinkGeneratedDate { get; set; }
        public string EWRPolicyNo { get; set; }
        public string EWRType { get; set; }
        public string EWRValidity { get; set; }
        public string CCPPolicyNum { get; set; }
        public string CCPSaleDate { get; set; }
        public string SaleMonth { get; set; }
        public string Vin { get; set; }
        public string VehInvDate { get; set; }
        public string RegNum { get; set; }
        public string ModelCd { get; set; }
        public string ModelDesc { get; set; }
        public string VariantCd { get; set; }
        public string ModelVariant { get; set; }
        public string CustName { get; set; }
        public string CustMobileNo { get; set; }
        public string OdometerReading { get; set; }
        public string AddonCd { get; set; }
        public string CCPType { get; set; }
        public string CCPStartDate { get; set; }
        public string CCPExpiryDate { get; set; }
        public string OldPolicyNo { get; set; }
        public string OldPolicyDesc { get; set; }
        public string CCPRenewalJCNo { get; set; }
        public string JCStatus { get; set; }
        public string ClaimTaken { get; set; }
        public string ClaimAmt { get; set; }
        public string BasicAmt { get; set; }
        public string DiscountAmt { get; set; }
        public string CGSTAmt { get; set; }
        public string SGSTAmt { get; set; }
        public string IGSTAmt { get; set; }
        public string NetAmt { get; set; }
        public string Status { get; set; }
        public string OnlineFlag { get; set; }
        public string FacilitationAmt { get; set; }
        public string SoldFrom { get; set; }
        public string PaymentType { get; set; }
        public string ConvenienceChargesDiscount { get; set; }
        public string InterestChargesDiscount { get; set; }
        public string EMITenure { get; set; }
        public string BasicCostFromBank { get; set; }
        public string Difference { get; set; }
        public string AddonInvNum { get; set; }
        public string NewCCPSoldRoNum { get; set; }
        public string Channel { get; set; }
    }
    public class ExtendedWarrantyy
    {
        public string Branch { get; set; }
        public string PolicyNo { get; set; }
        public string InvoiceNo { get; set; }
        public string PolicySaleDate { get; set; }
        public string VIN { get; set; }
        public string VehicleSaleDate { get; set; }
        public string ModelCode { get; set; }
        public string ModelDesc { get; set; }
        public string VariantCode { get; set; }
        public string VariantDesc { get; set; }
        public string WarrantyType { get; set; }

        public string CustomerName { get; set; }
        public string Mileage { get; set; }
        public string ExpiryDate { get; set; }
        public string ExpiryMileage { get; set; }

        public string ActualPremiumAmount { get; set; }
        public string PremiumAmount { get; set; }
        public string DiscountAmount { get; set; }

        public string CGSTAmt { get; set; }
        public string SGSTAmt { get; set; }
        public string IGSTAmt { get; set; }

        public string CommissionAmount { get; set; }
        public string CGSTCommission { get; set; }
        public string SGSTCommission { get; set; }
        public string IGSTCommission { get; set; }

        public string SoldBy { get; set; }
        public string Status { get; set; }

        public string ServiceAdvisorDSE { get; set; }
        public string ServiceAdvisorDSEName { get; set; }

        public string Channel { get; set; }
    }


    public class Workshop
    {
        public int WorkshopCode { get; set; }
        public string WorkshopName { get; set; }
        public int Particularcode { get; set; }
        public string particularName { get; set; }
        public string EntrybyDate { get; set; }
        public bool Uploadstatus { get; set; }
        public bool ImportStatus { get; set; }
        public int Noofrows { get; set; }
        public DateTime PickedDate { get; set; }

    }
}
