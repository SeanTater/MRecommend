using System;
using System.IO;
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
    public partial class movies_search_display : Form
    {
        public DataRow current;
        public int search_type;
        public String searched_data;
        public MySqlDataAdapter my_data_adapter;
        public DataSet my_dataset;
        public DataTable my_data_table;
        private List<LinkLabel> link_labels;


        public void display_image_n_desp(int count)
        {
            
            DataRow dr_new = my_data_table.Rows[count];
            current = dr_new;
            byte[] image_bytes = (byte[])dr_new[5];
            MemoryStream ms = new MemoryStream(image_bytes);
            System.Drawing.Bitmap img = new System.Drawing.Bitmap(ms);
            pictureBox1.Image = img;
            pictureBox1.Visible = true;
            label1.Text = (String)dr_new[4];
            label1.Visible = true;
            button1.Visible = true;
        }
        public void display_details(DataTable data_table, int count)
        {
            DataRow movie = data_table.Rows[count];
            link_labels[count].Visible = true;
            link_labels[count].Text = (String)movie[1] + " (" + movie[2] + ")";
            if (count == 0)
                display_image_n_desp(0);
        }

        public movies_search_display(int search_type=0, String search_data="")
        {
            this.search_type = search_type;
            this.searched_data = search_data;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            link_labels = new List<LinkLabel>() {
                linkLabel1,
                linkLabel2,
                linkLabel3,
                linkLabel4,
                linkLabel5,
                linkLabel6,
                linkLabel7,
                linkLabel8,
                linkLabel9,
                linkLabel10
            };
            try 
            {
                String sql;
                foreach (LinkLabel label in link_labels) {
                    label.Visible = false;
                }
                pictureBox1.Visible = false;
                label1.Visible = false;
                button1.Visible = false;
                switch (search_type)
                {
                    case 0:
                        label6.Text = "Movies";
                        sql = "SELECT * FROM `movie` WHERE Title='" + searched_data + "'";
                        int cnt = 0;
                        my_data_adapter = new MySqlDataAdapter(sql, Util.connect());
                        my_dataset = new DataSet();
                        my_data_table = new DataTable();
                        my_data_adapter.Fill(my_dataset, "movie_by_names");
                        my_data_table = my_dataset.Tables["movie_by_names"];
                        if (my_data_table.Rows.Count == 0)
                        {
                            MessageBox.Show("no movies for the given name exist");
                            movies_database_homepage.mainpage mp = new mainpage();
                            mp.Show();
                            this.Hide();
                        }
                        else 
                        {
                            while ((my_data_table.Rows.Count - cnt) > 0)
                            {
                                display_details(my_data_table, cnt);
                                cnt++;
                            }
                        }
                        
                        break;
                    case 1:
                        label6.Text = "Actors";
                        int cnt1 = 0;
                        String[] name=new String[2];
                        name = searched_data.Split(' ');
                        if (name.Length == 2)
                        {
                            sql = "SELECT DISTINCT m.* FROM person p,actor a, movie m WHERE p.Fname='" + name[0] + "' AND p.Lname='" + name[1] + "' AND p.SSN=a.SSN AND a.filmID=m.filmID";
                        }
                        else 
                        {
                            sql = "SELECT DISTINCT m.* FROM person p,actor a,movie m WHERE (p.Fname='" + name[0] + "' AND p.SSN=a.SSN AND a.filmID=m.filmID)OR(p.Lname='" + name[0] + "' AND p.SSN=a.SSN AND a.filmID=m.filmID)";
                        }
                        my_data_adapter = new MySqlDataAdapter(sql, Util.connect());
                        my_dataset = new DataSet();
                        my_data_table = new DataTable();
                        my_data_adapter.Fill(my_dataset, "movie_by_actors");
                        my_data_table = my_dataset.Tables["movie_by_actors"];
                        int count = my_data_table.Rows.Count;
                        if (count == 0)
                        {
                            MessageBox.Show("no actors for the given name exist");
                            movies_database_homepage.mainpage mp = new mainpage();
                            mp.Show();
                            this.Hide();
                        }
                        else 
                        {
                            while ((my_data_table.Rows.Count - cnt1) > 0)
                            {
                                display_details(my_data_table, cnt1);
                                cnt1++;
                            }
                        }
                        
                        break;
                    case 2:
                        label6.Text = "Directors";
                        int cnt2 = 0;
                        String[] name1=new String[2];
                        name1 = searched_data.Split(' ');
                        if (name1.Length == 2)
                        {
                            sql = "SELECT DISTINCT m.* FROM person p,director d, movie m WHERE p.Fname='" + name1[0] + "' AND p.Lname='" + name1[1] + "' AND p.SSN=d.SSN AND d.filmID=m.filmID";
                        }
                        else 
                        {
                            sql = "SELECT DISTINCT m.* FROM person p,director a,movie m WHERE (p.Fname='" + name1[0] + "' AND p.SSN=d.SSN AND d.filmID=m.filmID)OR(p.Lname='" + name1[0] + "' AND p.SSN=d.SSN AND d.filmID=m.filmID)";
                        }
                        my_data_adapter = new MySqlDataAdapter(sql, Util.connect());
                        my_dataset = new DataSet();
                        my_data_table = new DataTable();
                        my_data_adapter.Fill(my_dataset, "movie_by_directors");
                        my_data_table = my_dataset.Tables["movie_by_directors"];
                        if (my_data_table.Rows.Count == 0)
                        {
                            MessageBox.Show("no directors for the given name exist");
                            movies_database_homepage.mainpage mp = new mainpage();
                            mp.Show();
                            this.Hide();
                        }
                        else
                        {
                            while ((my_data_table.Rows.Count - cnt2) > 0)
                            {
                                display_details(my_data_table, cnt2);
                                cnt2++;
                            }
                        }
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Movies.Movie_HomePage mh = new Movies.Movie_HomePage(current[0].ToString(),"0000000");
            mh.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            display_image_n_desp(0);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            display_image_n_desp(1);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            display_image_n_desp(3);
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            display_image_n_desp(6);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            display_image_n_desp(2);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            display_image_n_desp(5);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            display_image_n_desp(4);
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            display_image_n_desp(7);
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            display_image_n_desp(8);
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            display_image_n_desp(9);
        }
    }
}
