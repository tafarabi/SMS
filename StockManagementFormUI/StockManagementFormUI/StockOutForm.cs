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
    public partial class StockOutForm : Form
    {
        public string _categoryId;
        public string _companyId;
        public int _itemId;
        public int _availq;
        public int i = 0;
        DataTable dt = new DataTable();
        static string connectionString = @"server=DESKTOP-412B1P8\SQLEXPRESS; database=StockManagement; integrated security=true";

        SqlConnection con = new SqlConnection(connectionString);

        public StockOutForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            /**/
            Transactions transactions = new Transactions();
            i++;
            
            DataRow dr = dt.NewRow();
            dr[0] = i;
            dr[1] = itemComboBox.Text;
            dr[2] = Convert.ToInt32(itemComboBox.SelectedValue.ToString()); ;
            dr[3] = companyComboBox.Text;
            dr[4] = stockInQuantityTextBox.Text;
            dr[5] = Update(transactions);
            dataGridView1.DataSource = dt;
            dt.Rows.Add(dr);

            

        }

        private void StockOutForm_Load(object sender, EventArgs e)
        {
            CateroyCompanyCombo();

            dt.Columns.Add("SL.");
            dt.Columns.Add("Item");
            dt.Columns.Add("ItemId");
            dt.Columns.Add("Company");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Avail");
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["ItemId"].Visible = false;
            dataGridView1.Columns["Avail"].Visible = false;
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

         private void Add(StockInOut stockInOut)
        {

             foreach (DataGridViewRow rows in dataGridView1.Rows)
             {
                 Transactions transactions = new Transactions();
                 DateTime today = DateTime.Today;
                 stockInOut.ItemId = Convert.ToInt32(rows.Cells["ItemId"].Value);
                 stockInOut.Quantity = Convert.ToInt32(rows.Cells["Quantity"].Value);
                 stockInOut.StockId = 2;
                 
                 stockInOut.Date = today.ToString("dd/MM/yyyy");
                 _availq = Convert.ToInt32(rows.Cells["Avail"].Value) - stockInOut.Quantity;
                 transactions.AvailableQuantity = _availq;
                 if (stockInOut.ItemId>0)
                 {
                     string connectionString = @"server=DESKTOP-412B1P8\SQLEXPRESS; database=StockManagement; integrated security=true";

                     SqlConnection con = new SqlConnection(connectionString);

                     string query = @"INSERT INTO StockInOut VALUES('" + stockInOut.ItemId + "','" + stockInOut.Quantity + "','" +
                                    stockInOut.StockId + "','" + stockInOut.Date + "','" + stockInOut.Status + "') UPDATE Transactions SET AvailableQuantity = '" + _availq + "' WHERE ItemId = '" + stockInOut.ItemId + "' ";
                     SqlCommand command = new SqlCommand(query, con);

                     con.Open();

                     bool isAdded = command.ExecuteNonQuery() > 0;


                     con.Close();
                 }
                 
                
             }

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

         private void SellButton_Click(object sender, EventArgs e)
         {


             try
             {
                 StockInOut stockInOut = new StockInOut();
                 stockInOut.Status = 1.ToString();
                 Add(stockInOut);
                 dataGridView1.DataSource = null;

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             
         }

         private void DamageButton_Click(object sender, EventArgs e)
         {
             try
             {
                 StockInOut stockInOut = new StockInOut();
                 stockInOut.Status = 2.ToString();
                 Add(stockInOut);
                 dataGridView1.DataSource = null;

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         private void LostButton_Click(object sender, EventArgs e)
         {
             try
             {
                 StockInOut stockInOut = new StockInOut();
                 stockInOut.Status = 3.ToString();
                 Add(stockInOut);
                 dataGridView1.DataSource = null;

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }





    }
}
