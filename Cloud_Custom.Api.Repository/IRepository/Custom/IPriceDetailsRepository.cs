using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
     public interface IPriceDetailsRepository
    {
        Task<PriceDetails> GetList(UserBase user, int Type, string Fromdate, string ToDate);
        public Task<PriceDetails> GetVarientDetails(UserBase User, int PriceId);
    }
}
