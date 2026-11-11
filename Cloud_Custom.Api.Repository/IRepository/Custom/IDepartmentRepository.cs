using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IDepartmentRepository
    {
        Task<Department> GetList(UserBase user, string TabIndex);
        public Task<ResponseEntity> Save(UserBase user, string mode, Department input);
        public Task<Department> GetDepartmentDetails(UserBase User, int DepartmentCode, string mode, string Type);
        public Task<ResponseEntity> DeleteDepartment(UserBase user, Department model);
    }
}
