using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface ILeadVSPurchaseTimeLineRepository
    {

        Task<LeadVSPurchaseTimeLine> GetDetails(UserBase user, int Model, string LeadType);
    }
}
