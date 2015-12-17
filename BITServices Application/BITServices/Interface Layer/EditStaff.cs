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
    public partial class EditStaff : Form
    {
        Employee emp;
        Validation v = new Validation();

        public EditStaff(int eID)
        {
            InitializeComponent();
            
            
            emp = new Employee(eID);
            txtTitle.Text = emp.Title;
            txtName.Text = emp.Name;
            txtEmail.Text = emp.Email;
            txtRole.Text = emp.Role;
            txtPhone.Text = emp.Phone;
            chkActive.Checked = emp.IsActive;
            chkAdmin.Checked = emp.IsAdmin;
            chkSuper.Checked = emp.IsSuper;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cnfRes = MessageBox.Show("Update Employee ?", "Confirm Update", MessageBoxButtons.YesNo);
            if(cnfRes == DialogResult.Yes)
            {
                int empid = emp.EmployeeID;
                string title = v.cleanString(txtTitle.Text);
                string name = v.cleanString(txtName.Text);
                string email = v.cleanString(txtEmail.Text);
                string role = v.cleanString(txtRole.Text);
                string phone = v.cleanString(txtPhone.Text);
                bool isActive = chkActive.Checked;
                bool isSuper = chkSuper.Checked;
                bool isAdmin = chkAdmin.Checked;

                Employee newEmp = new Employee(empid, title, name, email, role, phone, isSuper, isActive, isAdmin);
                if(newEmp.updateEmp())
                {
                    MessageBox.Show("Successfully Updated!");
                    this.Close();
                } else { MessageBox.Show("Error with Update."); }
            }
            else { MessageBox.Show("Update aborted"); this.Close(); }
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
                e.Cancel = true;
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (txtPhone.Text.Trim() == "")
            {
                errorProvider1.SetError(lblPhone, "Phone cannot be empty");
                e.Cancel = true;
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtRole_Validating(object sender, CancelEventArgs e)
        {
            if (txtRole.Text.Trim() == "")
            {
                errorProvider1.SetError(lblRole, "Role cannot be empty");
                e.Cancel = true;
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
