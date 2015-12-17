using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.Business_Layer
{
    abstract class Person
    {
        private string title;
        private string name;
        private string email;
        private string phone;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }


    }
}
