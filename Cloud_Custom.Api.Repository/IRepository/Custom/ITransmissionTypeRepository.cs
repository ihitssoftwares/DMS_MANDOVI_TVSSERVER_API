using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
     public interface ITransmissionTypeRepository
    {
        Task<TransmissionType> GetList(UserBase user, string TabIndex);
        Task<ResponseEntity> Save(UserBase user, string mode, TransmissionType model);
        public Task<TransmissionType> GetDetails(UserBase User, int TypeCode, string mode, string Type);
        public Task<ResponseEntity> Delete(UserBase User, TransmissionType model);
    }
}
