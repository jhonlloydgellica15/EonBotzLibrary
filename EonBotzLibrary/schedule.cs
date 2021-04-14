﻿
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
namespace EonBotzLibrary
{
    public class schedule
    {

        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlDataReader mdr;
        MySqlCommand cmd;

        public List<string> datafill = new List<string>();
        public List<string> datafillroom = new List<string>();
        public List<string> datafillcourse = new List<string>();

        public string timediff { set; get; }
        public string subjcode { set; get; }
        public string subjTitle { set; get; }
        public string roomdesc { set; get; }
        public string date { set; get; }
        public string timeStart { set; get; }
        public string timeEnd { set; get; }
        public string maxStudent { set; get; }
        public string status { set; get; }
        public string roomid { set; get; }
        public string course { set; get; }
        public string timeending { set; get; }
        public string timedifftuesday { set; get; }


        public DataTable dt = new DataTable();


        private DataSet ds = new DataSet();
        public void times()
        {

            conn = connect.getcon();
            conn.Open();



            //cmd = new MySqlCommand("select date from schedule where date regexp '["+date+"]'", conn);
            //{
            //    mdr = cmd.ExecuteReader();

            //    while (mdr.Read())
            //    {
            //        timediff = mdr[0].ToString();
            //    }
            //    conn.Close();
            //}
            cmd = new MySqlCommand(" select timeend from schedule where roomid = '"+roomid+"'and date regexp'["+date+ "]'and timestart between '" + timeStart + "'and timestart   <='" + timeEnd + "' and timeend between'" + timeStart + "'and timeend <='" + timeEnd + "'", conn);
            {
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    timediff = mdr[0].ToString();

                }
                conn.Close();
            }
        }
        public void tuesday()
        {

            conn = connect.getcon();
            conn.Open();

            cmd = new MySqlCommand(" select timeend from schedule where roomid = '" + roomid + "'and date = 'th' and timestart between '" + timeStart + "'and timestart   <='" + timeEnd + "' and timeend between'" + timeStart + "'and timeend <='" + timeEnd + "'", conn);
            {
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    timedifftuesday = "wew";

                }
                conn.Close();
            }
        }
        public void Schedule()
        {
            conn = connect.getcon();
            conn.Open();

            datafill.Clear();

            using (cmd = new MySqlCommand("SELECT subjectcode FROM subjects", conn))
            {
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    datafill.Add(mdr[0].ToString());
                }
                conn.Close();
            }

            conn = connect.getcon();
            conn.Open();

            datafillroom.Clear();

            using (cmd = new MySqlCommand("SELECT description FROM rooms", conn))
            {
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    datafillroom.Add(mdr[0].ToString());
                }
                conn.Close();
            }


            conn = connect.getcon();
            conn.Open();

            datafillcourse.Clear();

            using (cmd = new MySqlCommand("SELECT description FROM course", conn))
            {
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    datafillcourse.Add(mdr[0].ToString());
                }
                conn.Close();
            }

        }
        public void viewroomNum()
        {

            status = "available";

            conn = connect.getcon();
            conn.Open();
            cmd = new MySqlCommand("select roomID from rooms where description = '" + roomdesc + "'", conn);
            mdr = cmd.ExecuteReader();
            while (mdr.Read())
            {
                roomid = mdr[0].ToString();
            }
            conn.Close();
        }
        public void viewCourseID()
        {

            conn = connect.getcon();
            conn.Open();
            cmd = new MySqlCommand("select courseID from course where description = '" + course + "'", conn);
            mdr = cmd.ExecuteReader();
            while (mdr.Read())
            {
                course = mdr[0].ToString();
            }
            conn.Close();


        }

        public void insertSched()
        {
            viewroomNum();

            viewCourseID();

            conn = connect.getcon();
            conn.Open();

            using (cmd = new MySqlCommand("INSERT INTO schedule(subjectCode,roomid,date,timestart,timeend,status,maxStudent,courseID)VALUES(" +
                "@subjcode,@roomid,@date,@timestart,@timeend,@status,@maxStudent,@course)", conn))
            {
                cmd.Parameters.AddWithValue("@subjcode", subjcode);
                cmd.Parameters.AddWithValue("@roomid", roomid);
                cmd.Parameters.AddWithValue("@course", course);
                cmd.Parameters.AddWithValue("@date", date);

                cmd.Parameters.AddWithValue("@timestart", timeStart);
                cmd.Parameters.AddWithValue("@timeend", timeEnd);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@maxStudent", maxStudent);
                cmd.ExecuteNonQuery();

            }
            conn.Close();
        }
        public void Viewdescription()
        {
            conn = connect.getcon();
            conn.Open();
            using (cmd = new MySqlCommand("select subjectTitle from subjects where subjectcode =@subjCode", conn))
            {
                cmd.Parameters.AddWithValue("@subjCode", subjcode);
                mdr = cmd.ExecuteReader();
                mdr.Read();
                if (mdr.HasRows)
                {
                    subjTitle = mdr[0].ToString();
                }
                mdr.Close();
                conn.Close();
            }
        }
        public void viewsched()
        {

            conn = connect.getcon();
            conn.Open();


            dt.Clear();
            using (cmd = new MySqlCommand("SELECT * from schedule", conn))
            {
                mdr = cmd.ExecuteReader();

                //dt.Columns.Add("Name", typeof(string));
                //while (mdr.Read())
                //{

                //    dt.Rows.Add(mdr[0].ToString() + " , " + mdr[1].ToString());
                //}

                dt.Columns.Clear();
                dt.Columns.Add("SchedID");
                dt.Columns.Add("SubjectCode");
                dt.Columns.Add("CourseID");
                dt.Columns.Add("date");
                dt.Columns.Add("maxStudent");
                dt.Columns.Add("status");
                dt.Columns.Add("time start");
                dt.Columns.Add("time end");
      

                while (mdr.Read())
                {
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), mdr[4].ToString(), mdr[5].ToString(), mdr[6].ToString(), mdr[7].ToString());
                }
            }

        }
    }
}