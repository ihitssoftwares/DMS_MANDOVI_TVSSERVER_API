using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface ILoadDataUpdateRepository
    {
        Task<LoadDataUpdate> GetList(UserBase user, string TabIndex);

        Task<LoadDataUpdate> GetTabList(UserBase user, string TabIndex);

        public Task<ResponseEntity> SettingsSave(UserBase User, LoadDataUpdate model, int VechicleModel);

        public Task<ResponseEntity> SavePopup(UserBase User, int BranchCode, string Name, int EmployeeCode, string Tabindex,int Technicianemployee);
    }
}
