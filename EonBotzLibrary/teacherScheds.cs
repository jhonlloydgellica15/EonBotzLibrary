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
            using (cmd = new MySqlCommand("select a.schedid, a.subjectcode, a.sub ,b.description,a.date, a.timestart,a.timeend from schedule a ,rooms b where b.roomid = a.roomid  and schedid = '" + subjectcode + "'", conn))
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
                    
                    dt.Rows.Add(mdr[0].ToString(), $"{mdr[1].ToString()} {mdr[2].ToString()} {mdr[3].ToString()}", mdr[4].ToString());
                }
            }
        }

        public void viewSchedTeach()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();

            using(cmd = new MySqlCommand("select a.schedID, a.subjectCode, a.subjectTitle, c.name, a.date, a.timeStart, a.timeEnd, d.firstname, d.lastname, d.gender from schedule a, teachersched b, rooms c, teachers d WHERE b.teacherId = d.teacherId and a.roomId = c.roomId and b.teacherid = '"+ teacherID + "' and a.schedID like '%" + getSchedID + "%'  and b.schedid  like '%" + getSchedID + "%'", conn))
            {
                mdr = cmd.ExecuteReader();

                dt.Columns.Clear();
                dt.Columns.Add("schedID");
                dt.Columns.Add("subjCode");
                dt.Columns.Add("subjTitle");
                dt.Columns.Add("roomName");
                dt.Columns.Add("day");
                dt.Columns.Add("timestart");
                dt.Columns.Add("timeend");
                dt.Columns.Add("fName");
                dt.Columns.Add("gender");

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

                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), bar.ToString(), mdr[5].ToString(), mdr[6].ToString(), mdr[7].ToString() + mdr[8].ToString(), mdr[9].ToString());
                }
            }
        }
    }

}
