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
    public partial class EditJob : Form
    {
        Job j;
        String[] priorities = { "LOW", "MEDIUM", "HIGH" };
        Validation v = new Validation();
       
        public EditJob(int id)
        {
            InitializeComponent();
            
            j = new Job(id);
            populateFields();
        }

        private void populateFields()
        {

            j.getJobDetails();
            Client c = new Client();
            Employee e = new Employee();

            //Make an array instance of each Clients and Employees
            Client[] clList = c.getClientList();
            Employee[] empList = e.getEmployeeList();


            cmbPriority.DataSource = priorities;
            cmbPriority.SelectedItem = j.Priority.ToUpper();
            

            cmbClient.DataSource = clList;
            cmbClient.SelectedItem = c;

            cmbContractor.DataSource = empList;
            cmbContractor.SelectedItem = e;

            txtJobName.Text = j.JobName;
            txtJobDetails.Text = j.JobDetails;
            txtJobLoc.Text = j.JobLocation;
            chkActive.Checked = j.Active;
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var cnfRes = MessageBox.Show("Update Job ?", "Confirm Update", MessageBoxButtons.YesNo);
            if (cnfRes == DialogResult.Yes)
            {
                Client c = (Client)cmbClient.SelectedItem;
                Employee emp = (Employee)cmbContractor.SelectedItem;

                j.JobName = v.cleanString(txtJobName.Text.Replace(" ",""));
                j.JobDetails = v.cleanString(txtJobDetails.Text);
                j.JobLocation = v.cleanString(txtJobLoc.Text);
                j.ClientID = c.ClientID;
                j.EmployeeID = emp.EmployeeID;
                j.Priority = v.cleanString((string)cmbPriority.SelectedItem);
                j.Active = chkActive.Checked;

                if (j.updateJob())
                {
                    MessageBox.Show("Successfully Updated!");
                    this.Close();
                }
                else { MessageBox.Show("Error with Update."); }
            }
            else { MessageBox.Show("Update aborted"); this.Close(); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
