using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SqlKata.Execution;
using System.Data;

namespace EonBotzLibrary
{
    public class StudentTuition
    {
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader mdr;

        public DataTable dt = new DataTable();
        public string studentID { set; get; }
        public string subjectcode { set; get; }
        public string total { set; get; }
        public string getSchedID { set; get; }
        public string indsub { set; get; }
        public string sched { set; get; }
      
        public void viewSubj()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("select a.subjectcode, SUM(a.totalprice) from subjects a , schedule b where b.subjectcode = a.subjectCode and b.schedid ='"+indsub+"'", conn))
            {
                mdr = cmd.ExecuteReader();

                dt.Columns.Clear();
        
                dt.Columns.Add("SubjectCode");
                dt.Columns.Add("Amount");

                while (mdr.Read())
                {
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString());
                }
            }
        }

    }
}