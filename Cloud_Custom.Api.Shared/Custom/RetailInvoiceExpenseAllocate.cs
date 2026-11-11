using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class RetailInvoiceExpenseAllocate
    {
        public List<RetailInvoiceExpenseAllocate> RetailInvoiceExpenseAllocateList { get; set; }
        public RetailInvoiceExpenseAllocateItem RetailInvoiceExpenseAllocateItem { get; set; }

        public int HDCODE { get; set; }
        public string InvNo { get; set; }
        public string Date { get; set; }
        public string StoreOrBranch { get; set; }
        public string Executive { get; set; }
        public string Model { get; set; }
        public string VariantColor { get; set; }
        public string EngineChasisNo { get; set; }
        public string CustomerName { get; set; }
        public decimal SaleAmount { get; set; }
        public decimal ExpenseTotal { get; set; }
        public decimal NetAmount { get; set; }
        public bool IsAllocated { get; set; }
        public string AllocateStatus { get; set; }
        public decimal VehiclePurchaseCost { get; set; }
    }

    public class RetailInvoiceExpenseAllocateItem
    {
        public int SalesTrnCode { get; set; }
        public string CustomerName { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string VariantCode { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string Remarks { get; set; }
        public List<RetailInvoiceExpenseAllocateItem> ExpensesList { get; set; } = new List<RetailInvoiceExpenseAllocateItem>();
        public int Code { get; set; }
        public string Name { get; set; }
        public decimal? Amount { get; set; }
  
    }
}
