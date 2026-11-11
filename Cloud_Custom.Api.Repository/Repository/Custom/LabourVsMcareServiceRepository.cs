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
    public class LabourVsMcareServiceRepository : ILabourVsMcareServiceRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public LabourVsMcareServiceRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<LabourVsMcareService> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 //new SqlParameter("@isAssigned",isAssigned),
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_LABOUR_VS_MCARE_LIST]", sqlparameters);
                return LabourvsmcareList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private LabourVsMcareService LabourvsmcareList(DataSet dataSet)
        {
            LabourVsMcareService model = new LabourVsMcareService();
            List<LabourVsMcareService> List = new List<LabourVsMcareService>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new LabourVsMcareService();
                    //item.Type = new Dropdown();
                    //item.Group = new Dropdown();

                    item.LabourCode = MakeSafe.ToSafeInt32(row["LabourCode"]);
                    item.ShortName = MakeSafe.ToSafeString(row["ShortName"]);
                   
                    item.Name = MakeSafe.ToSafeString(row["Name"]);
                    item.Service = new Dropdown
                    {
                        Code = MakeSafe.ToSafeInt32(row["ServiceCode"]),
                        Name = MakeSafe.ToSafeString(row["McareService"])
                    };


                    List.Add(item);

                   


                }
                model.List = List;
            }
            return model;

        }




        public async Task<ResponseEntity> PopupSave(UserBase user, LabourVsMcareService model)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                // new SqlParameter("@Mode",mode),
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_LABOUR_VS_MCARE_SAVE]", sqlParameters, CommandType.StoredProcedure);
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
