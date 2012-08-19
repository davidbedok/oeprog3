namespace WebServiceClient
{
    partial class WebServiceClientForm
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
            this.bTestConnection = new System.Windows.Forms.Button();
            this.tbPong = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvStoreItems = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbLoginname = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bGetList = new System.Windows.Forms.Button();
            this.pTestConnection = new System.Windows.Forms.Panel();
            this.lWelcome = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bBuy = new System.Windows.Forms.Button();
            this.cbItems = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.lResult = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoreItems)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            this.SuspendLayout();
            // 
            // bTestConnection
            // 
            this.bTestConnection.Location = new System.Drawing.Point(18, 24);
            this.bTestConnection.Name = "bTestConnection";
            this.bTestConnection.Size = new System.Drawing.Size(162, 23);
            this.bTestConnection.TabIndex = 0;
            this.bTestConnection.Text = "Test Connection";
            this.bTestConnection.UseVisualStyleBackColor = true;
            this.bTestConnection.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbPong
            // 
            this.tbPong.Enabled = false;
            this.tbPong.Location = new System.Drawing.Point(101, 53);
            this.tbPong.Name = "tbPong";
            this.tbPong.Size = new System.Drawing.Size(79, 20);
            this.tbPong.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvStoreItems);
            this.groupBox1.Location = new System.Drawing.Point(8, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 141);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Store";
            // 
            // dgvStoreItems
            // 
            this.dgvStoreItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStoreItems.Location = new System.Drawing.Point(18, 19);
            this.dgvStoreItems.Name = "dgvStoreItems";
            this.dgvStoreItems.ReadOnly = true;
            this.dgvStoreItems.Size = new System.Drawing.Size(564, 106);
            this.dgvStoreItems.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.bLogin);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbPassword);
            this.groupBox2.Controls.Add(this.tbLoginname);
            this.groupBox2.Location = new System.Drawing.Point(219, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 122);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 5;
            // 
            // bLogin
            // 
            this.bLogin.Enabled = false;
            this.bLogin.Location = new System.Drawing.Point(18, 76);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(162, 23);
            this.bLogin.TabIndex = 4;
            this.bLogin.Text = "Login";
            this.bLogin.UseVisualStyleBackColor = true;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Loginname";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(80, 50);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.Text = "alma";
            // 
            // tbLoginname
            // 
            this.tbLoginname.Location = new System.Drawing.Point(80, 28);
            this.tbLoginname.Name = "tbLoginname";
            this.tbLoginname.Size = new System.Drawing.Size(100, 20);
            this.tbLoginname.TabIndex = 0;
            this.tbLoginname.Text = "teszt";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bGetList);
            this.groupBox3.Controls.Add(this.pTestConnection);
            this.groupBox3.Controls.Add(this.tbPong);
            this.groupBox3.Controls.Add(this.bTestConnection);
            this.groupBox3.Location = new System.Drawing.Point(8, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(205, 122);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Test";
            // 
            // bGetList
            // 
            this.bGetList.Enabled = false;
            this.bGetList.Location = new System.Drawing.Point(18, 79);
            this.bGetList.Name = "bGetList";
            this.bGetList.Size = new System.Drawing.Size(162, 23);
            this.bGetList.TabIndex = 3;
            this.bGetList.Text = "Enter Store";
            this.bGetList.UseVisualStyleBackColor = true;
            this.bGetList.Click += new System.EventHandler(this.bGetList_Click);
            // 
            // pTestConnection
            // 
            this.pTestConnection.Location = new System.Drawing.Point(18, 53);
            this.pTestConnection.Name = "pTestConnection";
            this.pTestConnection.Size = new System.Drawing.Size(77, 20);
            this.pTestConnection.TabIndex = 2;
            // 
            // lWelcome
            // 
            this.lWelcome.AutoSize = true;
            this.lWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lWelcome.Location = new System.Drawing.Point(430, 27);
            this.lWelcome.Name = "lWelcome";
            this.lWelcome.Size = new System.Drawing.Size(82, 20);
            this.lWelcome.TabIndex = 6;
            this.lWelcome.Text = "Welcome";
            this.lWelcome.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lResult);
            this.groupBox4.Controls.Add(this.nudCount);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.cbItems);
            this.groupBox4.Controls.Add(this.bBuy);
            this.groupBox4.Location = new System.Drawing.Point(13, 289);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(599, 52);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " Buy";
            // 
            // bBuy
            // 
            this.bBuy.Enabled = false;
            this.bBuy.Location = new System.Drawing.Point(294, 17);
            this.bBuy.Name = "bBuy";
            this.bBuy.Size = new System.Drawing.Size(75, 23);
            this.bBuy.TabIndex = 0;
            this.bBuy.Text = "Buy";
            this.bBuy.UseVisualStyleBackColor = true;
            this.bBuy.Click += new System.EventHandler(this.bBuy_Click);
            // 
            // cbItems
            // 
            this.cbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItems.Enabled = false;
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Location = new System.Drawing.Point(115, 19);
            this.cbItems.Name = "cbItems";
            this.cbItems.Size = new System.Drawing.Size(121, 21);
            this.cbItems.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "product.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "count";
            // 
            // nudCount
            // 
            this.nudCount.Enabled = false;
            this.nudCount.Location = new System.Drawing.Point(13, 21);
            this.nudCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(56, 20);
            this.nudCount.TabIndex = 5;
            this.nudCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lResult
            // 
            this.lResult.AutoSize = true;
            this.lResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lResult.Location = new System.Drawing.Point(384, 18);
            this.lResult.Name = "lResult";
            this.lResult.Size = new System.Drawing.Size(54, 20);
            this.lResult.TabIndex = 6;
            this.lResult.Text = "result";
            this.lResult.Visible = false;
            // 
            // WebServiceClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 353);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lWelcome);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "WebServiceClientForm";
            this.Text = "WebService Client Application";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoreItems)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bTestConnection;
        private System.Windows.Forms.TextBox tbPong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbLoginname;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel pTestConnection;
        private System.Windows.Forms.DataGridView dgvStoreItems;
        private System.Windows.Forms.Button bGetList;
        private System.Windows.Forms.Label lWelcome;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbItems;
        private System.Windows.Forms.Button bBuy;
        private System.Windows.Forms.NumericUpDown nudCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lResult;
    }
}

