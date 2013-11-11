namespace Movies
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.login_register_panel = new System.Windows.Forms.Panel();
            this.register_button = new System.Windows.Forms.Button();
            this.login_button = new System.Windows.Forms.Button();
            this.search_panel = new System.Windows.Forms.Panel();
            this.search_type_combobox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.search_textbox = new System.Windows.Forms.TextBox();
            this.now_playing_panel = new System.Windows.Forms.Panel();
            this.previous_now_playing_button = new System.Windows.Forms.Button();
            this.next_now_playing_button = new System.Windows.Forms.Button();
            this.now_playing_label = new System.Windows.Forms.Label();
            this.movie_cover_3 = new System.Windows.Forms.PictureBox();
            this.movie_cover_2 = new System.Windows.Forms.PictureBox();
            this.movie_cover_1 = new System.Windows.Forms.PictureBox();
            this.movie_cover_0 = new System.Windows.Forms.PictureBox();
            this.welcome_label = new System.Windows.Forms.Label();
            this.login_register_panel.SuspendLayout();
            this.search_panel.SuspendLayout();
            this.now_playing_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movie_cover_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movie_cover_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movie_cover_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movie_cover_0)).BeginInit();
            this.SuspendLayout();
            // 
            // login_register_panel
            // 
            this.login_register_panel.Controls.Add(this.register_button);
            this.login_register_panel.Controls.Add(this.login_button);
            this.login_register_panel.Location = new System.Drawing.Point(12, 54);
            this.login_register_panel.Name = "login_register_panel";
            this.login_register_panel.Size = new System.Drawing.Size(871, 33);
            this.login_register_panel.TabIndex = 0;
            // 
            // register_button
            // 
            this.register_button.Location = new System.Drawing.Point(781, 7);
            this.register_button.Name = "register_button";
            this.register_button.Size = new System.Drawing.Size(75, 23);
            this.register_button.TabIndex = 1;
            this.register_button.Text = "Register";
            this.register_button.UseVisualStyleBackColor = true;
            this.register_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(681, 7);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(75, 23);
            this.login_button.TabIndex = 0;
            this.login_button.Text = "Login";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // search_panel
            // 
            this.search_panel.Controls.Add(this.search_type_combobox);
            this.search_panel.Controls.Add(this.button3);
            this.search_panel.Controls.Add(this.search_textbox);
            this.search_panel.Location = new System.Drawing.Point(12, 93);
            this.search_panel.Name = "search_panel";
            this.search_panel.Size = new System.Drawing.Size(871, 60);
            this.search_panel.TabIndex = 1;
            // 
            // search_type_combobox
            // 
            this.search_type_combobox.FormattingEnabled = true;
            this.search_type_combobox.Items.AddRange(new object[] {
            "Movies",
            "Actor",
            "Director"});
            this.search_type_combobox.Location = new System.Drawing.Point(666, 19);
            this.search_type_combobox.Name = "search_type_combobox";
            this.search_type_combobox.Size = new System.Drawing.Size(121, 21);
            this.search_type_combobox.TabIndex = 2;
            this.search_type_combobox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(793, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // search_textbox
            // 
            this.search_textbox.Location = new System.Drawing.Point(22, 20);
            this.search_textbox.Name = "search_textbox";
            this.search_textbox.Size = new System.Drawing.Size(631, 20);
            this.search_textbox.TabIndex = 0;
            this.search_textbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // now_playing_panel
            // 
            this.now_playing_panel.Controls.Add(this.previous_now_playing_button);
            this.now_playing_panel.Controls.Add(this.next_now_playing_button);
            this.now_playing_panel.Controls.Add(this.now_playing_label);
            this.now_playing_panel.Controls.Add(this.movie_cover_3);
            this.now_playing_panel.Controls.Add(this.movie_cover_2);
            this.now_playing_panel.Controls.Add(this.movie_cover_1);
            this.now_playing_panel.Controls.Add(this.movie_cover_0);
            this.now_playing_panel.Location = new System.Drawing.Point(12, 159);
            this.now_playing_panel.Name = "now_playing_panel";
            this.now_playing_panel.Size = new System.Drawing.Size(838, 354);
            this.now_playing_panel.TabIndex = 2;
            // 
            // previous_now_playing_button
            // 
            this.previous_now_playing_button.Location = new System.Drawing.Point(645, 328);
            this.previous_now_playing_button.Name = "previous_now_playing_button";
            this.previous_now_playing_button.Size = new System.Drawing.Size(75, 23);
            this.previous_now_playing_button.TabIndex = 6;
            this.previous_now_playing_button.Text = "Previous";
            this.previous_now_playing_button.UseVisualStyleBackColor = true;
            this.previous_now_playing_button.Click += new System.EventHandler(this.button5_Click);
            // 
            // next_now_playing_button
            // 
            this.next_now_playing_button.Location = new System.Drawing.Point(742, 328);
            this.next_now_playing_button.Name = "next_now_playing_button";
            this.next_now_playing_button.Size = new System.Drawing.Size(75, 23);
            this.next_now_playing_button.TabIndex = 5;
            this.next_now_playing_button.Text = "next";
            this.next_now_playing_button.UseVisualStyleBackColor = true;
            this.next_now_playing_button.Click += new System.EventHandler(this.button4_Click);
            // 
            // now_playing_label
            // 
            this.now_playing_label.AutoSize = true;
            this.now_playing_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.now_playing_label.Location = new System.Drawing.Point(30, 13);
            this.now_playing_label.Name = "now_playing_label";
            this.now_playing_label.Size = new System.Drawing.Size(131, 25);
            this.now_playing_label.TabIndex = 4;
            this.now_playing_label.Text = "Now Playing";
            // 
            // movie_cover_3
            // 
            this.movie_cover_3.ErrorImage = null;
            this.movie_cover_3.Image = ((System.Drawing.Image)(resources.GetObject("movie_cover_3.Image")));
            this.movie_cover_3.Location = new System.Drawing.Point(645, 61);
            this.movie_cover_3.Name = "movie_cover_3";
            this.movie_cover_3.Size = new System.Drawing.Size(190, 256);
            this.movie_cover_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.movie_cover_3.TabIndex = 3;
            this.movie_cover_3.TabStop = false;
            this.movie_cover_3.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // movie_cover_2
            // 
            this.movie_cover_2.ErrorImage = null;
            this.movie_cover_2.Image = ((System.Drawing.Image)(resources.GetObject("movie_cover_2.Image")));
            this.movie_cover_2.Location = new System.Drawing.Point(432, 61);
            this.movie_cover_2.Name = "movie_cover_2";
            this.movie_cover_2.Size = new System.Drawing.Size(190, 256);
            this.movie_cover_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.movie_cover_2.TabIndex = 2;
            this.movie_cover_2.TabStop = false;
            this.movie_cover_2.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // movie_cover_1
            // 
            this.movie_cover_1.ErrorImage = null;
            this.movie_cover_1.Image = ((System.Drawing.Image)(resources.GetObject("movie_cover_1.Image")));
            this.movie_cover_1.Location = new System.Drawing.Point(227, 61);
            this.movie_cover_1.Name = "movie_cover_1";
            this.movie_cover_1.Size = new System.Drawing.Size(190, 256);
            this.movie_cover_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.movie_cover_1.TabIndex = 1;
            this.movie_cover_1.TabStop = false;
            this.movie_cover_1.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // movie_cover_0
            // 
            this.movie_cover_0.Image = ((System.Drawing.Image)(resources.GetObject("movie_cover_0.Image")));
            this.movie_cover_0.Location = new System.Drawing.Point(22, 61);
            this.movie_cover_0.Name = "movie_cover_0";
            this.movie_cover_0.Size = new System.Drawing.Size(190, 256);
            this.movie_cover_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.movie_cover_0.TabIndex = 0;
            this.movie_cover_0.TabStop = false;
            this.movie_cover_0.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // welcome_label
            // 
            this.welcome_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome_label.Location = new System.Drawing.Point(12, 9);
            this.welcome_label.Name = "welcome_label";
            this.welcome_label.Size = new System.Drawing.Size(856, 42);
            this.welcome_label.TabIndex = 3;
            this.welcome_label.Text = "Welcome to Movies database";
            this.welcome_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 512);
            this.Controls.Add(this.welcome_label);
            this.Controls.Add(this.now_playing_panel);
            this.Controls.Add(this.search_panel);
            this.Controls.Add(this.login_register_panel);
            this.Name = "main";
            this.Text = "Mainpage";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.login_register_panel.ResumeLayout(false);
            this.search_panel.ResumeLayout(false);
            this.search_panel.PerformLayout();
            this.now_playing_panel.ResumeLayout(false);
            this.now_playing_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movie_cover_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movie_cover_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movie_cover_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movie_cover_0)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel login_register_panel;
        private System.Windows.Forms.Button register_button;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Panel search_panel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox search_textbox;
        private System.Windows.Forms.ComboBox search_type_combobox;
        private System.Windows.Forms.Panel now_playing_panel;
        private System.Windows.Forms.PictureBox movie_cover_2;
        private System.Windows.Forms.PictureBox movie_cover_1;
        private System.Windows.Forms.PictureBox movie_cover_0;
        private System.Windows.Forms.Label welcome_label;
        private System.Windows.Forms.PictureBox movie_cover_3;
        private System.Windows.Forms.Label now_playing_label;
        private System.Windows.Forms.Button previous_now_playing_button;
        private System.Windows.Forms.Button next_now_playing_button;
    }
}

