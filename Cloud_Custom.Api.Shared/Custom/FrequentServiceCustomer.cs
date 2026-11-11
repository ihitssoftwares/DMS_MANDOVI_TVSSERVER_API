using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class FrequentServiceCustomer
    {

        public string Name { get; set; }
        public string RegistrationNo { get; set; }
        public string Address { get; set; }

        public int Phone { get; set; }
        public string Email { get; set; }
        public int TotalVisits { get; set; }

        public decimal TotalRevenue { get; set; }
        public DateTime LastVisit { get; set; }

        public List<FrequentServiceCustomer> List { get; set; }
        public UserBase User { get; set; }
        public Dropdown WorkShop { get; set; }
    }
}
