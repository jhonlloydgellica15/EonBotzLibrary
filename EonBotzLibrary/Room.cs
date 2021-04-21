using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
namespace EonBotzLibrary
{
    public class Room
    {

        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader mdr;

        public DataTable dt = new DataTable();

        public string id { set; get; }
        public string description { set; get; }

//Hello
        public void CREATE_DATA()
        {
            conn = connect.getcon();
            conn.Open();

            using(cmd = new MySqlCommand("INSERT INTO rooms(description)VALUES(@desc)", conn))
            {
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void UPDATE_DATA()
        {
            conn = connect.getcon();
            conn.Open();

            using (cmd = new MySqlCommand("update rooms set description=@desc WHERE roomId=@id", conn))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("@desc", description);

                cmd.ExecuteNonQuery();
            }
        }

        public void VIEW_DATA()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("SELECT * from rooms", conn))
            {
                mdr = cmd.ExecuteReader();

                //dt.Columns.Add("Name", typeof(string));
                //while (mdr.Read())
                //{
                //    dt.Rows.Add(mdr[0].ToString() + " , " + mdr[1].ToString());
                //}

                dt.Columns.Clear();
                dt.Columns.Add("ID");
                dt.Columns.Add("Description");

                while (mdr.Read())
                {
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString());
                }
            }
        }

        public void PassData()
        {
            conn = connect.getcon();
            conn.Open();


            using (cmd = new MySqlCommand("SELECT * FROM rooms WHERE roomId LIKE @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                mdr = cmd.ExecuteReader();
                mdr.Read();

                if (mdr.HasRows)
                {
                    description = mdr[1].ToString();
                }
                mdr.Close();
                conn.Close();
            }
        }

        public void showRoomUsed()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("SELECT date, timeStart, timeEnd, roomID FROM schedule ", conn))
            {
                dt.Columns.Clear();
                dt.Columns.Add("ID");
                dt.Columns.Add("Day");
                dt.Columns.Add("Schedule");
                dt.Columns.Add("Room");

                while (mdr.Read())
                {
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString() + mdr[2].ToString(), mdr[3].ToString());
                }
            }
            conn.Close();
        }
    }
}
