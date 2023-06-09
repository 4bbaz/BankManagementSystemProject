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
    public partial class WithdrawForm : Form
    {
        public WithdrawForm()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("Server = localhost; Port=3308; Database = banksystem; Username = root; password =;");

        private void button2_Click(object sender, EventArgs e)
        {
            

            try
            {
                con.Open();
                string query = "SELECT customer.FirstName, customer.LastName, account.balance FROM account INNER JOIN customer ON customer.AccountNo = account.AccountNo WHERE customer.AccountNo = '" + txtAcNo.Text + "' ";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader rd;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    txtFname.Text = rd.GetString("FirstName");
                    txtLname.Text = rd.GetString("LastName");
                    txtBal.Text = rd.GetString("balance");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "UPDATE account SET balance = balance - '" + txtAm.Text + "' WHERE AccountNo = '" + txtAcNo.Text + "' ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO transaction(AccountNo,Withdraw,date) VALUES('" + txtAcNo.Text + "','" + txtAm.Text + "','"+ DateTime.Now + "')";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Withdraw successfully....");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }
    }
}
