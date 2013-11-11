namespace Movies
{
    partial class loginpage
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
            this.login_register_split = new System.Windows.Forms.SplitContainer();
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.username_textbox = new System.Windows.Forms.TextBox();
            this.cancel_button = new System.Windows.Forms.Button();
            this.login_button = new System.Windows.Forms.Button();
            this.password_label = new System.Windows.Forms.Label();
            this.username_label = new System.Windows.Forms.Label();
            this.login_label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.female_radiobutton = new System.Windows.Forms.RadioButton();
            this.male_radiobutton = new System.Windows.Forms.RadioButton();
            this.gender_label = new System.Windows.Forms.Label();
            this.confirm_register_password_textbox = new System.Windows.Forms.TextBox();
            this.register_password_textbox = new System.Windows.Forms.TextBox();
            this.register_username_textbox = new System.Windows.Forms.TextBox();
            this.ssn_textbox = new System.Windows.Forms.TextBox();
            this.last_name_textbox = new System.Windows.Forms.TextBox();
            this.first_name_textbox = new System.Windows.Forms.TextBox();
            this.cancel_register_button = new System.Windows.Forms.Button();
            this.register_button = new System.Windows.Forms.Button();
            this.confirm_register_password_label = new System.Windows.Forms.Label();
            this.register_password_label = new System.Windows.Forms.Label();
            this.register_username_label = new System.Windows.Forms.Label();
            this.ssn_label = new System.Windows.Forms.Label();
            this.last_name_label = new System.Windows.Forms.Label();
            this.first_name_label = new System.Windows.Forms.Label();
            this.register_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.login_register_split)).BeginInit();
            this.login_register_split.Panel1.SuspendLayout();
            this.login_register_split.Panel2.SuspendLayout();
            this.login_register_split.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // login_register_split
            // 
            this.login_register_split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.login_register_split.Location = new System.Drawing.Point(0, 0);
            this.login_register_split.Name = "login_register_split";
            // 
            // login_register_split.Panel1
            // 
            this.login_register_split.Panel1.Controls.Add(this.password_textbox);
            this.login_register_split.Panel1.Controls.Add(this.username_textbox);
            this.login_register_split.Panel1.Controls.Add(this.cancel_button);
            this.login_register_split.Panel1.Controls.Add(this.login_button);
            this.login_register_split.Panel1.Controls.Add(this.password_label);
            this.login_register_split.Panel1.Controls.Add(this.username_label);
            this.login_register_split.Panel1.Controls.Add(this.login_label);
            this.login_register_split.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // login_register_split.Panel2
            // 
            this.login_register_split.Panel2.Controls.Add(this.groupBox1);
            this.login_register_split.Panel2.Controls.Add(this.gender_label);
            this.login_register_split.Panel2.Controls.Add(this.confirm_register_password_textbox);
            this.login_register_split.Panel2.Controls.Add(this.register_password_textbox);
            this.login_register_split.Panel2.Controls.Add(this.register_username_textbox);
            this.login_register_split.Panel2.Controls.Add(this.ssn_textbox);
            this.login_register_split.Panel2.Controls.Add(this.last_name_textbox);
            this.login_register_split.Panel2.Controls.Add(this.first_name_textbox);
            this.login_register_split.Panel2.Controls.Add(this.cancel_register_button);
            this.login_register_split.Panel2.Controls.Add(this.register_button);
            this.login_register_split.Panel2.Controls.Add(this.confirm_register_password_label);
            this.login_register_split.Panel2.Controls.Add(this.register_password_label);
            this.login_register_split.Panel2.Controls.Add(this.register_username_label);
            this.login_register_split.Panel2.Controls.Add(this.ssn_label);
            this.login_register_split.Panel2.Controls.Add(this.last_name_label);
            this.login_register_split.Panel2.Controls.Add(this.first_name_label);
            this.login_register_split.Panel2.Controls.Add(this.register_label);
            this.login_register_split.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.login_register_split.Size = new System.Drawing.Size(984, 512);
            this.login_register_split.SplitterDistance = 374;
            this.login_register_split.TabIndex = 0;
            // 
            // password_textbox
            // 
            this.password_textbox.Location = new System.Drawing.Point(120, 203);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.PasswordChar = '*';
            this.password_textbox.Size = new System.Drawing.Size(161, 20);
            this.password_textbox.TabIndex = 6;
            // 
            // username_textbox
            // 
            this.username_textbox.Location = new System.Drawing.Point(120, 157);
            this.username_textbox.Name = "username_textbox";
            this.username_textbox.Size = new System.Drawing.Size(161, 20);
            this.username_textbox.TabIndex = 5;
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(184, 265);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 4;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(27, 265);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(75, 23);
            this.login_button.TabIndex = 3;
            this.login_button.Text = "Login";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(24, 203);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(53, 13);
            this.password_label.TabIndex = 2;
            this.password_label.Text = "Password";
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Location = new System.Drawing.Point(24, 165);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(55, 13);
            this.username_label.TabIndex = 1;
            this.username_label.Text = "Username";
            // 
            // login_label
            // 
            this.login_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_label.Location = new System.Drawing.Point(114, 67);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(83, 38);
            this.login_label.TabIndex = 0;
            this.login_label.Text = "Login";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.female_radiobutton);
            this.groupBox1.Controls.Add(this.male_radiobutton);
            this.groupBox1.Location = new System.Drawing.Point(256, 370);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 62);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // female_radiobutton
            // 
            this.female_radiobutton.AutoSize = true;
            this.female_radiobutton.Location = new System.Drawing.Point(7, 39);
            this.female_radiobutton.Name = "female_radiobutton";
            this.female_radiobutton.Size = new System.Drawing.Size(59, 17);
            this.female_radiobutton.TabIndex = 1;
            this.female_radiobutton.TabStop = true;
            this.female_radiobutton.Text = "Female";
            this.female_radiobutton.UseVisualStyleBackColor = true;
            // 
            // male_radiobutton
            // 
            this.male_radiobutton.AutoSize = true;
            this.male_radiobutton.Location = new System.Drawing.Point(7, 11);
            this.male_radiobutton.Name = "male_radiobutton";
            this.male_radiobutton.Size = new System.Drawing.Size(48, 17);
            this.male_radiobutton.TabIndex = 0;
            this.male_radiobutton.TabStop = true;
            this.male_radiobutton.Text = "Male";
            this.male_radiobutton.UseVisualStyleBackColor = true;
            // 
            // gender_label
            // 
            this.gender_label.AutoSize = true;
            this.gender_label.Location = new System.Drawing.Point(105, 370);
            this.gender_label.Name = "gender_label";
            this.gender_label.Size = new System.Drawing.Size(42, 13);
            this.gender_label.TabIndex = 17;
            this.gender_label.Text = "Gender";
            // 
            // confirm_register_password_textbox
            // 
            this.confirm_register_password_textbox.Location = new System.Drawing.Point(256, 329);
            this.confirm_register_password_textbox.Name = "confirm_register_password_textbox";
            this.confirm_register_password_textbox.PasswordChar = '*';
            this.confirm_register_password_textbox.Size = new System.Drawing.Size(100, 20);
            this.confirm_register_password_textbox.TabIndex = 16;
            // 
            // register_password_textbox
            // 
            this.register_password_textbox.Location = new System.Drawing.Point(256, 298);
            this.register_password_textbox.Name = "register_password_textbox";
            this.register_password_textbox.PasswordChar = '*';
            this.register_password_textbox.Size = new System.Drawing.Size(100, 20);
            this.register_password_textbox.TabIndex = 15;
            // 
            // register_username_textbox
            // 
            this.register_username_textbox.Location = new System.Drawing.Point(256, 262);
            this.register_username_textbox.Name = "register_username_textbox";
            this.register_username_textbox.Size = new System.Drawing.Size(100, 20);
            this.register_username_textbox.TabIndex = 14;
            // 
            // ssn_textbox
            // 
            this.ssn_textbox.Location = new System.Drawing.Point(256, 229);
            this.ssn_textbox.MaxLength = 10;
            this.ssn_textbox.Name = "ssn_textbox";
            this.ssn_textbox.Size = new System.Drawing.Size(100, 20);
            this.ssn_textbox.TabIndex = 13;
            // 
            // last_name_textbox
            // 
            this.last_name_textbox.Location = new System.Drawing.Point(256, 191);
            this.last_name_textbox.Name = "last_name_textbox";
            this.last_name_textbox.Size = new System.Drawing.Size(100, 20);
            this.last_name_textbox.TabIndex = 12;
            // 
            // first_name_textbox
            // 
            this.first_name_textbox.Location = new System.Drawing.Point(256, 154);
            this.first_name_textbox.Name = "first_name_textbox";
            this.first_name_textbox.Size = new System.Drawing.Size(100, 20);
            this.first_name_textbox.TabIndex = 11;
            // 
            // cancel_register_button
            // 
            this.cancel_register_button.Location = new System.Drawing.Point(281, 453);
            this.cancel_register_button.Name = "cancel_register_button";
            this.cancel_register_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_register_button.TabIndex = 10;
            this.cancel_register_button.Text = "cancel";
            this.cancel_register_button.UseVisualStyleBackColor = true;
            this.cancel_register_button.Click += new System.EventHandler(this.cancelRegisterButton_Click);
            // 
            // register_button
            // 
            this.register_button.Location = new System.Drawing.Point(116, 453);
            this.register_button.Name = "register_button";
            this.register_button.Size = new System.Drawing.Size(75, 23);
            this.register_button.TabIndex = 9;
            this.register_button.Text = "Register";
            this.register_button.UseVisualStyleBackColor = true;
            this.register_button.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // confirm_register_password_label
            // 
            this.confirm_register_password_label.AutoSize = true;
            this.confirm_register_password_label.Location = new System.Drawing.Point(102, 332);
            this.confirm_register_password_label.Name = "confirm_register_password_label";
            this.confirm_register_password_label.Size = new System.Drawing.Size(89, 13);
            this.confirm_register_password_label.TabIndex = 8;
            this.confirm_register_password_label.Text = "Retype password";
            // 
            // register_password_label
            // 
            this.register_password_label.AutoSize = true;
            this.register_password_label.Location = new System.Drawing.Point(102, 301);
            this.register_password_label.Name = "register_password_label";
            this.register_password_label.Size = new System.Drawing.Size(53, 13);
            this.register_password_label.TabIndex = 7;
            this.register_password_label.Text = "Password";
            // 
            // register_username_label
            // 
            this.register_username_label.AutoSize = true;
            this.register_username_label.Location = new System.Drawing.Point(102, 265);
            this.register_username_label.Name = "register_username_label";
            this.register_username_label.Size = new System.Drawing.Size(55, 13);
            this.register_username_label.TabIndex = 4;
            this.register_username_label.Text = "Username";
            // 
            // ssn_label
            // 
            this.ssn_label.AutoSize = true;
            this.ssn_label.Location = new System.Drawing.Point(102, 232);
            this.ssn_label.Name = "ssn_label";
            this.ssn_label.Size = new System.Drawing.Size(29, 13);
            this.ssn_label.TabIndex = 3;
            this.ssn_label.Text = "SSN";
            // 
            // last_name_label
            // 
            this.last_name_label.AutoSize = true;
            this.last_name_label.Location = new System.Drawing.Point(102, 194);
            this.last_name_label.Name = "last_name_label";
            this.last_name_label.Size = new System.Drawing.Size(58, 13);
            this.last_name_label.TabIndex = 2;
            this.last_name_label.Text = "Last Name";
            // 
            // first_name_label
            // 
            this.first_name_label.AutoSize = true;
            this.first_name_label.Location = new System.Drawing.Point(102, 157);
            this.first_name_label.Name = "first_name_label";
            this.first_name_label.Size = new System.Drawing.Size(57, 13);
            this.first_name_label.TabIndex = 1;
            this.first_name_label.Text = "First Name";
            // 
            // register_label
            // 
            this.register_label.AutoSize = true;
            this.register_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_label.Location = new System.Drawing.Point(201, 67);
            this.register_label.Name = "register_label";
            this.register_label.Size = new System.Drawing.Size(116, 31);
            this.register_label.TabIndex = 0;
            this.register_label.Text = "Register";
            // 
            // loginpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 512);
            this.Controls.Add(this.login_register_split);
            this.Name = "loginpage";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.login_register_split.Panel1.ResumeLayout(false);
            this.login_register_split.Panel1.PerformLayout();
            this.login_register_split.Panel2.ResumeLayout(false);
            this.login_register_split.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.login_register_split)).EndInit();
            this.login_register_split.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer login_register_split;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.TextBox username_textbox;
        private System.Windows.Forms.Label register_label;
        private System.Windows.Forms.Button cancel_register_button;
        private System.Windows.Forms.Button register_button;
        private System.Windows.Forms.Label confirm_register_password_label;
        private System.Windows.Forms.Label register_password_label;
        private System.Windows.Forms.Label register_username_label;
        private System.Windows.Forms.Label ssn_label;
        private System.Windows.Forms.Label last_name_label;
        private System.Windows.Forms.Label first_name_label;
        private System.Windows.Forms.TextBox confirm_register_password_textbox;
        private System.Windows.Forms.TextBox register_password_textbox;
        private System.Windows.Forms.TextBox register_username_textbox;
        private System.Windows.Forms.TextBox ssn_textbox;
        private System.Windows.Forms.TextBox last_name_textbox;
        private System.Windows.Forms.TextBox first_name_textbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton female_radiobutton;
        private System.Windows.Forms.RadioButton male_radiobutton;
        private System.Windows.Forms.Label gender_label;
    }
}