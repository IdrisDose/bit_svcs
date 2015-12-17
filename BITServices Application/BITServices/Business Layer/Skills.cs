using BITServices.Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.Business_Layer
{
    class Skills
    {
        private int skillID;
        private int employeeID;
        private bool developer;
        private bool analyst;
        private bool itsupport;
        DataTable dt;

        #region Encapsulation

            public int SkillID
        {
            get { return skillID; }
            set { skillID = value; }
        }

            public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

            public bool Developer
        {
            get { return developer; }
            set { developer = value; }
        }

            public bool Analyst
        {
            get { return analyst; }
            set { analyst = value; }
        }

            public bool Itsupport
        {
            get { return itsupport; }
            set { itsupport = value; }
        }
        
        #endregion

        #region Constructors

            public Skills(int eID)
            {
                this.EmployeeID = eID;
            }

            public Skills(int eID, bool d, bool a, bool i)
            {
                this.EmployeeID = eID;
                this.Developer = d;
                this.Analyst = a;
                this.Itsupport = i;
            }

        #endregion

        #region Methods / Procedures

            internal void GetSkills()
            {
                String query = "SELECT * FROM skills WHERE employee_id=" + this.EmployeeID;
                DAL d = new DAL(query);
                dt = d.Select();
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.SkillID = (int)dr["skill_id"];
                        this.EmployeeID = (int)dr["employee_id"];
                        this.Developer = (bool)dr["developer"];
                        this.Analyst = (bool)dr["analyst"];
                        this.Itsupport = (bool)dr["itsupport"];
                    }
                }
                else
                {
                    this.SkillID = 0;
                    this.Developer = false;
                    this.Analyst = false;
                    this.Itsupport = false;
                }

            }

            internal bool skillsInsert()
            {
                String query = "UPDATE skills SET developer=" + this.Developer +
                                                 ", analyst=" + this.Analyst +
                                                 ", itsupport=" + this.Itsupport +
                                                 " WHERE employee_id=" + this.EmployeeID;
                DAL d = new DAL(query);
                if (d.ExecuteNonQuery())
                {
                    return true;
                }
                else { return false; }
            }
        
        #endregion

    }
}
