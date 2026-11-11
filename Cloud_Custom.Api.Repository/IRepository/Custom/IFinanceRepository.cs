using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IFinanceRepository
    {

        Task<Finance> GetList(UserBase user, string TabIndex);
        Task<ResponseEntity> Save(UserBase user, string mode, Finance model);
        public Task<Finance> GetFinanceDetails(UserBase User, int FinancierCode, string mode);
        public Task<ResponseEntity> FinanceDelete(UserBase User, Finance model);
    }
}
