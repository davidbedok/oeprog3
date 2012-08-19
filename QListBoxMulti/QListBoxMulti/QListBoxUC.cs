using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QListBoxMulti
{
    public partial class QListBoxUC : UserControl
    {
        private int maxItemsCount;

        public event EventHandler MaxItemsLimitReached;

        public QListBoxUC()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        public string[] LeftItems
        {
            get
            {
                string[] ret = new string[lbLeft.Items.Count];
                for (int i = 0; i < (lbLeft.Items.Count - 1); i++)
                {
                    ret[i] = lbLeft.Items[i].ToString();
                }
                return ret;
            }
        }


        [Browsable(false)]
        public string[] RightItems
        {
            get
            {
                string[] ret = new string[lbRight.Items.Count];
                for (int i = 0; i < (lbRight.Items.Count - 1); i++)
                {
                    ret[i] = lbRight.Items[i].ToString();
                }
                return ret;
            }
        }

        [Category("QListBoxMulti")]
        [Browsable(true)]
        public int MaxItemsCount
        {
            get { return this.maxItemsCount; }
            set { this.maxItemsCount = value; }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                addItemToListBox(lbLeft, tbLeft.Text);
                // lbLeft.Items.Add(tbLeft.Text);
                tbLeft.Text = "";
            }
        }

        private void addItemToListBox( ListBox lb, string value)
        {
            if (lb.Items.Count < this.maxItemsCount)
            {
                lb.Items.Add(value);
            }
            else
            {
                if (MaxItemsLimitReached != null)
                {
                    MaxItemsLimitReached(this,EventArgs.Empty);
                }
            }
        }

        private void tbRight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                addItemToListBox(lbRight, tbRight.Text);
                // lbRight.Items.Add(tbRight.Text);
                tbRight.Text = "";
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            lbLeft.SelectionMode = SelectionMode.MultiExtended;
            lbRight.SelectionMode = SelectionMode.MultiExtended;

            this.MaxItemsCount = 10;

            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                addItemToListBox(lbLeft, rand.Next(1000).ToString()); 
                addItemToListBox(lbRight, rand.Next(1000).ToString());
            }

           
        }

        private void bMoveAllToRight_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < (lbLeft.Items.Count - 1); i++ )
            {
                lbRight.Items.Add(lbLeft.Items[i]);
            }
            lbLeft.Items.Clear();
        }

        private void bMoveAllToLeft_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < (lbRight.Items.Count - 1); i++)
            {
                lbLeft.Items.Add(lbRight.Items[i]);
            }
            lbRight.Items.Clear();
        }

        private void bMoveSelectedToRight_Click(object sender, EventArgs e)
        {
            for (int i = lbLeft.SelectedItems.Count - 1; i >= 0; i--)
            {
                lbRight.Items.Add(lbLeft.SelectedItems[i]);
                lbLeft.Items.Remove(lbLeft.SelectedItems[i]);
            }
        }

        private void bMoveSelectedToLeft_Click(object sender, EventArgs e)
        {
            for (int i = lbRight.SelectedItems.Count - 1; i >= 0; i--)
            {
                lbLeft.Items.Add(lbRight.SelectedItems[i]);
                lbRight.Items.Remove(lbRight.SelectedItems[i]);
            }
        }
    }
}
