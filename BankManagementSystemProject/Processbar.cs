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
    public partial class Processbar : Form
    {
        public Processbar()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 4;
            if (progressBar1.Value >= 99)
            {
                MainBank m = new MainBank();
                this.Hide();
                m.Show();

                timer1.Enabled = false;
                progressBar1.Value = progressBar1.Value - 1;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Processbar_Load(object sender, EventArgs e)
        {
            
        }
    }
}
