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
    public class AdminLoginServices : IAdminLoginServices
    {
        private readonly Dictionary<string, AdminLogin> _AdminLogin;
        public AdminLoginServices()
        {
            _AdminLogin = new Dictionary<string, AdminLogin>();
        }
        public AdminLogin LoginIn(AdminLogin admin)
        {
            DataSet ds = new DataSet();
            AdminLogin objLogin = new AdminLogin();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@username", admin.userName);
                param[1] = new SqlParameter("@password", admin.password);
                ds = DBConnectionSQL.gettable("getLoginAdmin", param);
                foreach (DataRow dr in ds.Tables[0].Rows)
                { 
                    objLogin.userName = dr["user_name"].ToString();
                    objLogin.userFullName = dr["full_name"].ToString();
                    objLogin.isLogin = true;
                }
            }
            catch (Exception)
            {
                objLogin.isLogin = false;
                throw;
            }
            return objLogin;
        }
    }
}
