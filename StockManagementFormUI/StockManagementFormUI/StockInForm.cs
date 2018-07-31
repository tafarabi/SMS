using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementFormUI.Model;

namespace StockManagementFormUI
{
    public partial class StockInForm : Form
    {
        public string _categoryId;
        public string _companyId;

        static string connectionString = @"server=DESKTOP-412B1P8\SQLEXPRESS; database=StockManagement; integrated security=true";

        SqlConnection con = new SqlConnection(connectionString);

        public StockInForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            StockInOut stockInOut = new StockInOut();


            MessageBox.Show(categoryComboBox.SelectedValue.ToString());
        }

        private void StockInForm_Load(object sender, EventArgs e)
        {
            
            string query = @"SELECT Id,Name FROM Companies";
            string query1 = @"SELECT Id,Name FROM Categories";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
            con.Open();


            DataSet ds = new DataSet();
            da.Fill(ds, "Company");

            companyComboBox.ValueMember = "Id";
            companyComboBox.DisplayMember = "Name";
            companyComboBox.DataSource = ds.Tables["Company"];

           

            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "Category");

            categoryComboBox.ValueMember = "Id";
            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.DataSource = ds1.Tables["Category"];

            
            con.Close();
           

        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            StockInOut stockInOut = new StockInOut();
            GetItem(stockInOut);
        }

        private void GetItem(StockInOut stockInOut)
        {
            stockInOut.categoryId = categoryComboBox.SelectedValue.ToString();

            string query = @"SELECT Id,Name FROM Items where CategoryId = stockInOut.categoryId";
   

            SqlDataAdapter da = new SqlDataAdapter(query, con);
    
            con.Open();


            DataSet ds = new DataSet();
            da.Fill(ds, "Item");

            itemComboBox.ValueMember = "Id";
            itemComboBox.DisplayMember = "Name";
            itemComboBox.DataSource = ds.Tables["Item"];

            con.Close();
        }
    }
}
