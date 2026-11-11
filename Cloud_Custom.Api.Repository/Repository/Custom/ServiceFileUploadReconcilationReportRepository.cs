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
    public class ServiceFileUploadReconcilationReportRepository : IServiceFileUploadReconcilationReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ServiceFileUploadReconcilationReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<ServiceFileUploadReconcilationReport> GetList(UserBase user, int Month,int Region)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@monthCode",Month),
                 new SqlParameter("@RegionCode",Region),


                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_FILE_UPLOAD_RECONCILATION_REPORT]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private ServiceFileUploadReconcilationReport DesignationVsParameterList(DataSet dataSet)
        {
            ServiceFileUploadReconcilationReport model = new ServiceFileUploadReconcilationReport();
            List<ServiceFileUploadReconcilationReport> List = new List<ServiceFileUploadReconcilationReport>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceFileUploadReconcilationReport();



                    item.Date = MakeSafe.ToSafeString(row["Date"]);
                    item.Day = MakeSafe.ToSafeString(row["Day"]);
                    item.NoOfWsUploadedLoad = MakeSafe.ToSafeInt32(row["NoOfWsUploadedLoad"]);
                    item.NoOfWsNotUploadedLoad = MakeSafe.ToSafeInt32(row["NoOfWsNotUploadedLoad"]);                
                    item.NoOfWsUploadedLabour = MakeSafe.ToSafeInt32(row["NoOfWsUploadedLabour"]);
                    item.NoOfWsNotUploadedLabour = MakeSafe.ToSafeInt32(row["NoOfWsNotUploadedLabour"]);
                    item.NoOfJobCardLoad = MakeSafe.ToSafeInt32(row["NoOfJobCardLoad"]);
                    item.NoOfJobCardLabour = MakeSafe.ToSafeInt32(row["NoOfJobCardLabour"]);
                    item.NoOfJobCardInLoadNotInLabour = MakeSafe.ToSafeInt32(row["NoOfJobCardInLoadNotInLabour"]);
                    item.NoOfJobCardInLabourNotInLoad = MakeSafe.ToSafeInt32(row["NoOfJobCardInLabourNotInLoad"]);
                    item.LabourAmtInLoad = MakeSafe.ToSafeInt32(row["LabourAmtInLoad"]);
                    item.LabourAmtInLabour = MakeSafe.ToSafeInt32(row["LabourAmtInLabour"]);
                    item.TotalAmount = MakeSafe.ToSafeInt32(row["TotalAmount"]);




                    List.Add(item);
                }
                model.List = List;
            }

            return model;
           
        }


        public async Task<ServiceFileUploadReconcilationReport> GetPopUp(UserBase user,string date)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Date",date),
                

                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_FILE_UPLOAD_RECONCILATION_REPORT_WORKSHOP_DETAIL]", sqlparameters);
                return ParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private ServiceFileUploadReconcilationReport ParameterList(DataSet dataSet)
        {
            ServiceFileUploadReconcilationReport model = new ServiceFileUploadReconcilationReport();
            List<ServiceFileUploadReconcilationReport> List = new List<ServiceFileUploadReconcilationReport>();
            List<ServiceFileUploadReconcilationReportList> EditList = new List<ServiceFileUploadReconcilationReportList>();
            List<ServiceFileUploadReconcilationReportList2> EditList2 = new List<ServiceFileUploadReconcilationReportList2>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceFileUploadReconcilationReport();



                    item.branchCode = MakeSafe.ToSafeInt32(row["branchCode"]);

                    item.branchName = MakeSafe.ToSafeString(row["branchName"]);
                    item.UploadedLoad = MakeSafe.ToSafeInt32(row["UploadedLoad"]);
                    item.UploadedLabour = MakeSafe.ToSafeInt32(row["UploadedLabour"]);
                   




                    List.Add(item);
                }
                model.List = List;
            }
            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new ServiceFileUploadReconcilationReportList();



                    item.Location = MakeSafe.ToSafeString(row["Location"]);

                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.JcDate = MakeSafe.ToSafeString(row["JcDate"]);
                    item.SA = MakeSafe.ToSafeString(row["SA"]);
                    item.Technician = MakeSafe.ToSafeString(row["Technician"]);
                    item.ServiceType = MakeSafe.ToSafeString(row["ServiceType"]);
                    item.PartAmt = MakeSafe.ToSafeDecimal(row["PartAmt"]);
                    item.LabourAmt = MakeSafe.ToSafeDecimal(row["LabourAmt"]);
                    item.BillAmount = MakeSafe.ToSafeDecimal(row["BillAmount"]);
                    item.BillDate = MakeSafe.ToSafeString(row["BillDate"]);
                   





                    EditList.Add(item);
                }
                model.EditList = EditList;
            }
            if ((dataSet.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[2].Rows)
                {
                    var item = new ServiceFileUploadReconcilationReportList2();



                    item.Location = MakeSafe.ToSafeString(row["Location"]);

                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.JcDate = MakeSafe.ToSafeString(row["JcDate"]);
                    item.SA = MakeSafe.ToSafeString(row["SA"]);
                    item.BillAmount = MakeSafe.ToSafeDecimal(row["BillAmount"]);
                    item.BillDate = MakeSafe.ToSafeString(row["BillDate"]);




                    EditList2.Add(item);
                }
                model.EditList2 = EditList2;
            }
            return model;

        }


        public async Task<ServiceFileUploadReconcilationReport> GetPopUp1(UserBase user, string date)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Date",date),


                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_FILE_UPLOAD_RECONCILATION_REPORT_JC_DETAIL]", sqlparameters);
                return ParameterList1(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private ServiceFileUploadReconcilationReport ParameterList1(DataSet dataSet)
        {
            ServiceFileUploadReconcilationReport model = new ServiceFileUploadReconcilationReport();
            List<ServiceFileUploadReconcilationReport> List = new List<ServiceFileUploadReconcilationReport>();
            List<ServiceFileUploadReconcilationReportList> EditList = new List<ServiceFileUploadReconcilationReportList>();
            List<ServiceFileUploadReconcilationReportList2> EditList2 = new List<ServiceFileUploadReconcilationReportList2>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceFileUploadReconcilationReport();



                    item.branchCode = MakeSafe.ToSafeInt32(row["branchCode"]);

                    item.branchName = MakeSafe.ToSafeString(row["branchName"]);
                 
                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.jcInLoad = MakeSafe.ToSafeInt32(row["jcInLoad"]);
                    item.jcInLabour = MakeSafe.ToSafeInt32(row["jcInLabour"]);




                    List.Add(item);
                }
                model.List = List;
            }
            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new ServiceFileUploadReconcilationReportList();



                    item.Location = MakeSafe.ToSafeString(row["Location"]);

                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.JcDate = MakeSafe.ToSafeString(row["JcDate"]);
                    item.SA = MakeSafe.ToSafeString(row["SA"]);
                    item.Technician = MakeSafe.ToSafeString(row["Technician"]);
                    item.ServiceType = MakeSafe.ToSafeString(row["ServiceType"]);
                    item.PartAmt = MakeSafe.ToSafeDecimal(row["PartAmt"]);
                    item.LabourAmt = MakeSafe.ToSafeDecimal(row["LabourAmt"]);
                    item.BillAmount = MakeSafe.ToSafeDecimal(row["BillAmount"]);
                    item.BillDate = MakeSafe.ToSafeString(row["BillDate"]);






                    EditList.Add(item);
                }
                model.EditList = EditList;
            }
            if ((dataSet.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[2].Rows)
                {
                    var item = new ServiceFileUploadReconcilationReportList2();



                    item.Location = MakeSafe.ToSafeString(row["Location"]);

                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.JcDate = MakeSafe.ToSafeString(row["JcDate"]);
                    item.SA = MakeSafe.ToSafeString(row["SA"]);
                    item.BillAmount = MakeSafe.ToSafeDecimal(row["BillAmount"]);
                    item.BillDate = MakeSafe.ToSafeString(row["BillDate"]);




                    EditList2.Add(item);
                }
                model.EditList2 = EditList2;
            }
            return model;

        }


        public async Task<ServiceFileUploadReconcilationReport> GetPopUp2(UserBase user, string date)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Date",date),


                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_FILE_UPLOAD_RECONCILATION_REPORT_LABOUR_AMOUNT_DETAIL]", sqlparameters);
                return ParameterList2(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }




        private ServiceFileUploadReconcilationReport ParameterList2(DataSet dataSet)
        {
            ServiceFileUploadReconcilationReport model = new ServiceFileUploadReconcilationReport();
           
            List<ServiceFileUploadReconcilationReportList> EditList = new List<ServiceFileUploadReconcilationReportList>();
            List<ServiceFileUploadReconcilationReportList2> EditList2 = new List<ServiceFileUploadReconcilationReportList2>();

           
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceFileUploadReconcilationReportList();



                    item.Location = MakeSafe.ToSafeString(row["Location"]);

                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.JcDate = MakeSafe.ToSafeString(row["JcDate"]);
                    item.SA = MakeSafe.ToSafeString(row["SA"]);
                    item.Technician = MakeSafe.ToSafeString(row["Technician"]);
                    item.ServiceType = MakeSafe.ToSafeString(row["ServiceType"]);
                    item.PartAmt = MakeSafe.ToSafeDecimal(row["PartAmt"]);
                    item.LabourAmt = MakeSafe.ToSafeDecimal(row["LabourAmt"]);
                    item.BillAmount = MakeSafe.ToSafeDecimal(row["BillAmount"]);
                    item.BillDate = MakeSafe.ToSafeString(row["BillDate"]);






                    EditList.Add(item);
                }
                model.EditList = EditList;
            }
            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new ServiceFileUploadReconcilationReportList2();



                    item.Location = MakeSafe.ToSafeString(row["Location"]);

                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.JcDate = MakeSafe.ToSafeString(row["JcDate"]);
                    item.SA = MakeSafe.ToSafeString(row["SA"]);
                    item.BillAmount = MakeSafe.ToSafeDecimal(row["BillAmount"]);
                    item.BillDate = MakeSafe.ToSafeString(row["BillDate"]);




                    EditList2.Add(item);
                }
                model.EditList2 = EditList2;
            }
            return model;

        }




    }
}
