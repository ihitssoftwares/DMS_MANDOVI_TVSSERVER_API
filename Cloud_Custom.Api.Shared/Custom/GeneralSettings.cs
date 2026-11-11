using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class GeneralSettings
    {



        //public string DespatchEntry { get; set; }
        //public string OrderBookingEntry { get; set; }
        //public string DeliveryCompletedChecking { get; set; }
        public Dropdown BasedOn { get; set; }

        public bool DespatchEntry { get; set; }
        public bool OrderBookingEntry { get; set; }
        public bool DeliveryCompletedChecking { get; set; }
        public bool EnableSalesUpdate { get; set; }


        //public List<GeneralSettings> List { get; set; }
    }
}
