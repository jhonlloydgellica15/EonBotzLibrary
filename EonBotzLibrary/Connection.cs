using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace EonBotzLibrary
{
    public class Connection
    {
          public  MySqlConnection conn;
          public  MySqlCommand cmd;
          public MySqlDataReader dr;
          public string res;



        public MySqlConnection getcon()
        {
            conn = new MySqlConnection("server=localhost;user id=root;password=eonbotz;port=3306;database=smsdb");
        

            return conn;
        }

        //public string QuerySelect(string table = "", string key = "", string value = "")
        //{

        //    if (!table.Equals(""))
        //    {
        //        res = "RESULT";
        //        cmd = new MySqlCommand($"SELECT *  FROM {table} ", getcon()); //select query
        //        dr = cmd.ExecuteReader(); // execute query

        //        return res; // return result


        //    }


        //    return res;

        //}

    }
}
