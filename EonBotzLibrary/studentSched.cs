
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using SqlKata.Execution;
namespace EonBotzLibrary
{
    
    public class studentSched
    {
       
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlDataReader mdr;
        MySqlCommand cmd;
      public   DataTable dt = new DataTable();

        public string category { set; get; }


        public void display()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("select b.schedid,b.subjectcode, c.subjectTitle,d.name,b.date, b.timestart,b.timeend,b.maxstudent,b.status, c.lab,c.lec  from tuition a,schedule b, subjects c,rooms d   where b.subjectcode = c.subjectcode and a.schedid = b.schedid and a.tuitioncatid='" + category + "' group by a.tuitionid", conn))
            {
                mdr = cmd.ExecuteReader();

                dt.Columns.Clear();

                dt.Columns.Add("SchedID");
                dt.Columns.Add("SubjectCode");
                dt.Columns.Add("SubjectTitle");
                dt.Columns.Add("RoomName");
                dt.Columns.Add("Day");
                dt.Columns.Add("Timestart");
                dt.Columns.Add("Timeend");
                dt.Columns.Add("MaxStudent");
                dt.Columns.Add("Status");
                dt.Columns.Add("lablec");

                while (mdr.Read())
                {
                    string foo = mdr[4].ToString(), bar = string.Empty;

                    foreach (char c in foo)
                    {
                        if (c == '1')
                        {
                            bar += "M";
                        }
                        else if (c == '2')
                        {
                            bar += "T";
                        }
                        else if (c == '3')
                        {
                            bar += "W";
                        }
                        else if (c == '4')
                        {
                            bar += "Th";
                        }
                        else if (c == '5')
                        {
                            bar += "F";
                        }
                        else if (c == '6')
                        {
                            bar += "S";
                        }
                    }
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), bar, mdr[5].ToString(), mdr[6].ToString(), mdr[7].ToString(), mdr[8].ToString(), mdr[10].ToString() + "/" + mdr[9].ToString());
                }
            }
        }
    }



}
