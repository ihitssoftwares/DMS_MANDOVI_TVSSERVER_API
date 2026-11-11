using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class TestDriveSettings
    {
        public UserBase User { get; set; }

        public Dropdown Branch { get; set; }
        public Dropdown ModelCar { get; set; }
        public Dropdown Variant { get; set; }

        public Dropdown FuelType { get; set; }
        public Dropdown Transmission { get; set; }
        public Dropdown Color { get; set; }
        public int VehicleCode { get; set; }
        public int BranchCode { get; set; }
        public string BranchName { get; set; }
        public string Name { get; set; }
        public string ModelName { get; set; }
        public string VariantName { get; set; }
        public string FuelTypeName { get; set; }
        public string TransmissionTypeName { get; set; }
        public string ColorName { get; set; }
        public string RegNo { get; set; }
        public string ChassisNo { get; set; }
        public string EngineNo { get; set; }
        public string YearOfManufacture { get; set; }
        public bool IsActive { get; set; }

        public string Mode { get; set; }

        public List<TestDriveSettings> List { get; set; }
    }
}
