using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagementSystemProject
{
    public partial class CustomerList : Form
    {
        public CustomerList()
        {
            InitializeComponent();
            ShowAllData();
        }
        MySqlConnection con = new MySqlConnection("Server = localhost; Port=3308; Database = banksystem; Username = root; password =;");
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void ShowAllData()
        {
            con.Open();
            string getalldata = "SELECT customer.*, account.* FROM account INNER JOIN customer ON customer.AccountNo = account.AccountNo";
            MySqlDataAdapter adp = new MySqlDataAdapter(getalldata,con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
