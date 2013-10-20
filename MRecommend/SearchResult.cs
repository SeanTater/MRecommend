using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Movies
{
    public partial class SearchResult : Form
    {
        int ssn;
        string searchText;

        public SearchResult(string text,int ssn)
        {
            searchText = text;
            this.ssn = ssn;
            InitializeComponent();
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void SearchResult_Load(object sender, EventArgs e)
        {
            DataRowCollection films = Util.query("SELECT * FROM movie WHERE title LIKE '%" + searchText + "%'").Rows;
            searchBox.Text = searchText;
           
            panel1.Controls.Clear();

            try
            {

                //panel1.ColumnCount = 3;
                //panel1.RowCount = dt.Rows.Count;
                //panel1.ColumnStyles.Clear();
                //panel1.RowStyles.Clear();
                //panel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                //panel1.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
                //panel1.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                panel1.AutoScroll = true;
                //panel1.AutoSize = false;

                int i = 0;
                foreach (DataRow film in films)
                {
                    //DataRow dr = dt.Rows[0];
                    //panel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                    string title = film[1].ToString();
                    int year = Convert.ToInt32(film[2]);
                    float rating = Convert.ToInt32(film[3]);
                    String description = film[4].ToString();
                    byte[] barrImg = (byte[])film[5];
                    MemoryStream mstream = new MemoryStream(barrImg);
                    //movie_image.Image = Image.FromStream(mstream);

                    TableLayoutPanel filmPanel = new TableLayoutPanel();

                    PictureBox pb = new PictureBox();
                    pb.Image = Image.FromStream(mstream);
                    pb.Size = new System.Drawing.Size(40, 50);
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;

                    LinkLabel tlabel = new LinkLabel();
                    tlabel.Text = title;
                    tlabel.Width = 200;
                    tlabel.Height = 22;
                    tlabel.Links.Add(0, tlabel.Text.Length, tlabel.Text);
                    tlabel.LinkClicked += new LinkLabelLinkClickedEventHandler(tlabel_LinkClicked);
                    //tlabel.AutoSize = true;

                    Label rlabel = new Label();
                    rlabel.Text = rating.ToString();
                    rlabel.BorderStyle = BorderStyle.FixedSingle;

                    rlabel.AutoSize = true;

                    filmPanel.Controls.Add(pb, 0, 0);
                    filmPanel.Controls.Add(tlabel, 1, 0);
                    filmPanel.Controls.Add(rlabel, 2, 0);
                    filmPanel.AutoSize = true;

                    //filmPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;

                    //panel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    panel1.Controls.Add(filmPanel);
                    filmPanel.Location = new Point(0, i * 100);
                    //panel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    //panel1.Controls.Add(tlabel, 1, i);
                    //panel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    //panel1.Controls.Add(rlabel, 2, i);



                    //panel1
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchText = searchBox.Text;
            DataRowCollection films = Util.query("SELECT * FROM movie WHERE title LIKE '%" + searchText + "%'").Rows;

            panel1.Controls.Clear();
            
            try
            {
                //panel1.ColumnCount = 3;
                //panel1.RowCount = dt.Rows.Count;
                //panel1.ColumnStyles.Clear();
                //panel1.RowStyles.Clear();
                //panel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                //panel1.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
                //panel1.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                panel1.AutoScroll = true;
                //panel1.AutoSize = false;

                int i = 0;
                foreach (DataRow film in films)
                {
                    //DataRow dr = dt.Rows[0];
                    //panel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                    string title = film[1].ToString();
                    int year = Convert.ToInt32(film[2]);
                    float rating = Convert.ToInt32(film[3]);
                    String description = film[4].ToString();
                    byte[] barrImg = (byte[])film[5];
                    MemoryStream mstream = new MemoryStream(barrImg);
                    //movie_image.Image = Image.FromStream(mstream);

                    TableLayoutPanel filmPanel = new TableLayoutPanel();

                    PictureBox pb = new PictureBox();
                    pb.Image = Image.FromStream(mstream);
                    pb.Size = new System.Drawing.Size(40, 50);
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;

                    LinkLabel tlabel = new LinkLabel();
                    tlabel.Text = title;
                    tlabel.Width = 200;
                    tlabel.Height = 22;
                    tlabel.Links.Add(0, tlabel.Text.Length, tlabel.Text);
                    tlabel.LinkClicked += new LinkLabelLinkClickedEventHandler(tlabel_LinkClicked);
                    //tlabel.AutoSize = true;

                    Label rlabel = new Label();
                    rlabel.Text = rating.ToString();
                    rlabel.BorderStyle = BorderStyle.FixedSingle;

                    rlabel.AutoSize = true;

                    filmPanel.Controls.Add(pb, 0, 0);
                    filmPanel.Controls.Add(tlabel, 1, 0);
                    filmPanel.Controls.Add(rlabel, 2, 0);
                    filmPanel.AutoSize = true;

                    //filmPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;

                    //panel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    panel1.Controls.Add(filmPanel);
                    filmPanel.Location = new Point(0, i * 100);
                    //panel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    //panel1.Controls.Add(tlabel, 1, i);
                    //panel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    //panel1.Controls.Add(rlabel, 2, i);
                    
                    
                    
                    //panel1
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void tlabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //throw new NotImplementedException();
            string title = e.Link.LinkData.ToString();

            DataRowCollection ids = Util.query("SELECT filmID FROM movie WHERE title='" + title + "';").Rows;
            if (ids.Count > 0)
            {
                string id = ids[0][0].ToString();
                Movie_HomePage moviePage = new Movie_HomePage(id, ssn.ToString());
                moviePage.Show();
            }

        }
    }
}
