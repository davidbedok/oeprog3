﻿namespace UserAddressLineTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addressData1 = new UserAddressLine.AddressData();
            this.addressData2 = new UserAddressLine.AddressData();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addressData1
            // 
            this.addressData1.Location = new System.Drawing.Point(12, 12);
            this.addressData1.MyTag = 0;
            this.addressData1.Name = "addressData1";
            this.addressData1.Size = new System.Drawing.Size(341, 137);
            this.addressData1.TabIndex = 0;
            this.addressData1.ZipCode = 1000;
            this.addressData1.AddressLine1Changed += new System.EventHandler(this.addressData1_AddressLine1Changed);
            this.addressData1.AddressLine2Changed += new System.EventHandler(this.addressData1_AddressLine2Changed);
            this.addressData1.ZipCodeChanged += new System.EventHandler(this.addressData1_ZipCodeChanged);
            this.addressData1.CityChanged += new System.EventHandler(this.addressData1_CityChanged);
            this.addressData1.CountryChanged += new System.EventHandler(this.addressData1_CountryChanged);
            // 
            // addressData2
            // 
            this.addressData2.Location = new System.Drawing.Point(13, 155);
            this.addressData2.MyTag = 0;
            this.addressData2.Name = "addressData2";
            this.addressData2.Size = new System.Drawing.Size(341, 137);
            this.addressData2.TabIndex = 1;
            this.addressData2.ZipCode = 1000;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 347);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addressData2);
            this.Controls.Add(this.addressData1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserAddressLine.AddressData addressData1;
        private UserAddressLine.AddressData addressData2;
        private System.Windows.Forms.Button button1;
    }
}

