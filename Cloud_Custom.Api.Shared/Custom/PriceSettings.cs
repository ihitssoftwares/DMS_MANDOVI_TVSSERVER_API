using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class PriceSettings
    {
        public int SlNo { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Dropdown Model { get; set; }
        public Dropdown Variant { get; set; }
        public Dropdown Color { get; set; }
        public Dropdown FuelType { get; set; }
        public Dropdown TransmissionType { get; set; }
        public Dropdown Region { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public int VariantCode { get; set; }
        public string VarientName { get; set; }
        public int ColorCode { get; set; }
        public string ColorName { get; set; }
        public int TransmissionTypeCode { get; set; }
        public string TransmissionName { get; set; }
        public int FuelTypeCode { get; set; }
        public string Fuelname { get; set; }
        public int PriceId { get; set; }
        public string mode { get; set; }
        public decimal? OnShowPrice { get; set; }
        public decimal? Gst { get; set; }
        public decimal? TCS { get; set; }

        public int? WarrantyAmount { get; set; }

        public decimal? RoadTax { get; set; }
        public decimal? RegnExp { get; set; }
        public decimal? Insurance { get; set; }
        public decimal? Fastag { get; set; }

        public decimal? OnRoadPrice { get; set; }

        public decimal? EW { get; set; }
        public decimal? MSILRewards { get; set; }
        public decimal? BasicAccessories { get; set; }
        public decimal? SMP { get; set; }

        public decimal? TotalOnRoad { get; set; }


       


        public List<PriceSettings> VariantWiseList { get; set; }
    }
    
}
