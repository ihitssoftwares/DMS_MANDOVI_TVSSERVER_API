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
   public  class OutSourceWorkRepository : IOutSourceWorkRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public OutSourceWorkRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<OutSourceWork> GetList(UserBase user, int Month, int Branch,int Region)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),

                 new SqlParameter("@Month",Month),
                 new SqlParameter("@Region",Region),
                 new SqlParameter("@Branch",Branch)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_OUTSOURCE_WORK_LIST]", sqlparameters);
                return GetList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private OutSourceWork GetList(DataSet dataSet)
        {
            OutSourceWork model = new OutSourceWork();
            List<OutSourceWork> List = new List<OutSourceWork>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new OutSourceWork();

            
                    item.JcCardNo = MakeSafe.ToSafeString(row["JcCardNo"]);
                    item.JcCardDate = MakeSafe.ToSafeString(row["JcDate"]);
                   
                    item.Customer = MakeSafe.ToSafeString(row["Customer"]);
                    item.RegNo = MakeSafe.ToSafeString(row["RegNo"]);
                 
                  



                    List.Add(item);
                }
                model.OutSourceWorkList = List;
            }
            return model;

        }


        public async Task<WorkPopup> GetJcDetails(UserBase user, string JobCardCode ,int Branch)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
         
                new SqlParameter("@JobCardCode",JobCardCode),
                new SqlParameter("@Branch",Branch),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_OUTSOURCED_WORK_DETAILS]", sqlparameters);

            return PopulateGetBayDetails(ds);

        }
        public WorkPopup PopulateGetBayDetails(DataSet ds)
        {

            WorkPopup model = new WorkPopup();
            List<WorkPopup> List = new List<WorkPopup>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new WorkPopup();

     
                    item.JcCardNo = MakeSafe.ToSafeString(row["JCNO"]);
                    item.JcCardDate = MakeSafe.ToSafeString(row["JCDate"]);
                    item.Customer = MakeSafe.ToSafeString(row["Customer"]);
                    item.RegNo = MakeSafe.ToSafeString(row["RegNo"]);
                   




                    List.Add(item);
                }
                model.WorkPopupList = List;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, OutSourceWork model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_OUTSOURCE_WORK_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
