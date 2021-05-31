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
        public string prelim { set; get; }

        public string midterm { set; get; }

        public string semi { set; get; }
        public string final { set; get; }
        public string total { set; get; }


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
                    dt.Rows.Add(mdr[0].ToString(), $"{mdr[1].ToString()} {mdr[2].ToString()}", mdr[3].ToString());
                }
            }
        }

        public void viewPayment()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("select a.prelim,midterm,semi,finals,total from Billing a,studentSched b,student c where  a.studentSchedid = b.studentSchedID and b.studentid = c.studentid and c.studentid ='"+studentID+"'", conn))
            {
                mdr = cmd.ExecuteReader();
           

                while (mdr.Read())
                {
                    prelim = mdr[0].ToString();
                    midterm = mdr[1].ToString();
                    semi = mdr[2].ToString();
                    final = mdr[3].ToString();
                    total = mdr[4].ToString();
                }
            }
        }
    }
}