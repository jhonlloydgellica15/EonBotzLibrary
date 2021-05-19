
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
            using (cmd = new MySqlCommand("SELECT a.schedId, a.subjectCode,e.subjectTitle,d.name,a.timestart,a.timeend,a.date,a.maxStudent,a.status ,e.lab,e.lec FROm subjects e, schedule a ,tuition b,tuitioncategory c,rooms d where a.subjectcode = b.subjectcode and b.tuitioncatid = c.tuitionCatID and d.roomid = a.roomid and e.subjectcode = b.subjectcode and c.category ='" + category+ "'group by a.schedId", conn))
            {
                mdr = cmd.ExecuteReader();

                dt.Columns.Clear();

                dt.Columns.Add("SchedID");
                dt.Columns.Add("SubjectCode");
                dt.Columns.Add("SubjectTitle");
                dt.Columns.Add("RoomName");
                dt.Columns.Add("Timestart");
                dt.Columns.Add("Timeend");
                dt.Columns.Add("Day");
                dt.Columns.Add("MaxStudent");
                dt.Columns.Add("Status");
                dt.Columns.Add("lablec");

                while (mdr.Read())
                {
                    string foo = mdr[6].ToString(), bar = string.Empty;

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
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), bar, mdr[4].ToString(), mdr[5].ToString(), mdr[7].ToString(), mdr[8].ToString(), mdr[10].ToString() + "/" + mdr[9].ToString());
                }
            }
        }
    }



}
