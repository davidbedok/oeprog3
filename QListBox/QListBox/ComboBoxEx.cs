using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QListBox
{
    // public delegate void DropDownEventHandler(object sender, System.Windows.Forms.ComboBoxStyle value);

    public class ComboBoxEx : System.Windows.Forms.ComboBox
    {

        public new System.Windows.Forms.ComboBoxStyle DropDownStyle
        {
            get { return this.DropDownStyle; }
            set {
                if (System.Windows.Forms.ComboBoxStyle.DropDownList.Equals(value))
                {
                    this.DropDownStyle = value;
                }
                else
                {
                    /*
                    if (DropDownStyleForbiddenNotify != null)
                    {
                        DropDownStyleForbiddenNotify(this,value);
                    }
                     * */
                    this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                }
            }
        }


        //public event DropDownEventHandler DropDownStyleForbiddenNotify;

    }
}
