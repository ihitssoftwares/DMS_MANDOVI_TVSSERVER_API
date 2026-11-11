using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public  class VehicleOrderStatus
    {
        public int SlNo { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string CustomerName { get; set; }
        public string ModelName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Model { get; set; }
        public string Varient { get; set; }
        public string OrderDate { get; set; }
        public string EngineNo { get; set; }
        public string Chasisno { get; set; }
        public bool Alloted { get; set; }
        public bool Invoicegeneration { get; set; }
        public int RegistrationCode { get; set; }
        public int OrdertrnCode { get; set; }
        public bool Registration { get; set; }
        public bool RegVerification { get; set; }
        public bool RegFinal { get; set; }
        public bool RTOProcessing { get; set; }
        public bool Delivery { get; set; }

        public List<VehicleOrderStatus> List { get; set; }
    }
}
