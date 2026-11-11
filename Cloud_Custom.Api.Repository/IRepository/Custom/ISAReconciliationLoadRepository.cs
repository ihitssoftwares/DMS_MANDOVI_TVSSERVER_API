using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface ISAReconciliationLoadRepository
    {
        Task<SAReconciliationLoad> GetList(UserBase user, int Month, int Region, int Branch, string ServiceAdvisor, bool IsAssigned);
        Task<SAReconciliationLoad> GetSADetails(UserBase user, int Month, int Region, int Branch, string ServiceAdvisor);
        Task<SAReconciliationLoad> GetJCdetails(UserBase user, string JCNO);
        Task<ResponseEntity> Save(UserBase user, SAReconciliationLoad model);
    }
}
