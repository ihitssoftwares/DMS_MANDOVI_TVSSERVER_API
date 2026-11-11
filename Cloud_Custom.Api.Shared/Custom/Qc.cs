using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class Qc
    {
        public int SalesVehicleCode { get; set; }
        public string DispatchDate { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string DcNo { get; set; }
        public string Modeldetails { get; set; }
        public string FuelType { get; set; }
        public string TransmissionType { get; set; }
        public string EnginNo { get; set; }
        public string ChassisNo { get; set; }
        public string Status { get; set; }

        public string VehVinNo { get; set; }
        public string BranchName { get; set; }
        public Decimal BasicValue { get; set; }
        public Decimal DiscountSpot { get; set; }
        public Decimal DRF { get; set; }
        public Decimal AssessableValue { get; set; }
        public Decimal IGST { get; set; }
        public Decimal Cess { get; set; }
        public Decimal Amount { get; set; }
        public Decimal TCS { get; set; }

        public int active { get; set; }
        public int totalRecords { get; set; }


        public List<Qc> QcList { get; set; }
        public QcItem QcItem { get; set; }
        public QcDoc QcDoc { get; set; }
        public List<QcDoc> QcDocItemList { get; set; }
    }
    public class QcItem
    {
        public int SalesVehicleCode { get; set; }
        public string DispatchDate { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string DcNo { get; set; }
        public string Modeldetails { get; set; }
        public string FuelType { get; set; }
        public string TransmissionType { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }
        public string Status { get; set; }
        public string QcStatus { get; set; }
        public Decimal Amount { get; set; }
        public Dropdown WareHouse { get; set; }
        public List<QcItem> QcItemList { get; set; }
    }

    public class QcDoc
    {
        public string AbsoluteUrl { get; set; }
        public string ActualFileName { get; set; }
        public File File { get; set; }

        public List<QcDoc> QcDocItemList { get; set; }
    }
}


