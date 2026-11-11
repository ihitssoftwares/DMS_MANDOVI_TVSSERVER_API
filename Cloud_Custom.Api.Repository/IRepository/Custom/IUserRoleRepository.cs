using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
     public interface IUserRoleRepository
    {
        public Task<UserRole> GetUserRoleList(UserBase user, string TabIndex);
        public Task<UserRole> GetUserRoleTabDetails(UserBase user, Guid UserRoleGI);
        public Task<UserRole> GetUserRoleDetails(UserBase user, Guid UserRoleGI, Guid LogGI, string Type);
        public Task<UserRole> GetApplicabilityDetails(UserBase user, Head input);
        public Task<ResponseEntity> UserRoleSave(UserRole input);
        public Task<ResponseEntity> TabApplicabilitySave(UserRole input);
        public Task<ResponseEntity> UserRoleDelete(UserBase user, Guid UserRoleGI);
        public Task<ResponseEntity> UserRoleApproveOrReject(UserRole model);
    }
}
