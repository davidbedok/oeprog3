using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication4
{
    public partial class FormButton : Form
    {
        public FormButton()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "";
        }
      
        private void myButton1_MouseMove(object sender, MouseEventArgs e)
        {            
            toolStripStatusLabel1.Text = e.X.ToString() + " x " + e.Y.ToString();         
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show( myButton.EnterNumber.ToString() );
        }
    }
}