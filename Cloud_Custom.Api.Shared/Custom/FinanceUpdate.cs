using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class FinanceUpdate
    {
        public Dropdown Month { get; set; }
        public Dropdown Status { get; set; }
        public int StatusType { get; set; }
        public List<FinanceUpdate> FinanceUpdateList { get; set; }

        public int HDCODE { get; set; }
        public string InvNo { get; set; }
        public string Date { get; set; }
        public string StoreOrBranch { get; set; }
        public string Executive { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string Color { get; set; }
        public string EngineNo { get; set; }
        public string ChasisNo { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalReceivable { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal TotalDiscount { get; set; }
        public string NetAmount { get; set; }

        public string VariantColor { get; set; }
        public string EngineChasisNo { get; set; }
        public decimal ReceivablesTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal ExpenseTotal { get; set; }

        public decimal SalesAmount { get; set; }

        public FinanceUpdateItem FinanceUpdateItem { get; set; }
        public decimal VehiclePurchaseCost { get; set; }
        public string VerifyStatus { get; set; }
    }

    public class FinanceUpdateItem
    {
        public int SalesTrnCode { get; set; }

        public string CustomerName { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string VariantCode { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string VinNo { get; set; }

        public decimal InvoiceAmount { get; set; }

        public decimal TotalReceivable { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal TotalDiscount { get; set; }

        public List<FinanceLineItem> DiscountList { get; set; } = new List<FinanceLineItem>();
        public List<FinanceLineItem> ReceivablesList { get; set; } = new List<FinanceLineItem>();
        public List<FinanceLineItem> ExpensesList { get; set; } = new List<FinanceLineItem>();

        public string ValidationMessage { get; set; }
        public decimal TotalEarning { get; set; }
        public decimal GrossRetention { get; set; }
        public decimal SalesAmount { get; set; }

        public decimal NetRetention { get; set; }
        public DateTime DeliVeryDate { get; set; }
        public decimal PurhaseCostPrice { get; set; }


        public List<FinanceAccessoryItem> AccessoriesList { get; set; } = new List<FinanceAccessoryItem>();
        public int TotalAccessoriesQty { get; set; }
        public int TotalAccessoriesCost { get; set; }
        public int TotalAccessoriesSelling { get; set; }
        public int TotalAccessoriesProfit { get; set; }
    }

    public class FinanceLineItem
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
        public string Remarks { get; set; }
        public decimal? Amount { get; set; }
    }


    public class FinanceAccessoryItem
    {
        public int TrnCode { get; set; }
        public int? HdCode { get; set; }
        public int? ItemCode { get; set; }
        public string ItemName { get; set; }
        public string PartNumber { get; set; }
        public int? Qty { get; set; }
        public int? UnitPrice { get; set; }
        public int? Cost { get; set; }
        public int? SellingPrice { get; set; }
        public int? Profit { get; set; }
    }
}
