using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication3
{
    class MyCheckBox : System.Windows.Forms.CheckBox
    {

        private int fChangeNumber = 0;
       
        public new bool Checked
        {
            get {                
                return base.Checked; 
            }
            set
            {                
                fChangeNumber++;                
                if (value)
                {                    
                    this.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
                }
                else
                {
                    this.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular );
                }
                base.Checked = value;
            }
        }
         
        public int ChangeNumber
        {
            get
            {
                return fChangeNumber;
            }
        }
        


    }
}
