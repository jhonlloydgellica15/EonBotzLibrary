using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
namespace EonBotzLibrary
{
    class feeStructure
    {
        public string structurename { set; get; }
        public string structureID { set; get; }
        public string structuredescrip { set; get; }

        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader mdr;

    }


}
