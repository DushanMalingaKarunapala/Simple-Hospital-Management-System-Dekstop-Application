using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    class LabTechnicians:User
    {
        public int LabTecID { get; set; }
        public string Contact { get; set; }



        public void addLabTechnician(LabTechnicians labtechnician)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(labtechnician.password);

            string sql = "insert into LabTechnicians (name,username,password,contact) values (@name, @username, @password, @contact)";


            using (SqlConnection connection = new SqlConnection(Data.cs)) //parameterizing the values
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@name", labtechnician.name);
                cmd.Parameters.AddWithValue("@username", labtechnician.username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@contact", labtechnician.Contact);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }


    }
}
