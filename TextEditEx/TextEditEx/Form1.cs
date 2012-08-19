using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TextEditEx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cMyOperation1.ResultChanged += new EventHandler(cMyOperation1_ResultChanged);
        }

        void cMyOperation1_ResultChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Result is "+cMyOperation1.GetResult().ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxEx1.ReadOnly = !textBoxEx1.ReadOnly;            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(textBoxEx1.IntValue);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxEx1.InsertSpaces();
        }
    }
}