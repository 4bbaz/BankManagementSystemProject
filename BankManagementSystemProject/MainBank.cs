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
    public partial class MainBank : Form
    {
        public MainBank()
        {
            InitializeComponent();
        }
        
        
       
        
        
        
        
       






        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateAccount CAc = new CreateAccount();
            CAc.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Depositform dp = new Depositform();
            dp.Show();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WithdrawForm w = new WithdrawForm();
            w.Show();
           


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Transfer tr = new Transfer();
            tr.Show();
           
           

        }

        private void button6_Click(object sender, EventArgs e)
        {
            CheckBal cbal = new CheckBal();
            cbal.Show();

           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UpdateAc up = new UpdateAc();
            
            up.Show();
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            accountDetails ad = new accountDetails();
            
            ad.Show();
   
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CustomerList cl = new CustomerList();
            cl.Show();

        }
    }


}

