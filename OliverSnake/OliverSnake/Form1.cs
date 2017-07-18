using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OliverSnake
{
    public partial class Form1 : Form
    {
        Graphics gfx;
        Bitmap bitmap;

        Body body = new Body(50, 50, 500, 300, 0, 0, Brushes.Cyan);
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            gfx = Graphics.FromImage(bitmap);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = bitmap;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gfx.Clear(BackColor);
            body.draw(gfx);
            body.update(ClientSize);
            pictureBox1.Image = bitmap;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                body.speedX = -50;
                body.speedY = 0;
            }

            if(e.KeyCode == Keys.Up)
            {
                body.speedX = 0;
                body.speedY = -50;
            }

            if (e.KeyCode == Keys.Down)
            {
                body.speedX = 0;
                body.speedY = 50;
            }

            if (e.KeyCode == Keys.Right)
            {
                body.speedX = 50;
                body.speedY = 0;
            }

            if(body.x < 0 || body.x - body.width > ClientSize.Width || body.y < 0 || body.y - body.height > ClientSize.Height)
            {
                label1.Text = "YOU LOSE! MWAHAHAHA";
                body.x = ClientSize.Width / 2;
                body.y = ClientSize.Height / 2;
                body.speedX = 0;
                body.speedY = 0;
            }
        }
    }
}
