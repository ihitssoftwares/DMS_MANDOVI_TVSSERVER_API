using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
    public class ModelvsVariantRepository: IModelvsVariantRepository
    {

        private readonly ISqlConnectionProvider _sql;
        public ModelvsVariantRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<ModelvsVariant> GetList(UserBase user,int Modeldr)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Modeldr",Modeldr),





            };
            var ds = await _sql.GetDataSetAsync("DMS.SP_SAVE_MODEL_VS_VARIANT_LIST", sqlparameters);

            return PopulateGetList(ds);

        }
        public ModelvsVariant PopulateGetList(DataSet ds)
        {

            ModelvsVariant model = new ModelvsVariant();
            List<ModelvsVariant> List = new List<ModelvsVariant>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new ModelvsVariant();


                    item.modelname = MakeSafe.ToSafeString(row["Model"]);

                    item.variantname = MakeSafe.ToSafeString(row["Variant"]);

                    item.HDCode = MakeSafe.ToSafeInt32(row["HDCode"]);

                    item.Modelcode = MakeSafe.ToSafeInt32(row["Modelcode"]);

                    item.Variantcode = MakeSafe.ToSafeInt32(row["Variantcode"]);
                    item.ColorCode = MakeSafe.ToSafeInt32(row["ColorCode"]);
                    


                    List.Add(item);

                }

                model.ModelvsVariantList = List;
                return model;
            }
            return model;
        }
        public async Task<ModelvsVariant> GetPopUpDetails(UserBase user)//create
        {
            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),              
           

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[MODEL_VS_VARIANT_POPUP_DETAILS]", sqlparameters);

            return PopulateModelvsVariantPopUpDetails(ds);
        }
        private ModelvsVariant PopulateModelvsVariantPopUpDetails(DataSet ds)
        {

            ModelvsVariant model = new ModelvsVariant();
            List<ModelvsVariant> RequestList = new List<ModelvsVariant>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row1 in ds.Tables[0].Rows)
                {
                    ModelvsVariant List = new ModelvsVariant();
                    //List.Modelcode= MakeSafe.ToSafeInt32(row1["ModelCode"]);
                    //List.modelname = MakeSafe.ToSafeString(row1["ModeName"]);
                    //List.variantname= MakeSafe.ToSafeString(row1["VariantName"]);
                    //List.Variantcode= MakeSafe.ToSafeInt32(row1["VariantCode"]);
                    List.ColorName = MakeSafe.ToSafeString(row1["ColorName"]);
                    List.ColorCode = MakeSafe.ToSafeInt32(row1["ColorCode"]);


                 RequestList.Add(List);
                }
                model.ColorList = RequestList;
            }
            return model;
        }
        public async Task<ResponseEntity> Save(UserBase user, ModelvsVariant model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                     new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_SAVE_MODEL_VS_VARIANT]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
        public async Task<ModelvsVariant> Getdetails(UserBase user, int HDCode,int ColorCode)//edit
        {
            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
               
                new SqlParameter("@HDCode",HDCode),
                new SqlParameter("@ColorCode",ColorCode),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[MODEL_VS_VARIANT_POPUP_GETDETAILS]", sqlparameters);

            return PopulateModelvsVariantgetPopUpDetails(ds);
        }
        private ModelvsVariant PopulateModelvsVariantgetPopUpDetails(DataSet ds)
        {

            ModelvsVariant model = new ModelvsVariant();
      

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                model = new ModelvsVariant

                {

                   modelname= MakeSafe.ToSafeString(row["ModelName"]),
                   Modelcode = MakeSafe.ToSafeInt32(row["ModelCode"]),
                    variantname = MakeSafe.ToSafeString(row["VariantName"]),
                   Variantcode = MakeSafe.ToSafeInt32(row["VariantCode"]),
                    ColorName = MakeSafe.ToSafeString(row["ColorName"]),
                   ColorCode = MakeSafe.ToSafeInt32(row["ColorCode"]),
                    //Applicability = MakeSafe.ToSafeBool(row["Applicability"]),
                   


                  
                };
              

            }

            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {

                model.Attachment1 = new File();
                model.Attachment2 = new File();
                model.Attachment3 = new File();
                model.Attachment4 = new File();
                model.Attachment5 = new File();
                model.Attachment6 = new File();
                model.Attachment7 = new File();
                model.Attachment8 = new File();

                model.Attachment1.AbsoluteUri = MakeSafe.ToSafeString(ds.Tables[1].Rows[0]["AbsoluteUri1"]);
                model.Attachment1.FileName = MakeSafe.ToSafeString(ds.Tables[1].Rows[0]["FileName1"]);

                model.Attachment2.AbsoluteUri = MakeSafe.ToSafeString(ds.Tables[1].Rows[0]["AbsoluteUri2"]);
                model.Attachment2.FileName = MakeSafe.ToSafeString(ds.Tables[1].Rows[0]["FileName2"]);

                model.Attachment3.AbsoluteUri = MakeSafe.ToSafeString(ds.Tables[1].Rows[0]["AbsoluteUri3"]);
                model.Attachment3.FileName = MakeSafe.ToSafeString(ds.Tables[1].Rows[0]["FileName3"]);

                model.Attachment4.AbsoluteUri = MakeSafe.ToSafeString(ds.Tables[1].Rows[0]["AbsoluteUri4"]);
                model.Attachment4.FileName = MakeSafe.ToSafeString(ds.Tables[1].Rows[0]["FileName4"]);

                model.Attachment5.AbsoluteUri = MakeSafe.ToSafeString(ds.Tables[1].Rows[0]["AbsoluteUri5"]);
                model.Attachment5.FileName = MakeSafe.ToSafeString(ds.Tables[1].Rows[0]["FileName5"]);

                model.Attachment6.AbsoluteUri = MakeSafe.ToSafeString(ds.Tables[1].Rows[0]["AbsoluteUri6"]);
                model.Attachment6.FileName = MakeSafe.ToSafeString(ds.Tables[1].Rows[0]["FileName6"]);

                model.Attachment7.AbsoluteUri = MakeSafe.ToSafeString(ds.Tables[1].Rows[0]["AbsoluteUri7"]);
                model.Attachment7.FileName = MakeSafe.ToSafeString(ds.Tables[1].Rows[0]["FileName7"]);

                model.Attachment8.AbsoluteUri = MakeSafe.ToSafeString(ds.Tables[1].Rows[0]["AbsoluteUri8"]);
                model.Attachment8.FileName = MakeSafe.ToSafeString(ds.Tables[1].Rows[0]["FileName8"]);
            }
            if ((ds.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                model.ApplicabilityList = new List<ModelvsVariant>();
                foreach (DataRow row1 in ds.Tables[2].Rows)
                {
                    ModelvsVariant List = new ModelvsVariant();
                    List.ColorCode = MakeSafe.ToSafeInt32(row1["ColourCode"]);
                    List.ColorName = MakeSafe.ToSafeString(row1["ColourName"]);
                    List.Applicability = MakeSafe.ToSafeBool(row1["Applicability"]);
                    model.ApplicabilityList.Add(List);
                }
            }

             
                    return model;
        }
        public async Task<ResponseEntity> Edit(UserBase user, ModelvsVariant model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                     new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_EDIT_MODEL_VS_VARIANT]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
        public async Task<ResponseEntity> Delete(UserBase User, ModelvsVariant model)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),

                        ResponseKey,ResponseStatus
                };

                await _sql.ExecuteNonQueryAsync("[DMS].[SP_MODELvsVARIANT_DELETE]", sqlParameters, CommandType.StoredProcedure);
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
