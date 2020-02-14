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
        public Orders getFoodHistory(string userid)
        {
            Orders orders = new Orders();
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@userid", userid);
                ds = DBConnectionSQL.gettable("GetFoodHistory", param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        orders.id = Convert.ToInt32(dr["id"]);
                        orders.orderBy = dr["email_id"].ToString();
                        orders.full_name = dr["full_name"].ToString();
                        orders.is_ready = Convert.ToBoolean(dr["is_ready"]);
                        orders.orderAt = dr["order_at"].ToString();
                        orders.totalPrice = Convert.ToDouble(dr["total_price"]);
                        orders.foodOrders = getFoodOrderDetails(orders.id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
            return orders;
        }
        public List<FoodOrders> getFoodOrderDetails(int orderId)
        {
            List<FoodOrders> lst = new List<FoodOrders>();
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@orderid", orderId);
            ds = DBConnectionSQL.gettable("GetFoodOrder", param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    FoodOrders objATT = new FoodOrders();
                    objATT.foodName = dr["menu_name,"].ToString();
                    objATT.quantity = dr["quantity"].ToString();
                    objATT.price = Convert.ToDouble(dr["price"]);
                    lst.Add(objATT);
                }

            }
            return lst;
        }
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
