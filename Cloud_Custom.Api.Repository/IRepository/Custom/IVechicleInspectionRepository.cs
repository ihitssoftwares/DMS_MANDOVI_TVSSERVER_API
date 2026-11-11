using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IVechicleInspectionRepository
    {
        Task<VechicleInspection> GetList(UserBase user);

        Task<VechicleInspection> GetInspectionList(UserBase user, int HDcode);
    }
}

