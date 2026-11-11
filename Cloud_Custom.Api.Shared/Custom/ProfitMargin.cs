using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ProfitMargin
    {
        public string Name { get; set; }
        public int WarrantyPrice { get; set; }
        public int Commission { get; set; }
        public int Extendedwarantycode { get; set; }
        public decimal Amount { get; set; }
        public int Code { get; set; }
        public Dropdown VechicleModel { get; set; }
        public List<ProfitMargin> List { get; set; }
    }
}
