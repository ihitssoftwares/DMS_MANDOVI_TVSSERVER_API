using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public class SalesUpdate
    {
        public int HDCODE { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Status { get; set; }

        public int StatusType { get; set; }
        public Dropdown Store { get; set; }
        public int MessStatus { get; set; }
        public Dropdown DSE { get; set; }
        public Dropdown CarModel { get; set; }
        public Dropdown Dealer { get; set; }
        public string Message { get; set; }
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
        public string CustMob { get; set; }
        public string ConsumerDiscount { get; set; }
        public string CorporateDiscount { get; set; }
        public string NetAmount { get; set; }
        public string Remarks { get; set; }
        public int TotalCount { get; set; }
        public string Mode { get; set; }
        public SalesUpdateItem SalesUpdateItem { get; set; }
        public List<SalesUpdate> SalesUpdateList { get; set; }
        public List<SalesUpdateItem> List { get; set; }
        //public List<AccessoriesSales> AccessoriesList { get; set; }
        public int ModelCode { get; set; }

        public decimal pprofitPercent { get; set; }
        public decimal fprofitPercent { get; set; }
        public decimal iprofitPercent { get; set; }
        public decimal PlanProfit { get; set; }
        public decimal finProfit { get; set; }
        public decimal incProfit { get; set; }
        public decimal EXbProfit { get; set; }
        public decimal cpaprofit { get; set; }
        public decimal gaaprofit { get; set; }
        public decimal acprofit { get; set; }
        public decimal odAmt { get; set; }
        public decimal ssfamt { get; set; }
        public decimal accprofit { get; set; }
        public Dropdown ModeOfPayment { get; set; }

        public decimal SaleAmount { get; set; }

    }
    public class SalesUpdateItem
    {
        public string ValidationMessage { get; set; }
        public string DispatchDate { get; set; }
        public int CostAmt { get; set; }
        public decimal? EWAmount { get; set; }
        public decimal? MIAmount { get; set; }
        public decimal? MGAAmount { get; set; }
        public decimal? MCPAmount { get; set; }
        public decimal? MCPProfit { get; set; }
        public Dropdown Employee { get; set; }
        public Dropdown Branch { get; set; }
        public Dropdown Modell { get; set; }
        public string ExchangeStatus { get; set; }
        public string FinanceStatus { get; set; }
        public decimal? AutoCardAmount { get; set; }
        public decimal? AutoCardProfit { get; set; }
        public decimal? OtherDiscount { get; set; }
        public decimal? MSSFAmount { get; set; }
        public string Executive { get; set; }
        public string Model { get; set; }
        public string StoreOrBranch { get; set; }
        public Dropdown Finance { get; set; }
        public Dropdown Insurance { get; set; }
        public Dropdown Plan { get; set; }
        public Dropdown Accessories { get; set; }
        public int WarrentyAmount { get; set; }
        public decimal WProfitAmount { get; set; }
        public int InsuranceAmount { get; set; }
        public int AccesoryAmount { get; set; }
        public int FinanaceAmount { get; set; }
        public bool ExchengeBonus { get; set; }
        public int ExchamgeBonusAmount { get; set; }
        public int ModelCode { get; set; }
        public decimal ProfitFinanceAmount { get; set; }
        public decimal ProfitInsuranceAmount { get; set; }
        public List<SalesUpdateItem> List { get; set; }
        public List<AccessoriesSales> AccessoriesList { get; set; }
        public decimal NETPROFITAmount { get; set; }
        public string Varient { get; set; }
        public string color { get; set; }
        public Dropdown Varients { get; set; }
        public Dropdown Colors { get; set; }
        public Dropdown ModeOfPayment { get; set; }
        public decimal NetAmount { get; set; }
        public decimal SellingAmount { get; set; }
        public decimal AccessoryAmount { get; set; }
        public decimal AccessoryProfitAmount { get; set; }
        public string NewVehVIN { get; set; }

    }
    public class AccessoriesSales
    {
        public int AccessoriesCode { get; set; }
        public string Type { get; set; }
        public int AccessoryAmount { get; set; }
        public bool Applicablity { get; set; }
        public int SellingAmount { get; set; }
        public decimal ProfitAmount { get; set; }
    }
}
