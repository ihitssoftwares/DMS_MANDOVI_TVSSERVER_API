using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class DesignationVsParameter
    {
        public int SLno { get; set; }
        public int PaticularCode { get; set; }
        public string PaticularName { get; set; }
        public bool IsApplicable { get; set; }
        public Dropdown Designation { get; set; }
        public int DesignationCode { get; set; }
        public int regionCode { get; set; }
        public int ParameterTypeCode { get; set; }
        public string ParameterTypeName { get; set; }
        public List<ParameterItem> ParameterList { get; set; }
        public List<DesignationVsParameter> List { get; set; }
        public UserBase user { get; set; }
    }
    public class ParameterItem
    {
        public int PaticularCode { get; set; }
        public bool IsApplicable { get; set; }
    }
}
