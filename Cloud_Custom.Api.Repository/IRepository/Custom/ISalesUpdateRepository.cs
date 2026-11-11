using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public interface ISalesUpdateRepository
    {
        Task<SalesUpdate> GetList(UserBase user, int Month, int Status,int DealerCode);
        Task<SalesUpdate> GetEmployeeDetails(UserBase user, int Month, int Status,int Model);
        Task<ResponseEntity> EmployeeWiseUpdate(UserBase user, SalesUpdate model);
        Task<ResponseEntity> EmployeeWiseDelete(UserBase user, SalesUpdate model);
        Task<SalesUpdate> GetPlanAmount(UserBase user, string Type,int Model, int Code);
        Task<SalesUpdate> GetFinanceAmount(UserBase user, string Type,int Model, int Code);
        Task<SalesUpdate> GetInsuranceAmount(UserBase user, string Type,int Model, int Code);
    }
}
