using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class MCarePlanSettings
    {
        public UserBase user { get; set; }
        public string Status { get; set; }
        public Dropdown Plan { get; set; }
        public Dropdown Model { get; set; }
        public Dropdown Segment { get; set; }
        public int Code { get; set; }
        public int SLno { get; set; }
        public int NoofServices { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Mode { get; set; }
        public string ModelName { get; set; }
        public string GroupName { get; set; }
        public int Percentage { get; set; }
        public string Amount { get; set; }
        public string ServiceName { get; set; }
        public int ServiceCode { get; set; }

        public int ModelCode { get; set; }
        public int DtCode { get; set; }
        public string Limit { get; set; }
        public string Desc { get; set; }
        public string PlanName { get; set; }
        public string ServiceDescription { get; set; }
        public string Details { get; set; }
        public bool IsApplicable { get; set; }
        public bool IsProvision { get; set; }
        public List<MCarePlanSettings> List { get; set; }
        public List<MCarePlanSettings> ServiceList { get; set; }
        public List<MCarePlanSettings> DescList { get; set; }
        public List<ModelItem> List1 { get; set; }
    }
    public class ModelItem
    {
        public int PaticularCode { get; set; }
        public bool IsApplicable { get; set; }
    }
}
