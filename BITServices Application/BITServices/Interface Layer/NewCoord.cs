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
    public partial class NewCoord : Form
    {
        public NewCoord()
        {
            InitializeComponent();

            initStaffList();
        }

        private void initStaffList()
        {
            Employee emps = new Employee();
            DataTable dt = emps.getEmployees();
            if (dt != null)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    if (!(bool)dr["isSupervising"])
                    {
                        cmbStaffList.Items.Add(new Employee((int)dr["employee_id"], dr["name"].ToString()));
                    }
                }
                cmbStaffList.SelectedIndex = 0;
            }
            else
            {
                lblOutput.Text = "Unable to retrieve list of Employees";
                lblOutput.ForeColor = Color.Red;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee cmbemp = (Employee)cmbStaffList.SelectedItem;
            cmbemp.IsSuper = true;
            if (cmbemp.makeCoord())
            {
                MessageBox.Show("Staff Member made coodinator.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Operation Failed!");
                this.Close();
            }
        }
    }
}
