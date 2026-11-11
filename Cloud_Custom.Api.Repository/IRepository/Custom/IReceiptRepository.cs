using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
  public   interface IReceiptRepository
    {
        Task<Receipt> GetList(UserBase user, string TabIndex);
      
        public Task<JObject> ReceiptJSON(string RegGi, int RegCode);
        Task<ResponseEntity> Save(UserBase user, Receipt model);
    }
}
