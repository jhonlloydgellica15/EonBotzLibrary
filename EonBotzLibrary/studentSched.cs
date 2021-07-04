
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
        string total;
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlDataReader mdr;
        MySqlCommand cmd;
        public DataTable dt = new DataTable();
        public DataTable dtFilter = new DataTable();
        public DataTable dtStudentSched = new DataTable();
        public DataTable dtSectioning = new DataTable();
        public List<string> datafill = new List<string>();

        public string category { set; get; }
        public string textvalue { set; get; }
        public string totalUnits { set; get; }
        public string getSchedID { set; get; }
        public string studentID { set; get; }

        public void display()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("select a.schedid, a.subjectcode, a.subjectTitle,d.name,a.date,a.timeStart,a.timeEnd,a.maxStudent,a.status,f.lec,f.lab, f.totalunits,count(c.studentSchedID) from schedule a cross join rooms d cross join subjects f cross join Sectioning b on a.schedID = b.schedID left join studentSched c on c.schedID regexp a.schedID where d.roomId =a.roomId and f.subjectCode = a.subjectCode and b.SectionCategoryID = '" + category + "'  group by b.sectionID having count(c.studentSchedID) < a.maxstudent", conn))
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
                dt.Columns.Add("total");

                while (mdr.Read())
                {
                    //totalUnits = mdr[11].ToString();
                    totalUnits = mdr[11].ToString();
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
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), bar, mdr[5].ToString(), mdr[6].ToString(), mdr[7].ToString(), mdr[8].ToString(), mdr[9].ToString() + "/" + mdr[10].ToString(), mdr[11].ToString());
                }
                conn.Close();
                mdr.Close();
            }
        }
        public void showMaxenrolled()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("select a.schedid, a.subjectcode, a.subjectTitle,d.name,a.date,a.timeStart,a.timeEnd,a.maxStudent,a.status,e.lec,e.lab, e.totalunits,count(studentSchedID) from schedule a left join Sectioning l on l.SectionCategoryID =3 left join studentSched c on c.schedId regexp a.schedID left join rooms d on d.roomId =a.roomId left join subjects e on e.subjectCode = a.subjectCode   group by a.schedId having count(c.schedID) < a.maxStudent", conn))
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
                dt.Columns.Add("total");

                while (mdr.Read())
                {
                    //totalUnits = mdr[11].ToString();
                    totalUnits = mdr[11].ToString();
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
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), bar, mdr[5].ToString(), mdr[6].ToString(), mdr[7].ToString(), mdr[8].ToString(), mdr[9].ToString() + "/" + mdr[10].ToString(), mdr[11].ToString());
                }
                conn.Close();
                mdr.Close();
            }
        }
        public void viewSectiong()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("select a.schedid, a.subjectcode, a.subjectTitle,d.name,a.date,a.timeStart,a.timeEnd,a.maxStudent,a.status,b.lec,b.lab, b.totalunits from rooms d, schedule a ,subjects b,Sectioning c where a.roomId = d.roomId and a.schedid = c.schedID and c.SectionCategoryID = '" + category + "' and a.subjectcode = b.subjectcode and a.status = 'available' group by c.schedid", conn))
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
                dt.Columns.Add("total");


                while (mdr.Read())
                {
                    //totalUnits = mdr[11].ToString();
                    totalUnits = mdr[11].ToString();
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
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), bar, mdr[5].ToString(), mdr[6].ToString(), mdr[7].ToString(), mdr[8].ToString(), mdr[9].ToString() + "/" + mdr[10].ToString(), mdr[11].ToString());
                    //dtSectioning.Rows.Add(mdr[0].ToString(), mdr[1].ToString());
                }
                conn.Close();
                mdr.Close();
            }
        }

        public void displayFilter()
        {
            conn = connect.getcon();
            conn.Open();

            dtFilter.Clear();
            using (cmd = new MySqlCommand("select a.schedid, a.subjectcode, a.subjectTitle,d.name,a.date,a.timeStart,a.timeEnd,a.maxStudent,a.status,e.lec,e.lab, e.totalunits from schedule a left join studentSched c on c.schedId regexp a.schedID left join rooms d on d.roomId =a.roomId left join subjects e on e.subjectCode = a.subjectCode group by a.schedId having count(c.schedID) < a.maxStudent", conn))
            //using (cmd = new MySqlCommand("select a.schedid, a.subjectcode, a.subjectTitle,d.name,a.date,a.timeStart,a.timeEnd,a.maxStudent,a.status,b.lec,b.lab, b.totalunits from rooms d, schedule a ,subjects b,Sectioning c,studentSched e where a.roomId = d.roomId and a.schedid = c.schedID and a.subjectcode = b.subjectcode and a.status = 'available' group by c.schedid having count(e.schedid) < a.maxstudent", conn))
            {
                mdr = cmd.ExecuteReader();

                dtFilter.Columns.Clear();

                dtFilter.Columns.Add("SchedID");
                dtFilter.Columns.Add("SubjectCode");
                dtFilter.Columns.Add("SubjectTitle");
                dtFilter.Columns.Add("RoomName");
                dtFilter.Columns.Add("Day");
                dtFilter.Columns.Add("Timestart");
                dtFilter.Columns.Add("Timeend");
                dtFilter.Columns.Add("MaxStudent");
                dtFilter.Columns.Add("Status");
                dtFilter.Columns.Add("lablec");
                dtFilter.Columns.Add("total");

                while (mdr.Read())
                {
                    //totalUnits = mdr[11].ToString();
                    totalUnits = mdr[11].ToString();
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
                    dtFilter.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), bar, mdr[5].ToString(), mdr[6].ToString(), mdr[7].ToString(), mdr[8].ToString(), mdr[9].ToString() + "/" + mdr[10].ToString(), mdr[11].ToString());
                }
                conn.Close();
                mdr.Close();
            }
        }
        public void displaytextShow()
        {
            conn = connect.getcon();
            conn.Open();

            dtFilter.Clear();
            using (cmd = new MySqlCommand("select a.schedid, a.subjectcode, a.subjectTitle,d.name,a.date,a.timeStart,a.timeEnd,a.maxStudent,a.status,e.lec,e.lab, e.totalunits from schedule a left join studentSched c on c.schedId regexp a.schedID left join rooms d on d.roomId =a.roomId left join subjects e on e.subjectCode = a.subjectCode where a.subjectCode like '%" + textvalue + "%' or a.subjectTitle like '%" + textvalue + "%'    group by a.schedId having count(c.schedID) < a.maxStudent", conn))
            //using (cmd = new MySqlCommand("select a.schedid, a.subjectcode, a.subjectTitle,d.name,a.date,a.timeStart,a.timeEnd,a.maxStudent,a.status,b.lec,b.lab, b.totalunits from rooms d, schedule a ,subjects b,Sectioning c,studentSched e where a.roomId = d.roomId and a.schedid = c.schedID and a.subjectcode = b.subjectcode and a.status = 'available' group by c.schedid having count(e.schedid) < a.maxstudent", conn))
            {
                mdr = cmd.ExecuteReader();

                dtFilter.Columns.Clear();

                dtFilter.Columns.Add("SchedID");
                dtFilter.Columns.Add("SubjectCode");
                dtFilter.Columns.Add("SubjectTitle");
                dtFilter.Columns.Add("RoomName");
                dtFilter.Columns.Add("Day");
                dtFilter.Columns.Add("Timestart");
                dtFilter.Columns.Add("Timeend");
                dtFilter.Columns.Add("MaxStudent");
                dtFilter.Columns.Add("Status");
                dtFilter.Columns.Add("lablec");
                dtFilter.Columns.Add("total");

                while (mdr.Read())
                {
                    //totalUnits = mdr[11].ToString();
                    totalUnits = mdr[11].ToString();
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
                    dtFilter.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), bar, mdr[5].ToString(), mdr[6].ToString(), mdr[7].ToString(), mdr[8].ToString(), mdr[9].ToString() + "/" + mdr[10].ToString(), mdr[11].ToString());
                }
                conn.Close();
                mdr.Close();
            }
        }

        public void viewSchedStudent()
        {
            conn = connect.getcon();
            conn.Open();


            dtStudentSched.Clear();
            //select a.schedid, a.subjectcode, a.subjectTitle,d.name,a.date,a.timeStart,a.timeEnd,a.maxStudent,a.status,b.lec,b.lab, b.totalunits from rooms d, schedule a ,subjects b, Sectioning c where a.roomId = d.roomId and a.schedid = c.schedID and a.subjectcode = b.subjectcode and a.status = 'available' group by c.schedid
            using (cmd = new MySqlCommand("select distinct a.schedID, a.subjectCode, a.subjectTitle, c.name, a.date, a.timeStart, a.timeEnd, a.maxStudent,a.status, e.lec, e.lab, e.totalunits, d.firstname, d.lastname, d.gender, d.course from schedule a, studentSched b, rooms c, student d, subjects e,studentSched f WHERE b.studentID = d.studentID and a.roomId = c.roomId and a.subjectCode = e.subjectcode and a.status = 'available' and b.studentID = '" + studentID + "' and a.schedID like '%" + getSchedID + "%'  and b.schedid  like '%" + getSchedID + "%'", conn))
            {

                mdr = cmd.ExecuteReader();

                dtStudentSched.Columns.Clear();

                dtStudentSched.Columns.Add("SchedID");
                dtStudentSched.Columns.Add("SubjectCode");
                dtStudentSched.Columns.Add("SubjectTitle");
                dtStudentSched.Columns.Add("RoomName");
                dtStudentSched.Columns.Add("Day");
                dtStudentSched.Columns.Add("Timestart");
                dtStudentSched.Columns.Add("Timeend");
                dtStudentSched.Columns.Add("MaxStudent");
                dtStudentSched.Columns.Add("Status");
                dtStudentSched.Columns.Add("lablec");
                dtStudentSched.Columns.Add("total");
                dtStudentSched.Columns.Add("Name");
                dtStudentSched.Columns.Add("Gender");
                dtStudentSched.Columns.Add("Course");

                while (mdr.Read())
                {
                    totalUnits = mdr[11].ToString();
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

                    dtStudentSched.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), bar, mdr[5].ToString(), mdr[6].ToString(), mdr[7].ToString(), mdr[8].ToString(), mdr[9].ToString() + "/" + mdr[10].ToString(), mdr[11].ToString(), $"{mdr[12].ToString()} {mdr[13].ToString()}", mdr[14].ToString(), mdr[15].ToString());
                }
                conn.Close();
                mdr.Close();
            }
        }
    }
}
