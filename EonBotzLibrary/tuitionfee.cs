using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
namespace EonBotzLibrary
{
    public class tuitionfee
    {
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader mdr;
        public DataTable dt = new DataTable();

        public List<string> datafill = new List<string>();
        public List<string> datafillsubj = new List<string>();
        public string subjectcode { set; get; }
        public string categoryID { set; get; }
        public string category { set; get; }
        public string id { set; get; }
        public string total { set; get; }

        public void view()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("select  a.tuitioncatid,a.category,count(b.schedid),sum(c.lecprice),sum(c.labprice),sum(c.totalunits), sum(c.totalPrice) from tuitioncategory a left join  tuition b on a.tuitioncatid = b.tuitioncatid left join subjects c on c.subjectcode = b.subjectcode group by a.tuitioncatid", conn))
            {
                mdr = cmd.ExecuteReader();

                dt.Columns.Clear();
                dt.Columns.Add("ID");
                dt.Columns.Add("Category");
                dt.Columns.Add("Count");
                dt.Columns.Add("lec price");
                dt.Columns.Add("lab price");
                dt.Columns.Add("total units");
                dt.Columns.Add("total price");


                while (mdr.Read())
                {
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), mdr[4].ToString(), mdr[5].ToString(), mdr[6].ToString());
                }
            }
        }
        public void select()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("SELECT category FROM smsdb.tuitioncategory", conn))
            {
                mdr = cmd.ExecuteReader();

                dt.Columns.Clear();
                dt.Columns.Add("category");

                while (mdr.Read())
                {
                    datafill.Add(mdr[0].ToString());
                }
                conn.Close();
                conn.Dispose();

                conn = connect.getcon();
                conn.Open();

                dt.Clear();
                using (cmd = new MySqlCommand("SELECT subjectcode FROM smsdb.subjects", conn))
                {
                    mdr = cmd.ExecuteReader();

                    dt.Columns.Clear();
                    dt.Columns.Add("subjectcode");

                    while (mdr.Read())
                    {
                        datafillsubj.Add(mdr[0].ToString());
                    }
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        public void selectQuery()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("SELECT c.schedID , a.subjectcode, a.subjTitle FROM smsdb.tuition a, subjects b, schedule c where a.subjectCode = b.subjectcode and a.schedID = c.schedID and tuitionCatID = '" + id + "'", conn))
            {
                mdr = cmd.ExecuteReader();

                dt.Columns.Clear();
                dt.Columns.Add("schedID");
                dt.Columns.Add("subjectcode");
                dt.Columns.Add("subjTitle");

                while (mdr.Read())
                {
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString());

                }
            }

        }

        //public void selectQuery2()
        //{
        //    conn = connect.getcon();
        //    conn.Open();

        //    dt.Clear();
        //    using (cmd = new MySqlCommand("SELECT sum(b.totalprice) FROM smsdb.tuition a, subjects b where a.subjectCode = b.subjectcode and tuitionCatID = '" + id + "'", conn))
        //    {
        //        mdr = cmd.ExecuteReader();

        //        while (mdr.Read())
        //        {
        //            //dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString());
        //            total = mdr[0].ToString();
        //        }
        //    }

        //}



    }
}

