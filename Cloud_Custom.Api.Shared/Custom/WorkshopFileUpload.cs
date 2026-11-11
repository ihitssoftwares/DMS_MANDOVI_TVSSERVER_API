using Cloud_Custom.Api.Shared.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class WorkshopFileUpload
    {
        public List<Dictionary<string, string>> DynamicData { get; set; }
        public List<FileColumnOrder> Columns { get; set; }
        public DateTime PickedDate { get; set; }
        public int SlNo { get; set; }
        public int PaticularCode { get; set; }
        public string PaticularName { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string EntrybyDate { get; set; }
        public bool Uploadstatus { get; set; }
        public bool ImportStatus { get; set; }
        public int Noofrows { get; set; }
        public File ImportFromExcel { get; set; }
        public List<WorkshopFileUpload> List { get; set; }
        public List<Labour> LabourList { get; set; }
        public List<Load> Load { get; set; }
        public List<MCP> MCPList { get; set; }
        public List<MGA> MGAList { get; set; }
        public List<PMS> PMSList { get; set; }
        public List<PMSParts> PMSPartsList { get; set; }
        public List<SPARES> SPARESList { get; set; }
        public List<SYNTHETICOIL> SYNTHETICOILList { get; set; }
        public List<TrueValue> TrueValueList { get; set; }
        public List<Tyre> TyreList { get; set; }
        public List<Battery> BatteryList { get; set; }
        public List<CCP> CCPList { get; set; }
        public List<ExtendedWarranty> ExtendedWarrantyList { get; set; }
        public string FileName { get; set; }
        public List<string> InvalidColumns { get; set; }
        public List<string> SuggestedColumns { get; set; }
        public bool IsAutoFix { get; set; }
        [JsonProperty("processing_summary")]
        public SmartProcessingSummary ProcessingSummary { get; set; }
        public string ValidationType { get; set; }
        public List<string> InvalidLocations { get; set; }
        public List<string> SuggestedLocations { get; set; }
        public List<string> InvalidDateColumns { get; set; }
        public string InvalidDateValue { get; set; }
        public List<string> SuggestedDates { get; set; }
        public string DateFixes { get; set; }
        public int TotalRows { get; set; }
        public int InsertedRows { get; set; }
        public bool IsFinalUpload { get; set; }
        public string WorkshopCodePy { get; set; }
        public List<PartsMaster> PartsMasterList { get; set; }
        public List<PartsData> PartsDataList { get; set; }
    }
    public class Labour
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
        public string WorkshopCodePy { get; set; }
    }
    public class Load
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
        public string WorkshopCodePy { get; set; }
    }
    public class MCP
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
        public string WorkshopCodePy { get; set; }
    }
    public class MGA
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
        public string WorkshopCodePy { get; set; }
    }
    public class FileColumnOrder
    {
        public int Order { get; set; }
        public string FileName { get; set; }
    }
    public class PMS
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
        public string WorkshopCodePy { get; set; }
    }
    public class PMSParts
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
        public string WorkshopCodePy { get; set; }
    }
    public class SPARES
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
        public string WorkshopCodePy { get; set; }
    }
    public class SYNTHETICOIL
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
        public string WorkshopCodePy { get; set; }
    }
    public class TrueValue
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
        public string WorkshopCodePy { get; set; }
    }
    public class Tyre
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
        public string WorkshopCodePy { get; set; }
    }
    public class Battery
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
        public string WorkshopCodePy { get; set; }
    }
    public class CCP
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
        public string WorkshopCodePy { get; set; }
    }
    public class ExtendedWarranty
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
        public string WorkshopCodePy { get; set; }
    }
    public class SmartProcessingSummary
    {
        [JsonProperty("total_files")]
        public int TotalFiles { get; set; }

        [JsonProperty("valid_files_count")]
        public int ValidFilesCount { get; set; }

        [JsonProperty("invalid_files_count")]
        public int InvalidFilesCount { get; set; }

        [JsonProperty("valid_files_with_columns_count")]
        public int ValidFilesWithColumnsCount { get; set; }

        [JsonProperty("invalid_files_with_unidentified_columns")]
        public int InvalidFilesWithUnidentifiedColumns { get; set; }

        [JsonProperty("valid_date_files_count")]
        public int ValidDateFilesCount { get; set; }

        [JsonProperty("invalid_date_files_count")]
        public int InvalidDateFilesCount { get; set; }

        [JsonProperty("valid_location_files_count")]
        public int ValidLocationFilesCount { get; set; }

        [JsonProperty("invalid_location_files_count")]
        public int InvalidLocationFilesCount { get; set; }

        [JsonProperty("invalid_files")]
        public List<InvalidFile> InvalidFiles { get; set; }
        [JsonProperty("file_row_counts")]
        public List<FileRowCount> FileRowCounts { get; set; }
        public class FileRowCount
        {
            [JsonProperty("filename")]
            public string FileName { get; set; }

            [JsonProperty("total_rows")]
            public int TotalRows { get; set; }
        }
    }
    public class SmartUploadData
    {
        [JsonProperty("processing_summary")]
        public SmartProcessingSummary ProcessingSummary { get; set; }

        [JsonProperty("metadata")]
        public SmartUploadMetadata Metadata { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
    }
    public class SmartUploadMetadata
    {
        [JsonProperty("total_records")]
        public int TotalRecords { get; set; }

        [JsonProperty("total_files")]
        public int TotalFiles { get; set; }

        [JsonProperty("processing_time_seconds")]
        public decimal ProcessingTimeSeconds { get; set; }
    }
    public class SmartUploadResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("data")]
        public SmartUploadData Data { get; set; }
    }
    public class InvalidFile
    {
        [JsonProperty("filename")]
        public string FileName { get; set; }

        [JsonProperty("column_validation")]
        public ColumnValidation ColumnValidation { get; set; }

        [JsonProperty("location_validation")]
        public LocationValidation LocationValidation { get; set; }

        [JsonProperty("date_validation")]
        public DateValidation DateValidation { get; set; }

        [JsonProperty("structure_validation")]
        public StructureValidation StructureValidation { get; set; }
    }
    public class ColumnValidation
    {
        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("unknown_columns")]
        public List<string> UnknownColumns { get; set; }

        [JsonProperty("column_suggestions")]
        public Dictionary<string, List<ColumnSuggestion>> ColumnSuggestions { get; set; }
    }
    public class ColumnSuggestion
    {
        [JsonProperty("column_suggestion")]
        public string ColumnSuggestionName { get; set; }

        [JsonProperty("confidence")]
        public decimal Confidence { get; set; }
    }
    public class LocationValidation
    {
        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("invalid_locations")]
        public List<string> InvalidLocations { get; set; }

        [JsonProperty("location_error_count")]
        public int LocationErrorCount { get; set; }

        [JsonProperty("location_suggestions")]
        public Dictionary<string, LocationSuggestion> LocationSuggestions { get; set; }
    }
    public class LocationSuggestion
    {
        [JsonProperty("suggested_locations")]
        public List<LocationMatch> SuggestedLocations { get; set; }

        [JsonProperty("top_suggestion")]
        public string TopSuggestion { get; set; }

        [JsonProperty("instruction")]
        public string Instruction { get; set; }
    }
    public class LocationMatch
    {
        [JsonProperty("suggestion")]
        public string Suggestion { get; set; }

        [JsonProperty("match_score")]
        public decimal MatchScore { get; set; }
    }
    public class DateValidation
    {
        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("issues")]
        public List<string> Issues { get; set; }

        [JsonProperty("columns_with_issues")]
        public Dictionary<string, List<string>> ColumnsWithIssues { get; set; }

        [JsonProperty("date_suggestions")]
        public Dictionary<string, DateSuggestion> DateSuggestions { get; set; }
    }
    public class DateSuggestion
    {
        [JsonProperty("column_name")]
        public string ColumnName { get; set; }

        [JsonProperty("suggested_date")]
        public string SuggestedDate { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("confidence")]
        public decimal Confidence { get; set; }
    }

    public class UploadFolderResponse
    {
        public bool success { get; set; }
        public int total_files { get; set; }
        public int processed_files { get; set; }
        public List<FileSummary> files_summary { get; set; }
        public string message { get; set; }
    }

    public class FileSummary
    {
        public string filename { get; set; }
        public string module { get; set; }
        public string match_percentage { get; set; }
        public string saved_path { get; set; }
        public string original_path { get; set; }
    }

    public class StructureValidation
    {
        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("total_affected_rows")]
        public int TotalAffectedRows { get; set; }

        [JsonProperty("returned_rows_count")]
        public int ReturnedRowsCount { get; set; }

        [JsonProperty("row_details")]
        public List<StructureRowDetail> RowDetails { get; set; }
    }

    public class StructureRowDetail
    {
        [JsonProperty("excel_row")]
        public int ExcelRow { get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }

        [JsonProperty("jc_no")]
        public string JCNo { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public class PartsMaster
    {
        [JsonProperty("Oil Type")]
        public string OilType { get; set; }

        [JsonProperty("Part Num")]
        public string PartNum { get; set; }
    }

    public class PartsData
    {
        public string PartCategory { get; set; }
        public string PartCategoryDescription { get; set; }
        public string PartNum { get; set; }
        public string PartDescription { get; set; }
        public string MonthYear { get; set; }
        public string Day { get; set; }
        public string SaleType { get; set; }
        public string ServiceDescription { get; set; }
        public string VariantName { get; set; }
        public string JobCardNum { get; set; }
        public string VIN { get; set; }
        public string OdometerReading { get; set; }
        public string ServiceAdvisor { get; set; }

        [JsonProperty("300+Odometer")]
        public string Odometer300Plus { get; set; }

        public string Model { get; set; }
        public string VehicleRegistrationNum { get; set; }
        public string BaseModelName { get; set; }
        public string JobCardOpenDate { get; set; }
        public string NetRetailQty { get; set; }
        public string NetRetailSelling { get; set; }
        public string NetRetailDDL { get; set; }

        [JsonProperty("NetRetailDDLw/oCO-DDLDDT")]
        public string NetRetailDDLWOCODDLDDT { get; set; }

        public string Location { get; set; }
        public string LocationDesc { get; set; }
        public string FileName { get; set; }

        public string WorkshopCodePy { get; set; }
    }
}