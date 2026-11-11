using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class Customer
    {
        public int CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string DMSCode { get; set; }
        public string mode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string ContactNo { get; set; }
        public string City { get; set; }
        public string MailId { get; set; }
        public string RegNo { get; set; }
        public string ModelName { get; set; }
        public string VehicleStatus { get; set; }
        public bool Sold { get; set; }
        public string VariantName { get; set; }
        public int active { get; set; }
        public int totalRecords { get; set; }


        public Dropdown CarModel { get; set; }
        public Dropdown Variant { get; set; }
        public List<Customer> List { get; set; }

        public File ImportFromExcel { get; set; }
        public string ChassisNo { get; set; }
        public string EngineNo { get; set; }
        public string VinNo { get; set; }
        public string FuelType { get; set; }
        public string Message { get; set; }
    }
}
