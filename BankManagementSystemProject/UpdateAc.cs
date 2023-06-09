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
    public partial class UpdateAc : Form
    {
        public UpdateAc()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("Server = localhost; Port=3308; Database = banksystem; Username = root; password =;");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnS_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "SELECT customer.FirstName,customer.LastName,account.balance FROM account INNER JOIN customer ON customer.AccountNo = account.AccountNo WHERE customer.AccountNo = '" + txtAc.Text + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txtFfn.Text = dr.GetString("FirstName");
                    txtFln.Text = dr.GetString("LastName");

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
                string query = "SELECT * FROM customer WHERE AccountNo = '" + txtAc.Text + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txtFfn.Text = dr.GetString("FirstName");
                    txtFln.Text = dr.GetString("LastName");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "UPDATE customer SET FirstName = '" + txtFfn.Text + "' WHERE AccountNo = '" + txtAc.Text + "' ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "UPDATE customer SET LastName = '" + txtFln.Text + "' WHERE AccountNo = '" + txtAc.Text + "' ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "UPDATE customer SET Email = '" + txtEmail.Text + "' WHERE AccountNo = '" + txtAc.Text + "' ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "UPDATE customer SET Phone = '" + txtP.Text + "' WHERE AccountNo = '" + txtAc.Text + "' ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "UPDATE customer SET Address = '" + txtadd.Text + "' WHERE AccountNo = '" + txtAc.Text + "' ";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully....");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }
    }
}

