
using Newtonsoft.Json;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SAMPLE_API_PLUS.Helper
{
    public static  class UserHelper
    {
       
            public static UserBase GetUser(ClaimsPrincipal user)
            {
                var userData = JsonConvert.DeserializeObject<UserBase>(user.FindFirstValue(ClaimTypes.UserData));
                return userData;
            }
        }
    
}
