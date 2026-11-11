using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{

    public class LeadEnquiryUpload
    {
        public File ImportFromExcel { get; set; }
        public string Message { get; set; }
        public List<LeadEnquiryUploadImportModel> LeadEnquiryUploadImportModel { get; set; }
        public Dropdown Month { get; set; }
    }

    public class LeadEnquiryUploadImportModel
    {
        public string DDealerRegionCode { get; set; }
        public string LeadNo { get; set; }
        public string Name { get; set; }
        public string SourceOfEnquiry { get; set; }

        public string modelName { get; set; }
        public string DSalesDealerCode { get; set; }
        public string DOutletType { get; set; }
        public string DDealerName { get; set; }
        public string DEnquiryNum { get; set; }
        public string DEnquiryDate { get; set; }
        public string DProspectName { get; set; }
        public string DEnquiryCustomerType { get; set; }
        public string DSchemeCode1 { get; set; }
        public string DSchemeName1 { get; set; }
        public string DCorporate { get; set; }
        public string DBuyerType { get; set; }
        public string DReferenceNo { get; set; }
        public string DExistingMake { get; set; }
        public string DExistingModel { get; set; }
        public string DTradeInYN { get; set; }
        public string DEnquirySource { get; set; }
        public string DEnquiryMode { get; set; }
        public string DModel { get; set; }
        public string DVariant { get; set; }
        public string DTLName { get; set; }
        public string DDSEName { get; set; }
        public string DDSEEmployeeDesignation { get; set; }
        public string DNewCarEnquiryStatus { get; set; }
        public string DAgeOfEnquiry { get; set; }
        public string DTestDriveDate { get; set; }
        public string DHomeVisitDate { get; set; }
        public string DLostReason { get; set; }
        public string DNumOfFollowUp { get; set; }
        public string DBookingNum { get; set; }
        public string DBookingDate { get; set; }
        public string DPromisedDeliveryDate { get; set; }
        public string DInvoiceNum { get; set; }
        public string DInvoiceDate { get; set; }
        public string DEvaluatorCode { get; set; }
        public string DEvaluatorMSPINNo { get; set; }
        public string DEvaluatorName { get; set; }
        public string DEvaluationDate { get; set; }
        public string DBoughtDate { get; set; }
        public string DOldCarRegNum { get; set; }
        public string DOldCarModel { get; set; }
        public string DOldCarSubModel { get; set; }
        public string DOFFOfferedPrice { get; set; }
        public string DCustomerExpectedPrice { get; set; }
        public string DReofferedPrice { get; set; }
        public string DBuyingPrice { get; set; }
        public string DReferencePrice { get; set; }
        public string DDateOfReg { get; set; }
        public string DOldCarYOM { get; set; }
        public string DColorCode { get; set; }
        public string DNewCarVariant { get; set; }
        public string DFollowupMode { get; set; }
        public string DEBrochureDate { get; set; }
        public string DEQuoteDate { get; set; }
        public string DCustomerEmailYN { get; set; }
        public string DNextFollowupPlannedDate { get; set; }
        public string DLastFollowupDate { get; set; }
        public string DFollowupActionTaken { get; set; }
        public string DTestDriveMode { get; set; }
        public string DDSEMSPIN { get; set; }
        public string DTestDriveKMS { get; set; }
        public string DTestDriveDurationMins { get; set; }
        public string DEnquiryStrength { get; set; }
        public string DMultipleOutletVisitCount { get; set; }
        public string DMultipleOutletVisitFlag { get; set; }
        public string DMultipleEvaluationsFlag { get; set; }
        public string DMultipleEvaluationsCount { get; set; }
        public string DVisitedWithFamilyFlag { get; set; }
        public string DDuplicateEnquiriesFlag { get; set; }
        public string DEvaluationGapFlag { get; set; }
        public string DPIDropOnWebsite { get; set; }
        public string DDSEAssignedDate { get; set; }
        public string DRefName { get; set; }
        public string DReferenceType { get; set; }
        public string DRefMobileNo { get; set; }
        public string DCustomerProfile { get; set; }
        public string DBAType { get; set; }
        public string DACRMInfluence { get; set; }
        public string DCampaignCode { get; set; }
        public string DCampaignName { get; set; }
        public string DOldVehicleNextFollowupPlan { get; set; }
        public string DOldVehicleNextActionPlan { get; set; }
        public string DInterestedInLoyaltyCard { get; set; }
        public string DPurchaseLikelihood { get; set; }
        public string DEnquiry { get; set; }
        public string DCarConfigurationSaved { get; set; }
        public string DConfiguratorQuotationSentDate { get; set; }
        public string DLQSPlatform { get; set; }
        public string DHYPCampaign { get; set; }
        public string DUTMMedium { get; set; }
        public string DUTMCampaign { get; set; }
        public string DOculusID { get; set; }
        public string DVRExperienceShown { get; set; }
        public string DVRSameModelExperience { get; set; }
        public string DVRTimeSpent { get; set; }
        public string DVRExperienceDate { get; set; }
        public string DMobileNo { get; set; }
        public int active { get; set; }
        public int totalRecords { get; set; }
    }
}
