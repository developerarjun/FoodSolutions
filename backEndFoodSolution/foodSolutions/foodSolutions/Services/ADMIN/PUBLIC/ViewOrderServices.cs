using foodSolutions.COMMON;
using foodSolutions.Model.USER.PUBLIC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace foodSolutions.Services.ADMIN.PUBLIC
{
    public class ViewOrderServices : IViewOrderServices
    {
        public Orders getOrderByAdmin()
        {
            Orders orders = new Orders();
            try
            {
                DataSet ds = new DataSet();
                ds = DBConnectionSQL.gettable("GetFoodOrder", null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        orders.id = Convert.ToInt32(dr["id"]);
                        orders.orderBy = dr["email_id"].ToString();
                        orders.full_name = dr["full_name"].ToString();
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
        public List<FoodOrders> getFoodOrderDetails(int orderId) {
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

        public List<Orders> getSalesReport(SalesReport sales)
        {
            List<Orders> lst = new List<Orders>();
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@fromDate", sales.fromDate);
            param[1] = new SqlParameter("@toDate", sales.toDate);
            ds = DBConnectionSQL.gettable("GetSalesReports", param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Orders objATT = new Orders();
                    objATT.orderBy = dr["menu_name,"].ToString();
                    objATT.orderAt = dr["quantity"].ToString();
                    objATT.totalPrice = Convert.ToDouble(dr["price"]);
                    lst.Add(objATT);
                }
            }
            return lst;
        }
    }
}

