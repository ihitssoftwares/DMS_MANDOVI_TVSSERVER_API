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
    public class SeviceAchivementvsTargetRepository : ISeviceAchivementvsTargetRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public SeviceAchivementvsTargetRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }




        public async Task<SeviceAchivementvsTarget> GetList(UserBase user, int Region, int MonthCode, int ParameterCode)
        
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),

                 new SqlParameter("@RegionCode",Region),
                 new SqlParameter("@MonthCode",MonthCode),
                 new SqlParameter("@ParameterCode",ParameterCode),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_TARGET_VS_ACHIEVMENT_REPORT]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private SeviceAchivementvsTarget DesignationVsParameterList(DataSet dataSet)
        {
            SeviceAchivementvsTarget model = new SeviceAchivementvsTarget();
            List<SeviceAchivementvsTarget> List = new List<SeviceAchivementvsTarget>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new SeviceAchivementvsTarget();



                    
                    item.Branch = MakeSafe.ToSafeString(row["Branch"]);
                    item.Regions = MakeSafe.ToSafeString(row["Region"]);
                    item.IncentiveGroup = MakeSafe.ToSafeString(row["Incentive Group"]);
                    item.TargetParameter = MakeSafe.ToSafeString(row["Target Parameter"]);
                    item.Target = MakeSafe.ToSafeInt32(row["Target"]);
                    item.TillDateAchievment = MakeSafe.ToSafeInt32(row["Till Date Achievment"]);
                    item.PercentageofAchievment = MakeSafe.ToSafeInt32(row["% of Achievment"]);
                    item.monthCode = MakeSafe.ToSafeInt32(row["monthCode"]);
                    item.parameterCode = MakeSafe.ToSafeInt32(row["parameterCode"]);
                    item.IncentiveGroupCode = MakeSafe.ToSafeInt32(row["IncentiveGroupCode"]);
                    item.RegionCode = MakeSafe.ToSafeInt32(row["RegionCode"]);
                    item.BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]);



                    List.Add(item);
                }
                model.List = List;
            }


            //if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            //{
            //    foreach (DataRow row in dataSet.Tables[1].Rows)
            //    {

            //        model.PendingCount = MakeSafe.ToSafeInt32(row["PendingCount"]);

            //    }
            //}
            return model;
        }











        public async Task<SeviceAchivementvsTarget> GetDetails(UserBase user, int parameterCode, int IncentiveGroupCode, int RegionCode, int BranchCode, int MonthCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@ParameterCode",parameterCode),
                 new SqlParameter("@IncentiveGroupCode",IncentiveGroupCode),
                  new SqlParameter("@RegionCode",RegionCode),
                   new SqlParameter("@BranchCode",BranchCode),
                    new SqlParameter("@MonthCode",MonthCode),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_TARGET_VS_ACHIEVMENT_REPORT_DRILLDOWN]", sqlparameters);

            return PopulateGetEmployeeDetails(ds);

        }
        public SeviceAchivementvsTarget PopulateGetEmployeeDetails(DataSet ds)
        {

            SeviceAchivementvsTarget model = new SeviceAchivementvsTarget();
            List<AchivementvsTarget> List = new List<AchivementvsTarget>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new AchivementvsTarget();



                    item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    item.EmployeeID = MakeSafe.ToSafeString(row["Employee ID"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["Employee Name"]);                   
                    item.TargetParameter = MakeSafe.ToSafeString(row["Target Parameter"]);
                    item.Target = MakeSafe.ToSafeInt32(row["Target"]);
                    item.TillDateAchievment = MakeSafe.ToSafeInt32(row["Till Date Achievment"]);
                    item.PercentageofAchievment = MakeSafe.ToSafeInt32(row["% of Achievment"]);
                    



                    List.Add(item);
                }
                model.EditList = List;
            }
            return model;
        }





        public async Task<SeviceAchivementvsTarget> GetDrillDownDetails(UserBase user, int monthCode, int parameterCode, int employeeCode)
        {
            IDbDataParameter[] sqlparameters =
            {
        new SqlParameter("@MonthCode", monthCode),
        new SqlParameter("@ParameterCode", parameterCode),
        new SqlParameter("@EmployeeCode", employeeCode)
    };

            var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_TARGET_VS_ACHIEVMENT_REPORT_DRILLDOWN_DETAIL]",
                sqlparameters);

            return PopulateDrillDownDetails(ds, parameterCode);
        }


        public SeviceAchivementvsTarget PopulateDrillDownDetails(DataSet ds, int parameterCode)
        {
            SeviceAchivementvsTarget model = new SeviceAchivementvsTarget();




           


            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.parameterCode = MakeSafe.ToSafeInt32(row["parameterCode"]);

                    model.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    model.EmployeeId = MakeSafe.ToSafeString(row["EmployeeId"]);
                    model.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);
                    model.Branch = MakeSafe.ToSafeString(row["Branch"]);

                }
            }

            if ((ds.Tables[1]?.Rows?.Count ?? 0) == 0)
                return model;
            if (parameterCode == 1)
            {
                List<ServiceIncentiveLoad> list = new List<ServiceIncentiveLoad>();

                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    ServiceIncentiveLoad item = new ServiceIncentiveLoad();

                    item.Workshop = MakeSafe.ToSafeString(row["Workshop"]);
                    item.RegionName = MakeSafe.ToSafeString(row["RegionName"]);
                    item.ServiceAdvisor = MakeSafe.ToSafeString(row["ServiceAdvisor"]);
                    item.JobCardNumber = MakeSafe.ToSafeString(row["JobCardNumber"]);
                    item.JobCardDate = MakeSafe.ToSafeDateTime(row["JobCardDate"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.RegistrationNumber = MakeSafe.ToSafeString(row["RegistrationNumber"]);
                    item.PsFStatus = MakeSafe.ToSafeString(row["PsFStatus"]);
                    item.ServiceType = MakeSafe.ToSafeString(row["ServiceType"]);
                    item.SaleDate = MakeSafe.ToSafeDateTime(row["SaleDate"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.Variant = MakeSafe.ToSafeString(row["Variant"]);
                    item.LabourAmount = MakeSafe.ToSafeDecimal(row["LabourAmount"]);
                    item.PartsAmount = MakeSafe.ToSafeDecimal(row["PartsAmount"]);
                    item.BillAmount = MakeSafe.ToSafeDecimal(row["BillAmount"]);
                    item.MgaAmount = MakeSafe.ToSafeDecimal(row["MgaAmount"]);
                    item.CEI = MakeSafe.ToSafeString(row["CEI"]);
                    item.NPScategory = MakeSafe.ToSafeString(row["NPScategory"]);
                    item.EntryDate = MakeSafe.ToSafeDateTime(row["EntryDate"]);

                    list.Add(item);
                }

                model.ServiceIncentiveLoadList = list;
            }
            else if (parameterCode == 2)
            {
                List<LabourDetails> list = new List<LabourDetails>();

                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    LabourDetails item = new LabourDetails();

                    item.Workshop = MakeSafe.ToSafeString(row["Workshop"]);
                    item.RegionName = MakeSafe.ToSafeString(row["RegionName"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);
                    item.JobCardNumber = MakeSafe.ToSafeString(row["JobCardNumber"]);
                    item.JobCardDate = MakeSafe.ToSafeDateTime(row["JobCardDate"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.RegistrationNumber = MakeSafe.ToSafeString(row["RegistrationNumber"]);
                    item.Variant = MakeSafe.ToSafeString(row["Variant"]);
                    item.ServiseType = MakeSafe.ToSafeString(row["ServiceType"]);
                    
                    item.LabourName = MakeSafe.ToSafeString(row["LabourName"]);
                    item.BasicAmt = MakeSafe.ToSafeDecimal(row["BasicAmt"]);
                    item.DiscountAmt = MakeSafe.ToSafeDecimal(row["DiscountAmt"]);
                    item.ChargesAmt = MakeSafe.ToSafeDecimal(row["ChargesAmt"]);
                    item.BillAmt = MakeSafe.ToSafeDecimal(row["BillAmt"]);

                    list.Add(item);
                }

                model.LabourDetailsList = list;
            }
            else if (parameterCode == 3)
            {
                List<MGADetails> list = new List<MGADetails>();

                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    MGADetails item = new MGADetails();

                    item.Workshop = MakeSafe.ToSafeString(row["Workshop"]);
                    item.RegionName = MakeSafe.ToSafeString(row["RegionName"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);
                    item.VehicleCount = MakeSafe.ToSafeInt32(row["VehicleCount"]);
                    item.Consumption = MakeSafe.ToSafeDecimal(row["Consumption"]);
                    item.LoadValue = MakeSafe.ToSafeDecimal(row["LoadValue"]);
                    item.MGALoad = MakeSafe.ToSafeDecimal(row["MGALoad"]);
                    item.ACFilter = MakeSafe.ToSafeDecimal(row["ACFilter"]);
                    item.Screenwash = MakeSafe.ToSafeDecimal(row["Screenwash"]);
                    item.Perfumes = MakeSafe.ToSafeDecimal(row["Perfumes"]);
                    item.Mats = MakeSafe.ToSafeDecimal(row["Mats"]);
                    item.ACGas = MakeSafe.ToSafeDecimal(row["ACGas"]);
                    item.MGADate = MakeSafe.ToSafeDateTime(row["MGADate"]);

                    list.Add(item);
                }

                model.MGADetailsList = list;
            }




            return model;
        }
    }
}
