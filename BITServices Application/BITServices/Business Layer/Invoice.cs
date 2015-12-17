using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.Business_Layer
{
    class Invoice
    {
        private int invoiceID;
        private string invoiceDetails;
        private string invoiceStatus;
        private decimal invoiceAmount;
        private int jobID;
        private int clientID;

        public Invoice()
        {

        }
        
        public Invoice(int c)
        {
            clientID = c;
        }

        public Invoice(string invD, string invS, decimal invA, int jID, int cID)
        {
            invoiceDetails = invD;
            invoiceStatus = invS;
            invoiceAmount = invA;
            jobID = jID;
            clientID = cID;
        }

        public int InvoiceID
        {
            get { return invoiceID; }
            set { invoiceID = value; }
        }

        public string InvoiceDetails
        {
            get { return invoiceDetails; }
            set { invoiceDetails = value; }
        }

        public string InvoiceStatus
        {
            get { return invoiceStatus; }
            set { invoiceStatus = value; }
        }

        public decimal InvoiceAmount
        {
            get { return invoiceAmount; }
            set { invoiceAmount = value; }
        }

        public int JobID
        {
            get { return jobID; }
            set { jobID = value; }
        }

        public int ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }

    }
}
