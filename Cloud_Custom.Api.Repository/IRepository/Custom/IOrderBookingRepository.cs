using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public interface IOrderBookingRepository
    {
        Task<LeadEnquiryUpdate> GetList(UserBase user, int Month);
        Task<OrderBooking> GetLeadEnquiryDetails(UserBase user, int EnqCode, string LeadNo);
        Task<ResponseEntity> OrderBooking(UserBase user, OrderBooking model);
        Task<OrderBooking> GetExShowroomPrice(UserBase user, int Model, int Variant, int Color, string FuelType, string Transmission, string OrderDate);
    }
}
