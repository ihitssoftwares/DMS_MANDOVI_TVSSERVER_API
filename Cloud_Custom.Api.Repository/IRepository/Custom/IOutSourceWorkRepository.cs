using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IOutSourceWorkRepository
    {
        Task<OutSourceWork> GetList(UserBase user,int Month, int Branch,int Region);
        Task<WorkPopup> GetJcDetails(UserBase user, string JobCardCode, int Branch);
        Task<ResponseEntity> Save(UserBase user, OutSourceWork model);
    }
}
