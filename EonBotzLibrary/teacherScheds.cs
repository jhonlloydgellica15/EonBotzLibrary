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
    public class teacherScheds
    {
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader mdr;

        public DataTable dt = new DataTable();
        public string teacherID { set; get; }
        public string subjectcode { set; get; }

        public string getSchedID { set; get; }

        public void viewteachsubj()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("select a.schedid, a.subjectcode,b.description,a.date, a.timestart,a.timeend from schedule a ,rooms b where b.roomid = a.roomid  and schedid = '" + subjectcode + "'", conn))
            {
                mdr = cmd.ExecuteReader();

                dt.Columns.Clear();
                dt.Columns.Add("SchedID");
                dt.Columns.Add("SubjectCode");
                dt.Columns.Add("Room");
                dt.Columns.Add("Day");
                dt.Columns.Add("TimeStart");
                dt.Columns.Add("TimeEnd");

                while (mdr.Read())
                {
                    string foo = mdr[3].ToString(), bar = string.Empty;

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
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(),  bar.ToString(), mdr[4].ToString(), mdr[5].ToString());
                }
            }
        }
        public void viewstudent()
        {

            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("select a.studentid,c.firstname, c.middlename, c.lastname, c.course from studentSched a , teachersched b, student c where a.studentid = c.studentid and b.teacherid = '" + teacherID + "'  and a.schedId  like '%" + getSchedID + "%' and b.schedid  like '%" + getSchedID + "%'", conn))
            {
                mdr = cmd.ExecuteReader();

                dt.Columns.Clear();
                dt.Columns.Add("ID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Course");


                while (mdr.Read())
                {
                    var value = DBContext.GetContext().Query("course").Where("courseId", mdr[4].ToString()).First();
                    dt.Rows.Add(mdr[0].ToString(), $"{mdr[1].ToString()} {mdr[2].ToString()} {mdr[3].ToString()}", value.abbreviation);
                }
            }
        }
    }

}
