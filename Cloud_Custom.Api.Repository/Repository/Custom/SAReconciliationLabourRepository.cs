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
    public class SAReconciliationLabourRepository  : ISAReconciliationLabourRepository
    { 

      private readonly ISqlConnectionProvider _sql;

    public SAReconciliationLabourRepository(ISqlConnectionProvider sql)
    {
        _sql = sql;
    }

        public async Task<SAReconciliationLabour> GetList(UserBase user, int Month, int Region, int Branch, string ServiceAdvisor, bool IsAssigned)
        {
            IDbDataParameter[] sqlparameters =
            {
        new SqlParameter("@CompanyGI", user.CompanyGuid),
        new SqlParameter("@UserGuid", user.UserGuid),
        new SqlParameter("@Month", Month),
        new SqlParameter("@Region", Region),
        new SqlParameter("@Branch", Branch),
        new SqlParameter("@ServiceAdvisor",ServiceAdvisor),
        new SqlParameter("@IsAssigned", IsAssigned),
    };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_SA_RECONCILIATION_LABOUR_LIST]", sqlparameters);
            return PopulateGetList(ds);
        }

        public SAReconciliationLabour PopulateGetList(DataSet ds)
    {
        SAReconciliationLabour model = new SAReconciliationLabour();
        model.List = new List<SAReconciliationLabour>();
        if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var item = new SAReconciliationLabour
                {
                    AdvisorCode = MakeSafe.ToSafeInt32(row["LoadSaCode"]),
                    BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]),
                    NonSAName = MakeSafe.ToSafeString(row["LoadSaName"]),
                    BranchName = MakeSafe.ToSafeString(row["BranchName"]),
                    JCNumber = MakeSafe.ToSafeString(row["JCNumber"]),
                    JCDatetime = MakeSafe.ToSafeString(row["JCDatetime"]),
                    LabourDescription = MakeSafe.ToSafeString(row["LabourDescription"]),
                    AdvisorName = MakeSafe.ToSafeString(row["MappedSa"]),
                };



                model.List.Add(item);
            }
        }
        return model;
    }
        public async Task<SAReconciliationLabour> GetSADetails(UserBase user, int Month, int Region, int Branch, string JCNumber, string LabourDescription)
        {
            IDbDataParameter[] sqlparameters =
            {
        new SqlParameter("@CompanyGI", user.CompanyGuid),
        new SqlParameter("@UserGuid", user.UserGuid),
        new SqlParameter("@Month", Month),
        new SqlParameter("@Region", Region),
        new SqlParameter("@Branch", Branch),
        new SqlParameter("@JCNumber", (object)JCNumber ?? DBNull.Value),
        new SqlParameter("@LabourDescription", (object)LabourDescription ?? DBNull.Value),
    };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_SA_RECONCILIATION_LABOUR_DETAILS]", sqlparameters);
            return PopulateGetSADetails(ds);
        }

        public SAReconciliationLabour PopulateGetSADetails(DataSet ds)
        {
            SAReconciliationLabour model = new SAReconciliationLabour();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                model.AdvisorCode = MakeSafe.ToSafeInt32(row["AdvisorCode"]);
                model.NonSAName = MakeSafe.ToSafeString(row["AdvisorName"]);
                model.BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]);
                model.BranchName = MakeSafe.ToSafeString(row["BranchName"]);
                model.RegionName = MakeSafe.ToSafeString(row["RegionName"]);
                model.JCNumber = MakeSafe.ToSafeString(row["JCNumber"]);
                model.JCDatetime = MakeSafe.ToSafeString(row["JCDatetime"]);
                model.LabourDescription = MakeSafe.ToSafeString(row["LabourDescription"]);
                model.MappedSA = new Dropdown();
                model.MappedSA.Code = MakeSafe.ToSafeInt32(row["AdvisorCode"]);
            }

    
            if ((ds.Tables.Count > 1) && (ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[1].Rows[0];
                model.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                model.Model = MakeSafe.ToSafeString(row["Model"]);
                model.Variant = MakeSafe.ToSafeString(row["Variant"]);
                model.Color = MakeSafe.ToSafeString(row["Color"]);
                model.Phone = MakeSafe.ToSafeString(row["Phone"]);
            }

            return model;
        }

        public async Task<SAReconciliationLabour> GetJCdetails(UserBase user, string JCNO)
    {
        IDbDataParameter[] sqlparameters =
        {
                new SqlParameter("@CompanyGI", user.CompanyGuid),
                new SqlParameter("@UserGuid", user.UserGuid),

                new SqlParameter("@JCNO", JCNO),
            };
        var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_FILE_SA_RECONCILIATION_JC_DETAILS]", sqlparameters);

        return PopulateGetJCdetails(ds);
    }

    public SAReconciliationLabour PopulateGetJCdetails(DataSet ds)
    {
        SAReconciliationLabour model = new SAReconciliationLabour();

        if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
        {
            DataRow row = ds.Tables[0].Rows[0];

            model.JCNumber = MakeSafe.ToSafeString(row["JCNumber"]);
            model.JCDatetime = MakeSafe.ToSafeString(row["JCDatetime"]);
            model.BranchName = MakeSafe.ToSafeString(row["BranchName"]);
            model.RegionName = MakeSafe.ToSafeString(row["RegionName"]);
            model.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
            model.AdvisorName = MakeSafe.ToSafeString(row["AdvisorName"]);
            model.Model = MakeSafe.ToSafeString(row["Model"]);
            model.Variant = MakeSafe.ToSafeString(row["Variant"]);
            model.Color = MakeSafe.ToSafeString(row["Color"]);
            model.Phone = MakeSafe.ToSafeString(row["Phone"]);

            model.MappedSA = new Dropdown();
            model.MappedSA.Code = MakeSafe.ToSafeInt32(row["MappedSACode"]);
        }

        return model;
    }

    public async Task<ResponseEntity> Save(UserBase user, SAReconciliationLabour model)
    {
        SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
        SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
        IDbDataParameter[] sqlParameters =
        {
                new SqlParameter("@CompanyGI", user.CompanyGuid),
                new SqlParameter("@UserGuid", user.UserGuid),
                new SqlParameter("@JSONDATA", JsonHelper.ToJson(model)),
                ResponseKey, ResponseStatus
            };
        await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_SA_RECONCILIATION_LABOUR_SAVE]", sqlParameters, CommandType.StoredProcedure);
        return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
    }
}
}
