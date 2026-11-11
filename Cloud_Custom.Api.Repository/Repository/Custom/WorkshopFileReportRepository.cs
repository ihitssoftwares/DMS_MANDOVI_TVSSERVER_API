using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
     public class WorkshopFileReportRepository  : IWorkshopFileReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public WorkshopFileReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<WorkshopFileReport> GetList(UserBase user, string Workshopcode, string FromDate, string ToDate)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@WorkShop",Workshopcode),
                 new SqlParameter("@From",FromDate),
                 new SqlParameter("@To",ToDate),



            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_WORKSHOP_FILE_REPORT_LIST]", sqlparameters);
                return PriceDetailsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private WorkshopFileReport PriceDetailsList(DataSet dataSet)
        {
            WorkshopFileReport model = new WorkshopFileReport();
            model.List = new List<WorkshopFileReport>();
            model.GrandList = new List<GrandTotall>();
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                model.Workshop = new Dropdown();

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new WorkshopFileReport();

                    item.SlNo = MakeSafe.ToSafeInt32(row["SLNO"]);

                    item.FilelabourCode = MakeSafe.ToSafeInt32(row["FileLabourCode"]);
                    item.FilelabourName = MakeSafe.ToSafeString(row["FileLabourName"]);
                    item.FileLoadCode = MakeSafe.ToSafeInt32(row["fileLoadCode"]);
                    item.FileLoadName = MakeSafe.ToSafeString(row["fileLoadName"]);
                    item.FileMCPCode = MakeSafe.ToSafeInt32(row["fileMCPCode"]);
                    item.FileMCPName = MakeSafe.ToSafeString(row["fileMCPName"]);
                    item.FileMGACode = MakeSafe.ToSafeInt32(row["fileMGACode"]);
                    item.FileMGAName = MakeSafe.ToSafeString(row["fileMGAName"]);
                    item.FilePMSCode = MakeSafe.ToSafeInt32(row["filePMS20Code"]);
                    item.FilePMSName = MakeSafe.ToSafeString(row["filePMS20Name"]);
                    item.FilePmsPartsCode = MakeSafe.ToSafeInt32(row["FilePmsPartsCode"]);
                    item.FilePmsPartsName = MakeSafe.ToSafeString(row["FilePmsPartsName"]);
                    item.FileSparesCode = MakeSafe.ToSafeInt32(row["FileSparesCode"]);
                    item.FileSparesName = MakeSafe.ToSafeString(row["FileSparesName"]);
                    item.FileSyntheticoilCode = MakeSafe.ToSafeInt32(row["FileSyntheticoilCode"]);
                    item.FileSyntheticoilName = MakeSafe.ToSafeString(row["FileSyntheticoilName"]);
                    item.FileTrueValueCode = MakeSafe.ToSafeInt32(row["FileTrueValueCode"]);
                    item.FileTrueValueName = MakeSafe.ToSafeString(row["FileTrueValueName"]);
                    item.FileTyreCode = MakeSafe.ToSafeInt32(row["FileTyreCode"]);
                    item.FileTyreName = MakeSafe.ToSafeString(row["FileTyreName"]);
                    item.FileBattteryCode = MakeSafe.ToSafeInt32(row["FileBatteryCode"]);
                    item.FileBattteryName = MakeSafe.ToSafeString(row["FileBatteryName"]);
                    item.FileCCPCode = MakeSafe.ToSafeInt32(row["FileCCPCode"]);
                    item.FileCCPName = MakeSafe.ToSafeString(row["FileCCPName"]);
                    item.FileEWCode = MakeSafe.ToSafeInt32(row["FileEWCode"]);
                    item.FileEWName = MakeSafe.ToSafeString(row["FileEWName"]);
                    item.Labour = MakeSafe.ToSafeDecimal(row["Labour"]);
                    item.Load = MakeSafe.ToSafeDecimal(row["Load"]);
                    item.MCP = MakeSafe.ToSafeDecimal(row["Mcp"]);
                    item.MGA = MakeSafe.ToSafeDecimal(row["Mga"]);
                    item.PMS = MakeSafe.ToSafeDecimal(row["Pms20"]);
                    item.PMSParts = MakeSafe.ToSafeDecimal(row["PmsParts"]);
                    item.Spares = MakeSafe.ToSafeDecimal(row["Spares"]);
                    item.SyntheticOil = MakeSafe.ToSafeDecimal(row["SyntheticOil"]);
                    item.TrueValue = MakeSafe.ToSafeDecimal(row["TrueValue"]);
                    item.Tyre = MakeSafe.ToSafeDecimal(row["TYRE"]);
                    item.CCP = MakeSafe.ToSafeDecimal(row["CCP"]);
                    item.ExtendedWarranty = MakeSafe.ToSafeDecimal(row["EW"]);
                    item.Battery = MakeSafe.ToSafeDecimal(row["Battery"]);
                    item.Total = MakeSafe.ToSafeDecimal(row["Total"]);
                    item.Billdate = MakeSafe.ToSafeDateTime(row["Date"]);
                    item.Total = MakeSafe.ToSafeDecimal(row["Total"]);
                    //model.ToDate = MakeSafe.ToSafeDateTime(row["ToDate"]);
                    //model.Workshop.Code = MakeSafe.ToSafeInt32(row["Workshop"]);

                   model.List.Add(item);
                }

              
            }

            // ✅ Table 1 → Grand Total
            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new GrandTotall
                    {
                        Name = MakeSafe.ToSafeString(row["Name"]),
                        LabourAmt = MakeSafe.ToSafeDecimal(row["LabourAmt"]),
                        LoadAmt = MakeSafe.ToSafeDecimal(row["LoadAmt"]),
                        McpAmt = MakeSafe.ToSafeDecimal(row["McpAmt"]),
                        MgaAmt = MakeSafe.ToSafeDecimal(row["MgaAmt"]),
                        Pms20Amt = MakeSafe.ToSafeDecimal(row["Pms20Amt"]),
                        PmsPARTS = MakeSafe.ToSafeDecimal(row["PmsPARTS"]),
                        SparesAmt = MakeSafe.ToSafeDecimal(row["SparesAmt"]),
                        SyntheticOilAmt = MakeSafe.ToSafeDecimal(row["SyntheticOilAmt"]),
                        TrueValueAmt = MakeSafe.ToSafeDecimal(row["TrueValueAmt"]),
                        TyreAmt = MakeSafe.ToSafeDecimal(row["TyreAmt"]),
                        CcpAmt = MakeSafe.ToSafeDecimal(row["CcpAmt"]),
                        EwAmt = MakeSafe.ToSafeDecimal(row["EwAmt"]),
                        BatteryAmt = MakeSafe.ToSafeDecimal(row["BatteryAmt"]),
                        Total = MakeSafe.ToSafeDecimal(row["Total"])
                    };

                    model.GrandList.Add(item);
                }
            }

            return model;
        }
        public async Task<WorkshopFileUpload> GetPopupList(UserBase user, int FileCode, string FromDate, string ToDate, string workShop)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
            new SqlParameter("@CompanyGI", user.CompanyGuid),
            new SqlParameter("@UserGI", user.UserGuid),
            new SqlParameter("@FileCode", FileCode),
            new SqlParameter("@From", FromDate),
            new SqlParameter("@To", ToDate),
            new SqlParameter("@workShop", workShop)
        };

                var ds = await _sql.GetDataSetAsync("[DMS].[SP_WORKSHOP_FILE_REPORT_DETAILS]", sqlparameters);

                return PopulateGetListByParticular(ds, FileCode);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private WorkshopFileUpload PopulateGetListByParticular(DataSet ds, int fileCode)
        {
            WorkshopFileUpload model = new WorkshopFileUpload();

            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return model;

            var table = ds.Tables[0];

            switch (fileCode)
            {
                case 1: // LABOUR
                    model.LabourList = table.AsEnumerable().Select(row => new Labour
                    {
                        DealerName = row["DealerName"]?.ToString(),
                        DealerCity = row["DealerCity"]?.ToString(),
                        Location = row["Location"]?.ToString(),
                        LabourCode = row["LabourCode"]?.ToString(),
                        LabourDesc = row["LabourDesc"]?.ToString(),
                        ServiceAdvisorOrTechnicianName = row["ServiceAdvisorTechnicianName"]?.ToString(),
                        JCNo = row["JCNum"]?.ToString(),
                        JCDate = row["JcDate"]?.ToString(),
                        CustomerName = row["CustomerName"]?.ToString(),
                        RegistrationNo = row["RegistrationNo"]?.ToString(),
                        Model = row["Model"]?.ToString(),
                        BillNo = row["BillNo"]?.ToString(),
                        BillDate = row["BillDate"]?.ToString(),
                        BillDesc = row["BillDesc"]?.ToString(),
                        BasicAmt = row["BasicAmt"]?.ToString(),
                        DiscountAmt = row["DiscountAmt"]?.ToString(),
                        ChargesAmt = row["ChargesAmt"]?.ToString(),
                        BillAmt = row["BillAmt"]?.ToString()
                    }).ToList();
                    break;

                case 2: // LOAD (UPDATED FULL)
                    model.Load = table.AsEnumerable().Select(row => new Load
                    {
                        DealerName = row["DealerName"]?.ToString(),
                        DealerCity = row["DealerCity"]?.ToString(),
                        Location = row["Location"]?.ToString(),
                        JobCardNo = row["JobCardNo"]?.ToString(),
                        JCDateTime = row["JCDateTime"]?.ToString(),
                        ServiceType = row["ServiceType"]?.ToString(),
                        RepeatRevisit = row["RepeatRevisit"]?.ToString(),
                        CustomerName = row["CustomerName"]?.ToString(),
                        Phone = row["Phone"]?.ToString(),
                        MobileNo = row["MobileNo"]?.ToString(),
                        CustomerCategory = row["CustomerCategory"]?.ToString(),
                        PSFStatus = row["PSFStatus"]?.ToString(),
                        RegistrationNo = row["RegistrationNo"]?.ToString(),
                        Chassis = row["ChassisNo"]?.ToString(),
                        EngineNum = row["EngineNo"]?.ToString(),
                        Color = row["Color"]?.ToString(),
                        Variant = row["Variant"]?.ToString(),
                        Model = row["Model"]?.ToString(),
                        MI_YN = row["MI_YN"]?.ToString(),
                        SaleDate = row["SaleDate"]?.ToString(),
                        Group = row["GroupName"]?.ToString(),
                        ServiceAdvisor = row["SA"]?.ToString(),
                        Technician = row["Technician"]?.ToString(),
                        CircularNo = row["CircularNo"]?.ToString(),
                        ServiceType2 = row["ServiceType2"]?.ToString(),
                        Mileage = row["Mileage"]?.ToString(),
                        EstLabAmt = row["EstLabAmt"]?.ToString(),
                        EstPartAmt = row["EstPartAmt"]?.ToString(),
                        PromisedDate = row["PromisedDate"]?.ToString(),
                        RevPromisedDate = row["RevPromisedDate"]?.ToString(),
                        ReadyDateTime = row["ReadyDateTime"]?.ToString(),
                        RevEstPartAmt = row["RevEstPartAmt"]?.ToString(),
                        RevEstLabAmt = row["RevEstLabAmt"]?.ToString(),
                        JCSource = row["JCSource"]?.ToString(),
                        AppSentDate = row["AppSentDate"]?.ToString(),
                        AppRejDate = row["AppRejDate"]?.ToString(),
                        ApprovalStatus = row["ApprovalStatus"]?.ToString(),
                        CustRemarks = row["CustRemarks"]?.ToString(),
                        DlrRemarks = row["DlrRemarks"]?.ToString(),
                        Status = row["Status"]?.ToString(),
                        BillNo = row["BillNo"]?.ToString(),
                        BillDate = row["BillDate"]?.ToString(),
                        LabourAmt = row["LabourAmt"]?.ToString(),
                        PartAmt = row["PartAmt"]?.ToString(),
                        PickupRequired = row["PickupRequired"]?.ToString(),
                        PickupDate = row["PickupDate"]?.ToString(),
                        PickupLocation = row["PickupLocation"]?.ToString(),
                        BillAmount = row["BillAmount"]?.ToString(),
                        Address1 = row["Address1"]?.ToString(),
                        Address2 = row["Address2"]?.ToString(),
                        Address3 = row["Address3"]?.ToString(),
                        City = row["City"]?.ToString(),
                        Pin = row["Pin"]?.ToString(),
                        DOB = row["DOB"]?.ToString(),
                        DOA = row["DOA"]?.ToString(),
                        Email = row["Email"]?.ToString(),
                        CheckInDate = row["CHKIN_DT"]?.ToString(),
                        CheckOutDate = row["CHKOUT_DT"]?.ToString()
                    }).ToList();
                    break;

                case 3: // MCP
                    model.MCPList = table.AsEnumerable().Select(row => new MCP
                    {
                        Location = row["Location"]?.ToString(),
                        MCPEnrollmentNo = row["MCPEnrollmentNo"]?.ToString(),
                        MCPInvoiceNo = row["MCPInvoiceNo"]?.ToString(),
                        MCPDate = row["MCPDate"]?.ToString(),
                        MCPStatus = row["MCPStatus"]?.ToString(),
                        CustomerName = row["CustomerName"]?.ToString(),
                        Mobile = row["Mobile"]?.ToString(),
                        Email = row["Email"]?.ToString(),
                        Model = row["Model"]?.ToString(),
                        Vin = row["Vin"]?.ToString(),
                        RegNum = row["RegNum"]?.ToString(),
                        PackageDesc = row["PackageDesc"]?.ToString(),
                        AmountCollected = row["AmountCollected"]?.ToString(),
                        BalanceAmount = row["BalanceAmount"]?.ToString()
                    }).ToList();
                    break;

                case 4: // MGA
                    model.MGAList = table.AsEnumerable().Select(row => new MGA
                    {
                        Region = row["Region"]?.ToString(),
                        DealerCode = row["DealerCode"]?.ToString(),
                        FORCode = row["FORCode"]?.ToString(),
                        OutletCode = row["OutletCode"]?.ToString(),
                        City = row["City"]?.ToString(),
                        Branch = row["Branch"]?.ToString(),
                        DealerName = row["DealerName"]?.ToString(),
                        ServiceAdvisor = row["ServiceAdvisor"]?.ToString(),
                        Consumption = row["Consumption"]?.ToString(),
                        Load = row["LoadValue"]?.ToString(),
                        MGALoad = row["MGALoad"]?.ToString(),
                        ACFilter = row["ACFilter"]?.ToString(),
                        Screenwash = row["Screenwash"]?.ToString(),
                        Perfumes = row["Perfumes"]?.ToString(),
                        Mats = row["Mats"]?.ToString(),
                        ACGas = row["ACGas"]?.ToString()
                    }).ToList();
                    break;
                case 5: // PMS20
                    model.PMSList = table.AsEnumerable().Select(row => new PMS
                    {
                        Region = row["Region"]?.ToString(),
                        Dealer = row["Dealer"]?.ToString(),
                        DealerCode = row["DealerCode"]?.ToString(),
                        Outlet = row["Outlet"]?.ToString(),
                        DealerCity = row["DealerCity"]?.ToString(),
                        Location = row["Location"]?.ToString(),
                        JCNo = row["JCNo"]?.ToString(),
                        RegNo = row["RegNo"]?.ToString(),
                        VIN = row["VIN"]?.ToString(),
                        Model = row["Model"]?.ToString(),
                        Variant = row["Variant"]?.ToString(),
                        SaleDate = row["SaleDate"]?.ToString(),
                        Service = row["ServiceType"]?.ToString(),
                        Mileage = row["Mileage"]?.ToString(),
                        JCOpenDate = row["JCOpenDate"]?.ToString(),
                        JCCloseDate = row["JCCloseDate"]?.ToString(),
                        BillDate = row["BillDate"]?.ToString(),
                        PromisedDate = row["PromisedDate"]?.ToString(),
                        JCOpenedBy = row["JCOpenedBy"]?.ToString(),
                        JCOpenedByDesg = row["JCOpenedByDesg"]?.ToString(),
                        JCSource = row["JCSource"]?.ToString(),
                        JCLabourAmt = row["JCLabourAmt"]?.ToString(),
                        JCPartAmt = row["JCPartAmt"]?.ToString(),
                        JCBillAmt = row["JCBillAmt"]?.ToString(),
                        EWName = row["EWName"]?.ToString(),
                        EWConverted = row["EWConverted"]?.ToString(),
                        EWCancel = row["EWCancel"]?.ToString(),
                        EWActiveExpire = row["EWStatus"]?.ToString(),
                        MCPName = row["MCPName"]?.ToString(),
                        MCPActiveExpire = row["MCPStatus"]?.ToString(),
                        QRCode = row["QRCode"]?.ToString(),
                        ScanType = row["ScanType"]?.ToString(),
                        AudioCount = row["AudioCount"]?.ToString(),
                        ApprovalStatus = row["ApprovalStatus"]?.ToString(),
                        RFIDTag = row["RFIDTag"]?.ToString(),
                        FSCBarCode = row["FSCBarCode"]?.ToString(),
                        BSCValue = row["BSCValue"]?.ToString(),
                        SellingDealerRegion = row["SellingDealerRegion"]?.ToString(),
                        SellingParentGroup = row["SellingParentGroup"]?.ToString(),
                        SellingDealerCode = row["SellingDealerCode"]?.ToString(),
                        SellingDealerName = row["SellingDealerName"]?.ToString(),
                        PreviousDealerRegion = row["PreviousDealerRegion"]?.ToString(),
                        PreviousDealerName = row["PreviousDealerName"]?.ToString(),
                        PreviousDealerParentGroup = row["PreviousDealerParentGroup"]?.ToString(),
                        PreviousSubServiceType = row["PreviousSubServiceType"]?.ToString(),
                        PreviousServiceDealerCode = row["PreviousServiceDealerCode"]?.ToString(),
                        WashType = row["WashType"]?.ToString(),
                        TotalLabDiscount = row["TotalLabDiscount"]?.ToString(),
                        TotalPartDiscount = row["TotalPartDiscount"]?.ToString(),
                        PartAmountWithoutGST = row["PartAmtWithoutGST"]?.ToString(),
                        LabourAmountWithoutGST = row["LabourAmtWithoutGST"]?.ToString(),
                        BillAmountWithoutGST = row["BillAmtWithoutGST"]?.ToString(),
                        ServiceAdvisorMSPIN = row["ServiceAdvisorMSPIN"]?.ToString(),
                        OCASCount = row["OCASCount"]?.ToString(),
                        OCASSavedCount = row["OCASSavedCount"]?.ToString(),
                        OCASSentCount = row["OCASSentCount"]?.ToString(),
                        OpenToClose = row["OpenToClose"]?.ToString(),
                        CloseToBill = row["CloseToBill"]?.ToString(),
                        OpenToBill = row["OpenToBill"]?.ToString(),
                        TimeOpenToClose = row["TimeOpenToClose"]?.ToString()
                    }).ToList();
                    break;
                case 6: // PMS PARTS
                    model.PMSPartsList = table.AsEnumerable().Select(row => new PMSParts
                    {
                        ParentGroup = row["ParentGroup"]?.ToString(),
                        LocationCode = row["LocationCode"]?.ToString(),
                        ServiceAdvisorName = row["ServiceAdvisorName"]?.ToString(),
                        MonthYear = row["MonthYear"]?.ToString(),
                        Day = row["Day"]?.ToString(),
                        VariantName = row["VariantName"]?.ToString(),
                        VariantCode = row["VariantCode"]?.ToString(),
                        RequiredPartGroupDescription = row["RequiredPartGroupDesc"]?.ToString(),
                        BaseModelName = row["BaseModelName"]?.ToString(),
                        BaseModel = row["BaseModel"]?.ToString(),
                        PMSRequired = row["PMSRequired"]?.ToString(),
                        PMSChanged = row["PMSChanged"]?.ToString(),
                        PMSPercentage = row["PMSPercent"]?.ToString()
                    }).ToList();
                    break;
                case 7: // SPARES
                    model.SPARESList = table.AsEnumerable().Select(row => new SPARES
                    {
                        SrlNo = row["SrlNo"]?.ToString(),
                        DealerName = row["DealerName"]?.ToString(),
                        DealerCity = row["DealerCity"]?.ToString(),
                        Location = row["Location"]?.ToString(),
                        GroupBy = row["GroupBy"]?.ToString(),
                        BillNo = row["BillNo"]?.ToString(),
                        MCPNo = row["MCPNo"]?.ToString(),
                        InsClaimNumber = row["InsClaimNumber"]?.ToString(),
                        InsClaimDate = row["InsClaimDate"]?.ToString(),
                        BillDate = row["BillDate"]?.ToString(),
                        JobCardNo = row["JobCardNo"]?.ToString(),
                        ServiceType = row["ServiceType"]?.ToString(),
                        RegistrationNo = row["RegistrationNo"]?.ToString(),
                        CustomerID = row["CustomerID"]?.ToString(),
                        PartyName = row["PartyName"]?.ToString(),
                        GSTNum = row["GSTNum"]?.ToString(),
                        PlaceOfSupply = row["PlaceOfSupply"]?.ToString(),
                        PartsBasicAmount = row["PartsBasicAmount"]?.ToString(),
                        PartsDiscount = row["PartsDiscount"]?.ToString(),
                        PartsCharges = row["PartsCharges"]?.ToString(),
                        LabourBasicAmt = row["LabourBasicAmt"]?.ToString(),
                        LabourDiscount = row["LabourDiscount"]?.ToString(),
                        LabourCharges = row["LabourCharges"]?.ToString(),
                        RoundOffAmt = row["RoundOffAmt"]?.ToString(),
                        BillAmt = row["BillAmt"]?.ToString(),
                        Salvage = row["Salvage"]?.ToString(),
                        Deductible = row["Deductible"]?.ToString()
                    }).ToList();
                    break;
                case 8: // SYNTHETIC OIL
                    model.SYNTHETICOILList = table.AsEnumerable().Select(row => new SYNTHETICOIL
                    {
                        Region = row["Region"]?.ToString(),
                        DealerCity = row["DealerCity"]?.ToString(),
                        LocationCode = row["LocationCode"]?.ToString(),
                        LocationDescription = row["LocationDescription"]?.ToString(),
                        PartNum = row["PartNum"]?.ToString(),
                        MonthYear = row["MonthYear"]?.ToString(),
                        Day = row["Day"]?.ToString(),
                        ModelName = row["ModelName"]?.ToString(),
                        JobCardNum = row["JobCardNum"]?.ToString(),
                        ServiceAdvisorName = row["ServiceAdvisorName"]?.ToString(),
                        NetRetailQty = row["NetRetailQty"]?.ToString(),
                        ServiceLoad = row["ServiceLoad"]?.ToString()
                    }).ToList();
                    break;
                case 9: // TRUE VALUE
                    model.TrueValueList = table.AsEnumerable().Select(row => new TrueValue
                    {
                        DealerCity = row["DealerCity"]?.ToString(),
                        Date = row["SaleDate"]?.ToString(),
                        BuyerType = row["BuyerType"]?.ToString(),
                        EnquiryStatus = row["EnquiryStatus"]?.ToString(),
                        EnquirySource = row["EnquirySource"]?.ToString(),
                        EnquiryMode = row["EnquiryMode"]?.ToString(),
                        CustomerName = row["CustomerName"]?.ToString(),
                        CustomerCity = row["CustomerCity"]?.ToString(),
                        CustomerState = row["CustomerState"]?.ToString(),
                        PIN = row["PIN"]?.ToString(),
                        SalesExecutiveName = row["SalesExecutiveName"]?.ToString(),
                        VehicleRegistrationNo = row["VehicleRegistrationNo"]?.ToString(),
                        Manufacturer = row["Manufacturer"]?.ToString(),
                        Model = row["Model"]?.ToString(),
                        ModelCode = row["ModelCode"]?.ToString(),
                        SubModel = row["SubModel"]?.ToString(),
                        FuelType = row["FuelType"]?.ToString(),
                        VehicleBuyCategory = row["VehicleBuyCategory"]?.ToString(),
                        VehicleSoldCategory = row["VehicleSoldCategory"]?.ToString(),
                        VehicleCategory = row["VehicleCategory"]?.ToString(),
                        YOM = row["YOM"]?.ToString(),
                        AgeOfOldCar = row["AgeOfOldCar"]?.ToString(),
                        SaleType = row["SaleType"]?.ToString(),
                        BookingToSale = row["BookingToSale"]?.ToString(),
                        Enquiry = row["Enquiry"]?.ToString(),
                        NetBooking = row["NetBooking"]?.ToString(),
                        GrossBooking = row["GrossBooking"]?.ToString(),
                        BookingCancelled = row["BookingCancelled"]?.ToString(),
                        NetSale = row["NetSale"]?.ToString(),
                        GrossSale = row["GrossSale"]?.ToString(),
                        EnquiryLost = row["EnquiryLost"]?.ToString(),
                        NetworkStock = row["NetworkStock"]?.ToString(),
                        BuyingPrice = row["BuyingPrice"]?.ToString(),
                        SellingPrice = row["SellingPrice"]?.ToString(),
                        TotalActualRF = row["TotalActualRF"]?.ToString(),
                        ProfitMargin = row["ProfitMargin"]?.ToString(),
                        ReferenceSalesPrice = row["ReferenceSalesPrice"]?.ToString(),
                        WarrantyCharges = row["WarrantyCharges"]?.ToString(),
                        AdvanceAmountPaid = row["AdvanceAmountPaid"]?.ToString(),
                        PendingAmount = row["PendingAmount"]?.ToString()
                    }).ToList();
                    break;
                case 10: // TYRE
                    model.TyreList = table.AsEnumerable().Select(row => new Tyre
                    {
                        LocationCode = row["LocationCode"]?.ToString(),
                        PartDescription = row["PartDescription"]?.ToString(),
                        MonthYear = row["MonthYear"]?.ToString(),
                        Day = row["Day"]?.ToString(),
                        ServiceAdvisorName = row["ServiceAdvisorName"]?.ToString(),
                        Channel = row["Channel"]?.ToString(),
                        NetRetailQty = row["NetRetailQty"]?.ToString(),
                        NetRetailDDL = row["NetRetailDDL"]?.ToString(),
                        NetRetailSelling = row["NetRetailSelling"]?.ToString()
                    }).ToList();
                    break;

                case 11: // CCP
                    model.CCPList = table.AsEnumerable().Select(row => new CCP
                    {
                        Region = row["Region"]?.ToString(),
                        DealerCode = row["DealerCode"]?.ToString(),
                        DealerName = row["DealerName"]?.ToString(),
                        Location = row["Location"]?.ToString(),
                        PaymentLinkGeneratedDate = row["PaymentLinkGeneratedDate"]?.ToString(),
                        EWRPolicyNo = row["EWRPolicyNo"]?.ToString(),
                        EWRType = row["EWRType"]?.ToString(),
                        EWRValidity = row["EWRValidity"]?.ToString(),
                        CCPPolicyNum = row["CCPPolicyNum"]?.ToString(),
                        CCPSaleDate = row["CCPSaleDate"]?.ToString(),
                        SaleMonth = row["SaleMonth"]?.ToString(),
                        Vin = row["VIN"]?.ToString(),
                        VehInvDate = row["VehInvDate"]?.ToString(),
                        RegNum = row["RegNum"]?.ToString(),
                        ModelCd = row["ModelCd"]?.ToString(),
                        ModelDesc = row["ModelDesc"]?.ToString(),
                        VariantCd = row["VariantCd"]?.ToString(),
                        ModelVariant = row["ModelVariant"]?.ToString(),
                        CustName = row["CustName"]?.ToString(),
                        CustMobileNo = row["CustMobileNo"]?.ToString(),
                        OdometerReading = row["OdometerReading"]?.ToString(),
                        AddonCd = row["AddonCd"]?.ToString(),
                        CCPType = row["CCPType"]?.ToString(),
                        CCPStartDate = row["CCPStartDate"]?.ToString(),
                        CCPExpiryDate = row["CCPExpiryDate"]?.ToString(),
                        OldPolicyNo = row["OldPolicyNo"]?.ToString(),
                        OldPolicyDesc = row["OldPolicyDesc"]?.ToString(),
                        CCPRenewalJCNo = row["CCPRenewalJCNo"]?.ToString(),
                        JCStatus = row["JCStatus"]?.ToString(),
                        ClaimTaken = row["ClaimTaken"]?.ToString(),
                        ClaimAmt = row["ClaimAmt"]?.ToString(),
                        BasicAmt = row["BasicAmt"]?.ToString(),
                        DiscountAmt = row["DiscountAmt"]?.ToString(),
                        CGSTAmt = row["CGSTAmt"]?.ToString(),
                        SGSTAmt = row["SGSTAmt"]?.ToString(),
                        IGSTAmt = row["IGSTAmt"]?.ToString(),
                        NetAmt = row["NetAmt"]?.ToString(),
                        Status = row["Status"]?.ToString(),
                        OnlineFlag = row["OnlineFlag"]?.ToString(),
                        FacilitationAmt = row["FacilitationAmt"]?.ToString(),
                        SoldFrom = row["SoldFrom"]?.ToString(),
                        PaymentType = row["PaymentType"]?.ToString(),
                        ConvenienceChargesDiscount = row["ConvenienceChargesDiscount"]?.ToString(),
                        InterestChargesDiscount = row["InterestChargesDiscount"]?.ToString(),
                        EMITenure = row["EMITenure"]?.ToString(),
                        BasicCostFromBank = row["BasicCostFromBank"]?.ToString(),
                        Difference = row["Difference"]?.ToString(),
                        AddonInvNum = row["AddonInvNum"]?.ToString(),
                        NewCCPSoldRoNum = row["NewCCPSoldRoNum"]?.ToString(),
                        Channel = row["Channel"]?.ToString()
                    }).ToList();
                    break;

                case 12: // EXTENDED WARRANTY
                    model.ExtendedWarrantyList = table.AsEnumerable().Select(row => new ExtendedWarranty
                    {
                        Branch = row["Branch"]?.ToString(),
                        PolicyNo = row["PolicyNo"]?.ToString(),
                        InvoiceNo = row["InvoiceNo"]?.ToString(),
                        PolicySaleDate = row["PolicySaleDate"]?.ToString(),
                        VIN = row["VIN"]?.ToString(),
                        VehicleSaleDate = row["VehicleSaleDate"]?.ToString(),
                        ModelCode = row["ModelCode"]?.ToString(),
                        ModelDesc = row["ModelDesc"]?.ToString(),
                        VariantCode = row["VariantCode"]?.ToString(),
                        VariantDesc = row["VariantDesc"]?.ToString(),
                        WarrantyType = row["WarrantyType"]?.ToString(),
                        CustomerName = row["CustomerName"]?.ToString(),
                        Mileage = row["Mileage"]?.ToString(),
                        ExpiryDate = row["ExpiryDate"]?.ToString(),
                        ExpiryMileage = row["ExpiryMileage"]?.ToString(),
                        ActualPremiumAmount = row["ActualPremiumAmount"]?.ToString(),
                        PremiumAmount = row["PremiumAmount"]?.ToString(),
                        DiscountAmount = row["DiscountAmount"]?.ToString(),
                        CGSTAmt = row["CGSTAmt"]?.ToString(),
                        SGSTAmt = row["SGSTAmt"]?.ToString(),
                        IGSTAmt = row["IGSTAmt"]?.ToString(),
                        CommissionAmount = row["CommissionAmount"]?.ToString(),
                        CGSTCommission = row["CGSTCommission"]?.ToString(),
                        SGSTCommission = row["SGSTCommission"]?.ToString(),
                        IGSTCommission = row["IGSTCommission"]?.ToString(),
                        SoldBy = row["SoldBy"]?.ToString(),
                        Status = row["Status"]?.ToString(),
                        ServiceAdvisorDSE = row["ServiceAdvisorDSE"]?.ToString(),
                        ServiceAdvisorDSEName = row["ServiceAdvisorDSEName"]?.ToString(),
                        Channel = row["Channel"]?.ToString()
                    }).ToList();
                    break;

                case 13: // BATTERY
                    model.BatteryList = table.AsEnumerable().Select(row => new Battery
                    {
                        LocationCode = row["LocationCode"]?.ToString(),
                        PartDescription = row["PartDescription"]?.ToString(),
                        MonthYear = row["MonthYear"]?.ToString(),
                        Day = row["Day"]?.ToString(),
                        ServiceAdvisorName = row["ServiceAdvisorName"]?.ToString(),
                        Channel = row["Channel"]?.ToString(),
                        NetRetailQty = row["NetRetailQty"]?.ToString(),
                        NetRetailDDL = row["NetRetailDDL"]?.ToString(),
                        NetRetailSelling = row["NetRetailSelling"]?.ToString()
                    }).ToList();
                    break;
            }

            return model;
        }
    }
}
