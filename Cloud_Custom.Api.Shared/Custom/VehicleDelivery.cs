using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
     public class VehicleDelivery
    {
        public int SlNo { get; set; }
        public DateTime NextServicedate { get; set; }
        public DateTime Deliverydate { get; set; }
        public Dropdown Officer { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Model { get; set; }
        public string Varient { get; set; }
        public string ColorName { get; set; }
        public string VehicleNo { get; set; }
        public string TransmissionName { get; set; }
        public string FuelName { get; set; }
        public int CheckListCode { get; set; }
        public string EngineNo { get; set; }
        public string ChasisNo { get; set; }
        public int RegistrationCode { get; set; }
        public int OrdertrnCode { get; set; }
        public string Location { get; set; }
        public string CustomerFeedback { get; set; }
        public string DelivaryMode { get; set; }
        public string ChecklistName { get; set; }
        public int CustomerRating { get; set; }
        public bool IsAppplicable { get; set; }
        public List<VehicleDelivery> Checklist { get; set; }
        public List<VehicleDelivery> List { get; set; }
        public int MODELCODE { get; set; }
        public int VARIANTCODE { get; set; }
        public int COLORCODE { get; set; }
        public int TRANSMISSIONCODE { get; set; }
        public int FUELTYPECODE { get; set; }
 
    }
}
