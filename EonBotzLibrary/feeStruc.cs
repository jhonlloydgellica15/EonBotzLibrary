using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
namespace EonBotzLibrary
{
    public class feeStruc
    {
        public string structurename { set; get; }
        public string structureID { set; get; }
        public string structuredescrip { set; get; }
        public string total { set; get; }
        public string categoryID { set; get; }
        public string getcatid { set; get; }
        public string getcat { set; get; }
        public string category { set; get; }
        public string id { set; get; }
        public string amount { set; get; }
        public List<string> datafill = new List<string>();
        public DataTable dt = new DataTable();
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader mdr;
        public void view()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("SELECT distinct  a.structureID,a.structureName,a.description,count( c.categoryid )as count, sum( c.total)as total FROM smsdb.feestructure a,smsdb.categoryfee b, smsdb.totalfee c  where  a.structureID = c.structureID  group by  c.structureID,a.structureID,b.categoryid", conn))
            {
                mdr = cmd.ExecuteReader();



                dt.Columns.Clear();
                dt.Columns.Add("ID");
                dt.Columns.Add("structurename");
                dt.Columns.Add("Description");
                dt.Columns.Add("count");
                dt.Columns.Add("total");


                while (mdr.Read())
                {
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), mdr[4].ToString());
                }
            }
        }
        public void getid()
        {
            conn = connect.getcon();
            conn.Open();
            cmd = new MySqlCommand("select distinct a.categoryid from totalfee a, categoryfee b  where b.category = '" + getcat + "' and a.categoryid = b.categoryid  ",conn);
            mdr = cmd.ExecuteReader();
            while(mdr.Read())
            {
                getcatid = mdr[0].ToString();
            }    

        }

        public void viewcategory()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("SELECT distinct  a.structureID,a.structureName,a.description,count( c.categoryid )as count, sum( c.total)as total FROM smsdb.feestructure a,smsdb.categoryfee b, smsdb.totalfee c  where  a.structureID = c.structureID  group by  c.structureID,a.structureID,b.categoryid", conn))
            {
                mdr = cmd.ExecuteReader();



                dt.Columns.Clear();
                dt.Columns.Add("ID");
                dt.Columns.Add("structurename");
                dt.Columns.Add("Description");
                dt.Columns.Add("count");
                dt.Columns.Add("total");


                while (mdr.Read())
                {
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), mdr[4].ToString());
                }
            }
        }
        public void viewfees()
        {
            conn = connect.getcon();
            conn.Open();

            using (cmd = new MySqlCommand("select    a.category, b.total from categoryfee a, totalfee b where b.structureid ='" + structureID + "' and a.categoryid = b.categoryid group by b.totalfeeid", conn))
            {
                mdr = cmd.ExecuteReader();
                dt.Columns.Clear();
                dt.Columns.Add("category");
                dt.Columns.Add("amount");

                if (mdr.HasRows)
                {
                    while (mdr.Read())
                    {
                        dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString());
                    }
                    conn.Close();

                    conn = connect.getcon();
                    conn.Open();
                    cmd = new MySqlCommand("select   sum(b.total),count(b.total) from categoryfee a, totalfee b where b.structureid ='"+structureID+"' and a.categoryid = b.categoryid", conn);
                    mdr = cmd.ExecuteReader();
                    while (mdr.Read())
                    {
                        total = mdr[0].ToString();
                    }
                }
            }



        }

        public void viewcategories()
        {

            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("SELECT category FROM smsdb.categoryfee;", conn))
            {
                mdr = cmd.ExecuteReader();



                dt.Columns.Clear();
                dt.Columns.Add("category");



                while (mdr.Read())
                {
                    datafill.Add(mdr[0].ToString());
                }
            }

        }
        public void viewcategoryID()
        {
            conn = connect.getcon();
            conn.Open();

            cmd = new MySqlCommand("select categoryid from categoryfee where category ='" + category + "'", conn);
            mdr = cmd.ExecuteReader();
            while(mdr.Read())
            {
                categoryID = mdr[0].ToString();
            }
        }
        public void insertfee()
        {
            conn = connect.getcon();
            conn.Open();

            using (cmd = new MySqlCommand("INSERT INTO totalfee(structureid,categoryid,total)VALUES(" +
                "@structureid,@categoryid,@total)", conn))
            {
                cmd.Parameters.AddWithValue("@structureid", structureID);
                cmd.Parameters.AddWithValue("@categoryid", categoryID);
                cmd.Parameters.AddWithValue("@total", amount);
     
                cmd.ExecuteNonQuery();
                

            }
            conn.Close();
        }

    }

}

