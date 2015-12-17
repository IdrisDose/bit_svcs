using BITServices.Business_Layer;
using BITServices.Interface_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BITServices
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Validation v = new Validation();

            string uname = v.cleanString(txtUname.Text.ToLower());
            string pword = txtPword.Text;
            string email;
            Login l;
            if(uname.Contains("@"))
            {
                l = new Login(uname,pword,true);
            }
            else { l = new Login(uname, pword, false); }

            switch (l.ReturnLoginType()[0])
            {
               case "SUPERVISOR":
                    
                    email= l.ReturnLoginType()[1];
                    AdminForm af = new AdminForm(email);
                    this.Hide();
                    af.ShowDialog(this); 
                    break;

               case "EMPLOYEE":
                    email = l.ReturnLoginType()[1];
                    CoordForm cf = new CoordForm(email);
                    this.Hide();
                    cf.ShowDialog(this); 
                    break;

               case "CLIENT":
                    lblError.Text = "Client Menu not implemented";
                    break;

               default:
                    lblError.Text = "Invalid login credentials.";
                    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void txtPword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUname.Text = "admin";
            txtPword.Text = "password";
            btnLogin_Click(sender, e);
        }

        private void btnCoDebug_Click(object sender, EventArgs e)
        {
            txtUname.Text = "employee";
            txtPword.Text = "password";
            btnLogin_Click(sender, e);
        }

    }
}
