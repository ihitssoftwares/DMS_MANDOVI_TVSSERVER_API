using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Custom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public interface ILateHourConfirmationRepository
    {
        Task<AttendanceWagesConfirmation> ConfirmationList_PROFANT(UserBase user, string TabIndex, int Month, Filter filter);
        Task<AttendanceWagesConfirmation> GetEmployeeAttnDetails_PROFANT(UserBase user, int Month, Guid EmployeeGI);
        Task<ResponseEntity> LessHourConfirmationSave_PROFANT(AttendanceWagesConfirmation Model);
        Task<DataSet> ConfirmationList_PROFANT_EXCEL(UserBase user, int Month, string Tab, Filter filter);
        public Task<ResponseEntity> Update_PROFANT(AttendanceWagesConfirmation model);
    }
}
