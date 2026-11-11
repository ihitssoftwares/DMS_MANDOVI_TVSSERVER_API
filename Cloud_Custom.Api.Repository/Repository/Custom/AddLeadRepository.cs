using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Custom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{

    public class AddLeadRepository : IAddLeadRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public AddLeadRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<AddLead> GetList(UserBase user)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_ADD_LEAD_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public AddLead PopulateGetList(DataSet ds)
        {
            AddLead model = new AddLead();
            model.AddLeadList = new List<AddLead>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new AddLead
                    {
    
                        LeadTrnCode = MakeSafe.ToSafeInt32(row["LeadTrnCode"]),
                        CustomerName = MakeSafe.ToSafeString(row["LeadName"]),
                        LeadNo = MakeSafe.ToSafeString(row["LeadNo"]),
                        Mobilno = MakeSafe.ToSafeString(row["MobileNo"]),
                        EmailId = MakeSafe.ToSafeString(row["EmailID"]),
                        Variant = new Dropdown { Name = MakeSafe.ToSafeString(row["Variant"]) },
                        Color = new Dropdown { Name = MakeSafe.ToSafeString(row["ColorName"]) },               
                        Modell = new Dropdown { Name = MakeSafe.ToSafeString(row["InterestedModel"]) },                      
                        Status = new Dropdown { Name = MakeSafe.ToSafeString(row["LeadStatus"]) },              
                        EnquireDate = MakeSafe.ToSafeString(row["LeadDate"]),

                    };
                model.AddLeadList.Add(item);
            }
        }
            return model;
        }


        public async Task<ResponseEntity> Save(UserBase user,AddLead input)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@JSONDATA",JsonHelper.ToJson(input)),
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_ADD_LEAD]", sqlParameters, CommandType.StoredProcedure);
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
