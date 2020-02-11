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
    public class UserRegisterServices : IUserRegisterServices
    {
        public bool saveUserDetails(User user)
        {
            SqlConnection conn = DBConnectionSQL.getConnection();
            using (conn)
            {
                SqlTransaction tran;
                tran = conn.BeginTransaction();
                try
                {
                    SqlCommand cmd;
                    cmd = new SqlCommand("user_register", conn, tran);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = user._id ;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar,100).Value = user.email;
                    cmd.Parameters.Add("@firstname", SqlDbType.VarChar,100).Value = user.firstName;
                    cmd.Parameters.Add("@middlename", SqlDbType.VarChar, 100).Value = user.middleName;
                    cmd.Parameters.Add("@lastname", SqlDbType.VarChar,100).Value = user.lastName;
                    cmd.Parameters.Add("@phonenumber", SqlDbType.VarChar, 100).Value = user.phoneNumber;
                    cmd.Parameters.Add("@shift", SqlDbType.VarChar, 100).Value = user.shift;
                    cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                     cmd.ExecuteNonQuery();
                    user._id = (int)cmd.Parameters["@id"].Value;
                    cmd = new SqlCommand("ins_register_user", conn, tran);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = user._id;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar,100).Value = user.userName;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar,100).Value = user.password;
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return false;
                    throw new Exception("Error" + ex.Message);
                }
                return true;
            }
        }
    }
}
