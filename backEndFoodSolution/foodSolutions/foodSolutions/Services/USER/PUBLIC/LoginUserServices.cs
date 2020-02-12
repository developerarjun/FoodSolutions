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
    public class LoginUserServices : ILoginUserServices
    {
        public LoginUser checkUser(LoginUser loginUser)
        {
            DataSet ds = new DataSet();
            LoginUser objLogin = new LoginUser();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@username", loginUser.userName);
                param[1] = new SqlParameter("@password", loginUser.password);
                ds = DBConnectionSQL.gettable("getLoginUser", param);
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
