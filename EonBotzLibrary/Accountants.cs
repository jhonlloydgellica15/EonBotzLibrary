using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace EonBotzLibrary
{
    public class Accountants
    {
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader mdr;
        MySqlDataAdapter msda;


        public string id { set; get; }
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

            using (cmd = new MySqlCommand("INSERT INTO accountants(Lastname,Firstname,Middlename,Age,Dateofbirth,Placeofbirth,ContactNo,Gender,MaritalStatus,Citizenship,Religion,Address)VALUES(" +
                "@lname,@fname,@mname,@age,@dob,@pob,@contact,@gender,@marital,@citizen,@religion,@address)", conn))
            {
                cmd.Parameters.AddWithValue("@lname", lastname);
                cmd.Parameters.AddWithValue("@fname", firstname);
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

        public void UPDATE_DATA()
        {
            conn = connect.getcon();
            conn.Open();

            using (cmd = new MySqlCommand("update accountants set lastname=@lname, firstname=@fname, middlename=@mname, age=@age, dateofbirth=@dob, placeofbirth=@pob," +
                "contactno=@contact,gender=@gender, maritalstatus=@marital, citizenship=@citizen, religion=@religion, address=@address WHERE accountantId=@id", conn))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("@lname", lastname);
                cmd.Parameters.AddWithValue("@fname", firstname);
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
        }
        public void VIEW_DATA()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("SELECT * from accountants", conn))
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

        public void PassData()
        {
            conn = connect.getcon();
            conn.Open();


            using (cmd = new MySqlCommand("SELECT * FROM accountants WHERE accountantId LIKE @id", conn))
            {

                cmd.Parameters.AddWithValue("@id", id);
                mdr = cmd.ExecuteReader();
                mdr.Read();

                if (mdr.HasRows)
                {
                    lastname = mdr[1].ToString();
                    firstname = mdr[2].ToString();
                    middlename = mdr[3].ToString();
                    age = mdr[4].ToString();
                    dateofbirth = mdr[5].ToString();
                    placeofbirth = mdr[6].ToString();
                    contactno = mdr[7].ToString();
                    gender = mdr[8].ToString();
                    maritalstatus = mdr[9].ToString();
                    citizenship = mdr[10].ToString();
                    religion = mdr[11].ToString();
                    address = mdr[12].ToString();
                }
                mdr.Close();
                conn.Close();
            }
        }
    }
}
