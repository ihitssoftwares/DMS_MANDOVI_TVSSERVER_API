using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IDataValidationAlertsRepository
    {
        Task<DataValidationAlerts> GetValidationList(UserBase user, int ModuleCode, string Severity);
        Task<DataValidationAlerts> GetAlertDetails(UserBase user, string Type,int Code);
    }
}
