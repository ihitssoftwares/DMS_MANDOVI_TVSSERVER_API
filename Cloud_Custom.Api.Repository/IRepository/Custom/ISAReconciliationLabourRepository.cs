using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public  interface ISAReconciliationLabourRepository
    {
        Task<SAReconciliationLabour> GetList(UserBase user, int Month, int Region, int Branch, string ServiceAdvisor, bool IsAssigned);
        Task<SAReconciliationLabour> GetSADetails(UserBase user, int Month, int Region, int Branch, string JCNumber, string LabourDescription);
        Task<SAReconciliationLabour> GetJCdetails(UserBase user, string JCNO);
        Task<ResponseEntity> Save(UserBase user, SAReconciliationLabour model);
    }
}
