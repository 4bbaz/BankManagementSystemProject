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
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("Server = localhost; Port=3308; Database = banksystem; Username = root; password =;");

        public void AccoutNo()
        {
            con.Open();
            string query = "SELECT max(AccountNo) from customer";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                string val = dr[0].ToString();
                if(val == "")
                {
                    LacNo.Text = "10000";
                }
                else
                {
                    int a;
                    a = int.Parse(dr[0].ToString());
                    a = a + 1;
                    LacNo.Text = a.ToString();

                }
            }
            con.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Fname, Lname, aadid, age, dob, city, state, address, email, phone, actype, bal,Acno;
            Fname = txtFname.Text;
            Lname = txtLname.Text;
            aadid = txtAadID.Text;
            age = txtAge.Text;
            dob = txtDate.Text;
            city = txtState.Text;
            state = txtState.Text;
            address = txtAddress.Text;
            email = txtEmail.Text;
            phone = txtPhone.Text;
            actype = txtAcType.Text;
            bal = txtDeposit.Text;
            Acno = LacNo.Text;


            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = $"INSERT INTO customer VALUES('{Acno}','{Fname}','{Lname}','{aadid}','{age}','{dob}','{city}','{state}','{address}','{email}','{phone}')";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO account VALUES('" + Acno + "','" + bal + "','" + actype + "')";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Saved Successfully!");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            con.Close();

        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            AccoutNo();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
