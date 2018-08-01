using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StockManagementFormUI
{
    public partial class SearchAndViewItems : Form
    {
        static string connectString = @"server=DESKTOP-412B1P8\SQLEXPRESS; database=StockManagement; integrated security=true";

        SqlConnection con = new SqlConnection(connectString);
        public SearchAndViewItems()
        {
            InitializeComponent();
        }

        private void SearchAndViewItems_Load(object sender, EventArgs e)
        {
            CategoryComboBox();
            companyComboBox1();
            companyComboBox.Text = String.Empty;
            categoryComboBox.Text = String.Empty;
        }
        private void companyComboBox1()
        {
            string query = "select Id, Name from Companies";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "Companies");
            companyComboBox.DisplayMember = "Name";
            companyComboBox.ValueMember = "Id";
            companyComboBox.DataSource = ds.Tables["Companies"];
            con.Close();
        }

        private void CategoryComboBox()
        {
            string query = "select Id, Name from Categories";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "Categories");
            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.ValueMember = "Id";
            categoryComboBox.DataSource = ds.Tables["Categories"];
            con.Close();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                int categoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
                int companyId = Convert.ToInt32(companyComboBox.SelectedValue);
                //essageBox.Show(categoryId + " " + companyId);
                con.Open();
                //string query = "select * from Items WHERE categoryId = '" + categoryId + "'";
                string query = "SELECT i.Name Item,c.Name Category,cm.Name Company,AvailableQuantity,ReorderLevel FROM Items as i INNER JOIN Categories c ON c.Id = i.CategoryId INNER JOIN Companies cm ON cm.Id = i.CompanyId INNER JOIN Transactions  t ON t.ItemId = i.Id WHERE categoryId = '" + categoryId + "' AND CompanyId = '" + companyId + "'";
                SqlDataAdapter dataadapter = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                dataadapter.Fill(ds, "Items");
                itemDataGridView.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
