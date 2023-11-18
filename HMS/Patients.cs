using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    class Patients
    {
        public string patientname { get; set; }
        public string patientNID { get; set; }
        public string patientDob { get; set; }
        public string patientmedicalHistory { get; set; }
        public string patientContact { get; set; }






        public void addPatients(Patients patient)
        {
            string sql = "insert into Patients(patientname,patientNID, patientDob, patientmedicalHistory,patientContact) values (@patientname,@patientNID, @patientDob, @patientmedicalHistory, @patientContact)";

            using (SqlConnection connection = new SqlConnection(Data.cs)) //parameterizing the values
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@patientname", patient.patientname);
                cmd.Parameters.AddWithValue("@patientNID", patient.patientNID);
                cmd.Parameters.AddWithValue("@patientDob", patient.patientDob);
                cmd.Parameters.AddWithValue("@patientmedicalHistory", patient.patientmedicalHistory);
                cmd.Parameters.AddWithValue("@patientContact", patient.patientContact);


                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }

        }
    }

    

}
