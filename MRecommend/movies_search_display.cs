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
        private Slot current;
        private int search_type;
        private String searched_data;
        private class Slot
        {
            public Slot(LinkLabel l, DataRow m) {
                label = l;
                movie = m;
            }
            public LinkLabel label;
            public DataRow movie;
        }
        private List<Slot> display_slots;


        public void display_image_n_desp(int slot_index)
        {
            current = display_slots[slot_index];
            byte[] image_bytes = (byte[])current.movie[5];
            MemoryStream ms = new MemoryStream(image_bytes);
            System.Drawing.Bitmap img = new System.Drawing.Bitmap(ms);
            pictureBox1.Image = img;
            pictureBox1.Visible = true;
            label1.Text = (String)current.movie[4];
            label1.Visible = true;
            button1.Visible = true;
        }
        public void display_details(int slot_index)
        {
            Slot slot = display_slots[slot_index];
            slot.label.Visible = true;
            slot.label.Text = (String)slot.movie[1] + " (" + slot.movie[2] + ")";
            if (slot_index == 0)
                display_image_n_desp(slot_index);
        }

        public movies_search_display(int search_type=0, String search_data="")
        {
            this.search_type = search_type;
            this.searched_data = search_data;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            display_slots = new List<Slot>() {
                new Slot(linkLabel1, null),
                new Slot(linkLabel2, null),
                new Slot(linkLabel3, null),
                new Slot(linkLabel4, null),
                new Slot(linkLabel5, null),
                new Slot(linkLabel6, null),
                new Slot(linkLabel7, null),
                new Slot(linkLabel8, null),
                new Slot(linkLabel9, null),
                new Slot(linkLabel10, null)
            };
            try 
            {
                String sql;
                foreach (Slot slot in display_slots) {
                    slot.label.Visible = false;
                }
                pictureBox1.Visible = false;
                label1.Visible = false;
                button1.Visible = false;
                DataRowCollection movies;
                if (search_type == 0) {
                    label6.Text = "Movies";
                    movies = Util.query("SELECT * FROM `movie` WHERE Title LIKE '%" + searched_data + "%'", "movie_by_names").Rows;
                        
                } else if (search_type == 1) {
                    label6.Text = "Actors";
                    String[] name=new String[2];
                    name = searched_data.Split(' ');
                    if (name.Length == 2)
                    {
                        sql = "SELECT DISTINCT m.* FROM person p,actor a, movie m WHERE p.Fname LIKE '%" + name[0] + "%' AND p.Lname LIKE '%" + name[1] + "%' AND p.SSN=a.SSN AND a.filmID=m.filmID";
                    }
                    else 
                    {
                        sql = "SELECT DISTINCT m.* FROM person p,actor a,movie m WHERE (p.Fname LIKE '%" + name[0] + "%' AND p.SSN=a.SSN AND a.filmID=m.filmID)OR(p.Lname LIKE '%" + name[0] + "%' AND p.SSN=a.SSN AND a.filmID=m.filmID)";
                    }
                    movies = Util.query(sql, "movie_by_actors").Rows; 
                } else {
                    label6.Text = "Directors";
                    String[] name1=new String[2];
                    name1 = searched_data.Split(' ');
                    if (name1.Length == 2)
                    {
                        sql = "SELECT DISTINCT m.* FROM person p,director d, movie m WHERE p.Fname LIKE '%" + name1[0] + "%' AND p.Lname LIKE '%" + name1[1] + "%' AND p.SSN=d.SSN AND d.filmID=m.filmID";
                    }
                    else 
                    {
                        sql = "SELECT DISTINCT m.* FROM person p,director a,movie m WHERE (p.Fname LIKE '%" + name1[0] + "%' AND p.SSN=d.SSN AND d.filmID=m.filmID)OR(p.Lname LIKE '%" + name1[0] + "%' AND p.SSN=d.SSN AND d.filmID=m.filmID)";
                    }
                    movies = Util.query(sql, "movie_by_directors").Rows;
                }
                if (movies.Count == 0)
                {
                    MessageBox.Show("Your search did not match any movies.");
                    this.Close();
                }
                else
                {
                    for (int i = 0; i < 10 && i < movies.Count; i++)
                    {
                        display_slots[i].movie = movies[i];
                        display_details(i);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Movies.Movie_HomePage mh = new Movies.Movie_HomePage(current.movie[0].ToString(),"0000000");
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
