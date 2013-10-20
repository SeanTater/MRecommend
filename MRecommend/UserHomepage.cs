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
using System.IO;

namespace Movies
{
    public partial class UserHomepage : Form
    {
        bool action; bool adventure; bool animation; bool biography; bool comedy; bool crime; bool documentary; bool drama;
        bool fantasy; bool horror; bool musical; bool romance; bool scifi; bool sport; bool thriller; bool war;

        String Username = "anton";
        String useridQuery;
        int ssn;
        String reviews;
        String popular;
        String recommended;
        String preferences_sql;
        AutoCompleteStringCollection allmovies;
        public UserHomepage()
        {
            InitializeComponent();
        }

        public UserHomepage(String username)
        {
            this.Username = username;
            ssn = Convert.ToInt32(Util.query(String.Format("Select SSN FROM user WHERE Username='{0}';", Username)).Rows[0][0]);
            preferences_sql = "Select genre FROM Likes WHERE SSN = " + ssn;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string text = searchBox.Text;
            SearchResult sr = new SearchResult(text,ssn);
            sr.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            try
            {
                String genre;
                DataRowCollection preferences = Util.query(preferences_sql).Rows;
                if (preferences.Count > 0)
                {
                    foreach (DataRow dr in preferences)
                    {
                        genre = dr[0].ToString();
                        if (genre == "Action")
                        {
                            action = true;
                            checkBoxAction.CheckState = CheckState.Checked;
                        }
                        if (genre == "Adventure")
                        {
                            adventure = true;
                            checkBoxAdventure.CheckState = CheckState.Checked;
                        }
                        if (genre == "Animation")
                        {
                            animation = true;
                            checkBoxAnimation.CheckState = CheckState.Checked;
                        }
                        if (genre == "Biography")
                        {
                            biography = true;
                            checkBoxBiography.CheckState = CheckState.Checked;
                        }
                        if (genre == "Comedy")
                        {
                            comedy = true;
                            checkBoxComedy.CheckState = CheckState.Checked;
                        }
                        if (genre == "Crime")
                        {
                            crime = true;
                            checkBoxCrime.CheckState = CheckState.Checked;
                        }
                        if (genre == "Documentary")
                        {
                            documentary = true;
                            checkBoxDocumentary.CheckState = CheckState.Checked;
                        }
                        if (genre == "Drama")
                        {
                            drama = true;
                            checkBoxDrama.CheckState = CheckState.Checked;
                        }
                        if (genre == "Fantasy")
                        {
                            fantasy = true;
                            checkBoxFantasy.CheckState = CheckState.Checked;
                        }
                        if (genre == "Horror")
                        {
                            horror = true;
                            checkBoxHorror.CheckState = CheckState.Checked;
                        }
                        if (genre == "Musical")
                        {
                            musical = true;
                            checkBoxMusical.CheckState = CheckState.Checked;
                        }
                        if (genre == "Romance")
                        {
                            romance = true;
                            checkBoxRomance.CheckState = CheckState.Checked;
                        }
                        if (genre == "Sci-Fi")
                        {
                            scifi = true;
                            checkBoxScifi.CheckState = CheckState.Checked;
                        }
                        if (genre == "Sport")
                        {
                            sport = true;
                            checkBoxSport.CheckState = CheckState.Checked;
                        }
                        if (genre == "Thriller")
                        {
                            thriller = true;
                            checkBoxThriller.CheckState = CheckState.Checked;
                        }
                        if (genre == "War")
                        {
                            war = true;
                            checkBoxWar.CheckState = CheckState.Checked;
                        }
                    }

                    panel4.AutoScroll = true;

                    panel3.BackColor = Color.WhiteSmoke;
                    panel3.AutoScroll = true;

                    //Point loc = new Point(5,5);
                    int i = 0;
                    DataRowCollection popular_movies = Movies.Util.query("SELECT DISTINCT m.title FROM movie m,recommend r WHERE m.filmID=r.filmID AND Avg_rating>=7.5 GROUP BY m.title HAVING COUNT(*)>=2").Rows);
                    foreach (DataRow movie in popular_movies)
                    {
                        string title = movie[0].ToString();
                        LinkLabel l = new LinkLabel();
                        panel3.Controls.Add(l);
                        l.Name = title;
                        l.Location = new Point(l.Location.X, 18 * i);
                        //l.Height = 12;
                        //l.Width = 150;
                        //l.Location 
                        //loc += 5;
                        //loc.Y += l.Height + 5;
                        l.Text = title;
                        l.AutoSize = true;
                        l.Links.Add(0, l.Text.Length, l.Text);
                        l.LinkClicked += new LinkLabelLinkClickedEventHandler(l_LinkClicked);

                        //l.Top = loc;
                        i++;
                    }

                    populateReviewPanel();



                    // Movie Name Autocompletion
                    DataRowCollection movies = Util.query("SELECT DISTINCT title FROM movie").Rows;
                    allmovies = new AutoCompleteStringCollection();
                    foreach (DataRow movie in movies)
                    {
                        allmovies.Add(movie[0].ToString());
                    }
                    searchBox.AutoCompleteCustomSource = allmovies;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        void populateReviewPanel()
        {
            panel2.Controls.Clear();
            panel2.AutoScroll = true;
            panel2.BackColor = Color.WhiteSmoke;
            DataRowCollection reviews = Util.query("Select m.title,r.Rating,r.Text FROM movie m,movie_review r WHERE m.filmID=r.filmID AND SSN=" + ssn).Rows;
            int i = 0;
            //Point loc = new Point(5,5);
            foreach (DataRow review in reviews)
            {
                string title = review[0].ToString();
                string rating = review[1].ToString();
                string text = review[2].ToString();
                FlowLayoutPanel flp = new FlowLayoutPanel();
                panel2.Controls.Add(flp);
                flp.Name = title;
                flp.Location = new Point(flp.Location.X, 20 * i);

                LinkLabel t = new LinkLabel();
                Label r = new Label();
                Label txt = new Label();
                LinkLabel delete = new LinkLabel();

                flp.Controls.Add(t);
                flp.Controls.Add(r);
                flp.Controls.Add(txt);
                flp.Controls.Add(delete);

                t.Text = title;
                r.Text = "   " + rating; r.ForeColor = Color.Red;
                txt.Text = "   " + text;
                delete.Text = "  Delete";

                t.Links.Add(0, t.Text.Length, t.Text);
                t.LinkClicked += new LinkLabelLinkClickedEventHandler(l_LinkClicked);

                delete.Links.Add(2, delete.Text.Length, t.Text);
                delete.LinkClicked += new LinkLabelLinkClickedEventHandler(delete_LinkClicked);

                delete.AutoSize = true;
                t.AutoSize = true;
                r.AutoSize = true;
                txt.AutoSize = true;
                //flp.Text = title;
                //flp.AutoSize = true;
                flp.Height = 16;
                flp.Width = 450;
                //foreach (Control c in flp.Controls)
                //{

                //}
                //l.Top = loc;
                i++;
            }
        }

        void delete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string title = e.Link.LinkData.ToString();
            DataRowCollection films = Util.query(String.Format("SELECT filmID FROM movie WHERE title='{0}';", title)).Rows;
            if (films.Count > 0)
            {
                int fid = Convert.ToInt32(films[0][0]);

                int rows_affected = Util.non_query(String.Format("DELETE FROM movie_review WHERE SSN={0} AND filmID={1};", ssn, fid));
                if (rows_affected == 1)
                {
                    MessageBox.Show("Your review for " + title + " has been deleted");
                    //panel2.Controls.Remove(panel2.Controls.Find(title, true)[0]);
                    populateReviewPanel();
                    panel2.Refresh();
                }
            }
        }

        void l_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string title = e.Link.LinkData.ToString();
            DataRowCollection films = Util.query(String.Format("SELECT filmID FROM movie WHERE title='{0}';", title)).Rows;
            if (films.Count > 0)
            {
                String fid = films[0][0].ToString();
                Movie_HomePage moviePage = new Movie_HomePage(fid, ssn.ToString());
                moviePage.Show();
            }
        }

