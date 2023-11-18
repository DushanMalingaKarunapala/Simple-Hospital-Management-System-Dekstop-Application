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
    public partial class Login : Form
    {
        public static int LoggedInDoctorId { get; set; }
        public static int LoggedInReceptionistId { get; set; }
        public static int LoggedInAdministratorId { get; set; }
        public static int LoggedInLaboraroristId { get; set; }



        public Login()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private int? LoginValidation(string username, string password) // login validation method
        {   
       
           
            string selectedUserType = loginpageCombobox.SelectedItem.ToString();
            
           
            string query = "";

            switch (selectedUserType)
            {
                case "Administrator":
                    query = "SELECT id, password FROM Administrator WHERE Username = @username";
                    break;
                case "Receptionist":
                    query = "SELECT receptionistid, password FROM Receptionist WHERE Username = @username";
                    break;
                case "Doctor":
                    query = "SELECT docid, password FROM Doctor WHERE Username = @username";
                    break;
                case "Laboratorist":
                    query = "SELECT labTecID, password FROM LabTechnicians WHERE Username = @username";
                    break;
                default:
                    return -1;
            }

            using (SqlConnection con = new SqlConnection(Data.cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    /*cmd.Parameters.AddWithValue("@password", password);*/ // Consider hashing and salting passwords.

                    //con.Open();
                    //int result = (int)cmd.ExecuteScalar();

                    //return result == 1;
                    
                    con.Open();
                    //object result = cmd.ExecuteScalar();
                    //Console.WriteLine(result);
                    //if (result != null)
                    //{
                    //    string hashedPassword = result.ToString();
                    //    return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
                    //}

                    //return false;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashedPassword = reader["password"].ToString();
                            if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                            {
                                if (selectedUserType == "Doctor")
                                {
                                    return (int)reader["docid"];
                                    

                                }
                                else if (selectedUserType == "Receptionist")
                                {
                                    return (int)reader["receptionistid"];


                                }
                                else if (selectedUserType == "Administrator")
                                {
                                    return (int)reader["id"];


                                }
                                else if (selectedUserType == "Laboratorist")
                                {
                                    return (int)reader["labTecID"];


                                }

                            }
                        }
                    }

                    return null; // Indicate unsuccessful login






                }
            }


        }

        private void guna2Button1_Click(object sender, EventArgs e) //login click event method
        {
            if(loginpageCombobox.SelectedItem == null)
            {
                MessageBox.Show("please select a user type first!");
            }
            else
            {
                int? isValid = LoginValidation(txtboxLoginUsername.Text, txtboxLoginPassword.Text);

                if (isValid != null) //if the isvalid var is not null
                {


                    if (loginpageCombobox.SelectedItem.ToString() == "Doctor")
                    {
                        LoggedInDoctorId = isValid.Value;  //initialize the logged in doctor's id to a global variable
                    }
                    else if (loginpageCombobox.SelectedItem.ToString() == "Receptionist")
                    {
                        LoggedInReceptionistId = isValid.Value;  //initialize the logged in receptionist's id to a global variable
                    }
                    else if (loginpageCombobox.SelectedItem.ToString() == "Administrator")
                    {
                        LoggedInAdministratorId = isValid.Value;  //initialize the logged in admin's id to a global variable
                    }
                    else if (loginpageCombobox.SelectedItem.ToString() == "Laboratorist")
                    {
                        LoggedInLaboraroristId = isValid.Value;  //initialize the logged in admin's id to a global variable
                    }

                    // Open the respective form based on the user type
                    switch (loginpageCombobox.SelectedItem.ToString())
                    {
                        case "Administrator":
                            Admin admin = new Admin();
                            admin.Show();
                            this.Hide();
                            break;
                        case "Receptionist":
                            Reception reception = new Reception();
                            reception.Show();
                            this.Hide();
                            break;
                        case "Doctor":
                            Doctor doc = new Doctor();
                            doc.Show();
                            this.Hide();
                            break;
                        case "Laboratorist":
                            LabTechnician labtechnician = new LabTechnician();
                            labtechnician.Show();
                            this.Hide();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            



        }

        private void loginpageCombobox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }
    }
}
