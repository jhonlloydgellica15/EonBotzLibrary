using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace EonBotzLibrary
{


    public class studentPaymentDisplay
    {
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlDataReader mdr;
        MySqlCommand cmd;
        public DataTable dt = new DataTable();

        public string studentID { set; get; }

        public void display()
        {

            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("select c.studentid,c.firstname,c.lastname,b.total   from  Billing b , studentSched a,student c where b.studentSchedID = a.studentSchedID and c.studentid = a.studentid", conn))
            {
                mdr = cmd.ExecuteReader();
                dt.Columns.Clear();

                dt.Columns.Add("StudentID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Total");

                while (mdr.Read())
                {
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString());
                }
            }
        }
    }
}