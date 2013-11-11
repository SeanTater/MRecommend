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

namespace Movies
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
                    login_register_split.Panel1.Enabled = true;
                    login_register_split.Panel2.Enabled = false;
                }
                else if (called_button.Equals("register"))
                {
                    login_register_split.Panel2.Enabled = true;
                    login_register_split.Panel1.Enabled = false;
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
                String gender = male_radiobutton.Checked ? "Male" : "Female";
                String sql = "INSERT INTO `person`(`Fname`, `Lname`, `SSN`, `gender`) VALUES ('" + first_name_textbox.Text + "','" + last_name_textbox.Text + "','" + ssn_textbox.Text + "','" + gender + "')";
                String sql1 = "INSERT INTO `user`(`username`, `password`, `SSN`) VALUES ('" + register_username_textbox.Text + "','" + register_password_textbox.Text + "','" + ssn_textbox.Text + "')";
                MySqlDataAdapter my_data_adapter = new MySqlDataAdapter();
                my_data_adapter.InsertCommand = new MySqlCommand(sql, Util.connect());
                //my_data_adapter.InsertCommand = new MySqlCommand(sql1, conn);
                if(register_password_textbox.Text.Equals(confirm_register_password_textbox.Text))
                {
                    my_data_adapter.InsertCommand.ExecuteNonQuery();
                    my_data_adapter.InsertCommand = new MySqlCommand(sql1, Util.connect());
                    my_data_adapter.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("User registered.");
                    first_name_textbox.Clear();
                    last_name_textbox.Clear();
                    ssn_textbox.Clear();
                    register_username_textbox.Clear();
                    register_password_textbox.Clear();
                    confirm_register_password_textbox.Clear();
                    male_radiobutton.Checked = false;
                    female_radiobutton.Checked = false;
                    login_register_split.Panel1.Enabled = true;
                    login_register_split.Panel2.Enabled = false;
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
                DataRowCollection users = Movies.Util.query("SELECT * FROM `user` WHERE Username='" + username_textbox.Text + "'").Rows;

                if (users.Count > 0)
                {
                    DataRow user = users[0];
                    if(user["Password"].Equals(password_textbox.Text))
                    {
                        MessageBox.Show("Welcome "+user["Username"]+" ");
                        Movies.UserHomepage uh = new Movies.UserHomepage(user["Username"].ToString());
                        uh.Show();
                        this.Close();

                    }else
                    {
                        MessageBox.Show("Wrong password");
                        password_textbox.Clear();
                    }
                }
                else 
                {
                    MessageBox.Show("Username not found");
                    username_textbox.Clear();
                    password_textbox.Clear();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
 
    }
}
