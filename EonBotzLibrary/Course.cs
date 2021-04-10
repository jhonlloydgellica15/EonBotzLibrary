using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace EonBotzLibrary
{
    public class Course
    {
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader mdr;


        public string id { set; get; }
        public string description { set; get; }
        public string abbreviation { set; get; }

        public DataTable dt = new DataTable();

        public void CREATE_DATA()
        {
            conn = connect.getcon();
            conn.Open();

            using (cmd = new MySqlCommand("INSERT INTO course(description, abbreviation)VALUES(@desc, @abbre)", conn))
            {
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.Parameters.AddWithValue("@abbre", abbreviation);
                cmd.ExecuteNonQuery();

            }
            conn.Close();
        }

        public void UPDATE_DATA()
        {
            conn = connect.getcon();
            conn.Open();

            using (cmd = new MySqlCommand("update course set description=@desc, abbreviation=@abbre WHERE courseId=@id", conn))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.Parameters.AddWithValue("@abbre", abbreviation);
                cmd.ExecuteNonQuery();
            }
        }
        public void VIEW_DATA()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("SELECT * from course", conn))
            {
                mdr = cmd.ExecuteReader();

                //dt.Columns.Add("Name", typeof(string));
                //while (mdr.Read())
                //{

                //    dt.Rows.Add(mdr[0].ToString() + " , " + mdr[1].ToString());
                //}

                dt.Columns.Clear();
                dt.Columns.Add("ID");
                dt.Columns.Add("Course");

                while (mdr.Read())
                {
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString() + "(" + mdr[2].ToString() + ")");
                }
            }
        }

        public void PassData()
        {
            conn = connect.getcon();
            conn.Open();


            using (cmd = new MySqlCommand("SELECT * FROM course WHERE courseId LIKE @id", conn))
            {

                cmd.Parameters.AddWithValue("@id", id);
                mdr = cmd.ExecuteReader();
                mdr.Read();

                if (mdr.HasRows)
                {
                    description = mdr[1].ToString();
                    abbreviation = mdr[2].ToString();
                }
                mdr.Close();
                conn.Close();
            }
        }
    }
}
