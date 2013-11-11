namespace Movies
{
    partial class write_update_reviewForm
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
            this.save_review_button = new System.Windows.Forms.Button();
            this.cancel_review_button = new System.Windows.Forms.Button();
            this.review_textbox = new System.Windows.Forms.TextBox();
            this.review_label = new System.Windows.Forms.Label();
            this.rating_label = new System.Windows.Forms.Label();
            this.rating_spinner = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.rating_spinner)).BeginInit();
            this.SuspendLayout();
            // 
            // save_review_button
            // 
            this.save_review_button.Location = new System.Drawing.Point(273, 226);
            this.save_review_button.Name = "save_review_button";
            this.save_review_button.Size = new System.Drawing.Size(75, 23);
            this.save_review_button.TabIndex = 0;
            this.save_review_button.Text = "Save";
            this.save_review_button.UseVisualStyleBackColor = true;
            this.save_review_button.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // cancel_review_button
            // 
            this.cancel_review_button.Location = new System.Drawing.Point(369, 226);
            this.cancel_review_button.Name = "cancel_review_button";
            this.cancel_review_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_review_button.TabIndex = 1;
            this.cancel_review_button.Text = "Cancel";
            this.cancel_review_button.UseVisualStyleBackColor = true;
            this.cancel_review_button.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // review_textbox
            // 
            this.review_textbox.Location = new System.Drawing.Point(31, 90);
            this.review_textbox.Multiline = true;
            this.review_textbox.Name = "review_textbox";
            this.review_textbox.Size = new System.Drawing.Size(672, 108);
            this.review_textbox.TabIndex = 2;
            // 
            // review_label
            // 
            this.review_label.AutoSize = true;
            this.review_label.Location = new System.Drawing.Point(31, 71);
            this.review_label.Name = "review_label";
            this.review_label.Size = new System.Drawing.Size(71, 13);
            this.review_label.TabIndex = 3;
            this.review_label.Text = "Your Review:";
            // 
            // rating_label
            // 
            this.rating_label.AutoSize = true;
            this.rating_label.Location = new System.Drawing.Point(31, 43);
            this.rating_label.Name = "rating_label";
            this.rating_label.Size = new System.Drawing.Size(38, 13);
            this.rating_label.TabIndex = 4;
            this.rating_label.Text = "Rating";
            // 
            // rating_spinner
            // 
            this.rating_spinner.Location = new System.Drawing.Point(76, 41);
            this.rating_spinner.Name = "rating_spinner";
            this.rating_spinner.Size = new System.Drawing.Size(49, 20);
            this.rating_spinner.TabIndex = 5;
            // 
            // write_update_reviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 261);
            this.Controls.Add(this.rating_spinner);
            this.Controls.Add(this.rating_label);
            this.Controls.Add(this.review_label);
            this.Controls.Add(this.review_textbox);
            this.Controls.Add(this.cancel_review_button);
            this.Controls.Add(this.save_review_button);
            this.Name = "write_update_reviewForm";
            this.Text = "Write / Update Review";
            ((System.ComponentModel.ISupportInitialize)(this.rating_spinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save_review_button;
        private System.Windows.Forms.Button cancel_review_button;
        private System.Windows.Forms.TextBox review_textbox;
        private System.Windows.Forms.Label review_label;
        private System.Windows.Forms.Label rating_label;
        private System.Windows.Forms.NumericUpDown rating_spinner;
    }
}