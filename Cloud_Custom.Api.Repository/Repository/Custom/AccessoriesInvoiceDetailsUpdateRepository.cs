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
    public class AccessoriesInvoiceDetailsUpdateRepository : IAccessoriesInvoiceDetailsUpdateRepository
    {

        private readonly ISqlConnectionProvider _sql;
        public AccessoriesInvoiceDetailsUpdateRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<AccessoriesInvoiceDetailsUpdate> GetList(UserBase user,int MonthCode, int BranchCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
       
                new SqlParameter("@MonthCode",MonthCode),
                new SqlParameter("@BranchCode",BranchCode),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_ACCESSORIES_INVOICE_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public AccessoriesInvoiceDetailsUpdate PopulateGetList(DataSet ds)
        {
            AccessoriesInvoiceDetailsUpdate model = new AccessoriesInvoiceDetailsUpdate();
            model.List = new List<AccessoriesInvoiceDetailsUpdate>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new AccessoriesInvoiceDetailsUpdate
                    {
                        DTCode = MakeSafe.ToSafeInt32(row["DTCode"]),
                        InvNo = MakeSafe.ToSafeString(row["InvNo"]),
                        InvoiceDate = MakeSafe.ToSafeDateTime(row["InvoiceDate"]),
                        StoreBranch = MakeSafe.ToSafeString(row["StoreBranch"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),

                        Variant = MakeSafe.ToSafeString(row["Variant"]),
                        Color = MakeSafe.ToSafeString(row["Color"]),
                        Executive = MakeSafe.ToSafeString(row["Executive"]),
                      
                    };

                    model.List.Add(item);
                }
            }

            return model;
        }

        public async Task<AccessoriesInvoiceDetailsUpdate> GetDetails(UserBase user,int DtCode)//create
        {
            IDbDataParameter[] sqlparameters =
           {
                //new SqlParameter("@CompanyGI",user.CompanyGuid),
                //new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@DtCode",DtCode),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_ACCESSORIES_INVOICE_DETAILS]", sqlparameters);

            return PopulateDetails(ds);
        }
        private AccessoriesInvoiceDetailsUpdate PopulateDetails(DataSet ds)
        {

            AccessoriesInvoiceDetailsUpdate model = new AccessoriesInvoiceDetailsUpdate();
            model.List = new List<AccessoriesInvoiceDetailsUpdate>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    
                    var item = new AccessoriesInvoiceDetailsUpdate();


                    item.ItemCode = MakeSafe.ToSafeInt32(row["ItemCode"]);
                    item.SalesAccessoriesPartNumber = MakeSafe.ToSafeString(row["SalesAccessoriesPartNumber"]);
                    item.AccessorieName = MakeSafe.ToSafeString(row["AccessorieName"]);
                    item.Applicability = MakeSafe.ToSafeString(row["Applicability"]);
                    item.PartCategory = MakeSafe.ToSafeString(row["PartCategory"]);
                    item.Qty = MakeSafe.ToSafeInt32(row["Qty"]);
                    item.UnitPrice = MakeSafe.ToSafeDecimal(row["UnitPrice"]);
                    item.CostPrice = MakeSafe.ToSafeInt32(row["CostPrice"]);
                    item.SellingPrice = MakeSafe.ToSafeInt32(row["SellingPrice"]);
                    item.Profit = MakeSafe.ToSafeInt32(row["Profit"]);


                    model.List.Add(item);
                }
                
            }
            //model.List = new List<AccessoriesInvoiceDetailsUpdate>();
            if ((ds.Tables[1]?.Rows?.Count ?? 1) > 0)
            {
                DataRow row = ds.Tables[1].Rows[0];
                model = new AccessoriesInvoiceDetailsUpdate
                {

                    
                  
                    AbsoluteUrl = MakeSafe.ToSafeString(row["ABSOLUTEURI"]),
                    ActaulFileName = MakeSafe.ToSafeString(row["ACTUALFILENAME"]),


                };
            }

            return model;
        }

        public async Task<ResponseEntity> Save(UserBase user, AccessoriesInvoiceDetailsUpdate model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 500, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_ACCESSORIES_INVOICE_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }

    }
}
