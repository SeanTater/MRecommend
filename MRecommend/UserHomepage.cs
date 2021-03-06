﻿using System;
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
    class Genre
    {
        public Genre(string name, bool liked, CheckBox box)
        {
            this.name = name;
            this.liked = liked;
            this.box = box;
        }
        public string name;
        public bool liked;
        public CheckBox box;
    }
    public partial class UserHomepage : Form
    {
        Dictionary<string, Genre> genres;

        String Username = "anton";
        int ssn;
        String preferences_sql;
        AutoCompleteStringCollection allmovies;

        public UserHomepage(String username)
        {
            this.Username = username;
            ssn = Convert.ToInt32(ORM.query(String.Format("Select SSN FROM user WHERE Username='{0}';", Username)).Rows[0][0]);
            preferences_sql = "Select genre FROM Likes WHERE SSN = " + ssn;
            InitializeComponent();
        }

        private void search(object sender, EventArgs e)
        {

            string text = searchBox.Text;
            SearchResult sr = new SearchResult(text,ssn);
            sr.Show();
            
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // Please forgive this non-DRY ness
            genres = new Dictionary<string,Genre>();
            foreach (string name in new string[] {
                "Action",
                "Adventure",
                "Animation", 
                "Biography",
                "Comedy",
                "Crime",
                "Documentary",
                "Drama",
                "Fantasy",
                "Horror",
                "Musical",
                "Romance",
                "Sci-Fi",
                "Sport",
                "Thriller",
                "War"
                }) {
                CheckBox cb = new CheckBox();
                cb.Text = name;
                genres_panel.Controls.Add(cb);
                cb.CheckedChanged += new System.EventHandler(like_unlike_genres);
                genres[name] = new Genre(name, false, cb);
            }
            DataRowCollection preferences = ORM.query(preferences_sql).Rows;
            if (preferences.Count > 0)
            {
                foreach (DataRow dr in preferences)
                {
                    Genre genre = genres[dr[0].ToString()];
                    genre.liked = true;
                    genre.box.CheckState = CheckState.Checked;
                }

                recommendations_panel.AutoScroll = true;

                popular_panel.BackColor = Color.WhiteSmoke;
                popular_panel.AutoScroll = true;

                //Point loc = new Point(5,5);
                int i = 0;
                DataRowCollection popular_movies = Movies.ORM.query("SELECT DISTINCT m.title FROM movie m,recommend r WHERE m.filmID=r.filmID AND Avg_rating>=7.5 GROUP BY m.title HAVING COUNT(*)>=2").Rows;
                foreach (DataRow movie in popular_movies)
                {
                    string title = movie[0].ToString();
                    LinkLabel l = new LinkLabel();
                    popular_panel.Controls.Add(l);
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
                    l.LinkClicked += new LinkLabelLinkClickedEventHandler(display_movie_by_title);

                    //l.Top = loc;
                    i++;
                }

                populate_reviews();

                // Movie Name Autocompletion
                DataRowCollection movies = ORM.query("SELECT DISTINCT title FROM movie").Rows;
                allmovies = new AutoCompleteStringCollection();
                foreach (DataRow movie in movies)
                {
                    allmovies.Add(movie[0].ToString());
                }
                searchBox.AutoCompleteCustomSource = allmovies;
            }
        }

        void populate_reviews()
        {
            ratings_panel.Controls.Clear();
            ratings_panel.AutoScroll = true;
            ratings_panel.BackColor = Color.WhiteSmoke;
            DataRowCollection reviews = ORM.query("Select m.title,r.Rating,r.Text FROM movie m,movie_review r WHERE m.filmID=r.filmID AND SSN=" + ssn).Rows;
            int i = 0;
            //Point loc = new Point(5,5);
            foreach (DataRow review in reviews)
            {
                string title = review[0].ToString();
                string rating = review[1].ToString();
                string text = review[2].ToString();
                FlowLayoutPanel flp = new FlowLayoutPanel();
                ratings_panel.Controls.Add(flp);
                flp.Name = title;
                flp.Location = new Point(flp.Location.X, 20 * i);

                LinkLabel t = new LinkLabel();
                Label r = new Label();
                Label txt = new Label();
                LinkLabel delete_link = new LinkLabel();

                flp.Controls.Add(t);
                flp.Controls.Add(r);
                flp.Controls.Add(txt);
                flp.Controls.Add(delete_link);

                t.Text = title;
                r.Text = "   " + rating; r.ForeColor = Color.Red;
                txt.Text = "   " + text;
                delete_link.Text = "  Delete";

                t.Links.Add(0, t.Text.Length, t.Text);
                t.LinkClicked += new LinkLabelLinkClickedEventHandler(display_movie_by_title);

                delete_link.Links.Add(2, delete_link.Text.Length, t.Text);
                delete_link.LinkClicked += new LinkLabelLinkClickedEventHandler(delete);

                delete_link.AutoSize = true;
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

        void delete(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string title = e.Link.LinkData.ToString();
            DataRowCollection films = ORM.query(String.Format("SELECT filmID FROM movie WHERE title='{0}';", title)).Rows;
            if (films.Count > 0)
            {
                int fid = Convert.ToInt32(films[0][0]);

                int rows_affected = ORM.non_query(String.Format("DELETE FROM movie_review WHERE SSN={0} AND filmID={1};", ssn, fid));
                if (rows_affected == 1)
                {
                    MessageBox.Show("Your review for " + title + " has been deleted");
                    //panel2.Controls.Remove(panel2.Controls.Find(title, true)[0]);
                    populate_reviews();
                    ratings_panel.Refresh();
                }
            }
        }

        void display_movie_by_title(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string title = e.Link.LinkData.ToString();
            DataRowCollection films = ORM.query(String.Format("SELECT filmID FROM movie WHERE title='{0}';", title)).Rows;
            if (films.Count > 0)
            {
                String fid = films[0][0].ToString();
                MovieHome moviePage = new MovieHome(fid, ssn.ToString());
                moviePage.Show();
            }
        }

        private void like_unlike_genres(object box, EventArgs e)
        {
            update_preferences(genres[((CheckBox)box).Text]);
            populate_recommends();
        }

        private bool update_preferences(Genre genre)
        {
            // Go to the database.
            // If a checkbox is unchecked, remove from the likes table for that user.
            // If it is checked, insert it into the likes table for that user
            bool requested_status = genre.box.CheckState == CheckState.Checked;

            // The box matches the current state of the database. Leave it alone.
            if (requested_status == genre.liked) return genre.liked;

            if (requested_status)
            {
                ORM.non_query(String.Format("INSERT INTO Likes(SSN,genre) VALUES ({0},'{1}');", ssn, genre.name));
            }
            else
            {
                ORM.non_query(String.Format("DELETE FROM Likes WHERE SSN = {0} AND genre = '{1}';", ssn, genre.name));
            }
            return requested_status;
        }

        public void populate_recommends()
        {
            // Fetch the recommended movies for a user based on likes
            recommendations_panel.BackColor = Color.WhiteSmoke;
            while (recommendations_panel.Controls.Count > 0)
            {
                recommendations_panel.Controls.RemoveAt(0);
            }
            // TODO: Examine whether four nested queries are really necessary
            string recommended = "SELECT DISTINCT m.title FROM movie m,recommend r WHERE m.filmID=r.filmID AND r.SSN IN (SELECT l1.SSN FROM Likes l1,Likes l2 Where l1.genre=l2.genre AND l2.SSN = " + ssn + " AND l1.SSN < l2.SSN)";
            string temp = "SELECT filmID,title from movie WHERE title IN (" + recommended + ")";
            string rec = "SELECT DISTINCT title FROM (" + temp + ") t, genre g WHERE t.filmID=g.filmID AND genre IN (" + preferences_sql + ")";

            DataRowCollection titles = ORM.query(rec).Rows;
            int i = 0;

            foreach (DataRow movie in titles)
            {
                string title = movie[0].ToString();
                LinkLabel l = new LinkLabel();
                recommendations_panel.Controls.Add(l);
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
                l.LinkClicked += new LinkLabelLinkClickedEventHandler(display_movie_by_title);

                //l.Top = loc;
                i++;
            }

            recommendations_panel.Refresh();
        }

        private void logout(object sender, EventArgs e)
        {
            Movies.Main mp = new Movies.Main();
            mp.Show();
            this.Hide();
        }

    }
};
