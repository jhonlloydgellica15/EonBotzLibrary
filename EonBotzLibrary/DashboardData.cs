using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using EonBotzLibrary;

namespace EonBotzLibrary
{
    public class DashboardData
    {

        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader mdr;


        public int count { set; get; }
        public void CountStudent()
        {
            conn = connect.getcon();
            conn.Open();
            

            using(cmd = new MySqlCommand("SELECT COUNT(*) FROM student", conn))
            {
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    count = Convert.ToInt32(mdr[0].ToString());
                }
            }
        }

        public void CountTeacher()
        {
            conn = connect.getcon();
            conn.Open();


            using (cmd = new MySqlCommand("SELECT COUNT(*) FROM teachers", conn))
            {
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    count = Convert.ToInt32(mdr[0].ToString());
                }
            }
        }

        public void CountLibrarian()
        {
            conn = connect.getcon();
            conn.Open();


            using (cmd = new MySqlCommand("SELECT COUNT(*) FROM librarians", conn))
            {
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    count = Convert.ToInt32(mdr[0].ToString());
                }
            }
        }

        public void CountAccountants()
        {
            conn = connect.getcon();
            conn.Open();


            using (cmd = new MySqlCommand("SELECT COUNT(*) FROM accountants", conn))
            {
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    count = Convert.ToInt32(mdr[0].ToString());
                }
            }
        }
    }


    }
