using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class EmployeePerCar
    {
        public int Employeecode { get; set; }
        public string EmployeeName { get; set; }
        public string Store { get; set; }
        public string Designation { get; set; }
        public int? GrossPay { get; set; }
        public int? IncentiveAmount { get; set; }
        public int? TotalCost { get; set; }
        public int? NumberOfCarsSold { get; set; }
        public int? CostPerCar { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Dropdown Month { get; set; }

        public List<EmployeePerCar> EmployeePerCarList { get; set; }


    }
}
