using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class VechicleInspection
    {
        public int HDcode { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string RegistrationNo { get; set; }
        public string ModelName { get; set; }
        public string FuelType { get; set; }
        public string ColourName { get; set; }
        public string KM { get; set; }
        public string VariantName { get; set; }
        public string ManufacturedYear { get; set; }
        public string TimeSlot { get; set; }
        public string BookingSource { get; set; }
        public string Customeraddress { get; set; }
        public string ManufacturerName { get; set; }
        public List<VechicleInspection> VechicleInspectionList { get; set; }
        public List<VechicleInspectionParameter> ParameterList { get; set; }
        

    }

    public class VechicleInspectionParameter
    {
        public int ParameterTypeCode { get; set; }
        public string ParameterTypeName { get; set; }
        public int ParameterCode { get; set; }
        public string ParameterName { get; set; }
    }
 }

