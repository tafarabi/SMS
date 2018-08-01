namespace StockManagementInfoApp.UI
{
    partial class CompanyUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.companyTextBox = new System.Windows.Forms.TextBox();
            this.companyButton = new System.Windows.Forms.Button();
            this.companyDataGridView = new System.Windows.Forms.DataGridView();
            this.show = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // companyTextBox
            // 
            this.companyTextBox.Location = new System.Drawing.Point(163, 55);
            this.companyTextBox.Name = "companyTextBox";
            this.companyTextBox.Size = new System.Drawing.Size(169, 20);
            this.companyTextBox.TabIndex = 1;
            // 
            // companyButton
            // 
            this.companyButton.Location = new System.Drawing.Point(163, 97);
            this.companyButton.Name = "companyButton";
            this.companyButton.Size = new System.Drawing.Size(75, 23);
            this.companyButton.TabIndex = 2;
            this.companyButton.Text = "Save";
            this.companyButton.UseVisualStyleBackColor = true;
            this.companyButton.Click += new System.EventHandler(this.companyButton_Click);
            // 
            // companyDataGridView
            // 
            this.companyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.companyDataGridView.Location = new System.Drawing.Point(67, 179);
            this.companyDataGridView.Name = "companyDataGridView";
            this.companyDataGridView.Size = new System.Drawing.Size(381, 171);
            this.companyDataGridView.TabIndex = 3;
            // 
            // show
            // 
            this.show.Location = new System.Drawing.Point(257, 97);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(75, 23);
            this.show.TabIndex = 4;
            this.show.Text = "Show";
            this.show.UseVisualStyleBackColor = true;
            this.show.Click += new System.EventHandler(this.show_Click);
            // 
            // CompanyUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 395);
            this.Controls.Add(this.show);
            this.Controls.Add(this.companyDataGridView);
            this.Controls.Add(this.companyButton);
            this.Controls.Add(this.companyTextBox);
            this.Controls.Add(this.label1);
            this.Name = "CompanyUI";
            this.Text = "CompanyUI";
            this.Load += new System.EventHandler(this.CompanyUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.companyDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox companyTextBox;
        private System.Windows.Forms.Button companyButton;
        private System.Windows.Forms.DataGridView companyDataGridView;
        private System.Windows.Forms.Button show;
    }
}