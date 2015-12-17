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
    class Employee : Person
    {
        private int employeeID;
        private string role;
        private bool isSuper;
        private bool isActive;
        private bool isAdmin;
        private String[] result;
        private DataTable dt;

        #region Encapsulation

            public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

            public string Role
        {
            get { return role; }
            set { role = value; }
        }

            public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }

            public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

            public bool IsSuper
        {
            get { return isSuper; }
            set { isSuper = value; }
        }
        
        #endregion

        #region Constructors
            public Employee()
            {

            }

            public Employee(int eID)
            {
                this.getEmpDetailsByID(eID);
            }

            public Employee(string t, string n, string e, string ph, string r, bool isS, bool isA)
            {
                this.Title = t;
                this.Name = n;
                this.Email = e;
                this.Phone = ph;
                this.role = r;
                this.isSuper = isS;
            }

            public Employee(int eID, string n)
            {
                this.employeeID = eID;
                this.Name = n;
            }

            public Employee(string e)
            {
                this.getEmpDetails(e);
            }

            public Employee(int empid, string title, string name, string email, string role, string phone, bool isSuper, bool isActive, bool isAdmin)
            {
                this.EmployeeID = empid;
                this.Title = title;
                this.Name = name;
                this.Email = email;
                this.Role = role;
                this.Phone = phone;
                this.IsSuper = isSuper;
                this.IsActive = isActive;
                this.IsAdmin = isAdmin;
            }

            public Employee(string title, string name, string email, string role, string phone, bool isSuper, bool isActive, bool isAdmin)
            {
                // TODO: Complete member initialization
                this.Title = title;
                this.Name = name;
                this.Email = email;
                this.role = role;
                this.Phone = phone;
                this.isSuper = isSuper;
                this.isActive = isActive;
                this.isAdmin = isAdmin;
            }
        #endregion
           
        #region Methods / Procudures

            internal void getEmpDetails(string em)
        {
            string query = "select * from employees WHERE email = '" + em + "';";
            DAL d = new DAL(query);
            dt = new DataTable();
            if (d.exists(query))
            {
                dt = d.Select();
                foreach (DataRow dr in dt.Rows)
                {
                    this.EmployeeID = (int)dr["employee_id"];
                    this.Title = (string)dr["title"];
                    this.Name = (string)dr["name"];
                    this.Email = (string)dr["email"];
                    this.Phone = (string)dr["phone"];
                    this.Role = (string)dr["role"];
                    this.IsSuper = (bool)dr["isSupervising"];
                    this.IsActive = (bool)dr["isActive"];
                    this.IsAdmin = (bool)dr["isAdmin"];
                }
            }
            else
            {
                this.EmployeeID = 0;
                this.Title = "NULL";
                this.Name = "NULL";
                this.Email = "NULL";
                this.Phone = "NULL";
                this.Role = "NULL";
                this.IsSuper = false;
                this.IsActive = false;
                this.IsAdmin = false;
            }

        }

            private void getEmpDetailsByID(int eID)
        {
            string query = "select * from employees WHERE employee_id = '" + eID + "';";
            DAL d = new DAL(query);
            dt = new DataTable();
            if (d.exists(query))
            {
                dt = d.Select();
                foreach (DataRow dr in dt.Rows)
                {
                    this.EmployeeID = (int)dr["employee_id"];
                    this.Title = (string)dr["title"];
                    this.Name = (string)dr["name"];
                    this.Email = (string)dr["email"];
                    this.Phone = (string)dr["phone"];
                    this.Role = (string)dr["role"];
                    this.IsSuper = (bool)dr["isSupervising"];
                    this.IsActive = (bool)dr["isActive"];
                    this.IsAdmin = (bool)dr["isAdmin"];
                }
            }
            else
            {
                this.EmployeeID = 0;
                this.Title = "NULL";
                this.Name = "NULL";
                this.Email = "NULL";
                this.Phone = "NULL";
                this.Role = "NULL";
                this.IsSuper = false;
                this.IsActive = false;
                this.IsAdmin = false;
            }
        }

            internal DataTable getCoordinators()
        {
            String query = "SELECT * FROM employees WHERE isSupervising=true";
            DAL d = new DAL(query);
            dt = d.Select();
            if (dt != null)
            {
                return dt;
            }
            else { return null; }
        }

            internal DataTable getEmployees()
        {
            String query = "SELECT * FROM employees";
            DAL d = new DAL(query);
            dt = d.Select();
            if (dt != null)
            {
                return dt;
            }
            else { return null; }
        }

            public override string ToString()
        {
            return this.Name;
        }

            internal bool updateEmp()
        {
            String query = "UPDATE employees SET title='" + this.Title +
                                             "', name='" + this.Name +
                                             "', email='" + this.Email +
                                             "', phone='" + this.Phone +
                                             "', role='" + this.Role +
                                             "', isSupervising=" + this.IsSuper +
                                             ", isActive=" + this.IsActive +
                                             ", isAdmin=" + this.IsAdmin +
                                             " WHERE employee_id=" + this.EmployeeID;
            DAL d = new DAL(query);
            if (d.ExecuteNonQuery())
            {
                return true;
            }
            else { return false; }
        }

            internal bool makeInactive()
        {
            String query = "UPDATE employees SET isActive=" + this.IsActive + " WHERE employee_id=" + this.EmployeeID;
            DAL d = new DAL(query);
            if (d.ExecuteNonQuery())
            {
                return true;
            }
            else { return false; }
        }

            internal bool makeCoord()
        {
            String query = "UPDATE employees SET isSupervising=" + this.IsSuper + " WHERE employee_id=" + this.EmployeeID;
            DAL d = new DAL(query);
            if (d.ExecuteNonQuery())
            {
                return true;
            }
            else { return false; }
        }

            internal bool insertNewEmp()
        {
            String query1 = "SELECT * FROM employees WHERE email='" + this.Email + "' OR phone='" + this.Phone + "'";
            String inQuery = "INSERT INTO employees(title,name,email,phone,role,isSupervising,isActive,isAdmin)" +
                              "VALUES('" + this.Title +
                                      "','" + this.Name +
                                      "','" + this.Email +
                                      "','" + this.Phone +
                                      "','" + this.Role +
                                      "'," + this.IsSuper +
                                      "," + this.IsActive +
                                      "," + this.IsAdmin +
                                      ")";
            DAL d = new DAL(inQuery);
            if (!d.exists(query1))
            {
                return d.ExecuteNonQuery();
            }
            else { return false; }
        }

            internal Employee[] getEmployeeList()
            {
                Employee[] employees;
                Employee emps = new Employee();
                DataTable dt = emps.getEmployees();
                if (dt != null)
                {
                    employees = new Employee[dt.Rows.Count];
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        employees[i] = new Employee((int)dr["employee_id"], dr["name"].ToString());
                        i++;
                    }
                    return employees;
                }
                else { MessageBox.Show("Unable to retrieve list of Employees"); return null; }

            }  
        
        #endregion

    }
}
