using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace EonBotzLibrary
{
    public class Validity
    {
        public bool isEmpty(TextBox[] values)
        {
            foreach(var value in values)
            {
                if (value.Text.Equals(""))
                {
                    MessageBox.Show("Field must not be empty");
                    return true;
                }
            }
            return false;
        }
    }
}
