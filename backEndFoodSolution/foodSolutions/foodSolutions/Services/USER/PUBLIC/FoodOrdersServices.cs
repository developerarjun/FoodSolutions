using foodSolutions.COMMON;
using foodSolutions.Model.USER.PUBLIC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace foodSolutions.Services.USER.PUBLIC
{
    public class FoodOrdersServices : IFoodOrdersServices
    {
        public Orders saveFoodOrder(Orders order)
        {
            SqlConnection conn = DBConnectionSQL.getConnection();
            using (conn)
            {
                SqlTransaction tran;
                tran = conn.BeginTransaction();
                try
                {
                    SqlCommand cmd;
                    cmd = new SqlCommand("ins_orders", conn, tran);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@orderBy", SqlDbType.VarChar,100).Value = order.orderBy;
                    cmd.Parameters.Add("@totalAmount", SqlDbType.Float).Value = order.totalPrice;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = order.id;
                    cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    order.id = (int)cmd.Parameters["@id"].Value;
                    foreach (var obj in order.foodOrders)
                    {
                        cmd = new SqlCommand("ins_orders_foods", conn, tran);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@orderId", SqlDbType.Int).Value = order.id;
                        cmd.Parameters.Add("@foodId", SqlDbType.Int).Value = obj.foodId;
                        cmd.Parameters.Add("@quantity", SqlDbType.VarChar, 100).Value = obj.quantity;
                        cmd.Parameters.Add("@totalprice", SqlDbType.Float).Value = obj.price;
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw new Exception("Error" + ex.Message);
                }
                return order;
            }
        }
    }
}
