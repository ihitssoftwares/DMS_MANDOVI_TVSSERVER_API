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
    public class AccessoriesItemRepository : IAccessoriesItemRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public AccessoriesItemRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<AccessoriesItem> GetList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Type",TabIndex)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_ACCESSORIES_LIST]", sqlparameters);
                return AccessoriesItemList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private AccessoriesItem AccessoriesItemList(DataSet dataSet)
        {

            AccessoriesItem model = new AccessoriesItem();
            List<AccessoriesItem> GetList = new List<AccessoriesItem>();
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
                    var item = new AccessoriesItem();



                    item.SlNo = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.ItemName = MakeSafe.ToSafeString(row["ItemName"]);
                    item.CategoryName = MakeSafe.ToSafeString(row["Name"]);
                    item.ModelName = MakeSafe.ToSafeString(row["ModeName"]);
                    item.Amount = MakeSafe.ToSafeDecimal(row["Amount"]);
                    item.PartNumber = MakeSafe.ToSafeString(row["SalesAccessoriesPartNumber"]);
                    item.ModelCode = MakeSafe.ToSafeInt32(row["ModelCode"]);
                    item.CategoryCode = MakeSafe.ToSafeInt32(row["SalesAccessoriesPartCategoryCode"]);
                    item.ItemCode = MakeSafe.ToSafeInt32(row["ItemCode"]);


                    GetList.Add(item);
                }
                model.List = GetList;
            }
            return model;

        }

        public async Task<ResponseEntity> Save(UserBase user, string mode, AccessoriesItem input)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_ACCESSORIES_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }




        public async Task<AccessoriesItem> GetAccessoriesDetails(UserBase User, int ItemCode, string mode, string Type)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@ItemCode",ItemCode),


            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_ACCESSORIES_DETAILS]", sqlParameters);
            return PopulateAccessoriesDetails(dataSet);
        }



        private AccessoriesItem PopulateAccessoriesDetails(DataSet dataSet)
        {
            AccessoriesItem model = new AccessoriesItem();


            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];

                model.ItemCode = MakeSafe.ToSafeInt32(row["ItemCode"]);


                model.ItemName = MakeSafe.ToSafeString(row["ItemName"]);


                model.PartNumber = MakeSafe.ToSafeString(row["SalesAccessoriesPartNumber"]);


                model.Amount = MakeSafe.ToSafeDecimal(row["Amount"]);


                model.Category = new Dropdown()
                {
                    Name = MakeSafe.ToSafeString(row["CategoryName"]),
                    Code = MakeSafe.ToSafeInt32(
                        row["SalesAccessoriesPartCategoryCode"])
                };


                model.Model = new Dropdown()
                {
                    Name = MakeSafe.ToSafeString(row["ModelName"]),
                    Code = MakeSafe.ToSafeInt32(row["ModelCode"])
                };
                model.ApplicableModel = MakeSafe.ToSafeInt32(row["ApplicableModel"]) == 0 && !row.IsNull("ModelCode");


                model.Active = MakeSafe.ToSafeBool(row["IsActive"]);


                
            }
            return model;



        }




        public async Task<ResponseEntity> DeleteAccessories(UserBase user, AccessoriesItem accessoriesItem)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(accessoriesItem)),

                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_ACCESSORIES_DELETE]", sqlParameters, CommandType.StoredProcedure);
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


