using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    class Receptionists : User
    {
        
        public string status { get; set; }


        public void addReceptionists(Receptionists receptionist)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(receptionist.password);

            string sql = "insert into Receptionist (name,username,password,status) values (@name, @username, @password, @status)"; //parameterized querry        }


            using (SqlConnection connection = new SqlConnection(Data.cs)) //parameterizing the values
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@name", receptionist.name);
                cmd.Parameters.AddWithValue("@username", receptionist.username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@status", receptionist.status);
             

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }

}
