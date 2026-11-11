using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public  interface IStockAgeingSummaryRepository
    {
        Task<StockAgeingSummary> GetList(UserBase user, string Type, string Status, string Groupby,int Model,int Variant,int Color);
    }
}
