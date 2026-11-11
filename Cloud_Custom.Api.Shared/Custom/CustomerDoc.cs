using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class CustomerDoc
    {
        public int TrnCode { get; set; }
        public string CusttomerName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string Status { get; set; }
        public bool Aadhar { get; set; }
        public bool PAN { get; set; }
        public bool Photo { get; set; }
        public bool Insurance { get; set; }
        public bool Passport { get; set; }
        public bool Form20 { get; set; }
        public bool Form21 { get; set; }
        public bool Form22 { get; set; }
        public bool Form34 { get; set; }
        public bool BankAccount { get; set; }
        
        public File File { get; set; }
        public List<CustomerDoc> CustomerDocsList { get; set; }
        public CustomerDocItem CustomerDocItem { get; set; }
    }
    public class CustomerDocItem
    {
        public int TrnCode { get; set; }
        public int DocCode { get; set; }
        public string DocName { get; set; }
        public string AbsoluteUrl { get; set; }
        public string ActaulFileName { get; set; }
        public File File { get; set; }
    
        public string CusttomerName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string Status { get; set; }
        public bool Aadhar { get; set; }
        public bool PAN { get; set; }
        public bool Photo { get; set; }
        public bool Passport { get; set; }
        public bool BankAccount { get; set; }
        public List<CustomerDocItem> CustomerDocItemList { get; set; }

    }
}
