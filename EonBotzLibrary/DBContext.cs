using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using SqlKata.Execution;
using SqlKata.Compilers;

namespace EonBotzLibrary
{
    public static class DBContext
    {

        static MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;password=eonbotz;database=smsdb;port=3306");
        static MySqlCompiler compiler = new MySqlCompiler();

        public static QueryFactory GetContext() => new QueryFactory(connection, compiler);
    }
}
