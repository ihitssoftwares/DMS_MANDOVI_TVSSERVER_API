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
    public class ShowroomRentRepository: IShowroomRentRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ShowroomRentRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<ShowroomRent> GetList(UserBase user, int Region, int WorkhoporShowroom)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Region",Region),

                 new SqlParameter("@WorkhoporShowroom",WorkhoporShowroom)



                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SHOWROOM_RENT_LIST]", sqlparameters);
                return WorkhoporShowroomList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private ShowroomRent WorkhoporShowroomList(DataSet dataSet)
        {
            ShowroomRent model = new ShowroomRent();
            List<ShowroomRent> List = new List<ShowroomRent>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ShowroomRent();



                    item.SalesDealerCode = MakeSafe.ToSafeString(row["SalesDealerCode"]);
                    item.RegionName = MakeSafe.ToSafeString(row["RegionName"]);

                    item.RegionCode = MakeSafe.ToSafeInt32(row["RegionCode"]);
                  

                   
                    item.Rent = MakeSafe.ToSafeDecimal(row["Rent"]);

                   



                    List.Add(item);
                }
                model.List = List;
            }

            return model;

        }


        public async Task<ResponseEntity> RentUpdate(UserBase user, ShowroomRent model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_SHOWROOM_RENT_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
