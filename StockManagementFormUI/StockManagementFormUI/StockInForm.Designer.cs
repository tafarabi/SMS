namespace StockManagementFormUI
{
    partial class StockInForm
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
            this.companyComboBox = new System.Windows.Forms.ComboBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.itemComboBox = new System.Windows.Forms.ComboBox();
            this.reorderLabel = new System.Windows.Forms.Label();
            this.availableQuantityLabel = new System.Windows.Forms.Label();
            this.stockInQuantityTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // companyComboBox
            // 
            this.companyComboBox.FormattingEnabled = true;
            this.companyComboBox.Location = new System.Drawing.Point(181, 22);
            this.companyComboBox.Name = "companyComboBox";
            this.companyComboBox.Size = new System.Drawing.Size(162, 21);
            this.companyComboBox.TabIndex = 0;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(181, 63);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(162, 21);
            this.categoryComboBox.TabIndex = 1;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // itemComboBox
            // 
            this.itemComboBox.FormattingEnabled = true;
            this.itemComboBox.Location = new System.Drawing.Point(181, 106);
            this.itemComboBox.Name = "itemComboBox";
            this.itemComboBox.Size = new System.Drawing.Size(162, 21);
            this.itemComboBox.TabIndex = 2;
            // 
            // reorderLabel
            // 
            this.reorderLabel.AutoSize = true;
            this.reorderLabel.Location = new System.Drawing.Point(205, 147);
            this.reorderLabel.Name = "reorderLabel";
            this.reorderLabel.Size = new System.Drawing.Size(35, 13);
            this.reorderLabel.TabIndex = 3;
            this.reorderLabel.Text = "label1";
            // 
            // availableQuantityLabel
            // 
            this.availableQuantityLabel.AutoSize = true;
            this.availableQuantityLabel.Location = new System.Drawing.Point(205, 174);
            this.availableQuantityLabel.Name = "availableQuantityLabel";
            this.availableQuantityLabel.Size = new System.Drawing.Size(35, 13);
            this.availableQuantityLabel.TabIndex = 4;
            this.availableQuantityLabel.Text = "label2";
            // 
            // stockInQuantityTextBox
            // 
            this.stockInQuantityTextBox.Location = new System.Drawing.Point(184, 214);
            this.stockInQuantityTextBox.Name = "stockInQuantityTextBox";
            this.stockInQuantityTextBox.Size = new System.Drawing.Size(159, 20);
            this.stockInQuantityTextBox.TabIndex = 5;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(268, 259);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Company";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(122, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Category";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(144, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Item";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Reorder Level";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(79, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Available Quantity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Stock In Quantity";
            // 
            // StockInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 359);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.stockInQuantityTextBox);
            this.Controls.Add(this.availableQuantityLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reorderLabel);
            this.Controls.Add(this.itemComboBox);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.companyComboBox);
            this.Name = "StockInForm";
            this.Text = "Stock In";
            this.Load += new System.EventHandler(this.StockInForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox companyComboBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.ComboBox itemComboBox;
        private System.Windows.Forms.Label reorderLabel;
        private System.Windows.Forms.Label availableQuantityLabel;
        private System.Windows.Forms.TextBox stockInQuantityTextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}