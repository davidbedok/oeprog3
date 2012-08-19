namespace QListBoxMulti
{
    partial class QListBoxUC
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbLeft = new System.Windows.Forms.ListBox();
            this.lbRight = new System.Windows.Forms.ListBox();
            this.bMoveSelectedToRight = new System.Windows.Forms.Button();
            this.bMoveAllToRight = new System.Windows.Forms.Button();
            this.bMoveSelectedToLeft = new System.Windows.Forms.Button();
            this.bMoveAllToLeft = new System.Windows.Forms.Button();
            this.tbLeft = new System.Windows.Forms.TextBox();
            this.tbRight = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbLeft
            // 
            this.lbLeft.FormattingEnabled = true;
            this.lbLeft.Location = new System.Drawing.Point(5, 29);
            this.lbLeft.Name = "lbLeft";
            this.lbLeft.Size = new System.Drawing.Size(98, 147);
            this.lbLeft.TabIndex = 0;
            // 
            // lbRight
            // 
            this.lbRight.FormattingEnabled = true;
            this.lbRight.Location = new System.Drawing.Point(190, 29);
            this.lbRight.Name = "lbRight";
            this.lbRight.Size = new System.Drawing.Size(98, 147);
            this.lbRight.TabIndex = 1;
            // 
            // bMoveSelectedToRight
            // 
            this.bMoveSelectedToRight.Location = new System.Drawing.Point(109, 29);
            this.bMoveSelectedToRight.Name = "bMoveSelectedToRight";
            this.bMoveSelectedToRight.Size = new System.Drawing.Size(75, 23);
            this.bMoveSelectedToRight.TabIndex = 2;
            this.bMoveSelectedToRight.Text = ">";
            this.bMoveSelectedToRight.UseVisualStyleBackColor = true;
            this.bMoveSelectedToRight.Click += new System.EventHandler(this.bMoveSelectedToRight_Click);
            // 
            // bMoveAllToRight
            // 
            this.bMoveAllToRight.Location = new System.Drawing.Point(109, 58);
            this.bMoveAllToRight.Name = "bMoveAllToRight";
            this.bMoveAllToRight.Size = new System.Drawing.Size(75, 23);
            this.bMoveAllToRight.TabIndex = 3;
            this.bMoveAllToRight.Text = ">>";
            this.bMoveAllToRight.UseVisualStyleBackColor = true;
            this.bMoveAllToRight.Click += new System.EventHandler(this.bMoveAllToRight_Click);
            // 
            // bMoveSelectedToLeft
            // 
            this.bMoveSelectedToLeft.Location = new System.Drawing.Point(109, 87);
            this.bMoveSelectedToLeft.Name = "bMoveSelectedToLeft";
            this.bMoveSelectedToLeft.Size = new System.Drawing.Size(75, 23);
            this.bMoveSelectedToLeft.TabIndex = 4;
            this.bMoveSelectedToLeft.Text = "<";
            this.bMoveSelectedToLeft.UseVisualStyleBackColor = true;
            this.bMoveSelectedToLeft.Click += new System.EventHandler(this.bMoveSelectedToLeft_Click);
            // 
            // bMoveAllToLeft
            // 
            this.bMoveAllToLeft.Location = new System.Drawing.Point(109, 116);
            this.bMoveAllToLeft.Name = "bMoveAllToLeft";
            this.bMoveAllToLeft.Size = new System.Drawing.Size(75, 23);
            this.bMoveAllToLeft.TabIndex = 5;
            this.bMoveAllToLeft.Text = "<<";
            this.bMoveAllToLeft.UseVisualStyleBackColor = true;
            this.bMoveAllToLeft.Click += new System.EventHandler(this.bMoveAllToLeft_Click);
            // 
            // tbLeft
            // 
            this.tbLeft.Location = new System.Drawing.Point(3, 3);
            this.tbLeft.Name = "tbLeft";
            this.tbLeft.Size = new System.Drawing.Size(100, 20);
            this.tbLeft.TabIndex = 6;
            this.tbLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tbRight
            // 
            this.tbRight.Location = new System.Drawing.Point(187, 3);
            this.tbRight.Name = "tbRight";
            this.tbRight.Size = new System.Drawing.Size(100, 20);
            this.tbRight.TabIndex = 7;
            this.tbRight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRight_KeyPress);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbRight);
            this.Controls.Add(this.tbLeft);
            this.Controls.Add(this.bMoveAllToLeft);
            this.Controls.Add(this.bMoveSelectedToLeft);
            this.Controls.Add(this.bMoveAllToRight);
            this.Controls.Add(this.bMoveSelectedToRight);
            this.Controls.Add(this.lbRight);
            this.Controls.Add(this.lbLeft);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(294, 183);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbLeft;
        private System.Windows.Forms.ListBox lbRight;
        private System.Windows.Forms.Button bMoveSelectedToRight;
        private System.Windows.Forms.Button bMoveAllToRight;
        private System.Windows.Forms.Button bMoveSelectedToLeft;
        private System.Windows.Forms.Button bMoveAllToLeft;
        private System.Windows.Forms.TextBox tbLeft;
        private System.Windows.Forms.TextBox tbRight;
    }
}
