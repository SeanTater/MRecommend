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

namespace Movies
{
    class SearchSlot
    {
        public SearchSlot(LinkLabel l, DataRow m)
        {
            label = l;
            movie = m;
        }
        public LinkLabel label;
        public DataRow movie;
    }
    public partial class SearchDisplay : Form
    {
        private SearchSlot current;
        private List<SearchSlot> display_slots;


        private void display_image_n_desp(SearchSlot slot)
        {
            current = slot;
            byte[] image_bytes = (byte[])current.movie[5];
            MemoryStream ms = new MemoryStream(image_bytes);
            System.Drawing.Bitmap img = new System.Drawing.Bitmap(ms);
            cover_image.Image = img;
            cover_image.Visible = true;
            current_title.Text = (String)current.movie[4];
            current_title.Visible = true;
            view_details_button.Visible = true;
        }
        public void display_details(int slot_index)
        {
            SearchSlot slot = display_slots[slot_index];
            slot.label.Visible = true;
            slot.label.Text = String.Format("{0} ({1})", slot.movie[1], slot.movie[2]);
            if (slot_index == 0)
                display_image_n_desp(slot);
        }

        public SearchDisplay(int search_type=0, String query_string="")
        {
            InitializeComponent();

            display_slots = new List<SearchSlot>() {
                new SearchSlot(display_slot_00, null),
                new SearchSlot(display_slot_01, null),
                new SearchSlot(display_slot_02, null),
                new SearchSlot(display_slot_03, null),
                new SearchSlot(display_slot_04, null),
                new SearchSlot(display_slot_05, null),
                new SearchSlot(display_slot_06, null),
                new SearchSlot(display_slot_07, null),
                new SearchSlot(display_slot_08, null),
                new SearchSlot(display_slot_09, null)
            };
            String sql;
            foreach (SearchSlot slot in display_slots) {
                slot.label.Visible = false;
                slot.label.Links[0].Tag = slot;
            }
            cover_image.Visible = false;
            current_title.Visible = false;
            view_details_button.Visible = false;
            DataRowCollection movies;
            String[] name = new String[2];
            if (search_type == 0) {
                form_title.Text = String.Format("Search for movies named {0}", query_string);
                movies = ORM.query(String.Format("SELECT * FROM `movie` WHERE Title LIKE '%{0}%'", query_string)).Rows;
                        
            } else if (search_type == 1) {
                form_title.Text = String.Format("Search for movies with {0}", query_string);
                name = query_string.Split(' ');
                if (name.Length == 2)
                {
                    sql = String.Format("SELECT DISTINCT m.* FROM person p,actor a, movie m WHERE p.Fname LIKE '%{0}%' AND p.Lname LIKE '%{1}%' AND p.SSN=a.SSN AND a.filmID=m.filmID", name[0], name[1]);
                }
                else 
                {
                    sql = String.Format("SELECT DISTINCT m.* FROM person p,actor a,movie m WHERE (p.Fname LIKE '%{0}%' AND p.SSN=a.SSN AND a.filmID=m.filmID)OR(p.Lname LIKE '%{0}%' AND p.SSN=a.SSN AND a.filmID=m.filmID)", name[0]);
                }
                movies = ORM.query(sql).Rows; 
            } else {
                form_title.Text = String.Format("Search for movies directed by {0}", query_string);
                name = query_string.Split(' ');
                if (name.Length == 2)
                {
                    sql = String.Format("SELECT DISTINCT m.* FROM person p,director d, movie m WHERE p.Fname LIKE '%{0}%' AND p.Lname LIKE '%{1}%' AND p.SSN=d.SSN AND d.filmID=m.filmID", name[0], name[1]);
                }
                else 
                {
                    sql = String.Format("SELECT DISTINCT m.* FROM person p,director a,movie m WHERE (p.Fname LIKE '%{0}%' AND p.SSN=d.SSN AND d.filmID=m.filmID)OR(p.Lname LIKE '%{0}%' AND p.SSN=d.SSN AND d.filmID=m.filmID)", name[0]);
                }
                movies = ORM.query(sql).Rows;
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

        private void view_current_movie_details(object sender, EventArgs e)
        {
            Movies.MovieHome mh = new Movies.MovieHome(current.movie[0].ToString(),"0000000");
            mh.Show();
        }

        private void slot_clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            display_image_n_desp((SearchSlot)e.Link.Tag);
        }
    }
}
