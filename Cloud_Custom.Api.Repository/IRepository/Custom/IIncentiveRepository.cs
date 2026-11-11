using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IIncentiveRepository
    {
        Task<Incentive> GetList(UserBase user, string TabIndex);
        Task<ResponseEntity> Save(UserBase user, string mode, Incentive model);
        public Task<Incentive> GetIncentiveDetails(UserBase User, int IncentiveCode, string mode, string Type);
        public Task<ResponseEntity> DeleteIncentive(UserBase user, Incentive model);

        Task<Incentive> GetDepartmentTypeCode(UserBase user, int DepartmentCode);
    }
}
