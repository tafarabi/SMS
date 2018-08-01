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

        static string connectionString = @"server=DESKTOP-412B1P8\SQLEXPRESS; database=StockManagement; integrated security=true";

        SqlConnection con = new SqlConnection(connectionString);

        public StockInForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                StockInOut stockInOut = new StockInOut();
                Transactions transactions = new Transactions();
                DateTime today = DateTime.Today;
                stockInOut.ItemId = Convert.ToInt32(itemComboBox.SelectedValue.ToString());
                stockInOut.Quantity = Convert.ToInt32(stockInQuantityTextBox.Text);
                stockInOut.StockId = 1;
                stockInOut.Status = null;
                stockInOut.Date = today.ToString("dd/MM/yyyy");
                _availq = Update(transactions) + stockInOut.Quantity;
                transactions.AvailableQuantity = _availq;
               bool isAdded = Add(stockInOut);
                if (isAdded)
                {
                    MessageBox.Show("Stock In successfully");
                }
                else
                {
                    MessageBox.Show("Error");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StockInForm_Load(object sender, EventArgs e)
        {
            CateroyCompanyCombo();
        }

        private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryComboBox.Text = string.Empty;
            itemComboBox.Text = string.Empty;
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemCombo();
        }

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            _itemId = Convert.ToInt32(itemComboBox.SelectedValue.ToString());
            StockInOut stockInOut = new StockInOut();
            if (itemComboBox.SelectedIndex > 0)
            {
                reorderLabel.Text = OrderLevelCheck(stockInOut).ToString();
                availableQuantityLabel.Text = availLevelCheck(stockInOut).ToString();
            }


        }
        private void CateroyCompanyCombo()
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

        private void ItemCombo()
        {

            _companyId = companyComboBox.SelectedValue.ToString();
            _categoryId = categoryComboBox.SelectedValue.ToString();
            string query = @"Select Id,Name from Items where CompanyId =  '" + _companyId + "' AND CategoryId = '" + _categoryId + "'";


            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable ds = new DataTable();
            da.Fill(ds);

            DataRow row = ds.NewRow();
            row[0] = 0;
            row[1] = "-------";
            ds.Rows.InsertAt(row, 0);



            itemComboBox.ValueMember = "Id";
            itemComboBox.DisplayMember = "Name";
            itemComboBox.DataSource = ds;
            itemComboBox.Text = string.Empty;
            con.Close();
        }


        private int Update(Transactions transactions)
        {
            Int32 Availableq=0;
            string connectionString = @"server=DESKTOP-412B1P8\SQLEXPRESS; database=StockManagement; integrated security=true";

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
            string connectionString = @"server=DESKTOP-412B1P8\SQLEXPRESS; database=StockManagement; integrated security=true";

            SqlConnection con = new SqlConnection(connectionString);

            string query = @"INSERT INTO StockInOut VALUES('" + stockInOut.ItemId + "','" + stockInOut.Quantity + "','" +
                           stockInOut.StockId + "','" + stockInOut.Date + "','" + stockInOut.Status + "') UPDATE Transactions SET AvailableQuantity = '" + _availq + "' WHERE ItemId = '" + _itemId + "' ";
            SqlCommand command = new SqlCommand(query, con);

            con.Open();

            bool isAdded = command.ExecuteNonQuery() > 0;


            con.Close();
            return isAdded;
        }

         private int OrderLevelCheck(StockInOut stockInOut)
         {
             Int32 reorder = 0;
             string connectionString = @"server=DESKTOP-412B1P8\SQLEXPRESS; database=StockManagement; integrated security=true";

             SqlConnection con = new SqlConnection(connectionString);
             string query = @"SELECT ReorderLevel FROM Items WHERE Id = '" + _itemId + "' ";
             SqlCommand command = new SqlCommand(query, con);
             
             con.Open();
             reorder = (int)command.ExecuteScalar();
             con.Close();
             return reorder;
         }

         private int availLevelCheck(StockInOut stockInOut)
         {
             Int32 avail = 0;
             string connectionString = @"server=DESKTOP-412B1P8\SQLEXPRESS; database=StockManagement; integrated security=true";

             SqlConnection con = new SqlConnection(connectionString);
             string query = @"SELECT AvailableQuantity FROM Transactions WHERE ItemId = '" + _itemId + "'  ";
             SqlCommand command = new SqlCommand(query, con);

             con.Open();
             avail = (int)command.ExecuteScalar();
             con.Close();
             return avail;
         }
    }
}
