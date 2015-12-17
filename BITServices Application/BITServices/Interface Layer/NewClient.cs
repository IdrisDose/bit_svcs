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
    public partial class NewClient : Form
    {
        public NewClient()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Validation v = new Validation();

            Client cl = new Client();

            cl.Title = v.cleanString(txtClientTitle.Text);
            cl.Name = v.cleanString(txtClientName.Text);
            cl.Email = v.cleanString(txtClientEmail.Text);
            cl.StreetAddress = v.cleanString(txtClientAddress.Text);
            cl.City = v.cleanString(txtClientCity.Text);
            cl.Postcode = Convert.ToInt32(v.cleanString(txtClientPostCode.Text));
            cl.Phone = v.cleanString(txtClientPhone.Text);
            cl.Mobile = v.cleanString(txtClientMobile.Text);
            cl.IsActive = chkActive.Checked;

            if(cl.insertClient())
            {
                MessageBox.Show("Client Successfully inserted!");
                this.Close();
            }
            else { MessageBox.Show("Error inserting.. Client already exists"); }

            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtClientEmail_Validating(object sender, CancelEventArgs e)
        {
            Validation v = new Validation();
            if(!v.validateEmail(txtClientEmail.Text))
            {
                errorProvider1.SetError(txtClientEmail, "Need a valid Email: e.g; name@domain.tld");
                e.Cancel = true;
                return;
            } else { errorProvider1.Clear(); }
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
