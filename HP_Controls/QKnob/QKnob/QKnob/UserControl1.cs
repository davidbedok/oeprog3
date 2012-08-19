using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QKnob
{
    public partial class UserControl1 : UserControl
    {
        private float imgHW = 200;        
        private float centerR = 20;
        private int angle = 0;
        private double angleRad = 0;
        private int mouseX = 0;
        private int mouseY = 0;
        private float bitmapX = 0;
        private float bitmapY = 0;
        private float scaleX = 0;
        private float scaleY = 0;
        private float origoX = 0;
        private float origoY = 0;

        [Browsable(true)]
        [Category("Knob")]
        [Description("Angle of Knob")]
        public int Angle
        {
            get { return angle; }
            set { 
                  angle = value;
                  angleRad = Math.PI / 180 * value;
            }
        }

        public double getAngleRad()
        {
            return angleRad;
        }

        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap((int)imgHW, (int)imgHW);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox1_Click(this,e);
            
            scaleX = imgHW / pictureBox1.Size.Width;
            scaleY = imgHW / pictureBox1.Size.Height;
            origoX = imgHW / 2;
            origoY = imgHW / 2;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);
            float temp = (imgHW - 2 * centerR) / 2;
            Pen iPen = new Pen(Color.FromArgb(255, 0, 0, 0), 6);
            Pen iPenE = new Pen(Color.FromArgb(255, 0, 0, 0), 2);
            iPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            iPenE.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            iPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawEllipse(iPenE, temp, temp, 2 * centerR, 2 * centerR);
            g.DrawLine(iPen, origoX, origoY, bitmapX, bitmapY);
            g.Dispose();            
            pictureBox1.Invalidate();
            if ((origoY - bitmapY) != 0)
            {
                angleRad = Math.Tan((bitmapX - origoX) / (origoY - bitmapY));
                angle = Convert.ToInt32(180 * angleRad / Math.PI);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            bitmapX = scaleX * mouseX;
            bitmapY = scaleY * mouseY;
            lCoord.Text = mouseX + ":" + mouseY + " ("+(int)bitmapX+":"+(int)bitmapY+")";
        }

        
    }
}
