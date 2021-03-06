﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data.Odbc;

namespace Movies
{
    public partial class ReviewEditor : Form
    {
        bool ratingAlreadyExists;
        String filmID;
        String SSN;


        public ReviewEditor(String _filmID, String _SSN)
        {
            filmID = _filmID;
            SSN = _SSN;

            InitializeComponent();
            DataRowCollection ratings = ORM.query("SELECT text,rating FROM `movie_review` WHERE filmid = " + filmID + " AND ssn = " + SSN).Rows;
          
            if (ratings.Count != 0)
            {
                String review = ratings[0][0].ToString();
                String rating = ratings[0][1].ToString();

                review_textbox.Text = review;
                rating_spinner.Value = Convert.ToInt32(rating);
                ratingAlreadyExists = true; // just have to update the entry in database on save button click
            } else {
                ratingAlreadyExists = false;//have to insert a new entry in database on save button click
            }


        }

        private void save(object sender, EventArgs e)
        {
            //insert into database
            try { 
                int rating = (int) rating_spinner.Value;
                String review = review_textbox.Text;

                String SQL;
                if (ratingAlreadyExists) {
                    SQL = "UPDATE movie_review SET text='"+review+"',rating="+rating+" WHERE filmId="+filmID+" and SSN = "+SSN;
                }
                else
                {
                    SQL = "INSERT INTO `movie_review`(`filmID`, `SSN`, `Text`, `Rating`) VALUES (" + filmID + "," + SSN + ",'" + review + "'," + rating + ")";
                }
                ORM.non_query(SQL);

                this.Dispose();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cancel(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
