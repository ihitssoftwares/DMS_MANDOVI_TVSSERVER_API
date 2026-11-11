using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public interface IOrderRegisterRepository
    {
        Task<OrderBooking> GetList(UserBase user,string DateFilterType,string FromDate,string ToDate,string Status);
        Task<OrderBooking> GetOrderBookingDetails(UserBase user, int OrderTrnCode, string OrderNo);
      
    }
}
