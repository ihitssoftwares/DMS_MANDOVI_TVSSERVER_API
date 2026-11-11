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
   public  class ServiceIncentiveRepository : IServiceIncentiveRepository
    {
        private readonly ISqlConnectionProvider _sql;
       

        public ServiceIncentiveRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;

        }
        //public async Task<DataSet> GetIncentiveList(UserBase userBase,int MonthCode, int IncentiveCode)
        //{
        //    IDbDataParameter[] sqlparameters =
        //   {
        //        new SqlParameter("@CompanyGI",userBase.CompanyGuid),
        //        new SqlParameter("@UserGI",userBase.UserGuid),
        //        new SqlParameter("@MonthCode",MonthCode),
        //        new SqlParameter("@RegionCode",IncentiveCode),

        //    };
        //    var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_PROCESING_PRECHECK]", sqlparameters);
        //    return ds;
        //}

        public async Task<ServiceIncentive> GetIncentiveList(UserBase userBase, int MonthCode, int IncentiveCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
                    new SqlParameter("@CompanyGI",userBase.CompanyGuid),
                    new SqlParameter("@UserGI",userBase.UserGuid),
                    new SqlParameter("@MonthCode",MonthCode),
                    new SqlParameter("@RegionCode",IncentiveCode),

                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_PROCESING_PRECHECK]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }



        private ServiceIncentive DesignationVsParameterList(DataSet dataSet)
        {
            ServiceIncentive model = new ServiceIncentive();
            List<ServiceIncentive> List = new List<ServiceIncentive>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceIncentive();



                    item.SerialNO = MakeSafe.ToSafeInt32(row["id"]);
                    item.descriptions = MakeSafe.ToSafeString(row["descriptions"]);
                    item.details = MakeSafe.ToSafeString(row["details"]);
                    


                    List.Add(item);
                }
                model.List1 = List;
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


        public async Task<ServiceIncentive> GetProcessList(UserBase userBase, int MonthCode, int Region, int Employeecode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
                    new SqlParameter("@CompanyGI",userBase.CompanyGuid),
                    new SqlParameter("@UserGuid",userBase.UserGuid),
                    new SqlParameter("@MonthCode",MonthCode),
                    new SqlParameter("@RegionCode",Region),
                    new SqlParameter("@Employeecode",Employeecode),

                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_PROCESING]", sqlparameters);
                return ParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private ServiceIncentive ParameterList(DataSet dataSet)
        {
            ServiceIncentive model = new ServiceIncentive();
            List<ServiceIncentive> List = new List<ServiceIncentive>();
            List<ServiceIncentive> List2 = new List<ServiceIncentive>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceIncentive();



                    item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    item.Employee = MakeSafe.ToSafeString(row["Employee"]);
                    item.Branch = MakeSafe.ToSafeString(row["Branch"]);
                    item.IncentiveGroup = MakeSafe.ToSafeString(row["IncentiveGroup"]);
                    item.TotalIncentive = MakeSafe.ToSafeDecimal(row["TotalIncentive"]);






                    List.Add(item);
                }
                if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
                {
                    foreach (DataRow row in dataSet.Tables[1].Rows)
                    {
                        var item = new ServiceIncentive();

                        item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                        item.Target = MakeSafe.ToSafeInt32(row["Target"]);
                        item.Employee = MakeSafe.ToSafeString(row["Employee"]);
                        item.Branch = MakeSafe.ToSafeString(row["Branch"]);
                        item.Parameter = MakeSafe.ToSafeString(row["Parameter"]);
                        item.IncentiveGroup = MakeSafe.ToSafeString(row["IncentiveGroup"]);
                        item.ParameterType = MakeSafe.ToSafeString(row["ParameterType"]);
                        item.Achievment = MakeSafe.ToSafeInt32(row["Achievment"]);
                        item.IncentiveAmount = MakeSafe.ToSafeDecimal(row["IncentiveAmount"]);
                        item.TotalIncentive = MakeSafe.ToSafeDecimal(row["TotalIncentive"]);
                        item.Slab = MakeSafe.ToSafeString(row["Slab"]);
                        item.Incentive = MakeSafe.ToSafeString(row["Incentive"]);

                        List2.Add(item);
                    }
                }


                model.List2 = List2;
                model.List1 = List;
            }



            return model;
        }

        public async Task<ServiceIncentive> GetExcelProcessList(UserBase userBase, int MonthCode, int Region, int Employeecode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
                    new SqlParameter("@CompanyGI",userBase.CompanyGuid),
                    new SqlParameter("@UserGuid",userBase.UserGuid),
                    new SqlParameter("@MonthCode",MonthCode),
                    new SqlParameter("@RegionCode",Region),
                    new SqlParameter("@Employeecode",Employeecode),

                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_PROCESING_EXCEL]", sqlparameters);
                return PopulateList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private ServiceIncentive PopulateList(DataSet dataSet)
        {
            ServiceIncentive model = new ServiceIncentive();
            List<ServiceIncentive> List = new List<ServiceIncentive>();
           

           

                if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        var item = new ServiceIncentive();

                        item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                        item.Target = MakeSafe.ToSafeInt32(row["Target"]);
                        item.Employee = MakeSafe.ToSafeString(row["Employee"]);
                        item.Branch = MakeSafe.ToSafeString(row["Branch"]);
                        item.Parameter = MakeSafe.ToSafeString(row["Parameter"]);
                        item.IncentiveGroup = MakeSafe.ToSafeString(row["IncentiveGroup"]);
                        item.ParameterType = MakeSafe.ToSafeString(row["ParameterType"]);
                        item.Achievment = MakeSafe.ToSafeInt32(row["Achievment"]);
                        item.IncentiveAmount = MakeSafe.ToSafeDecimal(row["IncentiveAmount"]);
                        item.TotalIncentive = MakeSafe.ToSafeDecimal(row["TotalIncentive"]);
                        item.Slab = MakeSafe.ToSafeString(row["Slab"]);
                        item.Incentive = MakeSafe.ToSafeString(row["Incentive"]);
                        item.TotalCount = MakeSafe.ToSafeInt32(row["TotalCount"]);
                        List.Add(item);
                    }
                }


               
                model.List1 = List;
            



            return model;
        }
        public async Task<ServiceIncentive> GetExportToExcelList(UserBase userBase, int MonthCode, int Region)
        {
            try
            {
                
                IDbDataParameter[] sqlparameters =
                {
                    new SqlParameter("@CompanyGI",userBase.CompanyGuid),
                    new SqlParameter("@UserGuid",userBase.UserGuid),
                    new SqlParameter("@MonthCode",MonthCode),
                    new SqlParameter("@RegionCode",Region),
                   //new SqlParameter("@Employeecode",EmpCode),

                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_PROCESING_EXEL_LIST]", sqlparameters);
                return PopulateExelList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private ServiceIncentive PopulateExelList(DataSet dataSet)
        {
            ServiceIncentive model = new ServiceIncentive();
            List<ServiceIncentive> List = new List<ServiceIncentive>();




            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceIncentive();



                    item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    item.Employee = MakeSafe.ToSafeString(row["Employee"]);
                    item.Branch = MakeSafe.ToSafeString(row["Branch"]);
                    item.IncentiveGroup = MakeSafe.ToSafeString(row["IncentiveGroup"]);
                    item.TotalIncentive = MakeSafe.ToSafeDecimal(row["TotalIncentive"]);


                    item.TotalCount = MakeSafe.ToSafeInt32(row["TotalCount"]);





                    List.Add(item);
                }
            }



            model.List1 = List;




            return model;
        }

    }
}
