using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    class Appointment
    {
        public int appointmentid { get; set; }
        public DateTime appointmentdateandtime { get; set; }
        public string appointmentStatus { get; set; }
        public int receptionistid { get; set; }
        public int patientid { get; set; }
        public int docid { get; set; }
     
        public int appointmentno { get; set; }

        public void sheduleAppointment(Appointment appointment)
        {
            string sql = "insert into Appointments(appointmentdateandtime, appointmentStatus, patientid, docid,  appointmentno) " +
                        "values (@appointmentdateandtime, @appointmentStatus, @patientid, @docid, @appointmentno)";

            using (SqlConnection connection = new SqlConnection(Data.cs)) //parameterizing the values
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@appointmentdateandtime", appointment.appointmentdateandtime);
                cmd.Parameters.AddWithValue("@appointmentStatus", appointment.appointmentStatus);
                cmd.Parameters.AddWithValue("@patientid", appointment.patientid);
                cmd.Parameters.AddWithValue("@docid", appointment.docid);
                cmd.Parameters.AddWithValue("@appointmentno", appointment.appointmentno);



                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
}
