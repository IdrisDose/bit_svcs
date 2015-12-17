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
    public partial class AdminForm : Form
    {
        private Employee admin;

        public AdminForm(string email)
        {
            InitializeComponent();
            admin = new Employee(email);
            lblWelcome.Text = "Welcome, " + admin.Name;
        }

        #region Form General Functions

            private void lblWelcome_SizeChanged(object sender, EventArgs e)
        {

            lblWelcome.Left = (this.ClientSize.Width - lblWelcome.Size.Width) / 2;

        }

            private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

            private void tabCtrlAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabCtrlAdmin.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    populateCoordCombo();
                    break;
                case 2:
                    populateContrCombo();
                    break;
                case 3:
                    populateSkillCombo();
                    break;
                case 4:
                    populateClientCombo();
                    break;
                case 5:
                    populateJobCombo();
                    break;
            }
        }

            private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

            private void btnCoords_Click(object sender, EventArgs e)
        {
            tabCtrlAdmin.SelectedIndex = 1;
            populateCoordCombo();
        }

            private void btnContr_Click(object sender, EventArgs e)
        {
            tabCtrlAdmin.SelectedIndex = 2;
            populateContrCombo();
        }

            private void btnSkills_Click(object sender, EventArgs e)
        {
            tabCtrlAdmin.SelectedIndex = 3;
            populateSkillCombo();
        }

            private void btnJobs_Click(object sender, EventArgs e)
        {
            tabCtrlAdmin.SelectedIndex = 4;
            populateClientCombo();
        }

            private void btnClients_Click(object sender, EventArgs e)
        {
            tabCtrlAdmin.SelectedIndex = 5;
            populateJobCombo();
        }
        
        #endregion
        
        #region CoordManagement

            private void cmbStaffList_SelectedIndexChanged(object sender, EventArgs e)
            {
                Employee cmbemp = (Employee)cmbStaffList.SelectedItem;
                populateFields(cmbemp.EmployeeID);
            }

            private void btnCoordRefresh_Click(object sender, EventArgs e)
            {
                populateCoordCombo();
            }

            private void btnCoordEdit_Click(object sender, EventArgs e)
            {
                Employee cmbemp = (Employee)cmbStaffList.SelectedItem;
                EditStaff ec = new EditStaff(cmbemp.EmployeeID);
                ec.Show(this);
            }

            private void btnCoordDel_Click(object sender, EventArgs e)
            {
                Employee cmbemp = (Employee)cmbStaffList.SelectedItem;
                cmbemp.IsActive = false;
                if (cmbemp.makeInactive())
                {
                    MessageBox.Show("Staff Member made inactive");
                    populateFields(cmbemp.EmployeeID);
                }
                else
                {
                    MessageBox.Show("Operation Failed!");
                    populateFields(cmbemp.EmployeeID);
                }
            }

            private void btnCoordNew_Click(object sender, EventArgs e)
            {
                NewCoord nc = new NewCoord();
                nc.Show(this);
            }

            private void populateCoordCombo()
            {
                cmbStaffList.Items.Clear();
                Employee emps = new Employee();
                DataTable dt = emps.getCoordinators();
                if (dt != null)
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        cmbStaffList.Items.Add(new Employee((int)dr["employee_id"], dr["name"].ToString()));
                    }
                    cmbStaffList.SelectedIndex = 0;
                }
                else
                {
                    lblCoordOutput.Text = "Unable to retrieve list of Coordinators";
                    lblCoordOutput.ForeColor = Color.Red;
                }
            }

            private void populateFields(int id)
            {
                Employee emp = new Employee(id);
                txtTitle.Text = emp.Title;
                txtName.Text = emp.Name;
                txtEmail.Text = emp.Email;
                txtPhone.Text = emp.Phone;
                txtRole.Text = emp.Role;
                chkSuper.Checked = emp.IsSuper;
                chkActive.Checked = emp.IsActive;
                chkAdmin.Checked = emp.IsAdmin;
            }

        #endregion

        #region ContractorManagment
        
            private void populateContrCombo()
            {
                cmbContractors.Items.Clear();
                Employee emps = new Employee();
                DataTable dt = emps.getEmployees();
                if (dt != null)
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!(bool)dr["isSupervising"])
                        {
                            cmbContractors.Items.Add(new Employee((int)dr["employee_id"], dr["name"].ToString()));
                        }
                    }
                    cmbContractors.SelectedIndex = 0;
                }
                else { MessageBox.Show("Unable to retrieve list of Employees"); }
            }
        
            private void populateContrFields(int id)
            {
                Employee emp = new Employee(id);
                txtContrTitle.Text = emp.Title;
                txtContrName.Text = emp.Name;
                txtContrEmail.Text = emp.Email;
                txtContrPhone.Text = emp.Phone;
                txtContrRole.Text = emp.Role;
                chkContrActive.Checked = emp.IsActive;
            }

            private void btnContrEdit_Click(object sender, EventArgs e)
            {
                Employee cmbemp = (Employee)cmbContractors.SelectedItem;
                EditStaff es = new EditStaff(cmbemp.EmployeeID);
                es.Show(this);
            }

            private void btnContrNew_Click(object sender, EventArgs e)
            {
                NewStaff ns = new NewStaff();
                ns.Show(this);
            }

            private void cmbContractors_SelectedIndexChanged(object sender, EventArgs e)
            {
                Employee cmbemp = (Employee)cmbContractors.SelectedItem;
                populateContrFields(cmbemp.EmployeeID);
            }

            private void btnContrDel_Click(object sender, EventArgs e)
            {
                Employee cmbemp = (Employee)cmbContractors.SelectedItem;
                cmbemp.IsActive = false;
                if (cmbemp.makeInactive())
                {
                    MessageBox.Show("Staff Member made inactive");
                    populateContrFields(cmbemp.EmployeeID);
                }
                else
                {
                    MessageBox.Show("Operation Failed!");
                    populateContrFields(cmbemp.EmployeeID);
                }
            }

            private void btnContrRefresh_Click(object sender, EventArgs e)
            {
                populateContrCombo();
            }
        
        #endregion

        #region SkillManagment

            private void cmbStaffCombo_SelectedIndexChanged(object sender, EventArgs e)
            {
                Employee cmbemp = (Employee)cmbStaffCombo.SelectedItem;
                populateSkillFields(cmbemp.EmployeeID);
            }

            private void populateSkillCombo()
            {
                cmbStaffCombo.Items.Clear();
                Employee emps = new Employee();
                DataTable dt = emps.getEmployees();
                if (dt != null)
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!(bool)dr["isSupervising"])
                        {
                            cmbStaffCombo.Items.Add(new Employee((int)dr["employee_id"], dr["name"].ToString()));
                        }
                    }
                    cmbStaffCombo.SelectedIndex = 0;
                }
                else
                {

                    lblContrOut.Text = "Unable to retrieve list of Employees";
                    lblContrOut.ForeColor = Color.Red;
                }
            }
        
            private void populateSkillFields(int id)
            {
                Skills sk = new Skills(id);
                sk.GetSkills();
                chkDeveloper.Checked = sk.Developer;
                chkAnalyst.Checked = sk.Analyst;
                chkSupport.Checked = sk.Itsupport;

            }

            private void btnSkillSave_Click(object sender, EventArgs e)
            {
                Employee cmbemp = (Employee)cmbStaffCombo.SelectedItem;
                Skills skills = new Skills(cmbemp.EmployeeID, chkDeveloper.Checked, chkAnalyst.Checked, chkSupport.Checked);

                if (skills.skillsInsert())
                {
                    MessageBox.Show("Skills updated for " + cmbemp.ToString());
                    populateContrFields(cmbemp.EmployeeID);
                }
                else
                {
                    MessageBox.Show("Operation Failed!");
                    populateContrFields(cmbemp.EmployeeID);
                }
            }

            private void btnSkillsRefresh_Click(object sender, EventArgs e)
            {
                populateSkillCombo();
            }

        #endregion            

        #region ClientManagment

            private void cmbClients_SelectedIndexChanged(object sender, EventArgs e)
            {
                Client cl = (Client)cmbClients.SelectedItem;
                populateClientFields(cl.ClientID);
            }

            private void btnClientDel_Click(object sender, EventArgs e)
            {
                Client client = (Client)cmbContractors.SelectedItem;
                client.IsActive = false;
                if (client.makeInactive())
                {
                    MessageBox.Show("Client made inactive");
                    populateContrFields(client.ClientID);
                }
                else
                {
                    MessageBox.Show("Operation Failed!");
                    populateContrFields(client.ClientID);
                }
            }

            private void btnClientRefresh_Click(object sender, EventArgs e)
            {
                populateClientCombo();
            }

            private void btnClientEdit_Click(object sender, EventArgs e)
            {
                Client client = (Client)cmbClients.SelectedItem;
                EditClient ec = new EditClient(client.ClientID);
                ec.Show(this);
            }

            private void btnClientNew_Click(object sender, EventArgs e)
            {
                NewClient nc = new NewClient();
                nc.Show(this);
            }

            private void populateClientFields(int id)
            {
                Client cl = new Client(id);
                cl.getClient();

                txtClientTitle.Text = cl.Title;
                txtClientName.Text = cl.Name;
                txtClientEmail.Text = cl.Email;
                txtClientAddress.Text = cl.StreetAddress;
                txtClientCity.Text = cl.City;
                txtClientPostCode.Text = cl.Postcode.ToString();
                txtClientPhone.Text = cl.Phone;
                txtClientMobile.Text = cl.Mobile;
                chkClientActive.Checked = cl.IsActive;
            }

            private void populateClientCombo()
            {
                cmbClients.Items.Clear();
                Client client = new Client();
                DataTable dt = client.getClients();
                if (dt != null)
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        cmbClients.Items.Add(new Client((int)dr["client_id"],dr["name"].ToString()));
                    }
                    cmbClients.SelectedIndex = 0;
                }
                else { MessageBox.Show("Failed to get clients!"); }
            }

        #endregion

        #region JobManagement
        
            private void cmbJobList_SelectedIndexChanged(object sender, EventArgs e)
            {
                Job j = (Job)cmbJobList.SelectedItem;
                populateJobFields(j.JobID);
            }

            private void populateJobCombo()
            {
                cmbJobList.Items.Clear();
                Job j = new Job();
                DataTable dt = j.getJobs();
                if (dt != null)
                {
                    cmbJobList.Items.Add(new Job(0, "---"));
                    foreach (DataRow dr in dt.Rows)
                    {
                        cmbJobList.Items.Add(new Job((int)dr["job_id"],(string)dr["job_name"]));
                    }
                    cmbJobList.SelectedIndex = 0;
                }
                else { MessageBox.Show("Failed to get clients!"); }
            }

            private void populateJobFields(int id)
            {
                Job j = new Job(id);
                j.getJobDetails();

                Client c = new Client(j.ClientID);
                Employee e = new Employee(j.EmployeeID);

                txtJobName.Text = j.JobName;
                txtJobDetails.Text = j.JobDetails;
                txtJobLoc.Text = j.JobLocation;
                txtJobPriority.Text = j.Priority;
                txtClient.Text = c.Name;
                txtContractor.Text = e.Name;
                chkJobActive.Checked = j.Active;

            }

            private void btnJobNew_Click(object sender, EventArgs e)
            {
                NewJob nj = new NewJob();
                nj.Show(this);
            }

            private void btnRefreshJobs_Click(object sender, EventArgs e)
            {
                populateJobCombo();
            }

            private void btnDelJob_Click(object sender, EventArgs e)
            {
                Job j = (Job)cmbJobList.SelectedItem;
                j.Active = false;
                if (j.makeInactive())
                {
                    MessageBox.Show("Job made inactive");
                    populateContrFields(j.ClientID);
                }
                else
                {
                    MessageBox.Show("Operation Failed!");
                    populateContrFields(j.ClientID);
                }

            }

            private void btnEditJob_Click(object sender, EventArgs e)
            {
                Job j = (Job)cmbJobList.SelectedItem;
                EditJob ej = new EditJob(j.JobID);
                ej.Show(this);
            }

        #endregion

    }

}
