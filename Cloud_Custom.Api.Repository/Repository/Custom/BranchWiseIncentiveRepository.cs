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
    public class BranchWiseIncentiveRepository : IBranchWiseIncentiveRepository
    {

        private readonly ISqlConnectionProvider _sql;
        public BranchWiseIncentiveRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<BranchWiseIncentive> GetList(UserBase user, int Month, int Parameter, int Region, int IncentiveGroup)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@MonthCode",Month),
                 new SqlParameter("@ParameterCode",Parameter),
                 new SqlParameter("@RegionCode",Region),
                 new SqlParameter("@IncentiveGroupCode",IncentiveGroup)

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_BRANCH_WISE_INCENTIVE_LIST]", sqlparameters);
                return BranchWiseIncentiveList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private BranchWiseIncentive BranchWiseIncentiveList(DataSet dataSet)
        {
            BranchWiseIncentive model = new BranchWiseIncentive();
            List<BranchWiseIncentive> List = new List<BranchWiseIncentive>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new BranchWiseIncentive();


                    item.HdCode = MakeSafe.ToSafeInt32(row["HdCode"]);
                   item.BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]);
                    item.BranchName = MakeSafe.ToSafeString(row["BranchName"]);
                   
                    item.SlabType = MakeSafe.ToSafeString(row["SlabType"]);
                   
                    item.SlabFrom = MakeSafe.ToSafeDecimal(row["SlabFrom"]);
                    item.SlabTo = MakeSafe.ToSafeDecimal(row["SlabTo"]);
                    item.Incentive = MakeSafe.ToSafeDecimal(row["Incentive"]);
                    item.CalculationTypeName = MakeSafe.ToSafeString(row["CalculationTypeName"]);


                    List.Add(item);
                }
                model.List = List;
            }


            return model;
        }


        //public async Task<BranchWiseIncentive> GeteditList(UserBase user, int Month, int IncentiveGroup, int Region, int ParameterCode)
        //{
        //    try
        //    {
        //        IDbDataParameter[] sqlparameters =
        //          {
        //         new SqlParameter("@CompanyGI",user.CompanyGuid),
        //         new SqlParameter("@UserGuid",user.UserGuid),
        //         new SqlParameter("@Month",Month),
        //         new SqlParameter("@IncentiveGroupCode",IncentiveGroup),
        //         new SqlParameter("@RegionCode",Region),
        //         new SqlParameter("@ParameterCode",ParameterCode),

        //    };
        //        var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_SETTINGS_DATA]", sqlparameters);
        //        return ParameterList(ds);
        //    }
        //    catch (SqlException ex)
        //    {
        //        var ErrorMsg = ex.Message.ToString();
        //        throw new Exception(ErrorMsg, ex);
        //    }
        //}
        //private ServiceIncentiveSettingsGroupWise ParameterList(DataSet dataSet)
        //{
        //    ServiceIncentiveSettingsGroupWise model = new ServiceIncentiveSettingsGroupWise();
        //    List<EditServiceIncentiveSettingsGroupWise> List = new List<EditServiceIncentiveSettingsGroupWise>();

        //    if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
        //    {
        //        foreach (DataRow row in dataSet.Tables[0].Rows)
        //        {
        //            var item = new EditServiceIncentiveSettingsGroupWise();



        //            item.IncentiveGroupCode = MakeSafe.ToSafeInt32(row["IncentiveGroupCode"]);
        //            item.IncentiveGroupName = MakeSafe.ToSafeString(row["IncentiveGroupName"]);
        //            item.ParameterCode = MakeSafe.ToSafeInt32(row["ParameterCode"]);
        //            item.ParameterName = MakeSafe.ToSafeString(row["ParameterName"]);
        //            item.SlabType = MakeSafe.ToSafeString(row["SlabType"]);
        //            item.IncentiveType = MakeSafe.ToSafeString(row["IncentiveType"]);
        //            item.SlabFrom = MakeSafe.ToSafeDecimal(row["SlabFrom"]);
        //            item.SlabTo = MakeSafe.ToSafeDecimal(row["SlabTo"]);
        //            item.Incentives = MakeSafe.ToSafeDecimal(row["Incentive"]);



        //            List.Add(item);
        //        }
        //        model.EditList = List;
        //    }
        //    return model;

        //}

        //public async Task<ResponseEntity> SettingsSave(UserBase User, ServiceIncentiveSettingsGroupWise model, int monthcode)
        //{
        //    try
        //    {
        //        SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 250, Direction = ParameterDirection.Output };
        //        SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
        //        IDbDataParameter[] sqlParameters =
        //        {
        //            new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
        //            new SqlParameter("@CompanyGI",User.CompanyGuid),
        //            new SqlParameter("@UserGI",User.UserGuid),
        //            new SqlParameter("@Monthcode",monthcode),
        //    ResponseKey,ResponseStatus
        //    };
        //        await _sql.ExecuteNonQueryAsync("[DMS].[SP_SERVICE_INCENTIVE_TARGET_SAVE]", sqlParameters, CommandType.StoredProcedure);
        //        return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        //    }
        //    catch (SqlException EX)
        //    {
        //        var ErrorMsg = EX.Message.ToString();
        //        throw new Exception(ErrorMsg, EX);
        //    }
        //}

        public async Task<BranchWiseIncentive> GetBranchWiseIncentiveDetails(UserBase user,int HdCode,int BranchCode, int IncentiveGroupCode, int month, int Parameter, int Region)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@HdCode",HdCode),
                new SqlParameter("@BranchCode",BranchCode),
                new SqlParameter("@ParameterCode",Parameter),
                new SqlParameter("@MonthCode",month),
                new SqlParameter("@IncentiveGroupCode",IncentiveGroupCode),
                new SqlParameter("@RegionCode",Region),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_BRANCH_WISE_INCENTIVE_DETAILS]", sqlparameters);

            return PopulateGetBranchWiseIncentiveDetails(ds);

        }


        public BranchWiseIncentive PopulateGetBranchWiseIncentiveDetails(DataSet ds)
        {
            BranchWiseIncentive model = new BranchWiseIncentive();
            List<BranchWiseIncentive> list = new List<BranchWiseIncentive>();

            // Table 0: SlabFrom, SlabTo, Incentive, CalculationTypeCode
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new BranchWiseIncentive();
                    item.CalculationType = new Dropdown();

                    item.SlabFrom = MakeSafe.ToSafeDecimal(row["SlabFrom"]);
                    item.SlabTo = MakeSafe.ToSafeDecimal(row["SlabTo"]);
                    item.Incentive = MakeSafe.ToSafeDecimal(row["Incentive"]);
                    item.CalculationType.Code = MakeSafe.ToSafeInt32(row["CalculationTypeCode"]);

                    list.Add(item);
                }
                model.List = list;
            }

            // Table 1: BranchCode, HdCode, IncentiveGroupCode, ParameterCode, BranchName, MonthName, IncentiveGroupName, ParameterName
            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[1].Rows[0];
                model.BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]);
                model.HdCode = MakeSafe.ToSafeInt32(row["HdCode"]);
                model.IncentiveGroupCode = MakeSafe.ToSafeInt32(row["IncentiveGroupCode"]);
                model.ParameterCode = MakeSafe.ToSafeInt32(row["ParameterCode"]);
                model.BranchName = MakeSafe.ToSafeString(row["BranchName"]);
                model.MonthCode = MakeSafe.ToSafeInt32(row["MonthCode"]);
                model.MonthName = MakeSafe.ToSafeString(row["MonthName"]);
                model.IncentiveGroupName = MakeSafe.ToSafeString(row["IncentiveGroupName"]);
                model.ParameterName = MakeSafe.ToSafeString(row["ParameterName"]);
            }

            return model;
        }



        public async Task<ResponseEntity> BranchWiseIncentiveSave(UserBase user, BranchWiseIncentive model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_BRANCH_WISE_INCENTIVE_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }


        //public async Task<ResponseEntity> SavePopup(UserBase user, int monthfromCode, int MonthToCode)
        //{
        //    SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
        //    SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
        //    IDbDataParameter[] sqlParameters =
        //    {        new SqlParameter("@CompanyGI",user.CompanyGuid),
        //             new SqlParameter("@UserGuid",user.UserGuid),
        //             new SqlParameter("@MonthcodeFrom",monthfromCode),
        //             new SqlParameter("@MonthcodeTo",MonthToCode),
        //        ResponseKey,ResponseStatus
        //        };
        //    await _sql.ExecuteNonQueryAsync("[DMS].[SP_SERVICE_INCENTIVE_SETTINGS_TRANSFER]", sqlParameters, CommandType.StoredProcedure);
        //    return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        //}
    }
}
