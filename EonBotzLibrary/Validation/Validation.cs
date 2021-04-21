using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace EonBotzLibrary
{
    public static class Validator
    {
        public static bool isEmpty(TextBox[] values)
        {
            foreach(var value in values)
            {
                if (value.Text.Equals(""))
                {
                    MessageBox.Show($"{value.Name.Substring(3)} must not be empty");
                    return true;
                }
            }
            return false;
        }

        public static void AlertSuccess(string message)
        {
            MessageBox.Show(message, "Message Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void AlertDanger(string message)
        {
            MessageBox.Show(message, "Message Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool DeleteConfirmation()
        {
            DialogResult dr = MessageBox.Show("Do you want to Delete ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dr == DialogResult.Yes ? true : false;

            //if (dr == DialogResult.Yes)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public static bool TextMin(TextBox single, TextBox[] values, int num = 0)
        {
            if(!single.Text.Equals(""))
            {
                if (single.TextLength <= num)
                {
                    AlertDanger($"{single.Name.Substring(3)} must greater than {num}");
                    return true;
                }
                return false;
            }
            foreach(var value in values)
            {
                if(value.TextLength <= num)
                {
                    AlertDanger($"{value.Name.Substring(3)} must greater than {num}");
                    return true;
                }            
            }
            return false;   
        }
        public static bool AddConfirmation()
        {
            DialogResult dr = MessageBox.Show("Do you want to Add ?", "Add Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dr == DialogResult.Yes ? true : false;
        }

        public static bool UpdateConfirmation()
        {
            DialogResult dr = MessageBox.Show("Do you want to Update ?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dr == DialogResult.Yes ? true : false;
        }

        public static void ClearTextField(TextBox[] values)
        {
            foreach (var value in values)
            {
                value.Text = "";
            }
        }
    }
}
