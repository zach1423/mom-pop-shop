using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace mom_pop_shop
{
    public partial class Login : Form
    {
        bool ID = true;
        bool PASSWORD = false;

        MomAndPopDatabaseDataSetTableAdapters.EmployeesTableAdapter eta = new MomAndPopDatabaseDataSetTableAdapters.EmployeesTableAdapter();

        public Login()
        {
            InitializeComponent();
        }

        private void focused(int number)
        {
            if (ID)
            {
                Login_ID.Text = Login_ID.Text + Convert.ToString(number);
            }
            else if (PASSWORD)
            {
                Login_Password.Text = Login_Password.Text + Convert.ToString(number);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            focused(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            focused(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            focused(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            focused(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            focused(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            focused(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            focused(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            focused(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            focused(9);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            focused(0);
        }

        private void Backspace_Click(object sender, EventArgs e)
        {
            if (ID)
            {

            }
            else if (PASSWORD)
            {

            }
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            String output = Convert.ToString(eta.LoginGetPass(Convert.ToInt32(Login_ID.Text)));
            Main_Screen main = new Main_Screen();
            if (Login_Password.Text == output)
            {
                main.Show();
            }
            else
            {
                MessageBox.Show("Incorrect ID or Password");
            }
        }

        private void Login_ID_MouseClick(object sender, MouseEventArgs e)
        {
            ID = true;
            PASSWORD = false;
        }

        private void Login_Password_MouseClick(object sender, MouseEventArgs e)
        {
            PASSWORD = true;
            ID = false;
        }
    }
}
