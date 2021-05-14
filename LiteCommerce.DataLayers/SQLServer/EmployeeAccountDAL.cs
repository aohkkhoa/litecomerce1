using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers.SQLServer
{
    /// <summary>
    /// cài đặt chức năng liên quan đến tài khoản nhân viên
    /// </summary>
    public class EmployeeAccountDAL : _BaseDAL,IAccountDAL
    {
        public EmployeeAccountDAL(string connectionString) : base(connectionString)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Account Authorze(string loginName, string password)
        {
            Account data = null; 
           using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"SELECT EmployeeID, FirstName, LastName, Email, Photo
                                    FROM Employees
                                    WHERE Email= @loginName and Password = @password";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@loginName", loginName);
                cmd.Parameters.AddWithValue("@password", password);

                using (SqlDataReader dbReader= cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    if (dbReader.Read())
                    {
                        data = new Account()
                        {
                            UserName = dbReader["EmployeeID"].ToString(),
                            FullName = $"{dbReader["FirstName"]} {dbReader["LastName"]}",
                            Email = dbReader["Email"].ToString(),
                            Photo = dbReader["Photo"].ToString()
                        };
                    }
                }
                connection.Close();
            }

            return data;
        }

        public bool ChangePassword(int accountId, string oldpassword, string newpassword)
        {
            int result = 0;
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"UPDATE Employees 
                                    SET Password = @newpassword
                                   WHERE EmployeeID = @accountId AND Password = @oldpassword";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@accountId", accountId);
                cmd.Parameters.AddWithValue("@oldpassword", oldpassword);
                cmd.Parameters.AddWithValue("@newpassword", newpassword);
               
                result = cmd.ExecuteNonQuery();
                cn.Close();
            }
            if (result == 0) return false;
            else return true;
        }

        public Account Get(string accountId)
        {
            Account data = null;
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"SELECT EmployeeID, FirstName, LastName, Email, Photo 
                                    FROM Employees WHERE EmployeeID = @accountId";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@accountId", accountId);
                SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dbReader.Read())
                {
                    data = new Account()
                    {
                        UserName = dbReader["EmployeeID"].ToString(),
                        FullName = $"{dbReader["FirstName"]} {dbReader["LastName"]}",
                        Email = dbReader["Email"].ToString(),
                        Photo = dbReader["Photo"].ToString()
                    };
                }
                cn.Close();

            }
            return data;
        }
    }
}
