using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Drawing;
namespace Movies
{
    public partial class MovieHome : Form
    {
        private String filmId = "";//will be dynamic
        private String loggedInUserSSN = ""; //will be dynamic
        private bool screenLoaded = false;
        public MovieHome(String filmUID, String UserSSN)
        {
            
            filmId = filmUID;
            loggedInUserSSN = UserSSN;
            InitializeComponent();
            screenLoaded = false;
            populateMovieHomepage(filmId, loggedInUserSSN);
            screenLoaded = true;
        }

        public void populateMovieHomepage(String FilmId, String SSN)
        {
            //Fetch details of the movie from the database
            DataRow movie_row = Util.query("SELECT * FROM movie WHERE filmID = " + FilmId).Rows[0];

            String title = movie_row[1].ToString();
            String year = movie_row[2].ToString();
            String rating = movie_row[3].ToString();
            String description = movie_row[4].ToString();

            byte[] barrImg = (byte[])movie_row[5];
            MemoryStream mstream = new MemoryStream(barrImg);
            movie_image.Image = Image.FromStream(mstream);
            movie_name.Text = title;

            // avg_rating.Text = rating;
            //avg_rating_progress.Value = (int)float.Parse(rating);

            descriptionTB.Text = description;

            this.Text = String.Format("{0} - {1}", title, year);

            DataRowCollection directors = Util.query(String.Format("SELECT fname,lname FROM `person` WHERE SSN IN (Select SSN from director where filmid = {0})", FilmId)).Rows;

            foreach (DataRow director_row in directors)
            {
                String fname = director_row[0].ToString();
                String lname = director_row[1].ToString();
                String director = String.Format("{0} {1}", fname, lname);
                Label directorLabel = new Label();
                directorLabel.Text = director;
                directorLabel.AutoSize = true;
                directorPanel.Controls.Add(directorLabel);
            }
            directorPanel.BorderStyle = BorderStyle.FixedSingle;


            DataRowCollection genres = Util.query(String.Format("SELECT DISTINCT genre FROM `genre` WHERE filmid = {0}", FilmId)).Rows;
            foreach (DataRow genre_row in genres)
            {
                String genre = genre_row[0].ToString();
                Label genreLabel = new Label();
                genreLabel.Text = genre;
                genreLabel.AutoSize = true;
                genrePanel.Controls.Add(genreLabel);

            }
            genrePanel.BorderStyle = BorderStyle.FixedSingle;


            DataRowCollection actors = Util.query(String.Format("SELECT fname,lname FROM `person` ,actor Where person.SSN = actor.SSN AND actor.filmid = {0}", FilmId)).Rows;
            foreach (DataRow actor_row in actors)
            {
                String fname = actor_row[0].ToString();
                String lname = actor_row[1].ToString();
                String actor = fname + " " + lname;
                Label actorLabel = new Label();
                actorLabel.Text = actor;
                actorLabel.AutoSize = true;
                actorPanel.Controls.Add(actorLabel);

            }
            actorPanel.BorderStyle = BorderStyle.FixedSingle;


            DataRowCollection reviews = Util.query(String.Format("SELECT fname,lname,text,rating FROM `movie_review`,person WHERE filmid = {0} AND person.ssn = movie_review.ssn", FilmId)).Rows;
            float avgRating = 0;
            int panel_row = 0;
            foreach (DataRow review_row in reviews)
            {
                String fname = review_row[0].ToString();
                String lname = review_row[1].ToString();
                String review = review_row[2].ToString();
                String ratingGiven = review_row[3].ToString();
                avgRating += Convert.ToSingle(ratingGiven);
                TableLayoutPanel panel = new TableLayoutPanel();

                Label name = new Label();
                name.Text = String.Format("{0} {1} - {2}", fname, lname, ratingGiven);
                name.AutoSize = true;
                name.ForeColor = Color.Firebrick;

                TextBox tb = new TextBox();
                tb.Text = review;
                tb.Enabled = false;
                tb.WordWrap = true;
                tb.Height = 4;
                tb.Width = this.Width / 2 + this.Width / 3;

                panel.Controls.Add(name, 0, 0);
                panel.Controls.Add(tb, 0, 1);
                panel.AutoSize = true;

                ReviewsPanel.Controls.Add(panel, 0, panel_row++);
                ReviewsPanel.AutoScroll = true;
            }
            if (reviews.Count > 0)
            {
                avgRating = avgRating / reviews.Count;
            }
            else
            {
                avgRating = 0;

            }
            avg_rating.Text = avgRating.ToString("#.##");
            avg_rating_progress.Value = (int)avgRating;
            if (String.IsNullOrEmpty(loggedInUserSSN) || loggedInUserSSN.Equals("0000000"))
            {
                your_rating_textbox.Visible = false;
                your_rating_label.Visible = false;
                create_review_label.Visible = false;
                recommend_checkbox.Visible = false;
            }
            else
            {

                DataRowCollection ratings = Util.query(String.Format("SELECT rating FROM `movie_review` WHERE filmid = {0} AND ssn={1}", FilmId, loggedInUserSSN)).Rows;
                if (ratings.Count != 0)
                {
                    your_rating_textbox.Text = ratings[0][0].ToString();
                    your_rating_textbox.Visible = true;
                    your_rating_label.Visible = true;

                }
                else
                {
                    your_rating_textbox.Visible = false;
                    your_rating_label.Visible = false;

                }

            }
            if (String.IsNullOrEmpty(SSN) || SSN.Equals("0000000"))
            {
                recommend_checkbox.Visible = false;
                create_review_label.Visible = false;
            }
            else
            {
                recommend_checkbox.Visible = true;
                create_review_label.Visible = true;

                DataRowCollection recommends = Util.query(String.Format("SELECT SSN FROM recommend WHERE filmid={0} AND SSN={1}", filmId, loggedInUserSSN)).Rows;
                recommend_checkbox.Checked = recommends.Count > 0;
            }
            fetchTheatresPlayingIn();
        }

