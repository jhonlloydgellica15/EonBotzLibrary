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

        public void viewteachsubj()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("select a.schedid, a.subjectcode,a.date, a.timestart,a.timeend,b.name from schedule a ,rooms b where b.roomid = a.roomid  and schedid = '" + subjectcode+"'", conn))
            {
                mdr = cmd.ExecuteReader();

                //dt.Columns.Add("Name", typeof(string));
                //while (mdr.Read())
                //{

                //    dt.Rows.Add(mdr[0].ToString() + " , " + mdr[1].ToString());
                //}

              //  dt.Columns.Clear();
                dt.Columns.Add("subjectcode");
               dt.Columns.Add("date");
                dt.Columns.Add("timstart");
                dt.Columns.Add("timeend");
                dt.Columns.Add("room");

                dt.Columns.Add("schedid");



                while (mdr.Read())
                {

                  
                        string foo = mdr[1].ToString(), bar = string.Empty;

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
                        dt.Rows.Add(mdr[0].ToString(), bar.ToString(), mdr[2].ToString(), mdr[3].ToString(), mdr[4].ToString(), mdr[5].ToString());
                }
            }
        }
        public void viewstudent()
        {

            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("SELECT  from teachers", conn))
            {
                mdr = cmd.ExecuteReader();

                //dt.Columns.Add("Name", typeof(string));
                //while (mdr.Read())
                //{

                //    dt.Rows.Add(mdr[0].ToString() + " , " + mdr[1].ToString());
                //}

                dt.Columns.Clear();
                dt.Columns.Add("ID");
                dt.Columns.Add("Lastname");
                dt.Columns.Add("Firstname");
                dt.Columns.Add("Middlename");
                dt.Columns.Add("Age");
                dt.Columns.Add("DateOfBirth");
                dt.Columns.Add("PlaceOfBirth");
                dt.Columns.Add("ContactNo");
                dt.Columns.Add("Gender");
                dt.Columns.Add("MaritalStatus");
                dt.Columns.Add("Citizen");
                dt.Columns.Add("Religion");
                dt.Columns.Add("Address");

                while (mdr.Read())
                {
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), mdr[4].ToString(), mdr[5].ToString(), mdr[6].ToString(), mdr[7].ToString()
                        , mdr[8].ToString(), mdr[9].ToString(), mdr[10].ToString(), mdr[11].ToString(), mdr[12].ToString());
                }
            }
        }
    }
  
}
