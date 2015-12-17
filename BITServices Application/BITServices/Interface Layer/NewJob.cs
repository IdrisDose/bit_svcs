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
    public partial class NewJob : Form
    {
        internal String[] priorities = { "LOW", "MEDIUM", "HIGH" };
        
        public NewJob()
        {
            InitializeComponent();
            populateCombos();
        }

        private void populateCombos()
        {
            Client c = new Client();
            Employee e = new Employee();

            //Make an array instance of each Clients and Employees
            Client[] clList = c.getClientList();
            Employee[] empList = e.getEmployeeList();

            cmbPriority.DataSource = priorities;
            cmbClient.DataSource = clList;
            cmbContractor.DataSource = empList;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Validation v = new Validation();
            Job j = new Job();
            Client c = (Client)cmbClient.SelectedItem;
            Employee emp = (Employee)cmbContractor.SelectedItem;

            j.JobName = v.cleanString(txtJobName.Text.Replace(" ",""));
            j.JobDetails = v.cleanString(txtJobDetails.Text);
            j.JobLocation = v.cleanString(txtJobLoc.Text);
            j.ClientID = c.ClientID;
            j.EmployeeID = emp.EmployeeID;
            j.Priority = v.cleanString((string)cmbPriority.SelectedItem);
            j.Active = chkActive.Checked;

            if (j.insertJob())
            {
                MessageBox.Show("Successfully Inserted!");
                this.Close();
            }
            else { MessageBox.Show("Error with Update."); }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void validateText(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Trim() == "")
            {
                lblError.Text = textBox.Name.ToString() + " cannot be empty";
                e.Cancel = true;
                return;
            }
            else
            {
                lblError.Text = "";
            }
        }
    }
}
