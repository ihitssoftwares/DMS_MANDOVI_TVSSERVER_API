using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface ICertificateRepository
    {
        Task<Certificate> GetList(UserBase user);
        Task<Certificate> GetCertificateDetails(UserBase user, int RegEntryCode);
        public Task<JObject> CertificateJSON(string RegGi, int RegCode);
    }

}

