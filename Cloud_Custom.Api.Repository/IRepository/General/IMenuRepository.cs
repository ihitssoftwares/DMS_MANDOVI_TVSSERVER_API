using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.General
{
  public interface IMenuRepository
    {
        public Task<MenuEntity> GetCustomMenu(UserBase user);
        public Task<MenuItem> GetMenuDetails(UserBase user, int MenuCode);
        public Task<MenuEntity> GetModuleList(UserBase user, string LoginFrom);
        public Task<MenuEntity> GetModuleVsMenuList(UserBase user, int ModuleCode);
    }
}
