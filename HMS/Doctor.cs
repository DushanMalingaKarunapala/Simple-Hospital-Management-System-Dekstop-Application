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
    public partial class Doctor : Form
    {
        public int _selectedPatientId;
        int doctorId = Login.LoggedInDoctorId;
        public int _selectedMedicineID;
        public int _currentEMRRecordId;
        public Doctor()
        {
            InitializeComponent();
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            int docid = doctorId;

            string docname = GetDoctorNameById(docid);

            lblwelcomdoc.Text = "Welcome Doctor " + docname;
        }



        private string GetDoctorNameById(int docid) // excepts docid as a parameter
        {
            string docName = string.Empty;

            using (SqlConnection connection = new SqlConnection(Data.cs))
            {
                connection.Open();
                string query = "SELECT name FROM Doctor WHERE docid = @docid";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@docid", docid);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            docName = reader["name"].ToString();
                        }
                    }
                }
            }

            return docName;
        }
















        private void btndocLogout_Click(object sender, EventArgs e)
        {
                Login login = new Login();
                login.Show();
                this.Close();
            
        }



        private void ShowPanel(Panel panelToShow) // a function to show pass the panels to a list and show them only when clicked , if not clicked everyt panel will be hidden
        {
            //list of all panels in admin form

            List<Panel> allPanels = new List<Panel>()
            {
                paneldocTodayAppo,
                paneldocaddMedicationstoPatient,
                paneldocScheduleOperations,
                paneldocAdmitPatients,
                panedocViewEMR,


            };

            //hide all panels ad default
            foreach (var panel in allPanels)
            {
                panel.Visible = false;
            }

            //show the desired panel only

            panelToShow.Visible = true;


        }




        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnDocTodayAppointments_Click(object sender, EventArgs e)
        {
            ShowPanel(paneldocTodayAppo);
            doctodayAppointments();

            using (SqlConnection conn = new SqlConnection(Data.cs)) // display the scan types to the combobox when this button is clicked
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT scanID, scanName FROM ScanTypes", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboboxDocSelectScanType.DisplayMember = "scanName";
                comboboxDocSelectScanType.ValueMember = "scanID";
                comboboxDocSelectScanType.DataSource = dt;
            }


        }
        private void doctodayAppointments()
        {

            
            int doctorId = Login.LoggedInDoctorId;
            string query = "SELECT Appointments.appointmentid, Appointments.appointmentStatus, Appointments.patientid, Patients.patientname, Appointments.appointmentno FROM Appointments INNER JOIN Patients ON Appointments.patientid = Patients.patientid WHERE Appointments.appointmentdateandtime = CAST(GETDATE() AS DATE) AND Appointments.docid = @docid ORDER BY Appointments.appointmentno";

            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                try
                {
                    conn.Open();
                    // Create a command object with the connection and the query
                    SqlCommand cmd = new SqlCommand(query, conn);
                    // Add the parameter and its value
                    cmd.Parameters.AddWithValue("@docid", doctorId);


                    // Use the created command with the data adapter
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridviewtodayAppointments.DataSource = dt;
                    


                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //
        //prescribing medications to patients
        //
        private int CreateEMRRecordForPatient(int patientId, int doctorId) // method to create an emr record before 
        {
            int newRecordId = 0;

            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                conn.Open();

                string sql = "INSERT INTO EMR (patientid, docid, diagnosis) OUTPUT INSERTED.recordID VALUES (@patientid, @docid, @diagnosis)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@patientid", patientId);
                    cmd.Parameters.AddWithValue("@docid", doctorId);
                    cmd.Parameters.AddWithValue("@diagnosis", "");  // Set default diagnosis to empty for now, you can update it later

                    // Execute the command and get the newly inserted record ID
                    newRecordId = (int)cmd.ExecuteScalar();
                }
            }

            return newRecordId;
        }


        private void gridviewtodayAppointments_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) // method to enable doctor to select the required patient
        {
            try
            {
                if (e.RowIndex >= 0) // Ensure the row index is valid
                {
                    DataGridViewRow row = gridviewtodayAppointments.Rows[e.RowIndex];

                    int patientId = Convert.ToInt32(row.Cells["patientid"].Value);


                    // Now you have the patient's data, you can use it to populate other controls or save it for later processing.
                    // For example:
                    lbldoubleclick.Text = $"patient:{ patientId}";
                    _selectedPatientId = patientId;
                    _currentEMRRecordId = CreateEMRRecordForPatient(_selectedPatientId, doctorId);


                    // If you have global or class-level variables to hold the selected patient data for later use:
                    //_selectedPatientId = patientId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnSubmitDiagnosis_Click(object sender, EventArgs e) // method to let doctor to add diagnosis info to a selected patient
        {

            DataRowView selectedRow = (DataRowView)comboboxDocSelectScanType.SelectedItem; //get the selected item in the combo box
            string selectedScan = selectedRow["scanName"].ToString(); //initialize the selected row's scanName to and string

            // Check if a patient is selected and a diagnosis has been entered
            if (_selectedPatientId <= 0 || string.IsNullOrWhiteSpace(txtboxDiagnosis.Text))
            {
                MessageBox.Show("Please select a patient and enter a diagnosis before submitting.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                conn.Open();

                // Update the diagnosis for the current EMR record
                string sql = "UPDATE EMR SET diagnosis = @diagnosis, scanname = @scanname WHERE recordID = @recordID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@diagnosis", txtboxDiagnosis.Text.Trim());
                    cmd.Parameters.AddWithValue("@scanname", selectedScan);

                    cmd.Parameters.AddWithValue("@recordID", _currentEMRRecordId); // pass  currently selected value using the gl variable to the  EMR record ID

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Diagnosis updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("There was an error updating the diagnosis.");
                    }
                }
            }
        }







        //----------------------------------
        //add medications functionality
        //------------------------------------





        private void btnmenuMedicaitons_Click(object sender, EventArgs e) //doctor side menu medications button click
        {
            ShowPanel(paneldocaddMedicationstoPatient);
        }

        private void txtboxMedicationSearch_TextChanged(object sender, EventArgs e) //when the medicine searchbar text is changed
        {
            if (string.IsNullOrWhiteSpace(txtboxMedicationSearch.Text))
            {
                gridviewforMedicinesSearch.Rows.Clear();
            }
            else
            {
                SearchMedicines(txtboxMedicationSearch.Text);

            }
        }

        private void SearchMedicines(string query) //medicine search functionality
        {
            // Assuming you're using SQL Server with SqlConnection and SqlCommand.
            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                conn.Open();

                // Using a LIKE query to search for patients.
                // This will match any patient where the name or ID card number contains the query.
                
                string sql = "SELECT MedicineID, MedicineName, Dosage, UnitPrice FROM Medicines WHERE MedicineName LIKE @query OR MedicineID LIKE @query";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@query", "%" + query + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Clear the existing rows from your DataGridView
                        gridviewforMedicinesSearch.Rows.Clear();

                        while (reader.Read())
                        {
                            // Add the results to the DataGridView
                            object[] row = new object[]
                            {
                                reader["MedicineID"],
                                reader["MedicineName"],
                                reader["Dosage"],
                                reader["UnitPrice"],
                            };

                            gridviewforMedicinesSearch.Rows.Add(row);
                        }
                    }
                }
            }
        }

        private void gridviewforMedicinesSearch_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) // method for selecting medicines
        {   
            
            if (e.RowIndex >= 0) // Ensure the row index is valid
            {
                DataGridViewRow row = gridviewforMedicinesSearch.Rows[e.RowIndex];

                int medicineid = Convert.ToInt32(row.Cells["MedicineID"].Value);
                string medicinename = row.Cells["MedicineName"].Value.ToString();
                string dosage = row.Cells["Dosage"].Value.ToString();
                string UnitPrice = row.Cells["UnitPrice"].Value.ToString();

                
                // Now you have the patient's data, you can use it to populate other controls or save it for later processing.
                // For example:
                lblselectedMedicineName.Text = $"Selected : {medicinename}";
                lblselectedPatient.Text = $"patient:{ _selectedPatientId}";
                _selectedMedicineID = medicineid;
                gridviewforMedicinesSearch.DataSource = null;

                // If you have global or class-level variables to hold the selected patient data for later use:
                //_selectedPatientId = patientId;
            }
        }

        private void btnSubmitMedicationforPatient_Click(object sender, EventArgs e)
        {
            if (_selectedPatientId <= 0 || _selectedMedicineID <= 0)
            {
                MessageBox.Show("Please select both a patient and a medicine before prescribing.");
                return;
            }

            string frequency = txtboxMedFrequency.Text.Trim(); // Assuming you have a textbox named txtFrequancy
            string duration = txtboxMedDuration.Text.Trim();   // Assuming you have a textbox named txtDuration
            string dosage = txtboxMedDosage.Text.Trim();   // Assuming you have a textbox named txtDuration


            if (string.IsNullOrEmpty(frequency) || string.IsNullOrEmpty(duration) || string.IsNullOrEmpty(dosage))
            {
                MessageBox.Show("Please specify frequency, duration and dosage for the prescription.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                conn.Open();

                string sql = "INSERT INTO EMRprescriptions (medicationName, Dosage, Frequancy, duration, patientid, docid, recordID) VALUES (@medicationName, @Dosage, @Frequancy, @duration, @patientid, @docid, @recordID)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // I'm assuming you'll fetch the Dosage from the medicine selection. You might need to modify this part to suit your needs.
                    cmd.Parameters.AddWithValue("@medicationName", lblselectedMedicineName.Text);
                    cmd.Parameters.AddWithValue("@Dosage", dosage);
                    cmd.Parameters.AddWithValue("@Frequancy", frequency);
                    cmd.Parameters.AddWithValue("@duration", duration);
                    cmd.Parameters.AddWithValue("@patientid", _selectedPatientId);
                    cmd.Parameters.AddWithValue("@docid", doctorId);
                    cmd.Parameters.AddWithValue("@recordID", _currentEMRRecordId);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Medication prescribed successfully!");
                    }
                    else
                    {
                        MessageBox.Show("There was an error prescribing the medication.");
                    }
                }
            }
        }

        private void btndocAddNewMedicine_Click(object sender, EventArgs e)
        {
            txtboxMedicationSearch.Clear();
            txtboxMedDosage.Clear();
            txtboxMedDuration.Clear();
            txtboxMedFrequency.Clear();
            lblselectedMedicineName.ClearSelection();
            lblselectedPatient.ClearSelection();
        }



        //-------------------------------------------------------------
        //doctor schedule procedures 
        //--------------------------------------------------------------



        private void btndocSideMenuScheduleProcedure_Click(object sender, EventArgs e)
        {
            ShowPanel(paneldocScheduleOperations);
        }

        private void comboBoxProcedureType_MouseClick(object sender, MouseEventArgs e)// event method to bind procedure types to combobox
        {
            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT ProceduresID, Proceduretype FROM Procedures", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxProcedureType.DisplayMember = "Proceduretype";
                comboBoxProcedureType.ValueMember = "ProceduresID";
                comboBoxProcedureType.DataSource = dt;
            }
        }

        private void comboBoxOperationTheater_MouseClick(object sender, MouseEventArgs e) // event method to bind available theaters to combobox
        {
            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT theaterno, theatername FROM Theaters", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxOperationTheater.DisplayMember = "theatername";
                comboBoxOperationTheater.ValueMember = "theaterno";
                comboBoxOperationTheater.DataSource = dt;
            }
        }

        int GetScheduledOperationsCount(DateTime selectedDate, int selectedTheater)//function to get the operations count for selected date and selected theater by the doctor
        {
            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM EMROperations WHERE scheduledDateTime = @selectedDate AND operationtheaternumber = @selectedTheater", conn);
                cmd.Parameters.AddWithValue("@selectedDate", selectedDate.Date);  // Just the date part
                cmd.Parameters.AddWithValue("@selectedTheater", selectedTheater);

                return (int)cmd.ExecuteScalar();

            }
        }


        int GetTheaterBedCount(int selectedTheater) //function to get the bed count of each theater
        {
            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT beds FROM Theaters WHERE theaterno = @selectedTheater", conn);
                cmd.Parameters.AddWithValue("@selectedTheater", selectedTheater);

                return (int)cmd.ExecuteScalar();
            }
        }





        private void btnScheduleOpSubmit_Click(object sender, EventArgs e) //button click event method for sheduleoperations 
        {
            int procedureID = (int)comboBoxProcedureType.SelectedValue;
            int theaterID = (int)comboBoxOperationTheater.SelectedValue;
            DateTime selectedDate = ScheduleOpDatePicker.Value.Date;
            string description = txtBoxScheduleOpDes.Text;

            //int operationNo = GetOperationNumber(selectedDate, theaterID);


            int scheduledOpsCount = GetScheduledOperationsCount(selectedDate, theaterID);

            int bedCount = GetTheaterBedCount(theaterID);

            // Check if the theater is already filled up
            if (scheduledOpsCount >= bedCount)
            {
                MessageBox.Show("Selected theater is already filled up for the selected date. Please select another date or another theater.");
                return; // Exit the method without scheduling
            }
            else
            {
                int operationNo = scheduledOpsCount + 1; //increse the operation num count by 1 to save because there are availble beds in the theater

                using (SqlConnection conn = new SqlConnection(Data.cs)) // and insert the data to the table
                {
                    conn.Open();
                    string sql = "INSERT INTO EMROperations (ProceduresID, scheduledDateTime, operationDescription, docid, patientid, recordID, operationNo, operationtheaternumber) VALUES (@ProceduresID, @scheduledDateTime, @operationDescription, @docid, @patientid, @recordID, @operationNo, @operationtheaternumber)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProceduresID", procedureID);
                        cmd.Parameters.AddWithValue("@scheduledDateTime", selectedDate);
                        cmd.Parameters.AddWithValue("@operationDescription", description);
                        cmd.Parameters.AddWithValue("@docid", doctorId);  // Assuming you have doctorId stored
                        cmd.Parameters.AddWithValue("@patientid", _selectedPatientId); // Assuming _selectedPatientId is the selected patient's ID.
                        cmd.Parameters.AddWithValue("@recordID", _currentEMRRecordId); // Assuming you store the current EMR session's record ID in _currentEMRRecordId.
                        cmd.Parameters.AddWithValue("@operationNo", operationNo);
                        cmd.Parameters.AddWithValue("@operationtheaternumber", theaterID);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Procedure scheduled successfully!");
                        }
                        else
                        {
                            MessageBox.Show("There was an error scheduling the procedure.");
                        }
                    }
                }
            }
            
        }



        //-------------------------------------------------------------------
        //patient room admission functionality
        //-------------------------------------------------------------------


        private void btndocAdmitPatientSideMenu_Click(object sender, EventArgs e)
        {
            ShowPanel(paneldocAdmitPatients);

            //DataTable availableRooms = GetAvailableRooms();// call the getavailablerooms method when the admission side menu button is clicked

            //comboxSelectRoom.DisplayMember = "roomNo";
            //comboxSelectRoom.ValueMember = "roomNo";
            //comboxSelectRoom.DataSource = availableRooms;


            RefreshAvailableRoomsComboBox(); //call the refresh available rooms.. method to refresh the combobox again when the side menu buttoon is clicked
        }




        private DataTable GetAvailableRooms() // method to get availble rooms 
        {
            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                conn.Open();

                string sql = @"
            SELECT r.roomNo, r.beds - ISNULL(COUNT(a.admissionid), 0) AS availableBeds, 
                   + ' Room No ' + CAST(r.roomNo AS NVARCHAR) + ' - ' + CAST((r.beds - ISNULL(COUNT(a.admissionid), 0)) AS NVARCHAR) + ' beds available' AS roomDescription

            FROM Rooms r
            LEFT JOIN EMRRoomAdmission a ON r.roomNo = a.roomNo AND a.roomStatus = 'admitted'
            GROUP BY r.roomNo, r.beds
            HAVING r.beds > ISNULL(COUNT(a.admissionID), 0)
        ";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
                
            } 
            
                
        }

        private void RefreshAvailableRoomsComboBox() //method to refresh the combo box to load available rooms again
        {
            DataTable availableRooms = GetAvailableRooms();

            // Bind the data to the ComboBox
            comboxSelectRoom.DataSource = null; // Clear any previous bindings
            comboxSelectRoom.DisplayMember = "roomDescription";
            comboxSelectRoom.ValueMember = "roomNo";
            comboxSelectRoom.DataSource = availableRooms;
        }


        private void comboxSelectRoom_MouseClick(object sender, MouseEventArgs e)
        {
            
            
                //DataTable availableRooms = GetAvailableRooms();

                //comboxSelectRoom.DisplayMember = "roomNo";
                //comboxSelectRoom.ValueMember = "roomNo";
                //comboxSelectRoom.DataSource = availableRooms;
            

        }

        private void btnAdmitPatient_Click(object sender, EventArgs e)
        {
            int roomNo = (int)comboxSelectRoom.SelectedValue;
            DateTime admitiondate = datetimepickerPatientAdmissionDate.Value.Date;
            DateTime dischargedate = datetimepickerPatientDischargeDate.Value.Date;
            string admissionDescription = txtboxPatienAdmissionDescription.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(Data.cs))
                {
                    conn.Open();
                    string sql = "INSERT INTO EMRRoomAdmission (roomNo, patientid, docid, recordID, roomStatus, admissionDate, dischargeDate,admissionDescription) VALUES (@roomNo, @patientid, @docid, @recordID, 'admitted', @admissionDate,@dischargeDate,@admissionDescription)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@roomNo", roomNo);
                        cmd.Parameters.AddWithValue("@patientid", _selectedPatientId);
                        cmd.Parameters.AddWithValue("@docid", doctorId);
                        cmd.Parameters.AddWithValue("@recordID", _currentEMRRecordId);

                        cmd.Parameters.AddWithValue("@admissionDate", admitiondate);
                        cmd.Parameters.AddWithValue("@dischargeDate", dischargedate);
                        cmd.Parameters.AddWithValue("@admissionDescription", admissionDescription);







                        // Add other parameters as necessary

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Patient admitted successfully!");
                        }
                        else
                        {
                            MessageBox.Show("There was an error admitting the patient.");
                        }
                    }

                    
                    conn.Close();
                    RefreshAvailableRoomsComboBox();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //--------------------------------------------------------
        //doc manage emr functionality
        //---------------------------------------------


        private void btndocpatientEMR_Click(object sender, EventArgs e) //main side menu button clik
        {
            ShowPanel(panedocViewEMR);
            LoadEMRTypes();
        }


        private void LoadEMRTypes()// add items to the combobox
        {
            // Clear any existing items
            comboboxSelectEMRType.Items.Clear();

            // Add EMR types to the combobox
            comboboxSelectEMRType.Items.Add("Prescriptions");
            comboboxSelectEMRType.Items.Add("Operations");
            comboboxSelectEMRType.Items.Add("Room Admission");
            comboboxSelectEMRType.Items.Add("Lab Results");

            // Optionally, select the first item by default
            comboboxSelectEMRType.SelectedIndex = 0;
        }








        private void comboboxSelectEMRType_SelectedIndexChanged(object sender, EventArgs e)// load data based on the selected item
        {

            gridviewEMRPrescriptions.Visible = false;
            gridviewEMROperations.Visible = false;
            gridviewEMRLabResults.Visible = false;
            gridviewEMRRoomAdmissions.Visible = false;
            string selectedEMRType = comboboxSelectEMRType.SelectedItem.ToString();

            switch (selectedEMRType)
            {
                case "Prescriptions":
                    LoadPrescriptionsData();
                    gridviewEMRPrescriptions.Visible = true;
                    break;
                case "Operations":
                    LoadOperationsData();
                    gridviewEMROperations.Visible = true;

                    break;
                case "Room Admission":
                    loadroomadmissiondata();
                    gridviewEMRRoomAdmissions.Visible = true;
                    break;
                case "Lab Results":
                    LoadLabResultsData();
                    gridviewEMRLabResults.Visible = true;
                    break;
            }
        }
         
        private void LoadPrescriptionsData()  //mehtod to fetch emr prescriptions data based on the logged in doctor
        {
            

            int doctorId = Login.LoggedInDoctorId;
            string query = "SELECT * FROM EMRprescriptions WHERE docid = @docid";

            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                try
                {
                    conn.Open();
                    // Create a command object with the connection and the query
                    SqlCommand cmd = new SqlCommand(query, conn);
                    // Add the parameter and its value
                    cmd.Parameters.AddWithValue("@docid", doctorId);


                    // Use the created command with the data adapter
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridviewEMRPrescriptions.DataSource = dt;



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }




        private void LoadOperationsData()  //mehtod to fetch emr operations data based on the logged in doctor
        {
            

            int doctorId = Login.LoggedInDoctorId;
            string query = "SELECT * FROM EMROperations WHERE docid = @docid";

            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                try
                {
                    conn.Open();
                    // Create a command object with the connection and the query
                    SqlCommand cmd = new SqlCommand(query, conn);
                    // Add the parameter and its value
                    cmd.Parameters.AddWithValue("@docid", doctorId);


                    // Use the created command with the data adapter
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridviewEMROperations.DataSource = dt;



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        private void loadroomadmissiondata()  //mehtod to fetch emr room admissions data based on the logged in doctor
        {


            int doctorId = Login.LoggedInDoctorId;
            string query = "SELECT * FROM EMRRoomAdmission WHERE docid = @docid";

            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                try
                {
                    conn.Open();
                    // Create a command object with the connection and the query
                    SqlCommand cmd = new SqlCommand(query, conn);
                    // Add the parameter and its value
                    cmd.Parameters.AddWithValue("@docid", doctorId);


                    // Use the created command with the data adapter
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridviewEMRRoomAdmissions.DataSource = dt;



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        private void LoadLabResultsData()  //mehtod to fetch emr labresults data based on the logged in doctor
        {


            int doctorId = Login.LoggedInDoctorId;
            string query = "SELECT * FROM EMRLabResults WHERE docid = @docid";

            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                try
                {
                    conn.Open();
                    // Create a command object with the connection and the query
                    SqlCommand cmd = new SqlCommand(query, conn);
                    // Add the parameter and its value
                    cmd.Parameters.AddWithValue("@docid", doctorId);


                    // Use the created command with the data adapter
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridviewEMRLabResults.DataSource = dt;



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

       

        //emr records update functionality


    }








}
