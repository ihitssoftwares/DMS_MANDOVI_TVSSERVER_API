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
   public  class AllAdminFormsRepository : IAllAdminFormsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public AllAdminFormsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<AllAdminForms> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_AllAdminForms_LIST]", sqlparameters);
                return AllAdminFormsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private AllAdminForms AllAdminFormsList(DataSet dataSet)
        {
            AllAdminForms model = new AllAdminForms();
            List<AllAdminForms> List = new List<AllAdminForms>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new AllAdminForms();



                    item.MenuCode = MakeSafe.ToSafeInt32(row["MenuCode"]);
                    item.menuname = MakeSafe.ToSafeString(row["MenuName"]);
                    item.ControllerName = MakeSafe.ToSafeString(row["Controller"]);
             


                    List.Add(item);
                }
                model.MenuList = List;
            }
            return model;

        }
    }
}
