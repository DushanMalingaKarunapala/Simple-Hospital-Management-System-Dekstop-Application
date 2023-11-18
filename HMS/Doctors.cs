using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    class Doctors:User
    {
        public int docid { get; set; }
        public string specialization { get; set; }
        public string location { get; set; }
        public string shedule { get; set; }
        public string expertize { get; set; }
        public string qualifications { get; set; }
        public string contact { get; set; }




        public void addDoctor(Doctors doctor)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(doctor.password);

            string sql = "insert into Doctor (name,username,password,specialization,location,shedule,expertize,qualifications,contact) values (@name, @username, @password, @specialization, @location, @shedule, @expertize, @qualifications, @contact)";


            using (SqlConnection connection = new SqlConnection(Data.cs)) //parameterizing the values
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@name", doctor.name);
                cmd.Parameters.AddWithValue("@username", doctor.username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@specialization", doctor.specialization);
                cmd.Parameters.AddWithValue("@location", doctor.location);
                cmd.Parameters.AddWithValue("@shedule", doctor.shedule);
                cmd.Parameters.AddWithValue("@expertize", doctor.expertize);
                cmd.Parameters.AddWithValue("@qualifications", doctor.qualifications);
                cmd.Parameters.AddWithValue("@contact", doctor.contact);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
