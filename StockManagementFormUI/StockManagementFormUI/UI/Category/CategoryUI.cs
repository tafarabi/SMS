using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StockManagementFormUI.BLL;
using StockManagementFormUI.Model;

namespace StockManagementFormUI.UI.Category
{
    public partial class CategoryUI : Form
    {
        static string _connectionString = @"server=DESKTOP-412B1P8\SQLEXPRESS;Database=StockManagement;Integrated security=true";
        static SqlConnection _con = new SqlConnection(_connectionString);
        int _id;
        public CategoryUI()
        {
            InitializeComponent();
        }
        Manager _manager = new Manager();
        Person person = new Person();
        
        public void saveButton_Click(object sender, EventArgs e)
        {
            person.CategoryName = categoryNameTextBox.Text;
            
            if (saveButton.Text == "Save")
            {
               


                bool isAdded = _manager.Add(person);
            }
            else
            {
                bool isUpdate = _manager.Update(person);
            }
            
            
        }

        public void showButton_Click(object sender, EventArgs e)
        {
            
        }

        private void categoryDatagridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            categoryNameTextBox.Text = categoryDatagridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            person.Id = Convert.ToInt32(GetId(categoryDatagridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
        }

        private int GetId(string p)
        {
            string query = @"Select * from Categories WHERE Name = '"+ p +"'";
            SqlCommand command = new SqlCommand(query, _con);
            _con.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {

                person.Id = Convert.ToInt32(dr["Id"].ToString());

            }

            _con.Close();
            return person.Id;
        }

        private void categoryDatagridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            saveButton.Text = "Update";

            
        }

        private void CategoryUI_Load(object sender, EventArgs e)
        {
            string query = @"SELECT Name FROM Categories";
            SqlCommand command = new SqlCommand(query, _con);
            _con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            categoryDatagridView.DataSource = dt;

            _con.Close();
        }

        
    }
}
