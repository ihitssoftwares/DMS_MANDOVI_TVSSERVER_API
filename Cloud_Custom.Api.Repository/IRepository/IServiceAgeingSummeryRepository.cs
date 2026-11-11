using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository
{
    public interface IServiceAgeingSummeryRepository
    {
        Task<ServiceAgeingSummery>GetList(UserBase user,int Age);

    }
}
