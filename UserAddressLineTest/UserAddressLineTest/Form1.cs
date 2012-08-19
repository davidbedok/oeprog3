using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserAddressLineTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addressData1_AddressLine1Changed(object sender, EventArgs e)
        {
            MessageBox.Show("AddressLine1 Changed");
        }

        private void addressData1_AddressLine2Changed(object sender, EventArgs e)
        {
            MessageBox.Show("Hello2");
        }

        private void addressData1_CityChanged(object sender, EventArgs e)
        {
            MessageBox.Show("City");
        }

        private void addressData1_CountryChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Country");
        }

        private void addressData1_ZipCodeChanged(object sender, EventArgs e)
        {
            MessageBox.Show("ZIP");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addressData1.AddressLine1 = "AddressLine1";
        }
    }
}
