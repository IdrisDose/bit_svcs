using BITServices.Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.Business_Layer
{
    class Job
    {
        private int jobID;
        private string jobName;
        private string jobDetails;
        private int clientID;
        private int employeeID;
        private int supervisorID;
        private string priority;
        private string jobLocation;
        private bool active;
        private DataTable dt;

        #region Encapsulation
        public int JobID
        {
            get { return jobID; }
            set { jobID = value; }
        }
        public string JobName
        {
            get { return jobName; }
            set { jobName = value; }
        }
        public string JobDetails
        {
            get { return jobDetails; }
            set { jobDetails = value; }
        }
        public int ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }
        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        public int SupervisorID
        {
            get { return supervisorID; }
            set { supervisorID = value; }
        }
        public string Priority
        {
            get { return priority; }
            set { priority = value; }
        }
        public string JobLocation
        {
            get { return jobLocation; }
            set { jobLocation = value; }
        }
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        #endregion

        #region Constructors

            public Job() { }

            public Job(int jID)
        {
            this.JobID = jID;
        }

            public Job(string jobN, string jobD, int cID, string p)
        {
            jobName = jobN;
            jobDetails = jobD;
            clientID = cID;
            priority = p;
        }

            public Job(string jobN, string jobD, int cID, int eID, int sID, string p)
        {
            jobName = jobN;
            jobDetails = jobD;
            clientID = cID;
            employeeID = eID;
            supervisorID = sID;
            priority = p;
        }

            public Job(int jID, string jobN)
        {
            this.JobID = jID;
            this.JobName = jobN;
        }

        #endregion

        #region Methods / Procedures
            internal DataTable getJobs()
            {
                //Can't get Stored procs working producing error when trying to create in phpMyAdmin.
                String query = "SELECT * FROM jobs";
                DAL d = new DAL(query);
                dt = d.Select();
                if (dt != null)
                {
                    return dt;
                }
                else { return null; }
            }

            internal void getJobDetails()
            {
                //Can't get Stored procs working producing error when trying to create in phpMyAdmin.
                String query = "SELECT * FROM jobs WHERE job_id=" + this.JobID;
                DAL d = new DAL(query);
                dt = d.Select();
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.JobName = (string)dr["job_name"];
                        this.JobDetails = (string)dr["job_details"];
                        this.ClientID = (int)dr["client_id"];
                        this.EmployeeID = (int)dr["employee_id"];
                        this.Priority = (string)dr["priority"];
                        this.JobLocation = (string)dr["job_location"];
                        this.Active = (bool)dr["active"];
                    }
                }
                else
                {
                    this.JobName = "NULL";
                    this.JobDetails = "NULL";
                    this.ClientID = 0;
                    this.EmployeeID = 0;
                    this.Priority = "NULL";
                    this.JobLocation = "NULL";
                    this.Active = false;
                }
            }

            public override string ToString()
            {
                return this.JobName;
            }

            internal bool makeInactive()
            {
                String query = "UPDATE jobs SET active=" + this.Active + " WHERE job_id=" + this.JobID;
                DAL d = new DAL(query);
                if (d.ExecuteNonQuery())
                {
                    return true;
                }
                else { return false; }
            }
            
            internal bool updateJob()
            {
                String query = "UPDATE jobs SET job_name='" + this.JobName + "', job_details='" + this.JobDetails + "', client_id="+ this.ClientID + ", employee_id="+this.EmployeeID + ", priority='" + this.Priority + "', job_location='" + this.JobLocation + "', active=" + this.Active + " WHERE job_id=" + this.JobID;
                DAL d = new DAL(query);
                if (d.ExecuteNonQuery())
                {
                    return true;
                }
                else { return false; }
            }

            internal bool insertJob()
            {
                String query = "INSERT INTO jobs (job_name, job_details, client_id, employee_id, priority, job_location, active) "+
                               "VALUES ('" + this.JobName + "', '" + this.JobDetails +  "'," + this.ClientID + "," + this.EmployeeID + ",'" + this.priority + "','" +this.JobLocation + "'," + this.Active +")";

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
