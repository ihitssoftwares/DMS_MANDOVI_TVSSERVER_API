using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   
        public class COLDCALLFILEDOWNLOAD
        {
            public File ImportFromExcel { get; set; }
            public string Message { get; set; }
            public Dropdown Month { get; set; }
            public List<ColdCallImportModel> ColdCallImportModel { get; set; }
        }


    public class ColdCallImportModel
    {
        public string EnqNo { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string SourceOfEnquiry { get; set; }
        public string Transmission { get; set; }
        public string FuelType { get; set; }

    }
}