        private void checkBoxAction_CheckedChanged(object sender, EventArgs e)
        {

            action = updateUserPreferences(checkBoxAction, "Action", action);
            fetchRecommendedMovies();

        }

        private void checkBoxAdventure_CheckedChanged(object sender, EventArgs e)
        {
            adventure = updateUserPreferences(checkBoxAdventure, "Adventure", adventure);
            fetchRecommendedMovies();
        }

        private void checkBoxAnimation_CheckedChanged(object sender, EventArgs e)
        {
            animation = updateUserPreferences(checkBoxAnimation, "Animation", animation);
            fetchRecommendedMovies();
        }

        private void checkBoxBiography_CheckedChanged(object sender, EventArgs e)
        {
            biography = updateUserPreferences(checkBoxBiography, "Biography", biography);
            fetchRecommendedMovies();

        }

        private void checkBoxComedy_CheckedChanged(object sender, EventArgs e)
        {

            comedy = updateUserPreferences(checkBoxComedy, "Comedy", comedy);
            fetchRecommendedMovies();
        }

        private void checkBoxCrime_CheckedChanged(object sender, EventArgs e)
        {
            crime = updateUserPreferences(checkBoxCrime, "Crime", crime);
            fetchRecommendedMovies();

        }

        private void checkBoxDocumentary_CheckedChanged(object sender, EventArgs e)
        {
            documentary = updateUserPreferences(checkBoxDocumentary, "Documentary", documentary);
            fetchRecommendedMovies();
        }

