﻿using System;
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

        public void view()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
 using (cmd = new MySqlCommand("SELECT distinct a.tuitionCatID, a.category,(select count(c.subjectcode) from tuition b, subjects c   where a.tuitioncatID = b.tuitioncatID  and b.subjectcode = c.subjectcode),(select    sum(c.totallecprice) from tuition b, subjects c   where a.tuitioncatID = b.tuitioncatID  and b.subjectcode = c.subjectcode),(select    sum(c.totallabprice) from tuition b,subjects c   where a.tuitioncatID = b.tuitioncatID  and b.subjectcode = c.subjectcode),(select    sum(c.totalunits) from tuition b,subjects c   where a.tuitioncatID = b.tuitioncatID  and b.subjectcode = c.subjectcode),(select    sum(c.totalprice) from tuition b,subjects c   where a.tuitioncatID = b.tuitioncatID  and b.subjectcode = c.subjectcode)from tuitioncategory a ,tuition b, subjects c group by a.tuitioncatid,b.tuitioncatid,c.subjectcode", conn))
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
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), mdr[4].ToString(),mdr[5].ToString(), mdr[6].ToString());
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


        }


    }
}

