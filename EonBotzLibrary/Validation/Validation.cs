using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace EonBotzLibrary
{

    public static class Validator
    {
        //Validate accept numbers only
        public static void ValidateKeypressNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        //Disable all textbox
        public static void disableTextbox(TextBox[] values)
        {
            foreach (var value in values)
            {
                value.Enabled = false;
            }
        }

        public static string ToTitleCase(string title)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
        }

        //Check if combobox is empty
        public static bool isEmptyCmb(ComboBox[] values)
        {
            foreach (var value in values)
            {
                if (value.Text.Equals(""))
                {
                    AlertDanger($"{value.Name.Substring(3)} must not be empty");
                    return false;
                }
            }
            return true;
        }

        //Hide buttons
        public static void hideButton(Button[] values)
        {
            foreach(var value in values)
            {
                value.Visible = false;
            }
        }
        //Check if textbox is empty function
        public static bool isEmpty(TextBox[] values)
        {
            foreach (var value in values)
            {
                if (value.Text.Equals(""))
                {
                    AlertDanger($"{value.Name.Substring(3)} must not be empty");
                    return false;
                }
            }
            return true;
        }

        //Remove Subject Activation
        public static bool RemoveSubject()
        {
            DialogResult dr = MessageBox.Show("Do you want to remove this subject?", "Add Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dr == DialogResult.Yes ? true : false;
        }

        //Confirmation for activation and deactivation of academic year
        public static bool deactYear()
        {
            DialogResult dr = MessageBox.Show("Do you want to deactivate ?", "Add Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dr == DialogResult.Yes ? true : false;
        }

        public static bool actYear()
        {
            DialogResult dr = MessageBox.Show("Do you want to activate ?", "Add Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dr == DialogResult.Yes ? true : false;
        }
        //

        //Confirmation Function
        public static bool AddPreview()
        {
            DialogResult dr = MessageBox.Show("Do you want to preview ?", "Add Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dr == DialogResult.Yes ? true : false;
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


        public static bool DeleteConfirmation()
        {
            DialogResult dr = MessageBox.Show("Do you want to delete ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dr == DialogResult.Yes ? true : false;
        }
        //

        //Checkk the minimum input lengths of textfields
        //public static bool TextMin(TextBox[] values, int num)
        //{
        //    foreach(var value in values)
        //    {
        //        if(value.TextLength <= num)
        //        {
        //            AlertDanger($"{value.Name.Substring(3)} must greater than {num}");
        //            return true;
        //        }            
        //    }
        //    return false;   
        //}

        public static bool TextMin(TextBox single, int num)
        {
            if (!single.Text.Equals(""))
            {
                if (single.TextLength <= num)
                {
                    AlertDanger($"{single.Name.Substring(3)} must greater than {num}");
                    return true;
                }
            }
            return false;
        }
        //

        //Check if the textbox length is equal
        public static bool TextEqual(TextBox single, int num)
        {
            if (single.TextLength < num)
            {
                AlertDanger($"{single.Name.Substring(3)} text length must equal to {num}");
                return false;
            }
            return true;
        }
        //

        public static bool ValidateDate(DateTimePicker date)
        {
            if (!date.Value.Equals(""))
            {
                if (date.Value.Date >= DateTime.Now.Date)
                {
                    AlertDanger("Please select not greater than or not equal to current date");
                    return false;
                }
            }
            return true;
        }

        //Clear all textfields function
        public static void ClearTextField(TextBox[] values)
        {
            foreach (var value in values)
            {
                value.Text = "";
            }
        }
        //


        //Alert Message Here
        public static void AlertSuccess(string message)
        {
            MessageBox.Show(message, "Message Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void AlertDanger(string message)
        {
            MessageBox.Show(message, "Message Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //
    }
}
