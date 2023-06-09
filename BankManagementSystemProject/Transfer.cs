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
    public partial class Transfer : Form
    {
        public Transfer()
        {
            InitializeComponent();

        }
        MySqlConnection con = new MySqlConnection("Server = localhost; Port=3308; Database = banksystem; Username = root; password =;");

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnFac_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "SELECT customer.FirstName,customer.LastName,account.balance FROM account INNER JOIN customer ON customer.AccountNo = account.AccountNo WHERE customer.AccountNo = '" + txtFac.Text + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txtFfn.Text = dr.GetString("FirstName");
                    txtFln.Text = dr.GetString("LastName");
                    txtFbal.Text = dr.GetString("balance");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void btnTac_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "SELECT customer.FirstName,customer.LastName,account.balance FROM account INNER JOIN customer ON customer.AccountNo = account.AccountNo WHERE customer.AccountNo = '" + txtTac.Text + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txtTfn.Text = dr.GetString("FirstName");
                    txtTln.Text = dr.GetString("LastName");
                    txtTbal.Text = dr.GetString("balance");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void btnTR_Click(object sender, EventArgs e)
        {
            double amount = double.Parse(txtAm.Text);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "UPDATE account SET balance = balance - '" + amount + "' WHERE AccountNo = '" + txtFac.Text + "' ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "UPDATE account SET balance = balance + '" + amount + "' WHERE AccountNo = '" + txtTac.Text + "' ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO tr(f_acc,t_acc,amount,date) VALUES('" + txtFac.Text + "','" + txtTac.Text + "', '" + txtAm.Text + "', '" + DateTime.Now + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Transfer Successfully....");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }
    }
}
