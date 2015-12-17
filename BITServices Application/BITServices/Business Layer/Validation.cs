using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BITServices.Business_Layer
{
    class Validation
    {
        public Validation()
        {

        }

        internal string cleanString(string s)
        {
            s = s.Replace("'", "");
            return s;
           
        }


        internal bool validatePhone(string number)
        {
            if(!(number.Length < 10) || number[0] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool validateEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
