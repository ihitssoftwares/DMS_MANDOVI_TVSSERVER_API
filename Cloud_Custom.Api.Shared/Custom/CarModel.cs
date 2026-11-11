using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Shared.Custom
{
   public  class CarModel
    {
        public UserBase User { get; set; }
        public int ModelCode { get; set; }
        public int SLno { get; set; }
        public string mode { get; set; }

        public string  Modelname { get; set; }
        public string TypeName { get; set; }
        public string TypeVsOthersName { get; set; }
        public string  ModelType { get; set; }
        public Dropdown  Type { get; set; }
        public Dropdown Segment { get; set; }
        public Dropdown TypeVsOthers { get; set; }

        public string? DMSCode { get; set; }
        public bool Active { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
        public List<CarModel> List { get; set; }
        public Dropdown DiscontinueModel { get; set; }
        public bool DiscontinuedModel { get; set; }
        public int DiscontinuedModelCode { get; set; }
        public int ModelGroupCode { get; set; }
        public string ModelGroupName { get; set; }
        public Dropdown ModelGroup { get; set; }
    }
}
