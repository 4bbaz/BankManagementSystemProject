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
    public partial class accountDetails : Form
    {
        public accountDetails()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("Server = localhost; Port=3308; Database = banksystem; Username = root; password =;");
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "SELECT customer.*, account.AccoutType FROM account INNER JOIN customer ON customer.AccountNo = account.AccountNo WHERE customer.AccountNo = '" + txtAc.Text + "' ";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader rd;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    txtFn.Text = rd.GetString("FirstName");
                    txtLn.Text = rd.GetString("LastName");
                    txtad.Text = rd.GetString("AadharID");
                    txtAge.Text = rd.GetString("Age");
                    txtDOB.Text = rd.GetString("DOB");
                    txtCity.Text = rd.GetString("City");
                    txtState.Text = rd.GetString("State");
                    txtAddress.Text = rd.GetString("Address");
                    txtEmail.Text = rd.GetString("Email");
                    txtPhone.Text = rd.GetString("Phone");
                    txtAcctype.Text = rd.GetString("AccoutType");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }
    }
}
