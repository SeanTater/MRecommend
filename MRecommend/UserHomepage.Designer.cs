namespace Movies
{
    partial class UserHomepage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchBox = new System.Windows.Forms.TextBox();
            this.search_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sign_out_button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ratings_panel = new System.Windows.Forms.Panel();
            this.popular_panel = new System.Windows.Forms.Panel();
            this.recommendations_panel = new System.Windows.Forms.Panel();
            this.genres_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.AllowDrop = true;
            this.searchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.searchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.searchBox.Location = new System.Drawing.Point(14, 77);
            this.searchBox.MaxLength = 30;
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(367, 20);
            this.searchBox.TabIndex = 0;
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(422, 75);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(75, 23);
            this.search_button.TabIndex = 1;
            this.search_button.Text = "Go";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(492, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Popular Movies";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 23);
            this.label3.TabIndex = 21;
            this.label3.Text = "Your Reviews and Ratings";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Recommended for you";
            // 
            // sign_out_button
            // 
            this.sign_out_button.Location = new System.Drawing.Point(642, 9);
            this.sign_out_button.Name = "sign_out_button";
            this.sign_out_button.Size = new System.Drawing.Size(75, 23);
            this.sign_out_button.TabIndex = 23;
            this.sign_out_button.Text = "sign out";
            this.sign_out_button.UseVisualStyleBackColor = true;
            this.sign_out_button.Click += new System.EventHandler(this.signOutButtonClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(660, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Logged in.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Search for a movie";
            // 
            // ratings_panel
            // 
            this.ratings_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ratings_panel.Location = new System.Drawing.Point(12, 425);
            this.ratings_panel.Name = "ratings_panel";
            this.ratings_panel.Size = new System.Drawing.Size(452, 105);
            this.ratings_panel.TabIndex = 27;
            // 
            // popular_panel
            // 
            this.popular_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.popular_panel.Location = new System.Drawing.Point(495, 230);
            this.popular_panel.Name = "popular_panel";
            this.popular_panel.Size = new System.Drawing.Size(222, 300);
            this.popular_panel.TabIndex = 28;
            // 
            // recommendations_panel
            // 
            this.recommendations_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recommendations_panel.Location = new System.Drawing.Point(12, 230);
            this.recommendations_panel.Name = "recommendations_panel";
            this.recommendations_panel.Size = new System.Drawing.Size(458, 155);
            this.recommendations_panel.TabIndex = 29;
            // 
            // genres_panel
            // 
            this.genres_panel.Location = new System.Drawing.Point(12, 118);
            this.genres_panel.Name = "genres_panel";
            this.genres_panel.Size = new System.Drawing.Size(705, 86);
            this.genres_panel.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Genres";
            // 
            // UserHomepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 542);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.genres_panel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.recommendations_panel);
            this.Controls.Add(this.popular_panel);
            this.Controls.Add(this.ratings_panel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sign_out_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.searchBox);
            this.Name = "UserHomepage";
            this.Text = "Cinema Time!";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button sign_out_button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel ratings_panel;
        private System.Windows.Forms.Panel popular_panel;
        private System.Windows.Forms.Panel recommendations_panel;
        private System.Windows.Forms.FlowLayoutPanel genres_panel;
        private System.Windows.Forms.Label label1;

    }
}

