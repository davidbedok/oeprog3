using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MyOperation
{
    public partial class CMyOperation : UserControl
    {
        int arg1 = 0;
        int arg2 = 0;
        int res = 0;

        public CMyOperation()
        {
            InitializeComponent();
        }

        [Category("MyCategory")]
        [Description("First argumentum")]
        [DefaultValue(0)]
        public int FirstArg
        {
            get 
            {
                int temp;
                try { 
                    temp = Convert.ToInt32(textBox1.Text); 
                } catch (Exception le) { 
                    temp = -1; 
                }
                return temp; 
            }
            set
            {
                if (!(textBox1.Text.Equals(Convert.ToString(value))))
                {
                    textBox1.Text = Convert.ToString(value);                    
                }
            }
        }

        [Category("MyCategory")]
        [Description("Second argumentum")]
        [DefaultValue(0)]
        public int SecondArg
        {
            get
            {
                int temp;
                try
                {
                    temp = Convert.ToInt32(textBox2.Text);
                }
                catch (Exception le)
                {
                    temp = -1;
                }
                return temp;
            }
            set
            {
                if (!(textBox2.Text.Equals(Convert.ToString(value))))
                {
                    textBox2.Text = Convert.ToString(value);                    
                }
            }
        }

        public int GetResult()
        {
            return res;
        }

        public void SetResult()
        {
            res = arg1 + arg2;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            arg1 = FirstArg;
            arg2 = SecondArg;
            SetResult();
            textBox3.Text = Convert.ToString(GetResult());
            if (ResultChanged != null)
            {
                ResultChanged(this, EventArgs.Empty);
            }
        }

        [Category("MyCategory")]
        [Description("Fire when result is ready.")]       
        public event EventHandler ResultChanged;

    }
}