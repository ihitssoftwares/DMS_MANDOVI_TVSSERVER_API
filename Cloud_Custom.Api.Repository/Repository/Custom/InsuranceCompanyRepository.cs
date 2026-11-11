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
    public class InsuranceCompanyRepository : IInsuranceCompanyRepository
    {

        private readonly ISqlConnectionProvider _sql;
        public InsuranceCompanyRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<InsuranceCompany> GetList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@TabIndex",TabIndex),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[GET_INSURANCECOMPANY_LIST]", sqlparameters);
                return InsuranceCompanyList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private InsuranceCompany InsuranceCompanyList(DataSet dataSet)
        {
            InsuranceCompany model = new InsuranceCompany();
            List<InsuranceCompany> List = new List<InsuranceCompany>();
           
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new InsuranceCompany();

                    
                    item.InsComCode = MakeSafe.ToSafeInt32(row["InsComCode"]);
                    item.InsComName = MakeSafe.ToSafeString(row["InsComName"]);
                    

                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, string mode, InsuranceCompany model)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
               new SqlParameter("@CompanyGI",user.CompanyGuid),
               new SqlParameter("@UserGuid",user.UserGuid),
               new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
               new SqlParameter("@Mode",mode),
                ResponseKey,ResponseStatus
                };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_INSURANCECOMPANY_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<InsuranceCompany> GetInsuranceCompanyDetails(UserBase User, int InsComCode, string mode)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@InsComCode",InsComCode),
                

            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[GET_INSURANCECOMPANY_DETAILS]", sqlParameters);
            return PopulateInsuranceCompanyDetails(dataSet);

        }

        private InsuranceCompany PopulateInsuranceCompanyDetails(DataSet dataSet)
        {
            InsuranceCompany model = new InsuranceCompany();


            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];


                model.InsComCode = MakeSafe.ToSafeInt32(row["InsComCode"]);
                model.InsComName = MakeSafe.ToSafeString(row["InsComName"]);
               
                model.Active = MakeSafe.ToSafeBool(row["IsActive"]);
            }

            return model;
        }

        public async Task<ResponseEntity> InsuranceCompanyDelete(UserBase User, InsuranceCompany model)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),

                        ResponseKey,ResponseStatus
                };

                await _sql.ExecuteNonQueryAsync("[DMS].[SP_INSURANCECOMPANY_DELETE]", sqlParameters, CommandType.StoredProcedure);
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
