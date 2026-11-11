using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IServiceAchivementAdjustmentRepository
    {

        Task<ServiceAchivementAdjustment> GetList(UserBase user, int Month, int IncentiveGroup, int BranchCode, int Parameter);

       
        
        public Task<ResponseEntity> SettingsSave(UserBase User, ServiceAchivementAdjustment model, int ParameterCode, int IncentiveGroupCode, int monthcode, int Employecode, decimal ActualValue);

       
    }
}
