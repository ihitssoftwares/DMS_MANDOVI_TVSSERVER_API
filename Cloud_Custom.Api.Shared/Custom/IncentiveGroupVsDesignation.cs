using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class IncentiveGroupVsDesignation
    {
        public int SLno { get; set; }
        public int DesignationCode { get; set; }
        public string DesignationName { get; set; }
        public bool IsApplicable { get; set; }
        public Dropdown Incentive { get; set; }
        public int IncentiveCode { get; set; }
        public List<Parameter> ParameterList { get; set; }
        public List<IncentiveGroupVsDesignation> List { get; set; }
        public UserBase user { get; set; }
    }
    public class Parameter
    {
        public int ParameterCode { get; set; }
        public bool IsApplicable { get; set; }
    }
}
