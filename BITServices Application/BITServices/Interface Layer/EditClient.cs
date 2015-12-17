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
    public partial class EditClient : Form
    {
        Client cl;
        Validation v = new Validation();
        public EditClient(int ID)
        {
            InitializeComponent();
            cl = new Client(ID);
            populateFields();
        }

        private void populateFields()
        {
            cl.getClient();

            txtClientTitle.Text = cl.Title;
            txtClientName.Text = cl.Name;
            txtClientEmail.Text = cl.Email;
            txtClientAddress.Text = cl.StreetAddress;
            txtClientCity.Text = cl.City;
            txtClientPostCode.Text = cl.Postcode.ToString();
            txtClientPhone.Text = cl.Phone;
            txtClientMobile.Text = cl.Mobile;
            chkActive.Checked = cl.IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var cnfRes = MessageBox.Show("Update Employee ?", "Confirm Update", MessageBoxButtons.YesNo);
            if (cnfRes == DialogResult.Yes)
            {
                int clientID = cl.ClientID;
                Client nCl = new Client(clientID);
                
                nCl.Title = v.cleanString(txtClientTitle.Text);
                nCl.Name =  v.cleanString(txtClientName.Text);
                nCl.Email =  v.cleanString(txtClientEmail.Text);
                nCl.StreetAddress =  v.cleanString(txtClientAddress.Text);
                nCl.City =  v.cleanString(txtClientCity.Text);
                nCl.Postcode = Convert.ToInt32(v.cleanString(txtClientPostCode.Text));
                nCl.Phone = v.cleanString(txtClientPhone.Text);
                nCl.Mobile =  v.cleanString(txtClientMobile.Text);
                nCl.IsActive =  chkActive.Checked;

                if(nCl.updateClient())
                {
                    MessageBox.Show("Successfully updated!");
                    this.Close();
                }
            }
            else { MessageBox.Show("Error with Update."); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtClientEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!txtClientEmail.Text.Contains("@."))
            {
                errorProvider.SetError(txtClientEmail,"Valid email required Eg; <username>@bitsvcs.com");
                e.Cancel = true;
                return;
            }    
  
            errorProvider.SetError(txtClientEmail, "");
        }
    }
}
