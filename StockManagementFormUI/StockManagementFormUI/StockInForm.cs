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
        public int _itemId;
        public int _availq;

        static string connectionString = @"server=PC-301-22\SQLEXPRESS; database=StockManagement; integrated security=true";

        SqlConnection con = new SqlConnection(connectionString);

        public StockInForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            StockInOut stockInOut = new StockInOut();
            Transactions transactions = new Transactions();
            DateTime today = DateTime.Today;
            stockInOut.ItemId = Convert.ToInt32(itemComboBox.SelectedValue.ToString());
            stockInOut.Quantity = Convert.ToInt32(stockInQuantityTextBox.Text);
            stockInOut.StockId = 1;
            stockInOut.Status = null;
            stockInOut.Date = today.ToString("dd/MM/yyyy");
           // _itemId = stockInOut.ItemId;
            _availq = Update(transactions) + stockInOut.Quantity;
            transactions.AvailableQuantity = _availq;
            Add(stockInOut);

            MessageBox.Show(transactions.AvailableQuantity.ToString());

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
            
            _companyId = companyComboBox.SelectedValue.ToString();
            _categoryId = categoryComboBox.SelectedValue.ToString();
            string query = @"Select Id,Name from Items where CompanyId =  '" + _companyId + "' AND CategoryId = '" + _categoryId + "'";


            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Item");
            itemComboBox.ValueMember = "Id";
            itemComboBox.DisplayMember = "Name";
            itemComboBox.DataSource = ds.Tables["Item"];
            
            con.Close();

            itemComboBox.Text = string.Empty;
           
        }




        private int Update(Transactions transactions)
        {
            Int32 Availableq=0;
            string connectionString = @"server=PC-301-22\SQLEXPRESS; database=StockManagement; integrated security=true";

            SqlConnection con = new SqlConnection(connectionString);

            string query = @"select AvailableQuantity from Transactions  where ItemId = '" + _itemId + "'";
            SqlCommand command = new SqlCommand(query, con);

            con.Open();

            Availableq = (int) command.ExecuteScalar();


            con.Close();
            return Availableq;
        }

         private bool Add(StockInOut stockInOut)
        {
            string connectionString = @"server=PC-301-22\SQLEXPRESS; database=StockManagement; integrated security=true";

            SqlConnection con = new SqlConnection(connectionString);

            string query = @"INSERT INTO StockInOut VALUES('" + stockInOut.ItemId + "','" + stockInOut.Quantity + "','" +
                           stockInOut.StockId + "','" + stockInOut.Date + "','" + stockInOut.Status + "') UPDATE Transactions SET AvailableQuantity = '" + _availq + "' WHERE ItemId = '" + _itemId + "' ";
            SqlCommand command = new SqlCommand(query, con);

            con.Open();

            bool isAdded = command.ExecuteNonQuery() > 0;


            con.Close();
            return isAdded;
        }

         private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
         {
             categoryComboBox.Text = string.Empty;
             itemComboBox.Text = string.Empty;
         }

         private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
         {
           
         }
        
            
        
    }
}
