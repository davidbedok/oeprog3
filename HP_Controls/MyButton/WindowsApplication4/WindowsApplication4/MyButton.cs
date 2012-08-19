using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication4
{
    class MyButton : System.Windows.Forms.Button
    {        

        private int fEnterNumber = 0;

        public int EnterNumber
        {
            get { return fEnterNumber; }
        }

        public MyButton()
        {            
            this.MouseEnter += new System.EventHandler(this.myEventHandler_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.myEventHandler_MouseLeave);
            fEnterNumber = 0;
        }         

        private void myEventHandler_MouseEnter(object sender, EventArgs e)
        {
            this.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
            fEnterNumber++;
        }

        private void myEventHandler_MouseLeave(object sender, EventArgs e)
        {
            this.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
        }


    }
}
