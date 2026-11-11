using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Account
{
    public interface IUserRepository
    {
        //Task<DataSet> GetUserList_Excel(UserBase user, string TabIndex );
        public Task<User> GetUserList(UserBase user, string TabIndex );
        Task<User> GetUserDetails(UserBase userBase, Guid UserMasterGI, Guid logGI, string tabindex);
        public Task<User> GetApplicableMenus(UserBase user, int UserRoleCode);
        public Task<ResponseEntity> UserSave(User model);
       // public Task<ResponseEntity> UserApproveOrReject(User model);
        public Task<ResponseEntity> UserDelete(User model);
    }
}
