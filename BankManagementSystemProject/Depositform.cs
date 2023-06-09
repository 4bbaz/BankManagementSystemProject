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
    public partial class Depositform : Form
    {
        public Depositform()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("Server = localhost; Port=3308; Database = banksystem; Username = root; password =;");

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtSeach_Click(object sender, EventArgs e)
        {
            string AccNo, Fname, Lname, bal;
            AccNo = txtAcNo.Text;
            Fname = txtF.Text;
            Lname = txtL.Text;
            bal = txtBal.Text;



            try
            {
                con.Open();
                string query = "SELECT customer.FirstName,customer.LastName,account.balance FROM account INNER JOIN customer ON customer.AccountNo = account.AccountNo WHERE customer.AccountNo = '" + AccNo + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txtF.Text = dr.GetString("FirstName");
                    txtL.Text = dr.GetString("LastName");
                    txtBal.Text = dr.GetString("balance");

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
            double desposit = double.Parse(txtDeposit.Text);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "UPDATE account SET balance = balance + '" + desposit + "' WHERE AccountNo = '"+txtAcNo.Text+"' ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO transaction(AccountNo,Deposit,date) VALUES('" + txtAcNo.Text + "','" + txtDeposit.Text + "','" + DateTime.Now + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Done");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

        }
    }
}

