using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ServiceFileUploadReconcilationReport
    {
        public int TotalAmount { get; set; }
        public string JobCardNo { get; set; }
        public int jcInLoad { get; set; }
        public int jcInLabour { get; set; }
        public int branchCode { get; set; }
        public string branchName { get; set; }
        public int UploadedLoad { get; set; }
        public int UploadedLabour { get; set; }
        public Dropdown Month { get; set; }
        public int Monthcode { get; set; }
        public Dropdown IncentiveGroup { get; set; }
        public int IncentiveGroupCode { get; set; }
        public Dropdown WorkShop { get; set; }
        public Dropdown MonthFrom { get; set; }
        public Dropdown MonthTo { get; set; }
        public Dropdown Parameter { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public int NoOfWsUploadedLoad { get; set; }
        public int NoOfWsNotUploadedLoad { get; set; }
        public int NoOfWsUploadedLabour { get; set; }
        public int NoOfWsNotUploadedLabour { get; set; }
        public int NoOfJobCardLoad { get; set; }
        public int NoOfJobCardLabour { get; set; }
        public int NoOfJobCardInLoadNotInLabour { get; set; }
        public int LabourAmtInLabour { get; set; }
        public int NoOfJobCardInLabourNotInLoad { get; set; }
        public int LabourAmtInLoad { get; set; }
       
        public List<ServiceFileUploadReconcilationReport> List { get; set; }
        public List<ServiceFileUploadReconcilationReportList> EditList { get; set; }
        public List<ServiceFileUploadReconcilationReportList2> EditList2 { get; set; }
    }
    public class ServiceFileUploadReconcilationReportList
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

    public class ServiceFileUploadReconcilationReportList2
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
