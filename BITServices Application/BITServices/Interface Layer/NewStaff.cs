using BITServices.Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BITServices.Interface_Layer
{
    public partial class NewStaff : Form
    {
        bool errored = false;

        public NewStaff()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!errored)
            {
                Validation v = new Validation();
                string title = v.cleanString(txtTitle.Text);
                string name = v.cleanString(txtName.Text);
                string email = v.cleanString(txtEmail.Text);
                string role = v.cleanString(txtRole.Text);
                string phone = v.cleanString(txtPhone.Text);
                bool isActive = chkActive.Checked;
                bool isSuper = chkSuper.Checked;
                bool isAdmin = chkAdmin.Checked;

                Employee newEmp = new Employee(title, name, email, role, phone, isSuper, isActive, isAdmin);
                if (newEmp.insertNewEmp())
                {
                    MessageBox.Show("Successfully Inserted!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error with Inserting, might be because employee already exists.");
                }
            }
            else
            {
                MessageBox.Show("You have errors.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtName.Text.Replace("@", "");
            txtEmail.Text = txtName.Text.Replace(" ", ".") + "@bitsvcs.com";
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (txtTitle.Text.Trim() == "")
            {
                txtTitle.Text = "N/A";
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                errorProvider1.SetError(lblName, "Name cannot be empty");
                errored = true;
                e.Cancel = true;
                return;
            }
            else
            {
                errored = false;
                errorProvider1.Clear();
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (txtPhone.Text.Trim() == "")
            {
                errorProvider1.SetError(lblPhone, "Phone cannot be empty");
                errored = true;
                e.Cancel = true;
                return;
            }
            else
            {
                errored = false;
                errorProvider1.Clear();
            }
        }

        private void txtRole_Validating(object sender, CancelEventArgs e)
        {
            if (txtRole.Text.Trim() == "")
            {
                errorProvider1.SetError(lblRole, "Role cannot be empty");
                errored = true;
                e.Cancel = true;
                return;
            }
            else
            {
                errored = false;
                errorProvider1.Clear();
            }
        }

    }
}
