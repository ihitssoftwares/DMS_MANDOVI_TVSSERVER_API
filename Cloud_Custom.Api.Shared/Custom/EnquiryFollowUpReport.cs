using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class EnquiryFollowUpReport
    {
        public string Months { get; set; }
        public string SalesDealerCode { get; set; }
        public string EnquiryNum { get; set; }
        public string EnquiryDate { get; set; }
        public string ProspectName { get; set; }
        public string EnquirySource { get; set; }

        public string Model { get; set; }
        public string Variant { get; set; }
        public string Colour { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }

        public string TLName { get; set; }
        public string DSEName { get; set; }
        public string NewCarEnquiryStatus { get; set; }

        public string TestDriveDate { get; set; }
        public string HomeVisitDate { get; set; }
        public string NumOfFollowUp { get; set; }

        public string EvaluatorMSPINNo { get; set; }
        public string EvaluatorName { get; set; }
        public string EvaluationDate { get; set; }
        public string DSEMSPINNo { get; set; }

        public string MultipleOutletVisitCount { get; set; }
        public string MultipleEvaluationsCount { get; set; }
        public string EvaluationGapFlag { get; set; }

        public string Enquiry { get; set; }
        public string CarConfigurationSaved { get; set; }
        public string ConfiguratorQuotationSentDate { get; set; }
        public string NextFollowupPlannedDate { get; set; }

        public string TestDrive { get; set; }
        public string LiveEnquiry { get; set; }
        public string TD { get; set; }
        public string HomeVisit { get; set; }
        public string MultipleOutlet { get; set; }
        public string Evaluation { get; set; }

        public int TrnCode { get; set; }
        public int EnqTranCode { get; set; }
        public string LeadStatus { get; set; }
        public string ModeOfContact { get; set; }
        public int Remarks { get; set; }
        public int PurchaseTimeline { get; set; }
        public string MDMSEnquiryCode { get; set; }
        public string MDMSEnquiryDate { get; set; }
        public int Employee { get; set; }
        public string BranchCode { get; set; }
        public string DealerCode { get; set; }

        public Dropdown Month { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Branch { get; set; }
        public Dropdown IncentiveGroup { get; set; }
        
        public Dropdown WorkShop { get; set; }
        public Dropdown MonthFrom { get; set; }
        public Dropdown MonthTo { get; set; }
        public Dropdown Parameter { get; set; }
       

        public List<EnquiryFollowUpReport> List { get; set; }
        public List<EnquiryFollowUpReportList> EditList { get; set; }
        public List<EnquiryFollowUpReportList2> EditList2 { get; set; }
    }
    public class EnquiryFollowUpReportList
    {
        public string Location { get; set; }
        public string JobCardNo { get; set; }
        public string JcDate { get; set; }
        public string SA { get; set; }
        public string Technician { get; set; }
        public string ServiceType { get; set; }
        public decimal PartAmt { get; set; }
        public decimal LabourAmt { get; set; }
        public decimal BillAmount { get; set; }
        public string BillDate { get; set; }

    }

    public class EnquiryFollowUpReportList2
    {
        public string Location { get; set; }
        public string JobCardNo { get; set; }
        public string JcDate { get; set; }
        public string SA { get; set; }
        public string Technician { get; set; }
        public string ServiceType { get; set; }
        public decimal PartAmt { get; set; }
        public decimal LabourAmt { get; set; }
        public decimal BillAmount { get; set; }
        public string BillDate { get; set; }


    }
}
