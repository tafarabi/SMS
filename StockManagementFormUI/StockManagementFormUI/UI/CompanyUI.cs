using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using StockManagementFormUI.BLL;
using StockManagementFormUI.Model;

namespace StockManagementInfoApp.UI
{
    public partial class CompanyUI : Form
    {
        static string _connectionString = @"server=DESKTOP-412B1P8\SQLEXPRESS;Database=StockManagement;Integrated security=true";
        static SqlConnection _con = new SqlConnection(_connectionString);
        public CompanyUI()
        {
            InitializeComponent();
        }
        Person person = new Person();
        Manager _mamager = new Manager();
        private void companyButton_Click(object sender, EventArgs e)
        {
            person.CompanyName = companyTextBox.Text;
            bool isAdded = _mamager.CompanyAdd(person);
        }

        public void show_Click(object sender, EventArgs e)
        {
           
        }

        private void CompanyUI_Load(object sender, EventArgs e)
        {
            string query = @"SELECT * FROM Companies";
            SqlCommand command = new SqlCommand(query, _con);
            _con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            companyDataGridView.DataSource = dt;
        }
    }
}
