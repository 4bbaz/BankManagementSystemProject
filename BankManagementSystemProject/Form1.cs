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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username, password;
            username = txtUser.Text;
            password = txtPass.Text;

            if (username == "admin" && password == "123")
            {
                Processbar pr = new Processbar();
                this.Hide();
                pr.Show();

                Lcheck.Text = "Login successfully";

            }
            else
            {
                Lcheck.Text = "Invaild Username and Password";
                txtUser.Clear();
                txtPass.Clear();
                txtUser.Focus();
            }

            
        }
    }
}
