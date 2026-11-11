using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class CustomerAccount
    {
        public int OrderTrnCode { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string AllotedStatus { get; set; }
        public decimal NetAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal BalanceDue { get; set; }
        public decimal PerOfBalance { get; set; }
        public string ReceiptNo { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string TransactionNo { get; set; }
        public decimal NewReceivedAmount { get; set; }
        public Dropdown PaymentMode { get; set; }
        public decimal BalanceAmt { get; set; }
        public List<CustomerAccount> CustomerAccountList { get; set; }
        public List<CostPrice> CostPriceList { get; set; }
        public CustomeAccitem CustomeAccitem { get; set; }

    }
    public class CustomeAccitem { 
        public int TrnCode { get; set; }
        public string date { get; set; }
        public string receiptNo { get; set; }
        public string PaymentMode { get; set; }
        public string transactionNo { get; set; }
        public string Amount { get; set; }
        public List<CustomeAccitem> CustomeAccitemList { get; set; }
    }


}


