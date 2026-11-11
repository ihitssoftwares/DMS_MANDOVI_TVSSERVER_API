using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IInsuranceCompanyRepository
    {

        Task<InsuranceCompany> GetList(UserBase user, string TabIndex);
        Task<ResponseEntity> Save(UserBase user, string mode, InsuranceCompany model);
        public Task<InsuranceCompany> GetInsuranceCompanyDetails(UserBase User, int InsComCode, string mode);
        public Task<ResponseEntity> InsuranceCompanyDelete(UserBase User, InsuranceCompany model);
    }
}
