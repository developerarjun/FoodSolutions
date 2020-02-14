using foodSolutions.COMMON;
using foodSolutions.Model.ADMIN.PUBLIC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace foodSolutions.Services.ADMIN.PUBLIC
{
    public class MenuServices : IMenuServices
    {
        private readonly Dictionary<string, Menu> _Menu;
        public MenuServices()
        {
            _Menu = new Dictionary<string, Menu>();
        }

        public bool deleteMenu(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", id);
            int a = DBConnectionSQL.executeProcedure("delete_menu", param);
            if (a > 0)
            {
                return true;
            }
            return false;
        }

        public List<Menu> getMenu()
        {
            List<Menu> lst = new List<Menu>();
            DataSet ds = new DataSet();
            ds = DBConnectionSQL.gettable("GetMenu",null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Menu objATT = new Menu();
                    objATT._id = Convert.ToInt32(dr["id"]);
                    objATT.menuName = dr["menu_name"].ToString();
                    objATT.price = Convert.ToDouble(dr["price"]);
                    objATT.stock = dr["quantity"].ToString();
                    objATT.isAvailable = Convert.ToBoolean(dr["is_available"]);
                    lst.Add(objATT);
                }
            }
            return lst;
        }
        public bool savemenu(List<Menu> menu)
        {
            SqlConnection conn = DBConnectionSQL.getConnection();
            using (conn)
            {
                SqlTransaction tran;
                tran = conn.BeginTransaction();
                try
                {
                    SqlCommand cmd;
                    foreach (var objAtt in menu) {
                        if (objAtt._id != null)
                        {
                            cmd = new SqlCommand("update_menu", conn, tran);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = objAtt._id;
                            cmd.Parameters.Add("@menuname", SqlDbType.VarChar, 100).Value = objAtt.menuName;
                            cmd.Parameters.Add("@price", SqlDbType.Float).Value = objAtt.price;
                            cmd.Parameters.Add("@isavailable", SqlDbType.Bit).Value = objAtt.isAvailable;
                            cmd.Parameters.Add("@stock", SqlDbType.VarChar, 100).Value = objAtt.stock;
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd = new SqlCommand("ins_menu", conn, tran);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@menuname", SqlDbType.VarChar, 100).Value = objAtt.menuName;
                            cmd.Parameters.Add("@price", SqlDbType.Float).Value = objAtt.price;
                            cmd.Parameters.Add("@isavailable", SqlDbType.Bit).Value = objAtt.isAvailable;
                            cmd.Parameters.Add("@stock", SqlDbType.VarChar, 100).Value = objAtt.stock;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return false;
                    throw new Exception("Error" + ex.Message);
                }

            }
            return true;
        }
    }
}
