using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
     public interface IDesignationVsParameterRepository
    {
        Task<DesignationVsParameter> GetList(UserBase user,  int DesignationCode, int regionCode);
        Task<ResponseEntity> Save(DesignationVsParameter Model);
    }
}
