using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;

using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class InventoryDispatchUpdate
    {
        public File ImportFromExcel { get; set; }
        public string Message { get; set; }
        public List<SalesVehicleImport> SalesVehicleImport { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Dropdown BatchCode { get; set; }
        public List<SalesVehicleBatchSummary> SalesVehicleBatchSummary { get; set; }
    }

    public class SalesVehicleImport
    {
        public string DispatchDate { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string DCNo { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string Color { get; set; }
        public string TransmissionType { get; set; }
        public string FuelType { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }
        public string Remarks { get; set; }
        public string StockStatus { get; set; }
        public string AllotmentStatus { get; set; }
        public string WareHouseCode { get; set; }
        public string QCStatus { get; set; }
        public string Amount { get; set; }
        public string DealerRegionCode { get; set; }
        public string SalesDealerCode { get; set; }
        public string OutletType { get; set; }
        public string DealerName { get; set; }
        public string NewVehVIN { get; set; }
        public string ReceiptDate { get; set; }
        public string StockAge { get; set; }
        public string StockAgeingBucket { get; set; }
        public string NewCarVariant { get; set; }
        public string StockValue { get; set; }
        public string PhysicalLocType { get; set; }
        public string Location { get; set; }
        public string StockyardFromDate { get; set; }
        public string StockyardToDate { get; set; }
        public string ReserveFromDate { get; set; }
        public string ReserveToDate { get; set; }
        public string Stock { get; set; }
        public string ModelName { get; set; }
        public string VariantName { get; set; }
        public string ColourName { get; set; }
        public string Fuelname { get; set; }
        public string VariantCodeText { get; set; }
        public string ChassisPrefix { get; set; }
        public string BasicValue { get; set; }
        public string DiscountSpot { get; set; }
        public string DRF { get; set; }
        public string AssessableValue { get; set; }
        public string IGST { get; set; }
        public string Cess { get; set; }
        public string TCS { get; set; }
        public int? VariantCode { get; set; }
        public int? ModelCode { get; set; }
    }
    public class SalesVehicleBatchSummary
    {
        public string Batch { get; set; }
        public string Model { get; set; }
        public int TotalVehicles { get; set; }
        public DateTime? FirstDispatchDate { get; set; }
        public DateTime? LastDispatchDate { get; set; }
        public DateTime? FirstInvoiceDate { get; set; }
        public DateTime? LastInvoiceDate { get; set; }
        public int QCPassed { get; set; }
        public int Allotted { get; set; }
        public int InWarehouse { get; set; }
        public DateTime? EntryDate { get; set; }
        public string EntryBy { get; set; }
    }
}
