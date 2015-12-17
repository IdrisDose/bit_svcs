using BITServices.Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BITServices.Business_Layer
{
    class Login
    {
        private int loginID;
        private string loginType;
        private string uname;
        private string pword;
        private string email;
        private string query;
        private String[] result = new String[] { };

        public Login()
        {

        }

        public Login(string u, string p, bool isEmail)
        {
            if(isEmail)
            {
                this.Email = u;
                this.Pword = p;
            }
            else
            {
                this.Uname = u;
                this.Pword = p;
            }           
        }

        public Login(string lt, string u, string p, string e)
        {
            loginType = lt;
            uname = u;
            pword = p;
            email = e;
        }

        public int LoginID
        {
            get { return loginID; }
            set { loginID = value; }
        }

        public string LoginType
        {
            get { return loginType; }
            set { loginType = value; }
        }

        public string Uname
        {
            get { return uname; }
            set { uname = value; }
        }

        public string Pword
        {
            get { return pword; }
            set { pword = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        internal String[] ReturnLoginType()
        {
            query = "SELECT login_type, email FROM logins WHERE uname='" + uname + "' OR email='" + email + "' AND pass='" + pword + "';";
            DAL d = new DAL(query);

            if(d.exists(query))
            {
                result = d.SelectRow();
            }else{
                //Because this returns a two element string array I have to return the result like this...
                result = new string[] {"Invalid","Credentials"};
            }

            return result;
            
        }

        internal bool createLogin(string lt, string u, string p, string e)
        {
            return false;
        }
    }
}
