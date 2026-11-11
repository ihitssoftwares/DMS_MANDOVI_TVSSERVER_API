using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
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
  public   class StoreOrBranchRepository : IStoreOrBranchRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public StoreOrBranchRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<StoreOrBranch> GetList(UserBase user,int Type,int Region, int Workshoponly)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 //new SqlParameter("@Dealer",Dealer),
                 // new SqlParameter("@State",State),
                   new SqlParameter("@Type",Type),
                  new SqlParameter("@Region",Region),
                   new SqlParameter("@Workshoponly",Workshoponly),
                   

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_STOREorBRANCH_LIST]", sqlparameters);
                return StoreOrBranchList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private StoreOrBranch StoreOrBranchList(DataSet dataSet)
        {
            StoreOrBranch model = new StoreOrBranch();
            List<StoreOrBranch> List = new List<StoreOrBranch>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new StoreOrBranch();
                    item.Dealer = new Dropdown();
                    item.State = new Dropdown();
                    item.Region = new Dropdown();
                    item.Type = new Dropdown();

                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]);
                    item.SalesDealerCode = MakeSafe.ToSafeString(row["SalesDealerCode"]);
                    item.Branchname = MakeSafe.ToSafeString(row["BranchName"]);
                    //item.Type.Code = MakeSafe.ToSafeInt32(row["TypeCode"]);
                    item.TypeName = MakeSafe.ToSafeString(row["StoreType"]);
                    //item.Dealer.Code = MakeSafe.ToSafeInt32(row["DealershipCode"]);
                    item.Dealername = MakeSafe.ToSafeString(row["DealershipName"]);
                    //item.State.Code = MakeSafe.ToSafeInt32(row["StateCode"]);
                    item.StateName = MakeSafe.ToSafeString(row["StateName"]);
                    //item.Region.Code = MakeSafe.ToSafeInt32(row["RegionCode"]);
                    item.RegionName = MakeSafe.ToSafeString(row["RegionName"]);
                    item.WorkShopOrBranch = MakeSafe.ToSafeString(row["WorkShopOrBranch"]);

                    item.Email = MakeSafe.ToSafeString(row["Email"]);
                    item.ContactNo = MakeSafe.ToSafeString(row["ContactNo"]);
                    item.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);

                    List.Add(item);
                }
                model.List = List;
            }

            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, string mode, StoreOrBranch input)
        {
            try
            {
                input.WorkShop = input.WorkShopActive ? 1 : 0;

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(input)),
                 new SqlParameter("@Mode",mode),
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_STORE_BRANCH_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        public async Task<StoreOrBranch> GetBranchDetails(UserBase User, int BranchCode, string mode)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@BranchCode",BranchCode),


            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_STORE_DETAILS]", sqlParameters);
            return PopulateStoreOrBranchDetails(dataSet);

        }

        private StoreOrBranch PopulateStoreOrBranchDetails(DataSet dataSet)
        {
            StoreOrBranch model = new StoreOrBranch();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];

                model.Dealer = new Dropdown();
                model.State = new Dropdown();
                model.Region = new Dropdown();
                model.Type = new Dropdown();

                model.BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]);
                model.ShortName = MakeSafe.ToSafeString(row["ShortName"]);
                model.Branchname = MakeSafe.ToSafeString(row["BranchName"]);
                model.Dealer.Code = MakeSafe.ToSafeInt32(row["BranchDelearshipCode"]);
                model.Dealer.Name = MakeSafe.ToSafeString(row["DealershipName"]);
                model.State.Code = MakeSafe.ToSafeInt32(row["StateCode"]);
                model.State.Name = MakeSafe.ToSafeString(row["StateName"]);
                model.Region.Code = MakeSafe.ToSafeInt32(row["RegionCode"]);
                model.Region.Name = MakeSafe.ToSafeString(row["RegionName"]);
                model.Type.Code = MakeSafe.ToSafeInt32(row["StoreCode"]);
                model.Type.Name = MakeSafe.ToSafeString(row["StoreName"]);
                model.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);
                model.WorkShopOrBranch = MakeSafe.ToSafeString(row["WorkShopOrBranch"]);
                model.WorkShop = MakeSafe.ToSafeInt32(row["WorkShop"]);
                model.WorkShopActive = MakeSafe.ToSafeBool(row["WorkShopActive"]);
                model.Pin = MakeSafe.ToSafeString(row["Pin"]);
                model.Latitude = MakeSafe.ToSafeString(row["Latitude"]);
                model.Longitude = MakeSafe.ToSafeString(row["Longitude"]);
                model.SalesDealerCode = MakeSafe.ToSafeString(row["SalesDealerCode"]);
                model.Address = MakeSafe.ToSafeString(row["Address"]);
                model.MDSActive = MakeSafe.ToSafeBool(row["MDSActive"]);
                model.TVActive = MakeSafe.ToSafeBool(row["TVActive"]);

            }

            return model;
        }
        public async Task<ResponseEntity> DeleteBranch(UserBase user, StoreOrBranch model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_BRANCH_DELETE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }



        public async Task<ResponseEntity> PopupSave(UserBase user, StoreOrBranch model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_BRANCHPOPUP_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        public async Task<StoreOrBranch> GetPopupList(UserBase user, int BranchCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                  new SqlParameter("@BranchCode",BranchCode),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_BRANCHPOPUP_LIST]", sqlparameters);
                return Popuplist(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private StoreOrBranch Popuplist(DataSet dataSet)
        {
            StoreOrBranch model = new StoreOrBranch();
            List<StoreOrBranch> PopupList = new List<StoreOrBranch>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new StoreOrBranch();




                    item.BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]);
                    item.DtCode = MakeSafe.ToSafeInt32(row["DtCode"]);


                    item.MatchingName = MakeSafe.ToSafeString(row["MatchingName"]);





                    PopupList.Add(item);
                }
                model.List = PopupList;
            }
            return model;

        }


        public async Task<ResponseEntity> DeletePopup(UserBase user, int BranchCode, int DtCode)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                // new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                 new SqlParameter("@BranchCode",BranchCode),
                  new SqlParameter("@DtCode",DtCode),

                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_BRANCHPOPUP_DELETE]", sqlParameters, CommandType.StoredProcedure);
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
