using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementInfoApp.UI.Category;
using StockManagementInfoApp.UI;

namespace StockManagementInfoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void setupCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryUI categoryUi = new CategoryUI();
            categoryUi.Show();
        }

        public void setupCompanyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CompanyUI companyUi = new CompanyUI();
            companyUi.Show();
        }
    }
}
