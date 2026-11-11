using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IMobileRepository
    {
        Task<Mobile> DashBoardDetails(UserBase user);
        Task<Mobile> SalesDetails(UserBase user, string FromDate, string ToDate);
        Task<Mobile> MobileSalesDetails(UserBase user, string FromDate, string ToDate, Guid EmployeeUserGI);
        Task<Mobile> GADetails(UserBase user, string FromDate, string ToDate);
        Task<Mobile> BookingDetails(UserBase user);
        Task<Mobile> LeadDetails(UserBase user,string Type);
        Task<Mobile> MobileLeadDetails(UserBase user, string Type, Guid EmployeeUserGI);
        Task<Mobile> MobileBookingDetails(UserBase user, Guid EmployeeUserGI);

        Task<Mobile> BrowseDetails(UserBase user);
        Task<Mobile> Offers(UserBase user,int TabCode);

    }
}
