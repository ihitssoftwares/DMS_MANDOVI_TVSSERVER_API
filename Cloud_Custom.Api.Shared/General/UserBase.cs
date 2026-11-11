using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.General
{
 public  class UserBase
    {
        public Guid UserGuid { get; set; }
        public Guid CompanyGuid { get; set; }
        public Guid GroupCompanyGI { get; set; }        
    }
}
