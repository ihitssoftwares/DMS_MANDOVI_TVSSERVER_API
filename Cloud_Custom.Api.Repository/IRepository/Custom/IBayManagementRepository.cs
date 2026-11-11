using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IBayManagementRepository
    {
        Task<BayManagement> GetList(UserBase user,int WorkshopCode);
        Task<BayDetails> GetBayDetails(UserBase user, int JobCardCode, int customerCode, int WorkShopCode);
        Task<ResponseEntity> Save(UserBase user, BayManagement model);

    }
}
