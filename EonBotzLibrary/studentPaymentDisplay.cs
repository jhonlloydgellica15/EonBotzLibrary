using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace EonBotzLibrary
{


    public class studentPaymentDisplay
    {
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlDataReader mdr;
        MySqlCommand cmd;
        public DataTable dt = new DataTable();
        
        public string studentID { set; get; }
        public string prelim { set; get; }

        public string midterm { set; get; }
        public string currentbalance { set; get; }
        public string semi { set; get; }
        public string final { set; get; }
        public string total { set; get; }
        public string billingid { set; get; }
        public string amount { set; get; }
        public string remarks { set; get; }
        public string paymentMethod { set; get; }
        public string status { set; get; }
        public string totalpaid { set; get; }


        public void display()
        {
            //display
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("select c.studentid,c.firstname,c.lastname,b.total  from  Billing b , studentSched a,student c where b.studentSchedID = a.studentSchedID and c.studentid = a.studentid", conn))
            {
                mdr = cmd.ExecuteReader();
                dt.Columns.Clear();

                dt.Columns.Add("StudentID");
                dt.Columns.Add("Name");

                dt.Columns.Add("Total");

                while (mdr.Read())
                {
                    dt.Rows.Add(mdr[0].ToString(), $"{mdr[1].ToString()} {mdr[2].ToString()}", mdr[3].ToString());
                
                }
            }
        }

        public void viewPayment()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("select a.prelim,midterm,semi,finals,total,billingid from Billing a,studentSched b,student c where  a.studentSchedid = b.studentSchedID and b.studentid = c.studentid and c.studentid ='"+studentID+"'", conn))
            {
                mdr = cmd.ExecuteReader();
           

                while (mdr.Read())
                {
                    prelim = mdr[0].ToString();
                    midterm = mdr[1].ToString();
                    semi = mdr[2].ToString();
                    final = mdr[3].ToString();
                    total = mdr[4].ToString();
                    billingid = mdr[5].ToString();
                }
            }


        }


        public void insertpayment()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            cmd = new MySqlCommand("insert into payment(billingid,amount,remarks,paymentmethod,date,time,status) values ('" + billingid + "','" + amount + "','" + remarks + "','" + paymentMethod + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','"+status+"')", conn);
            cmd.ExecuteNonQuery();
           
        }

        public void viewtransaction()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            cmd = new MySqlCommand("select b.amount,b.remarks,b.date  from Billing a, payment b where a.billingid = b.billingid and a.billingid ='"+billingid+"'", conn);
            mdr = cmd.ExecuteReader();
       
            dt.Columns.Clear();

            dt.Columns.Add("amount");
            dt.Columns.Add("remarks");
            dt.Columns.Add("date");



            while (mdr.Read())
            {
                dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(),mdr[2].ToString());
            }

        }
        public void viewPaymentDetailed()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            cmd = new MySqlCommand("select sum(b.amount) from Billing a, payment b where a.billingid = b.billingid  and a.billingid = '" + billingid + "'", conn);
            mdr = cmd.ExecuteReader();
            while(mdr.Read())
            {
                totalpaid = mdr[0].ToString();
            }

            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            cmd = new MySqlCommand("select  a.total  -sum(b.amount)  from Billing a, payment b where a.billingid = b.billingid  and a.billingid ='" + billingid + "'", conn);
            mdr = cmd.ExecuteReader();
            while (mdr.Read())
            {
                currentbalance = mdr[0].ToString();
            }


        }
    }   
}