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
    public class BayManagementRepository : IBayManagementRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public BayManagementRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<BayManagement> GetList(UserBase user, int WorkshopCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),

                 new SqlParameter("@WorkshopCode",WorkshopCode)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_BAY_MANAGEMENT_LIST]", sqlparameters);
                return GetList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private BayManagement GetList(DataSet dataSet)
        {
            BayManagement model = new BayManagement();
            List<BayManagement> List = new List<BayManagement>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new BayManagement();

                    item.JobCardCode = MakeSafe.ToSafeInt32(row["JobCardCode"]);
                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.JCdate = MakeSafe.ToSafeString(row["Jcdate"]);
                    item.customerCode = MakeSafe.ToSafeInt32(row["CustomerCode"]);
                    item.Customer = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.RegNo = MakeSafe.ToSafeString(row["VehicleRegNo"]);
                    item.phoneNo = MakeSafe.ToSafeString(row["PhoneNo"]);
                    item.ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]);
                    item.EngineNo = MakeSafe.ToSafeString(row["EngineNo"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.variant = MakeSafe.ToSafeString(row["variant"]);
                    item.BayCount = MakeSafe.ToSafeInt32(row["BayCount"]);



                    List.Add(item);
                }
                model.BayList = List;
            }
            return model;

        }


        public async Task<BayDetails> GetBayDetails(UserBase user, int JobCardCode, int customerCode, int WorkShopCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),    
                new SqlParameter("@WorkShopCode",WorkShopCode),
                new SqlParameter("@JobCardCode",JobCardCode),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_BAY_MANAGEMENT_DETAILS_LIST]", sqlparameters);

            return PopulateGetBayDetails(ds);

        }
        public BayDetails PopulateGetBayDetails(DataSet ds)
        {

            BayDetails model = new BayDetails();
            List<BayDetails> List = new List<BayDetails>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new BayDetails();

                    item.BayCode = MakeSafe.ToSafeInt32(row["BayCode"]);
                    item.Bayname = MakeSafe.ToSafeString(row["BAY"]);
                    item.BayTypeCode = MakeSafe.ToSafeInt32(row["BayTypeCode"]);
                    item.BayTypename = MakeSafe.ToSafeString(row["BAYTYPE"]);
                    item.Applicability = MakeSafe.ToSafeBool(row["Applicability"]);
                   



                    List.Add(item);
                }
                model.BayDetailsList = List;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, BayManagement model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_BAY_MANAGEMENT_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}

