

using Cloud_Custom.Api.Shared.Account;
using Cloud_Custom.Api.Shared.General;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Account
{
  public  interface IAccountRepository
    {
        Task<CustomSoftware> GetSoftwareLogo();
        Task<UserRoleDetails> GetLogOutUserRoleDetails(UserBase user, int UserRoleCode);
        public Task<ResponseEntity<string>> Authenticate(Login credentials);
        Task<List<Dropdown>> GetGroupCompanyDropDown(Login credentials);
        public Task<ResponseEntity<string>> Login(Login credentials);
        public Task<ResponseEntity> LogHistory(UserBase UserBase, string CompanyCode, string UserCode,bool LoginSuccess, string Software, string InOutStatus, string MacAddress);
        public Task<ResponseEntity<JObject>> Mobile_Authenticate(Login credentials);

    }
}
