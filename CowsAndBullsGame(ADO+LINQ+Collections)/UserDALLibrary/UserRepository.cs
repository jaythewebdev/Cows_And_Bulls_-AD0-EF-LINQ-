using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using UsersModelLibrary;
using System.Data;




namespace UserDALLibrary
{
    public class UserRepository : IRepo<User, int>
    {
        SqlConnection conn;

        public UserRepository()
        {
            conn = new SqlConnection("Data Source=LAPTOP-1J0KOR9F\\SQLSERVER2023JAI;Integrated Security=true;Initial Catalog=dbCowsAndBulls");
        }

        public User Add(User item)
        {
                SqlCommand cmdAdd = new SqlCommand("proc_InsertData", conn);
                cmdAdd.CommandType = CommandType.StoredProcedure;
                cmdAdd.Parameters.AddWithValue("@username", item.Name);
                cmdAdd.Parameters.AddWithValue("@age", item.Age);
                cmdAdd.Parameters.AddWithValue("@phone", item.Phone);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                int result = cmdAdd.ExecuteNonQuery();
                conn.Close();
                if (result > 0)
                {
                    conn.Open();
                    cmdAdd = new SqlCommand("proc_GetLatestUserDetails", conn);
                    item.Id = Convert.ToInt32(cmdAdd.ExecuteScalar().ToString());
                    conn.Close();
                    return item;
                }
                return null;
            }
        }
    
}
