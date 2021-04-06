using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace EonBotzLibrary
{
    class Connection
    {
        MySqlConnection conn;

        public MySqlConnection getcon()
        {
            conn = new MySqlConnection("server=localhost;user id=root;password=eonbotz;port=3306;database=smsdb");
            return conn;
        }

    }
}
