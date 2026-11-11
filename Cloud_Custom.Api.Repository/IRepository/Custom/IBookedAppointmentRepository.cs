using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IBookedAppointmentRepository
    {
        Task<BookedAppointment> GetList(UserBase user, int AppoinmentStatus);
        Task<BookedAppointment> GetSearchList(UserBase user, string SearchCustomerName, string SearchCustomerRegisterNo, string SearchPhoneNo);

        Task<BookedAppointment> GetSearchDetails(UserBase user, string SearchCustomerName, string SearchCustomerRegisterNo, string SearchPhoneNo);
    }
}
