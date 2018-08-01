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
    public partial class ItemCreateUI : Form
    {
        static string connectString = @"server=DESKTOP-412B1P8\SQLEXPRESS; database=StockManagement; integrated security=true";

        SqlConnection con = new SqlConnection(connectString);
        public ItemCreateUI()
        {
            InitializeComponent();
        }

        private void ItemCreateUI_Load(object sender, EventArgs e)
        {
            CategoryComboBox();
            companyComboBox();
        }

        private void companyComboBox()
        {
            string query = "select Id, Name from Companies";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "Companies");
            compComboBox.DisplayMember = "Name";
            compComboBox.ValueMember = "Id";
            compComboBox.DataSource = ds.Tables["Companies"];
            con.Close();
        }

        private void CategoryComboBox()
        {
            string query = "select Id, Name from Categories";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "Categories");
            catComboBox.DisplayMember = "Name";
            catComboBox.ValueMember = "Id";
            catComboBox.DataSource = ds.Tables["Categories"];
            con.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Item item = new Item();
           
                item.CategoryId = Convert.ToInt32(catComboBox.SelectedValue);
                item.CompanyId = Convert.ToInt32(compComboBox.SelectedValue);
                item.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
                item.Name = nameTextBox.Text;
                if (!Check(item))
                {
                    bool isAdded = Add(item);

                    if (isAdded)
                    {
                        MessageBox.Show("Item inserted Successfully");

                    }
                    else
                    {
                        MessageBox.Show("Failed");
                    }
                }

                int id = GetId(item.Name);
                AddTransaction(id);
               // MessageBox.Show(id.ToString());
                
            }
            catch (Exception)
            {
                
               MessageBox.Show("Error");
            }
                
            }

          
            
        
        

          private bool Check(Item item)
            {
 	             bool isUserExisted = false;
            

                 string query = @"Select * from Items where Name= '" + item.Name + "'";

                 SqlCommand command = new SqlCommand(query, con);

                 con.Open();
                 SqlDataReader dr = command.ExecuteReader();
                 while (dr.Read())
                    {
                        if (dr.HasRows == true)
                            {
                                 MessageBox.Show("Item Name already exist");
                                 isUserExisted = true;
                                 break;
                            }
                    }
                  con.Close();
                  return isUserExisted;
            }

          
        bool Add(Item item)
        {

            string query = @"INSERT INTO Items(Name,CategoryId,CompanyId,ReorderLevel) VALUES('" + item.Name + "','" + item.CategoryId + "','" + item.CompanyId + "','" + item.ReorderLevel + "') ";

            SqlCommand command = new SqlCommand(query, con);

            con.Open();
            bool isAdded = command.ExecuteNonQuery() > 0;
            con.Close();
            
            return isAdded;
        }
        private int GetId(string name)
        {

            int id = 0;
            string query = @"SELECT * FROM Items WHERE Name='" + name + "'";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                id = Convert.ToInt32(dr["Id"].ToString());
            }
            else
            {
                MessageBox.Show("Iten not found");
            }
            con.Close();
            return id;
        }
        void AddTransaction(int itemId)
        {

            string query = @"INSERT INTO Transactions(ItemId,AvailableQuantity) VALUES('" + itemId + "',0) ";

            SqlCommand command = new SqlCommand(query, con);

            con.Open();
            command.ExecuteNonQuery();

            con.Close();
            
        }
    }
}
