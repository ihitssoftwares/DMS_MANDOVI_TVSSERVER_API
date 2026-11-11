using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
  public  class InvoiceGenerationForVechicle
    {
        public int OrderTrnCode { get; set; }
        public Dropdown Status { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string AllotedStatus { get; set; }
        public decimal NetAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal BalanceDue { get; set; }
        public decimal BalanceAmt { get; set; }
        public string ReceiptNo { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string TransactionNo { get; set; }
        public decimal NewReceivedAmount { get; set; }
        public Dropdown PaymentMode { get; set; }
        public decimal PerOfBalance { get; set; }
        public CustomeAccitem CustomeRecieptList { get; set; }
        public List<CostPrice> CostPriceList { get; set; }
        public string NewReceiptNo { get; set; }
        public string Remarks { get; set; }
        public List<InvoiceGenerationForVechicle> InvoiceGenerationForVechicleList { get; set; }
    }
}
