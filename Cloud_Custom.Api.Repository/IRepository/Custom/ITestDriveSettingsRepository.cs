using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface ITestDriveSettingsRepository
    {
        Task<TestDriveSettings> GetList(UserBase user, int Branch, int Model);
        public Task<ResponseEntity> Save(UserBase user, string mode, TestDriveSettings input);
        public Task<TestDriveSettings> GetTestDriveSettingsDetails(UserBase User, int VehicleCode, string mode);
        public Task<ResponseEntity> DeleteTestDriveSettings(UserBase user, TestDriveSettings model);
    }
}
