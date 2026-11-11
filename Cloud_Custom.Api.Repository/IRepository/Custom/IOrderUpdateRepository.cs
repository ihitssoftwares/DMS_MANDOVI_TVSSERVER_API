using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public interface IOrderUpdateRepository
    {
        Task<OrderBooking> GetList(UserBase user, int Month);
        Task<OrderBooking> GetOrderBookingDetails(UserBase user, int OrderTrnCode, string OrderNo);
        Task<ResponseEntity> OrderBookingUpdate(UserBase user, OrderBooking model);
        Task<ResponseEntity<Decimal>> GetRatePerItem(UserBase user, int ItemCode);
    }
}
