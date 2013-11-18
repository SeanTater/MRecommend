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

namespace Movies
{
    public partial class Main : Form
    {
        public DataTable now_playing;
        AutoCompleteStringCollection autocomplete_titles = new AutoCompleteStringCollection();
        AutoCompleteStringCollection autocomplete_actors = new AutoCompleteStringCollection();
        AutoCompleteStringCollection autocomplete_directors = new AutoCompleteStringCollection();
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            search_type_combobox.SelectedIndex = 0;
            switch (search_type_combobox.SelectedIndex)
            { 
                case 0:
                    foreach (DataRow dr in Movies.ORM.query("SELECT Title from movie").Rows)
                    {
                        autocomplete_titles.Add(dr[0].ToString());
                    }
                    search_textbox.AutoCompleteMode = AutoCompleteMode.Suggest;
                    search_textbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    search_textbox.AutoCompleteCustomSource = autocomplete_titles;
                    break;
                case 1:
                    foreach (DataRow dr in Movies.ORM.query("SELECT Fname,Lname FROM person p,actor a WHERE p.SSN=a.SSN").Rows) {
                            autocomplete_actors.Add(dr[0].ToString()+" "+dr[1].ToString());
                    }
                    search_textbox.AutoCompleteMode = AutoCompleteMode.Suggest;
                    search_textbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    search_textbox.AutoCompleteCustomSource = autocomplete_actors;
                    break;
                case 2:
                    foreach (DataRow dr in Movies.ORM.query("SELECT Fname,Lname FROM person p,director d WHERE p.SSN=d.SSN").Rows)
                    {
                        autocomplete_directors.Add(dr[0].ToString()+" "+dr[1].ToString());
                    }
                    search_textbox.AutoCompleteMode = AutoCompleteMode.Suggest;
                    search_textbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    search_textbox.AutoCompleteCustomSource = autocomplete_directors;
                    break;
            }

            now_playing = Movies.ORM.query("SELECT distinct m.filmID,m.Title,m.MoviePoster FROM now_playing np,movie m WHERE np.filmID=m.filmID");
            get_now_playing(0);
            
        }
        public void get_now_playing(int index)
        {
            Boolean flag = false;
            int i=0 ;
            for (i = index % 4; (i < 4); i++)
            {
                if ((index + i < now_playing.Rows.Count) && (index + i >= 0))
                {
                    flag = true;
                    int temp = index + i;
                    //MessageBox.Show("coming inside the loop "+temp);
                    DataRow dr = now_playing.Rows[index + i];
                    byte[] image_bytes = (byte[])dr[2];
                    MemoryStream ms = new MemoryStream(image_bytes);
                    System.Drawing.Bitmap img = new System.Drawing.Bitmap(ms);
                    switch (i)
                    {
                        case 0:
                            movie_cover_0.Image = img;
                            movie_cover_0.Tag = dr[0];
                            break;
                        case 1:
                            movie_cover_1.Image = img;
                            movie_cover_1.Tag = dr[0];
                            break;
                        case 2:
                            movie_cover_2.Image = img;
                            movie_cover_2.Tag = dr[0];
                            break;
                        case 3:
                            movie_cover_3.Image = img;
                            movie_cover_3.Tag = dr[0];
                            break;
                    }
                }
            }
            if (flag)
            {
                previous_now_playing_button.Tag = index + i;
                next_now_playing_button.Tag = index + i;
            }
            if (index + i -8< 0)
            {
                previous_now_playing_button.Enabled = false;
            }
            else if (index + i - 8 >= 0)
            {
                previous_now_playing_button.Enabled = true;
            
            }
            if(index + i > now_playing.Rows.Count)
            {
                next_now_playing_button.Enabled = false;
            }
            else if( index + i <= now_playing.Rows.Count)
            {
                next_now_playing_button.Enabled = true;
            }
        }
        private void login(object sender, EventArgs e)
        {
            Login f2 = new Login("login");
            f2.Show();
            this.Hide();
        }

        private void register(object sender, EventArgs e)
        {
            Login f2 = new Login("register");
            f2.Show();
            this.Hide();
        }

        private void search(object sender, EventArgs e)
        {
            switch (search_type_combobox.SelectedIndex)
            { 
                case 0:
                    //movies
                    SearchDisplay f3_movies = new SearchDisplay(0,search_textbox.Text);
                    //MessageBox.Show("coming here 1");
                    f3_movies.Show();
                    break;
                case 1:
                    //actor
                    SearchDisplay f3_actors = new SearchDisplay(1, search_textbox.Text);
                    //MessageBox.Show("coming here 2");
                    f3_actors.Show();
                    break;
                case 2:
                    //directors
                    SearchDisplay f3_directors = new SearchDisplay(2, search_textbox.Text);
                    //MessageBox.Show("coming here 3");
                    f3_directors.Show();
                    break;
                default:
                    break;
            }
        }

        private void select_box_0(object sender, EventArgs e)
        {
            //go to movies page
            Movies.MovieHome mh = new Movies.MovieHome(movie_cover_0.Tag.ToString(), "0000000");
            mh.Show();
        }

        private void select_box_1(object sender, EventArgs e)
        {
            //go to movies page
            Movies.MovieHome mh = new Movies.MovieHome(movie_cover_1.Tag.ToString(), "0000000");
            mh.Show();
        }

        private void select_box_2(object sender, EventArgs e)
        {
            //go to movies page
            Movies.MovieHome mh = new Movies.MovieHome(movie_cover_2.Tag.ToString(), "0000000");
            mh.Show();
        }

        private void select_box_3(object sender, EventArgs e)
        {
            Movies.MovieHome mh = new Movies.MovieHome(movie_cover_3.Tag.ToString(), "0000000");
            mh.Show();
        }

        private void fill_autocomplete(object sender, EventArgs e)
        {
            try
            {
                switch (search_type_combobox.SelectedIndex)
                {
                    case 0:
                        foreach (DataRow dr in Movies.ORM.query("SELECT Title FROM movie").Rows)
                        {
                            autocomplete_titles.Add(dr[0].ToString());
                        }
                        search_textbox.AutoCompleteMode = AutoCompleteMode.Suggest;
                        search_textbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        search_textbox.AutoCompleteCustomSource = autocomplete_titles;
                        break;
                    case 1:
                        foreach (DataRow dr in Movies.ORM.query("SELECT Fname,Lname FROM person p,actor a WHERE p.SSN=a.SSN").Rows)
                        {
                            autocomplete_actors.Add(dr[0].ToString() + " " + dr[1].ToString());
                        }
                        search_textbox.AutoCompleteMode = AutoCompleteMode.Suggest;
                        search_textbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        search_textbox.AutoCompleteCustomSource = autocomplete_actors;
                        break;
                    case 2:
                        foreach (DataRow dr in Movies.ORM.query("SELECT Fname,Lname FROM person p,director d WHERE p.SSN=d.SSN").Rows)
                        {
                            autocomplete_directors.Add(dr[0].ToString() + " " + dr[1].ToString());
                        }
                        search_textbox.AutoCompleteMode = AutoCompleteMode.Suggest;
                        search_textbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        search_textbox.AutoCompleteCustomSource = autocomplete_directors;
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void scroll_forward(object sender, EventArgs e)
        {
            try
            {
                get_now_playing((int)next_now_playing_button.Tag);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void scroll_backward(object sender, EventArgs e)
        {
            try
            {
               // MessageBox.Show("coming here" + (int)button4.Tag);
                get_now_playing(((int)next_now_playing_button.Tag) - 8);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