        private void checkBoxDrama_CheckedChanged(object sender, EventArgs e)
        {
            drama = updateUserPreferences(checkBoxDrama, "Drama", drama);
            fetchRecommendedMovies();

        }

        private void checkBoxFantasy_CheckedChanged(object sender, EventArgs e)
        {
            fantasy = updateUserPreferences(checkBoxFantasy, "Fantasy", fantasy);
            fetchRecommendedMovies();

        }

        private void checkBoxHorror_CheckedChanged(object sender, EventArgs e)
        {
            horror = updateUserPreferences(checkBoxHorror, "Horror", horror);
            fetchRecommendedMovies();
        }

        private void checkBoxMusical_CheckedChanged(object sender, EventArgs e)
        {
            musical = updateUserPreferences(checkBoxMusical, "Musical", musical);
            fetchRecommendedMovies();

        }

        private void checkBoxRomance_CheckedChanged(object sender, EventArgs e)
        {
            romance = updateUserPreferences(checkBoxRomance, "Romance", romance);
            fetchRecommendedMovies();

        }

        private void checkBoxScifi_CheckedChanged(object sender, EventArgs e)
        {
            scifi = updateUserPreferences(checkBoxScifi, "Sci-Fi", scifi);
            fetchRecommendedMovies();

        }

        private void checkBoxSport_CheckedChanged(object sender, EventArgs e)
        {
            sport = updateUserPreferences(checkBoxSport, "Sport", sport);
            fetchRecommendedMovies();
        }

        private void checkBoxThriller_CheckedChanged(object sender, EventArgs e)
        {
            thriller = updateUserPreferences(checkBoxThriller, "Thriller", thriller);
            fetchRecommendedMovies();
        }

        private void checkBoxWar_CheckedChanged(object sender, EventArgs e)
        {
            war = updateUserPreferences(checkBoxWar, "War", war);
            fetchRecommendedMovies();
        }

        public bool updateUserPreferences(CheckBox cb, string genre, bool liked_in_db)
        {
            // Go to the database.
            // If a checkbox is unchecked, remove from the likes table for that user.
            // If it is checked, insert it into the likes table for that user
            bool requested_status = cb.CheckState == CheckState.Checked;

            // The box matches the current state of the database. Leave it alone.
            if (requested_status == liked_in_db) return liked_in_db;

            if (requested_status)
            {
                Util.non_query(String.Format("INSERT INTO Likes(SSN,genre) VALUES ({0},'{1}');", ssn, genre));
            }
            else
            {
                Util.non_query(String.Format("DELETE FROM Likes WHERE SSN = {0} AND genre = '{1}';", ssn, genre));
            }
            return requested_status;
        }

        public void fetchRecommendedMovies()
        {
            // Fetch the recommended movies for a user based on likes
            panel4.BackColor = Color.WhiteSmoke;
            while (panel4.Controls.Count > 0)
            {
                panel4.Controls.RemoveAt(0);
            }
            // TODO: Examine whether four nested queries are really necessary
            string recommended = "SELECT DISTINCT m.title FROM movie m,recommend r WHERE m.filmID=r.filmID AND r.SSN IN (SELECT l1.SSN FROM Likes l1,Likes l2 Where l1.genre=l2.genre AND l2.SSN = " + ssn + " AND l1.SSN < l2.SSN)";
            string temp = "SELECT filmID,title from movie WHERE title IN (" + recommended + ")";
            string rec = "SELECT DISTINCT title FROM (" + temp + ") t, genre g WHERE t.filmID=g.filmID AND genre IN (" + preferences_sql + ")";

            DataRowCollection titles = Util.query(rec).Rows;
            int i = 0;

            foreach (DataRow movie in titles)
            {
                string title = movie[0].ToString();
                LinkLabel l = new LinkLabel();
                panel4.Controls.Add(l);
                l.Name = "rectitle" + i;
                l.Location = new Point(l.Location.X, 18 * i);
                //l.Height = 12;
                //l.Width = 150;
                //l.Location 
                //loc += 5;
                //loc.Y += l.Height + 5;
                l.Text = title;
                l.AutoSize = true;

                l.Links.Add(0, l.Text.Length, l.Text);
                l.LinkClicked += new LinkLabelLinkClickedEventHandler(l_LinkClicked);

                //l.Top = loc;
                i++;
            }

            panel4.Refresh();
        }

        private void LinkClicked(LinkLabel ll)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            movies_database_homepage.mainpage mp = new movies_database_homepage.mainpage();
            mp.Show();
            this.Hide();
        }

    }
};
