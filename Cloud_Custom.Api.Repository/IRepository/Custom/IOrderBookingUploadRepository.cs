using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
  public  interface IOrderBookingUploadRepository
    {
        public Task<ResponseEntity<List<BookingReportModel>>> OrderImportFromExcel(UserBase user, OrderBookingUpload model);
        Task<OrderBookingUpload> GetList(UserBase user, int Month);
    }
}
