using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class Services
    {

        public Batteryy Batteryy { get; set; }
        public CCPp CCPp { get; set; }
        public EW EW { get; set; }
        public labour labour { get; set; }
        public load load { get; set; }
        public Mcp mcp { get; set; }
        public Mga mga { get; set; }
        public Pms20 pms20 { get; set; }
        public PmsParts pmsparts { get; set; }
        public Spares spares { get; set; }
        public SyntheticOil syntheticoOil { get; set; }
        public Truevalue trueValue { get; set; }
        public Tyree tyre { get; set; }

    }
    public class Batteryy
    {
        public int? TotalQty { get; set; }
        public int? TotalRevenue { get; set; }
        public int? TotalDDL { get; set; }
        public int? AVGPrice { get; set; }
        public int? MonthCode { get; set; }
        public string MonthName { get; set; }
        public int? MonthSales { get; set; }
        public string ServiceAdvisorName { get; set; }
        public string Colour { get; set; }
        public int? Revenue { get; set; }
        public int? Qty { get; set; }
        public string LocationCode { get; set; }
        public string Branchname { get; set; }
        public int? locationRevenue { get; set; }
        public int? locationQty { get; set; }
        public string partDescription { get; set; }
        public Dropdown Branch { get; set; }
        public int? partTotalQty { get; set; }

    
        public string Day { get; set; }
        public string DailySales { get; set; }

        public string Advisior { get; set; }
        public string listLocationCode { get; set; }
        public string listpartDescription { get; set; }
        public int? listNetretailQty { get; set; }
        public int? NetRetailselling { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Type { get; set; }
        public Dropdown Region { get; set; }
   
        public List<Batteryy> BatteryList { get; set; }
        public List<Batteryy> MonthList { get; set; }
        public List<Batteryy> AdvisorList { get; set; }
        public List<Batteryy> LoctionList { get; set; }
        public List<Batteryy> PartList { get; set; }

    }


    public class CCPp
    {
        public int? CCPTotalRecords { get; set; }
        public int? CCPTotalSales { get; set; }
        public int? CCPTotalClaimAmount { get; set; }
        public int? CCPActivePolicies { get; set; }
        public string CCPDealername { get; set; }
        public string CCPCount { get; set; }
        public string CCPVIN { get; set; }
        public string CCPCustName { get; set; }
        public string CCPModelDesc { get; set; }
        public string CCPSaleDate { get; set; }
        public string CCPPolicyNum { get; set; }
        public int? CCPNetAmt { get; set; }
        public string CCPStatus { get; set; }
        public string FromDate { get; set; }
        public string Todate { get; set; }
        public string Search { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Type { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Branch { get; set; }
        public List<CCPp> CCPList { get; set; }
    }

     //---------------- EW ----------------
    public class EW
    {
        public int? EWTotalPolicies { get; set; }
        public int? EWTotalRevenue { get; set; }
        public int? EWTotalDiscount { get; set; }
        public int? EWAvgPremium { get; set; }
        public int? EWTotalCommission { get; set; }
        public string Colour { get; set; }
        public string EWMonthname { get; set; }
        public int? EWRevenue { get; set; }

        public string EWBranch { get; set; }
        public int? EWPolicies { get; set; }
        public int? EWBranchRevenue { get; set; }

        public string EWModelDesc { get; set; }
        public int? EWPolicyCount { get; set; }
        public Dropdown Branch { get; set; }
        public string EWServiceAdvisor { get; set; }
        public int? EWAdvisorRevenue { get; set; }
        public int? EWAdvisorPolicies { get; set; }

        public string EWPolicyNo { get; set; }
        public string EWCustomerName { get; set; }

        public string EWListBranch { get; set; }
        public string EWListModelDescri { get; set; }

        public string EWPremiumAmount { get; set; }
        public string EWExpiryDate { get; set; }
        public string FromDate { get; set; }
        public string Todate { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Type { get; set; }
        public Dropdown Region { get; set; }
  
        public List<EW> EWList { get; set; }
        public List<EW> EWMonthly { get; set; }
        public List<EW> EWBranchWise { get; set; }
        public List<EW> EWModelWise { get; set; }
        public List<EW> EWAdvisor { get; set; }

    }

    // ---------------- LABOUR ----------------
    public class labour
    {
        public int? LabourTotalJobs { get; set; }
        public int? LabourTotalRevenue { get; set; }
        public int? LabourTotalDiscount { get; set; }
        public int? LabourAvgBillValue { get; set; }

        public string LabourBillDate { get; set; }
        public int? LabourbillRevenue { get; set; }
        public string Colour { get; set; }
        public string LabourDealerName { get; set; }
        public int? LabourDealerRevenue { get; set; }
        public string labourlabourCode { get; set; }
        public string labourlabourDesc { get; set; }
        public int labourlabourTotalJobs { get; set; }
        public int labourlabourTotallaourAmount { get; set; }
        public int labourlabourTotalAvglaourAmount { get; set; }
        public string LabourDetailJcNum { get; set; }
        public string LabourDetailCustomerName { get; set; }
        public string LabourDetailJcDate { get; set; }
        public string LabourDetailRegNo { get; set; }
        public string LabourDetailModel { get; set; }
        public string LabourDetailBillNo { get; set; }
        public int? LabourDetailBillAmt { get; set; }
        public DateTime? LabourDetailBillDate { get; set; }
        public string FromDate { get; set; }
        public string Todate { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Type { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Branch { get; set; }
        public List<labour> labourList { get; set; }
        public List<labour> labourBillList { get; set; }
        public List<labour> labourDealerList { get; set; }
        public List<labour> labourLabourList { get; set; }
        public List<labour> PopUpList { get; set; }
        public int Code { get; set; }
        public string Location { get; set; }
        public string JobCardNo { get; set; }
        public DateTime JCDate { get; set; }
        public string SA { get; set; }
        public string CustomerName { get; set; }
        public string RegistrationNo { get; set; }
        public string CHASISNO { get; set; }
        public string EnginNo { get; set; }
        public decimal BillAmount { get; set; }
        public int active { get; set; }
        public int totalRecords { get; set; }
        public string Tab { get; set; }
        public string Name { get; set; }

    }

    // ---------------- LOAD ----------------
    public class load
    {
        public string LoadlistDealerName { get; set; }
        public string LoadlistDealerCity { get; set; }
        public string LoadlistLocation { get; set; }
        public string LoadlistJobCardNo { get; set; }
        public string LoadlistJobDate { get; set; }
        public string LoadlistCustomerName { get; set; }
        public string LoadlistServiceType { get; set; }
        public int? LoadlistBillAmount { get; set; }
        public string LoadlistStatus { get; set; }
        public string LoadlistRepeatRevisit { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Type { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Branch { get; set; }
        public int? LoadTotalJobs { get; set; }
        public int? LoadTotalRevenue { get; set; }
        public int? LoadAvgBilling { get; set; }
        public int? LoadRepeatJobs { get; set; }

        public string LoadRevenueDealerName { get; set; }
        public int? LoadRevenue { get; set; }

        public string LoadServiceTypeName { get; set; }
        public int? LoadJobCount { get; set; }
        public string FromDate { get; set; }
        public string Todate { get; set; }
        public List<load> loadList { get; set; }
        public List<load> loadDealerList { get; set; }
        public List<load> loadServiceList { get; set; }
        public List<load> PopUpList { get; set; }
        public int Code { get; set; }

        public string Location { get; set; }
        public string JobCardNo { get; set; }
        public DateTime JCDate { get; set; }
        public string SA { get; set; }
        public string CustomerName { get; set; }
        public string RegistrationNo { get; set; }
        public string CHASISNO { get; set; }
        public string EnginNo { get; set; }
        public decimal BillAmount { get; set; }
        public int active { get; set; }
        public int totalRecords { get; set; }
        public string Tab { get; set; }
        public string Name { get; set; }
    }
    // ---------------- MCP ----------------
    public class Mcp
    {
        public int? MCPTotalMCP { get; set; }
        public int? MCPActiveMCP { get; set; }
        public int? MCPExpiredMCP { get; set; }
        public int? MCPCancelledMCP { get; set; }

        public string MCPLocation { get; set; }
        public string MCPEnrollmentNo { get; set; }
        public string MCPInvoiceNo { get; set; }

        public string MCPDate { get; set; }
        public string MCPStatus { get; set; }

        public string MCPCustomerName { get; set; }
        public string MCPMobile { get; set; }

        public string MCPModel { get; set; }
        public string MCPRegNum { get; set; }
        public string FromDate { get; set; }
        public string Todate { get; set; }
        public string MCPStartDate { get; set; }
        public string MCPEndDate { get; set; }
        public Dropdown Status { get; set; }
        public Dropdown Branch { get; set; }
        public int? MCPNoOfServiceOffered { get; set; }
        public int? MCPBalanceServices { get; set; }

        public int? MCPAmountCollected { get; set; }
        public int? MCPAmountUsed { get; set; }
        public int? MCPBalanceAmount { get; set; }

        public string MCPExecutive { get; set; }

        

        public string MCPSummaryLocation { get; set; }

        public int? MCPLocationTotalMCP { get; set; }
        public int? MCPLocationActiveMCP { get; set; }
        public int? MCPLocationExpiredMCP { get; set; }
        public int? MCPLocationCancelledMCP { get; set; }

        public string MCPName { get; set; }
        public int? MCPcount { get; set; }
        public int? MCPTotalBalance { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Type { get; set; }
        public Dropdown Region { get; set; }
        public string Colour { get; set; }
        public List<Mcp> McpList { get; set; }
        public List<Mcp> McpLocationdetailsList { get; set; }
        public List<Mcp> McpLocationList { get; set; }
        public List<Mcp> McpStatusList { get; set; }
        public List<Mcp> McpLocationCountList { get; set; }

    }
    public class Mga
    {
        public string Colour { get; set; }
        public string MgaRegion { get; set; }
        public string MgaDealerName { get; set; }
        public string MgaCity { get; set; }
        public string MgaBranch { get; set; }
        public string MgaServiceAdvisor { get; set; }

        public int? MgaConsumption { get; set; }
        public int? MgaLoadValue { get; set; }
        public int? MgaLoad { get; set; }
        public int? MgaACFilter { get; set; }
        public int? MgaPerfumes { get; set; }
        public string MgaLostServiceAdvisor { get; set; }

        public int? MgaLostConsumption { get; set; }
   
        public string MgapServiceAdvisor { get; set; }

        public int? MgapConsumption { get; set; }
         public string mgaMonth { get; set; }
         public int? mgaMonthTotalConSumption { get; set; }
         public int? mgaMonthMGAload { get; set; }
        public int? MgaAvgComnsumption{ get; set; }
        public int? MgaTotalConsumption { get; set; }
        public int? MgaTotalLoad { get; set; }
        public int? MgaTotalMGA { get; set; }
        public string Color { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Type { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Branch { get; set; }
        public List<Mga> MgaAdvisorList { get; set; }
        public List<Mga> MgalostAdvisorList { get; set; }
        public List<Mga> MgaMonthList { get; set; }
        public List<Mga> MgaList { get; set; }
        public List<Mga> MgaPopUpList { get; set; }
        public int MgaCode { get; set; }

        public string MgaLocation { get; set; }
        public string MgaJobCardNo { get; set; }
        public DateTime MgaJCDate { get; set; }
        public string MgaSA { get; set; }
        public string MgaCustomerName { get; set; }
        public string MgaRegistrationNo { get; set; }
        public string MgaCHASISNO { get; set; }
        public string MgaEnginNo { get; set; }
        public decimal MgaBillAmount { get; set; }
        public int active { get; set; }
        public int totalRecords { get; set; }
        public string MgaTab { get; set; }
        public string MgaName { get; set; }

        
    }

    // ---------------- PMS20 ----------------
    public class Pms20
    {
       
        public int? Pms20TotalJC { get; set; }
        public int? Pms20TotalRevenue { get; set; }
        public int? Pms20LabourRevenue { get; set; }
        public int? Pms20PartsRevenue { get; set; }
        public int? Pms20AvgTAT { get; set; }

        public string Pms20JCNo { get; set; }
        public int Pms20JCBillAmt { get; set; }
        public string colour { get; set; }
        public Dropdown Dealer { get; set; }
        public string Pms20ServiceType { get; set; }
        public int? Pms20TotalCount { get; set; }

        public string Pms20DetailJCNo { get; set; }
        public string Pms20Dealer { get; set; }
        public string Pms20Model { get; set; }
        public string Pms20DetailServiceType { get; set; }
        public int? Pms20DetailJCBillAmt { get; set; }

        public string Pms20JCOpenDate { get; set; }
        public string Pms20JCCloseDate { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Type { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Branch { get; set; }
        public List<Pms20> Pms20List { get; set; }
        public List<Pms20> Pms20JcNoListList { get; set; }
        public List<Pms20> Pms20ServiceList { get; set; }

    }

    // ---------------- PMS PARTS ----------------
    public class PmsParts
    {
        public string Colour { get; set; }
        public string PmsPartsServiceAdvisorName { get; set; }

        public int? PmsPartsTotalRecords { get; set; }
        public int? PmsPartsTotalPMSRequired { get; set; }
        public int? PmsPartsTotalPMSChanged { get; set; }
        public int? PmsPartsPMSPercent { get; set; }

        public int? PmsPartsTrnCode { get; set; }
        public string PmsPartsLocationCode { get; set; }
        public string PmsPartsServiceAdvisorNameDetail { get; set; }

        public string PmsPartsMonthYear { get; set; }
        public int? PmsPartsDay { get; set; }

        public string PmsPartsBaseModelName { get; set; }
        public string PmsPartsVariantName { get; set; }
        public string PmsPartsRequiredPartGroupDesc { get; set; }

        public int? PmsPartsPMSRequired { get; set; }
        public int? PmsPartsPMSChanged { get; set; }

        public int PmsPartsTotalPMSPercent { get; set; }
        public DateTime PmsPartsEntryDate { get; set; }
       
        public int? PmsPartsCount { get; set; }
        public string PmsPartsName { get; set; }
        public int? PmsPartsOverallTotalPMSChanged { get; set; }
        public int? PmsPartsOverallTotalPMSPercent { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Type { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Branch { get; set; }
        public List<PmsParts> PmsPartsList { get; set; }
        public List<PmsParts> PmsPartsAdvisorList { get; set; }
    }

    // ---------------- SPARES ----------------
    public class Spares
    {
        public string Colour { get; set; }
        public int SparesTotalBills { get; set; }
        public int SparesTotalRevenue { get; set; }
        public int SparesPartsRevenue { get; set; }
        public int SparesLabourRevenue { get; set; }

        public string SparesName { get; set; }
        public int SparesCount { get; set; }

        public string SparesBillNo { get; set; }
        public string SparesBillDateDetail { get; set; }

        public string SparesDealerName { get; set; }
        public string SparesLocation { get; set; }
        public string SparesPartyName { get; set; }

        public int SparesPartsCharges { get; set; }
        public int SparesLabourCharges { get; set; }
        public int SparesBillAmt { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Type { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Branch { get; set; }
        public List<Spares> SparesList { get; set; }
        public List<Spares> SparesBillList { get; set; }
    }

    // ---------------- SYNTHETIC OIL ----------------
    public class SyntheticOil
    {
        public int SyntheticOilTotalRecords { get; set; }
        public int SyntheticOilTotalQty { get; set; }
        public int SyntheticOilTotalServiceLoad { get; set; }
        public string Colour { get; set; }
        public string SyntheticOilRegion { get; set; }
        public string SyntheticOilDealerCity { get; set; }
        public string SyntheticOilLocationDescription { get; set; }

        public string SyntheticOilName { get; set; }
        public int? SyntheticOilCount { get; set; }
        public string SyntheticOilServiceAdvisorName { get; set; }

        public int SyntheticOilNetRetailQty { get; set; }
        public int SyntheticOilServiceLoad { get; set; }

        public string SyntheticOilMonthYear { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Type { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Branch { get; set; }
        public List<SyntheticOil> SyntheticOilList { get; set; }
    }

    // ---------------- TRUE VALUE ----------------
    public class Truevalue
    {
        public string Colour { get; set; }
        public int TrueValueTotalEnquiry { get; set; }
        public int TrueValueNetBooking { get; set; }
        public int TrueValueNetSales { get; set; }

        public decimal TrueValueTotalProfit { get; set; }

        public string TrueValueDealerCity { get; set; }
        public int TrueValueTotalSales { get; set; }
        public decimal TrueValueDealerProfit { get; set; }

        public string TrueValueDealerCityDetail { get; set; }
        public string TrueValueSaleDate { get; set; }

        public string TrueValueName { get; set; }
        public int? TrueValueCount { get; set; }
        public string TrueValueFuelType { get; set; }

        public int TrueValueBuyingPrice { get; set; }
        public int TrueValueSellingPrice { get; set; }
        public int TrueValueProfitMargin { get; set; }

        public int TrueValueNetSale { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Type { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Branch { get; set; }
        public List<Truevalue> TruevalueList { get; set; }
        public List<Truevalue> TruevalueDealerList { get; set; }
    }

    // ---------------- TYRE ----------------
    public class Tyree
    {
        public string Colour { get; set; }
        public int TyreTotalQty { get; set; }
        public int TyreTotalDDL { get; set; }
        public int TyreTotalSelling { get; set; }
        public int TyreTotalRecords { get; set; }

        public string TyreLocationCode { get; set; }
        public string TyrePartDescription { get; set; }

        public string TyreMonthYear { get; set; }
        public int TyreDay { get; set; }

        public string TyreServiceAdvisorName { get; set; }
        public string TyreChannel { get; set; }

        public int TyreNetRetailQty { get; set; }
        public int TyreNetRetailDDL { get; set; }
        public int TyreNetRetailSelling { get; set; }

        public string TyreMetric { get; set; }
        public int TyreValue { get; set; }

        public string TyreName { get; set; }
        public int TyreCount { get; set; }
        public int TyreDDL { get; set; }
        public int TyreSelling { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Type { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Branch { get; set; }
        public List<Tyree> TyreeList { get; set; }
        public List<Tyree> TyreemetricList { get; set; }
        public List<Tyree> TyreDDlList { get; set; }
    }

}


