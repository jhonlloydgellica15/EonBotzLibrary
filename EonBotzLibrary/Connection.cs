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
             conn = new MySqlConnection("server=192.168.1.3;user id=smsadmin; password=eonbotz2016!;database=smsdb;port=3306");

            return conn;
        }

    }
}
