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
    public class DataValidationAlertsRepository: IDataValidationAlertsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public DataValidationAlertsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<DataValidationAlerts> GetValidationList(UserBase user, int ModuleCode, string Severity)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@ModuleCode",ModuleCode),

                 new SqlParameter("@Severity",Severity)



                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_DATA_VALIDATION_ALERTS]", sqlparameters);
                return DataValidationAlertsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }

        }
        private DataValidationAlerts DataValidationAlertsList(DataSet dataSet)
        {
            DataValidationAlerts model = new DataValidationAlerts();
            List<DataValidationAlerts> List = new List<DataValidationAlerts>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new DataValidationAlerts();



                    item.Code = MakeSafe.ToSafeInt32(row["Code"]);
                    item.ModuleCode = MakeSafe.ToSafeInt32(row["ModuleCode"]);
                    item.ModuleName = MakeSafe.ToSafeString(row["ModuleName"]);

                    item.Category = MakeSafe.ToSafeString(row["Category"]);
                    item.Alert = MakeSafe.ToSafeString(row["Alert"]);

                    item.Severity = MakeSafe.ToSafeString(row["Severity"]);
                    item.AlertCount = MakeSafe.ToSafeInt32(row["AlertCount"]);



                    List.Add(item);
                }
                model.List = List;
            }

            return model;

        }



        public async Task<DataValidationAlerts> GetAlertDetails(UserBase user, string Type,int Code)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Type",Type),
                 new SqlParameter("@Code",Code)






                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_DATA_VALIDATION_ALERTS_DETAILS]", sqlparameters);
                return DatapopupList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }

        }
        private DataValidationAlerts DatapopupList(DataSet dataSet)
        {
            DataValidationAlerts model = new DataValidationAlerts();
            List<DataValidationAlerts> List = new List<DataValidationAlerts>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new DataValidationAlerts();


                    item.ModuleName = MakeSafe.ToSafeString(row["ModuleName"]);
                    item.Alert = MakeSafe.ToSafeString(row["Alert"]);

                    item.Item = MakeSafe.ToSafeString(row["Item"]);
                    item.Description = MakeSafe.ToSafeString(row["Description"]);



                    List.Add(item);
                

                }
                model.AltertList = List;
                
                model.ModuleName = List[0].ModuleName;
                model.Alert = List[0].Alert;
            }

            return model;

        }

    }
}
