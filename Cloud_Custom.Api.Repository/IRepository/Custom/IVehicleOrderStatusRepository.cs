using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IVehicleOrderStatusRepository
    {
        Task<VehicleOrderStatus> GetList(UserBase user, string Fromdate, string ToDate);
        public Task<VehicleOrderStatus> Create(UserBase User, int RegistrationCode, int OrdertrnCode);
    }
}
