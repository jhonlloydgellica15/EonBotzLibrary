using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace EonBotzLibrary
{
    public class Students
    {
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader mdr;
        MySqlDataAdapter msda;

        public int counted { set; get; }
        public string firstname { set; get; }
        public string lastname { set; get; }
        public string middlename { set; get; }
        public string age { set; get; }
        public string dateofbirth { set; get; }
        public string placeofbirth { set; get; }
        public string contactno { set; get; }
        public string gender { set; get; }
        public string maritalstatus { set; get; }
        public string citizenship { set; get; }
        public string religion { set; get; }
        public string address { set; get; }

        public DataTable dt = new DataTable();

       
        private DataSet ds = new DataSet();


        public void CREATE_DATA()
        {
            conn = connect.getcon();
            conn.Open();

            using(cmd = new MySqlCommand("INSERT INTO student(lastname,firstname,middlename,age,dateofbirth,placeofbirth,contactno,gender,maritalstatus,citizenship,religion,address)VALUES(" +
                "@lname,@fname,@mname,@age,@dob,@pob,@contact,@gender,@marital,@citizen,@religion,@address)", conn))
            {
                cmd.Parameters.AddWithValue("@lname", lastname);
                cmd.Parameters.AddWithValue("@fname",  firstname);
                cmd.Parameters.AddWithValue("@mname", middlename);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("dob", dateofbirth);
                cmd.Parameters.AddWithValue("@pob", placeofbirth);
                cmd.Parameters.AddWithValue("@contact", contactno);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@marital", maritalstatus);
                cmd.Parameters.AddWithValue("@citizen", citizenship);
                cmd.Parameters.AddWithValue("@religion", religion);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.ExecuteNonQuery();
                
            }
            conn.Close();
        }

        public void VIEW_DATA()
        {
            conn = connect.getcon();
            conn.Open();


            dt.Clear();
            using(cmd = new MySqlCommand("SELECT lastname, firstname, middlename, contactno from student", conn))
            {
                mdr = cmd.ExecuteReader();

                dt.Columns.Add("Name", typeof(string));
                while (mdr.Read())
                {

                    dt.Rows.Add(mdr[0].ToString() + " , " + mdr[1].ToString());
                }

                //dt.Columns.Add("Lastname");
                //dt.Columns.Add("Firstname");
                //dt.Columns.Add("Middlename");
                //dt.Columns.Add("Contact");

                //while (mdr.Read())
                //{
                //    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString());
                //}



            }


        }
    }


}
