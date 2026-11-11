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
    public class LabourRepository : ILabourRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public LabourRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<LabourCls> GetList(UserBase user,int isAssigned)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@isAssigned",isAssigned),
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_LABOUR_LIST]", sqlparameters);
                return LabourList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private LabourCls LabourList(DataSet dataSet)
        {
            LabourCls model = new LabourCls();
            List<LabourCls> List = new List<LabourCls>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new LabourCls();
                    item.Type = new Dropdown();
                    item.Group = new Dropdown();

                    item.LabourCode = MakeSafe.ToSafeInt32(row["LabourCode"]);
                    item.Desc = MakeSafe.ToSafeString(row["Description"]);
                    item.Type.Code = MakeSafe.ToSafeInt32(row["LabourTypeCode"]);
                    item.Type.Name = MakeSafe.ToSafeString(row["LabourTypeName"]);
                    item.Group.Code = MakeSafe.ToSafeInt32(row["LabourGroupCode"]);
                    item.Group.Name = MakeSafe.ToSafeString(row["LabourGroupName"]);
                    item.BSLabour = MakeSafe.ToSafeBool(row["BodyShopLabour"]);
                    item.SLabour = MakeSafe.ToSafeBool(row["ServiceLabour"]);

                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }

        public async Task<LabourCls> GetPopupDetails(UserBase user, int LabourCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                  new SqlParameter("@LabourCode",LabourCode),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_LABOURPOPUP_LIST]", sqlparameters);
                return PopupDetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private LabourCls PopupDetails(DataSet dataSet)
        {
            LabourCls model = new LabourCls();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];

                
                model.Group = new Dropdown();
                model.Type = new Dropdown();

                model.LabourCode = MakeSafe.ToSafeInt32(row["LabourCode"]);
                model.Desc = MakeSafe.ToSafeString(row["Description"]);
                model.Type.Code = MakeSafe.ToSafeInt32(row["TypeCode"]);
                model.Type.Name = MakeSafe.ToSafeString(row["TypeName"]);
                model.Group.Code = MakeSafe.ToSafeInt32(row["GroupCode"]);
                model.Group.Name = MakeSafe.ToSafeString(row["GroupName"]);

                model.BSLabour = MakeSafe.ToSafeBool(row["BodyShopLabour"]);
                model.SLabour = MakeSafe.ToSafeBool(row["ServiceLabour"]);

            }

            return model;

        }

        public async Task<ResponseEntity> PopupSave(UserBase user, LabourCls model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_LABOURPOPUP_SAVE]", sqlParameters, CommandType.StoredProcedure);
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
