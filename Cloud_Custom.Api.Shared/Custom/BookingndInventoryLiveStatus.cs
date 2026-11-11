using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public  class BookingndInventoryLiveStatus
    {
        public Dropdown Model { get; set; }
        public Dropdown Branch { get; set; }
        public int ModelCode { get; set; }
        public string ModelName { get; set; }
        public int VariantCode { get; set; }
        public string Variant { get; set; }
        public int ColourCode { get; set; }
        public string Colour { get; set; }
        public int FuelCode { get; set; }
        public string FuelType { get; set; }      
        public int PendingBokking { get; set; }
        public int Instock { get; set; }
        public int Intransit { get; set; }
        public int TotalStock { get; set; }
        public int Allotted { get; set; }
        public int FreeStock { get; set; }
        public List<BookingndInventoryLiveStatus> BookingList { get; set; }
        public BookPopup BookPopup { get; set; }
    }
    public class BookPopup
    {
        public int BookCode { get; set; }
        public string BookNo { get; set; }
        public int Aging { get; set; }
        public string customerName { get; set; }
        public string DseName { get; set; }
        public List<BookPopup> BookingPopupList { get; set; }

    }
}
