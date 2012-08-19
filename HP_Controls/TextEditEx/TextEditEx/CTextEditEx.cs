using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace TextEditEx
{
    public class TextBoxEx : TextBox
    {
        Cursor savedCursor;

        // Constructor
        public TextBoxEx()
        {
            savedCursor = base.Cursor;
        }

        // Hide property in the Properties panel (Design mode), but visible in Code (public..)
        [Browsable(false)]
        public new Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        // View override property in a new Category (only in Categorized view take affect)
        [Browsable(true)] // default..
        [Category("myAddonProperties")]
        [Description("Special ReadOnly properites")]
        public new bool ReadOnly
        {           
            get { return base.ReadOnly; }
            set
            {                
                //base.Cursor = Cursor.
                //System.Windows.Forms.TextBox
                if (value)
                {
                    this.Cursor = Cursors.No;
                    this.BackColor = Color.Yellow;
                }
                else
                {
                    this.Cursor = savedCursor;
                    this.BackColor = Color.FromKnownColor(KnownColor.Window);
                }

                base.ReadOnly = value;
            }
        }

        [Browsable(false)]                        
        public int IntValue
        {
            get 
            {
                try
                {
                    return System.Convert.ToInt32(this.Text);                    
                } catch (Exception e) {
                    return -1;
                }                
            }          
        }

        public void InsertSpaces()
        {
            string tempstring = this.Text;
            string newstring = "";
            for (int i = 0; i < tempstring.Length; i++ )
            {
                newstring += tempstring[i]+" ";
            }
            this.Text = newstring;
        }
    }
}
