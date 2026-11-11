using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Shared.Custom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
   public  class CarModelRepository : ICarModelRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public CarModelRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<CarModel> GetList(UserBase user, string Type, string TabIndex,int DisModel,string ModelGrp)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Type",Type),
                 new SqlParameter("@TabIndex", TabIndex),
                 new SqlParameter("@DisModel", DisModel),
                 new SqlParameter("@ModelGrp",ModelGrp)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_CarModel_LIST]", sqlparameters);
                return ModelList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private CarModel ModelList(DataSet dataSet)
        {
            CarModel model = new CarModel();
            List<CarModel> List = new List<CarModel>();
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    model.ActiveCount = MakeSafe.ToSafeInt32(row["ActiveCount"]);
                    model.InactiveCount = MakeSafe.ToSafeInt32(row["InactiveCount"]);


                }
            }
            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new CarModel();
                    item.TypeVsOthers = new Dropdown();
                    item.Segment = new Dropdown();
                    item.ModelGroup = new Dropdown();


                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.ModelCode = MakeSafe.ToSafeInt32(row["ModeCode"]);
                    item.Modelname = MakeSafe.ToSafeString(row["ModeName"]);
                    item.TypeVsOthers.Name = MakeSafe.ToSafeString(row["ModeType"]);
                    item.TypeVsOthers.Code = MakeSafe.ToSafeInt32(row["TypeCode"]);
                    item.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);
                    item.Segment.Code = MakeSafe.ToSafeInt32(row["SegmentCode"]);
                    item.Segment.Name = MakeSafe.ToSafeString(row["SegmentName"]);
                    item.DiscontinuedModelCode = MakeSafe.ToSafeInt32(row["DiscontinuedModelCode"]);
                    item.ModelGroup.Name = MakeSafe.ToSafeString(row["ModelGroup"]);
                    item.ModelGroup.Code = MakeSafe.ToSafeInt32(row["ModelGroupCode"]);


                    List.Add(item);
                }
                model.List = List;
            }
            if ((dataSet.Tables.Count > 2) && (dataSet.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                model.TypeVsOthers = new Dropdown();
                model.TypeVsOthers.Code = MakeSafe.ToSafeInt32(dataSet.Tables[2].Rows[0]["DropdownCode"]);
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, string mode, CarModel input)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(input)),
                 new SqlParameter("@Mode",mode),
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_MODEL_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        public async Task<CarModel> GetModelDetails(UserBase User, int ModelCode, string mode, string Type)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@ModelCode",ModelCode),
                new SqlParameter("@Type",Type),

            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_Model_DETAILS]", sqlParameters);
            return PopulateModelDetails(dataSet);

        }

        private CarModel PopulateModelDetails(DataSet dataSet)
        {
            CarModel model = new CarModel();
         
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];

                model.TypeVsOthers = new Dropdown
                {
                    Name = MakeSafe.ToSafeString(row["ModeType"]),
                    Code = MakeSafe.ToSafeInt32(row["TypeCode"])
                };
                model.Segment = new Dropdown
                {
                    Name = MakeSafe.ToSafeString(row["SegmentName"]),
                    Code = MakeSafe.ToSafeInt32(row["SegmentCode"])
                };
                model.ModelGroup = new Dropdown
                {
                    Name = MakeSafe.ToSafeString(row["ModelGroup"]),
                    Code = MakeSafe.ToSafeInt32(row["ModelGroupCode"])
                };
                model.Modelname = MakeSafe.ToSafeString(row["ModeName"]);
                model.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);
                model.Active = MakeSafe.ToSafeBool(row["IsActive"]);
                model.DiscontinuedModelCode =MakeSafe.ToSafeInt32(row["DiscontinuedModelCode"]);

                model.DiscontinuedModel =model.DiscontinuedModelCode == 1;
            }

            return model;
        }
        public async Task<ResponseEntity> DeleteModel(UserBase user,CarModel model)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_MODEL_DELETE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

    }
}


    
