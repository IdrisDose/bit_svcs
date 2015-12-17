using BITServices.Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BITServices.Business_Layer
{
    class Client : Person
    {
        private int clientID;
        private string streetAddress;
        private string city;
        private int postcode;   
        private string mobile;
        private bool isActive;
        private DataTable dt;


        #region Encapsulation

            internal int ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }
            internal string StreetAddress
        {
            get { return streetAddress; }
            set { streetAddress = value; }
        }
            internal string City
        {
            get { return city; }
            set { city = value; }
        }
            internal int Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }
            internal string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
            internal bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        #endregion

        #region Constructors

            public Client()
            {

            }

            public Client(int cID)
            {
                this.ClientID = cID;
                this.getClient();
            }

            public Client(int cID, string n)
            {
                this.ClientID = cID;
                this.Name = n;
            }

            public Client(string n, string e)
            {
                Name = n;
                Email = e;
            }

            public Client(string t, string n, string sA, string c, int p, string e, string ph, string m, bool a)
            {
                this.Title = t;
                this.Name = n;
                this.StreetAddress = sA;
                this.City = c;
                this.Postcode = p;
                this.Email = e;
                this.Phone = ph;
                this.Mobile = m;
                this.IsActive = a;
            }
        
        #endregion

        #region Procedures / Methods

            internal void getClient()
            {
                string query = "select * from clients WHERE client_id = '" + this.ClientID + "';";
                DAL d = new DAL(query);
                dt = new DataTable();
                if (d.exists(query))
                {
                    dt = d.Select();
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.ClientID = (int)dr["client_id"];
                        this.Title = (string)dr["title"];
                        this.Name = (string)dr["name"];
                        this.StreetAddress = (string)dr["street_address"];
                        this.City = (string)dr["city"];
                        this.Postcode = (int)dr["postcode"];
                        this.Email = (string)dr["email"];
                        this.Phone = (string)dr["phone"];
                        this.Mobile = (string)dr["mobile"];
                        this.IsActive = (bool)dr["active"];
                    }
                }
                else
                {
                    this.ClientID = 0;
                    this.Title = "NULL";
                    this.Name = "NULL";
                    this.StreetAddress = "NULL";
                    this.City = "NULL";
                    this.Postcode = 0000;
                    this.Email = "NULL";
                    this.Phone = "NULL";
                    this.Mobile = "NULL";
                    this.IsActive = false;
                }
            }

            internal DataTable getClients()
            {
                String query = "SELECT * FROM clients";
                DAL d = new DAL(query);
                dt = d.Select();
                if (dt != null)
                {
                    return dt;
                }
                else { return null; }
            }

            internal bool makeInactive()
            {
                String query = "UPDATE clients SET active=" + this.IsActive + " WHERE client_id=" + this.ClientID;
                DAL d = new DAL(query);
                if (d.ExecuteNonQuery())
                {
                    return true;
                }
                else { return false; }
            }

            internal bool updateClient()
            {
                String query = "UPDATE clients SET title ='" + this.Title +
                                                 "', name='" + this.Name +
                                                 "', street_address='" + this.StreetAddress +
                                                 "', city='" + this.City +
                                                 "', postcode= " + this.Postcode +
                                                 ", email='" + this.Email +
                                                 "', phone='" + this.Phone +
                                                 "', mobile='" + this.Mobile +
                                                 "', active= " + this.IsActive +
                                                 " WHERE client_id=" + this.ClientID;
                DAL d = new DAL(query);
                if (d.ExecuteNonQuery())
                {
                    return true;
                }
                else { return false; }
            }

            internal bool insertClient()
            {
                String query1 = "SELECT * FROM employees WHERE email='" + this.Email + "' OR phone='" + this.Phone + "'";
                String inQuery = "INSERT INTO clients (title,name,street_address,city,postcode,email,phone,mobile,active)" +
                                 "VALUES ('" + this.Title +
                                 "', '" + this.Name +
                                 "', '" + this.StreetAddress +
                                 "', '" + this.City +
                                 "', " + this.Postcode +
                                 ", '" + this.Email +
                                 "', '" + this.Phone +
                                 "', '" + this.Mobile +
                                 "', " + this.IsActive + ")";

                DAL d = new DAL(inQuery);
                if (!d.exists(query1))
                {
                    return d.ExecuteNonQuery();
                }
                else { return false; }
            }

            internal Client[] getClientList()
            {
                Client[] clients;
                Client cl = new Client();
                DataTable dt = cl.getClients();
                if (dt != null)
                {
                    clients = new Client[dt.Rows.Count];
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {

                        clients[i] = new Client((int)dr["client_id"], dr["name"].ToString());
                        i++;
                    }
                    return clients;
                }
                else { MessageBox.Show("Unable to retrieve list of Employees"); return null; };
            }

            public override string ToString()
            {
                return this.Name;
            }
        
        #endregion

    }
}
