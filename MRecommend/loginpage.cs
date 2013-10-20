using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Movies;

namespace movies_database_homepage
{
    public partial class loginpage : Form
    {
        String called_button;
        public loginpage(String called_button)
        {
            this.called_button = called_button;
            InitializeComponent();
           
        }
        public loginpage()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                if (called_button.Equals("login"))
                {
                    splitContainer1.Panel1.Enabled = true;
                    splitContainer1.Panel2.Enabled = false;
                }
                else if (called_button.Equals("register"))
                {
                    splitContainer1.Panel2.Enabled = true;
                    splitContainer1.Panel1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void splitContainer1_Panel1_Paint(object Form2, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object Form2, PaintEventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            mainpage f1 = new mainpage();
            f1.Show();
            this.Hide();
        }

        private void cancelRegisterButton_Click(object sender, EventArgs e)
        {
            mainpage f1 = new mainpage();
            f1.Show();
            this.Hide();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            try 
            {
                String gender = maleRadioButton.Checked ? "Male" : "Female";
                String sql = "INSERT INTO `person`(`Fname`, `Lname`, `SSN`, `gender`) VALUES ('" + firstNameTextBox.Text + "','" + lastNameTextBox.Text + "','" + ssnTextBox.Text + "','" + gender + "')";
                String sql1 = "INSERT INTO `user`(`username`, `password`, `SSN`) VALUES ('" + registerUsernameTextBox.Text + "','" + registerPasswordTextBox.Text + "','" + ssnTextBox.Text + "')";
                MySqlDataAdapter my_data_adapter = new MySqlDataAdapter();
                my_data_adapter.InsertCommand = new MySqlCommand(sql, Util.connect());
                //my_data_adapter.InsertCommand = new MySqlCommand(sql1, conn);
                if(registerPasswordTextBox.Text.Equals(confirmRegisterPasswordTextBox.Text))
                {
                    my_data_adapter.InsertCommand.ExecuteNonQuery();
                    my_data_adapter.InsertCommand = new MySqlCommand(sql1, Util.connect());
                    my_data_adapter.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("User registered.");
                    firstNameTextBox.Clear();
                    lastNameTextBox.Clear();
                    ssnTextBox.Clear();
                    registerUsernameTextBox.Clear();
                    registerPasswordTextBox.Clear();
                    confirmRegisterPasswordTextBox.Clear();
                    maleRadioButton.Checked = false;
                    femaleRadioButton.Checked = false;
                    splitContainer1.Panel1.Enabled = true;
                    splitContainer1.Panel2.Enabled = false;
                }else
                {
                    MessageBox.Show("Passwords do not match");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try 
            {
                DataRowCollection users = Movies.Util.query("SELECT * FROM `user` WHERE Username='" + usernameTextBox.Text + "'").Rows;

                if (users.Count > 0)
                {
                    DataRow user = users[0];
                    if(user["Password"].Equals(passwordTextBox.Text))
                    {
                        MessageBox.Show("Welcome "+user["Username"]+" ");
                        Movies.UserHomepage uh = new Movies.UserHomepage(user["Username"].ToString());
                        uh.Show();
                        this.Close();

                    }else
                    {
                        MessageBox.Show("Wrong password");
                        passwordTextBox.Clear();
                    }
                }
                else 
                {
                    MessageBox.Show("Username not found");
                    usernameTextBox.Clear();
                    passwordTextBox.Clear();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
 
    }
}
