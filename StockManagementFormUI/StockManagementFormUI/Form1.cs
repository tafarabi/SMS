using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementFormUI.UI.Category;
using StockManagementInfoApp.UI;

namespace StockManagementFormUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f1 = new CategoryUI();
            f1.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f2 = new CompanyUI();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f3 = new ItemCreateUI();
            f3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form f4 = new StockInForm();
            f4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form f5 = new StockOutForm();
            f5.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form f6 = new SearchAndViewItems();
            f6.ShowDialog();
        }
    }
}
