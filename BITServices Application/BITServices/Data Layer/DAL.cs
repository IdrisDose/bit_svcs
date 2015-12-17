using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace BITServices.Data_Layer
{
    class DAL
    {
        private MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=bit_svcs;UID=root;PASSWORD=;");
        private DataTable dt;
        private DataSet ds;
        private MySqlCommand cmd;
        private MySqlDataAdapter da; 
        private MySqlDataReader reader;
        private string Query;

        public DAL(string query)
        {
            this.Query = query;
        }

        public void connecttodb()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            else
            {
                conn.Open();
            }
        }

        public bool ExecuteNonQuery()
        {
            try
            {
                connecttodb();
                cmd = new MySqlCommand(this.Query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                System.Console.Write("Updated with: " + this.Query);
                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("MySQL Error! Non-Query!" + "\n " + e.ToString());
                return true;
            }

        }

        public DataTable Select()
        {
            try
            {
                connecttodb();
                da = new MySqlDataAdapter(this.Query, conn);
                dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("MySQL Error! (Select)");
                Console.Write(e.ToString());
                return null;
            }
        }

        public String[] SelectRow()
        {
            String[] result = null;
            try
            {
                connecttodb();
                da = new MySqlDataAdapter(this.Query, conn);
                dt = new DataTable();
                da.Fill(dt);
                result = dt.Rows[0].ItemArray.Cast<string>().ToArray();
                return result;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("MySQL Error! (Select)");
                Console.Write(e.ToString());
                return null;
            }
        }
        
        public bool exists(string query)
        {
            try
            {
                cmd = new MySqlCommand(query, conn);
                connecttodb();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            } catch (MySqlException e)
            {
                Console.Write(e);
                conn.Close();
                return false;
            }
            
        }

    }
}
