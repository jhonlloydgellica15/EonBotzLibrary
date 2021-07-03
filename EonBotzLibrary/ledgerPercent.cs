using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace EonBotzLibrary
{
    public class ledgerPercent
    {
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader mdr;

        public string prelim { set; get; }
        public string midterm { set; get; }

        public string semi { set; get; }
        public string finals { set; get; }
        public string selectstudentid { set; get; }
        public string selectStudentSchedid { set; get; }
        public string downpayment { set; get; }
        public string studentDownpayment { set; get; }


        public void percent()
        {
            conn = connect.getcon();
            conn.Open();

            cmd = new MySqlCommand("select prelim,midterm,semiFinals,finals,downpayment from percentage where status ='Active' ", conn);
            mdr = cmd.ExecuteReader();
            while (mdr.Read())
            {
                prelim = mdr[0].ToString();
                midterm = mdr[1].ToString();
                semi = mdr[2].ToString();
                finals = mdr[3].ToString();
                downpayment = mdr[4].ToString();
            }
        }
        public void selectSchedID()
        {
            conn = connect.getcon();
            conn.Open();

            cmd = new MySqlCommand("select studentschedid from studentSched where studentid = '" + selectstudentid + "'", conn);
            mdr = cmd.ExecuteReader();
            while (mdr.Read())
            {
                selectStudentSchedid = mdr[0].ToString();
            }
        }
        public void insertBilling()
        {


        }

        public void percentee()
        {

            conn = connect.getcon();
            conn.Open();

            cmd = new MySqlCommand("select * from percentage", conn);
            mdr = cmd.ExecuteReader();
            while (mdr.Read())
            {
                selectStudentSchedid = mdr[0].ToString();
            }

        }


    }
}
