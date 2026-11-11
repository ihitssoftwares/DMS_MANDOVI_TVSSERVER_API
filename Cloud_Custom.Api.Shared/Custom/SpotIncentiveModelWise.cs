using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public class SpotIncentiveModelWise
    {
        public Dropdown Month { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Vehiclemodel { get; set; }
        public Dropdown Ageing { get; set; }
        public Dropdown Status { get; set; }
        public Dropdown Transmission { get; set; }
        public Dropdown FuelType { get; set; }
        public Dropdown Type { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int HDCode { get; set; }
        public decimal DSE { get; set; }
        public decimal TL { get; set; }
        public decimal SM { get; set; }
        public string EngineNo { get; set; }
        public string Code { get; set; }
        public string ChaseNo { get; set; }
        public string RegNo { get; set; }
        public string Name { get; set; }
        public int Model { get; set; }
        public int Variant { get; set; }
        public int Color { get; set; }
        //public string Transmission { get; set; }
        // public string FuelType { get; set; }
        public string ColorName { get; set; }
        public string ModelType { get; set; }
        public string ModelName { get; set; }
        public string VariantName { get; set; }
        public List<SpotIncentiveModelWise> SpotIncentiveModelWiseList { get; set; }
        public string VIN { get; set; }
        public string StockStatus { get; set; }
        public string AllotmentStatus { get; set; }
        public string QCStatus { get; set; }
        public int Stock_Age { get; set; }
        public string Stock_Ageing_Bucket { get; set; }
        public int TotalCount { get; set; }
        public int IncentiveStatus { get; set; }
        // public string Type { get; set; }
    }
}
