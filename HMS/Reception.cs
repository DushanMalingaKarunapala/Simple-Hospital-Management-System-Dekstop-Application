using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS
{
    public partial class Reception : Form
    {

        

        public int _selectedPatientId;
        public int _selectedDoctorId;
        private int? selectedAppointmentId = null;


        public Reception()
        {
            InitializeComponent();
        }



        private void btndocLogoutreception_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }






        private void ShowPanel(Panel panelToShow) // a function to show pass the panels to a list and show them only when clicked , if not clicked everyt panel will be hidden
        {
            //list of all panels in admin form

            List<Panel> allPanels = new List<Panel>()
            {
                panelAddnewPatient,
                panelscheduleAppointmentt,
                panelCurrentAppointments,
                panelforRescheduleConformation,

            };

            //hide all panels ad default
            foreach (var panel in allPanels)
            {
                panel.Visible = false;
            }

            //show the desired panel only

            panelToShow.Visible = true;


        }


        //------------------------------------
        //receptionist add new patient  codes
        //-------------------------------------



        private void btnNewPatientSideMenu_Click(object sender, EventArgs e)
        {
            ShowPanel(panelAddnewPatient);

        }

        private void btnSavePatient_Click(object sender, EventArgs e)
        {

            bool DataValid()
            {
                if (txtboxPatientID.Text == "")
                {
                    MessageBox.Show("Patient ID Cannot be Impty!");
                    return false;
                }
                if (DateTimePickerPatientDOB.Text == "")
                {
                    MessageBox.Show("Patient Date of Birth Cannot be Impty!");
                    return false;
                }

                return true;
            }


            if (DataValid())
            {
                try
                {
                    Patients patient = new Patients();
                    patient.patientname = txtboxPatientName.Text;
                    patient.patientNID = txtboxPatientID.Text;
                    patient.patientDob = DateTimePickerPatientDOB.Text;
                    patient.patientmedicalHistory = txtboxPatientMedHistory.Text;
                    patient.patientContact = txtboxPatientContact.Text;

                    patient.addPatients(patient);
                    MessageBox.Show("Patient Added Sucessfully!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        //--------------------------------------
        //receptionist schedule appointments codes
        //--------------------------------------

        private void btnSheduleAppoSideMenu_Click(object sender, EventArgs e) //when shedule appointment button is clicked
        {
            ShowPanel(panelscheduleAppointmentt);
        }



        //patient search for scheduling appointment
        private void txtboxSearchPatient_TextChanged(object sender, EventArgs e) //when searching for patients
        {
            if (string.IsNullOrWhiteSpace(txtboxSearchPatient.Text))
            {
                patientGridView.Rows.Clear();
            }
            else
            {
                SearchPatients(txtboxSearchPatient.Text);

            }
        }

        private void SearchPatients(string query)
        {
            // Assuming you're using SQL Server with SqlConnection and SqlCommand.
            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                conn.Open();

                // Use a LIKE query to search for patients.
                // This will match any patient where the name or ID card number contains the query.
                // NOTE: Using parameters to prevent SQL injection.
                string sql = "SELECT patientid, patientname, patientNID FROM Patients WHERE patientname LIKE @query OR patientNID LIKE @query";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@query", "%" + query + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Clear the existing rows from your DataGridView
                        patientGridView.Rows.Clear();

                        while (reader.Read())
                        {
                            // Add the results to your DataGridView
                            object[] row = new object[]
                            {
                                reader["patientid"],
                                reader["patientname"],
                                reader["patientNID"]
                            };

                            patientGridView.Rows.Add(row);
                        }
                    }
                }
            }
        }

        private void patientGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) // when the receptionist select a specific user 
        {
            if (e.RowIndex >= 0) // Ensure the row index is valid
            {
                DataGridViewRow row = patientGridView.Rows[e.RowIndex];

                int patientId = Convert.ToInt32(row.Cells["patientid"].Value);
                string patientName = row.Cells["patientname"].Value.ToString();
                string patientNID = row.Cells["patientNID"].Value.ToString();

                // Now you have the patient's data, you can use it to populate other controls or save it for later processing.
                // For example:
                txtboxSearchPatient.Text = $"Selected Patient: {patientName} - {patientNID}";
                _selectedPatientId = patientId;
                patientGridView.DataSource = null;

                // If you have global or class-level variables to hold the selected patient data for later use:
                //_selectedPatientId = patientId;
            }
        }
        //doctor search for scheduling appointment
        private void txtboxSearchDoctor_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtboxSearchDoctor.Text))
            {
                doctorslistview.Items.Clear();
            }
            else
            {
                SearchDoctors(txtboxSearchDoctor.Text);

            }
        }

        private void SearchDoctors(string query)
        {
            // Assuming you're using SQL Server with SqlConnection and SqlCommand.
            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                conn.Open();

                // Use a LIKE query to search for patients.
                // This will match any patient where the name or ID card number contains the query.
                // NOTE: Using parameters to prevent SQL injection.
                string sql = "SELECT docid, name, shedule, specialization FROM Doctor WHERE specialization LIKE @query OR name LIKE @query";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@query", "%" + query + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Clear the existing items from your ListView or DataGridView
                        doctorslistview.Items.Clear();

                        while (reader.Read())
                        {
                            // Add the results to your ListView or DataGridView
                            ListViewItem item = new ListViewItem(reader["docid"].ToString());
                            item.SubItems.Add(reader["name"].ToString());
                            item.SubItems.Add(reader["specialization"].ToString());
                            item.SubItems.Add(reader["shedule"].ToString());

                            doctorslistview.Items.Add(item);
                        }
                    }
                }
            }
        }


        private void doctorslistview_ItemActivate(object sender, EventArgs e)
        {
            

        }

        private void doctorslistview_DoubleClick(object sender, EventArgs e)
        {
            if (doctorslistview.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = doctorslistview.SelectedItems[0]; // Get the first selected item

                int doctorId = Convert.ToInt32(selectedItem.SubItems[0].Text);
                string doctorName = selectedItem.SubItems[1].Text;
                string doctorSpecialization = selectedItem.SubItems[2].Text;
                string doctorSchedule = selectedItem.SubItems[3].Text;

                // Now you have the doctor's data, you can use it to populate other controls, save it for later processing, or continue with the appointment scheduling.
                // For example:
                txtboxSearchDoctor.Text = $"Selected Doctor: {doctorName} - {doctorSpecialization}";
                _selectedDoctorId = doctorId;

                // If you have global or class-level variables to hold the selected doctor data for later use:
                //_selectedDoctorId = doctorId;


                //now after the receptionist select the patient , doctor and appointment status ,
                //appointment date and submit the form the selected patient id(patientid)
                //and selected doctor's id(docid) should be saved in the appointment table.
            }
        }


        public int GetNextAppointmentNumber(int doctorId, DateTime appointmentdateandtime) //generate appointment numbers
        {
            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                conn.Open();
                string sql = "SELECT MAX(appointmentno) FROM Appointments WHERE docid = @docid AND CAST(appointmentdateandtime AS DATE) = @appointmentDate";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@docid", doctorId);
                    cmd.Parameters.AddWithValue("@appointmentDate", appointmentdateandtime.Date);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result) + 1; // Return the next appointment number
                    }
                    else
                    {
                        return 1; // This is the first appointment for this doctor
                    }
                }
            }
        }



        ///appointment payment codes 
        ///

        

        private decimal GetDefaultAppointmentFee() //get the default appointment fee from the configurations table
        {
            using (SqlConnection connection = new SqlConnection(Data.cs))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT value FROM Configurations WHERE keys = 'defaultappointmentFee'", connection);
                return Convert.ToDecimal(command.ExecuteScalar());
            }
        }


        private void InsertAppointmentFeeToBilling(int patientId,  decimal fee ) //insert function for inserting patient appointment or consultation payment data to the billing table
        {
            using (SqlConnection connection = new SqlConnection(Data.cs))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Billing(patientid,date, fee, status, serviceType) VALUES (@patientId, @date, @fee, 'Paid', 'Appointment')", connection);

                command.Parameters.AddWithValue("@patientid", _selectedPatientId);
                command.Parameters.AddWithValue("@date", DateTime.Now);
                command.Parameters.AddWithValue("@fee", fee);

                command.ExecuteNonQuery();
            }
        }









        private void btnSheduleAppoform_Click(object sender, EventArgs e) // when the shedule appointment button is clicked in appoinment form
        {
            int patientid = _selectedPatientId;
            



            int nextAppointmentNumber = GetNextAppointmentNumber(_selectedDoctorId, appointmentDatetime.Value); //pass selected doc id and the selected date to the getnextappointmet function
            DialogResult result = MessageBox.Show($"Confirm appointment with number: {nextAppointmentNumber}?", "Confirm Appointment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Save the appointment

                try
                {
                    Appointment appointment = new Appointment();

                    appointment.docid = _selectedDoctorId; //get the selected doctor id from class level variable
                    appointment.patientid = _selectedPatientId; //get the selected patient id from class level variable
                    appointment.appointmentno = nextAppointmentNumber;
                    appointment.appointmentdateandtime = appointmentDatetime.Value;
                    appointment.appointmentStatus = txtboxAppointmentDescription.Text;

                    appointment.sheduleAppointment(appointment);
                    MessageBox.Show("Appointment scheduled Successfully!");

                    decimal appointmentFee = GetDefaultAppointmentFee();

                    // Insert into Billing or any other appropriate table
                    InsertAppointmentFeeToBilling(patientid, appointmentFee); //pass the patient id and the appoinmentfee to the billing function
                    MessageBox.Show("Patient Charged  Rs " + appointmentFee + " as Consultation Fees");
                }
                catch(Exception ex){

                    MessageBox.Show(ex.Message);
                }
               
            }
            else
            {
                ShowPanel(panelscheduleAppointmentt);
            }

        }


        //------------------------------------
        //receptionist current appointment codes
        //-------------------------------------

        private void PopulateAppointments() //method to populate datagrid view with appoinments data
        {
            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Appointments", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                currentAppodataGridView.DataSource = dt;
            }
        }


        private void btncurrentAppointments_Click(object sender, EventArgs e) // side menu button current appoitnments clicked
        {
            ShowPanel(panelCurrentAppointments);
            PopulateAppointments();
        }

        private void btnAppoReschedule_Click(object sender, EventArgs e)//when button reschedule clicked
        {
            if (currentAppodataGridView.SelectedRows.Count > 0)
            {
                selectedAppointmentId = Convert.ToInt32(currentAppodataGridView.SelectedRows[0].Cells["appointmentid"].Value);
                panelforRescheduleConformation.Visible = true;// Show the rescheduling panel
                panelscheduleAppointmentt.Visible = false;
            }
            else
            {
                MessageBox.Show("Please select an appointment to reschedule.");
            }
        }

        private void btnreschedulenewtimeanddateConfirm_Click(object sender, EventArgs e)
        {
            if (selectedAppointmentId.HasValue)
            {
                DateTime newAppointmentTime = rescheduledateTimePicker.Value;
                int newAppointmentNumber;

                


                // Now update the database with the new appointment time
                using (SqlConnection conn = new SqlConnection(Data.cs))
                {
                    conn.Open();

                    // Check number of appointments on the new date if there are appointments in the new date , 1 will be added to new appointment
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Appointments WHERE CAST(appointmentdateandtime AS DATE) = @newDate", conn))
                    {
                        cmd.Parameters.AddWithValue("@newDate", newAppointmentTime.Date);
                        newAppointmentNumber = (int)cmd.ExecuteScalar() + 1; // Add 1 to get the next available number
                    }

                    // Now, you have the new appointment number in 'newAppointmentNumber'. 
                    // You can use this number in your update command.

                    using (SqlCommand cmd = new SqlCommand("UPDATE Appointments SET appointmentDateAndTime = @newTime, appointmentStatus = 'rescheduled',appointmentno = @newNumber WHERE appointmentid = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@newTime", newAppointmentTime);
                        cmd.Parameters.AddWithValue("@newNumber", newAppointmentNumber);
                        cmd.Parameters.AddWithValue("@id", selectedAppointmentId.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Refresh the DataGridView to show the updated appointment time
                PopulateAppointments();

                panelforRescheduleConformation.Visible = false; // Hide the rescheduling panel
            }
            else
            {
                MessageBox.Show("Unexpected error occurred. Please try again.");
            }
        }

        private void btnreschedulenewtimeanddateCancel_Click(object sender, EventArgs e)//show the appointment panel again if receptionist select to cancel picking a new date and time 
        {
            ShowPanel(panelCurrentAppointments);
        }



        private void btnappoCancel_Click(object sender, EventArgs e) // if receptionist clicked to delete of cancel an appointment
        {
            if (currentAppodataGridView.SelectedRows.Count > 0)
            {
                int appointmentId = Convert.ToInt32(currentAppodataGridView.SelectedRows[0].Cells["appointmentid"].Value);
                if (MessageBox.Show("Are you sure you want to cancel this appointment?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(Data.cs))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE Appointments SET appointmentStatus = 'cancelled' WHERE appointmentid = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", appointmentId);
                            cmd.ExecuteNonQuery();

                            // Refresh the DataGridView to remove the cancelled appointment
                            PopulateAppointments();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to cancel.");
            }
        }

    }
}
