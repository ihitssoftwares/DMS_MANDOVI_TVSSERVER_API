using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using System.Linq;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
  public   class WorkShopUploadRepository : IWorkShopUploadRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly HttpClient _httpClient;
        public WorkShopUploadRepository(ISqlConnectionProvider sql, HttpClient httpClient)
        {
            _sql = sql;
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromMinutes(10);
        }
        public async Task<WorkShopUpload> GetList(UserBase user, string PickedDate)
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
        private WorkShopUpload VehicleOrderStatusList(DataSet dataSet)
        {
            WorkShopUpload model = new WorkShopUpload();
            List<WorkShopUpload> list = new List<WorkShopUpload>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    WorkShopUpload item = new WorkShopUpload();

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
        public async Task<WorkShopUpload> GetEntryDateList(UserBase user, string PickedDate)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@PickedDate",PickedDate),



            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_ENTRY_DATE_WORKSHOPFILE_UPLOAD]", sqlparameters);
                return GetEntryDateList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private WorkShopUpload GetEntryDateList(DataSet dataSet)
        {
            WorkShopUpload model = new WorkShopUpload();
            List<WorkShopUpload> list = new List<WorkShopUpload>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    WorkShopUpload item = new WorkShopUpload();

                    item.PaticularCode = MakeSafe.ToSafeInt32(row["ParticularCode"]);
                    item.PaticularName = MakeSafe.ToSafeString(row["ParticularName"]);
                    item.ImportStatus = MakeSafe.ToSafeBool(row["ImportStatus"]);
                    item.Uploadstatus = MakeSafe.ToSafeBool(row["UploadStatus"]);
                    item.Noofrows = MakeSafe.ToSafeInt32(row["NoofRows"]);
                    item.EntrybyDate = MakeSafe.ToSafeString(row["EntryByDate"]);

                    list.Add(item);
                }
                model.EntryDateList = list;
            }

            return model;
        }     
        public async Task<WorkShopUpload> GetWorkShopList(UserBase user, string ParticularName, string Date)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
   
                 new SqlParameter("@ParticularTypeCode",ParticularName),
                 new SqlParameter("@Date",Date),



            };
                var ds = await _sql.GetDataSetAsync("DMS.SP_WORKSHOP_FILE_UPLOAD_WORKSHOP_LIST", sqlparameters);
                 return GetWorkShopList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private WorkShopUpload GetWorkShopList(DataSet dataSet)
        {
            WorkShopUpload model = new WorkShopUpload();
            List<Workshop> list = new List<Workshop>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Workshop item = new Workshop();

                    item.WorkshopCode = MakeSafe.ToSafeInt32(row["WorkshopCode"]);
                    item.WorkshopName = MakeSafe.ToSafeString(row["WorkshopName"]);
                    //item.ImportStatus = MakeSafe.ToSafeBool(row["ImportStatus"]);
                    //item.Uploadstatus = MakeSafe.ToSafeBool(row["UploadStatus"]);
                    item.Noofrows = MakeSafe.ToSafeInt32(row["RowCount"]);
                    //item.EntrybyDate = MakeSafe.ToSafeString(row["EntryByDate"]);

                    list.Add(item);
                }
                model.WorkshopList = list;
            }

            return model;
        }

                public async Task<WorkShopUpload> GetEntryWiseWorKshopList(UserBase user, string ParticularName, string Date)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
   
                 new SqlParameter("@ParticularTypeCode",ParticularName),
                 new SqlParameter("@Date",Date),



            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_ENTRY_DATE_WORKSHOP_FILE_UPLOAD_WORKSHOP_LIST]", sqlparameters);
                 return GetEntryWiseWorKshopList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private WorkShopUpload GetEntryWiseWorKshopList(DataSet dataSet)
        {
            WorkShopUpload model = new WorkShopUpload();
            List<Workshop> list = new List<Workshop>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Workshop item = new Workshop();

                    item.WorkshopCode = MakeSafe.ToSafeInt32(row["WorkshopCode"]);
                    item.WorkshopName = MakeSafe.ToSafeString(row["WorkshopName"]);
                    //item.ImportStatus = MakeSafe.ToSafeBool(row["ImportStatus"]);
                    //item.Uploadstatus = MakeSafe.ToSafeBool(row["UploadStatus"]);
                    item.Noofrows = MakeSafe.ToSafeInt32(row["RowCount"]);
                    //item.EntrybyDate = MakeSafe.ToSafeString(row["EntryByDate"]);

                    list.Add(item);
                }
                model.EntryDateWorkShopList = list;
            }

            return model;
        }


        public async Task<WorkShopUpload> OrderList(UserBase user, int FileCode)
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
        private WorkShopUpload OrderStatusList(DataSet dataSet)
        {
            WorkShopUpload model = new WorkShopUpload();
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



        public async Task<ResponseEntity<List<WorkShopUpload>>> ImportFromExcel(UserBase user, WorkShopUpload model)
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

            return new ResponseEntity<List<WorkShopUpload>>(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value), unmatchedDetails);
        }
        public List<WorkShopUpload> PopulateUnmatchedDetails(DataSet ds)
        {
            List<WorkShopUpload> list = new List<WorkShopUpload>();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new WorkShopUpload
                    {

                    };

                    list.Add(item);
                }
            }

            return list;
        }




        public async Task<WorkShopUpload> GetListByParticular(UserBase user, int WorkshopCode, int ParticularCode, string Date)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
            new SqlParameter("@CompanyGI", user.CompanyGuid),
            new SqlParameter("@UserGI", user.UserGuid),
            new SqlParameter("@WorkshopCode", WorkshopCode),
            new SqlParameter("@FILECODE", ParticularCode),
            new SqlParameter("@DATE", Date)
        };

                var ds = await _sql.GetDataSetAsync("[DMS].[SP_WORKSHOP_FILE_LIST]", sqlparameters);

                return PopulateGetListByParticular(ds, ParticularCode);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private WorkShopUpload PopulateGetListByParticular(DataSet ds, int fileCode)
        {
            WorkShopUpload model = new WorkShopUpload();

            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return model;

            var table = ds.Tables[0];

            switch (fileCode)
            {
                case 1: // LABOUR
                    model.LabourList = table.AsEnumerable().Select(row => new Labourr
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
                    model.Load = table.AsEnumerable().Select(row => new Loadd
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
                    model.MCPList = table.AsEnumerable().Select(row => new MCPP
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
                    model.MGAList = table.AsEnumerable().Select(row => new MGAA
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
                    model.PMSList = table.AsEnumerable().Select(row => new PMSS
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
                    model.PMSPartsList = table.AsEnumerable().Select(row => new PMSPartss
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
                    model.SPARESList = table.AsEnumerable().Select(row => new SPARESS
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
                    model.SYNTHETICOILList = table.AsEnumerable().Select(row => new SYNTHETICOILL
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
                    model.TrueValueList = table.AsEnumerable().Select(row => new TrueValuee
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
                    model.TyreList = table.AsEnumerable().Select(row => new TYRE
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
                    model.CCPList = table.AsEnumerable().Select(row => new CCPP
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
                    model.ExtendedWarrantyList = table.AsEnumerable().Select(row => new ExtendedWarrantyy
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
                    model.BatteryList = table.AsEnumerable().Select(row => new BATTERY
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
        
        public async Task<WorkShopUpload> EntryListperPopularList(UserBase user, int WorkshopCode, int ParticularCode, string Date)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
            new SqlParameter("@CompanyGI", user.CompanyGuid),
            new SqlParameter("@UserGI", user.UserGuid),
            new SqlParameter("@WorkshopCode", WorkshopCode),
            new SqlParameter("@FILECODE", ParticularCode),
            new SqlParameter("@DATE", Date)
        };

                var ds = await _sql.GetDataSetAsync("[DMS].[SP_ENTRY_DATE_WORKSHOP_FILE_LIST]", sqlparameters);

                return EntryListperPopularList(ds, ParticularCode);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private WorkShopUpload EntryListperPopularList(DataSet ds, int fileCode)
        {
            WorkShopUpload model = new WorkShopUpload();

            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return model;

            var table = ds.Tables[0];

            switch (fileCode)
            {
                case 1: // LABOUR
                    model.LabourList = table.AsEnumerable().Select(row => new Labourr
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
                    model.Load = table.AsEnumerable().Select(row => new Loadd
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
                    model.MCPList = table.AsEnumerable().Select(row => new MCPP
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
                    model.MGAList = table.AsEnumerable().Select(row => new MGAA
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
                    model.PMSList = table.AsEnumerable().Select(row => new PMSS
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
                    model.PMSPartsList = table.AsEnumerable().Select(row => new PMSPartss
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
                    model.SPARESList = table.AsEnumerable().Select(row => new SPARESS
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
                    model.SYNTHETICOILList = table.AsEnumerable().Select(row => new SYNTHETICOILL
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
                    model.TrueValueList = table.AsEnumerable().Select(row => new TrueValuee
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
                    model.TyreList = table.AsEnumerable().Select(row => new TYRE
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
                    model.CCPList = table.AsEnumerable().Select(row => new CCPP
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
                    model.ExtendedWarrantyList = table.AsEnumerable().Select(row => new ExtendedWarrantyy
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
                    model.BatteryList = table.AsEnumerable().Select(row => new BATTERY
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
