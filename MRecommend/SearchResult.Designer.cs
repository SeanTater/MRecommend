namespace Movies
{
    partial class SearchResult
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
            this.search_label = new System.Windows.Forms.Label();
            this.advanced_search_button = new System.Windows.Forms.Button();
            this.search_button = new System.Windows.Forms.Button();
            this.search_textbox = new System.Windows.Forms.TextBox();
            this.search_results_panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // search_label
            // 
            this.search_label.AutoSize = true;
            this.search_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_label.Location = new System.Drawing.Point(46, 53);
            this.search_label.Name = "search_label";
            this.search_label.Size = new System.Drawing.Size(145, 17);
            this.search_label.TabIndex = 30;
            this.search_label.Text = "Search for a movie";
            // 
            // advanced_search_button
            // 
            this.advanced_search_button.Location = new System.Drawing.Point(556, 83);
            this.advanced_search_button.Name = "advanced_search_button";
            this.advanced_search_button.Size = new System.Drawing.Size(120, 23);
            this.advanced_search_button.TabIndex = 29;
            this.advanced_search_button.Text = "Advanced Search";
            this.advanced_search_button.UseVisualStyleBackColor = true;
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(451, 83);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(75, 23);
            this.search_button.TabIndex = 28;
            this.search_button.Text = "Go";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.query);
            // 
            // search_textbox
            // 
            this.search_textbox.AllowDrop = true;
            this.search_textbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.search_textbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.search_textbox.Location = new System.Drawing.Point(43, 85);
            this.search_textbox.MaxLength = 30;
            this.search_textbox.Name = "search_textbox";
            this.search_textbox.Size = new System.Drawing.Size(367, 20);
            this.search_textbox.TabIndex = 27;
            // 
            // search_results_panel
            // 
            this.search_results_panel.Location = new System.Drawing.Point(43, 137);
            this.search_results_panel.Name = "search_results_panel";
            this.search_results_panel.Size = new System.Drawing.Size(613, 339);
            this.search_results_panel.TabIndex = 31;
            // 
            // SearchResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 542);
            this.Controls.Add(this.search_results_panel);
            this.Controls.Add(this.search_label);
            this.Controls.Add(this.advanced_search_button);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.search_textbox);
            this.Name = "SearchResult";
            this.Text = "SearchResult";
            this.Load += new System.EventHandler(this.query);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label search_label;
        private System.Windows.Forms.Button advanced_search_button;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox search_textbox;
        private System.Windows.Forms.Panel search_results_panel;
    }
}