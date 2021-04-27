using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
namespace EonBotzLibrary
{
  public  class feeStruc
    {
        public string structurename { set; get; }
        public string structureID { set; get; }
        public string structuredescrip { set; get; }
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

    }
 


}

