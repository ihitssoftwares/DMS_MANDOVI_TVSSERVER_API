using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
  public   interface ISalesPositionRepository
    {
        Task<SalesPosition> GetList(UserBase user, string TabIndex);
        Task<ResponseEntity> Save(UserBase user, string mode, SalesPosition model);
        public Task<SalesPosition> GetPositionDetails(UserBase User, int IncentiveCode, string mode, string Type);
        public Task<ResponseEntity> DeletePostion(UserBase user, SalesPosition model);
    }
}
