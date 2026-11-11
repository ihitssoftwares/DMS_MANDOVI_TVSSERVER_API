using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
     public class WorkshopFileUploadRepository : IWorkshopFileUploadRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly HttpClient _httpClient;
        public WorkshopFileUploadRepository(ISqlConnectionProvider sql, HttpClient httpClient)
        {
            _sql = sql;
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromMinutes(120);
        }
        public async Task<WorkshopFileUpload> GetList(UserBase user, string PickedDate)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@PickedDate",PickedDate),
               


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[WORKSHOPFILE_UPLOAD]", sqlparameters);
                return VehicleOrderStatusList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private WorkshopFileUpload VehicleOrderStatusList(DataSet dataSet)
        {
            WorkshopFileUpload model = new WorkshopFileUpload();
            List<WorkshopFileUpload> list = new List<WorkshopFileUpload>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    WorkshopFileUpload item = new WorkshopFileUpload();

                    item.PaticularCode = MakeSafe.ToSafeInt32(row["ParticularCode"]);
                    item.PaticularName = MakeSafe.ToSafeString(row["ParticularName"]);
                    item.ImportStatus = MakeSafe.ToSafeBool(row["ImportStatus"]);
                    item.Uploadstatus = MakeSafe.ToSafeBool(row["UploadStatus"]);
                    item.Noofrows = MakeSafe.ToSafeInt32(row["NoofRows"]);
                    item.EntrybyDate = MakeSafe.ToSafeString(row["EntryByDate"]);

                    list.Add(item);
                }
                model.List = list;
            }

            return model;
        }

           public async Task<WorkshopFileUpload> OrderList(UserBase user,int FileCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@FileCode",FileCode),
               


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_FILE_ORDER]", sqlparameters);
                return OrderStatusList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private WorkshopFileUpload OrderStatusList(DataSet dataSet)
        {
            WorkshopFileUpload model = new WorkshopFileUpload();
            List<FileColumnOrder> list = new List<FileColumnOrder>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    FileColumnOrder item = new FileColumnOrder();

                    item.Order = MakeSafe.ToSafeInt32(row["ORDER"]);
                    item.FileName = MakeSafe.ToSafeString(row["FILENAME"]);
                    

                    list.Add(item);
                }
                model.Columns = list;
            }

            return model;
        }



        public async Task<ResponseEntity<List<WorkshopFileUpload>>> ImportFromExcel(UserBase user, WorkshopFileUpload model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),

                     new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };


            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_WORKSHOP_FILE_DOWNLOAD_IMPORT_EXCEL]", sqlParameters);
            var unmatchedDetails = PopulateUnmatchedDetails(ds);

            return new ResponseEntity<List<WorkshopFileUpload>>(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value), unmatchedDetails);
        }
        public List<WorkshopFileUpload> PopulateUnmatchedDetails(DataSet ds)
        {
            List<WorkshopFileUpload> list = new List<WorkshopFileUpload>();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new WorkshopFileUpload
                    {
                       
                    };

                    list.Add(item);
                }
            }

            return list;
        }

        public async Task<WorkshopFileUpload> GetListByParticular(UserBase user, int PaticularCode, string Date)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
            new SqlParameter("@CompanyGI", user.CompanyGuid),
            new SqlParameter("@UserGI", user.UserGuid),
            new SqlParameter("@FILECODE", PaticularCode),
            new SqlParameter("@DATE", Date)
        };

                var ds = await _sql.GetDataSetAsync("[DMS].[SP_FILE_LIST]", sqlparameters);

                return PopulateGetListByParticular(ds, PaticularCode);
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

        /*==============================================================
          SMART UPLOAD
        ==============================================================*/
        public async Task<WorkshopFileUpload> SmartUpload(UserBase user, WorkshopFileUpload model)
        {
            try
            {
                /* =========================================
                STEP 1: GET CONFIG
                ========================================= */

                IDbDataParameter[] sqlParams =
                {
                    new SqlParameter("@PaticularCode", model.PaticularCode),
                    new SqlParameter("@PickedDate", model.PickedDate)
                };

                var ds = await _sql.GetDataSetAsync("[DMS].[SP_WORKSHOP_SMARTUPLOAD_GET_PATH_AND_COLUMNS]",sqlParams);

                if (ds == null || ds.Tables.Count < 2)
                {
                    return new WorkshopFileUpload
                    {
                        Status = "error",
                        Message = "Configuration not found."
                    };
                }

                /* =========================================
                   STEP 2: EXPECTED COLUMNS
                ========================================= */

                List<string> expectedColumns = new List<string>();

                if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
                {
                    string cols =
                        Convert.ToString(ds.Tables[0].Rows[0]["ColumnNames"]);

                    if (!string.IsNullOrWhiteSpace(cols))
                    {
                        expectedColumns = cols
                            .Split(',')
                            .Select(x => x.Trim())
                            .Where(x => !string.IsNullOrWhiteSpace(x))
                            .ToList();
                    }
                }

                /* =========================================
                   STEP 2.1: LEARNED COLUMN MAPPING
                ========================================= */

                var mappingDs = await _sql.GetDataSetAsync("[DMS].[SP_SMARTUPLOAD_GET_COLUMN_MAPPING]",
                    new IDbDataParameter[]
                    {
                        new SqlParameter("@ModuleCode", model.PaticularCode)
                    });

                Dictionary<string, string> learnedColumns = new Dictionary<string, string>();

                if (mappingDs.Tables.Count > 0)
                {
                    foreach (DataRow row in mappingDs.Tables[0].Rows)
                    {
                        string expected =row["ExpectedColumn"]?.ToString();
                        string learned = row["LearnedColumns"]?.ToString();

                        if (string.IsNullOrWhiteSpace(learned))
                            continue;

                        foreach (var col in learned.Split(','))
                        {
                            string cleanCol = col.Trim();

                            if (!string.IsNullOrWhiteSpace(cleanCol))
                            {
                                learnedColumns[cleanCol] = expected;
                            }
                        }
                    }
                }

                /* =========================================
                   STEP 2.2: MASTER LOCATIONS
                ========================================= */

                var locationDs = await _sql.GetDataSetAsync("[DMS].[SP_SMART_UPLOAD_GET_LOCATIONS]",
                    new IDbDataParameter[]
                    {
                        new SqlParameter("@ModuleCode", model.PaticularCode)
                    });

                Dictionary<string, string> locations =new Dictionary<string, string>();

                if (locationDs.Tables.Count > 0)
                {
                    foreach (DataRow row in locationDs.Tables[0].Rows)
                    {
                        string locationName = row["LocationName"]?.ToString();

                        string locationCode = row["LocationCode"]?.ToString();

                        if (!string.IsNullOrWhiteSpace(locationName))
                        {
                            locations[locationName.Trim()] =
                                locationCode;
                        }
                    }
                }

                /* =========================================
                   STEP 2.3: LEARNED LOCATION MAPPING
                ========================================= */

                var learnedLocationDs = await _sql.GetDataSetAsync("[DMS].[SP_SMARTUPLOAD_GET_LOCATION_MAPPING]",
                    new IDbDataParameter[]
                    {
                        new SqlParameter("@ModuleCode", model.PaticularCode)
                    });

                Dictionary<string, string> learnedLocations = new Dictionary<string, string>();

                if (learnedLocationDs.Tables.Count > 0)
                {
                    foreach (DataRow row in learnedLocationDs.Tables[0].Rows)
                    {
                        string invalidLocation =row["InvalidLocation"]?.ToString();
                        string actualLocation =row["ActualLocation"]?.ToString();

                        if (!string.IsNullOrWhiteSpace(invalidLocation))
                        {
                            learnedLocations[invalidLocation.Trim()] =
                                actualLocation;
                        }
                    }
                }

                /* =========================================
                   STEP 3: PATH
                ========================================= */

                string folderPath =Convert.ToString(ds.Tables[1].Rows[0]["FolderPath"]);
                string pickedDay =model.PickedDate.ToString("dd");
                string finalPath =folderPath.Replace("{DATE}", pickedDay);

                /* =========================================
                   STEP 4: PYTHON PAYLOAD
                ========================================= */

                var payload = new
                {
                    module_name = model.PaticularName,
                    module_code = model.PaticularCode,
                    picked_day = pickedDay,
                    picked_full_date =model.PickedDate.ToString("dd-MM-yyyy"),
                    folder_path = finalPath,
                    expected_columns = expectedColumns,
                    learned_columns = learnedColumns,
                    locations = locations,
                    actual_location = learnedLocations,
                    correct_dates =string.IsNullOrWhiteSpace(model.DateFixes)? new List<object>() : JsonConvert.DeserializeObject<object>(model.DateFixes),
                    ai_fix = true
                };

                string jsonPayload =JsonConvert.SerializeObject(payload);

                Console.WriteLine("SMART PAYLOAD:");
                Console.WriteLine(jsonPayload);

                var content = new StringContent(jsonPayload,Encoding.UTF8,"application/json");

                /* =========================================
                   STEP 5: CALL PYTHON API
                ========================================= */

                var response = await _httpClient.PostAsync("http://127.0.0.1:5050/api/extract",content);
                var responseContent =await response.Content.ReadAsStringAsync();

                Console.WriteLine("SMART RESPONSE:");
                Console.WriteLine(responseContent);

                if (!response.IsSuccessStatusCode)
                {
                    return new WorkshopFileUpload
                    {
                        Status = "error",
                        Message = responseContent
                    };
                }

                /* =========================================
                   STEP 6: DESERIALIZE
                ========================================= */

                var smartResponse = JsonConvert.DeserializeObject<SmartUploadResponse>(responseContent);

                if (smartResponse == null)
                {
                    return new WorkshopFileUpload
                    {
                        Status = "error",
                        Message = "Unable to deserialize response"
                    };
                }

                if (string.Equals(smartResponse.Status, "error",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return new WorkshopFileUpload
                    {
                        Status = "error",
                        Message = smartResponse.Message
                    };
                }

                /* =========================================
                   STEP 7 : CHECK VALIDATIONS
                ========================================= */

                var summary = smartResponse.Data?.ProcessingSummary;

                int invalidColumns =summary?.InvalidFilesWithUnidentifiedColumns ?? 0;
                int invalidLocations =summary?.InvalidLocationFilesCount ?? 0;
                int invalidDates =summary?.InvalidDateFilesCount ?? 0;

                /* =========================================
                   STEP 8 : SAVE TO DB ONLY IF EVERYTHING VALID
                ========================================= */

                if (invalidColumns == 0 && invalidLocations == 0 && invalidDates == 0 && model.IsFinalUpload)
                {
                    string extractedJson = JsonConvert.SerializeObject(smartResponse.Data.Data);
                    Console.WriteLine("========================================");
                    Console.WriteLine("PARTS DATA TYPE:");
                    Console.WriteLine(smartResponse.Data.Data?.GetType()?.FullName);

                    Console.WriteLine("PARTS EXTRACTED JSON:");
                    Console.WriteLine(extractedJson);

                    Console.WriteLine("========================================");
                    var fileRowCountsJson = JsonConvert.SerializeObject(
                        smartResponse.Data?.ProcessingSummary?.FileRowCounts ??
                        new List<SmartProcessingSummary.FileRowCount>()
                    );
                    SqlParameter ResponseKey =new SqlParameter{ParameterName = "@ResponseKey",SqlDbType = SqlDbType.VarChar,Size = 500,Direction = ParameterDirection.Output};
                    SqlParameter ResponseStatus =new SqlParameter{ParameterName = "@ResponseStatus",SqlDbType = SqlDbType.Bit,Direction = ParameterDirection.Output};

                    IDbDataParameter[] saveParams =
                    {
                        new SqlParameter("@PaticularCode",model.PaticularCode),
                        new SqlParameter("@PickedDate",model.PickedDate),
                        new SqlParameter("@JSONDATA",extractedJson),
                        new SqlParameter("@UserGuid",user.UserGuid),
                        new SqlParameter("@FileRowCounts", fileRowCountsJson),
                        ResponseKey,ResponseStatus
                    };

                    await _sql.ExecuteNonQueryAsync("[DMS].[SP_WORKSHOP_SMARTUPLOAD_SAVE]",saveParams,CommandType.StoredProcedure);

                    string responseMessage = Convert.ToString(ResponseKey.Value);

                    int insertedRows = 0;

                    if (!string.IsNullOrWhiteSpace(responseMessage))
                    {
                        var firstPart = responseMessage.Split(' ')[0];

                        int.TryParse(firstPart, out insertedRows);
                    }

                    return new WorkshopFileUpload
                    {
                        Status = "success",
                        Message = responseMessage,

                        ProcessingSummary = smartResponse.Data.ProcessingSummary,

                        // Python count
                        TotalRows = smartResponse.Data.Metadata?.TotalRecords ?? 0,

                        // SQL inserted count
                        InsertedRows = insertedRows
                    };
                }

                /* =========================================
                   STEP 9 : RETURN VALIDATION RESPONSE
                ========================================= */

                return new WorkshopFileUpload
                {
                    Status = smartResponse.Status,
                    Message = smartResponse.Message,
                    ProcessingSummary =smartResponse.Data?.ProcessingSummary,
                    TotalRows =smartResponse.Data.Metadata?.TotalRecords ?? 0
                };
            }
            catch (Exception ex)
            {
                return new WorkshopFileUpload
                {
                    Status = "error",
                    Message = ex.Message
                };
            }

        }

         /*==============================================================
                  SMART UPLOAD AUTO FIX
        ==============================================================*/
        public async Task<WorkshopFileUpload> SmartUploadAutoFix(UserBase user, WorkshopFileUpload model)
        {
            try
            {
                /* =========================================
                STEP 1: VALIDATION
                ========================================= */

            if (model == null)
                {
                    return new WorkshopFileUpload
                    {
                        Status = "error",
                        Message = "Model is null"
                    };
                }

                /* =========================================
                   COLUMN VALIDATION
                ========================================= */

                if (model.ValidationType == "column")
                {
                    if (model.InvalidColumns == null ||
                        model.InvalidColumns.Count == 0)
                    {
                        return new WorkshopFileUpload
                        {
                            Status = "error",
                            Message = "InvalidColumns is empty"
                        };
                    }
                }

                /* =========================================
                   LOCATION VALIDATION
                ========================================= */

                if (model.ValidationType == "location")
                {
                    if (model.InvalidLocations == null ||
                        model.InvalidLocations.Count == 0)
                    {
                        return new WorkshopFileUpload
                        {
                            Status = "error",
                            Message = "InvalidLocations is empty"
                        };
                    }
                }
                /* =========================================
                   DATE VALIDATION
                ========================================= */

                if (model.ValidationType == "date")
                {
                    if (model.InvalidDateColumns == null ||
                        model.InvalidDateColumns.Count == 0)
                    {
                        return new WorkshopFileUpload
                        {
                            Status = "error",
                            Message = "InvalidDateColumns is empty"
                        };
                    }
                }

                /* =========================================
                   STEP 2: CLEAN SUGGESTED COLUMNS
                ========================================= */

                if (model.SuggestedColumns != null)
                {
                    model.SuggestedColumns =model.SuggestedColumns.Select(x =>string.IsNullOrWhiteSpace(x)? "UNKNOWN": x).ToList();
                }

                /* =========================================
                   STEP 3: SAVE COLUMN LEARNING
                ========================================= */

                if (model.ValidationType == "column")
                {
                    for (int i = 0;
                         i < model.InvalidColumns.Count;
                         i++)
                    {
                        string invalid =model.InvalidColumns[i];
                        string expectedRaw = null;

                        if (model.SuggestedColumns != null &&
                            model.SuggestedColumns.Count > i)
                        {
                            expectedRaw =model.SuggestedColumns[i];
                        }

                        if (string.IsNullOrWhiteSpace(expectedRaw))
                        {
                            expectedRaw = "UNKNOWN";
                        }

                        string expected = expectedRaw;

                        if (!string.IsNullOrEmpty(expectedRaw) && expectedRaw.Contains("("))
                        {
                            expected = expectedRaw.Substring(0,expectedRaw.IndexOf("(")).Trim();
                        }

                        IDbDataParameter[] mapParams =
                        {
                            new SqlParameter("@ModuleCode",model.PaticularCode),
                            new SqlParameter("@InvalidColumn",invalid ?? ""),
                            new SqlParameter("@ExpectedColumn",expected ?? "")
                        };

                        await _sql.ExecuteNonQueryAsync("[DMS].[SP_SMARTUPLOAD_SAVE_COLUMN_MAPPING]",mapParams,CommandType.StoredProcedure);
                    }
                }

                /* =========================================
                   STEP 4: SAVE LOCATION LEARNING
                ========================================= */

                if (model.ValidationType == "location")
                {
                    for (int i = 0;
                         i < model.InvalidLocations.Count;
                         i++)
                    {
                        string invalidLocation = model.InvalidLocations[i];
                        string actualLocation = null;

                        if (model.SuggestedLocations != null &&
                            model.SuggestedLocations.Count > i)
                        {
                            actualLocation = model.SuggestedLocations[i];
                        }

                        if (string.IsNullOrWhiteSpace(actualLocation))
                        {
                            actualLocation = "UNKNOWN";
                        }

                        IDbDataParameter[] locationParams =
                        {
                            new SqlParameter("@ModuleCode",model.PaticularCode),
                            new SqlParameter("@InvalidLocation",invalidLocation ?? ""),
                            new SqlParameter("@ActualLocation",actualLocation ?? "")
                        };

                        await _sql.ExecuteNonQueryAsync("[DMS].[SP_SMARTUPLOAD_SAVE_LOCATION_MAPPING]",locationParams,CommandType.StoredProcedure);
                    }
                }

                /* =========================================
                   STEP 4.1 : DATE FIX
                ========================================= */

                if (model.ValidationType == "date")
                {
                    Console.WriteLine("DATE FIXES RECEIVED FROM UI:");
                    Console.WriteLine(model.DateFixes);

                    if (string.IsNullOrWhiteSpace(model.DateFixes))
                    {
                        return new WorkshopFileUpload
                        {
                            Status = "error",
                            Message = "DateFixes is empty"
                        };
                    }
                }

                /* =========================================
                   STEP 5: RE-RUN SMART UPLOAD
                ========================================= */

                return await SmartUpload(user, model);
            }
            catch (Exception ex)
            {
                return new WorkshopFileUpload
                {
                    Status = "error",
                    Message = ex.Message
                };
            }

        }
        public async Task<UploadFolderResponse> UploadFolder(UserBase user,IFormFileCollection files, string monthUpload)
        {
            using var content = new MultipartFormDataContent();

            foreach (var file in files)
            {
                var stream = file.OpenReadStream();
                var fileContent = new StreamContent(stream);
                content.Add(fileContent, "files", file.FileName);
            }
            content.Add( new StringContent(monthUpload),"MonthUpload");
            var response = await _httpClient.PostAsync("http://127.0.0.1:5050/filetransfer/api/upload-folder",content);
            string responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Python API Error ({response.StatusCode}) : {responseBody}");
            }
            return JsonConvert.DeserializeObject<UploadFolderResponse>(responseBody);
        }

        public async Task<int> GetServerFileCount(UserBase user, WorkshopFileUpload model)
        {
            IDbDataParameter[] sqlParams =
            {
                new SqlParameter("@PaticularCode", model.PaticularCode),
                new SqlParameter("@PickedDate", model.PickedDate)
            };

            var ds = await _sql.GetDataSetAsync("[DMS].[SP_WORKSHOP_SMARTUPLOAD_GET_PATH_AND_COLUMNS]", sqlParams);

            if (ds == null || ds.Tables.Count < 2 || ds.Tables[1].Rows.Count == 0)
                return 0;

            string folderPath = Convert.ToString(ds.Tables[1].Rows[0]["FolderPath"]);
            string pickedDay = model.PickedDate.ToString("dd");
            string finalPath = folderPath.Replace("{DATE}", pickedDay);

            if (!Directory.Exists(finalPath))
                return 0;

            return Directory.EnumerateFiles(finalPath).Count(f =>f.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".xls", StringComparison.OrdinalIgnoreCase));
        }
    }
}


