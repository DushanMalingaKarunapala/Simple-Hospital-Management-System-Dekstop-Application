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
    
    

    public partial class Admin : Form
    {
        public string _selectedresourcetype;
        int adminID = Login.LoggedInAdministratorId;
        public int _selecteddoctorid;

        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            int adminId = adminID; // Retrieve the admin's ID from the variable

            // pass the adminid to the getadminnamebyid method and save it in a string variable
            string adminName = GetAdminNameById(adminId); 

            lblwelcome.Text = "Welcome  "  + adminName;

        }

        // method to get the name of the admin based on the logged in admin
        private string GetAdminNameById(int adminId) // excepts adminid as a parameter
        {
            string adminName = string.Empty;

            using (SqlConnection connection = new SqlConnection(Data.cs))
            {
                connection.Open();
                string query = "SELECT name FROM Administrator WHERE id = @adminId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@adminId", adminId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            adminName = reader["name"].ToString();
                        }
                    }
                }
            }

            return adminName;
        }












        private void btnlogout_Click(object sender, EventArgs e)
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
                addAdminFormPanel,
                panelAddReceptionistForm,
                panelAddDoctorsForm,
                panelAddLaboratorists,
                paneladminAddResources,
                panelManageDoctors,
            };

            //hide all panels ad default
            foreach(var panel in allPanels)
            {
                panel.Visible = false;
            }

            //show the desired panel only
            
            panelToShow.Visible = true;


        }

        private void guna2Button3_Click(object sender, EventArgs e) // when button add new administrator is clicked in the admin form side menu panel
        {
            //Addadmin addadmin = new Addadmin();
            //addadmin.Show();
            //this.Hide();

            //panelAddDoctorsForm.Visible = false;
            //panelAddReceptionistForm.Visible = false;
            //addAdminFormPanel.Visible = true;
            ShowPanel(addAdminFormPanel);
        }

        private void btnaddAdministrator_Click(object sender, EventArgs e) //when add administrator button clicked in the admin form panel
        {
             bool DataValid()
            {
                if (txtboxadminUsername.Text == "")
                {
                    MessageBox.Show("User name cannot be empty!");
                    return false;
                }
                if (txtboxadminPassword.Text == "")
                {
                    MessageBox.Show("Password cannot be empty");
                    return false;
                }

                return true;
            }



            if (DataValid())
            {
                try
                {
                    Administrator admin = new Administrator();
                    admin.name = txtboxadminName.Text;
                    admin.username = txtboxadminUsername.Text;
                    admin.password = txtboxadminPassword.Text;
                    admin.status = txtboxadminStatus.Text;

                    admin.addAdministrator(admin);
                    MessageBox.Show("Administrator Added Successfully");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }





        private void btnaddDoctorsideMenu_Click(object sender, EventArgs e) // when the adddoctor button is clicked in the admin side menu panel
        {
            ShowPanel(panelAddDoctorsForm);// pass the required panel to the show panel method

            //panelAddReceptionistForm.Visible = false;
            //addAdminFormPanel.Visible = false;
            //panelAddDoctorsForm.Visible = true;
        }


        private void btnaddDoctor_Click(object sender, EventArgs e) // when the add doctor button in the add doctor panel form is clicked, this method will work
        {


            bool DataValid()
            {
                if (txtboxUsername.Text == "")
                {
                    MessageBox.Show("User name cannot be empty!");
                    return false;
                }
                if (txtboxPassword.Text == "")
                {
                    MessageBox.Show("Password cannot be empty");
                    return false;
                }

                return true;
            }




            if (DataValid())
            {

                try
                {
                    Doctors doctor = new Doctors();
                    doctor.name = txtboxName.Text;
                    doctor.username = txtboxUsername.Text;
                    doctor.password = txtboxPassword.Text;
                    doctor.specialization = txtboxSpecialization.Text;
                    doctor.expertize = txtboxExpertize.Text;
                    doctor.qualifications = txtboxQualifications.Text;
                    doctor.contact = txtboxContact.Text;
                    doctor.shedule = txtBoxShedule.Text;
                    doctor.location = txtboxLocation.Text;

                    doctor.addDoctor(doctor);
                    MessageBox.Show("Doctor Added Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }




            }

        }





        private void guna2Button4_Click(object sender, EventArgs e)// when add reception button clicked in the admin menu side panel
        {

            //addAdminFormPanel.Visible = false;
            //panelAddDoctorsForm.Visible = false;

            //panelAddReceptionistForm.Visible = true;

            ShowPanel(panelAddReceptionistForm);
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            panelAddReceptionistForm.Visible = false;
            addAdminFormPanel.Visible = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e) //save new receptionist when addreceptionist button clicked
        {

            bool DataValid()
            {
                if (txtboxReceptionistUsername.Text == "")
                {
                    MessageBox.Show("User name cannot be empty!");
                    return false;
                }
                if (txtboxReceptionistPassword.Text == "")
                {
                    MessageBox.Show("Password cannot be empty");
                    return false;
                }

                return true;
            }






            if (DataValid())
            {
                try
                {
                    Receptionists receptionist = new Receptionists();
                    receptionist.name = txtboxReceptionistName.Text;
                    receptionist.username = txtboxReceptionistUsername.Text;
                    receptionist.password = txtboxReceptionistPassword.Text;
                    receptionist.status = txtboxReceptionistStatus.Text;
                  

                    receptionist.addReceptionists(receptionist);
                    MessageBox.Show("Receptionist Added Successfully");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void btnadminAddLaboraroristSideMenu_Click(object sender, EventArgs e)
        {
            ShowPanel(panelAddLaboratorists);
        }




        private void btnaddLaboratoristForm_Click(object sender, EventArgs e) //save new laborarorist when addlaboratorist button clicked
        {
            bool DataValid()
            {
                if (txtboxLaboUsername.Text == "")
                {
                    MessageBox.Show("User name cannot be empty!");
                    return false;
                }
                if (txtboxLaboPassword.Text == "")
                {
                    MessageBox.Show("Password cannot be empty");
                    return false;
                }

                return true;
            }


            if (DataValid())
            {
                try
                {
                    LabTechnicians labTechnician = new LabTechnicians();
                    labTechnician.name = txtboxLaboName.Text;
                    labTechnician.username = txtboxLaboUsername.Text;
                    labTechnician.password = txtboxLaboPassword.Text;
                    labTechnician.Contact = txtboxLaboContact.Text;


                    labTechnician.addLabTechnician(labTechnician);
                    MessageBox.Show("Laboratorist Added Successfully");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }




        }


        // manage resources functionality
       

        private void btnaddResourcessideMenu_Click(object sender, EventArgs e)
        {
            ShowPanel(paneladminAddResources);

            
        }



       

        private void ResourcetypeSelection()
        {
            string selectedresourceType = comboboxResourceType.SelectedItem.ToString();

            

            switch (selectedresourceType)
            {
                case "Ventilators":
                    lblstatus.Text = "Ventilator Status:";
                    lbldescription.Text = "Ventilator Description:";
                    break;
                case "Beds":
                    lblstatus.Text = "Bed Status:";
                    lbldescription.Text = "Bed Description:";
                    break;
                


            }

            _selectedresourcetype = selectedresourceType;

            // Reset other UI elements as needed
            txtboxItemStatus.Text = "";   // Clear the TextBox for status
            txtboxItemDes.Text = "";      // Clear the TextBox for description
        }

        private void comboboxResourceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResourcetypeSelection();
            
        }


        private void SaveToBedsTable(string status, string description)
        {

            using (SqlConnection connection = new SqlConnection(Data.cs))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Beds(bedstatus, beddescription,id) VALUES (@bedstatus, @beddescription,@id)", connection);

                command.Parameters.AddWithValue("@bedstatus", status);
                command.Parameters.AddWithValue("@beddescription", description);
                command.Parameters.AddWithValue("@id", adminID);


                command.ExecuteNonQuery();
            }
        }

        private void SaveToVentilatorsTable(string status, string description)
        {
            using (SqlConnection connection = new SqlConnection(Data.cs))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Ventilators(status, Description,id) VALUES (@status, @Description,@id)", connection);

                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@id", adminID);


                command.ExecuteNonQuery();
            }
        }

        private void btnaddResource_Click(object sender, EventArgs e)
        {
            //string selectedResourceType = comboboxResourceType.SelectedItem.ToString();
            string itemStatus = txtboxItemStatus.Text;
            string description = txtboxItemDes.Text;

            // Perform data validation (e.g., check for empty fields)

            // Save the resource to the respective table based on the selected resource type
            if (_selectedresourcetype == "Beds")
            {
                // Save data to the Beds table
                SaveToBedsTable(itemStatus, description);
            }
            else if (_selectedresourcetype == "Ventilators")
            {
                // Save data to the Ventilators table
                SaveToVentilatorsTable(itemStatus, description);
            }

            // Display a success message or handle any errors
            MessageBox.Show("Resource added successfully!");

            // Reset UI elements after submission
            ResourcetypeSelection();
        }



        //
        //manage doctors functionality
        //


        private void btnManageDoctor_Click(object sender, EventArgs e)
        {
            ShowPanel(panelManageDoctors);
            //LoadDoctorsData();
        }








        private void txtboxsearchdoc_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtboxsearchdoc.Text))
            {
                gridviewdoctors.Rows.Clear();
            }
            else
            {
                SearchDoctors(txtboxsearchdoc.Text);

            }
        }


        //method to search for specific doctors
        private void SearchDoctors(string query)
        {
            
            using (SqlConnection conn = new SqlConnection(Data.cs))
            {
                conn.Open();

                // Using a LIKE query to search for doctors based on specialization.
                // This will match any doctor whose specialization contains the query.
                string sql = "SELECT docid, specialization, location, shedule, expertize, qualifications, contact, name FROM Doctor WHERE specialization LIKE @query OR name LIKE @query";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@query", "%" + query + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Clear the existing rows from your DataGridView
                        gridviewdoctors.Rows.Clear();

                        while (reader.Read())
                        {
                            // Add the results to the DataGridView
                            object[] row = new object[]
                            {
                        reader["docid"],
                        reader["specialization"],
                        reader["location"],
                        reader["shedule"],
                        reader["expertize"],
                        reader["qualifications"],
                        reader["contact"],
                        reader["name"]
                            };

                        gridviewdoctors.Rows.Add(row);
                        }
                    }
                }
            }
        }


        //mehod to load the current data to a textfields when double click on the row
        private void gridviewdoctors_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gridviewdoctors.Rows[e.RowIndex];

                // Retrieve the doctor's data from the selected row
                _selecteddoctorid = Convert.ToInt32(row.Cells["docid"].Value);
                string specialization = row.Cells["specialization"].Value.ToString();
                string location = row.Cells["location"].Value.ToString();
                string shedule = row.Cells["shedule"].Value.ToString();
                string expertize = row.Cells["expertize"].Value.ToString();
                string qualifications = row.Cells["qualifications"].Value.ToString();
                string contact = row.Cells["contact"].Value.ToString();
                string name = row.Cells["name"].Value.ToString();


                



                // Display the captured data in input controls for editing
                txtboxspec.Text = specialization;
                txtboxLoc.Text = location;
                txtboxSched.Text = shedule;
                txtboxExper.Text = expertize;
                txtboxQualifi.Text = qualifications;
                txtboxConta.Text = contact;
                txtboxna.Text = name;



            }
        }


        //method for load the doctor table to gridview  >> 

        //private void LoadDoctorsData()
        //{
        //    using (SqlConnection conn = new SqlConnection(Data.cs))
        //    {
        //        conn.Open();

        //        // Select all doctors from the database
        //        string sql = "SELECT docid, specialization, location, shedule, expertize, qualifications, contact, name FROM Doctor";

        //        using (SqlCommand cmd = new SqlCommand(sql, conn))
        //        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        //        {
        //            DataTable dt = new DataTable();
        //            adapter.Fill(dt);

        //            // Bind the DataTable to the DataGridView
        //            gridviewdoctors.DataSource = dt;
        //        }
        //    }
        //}








        //update doc click method

        private void btnadminUpdatedoc_Click(object sender, EventArgs e)
        {
            // Capture the edited data from the input controls
            int doctorId = _selecteddoctorid; // Use the stored doctor ID
            string specialization = txtboxspec.Text;
            string location = txtboxLoc.Text;
            string shedule = txtboxSched.Text;
            string expertize = txtboxExper.Text;
            string qualifications = txtboxQualifi.Text;
            string contact = txtboxConta.Text;
            string name = txtboxna.Text;

            UpdateDoctorInDatabase(doctorId, specialization, location, shedule, expertize, qualifications, contact, name); //pass the arguments to the updaate doctor method


            // Refresh the DataGridView with the updated data
            

            // Display a success message or handle any errors
            MessageBox.Show("Doctor details updated successfully!");

        }


        private void UpdateDoctorInDatabase(int doctorId, string specialization, string location, string shedule, string expertize, string qualifications, string contact, string name)
        {
            using (SqlConnection con = new SqlConnection(Data.cs))
            {
                con.Open();

                // Construct the SQL UPDATE statement
                string sql = "UPDATE Doctor SET specialization = @specialization, location = @location, shedule = @shedule, expertize = @expertize, qualifications = @qualifications, contact = @contact, name = @name WHERE docid = @doctorId";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@doctorId", doctorId);
                    cmd.Parameters.AddWithValue("@specialization", specialization);
                    cmd.Parameters.AddWithValue("@location", location);
                    cmd.Parameters.AddWithValue("@shedule", shedule);
                    cmd.Parameters.AddWithValue("@expertize", expertize);
                    cmd.Parameters.AddWithValue("@qualifications", qualifications);
                    cmd.Parameters.AddWithValue("@contact", contact);
                    cmd.Parameters.AddWithValue("@name", name);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
