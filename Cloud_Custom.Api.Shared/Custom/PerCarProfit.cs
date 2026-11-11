using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class PerCarProfit
    {
        public int SlNo { get; set; }
        public Dropdown Month { get; set; }
        public string DeliveryDate { get; set; }
        public string InvoiceNo { get; set; }
        public string Store { get; set; }
        public string SalesPosition { get; set; }
        public string VehicleDetails { get; set; }
        public int? ExShowPrice { get; set; }
        public int? CarPurchasePrice { get; set; }
        public int? GrossPay { get; set; }
        public int? Finalprofit { get; set; }
        public int? Exchangeprofit { get; set; }
        public decimal ExtendedWarrentyProfit { get; set; }
        public decimal InsuranceProfit { get; set; }
        public decimal FinanceProfit { get; set; }
        public decimal ExchangeBonus { get; set; }
        public decimal MGAAmount { get; set; }
        public decimal MCPAmount { get; set; }
        public decimal AutoCardAmount { get; set; }
        public decimal OtherDiscountAmount { get; set; }
        public decimal MSSFAmount { get; set; }
        public decimal NETPROFIT { get; set; }
        public decimal Salary { get; set; }
        public decimal Incentive { get; set; }

        public string VinNo { get; set; }

        public List<PerCarProfit> List { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal ReceivablesTotal { get; set; }
        public decimal FinalNetAmount { get; set; }
        public decimal ExpenseTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public object SaleUpdatePendingCount { get; set; }
        public object FinanceUpdatePendingCount { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal CostPrice { get; set; }
        public string VariantName { get; set; }
        public string ModelName { get; set; }
        public string InvoiceDate { get; set; }
        public string CustomerName { get; set; }
        public string BranchName { get; set; }
        public int Hdcode { get; set; }
        public PLReport PLReport { get; set; }
    }
    public class PLReport
    {
        public List<PLHeader> DiscountHeaders { get; set; } = new List<PLHeader>();
        public List<PLHeader> ReceivableHeaders { get; set; } = new List<PLHeader>();
        public List<PLHeader> ExpenseHeaders { get; set; } = new List<PLHeader>();
        public List<PLInvoice> List { get; set; } = new List<PLInvoice>();
        public PLTotal Total { get; set; } = new PLTotal();
    }

    public class PLHeader
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }

    public class PLInvoice
    {
        public int SalesTrnCode { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string CustomerName { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string VariantCode { get; set; }
        public decimal InvoiceAmount { get; set; }
        public List<PLLine> Lines { get; set; } = new List<PLLine>();
    }

    public class PLLine
    {
        public string Section { get; set; }   
        public int TypeCode { get; set; }
        public decimal Amount { get; set; }
    }

    public class PLTotal
    {
        public int TotalCount { get; set; }
        public decimal TotalInvoiceAmount { get; set; }
        public List<PLLine> Lines { get; set; } = new List<PLLine>();
    }
}
