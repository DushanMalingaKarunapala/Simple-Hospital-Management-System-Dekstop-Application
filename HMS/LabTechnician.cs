using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS
{
    public partial class LabTechnician : Form
    {

        int _selectedPatientId;
        int _selecteddoctorId;
        string _selectedPatientname;
        int _selectedEMRRecordId;

        private string _selectedFilePath;
        public LabTechnician()
        {
            InitializeComponent();
        }



        private void btndocLogoutlab_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }





        private void ShowPanel(Panel panelToShow) // a function to show pass the panels to a list and show them only when clicked , if not clicked everyt panel will be hidden
        {
            //list of all panels in laboratorist form

            List<Panel> allPanels = new List<Panel>()
            {
                paneluploadLabResults,
                panelviewScheduledScans,
                
            };

            //hide all panels ad default
            foreach (var panel in allPanels)
            {
                panel.Visible = false;
            }

            //show the desired panel only

            panelToShow.Visible = true;


        }

        private void btnlabViewRequestedScans_Click(object sender, EventArgs e)
        {
            ShowPanel(panelviewScheduledScans);
            scheduledScans();
        }

        private void btnlabUploadLabResults_Click(object sender, EventArgs e)
        {
            ShowPanel(paneluploadLabResults);
        }

        //fetch the emr table 
        private void scheduledScans() //method to  fetch records from the EMR table where scanname is not null and where there is no corresponding result in EMRLabResults. because if there are corresponding relusts in emrlab results which means result is added to the emrlabresults table
        {
            gridviewScheduledScans.ColumnHeadersHeight = 40;
            

            //int doctorId = Login.LoggedInDoctorId;
            string query = @"
    SELECT 
        EMR.recordID, 
        EMR.docid,
        Doctor.name,
        EMR.patientid,
        Patients.patientname, 
        EMR.scanname
    FROM 
        EMR 
    LEFT JOIN 
        EMRLabResults ON EMR.recordID = EMRLabResults.recordID 
    INNER JOIN
        Patients ON EMR.patientID = Patients.patientid
    INNER JOIN
        Doctor ON EMR.docid = Doctor.docid
    WHERE 
        EMRLabResults.resultID IS NULL AND EMR.scanname IS NOT NULL";

            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridviewScheduledScans.DataSource = dt;

                    // Optional: Format grid view for better UI/UX
                    gridviewScheduledScans.Columns["recordID"].HeaderText = "Record ID";
                    gridviewScheduledScans.Columns["docid"].HeaderText = "Requested Doctor's ID";
                    gridviewScheduledScans.Columns["name"].HeaderText = "Requested Doctor's Name";
                    gridviewScheduledScans.Columns["patientid"].HeaderText = "Patient ID";
                    gridviewScheduledScans.Columns["patientname"].HeaderText = "Patient Name";
                    gridviewScheduledScans.Columns["scanname"].HeaderText = "Scan Name";
                    //gridviewScheduledScans.Columns["dateOfScan"].HeaderText = "Date of Scan";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while fetching the scheduled scans: " + ex.Message);
                }
            }
        }

        private void gridviewScheduledScans_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //double click event(when the laboratorist double click on to select patient
        {
            try
            {
                if (e.RowIndex >= 0) // Ensure the row index is valid
                {
                    DataGridViewRow row = gridviewScheduledScans.Rows[e.RowIndex];

                    int patientId = Convert.ToInt32(row.Cells["patientid"].Value);
                    string patientname = Convert.ToString(row.Cells["patientname"].Value);
                    int docid = Convert.ToInt32(row.Cells["docid"].Value);
                    int recordID = Convert.ToInt32(row.Cells["recordID"].Value);

                    // Now you have the patient's data, you can use it to populate other controls or save it for later processing.
                    // For example:
                    lbldoubleclickvalue.Text = $"patient:{ patientname}";
                    _selectedPatientId = patientId;
                    _selecteddoctorId = docid;
                    _selectedPatientname = patientname;
                    _selectedEMRRecordId = recordID;
                    //_currentEMRRecordId = CreateEMRRecordForPatient(_selectedPatientId, doctorId);


                    // If you have global or class-level variables to hold the selected patient data for later use:
                    //_selectedPatientId = patientId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e) //method to upload the lab result 
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png",
                Title = "Select an image"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _selectedFilePath = ofd.FileName;
                pictureBoxResultPreview.Image = new Bitmap(ofd.FileName);
                textBoxImagePath.Text = ofd.FileName;
            }
        }




        private void btnUploadLabResult_Click(object sender, EventArgs e) // method to sumbit the results to the table 
        {

            // Make sure an image is selected
            if (string.IsNullOrWhiteSpace(textBoxImagePath.Text))
            {
                MessageBox.Show("Please select an image first.");
                return;
            }

            // Define the destination directory
            string destinationDirectory = @"D:\programming\HMS\Scanimages"; // Change this path as needed
            string destinationPath = destinationDirectory + Path.GetFileName(textBoxImagePath.Text);

            // Copy the file
            try
            {
                File.Copy(textBoxImagePath.Text, destinationPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copying the file: " + ex.Message);
                return;
            }

            // Now, save the destinationPath to  database
            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                string sql = @"INSERT INTO EMRLabResults (recordID, result, date, patientid, docid, ScanDescription) 
                       VALUES (@recordID, @result, @date, @patientid, @docid, @description)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@recordID", _selectedEMRRecordId); // Assuming you have the selected record's ID
                    cmd.Parameters.AddWithValue("@result", destinationPath);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@patientid", _selectedPatientId); // Assuming you have the selected patient's ID
                    cmd.Parameters.AddWithValue("@docid", _selecteddoctorId); // Assuming you have the logged-in laboratorist's ID
                    cmd.Parameters.AddWithValue("@description", txtboxlabResultDescription.Text);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Result uploaded successfully!");
                    }
                    else
                    {
                        MessageBox.Show("There was an error uploading the result.");
                    }
                }
            }
        }

        
    }
}
