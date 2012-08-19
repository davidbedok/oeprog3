using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComboBoxEx3
{
    public class ComboBoxExClass  : ComboBox
    {

        public ComboBoxExClass()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /*
        public new ComboBoxStyle DropDownStyle
        {
            get { return base.DropDownStyle; }
            set { base.DropDownStyle = value; }
        }
         * */
        
        public new string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
        
    }
}