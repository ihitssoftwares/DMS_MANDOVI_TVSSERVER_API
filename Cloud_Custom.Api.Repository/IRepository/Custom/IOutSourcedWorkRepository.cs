using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IOutSourcedWorkRepository
    {
        Task<OutSourcedWork> GetList(UserBase user, string TabIndex);
        Task<ResponseEntity> Save(UserBase user, string mode, OutSourcedWork model);
        public Task<OutSourcedWork> GetOutSourcedWorkDetails(UserBase User, int Code, string mode, string Type);
    }
}
