using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomComboBox
{
    class ComboBoxEx2  : ComboBox
    {

        public new string Text
        {
            get { return this.Text; }
            set { this.Text = value; }
        }


    }
}
