using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class VahanDumpUpload
    {
        public File ImportFromExcel { get; set; }
        public string Message { get; set; }
        public List<VahanDumpUploadModel> VahanDumpUploadModel { get; set; }
        public List<DumpUploadModel> DumpUploadModel { get; set; }
        public List<VahanDumpUploadModel> VahanDumpUploadList { get; set; }
        public Dropdown Month { get; set; }

    }


}
public class VahanDumpUploadModel
{
    public int TrnCode { get; set; }

    public string OfficeName { get; set; }

    public string DealerName { get; set; }

    public string VehicleClass { get; set; }

    public string Description { get; set; }

    public string ReceiptNumber { get; set; }

    public DateTime ReceiptDate { get; set; }

    public string ApplicationNo { get; set; }

    public DateTime ApplicationDate { get; set; }

    public string EKYCStatus { get; set; }

    public string Vehicle { get; set; }

    public string RegistrationNumber { get; set; }

    public string OwnerName { get; set; }

    public string ChasisNumber { get; set; }

    public string TransactionNumber { get; set; }

    public string TransactionId { get; set; }

    public string BankRefNo { get; set; }

    public string TransactionType { get; set; }

    public DateTime ApprovalDate { get; set; }

    public string FrontLaserCode { get; set; }

    public string RearLaserCode { get; set; }

    public string Status { get; set; }

    public string PublicRemark { get; set; }

    public string CurrentAddress { get; set; }

    public string PermanentAddress { get; set; }

    public int Fees { get; set; }

    public int MVTax { get; set; }

    public int Surcharge { get; set; }

    public int Penalty { get; set; }

    public int Interest { get; set; }

    public int Exempted { get; set; }

    public int Rebate { get; set; }

    public int Total { get; set; }


}
public class DumpUploadModel
{
    public int TrnCode { get; set; }

    public string OfficeName { get; set; }

    public string DealerName { get; set; }

    public string VehicleClass { get; set; }

    public string Description { get; set; }

    public string ReceiptNumber { get; set; }

    public string ReceiptDate { get; set; }

    public string ApplicationNo { get; set; }

    public string ApplicationDate { get; set; }

    public string EKYCStatus { get; set; }

    public string Vehicle { get; set; }

    public string RegistrationNumber { get; set; }

    public string OwnerName { get; set; }

    public string ChasisNumber { get; set; }

    public string TransactionNumber { get; set; }

    public string TransactionId { get; set; }

    public string BankRefNo { get; set; }

    public string TransactionType { get; set; }

    public string ApprovalDate { get; set; }

    public string FrontLaserCode { get; set; }

    public string RearLaserCode { get; set; }

    public string Status { get; set; }

    public string PublicRemark { get; set; }

    public string CurrentAddress { get; set; }

    public string PermanentAddress { get; set; }

    public string Fees { get; set; }

    public string MVTax { get; set; }

    public string Surcharge { get; set; }

    public string Penalty { get; set; }

    public string Interest { get; set; }

    public string Exempted { get; set; }

    public string Rebate { get; set; }

    public string Total { get; set; }
    public int EntrBy { get; set; }

    public DateTime EntryDate { get; set; }

    public string Message { get; set; }
}


