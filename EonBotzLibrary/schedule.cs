using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
namespace EonBotzLibrary
{
    public class schedule
    {

        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlDataReader mdr;
        MySqlCommand cmd;

        public List<string> datafill = new List<string>();
        public string subjcode { set; get; }
          public string subjTitle { set; get; }

        public void Schedule()
        {
            conn = connect.getcon();
            conn.Open();

            datafill.Clear();

            using(cmd = new MySqlCommand("SELECT subjectcode FROM subjects", conn))
            {
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    datafill.Add(mdr[0].ToString());      
                }
                conn.Close();
            }
        }
        public void Viewdescription()
        {
            conn = connect.getcon();
            conn.Open();
            using(cmd = new MySqlCommand("select subjectTitle from subjects where subjectcode =@subjCode", conn))
            {
                cmd.Parameters.AddWithValue("@subjCode", subjcode);
                mdr = cmd.ExecuteReader();
                mdr.Read();
                if (mdr.HasRows)
                {
                    subjTitle = mdr[0].ToString();
                }
                mdr.Close();
                conn.Close();
            }
        }
    }
}