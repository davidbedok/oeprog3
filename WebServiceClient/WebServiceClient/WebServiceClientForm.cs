using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebServiceClient
{
    public partial class WebServiceClientForm : Form
    {
        private storeService.Service1 service;
        private storeService.StoreItemStruct[] storeItems;
        private storeService.UserStruct loginUser;

        public WebServiceClientForm()
        {
            InitializeComponent();
            this.service = new WebServiceClient.storeService.Service1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbPong.Text = service.Ping();
            if ("Pong".Equals(tbPong.Text))
            {
                pTestConnection.BackColor = Color.Green;
                this.bGetList.Enabled = true;
                this.bLogin.Enabled = true;
            }
            else
            {
                pTestConnection.BackColor = Color.Red;
            }                 
        }

        private void bGetList_Click(object sender, EventArgs e)
        {
            this.storeItems = this.service.List();
            if (cbItems.Items.Count == 0)
            {
                for (int i = 0; i < this.storeItems.Length; i++)
                {
                    cbItems.Items.Add((this.storeItems[i] as storeService.StoreItemStruct).name);
                }
                if (cbItems.Items.Count > 0)
                {
                    cbItems.SelectedIndex = 0;
                }
            }
            dgvStoreItems.DataSource = this.storeItems;
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            int id = this.service.Login(tbLoginname.Text, tbPassword.Text);
            if (id > 0)
            {
                this.loginUser = this.service.GetLoginUser(id);
                lWelcome.Text = "Welcome\n" + this.loginUser.name;
                lWelcome.Visible = true;
                bBuy.Enabled = true;
                nudCount.Enabled = true;
                cbItems.Enabled = true;
                this.lWelcome.ForeColor = Color.Green;
            }
            else
            {
                lWelcome.Text = "Wrong name\nor password!";
                lWelcome.Visible = true;
                bBuy.Enabled = false;
                nudCount.Enabled = false;
                cbItems.Enabled = false;
                this.lWelcome.ForeColor = Color.Red;
            }
        }

        private void bBuy_Click(object sender, EventArgs e)
        {
            string name = (cbItems.Items[cbItems.SelectedIndex] as String);
            int price = this.service.BuyByName(name, Convert.ToInt32(nudCount.Value));
            if (price > 0)
            {
                this.lResult.ForeColor = Color.Green;
                this.lResult.Text = "Buy complete (" + price + " HUF)!";
                this.lResult.Visible = true;
                this.bGetList_Click(sender,e);
            }
            else
            {
                this.lResult.ForeColor = Color.Red;
                this.lResult.Text = "Not enought item!";
                this.lResult.Visible = true;
            }
        }
    }
}
