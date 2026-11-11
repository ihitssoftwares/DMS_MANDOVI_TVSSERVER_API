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
  public   class MCareServiceEntryRepository : IMCareServiceEntryRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public MCareServiceEntryRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<MCareServiceEntry> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid)

                
            };
                var ds = await _sql.GetDataSetAsync("[MCARE].[SP_MCARE_SERVICE_ENTRY_LIST]", sqlparameters);
                return GetList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MCareServiceEntry GetList(DataSet dataSet)
        {
            MCareServiceEntry model = new MCareServiceEntry();
            List<MCareServiceEntry> List = new List<MCareServiceEntry>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new MCareServiceEntry();

                    item.RegEntryCode = MakeSafe.ToSafeInt32(row["RegEntryCode"]);
                    item.McareEntryNo = MakeSafe.ToSafeString(row["McareEntryNo"]);
                    item.CustomerCode = MakeSafe.ToSafeInt32(row["CustomerCode"]);        
                    item.Customer = MakeSafe.ToSafeString(row["Customer"]);
                    item.VehiRegNo = MakeSafe.ToSafeString(row["VehiRegNo"]);
                    item.BuyDate = MakeSafe.ToSafeString(row["BuyDate"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.Variant = MakeSafe.ToSafeString(row["Variant"]);
                    item.Color = MakeSafe.ToSafeString(row["Color"]);
                    item.PlanCode = MakeSafe.ToSafeString(row["PlanCode"]);
                    item.PlanName = MakeSafe.ToSafeString(row["PlanName"]);
                    item.Amount = MakeSafe.ToSafeInt32(row["Amount"]);



                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }


        public async Task<PopUpDetails> GetPopupDetails(UserBase user, int RegEntryCode, int CustomerCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@RegEntryCode",RegEntryCode),
                new SqlParameter("@CustomerCode",CustomerCode),


            };
            var ds = await _sql.GetDataSetAsync("[MCARE].[SP_MCARE_SERVICE_ENTRY_DETAILS_LIST]", sqlparameters);

            return PopulateGetBayDetails(ds);

        }
        public PopUpDetails PopulateGetBayDetails(DataSet ds)
        {

            PopUpDetails model = new PopUpDetails();
            List<PopUpDetails> List = new List<PopUpDetails>();
            List<PopUpDetails> ViewList = new List<PopUpDetails>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new PopUpDetails();

                    item.ServiceCode = MakeSafe.ToSafeInt32(row["ServiceCode"]);
                    item.Customer = MakeSafe.ToSafeString(row["Customer"]);
                    item.McareEntryNo = MakeSafe.ToSafeString(row["McareEntryNo"]);
                    item.ServiceName = MakeSafe.ToSafeString(row["ServiceName"]);
                    item.Limit = MakeSafe.ToSafeInt32(row["Limit"]);
                    item.Alreadytaken = MakeSafe.ToSafeInt32(row["Alreadytaken"]);
                    item.precentage = MakeSafe.ToSafeInt32(row["precentage"]);
                    item.RegEntryCode = MakeSafe.ToSafeInt32(row["RegistrationEntryCode"]);
                    item.taxtypecode = MakeSafe.ToSafeInt32(row["taxtypecode"]);




                    List.Add(item);
                }
                model.PopUpList = List;
            }
            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    var item = new PopUpDetails();

                    item.ServiceName = MakeSafe.ToSafeString(row["ServiceName"]);
                    item.Description = MakeSafe.ToSafeString(row["Description"]);
                    item.Amount = MakeSafe.ToSafeInt32(row["Amount"]);
                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.ActualServiceCost = MakeSafe.ToSafeDecimal(row["Actual"]);
                    item.InvoiceAmount = MakeSafe.ToSafeDecimal(row["Invoice"]);
                    item.DiscountAmt = MakeSafe.ToSafeDecimal(row["Discount"]);
                    item.NetAmount = MakeSafe.ToSafeDecimal(row["NetAmt"]);
                    item.TaxSum = MakeSafe.ToSafeDecimal(row["Tax"]);




                    ViewList.Add(item);
                }
                model.ViewList = ViewList;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, MCareServiceEntry model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[MCARE].[SP_MCARE_SERVICE_ENTRY_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
        public async Task<PopUpDetails> ViewDetails(UserBase user,int ServiceCode ,int RegCode )
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@ServiceCode",ServiceCode),
                 new SqlParameter("@RegCode",RegCode),


            };
                var ds = await _sql.GetDataSetAsync("[MCARE].[SP_MCARE_SERVICE_ENTRY_VIEW_DETAILS]", sqlparameters);
                return ViewDetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private PopUpDetails ViewDetails(DataSet dataSet)
        {
            PopUpDetails model = new PopUpDetails();
            List<PopUpDetails> List = new List<PopUpDetails>();



            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new PopUpDetails();

                    item.ServiceCode = MakeSafe.ToSafeInt32(row["ServiceCode"]);
                    item.Customer = MakeSafe.ToSafeString(row["Customer"]);
                    item.McareEntryNo = MakeSafe.ToSafeString(row["McareEntryNo"]);
                    item.ServiceName = MakeSafe.ToSafeString(row["ServiceName"]);
                    item.Limit = MakeSafe.ToSafeInt32(row["Limit"]);
                    item.Alreadytaken = MakeSafe.ToSafeInt32(row["Alreadytaken"]);
                    item.precentage = MakeSafe.ToSafeInt32(row["precentage"]);
                    item.RegEntryCode = MakeSafe.ToSafeInt32(row["RegistrationEntryCode"]);
                    item.Description = MakeSafe.ToSafeString(row["Description"]);
                    item.Amount = MakeSafe.ToSafeInt32(row["Amount"]);
                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);



                    List.Add(item);
                }
                model.PopUpList = List;
            }
            return model;

        }
    }
}

