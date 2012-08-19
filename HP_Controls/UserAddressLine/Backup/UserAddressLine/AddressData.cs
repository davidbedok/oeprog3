using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UserAddressLine
{
    public partial class AddressData : UserControl
    {
        public AddressData()
        {
            InitializeComponent();
            cbCountry.Items.Add("Hungary");
            cbCountry.Items.Add("Englang");
            cbCountry.Items.Add("France");
            cbCountry.Items.Add("Norge");
        }

        private int fMyTag;

        [Category("Address Data")]
        [Description("Country")]
        [DefaultValue("")]
        [Browsable(true)]
        public int MyTag
        {
            get { return fMyTag; }
            set { fMyTag = value; }
        }

        [Category("Sub Address Data")]
        [Description("City")]
        [DefaultValue("")]
        [Browsable(true)]
        public TextBox MyCity
        {
            get { return tbCity; }
            set { tbCity = value; }
        }

        [Category("Address Data")]
        [Description("Address Line 1")]
        [DefaultValue("")]
        [Browsable(true)]        
        public string AddressLine1
        {
            get { return tbAddressLine1.Text; }
            set
            {
                if (tbAddressLine1.Text != value)
                {
                    tbAddressLine1.Text = value;
                    if (AddressLine1Changed != null)
                        AddressLine1Changed(this, EventArgs.Empty);
                }
            }
        }

        [Category("Address Data")]
        [Description("Address Line 2")]
        [DefaultValue("")]
        [Browsable(true)]
        public string AddressLine2
        {
            get { return tbAddressLine2.Text; }
            set
            {
                if (tbAddressLine2.Text != value)
                {
                    tbAddressLine2.Text = value;
                    if (AddressLine2Changed != null)
                        AddressLine2Changed(this, EventArgs.Empty);
                }
            }
        }

        [Category("Address Data")]
        [Description("City")]
        [DefaultValue("")]
        [Browsable(true)]
        public string City
        {
            get { return tbCity.Text; }
            set
            {
                if (tbCity.Text != value)
                {
                    tbCity.Text = value;
                    if (CityChanged != null)
                        CityChanged(this, EventArgs.Empty);
                }
            }
        }

        [Category("Address Data")]
        [Description("Zip Code (1000-9999")]
        [DefaultValue("")]
        [Browsable(true)]
        public int ZipCode
        {
            get { return Convert.ToInt32(nZipCode.Value); }
            set
            {
                if (nZipCode.Value != value)
                {
                    nZipCode.Value = value;
                    if (ZipCodeChanged != null)
                        ZipCodeChanged(this, EventArgs.Empty);
                }
            }
        }

        [Category("Address Data")]
        [Description("Country")]
        [DefaultValue("")]
        [Browsable(true)]
        public string Country
        {
            get { return cbCountry.Text; }
            set
            {
                if (cbCountry.Text != value)
                {
                    cbCountry.Text = value;
                    if (CountryChanged != null)
                        CountryChanged(this, EventArgs.Empty);
                }
            }
        }

        [Category("Address Data Changed")]
        public event EventHandler AddressLine1Changed;

        [Category("Address Data Changed")]
        public event EventHandler AddressLine2Changed;

        [Category("Address Data Changed")]
        public event EventHandler CityChanged;

        [Category("Address Data Changed")]
        public event EventHandler ZipCodeChanged;

        [Category("Address Data Changed")]
        public event EventHandler CountryChanged;
 
    }
}