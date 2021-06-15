using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace EonBotzLibrary
{
    public class Subjects
    {
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader mdr;


        public DataTable dt = new DataTable();

        public string id { set; get; }
        public string subjCode { set; get; }
        public string subjTitle { set; get; }
        public string unit { set; get; }
        public string lec { set; get; }
        public string lab { set; get; }
        public string prereq { set; get; }


        public void CREATE_DATA()
        {
            conn = connect.getcon();
            conn.Open();

            using (cmd = new MySqlCommand("INSERT INTO subjects(subjectCode,subjectTitle,unit,lec,lab,prereq)VALUES(" +
                "@subjCode, @subjTitle, @unit, @lec, @lab, @prereq)", conn))
            {
                cmd.Parameters.AddWithValue("@subjCode", subjCode);
                cmd.Parameters.AddWithValue("@subjTitle", subjTitle);
                cmd.Parameters.AddWithValue("@unit", unit);
                cmd.Parameters.AddWithValue("@lec", lec);
                cmd.Parameters.AddWithValue("@lab", lab);
                cmd.Parameters.AddWithValue("@prereq", prereq);
                cmd.ExecuteNonQuery();

            }
            conn.Close();
        }

        public void UPDATE_DATA()
        {
            conn = connect.getcon();
            conn.Open();

            using (cmd = new MySqlCommand("update subjects set subjectCode=@subjCode, subjectTitle=@subjTitle, unit=@unit, lec=@lec, lab=@lab, prereq=@prereq WHERE subjectId=@id", conn))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("@subjCode", subjCode);
                cmd.Parameters.AddWithValue("@subjTitle", subjTitle);
                cmd.Parameters.AddWithValue("@unit", unit);
                cmd.Parameters.AddWithValue("@lec", lec);
                cmd.Parameters.AddWithValue("@lab", lab);
                cmd.Parameters.AddWithValue("@prereq", prereq);
              
                cmd.ExecuteNonQuery();
            }
        }

        public void VIEW_DATA()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("SELECT * from subjects", conn))
            {
                mdr = cmd.ExecuteReader();

                //dt.Columns.Add("Name", typeof(string));
                //while (mdr.Read())
                //{

                //    dt.Rows.Add(mdr[0].ToString() + " , " + mdr[1].ToString());
                //}

                dt.Columns.Clear();
     
                dt.Columns.Add("SubjectCode");
                dt.Columns.Add("SubjectTitle");
                dt.Columns.Add("Lec");
                dt.Columns.Add("Lab");
                dt.Columns.Add("LecPrice");
                dt.Columns.Add("LabPrice");
                dt.Columns.Add("Total");
                dt.Columns.Add("CourseID");

                while (mdr.Read())
                {
                    dt.Rows.Add( mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString()+"/"+ mdr[4].ToString(), mdr[6].ToString(), mdr[7].ToString(),mdr[10].ToString(),mdr[13].ToString());
                }
            }
        }

        public void PassData()
        {
            conn = connect.getcon();
            conn.Open();


            using (cmd = new MySqlCommand("SELECT * FROM subjects WHERE subjectId LIKE @id", conn))
            {

                cmd.Parameters.AddWithValue("@id", id);
                mdr = cmd.ExecuteReader();
                mdr.Read();

                if (mdr.HasRows)
                {
                    subjCode = mdr[1].ToString();
                    subjTitle = mdr[2].ToString();
                    unit = mdr[3].ToString();
                    lec = mdr[4].ToString();
                    lab = mdr[5].ToString();
                    prereq = mdr[6].ToString();
                }
                mdr.Close();
                conn.Close();
            }
        }
    }
}
