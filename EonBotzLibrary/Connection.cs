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
             conn = new MySqlConnection("server=localhost;user id=root; password=12345;database=smsdb;port=3306");

            return conn;
        }

    }
}
