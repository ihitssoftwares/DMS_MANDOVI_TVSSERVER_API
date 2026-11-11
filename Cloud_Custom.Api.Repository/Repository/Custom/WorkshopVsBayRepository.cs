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
    public class WorkshopVsBayRepository : IWorkshopVsBayRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public WorkshopVsBayRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }



        public async Task<WorkshopVsBay> Getlist(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_WORKSHOPVSBAY_LIST]", sqlparameters);
                return WorkshopVsBayList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private WorkshopVsBay WorkshopVsBayList(DataSet dataSet)
        {
            WorkshopVsBay model = new WorkshopVsBay();
            List<WorkshopVsBay> List = new List<WorkshopVsBay>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new WorkshopVsBay();

                    item.BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]);
                    item.BranchName = MakeSafe.ToSafeString(row["BranchName"]);
                    item.BranchDealershipCode = MakeSafe.ToSafeInt32(row["BranchDelearshipCode"]);
                    item.DealershipName = MakeSafe.ToSafeString(row["DealershipName"]);
                    item.StoreType = MakeSafe.ToSafeInt32(row["StoreType"]);
                    item.StoreTypeName = MakeSafe.ToSafeString(row["StoreTypeName"]);
                    item.stateCode = MakeSafe.ToSafeInt32(row["stateCode"]);
                    item.State = MakeSafe.ToSafeString(row["StateName"]);
                    item.RegionCode = MakeSafe.ToSafeInt32(row["RegionCode"]);
                    item.Region = MakeSafe.ToSafeString(row["RegionName"]);
                    item.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);
                    item.WorkShop = MakeSafe.ToSafeInt32(row["WorkShop"]);
                   



                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }


        public async Task<WorkshopVsBay> GetBayDetails(UserBase user,int BranchCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                   new SqlParameter("@BranchCode",BranchCode),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_WORKSHOPVSBAYDETAILS_LIST]", sqlparameters);
                return PopulateWorkshopVsBayDetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private WorkshopVsBay PopulateWorkshopVsBayDetails(DataSet dataSet)
        {
            WorkshopVsBay model = new WorkshopVsBay();
            List<WorkshopVsBay> BayList = new List<WorkshopVsBay>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];

                model.BranchName = MakeSafe.ToSafeString(row["BranchName"]);
                model.StartTime = MakeSafe.ToSafeDateTime(row["StartTime"]);
                model.EndTime = MakeSafe.ToSafeDateTime(row["EndTime"]);

                model.WorkShopTypeCode = MakeSafe.ToSafeInt32(row["WorkShopTypeCode"]);

                model.Type = new Dropdown();

                model.Type.Code = MakeSafe.ToSafeInt32(row["WorkShopTypeCode"]);

                model.Type.Name = MakeSafe.ToSafeString(row["WorkShopTypeName"]);
            }


            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new WorkshopVsBay();

                    //item.BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]);
                    item.BayTypeCode = MakeSafe.ToSafeInt32(row["BayTypeCode"]);
                    item.Name = MakeSafe.ToSafeString(row["BayName"]);
                    

                    item.ActualBayCount= MakeSafe.ToSafeInt32(row["ActualBayCount"]);
                    item.Count = MakeSafe.ToSafeInt32(row["Count"]);
                    item.AverageProductivityPerBay = MakeSafe.ToSafeInt32(row["AverageProductivityPerBay"]);

                    item.Capacity = MakeSafe.ToSafeInt32(row["Capacity"]);
                    item.AverageServiceTime = MakeSafe.ToSafeInt32(row["AverageServiceTime"]);
               






                    BayList.Add(item);

                }
                model.BayList = BayList;


            }

            return model;
        }

        public async Task<ResponseEntity> Save(UserBase user, int WorkShopCode,WorkshopVsBay model)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@JSONDATA", JsonHelper.ToJson(model)),
                   new SqlParameter("@WorkShopCode",WorkShopCode),

                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_WORKSHOPVSBAYS_SAVE]", sqlParameters, CommandType.StoredProcedure);
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