        public void fetchTheatresPlayingIn()
        {
            DataRowCollection theaters = Util.query(String.Format("SELECT name FROM theater,(SELECT DISTINCT TID FROM now_playing WHERE filmid='{0}') as temp WHERE theater.tid=temp.tid", filmId)).Rows;
            foreach (DataRow theater in theaters)
            {
                String theaterName = theater[0].ToString();
                LinkLabel t = new LinkLabel();
                t.Click += new EventHandler(t_Click);
                t.Text = theaterName;
                theatrePanel.Controls.Add(t);
            }
        }

        void t_Click(object sender, EventArgs e)
        {
            DataRowCollection films_now_playing = Util.query(String.Format("SELECT date,time FROM now_playing WHERE filmid='{0}' AND tid=(SELECT tid FROM theater WHERE name ='{1}')", filmId, (sender as LinkLabel).Text)).Rows;
            ShowTimeAndDatePanel popUp = new ShowTimeAndDatePanel();
            //Form popUp = new Form();
            foreach (DataRow film in films_now_playing)
            {
                String date = film[0].ToString().Split(' ')[0];
                String time = film[1].ToString();

                Label temp = new Label();
                temp.Text = String.Format("Date: {0}  Time: {1}", date, time);
                temp.AutoSize = true;
                TableLayoutPanel tpanel = (TableLayoutPanel)popUp.Controls[1];
                tpanel.Controls.Add(temp);
            }
            popUp.ShowDialog();
        }

        private void reviewLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            write_update_reviewForm reviewForm = new write_update_reviewForm(filmId, loggedInUserSSN);
            reviewForm.ShowDialog();

        }

        private void recommendCB_CheckedChanged(object sender, EventArgs e)
        {
            if (screenLoaded) {
                if (recommend_checkbox.Checked)
                {
                    Util.non_query(String.Format("INSERT INTO `recommend`(`SSN`, `filmid`) VALUES ({0},{1})", loggedInUserSSN, filmId));
                }
                else
                {
                    Util.non_query(String.Format("DELETE FROM recommend WHERE SSN={0} AND filmid={1}",loggedInUserSSN, filmId));
                }
            }
        }

    }
}
