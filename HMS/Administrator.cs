using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
namespace HMS
{
    class Administrator:User
    {   
        
        public string status { get; set; }







        public void addAdministrator(Administrator administrator)

        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(administrator.password);



            string sql = "insert into Administrator (name,username,password,status) values (@name, @username, @password, @status)"; //parameterized querry


            using (SqlConnection connection = new SqlConnection(Data.cs)) //parameterizing the values
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@name", administrator.name);
                cmd.Parameters.AddWithValue("@username", administrator.username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@status", administrator.status);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            
        }






    }


}
