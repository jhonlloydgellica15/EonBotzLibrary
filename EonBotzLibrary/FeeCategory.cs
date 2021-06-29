    using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace EonBotzLibrary
{
    public class FeeCategory
    {
        Connection connect = new Connection();
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader mdr;

        public string id { set; get; }
        public string category { set; get; }
        public string subcategory { set; get; }

        public string description { set; get; }
        public string amount { set; get; }
        public string curriculum { set; get; }
        public DataTable dt = new DataTable();


        public void CREATE_DATA()
        {
            conn = connect.getcon();
            conn.Open();
            

            using(cmd = new MySqlCommand("INSERT INTO feecategories(category)VALUES(@categ)", conn))
            {
                cmd.Parameters.AddWithValue("@categ", category);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            mdr.Close();
        }

        public void UPDATE_DATA()
        {
            conn = connect.getcon();
            conn.Open();

            using (cmd = new MySqlCommand("update feecategories set description=@desc WHERE feeID=@id", conn))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            mdr.Close();
        }
        public void VIEW_DATA()
        {
            conn = connect.getcon();
            conn.Open();

            dt.Clear();
            using (cmd = new MySqlCommand("SELECT * from feecategories", conn))
            {
                mdr = cmd.ExecuteReader();

                //dt.Columns.Add("Name", typeof(string));
                //while (mdr.Read())
                //{

                //    dt.Rows.Add(mdr[0].ToString() + " , " + mdr[1].ToString());
                //}

                dt.Columns.Clear();
                dt.Columns.Add("ID");
                dt.Columns.Add("Category");
                dt.Columns.Add("SubCategory");
                dt.Columns.Add("Description");
                dt.Columns.Add("Amount");
                dt.Columns.Add("CurriculumID");

                while (mdr.Read())
                {
                    dt.Rows.Add(mdr[0].ToString(), mdr[1].ToString(), mdr[2].ToString(), mdr[3].ToString(), mdr[4].ToString(), mdr[5].ToString());
                }
                conn.Close();
                mdr.Close();
            }
        }

        public void PassData()
        {
            conn = connect.getcon();
            conn.Open();


            using (cmd = new MySqlCommand("SELECT * FROM feecategories WHERE feeID LIKE @id", conn))
            {

                cmd.Parameters.AddWithValue("@id", id);
                mdr = cmd.ExecuteReader();
                mdr.Read();

                if (mdr.HasRows)
                {
                    category = mdr[1].ToString();
                    subcategory = mdr[2].ToString();
                    description = mdr[3].ToString();
                    amount = mdr[4].ToString();
                    curriculum = mdr[5].ToString();
                }
                mdr.Close();
                conn.Close();
            }
        }
    }
}
