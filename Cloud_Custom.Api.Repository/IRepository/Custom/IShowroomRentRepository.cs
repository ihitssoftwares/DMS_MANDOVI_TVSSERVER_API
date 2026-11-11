using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IShowroomRentRepository
    {
        Task<ShowroomRent> GetList(UserBase user,  int Region, int WorkhoporShowroom);
        Task<ResponseEntity> RentUpdate(UserBase user, ShowroomRent model);
    }
}
