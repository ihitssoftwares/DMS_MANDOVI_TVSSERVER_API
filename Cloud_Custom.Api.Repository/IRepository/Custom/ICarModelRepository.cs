using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Shared.Custom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface ICarModelRepository
    {
        Task<CarModel> GetList(UserBase user,string Type, string TabIndex,int DisModel,string ModelGrp);
        public Task<ResponseEntity> Save(UserBase user, string mode, CarModel input);
        public Task<CarModel> GetModelDetails(UserBase User, int ModelCode, string mode, string Type);
        public Task<ResponseEntity> DeleteModel(UserBase user,CarModel model);
    }
}
