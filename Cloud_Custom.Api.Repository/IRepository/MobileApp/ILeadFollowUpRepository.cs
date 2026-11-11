using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.MobileApp
{
   public interface ILeadFollowUpRepository
    {
        Task<ColdFollowUP> GetList(UserBase user,int TabIndex);
        Task<ColdFollowUP> GetEmployeePosition(UserBase user);
        Task<ColdFollowUP> GetMyTeamList(UserBase user, string Type);
    }
}


