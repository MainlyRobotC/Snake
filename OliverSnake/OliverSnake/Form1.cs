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

        List<SnakePiece> snakePieces;
        Graphics gfx;
        Bitmap bitmap;
        Food food;
        SnakePiece body;

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            gfx = Graphics.FromImage(bitmap);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = bitmap;
            food = new Food(30, 30, 0, 0, Brushes.Red);
            snakePieces = new List<SnakePiece>();
            snakePieces.Add(new SnakePiece(50, 50, 500, 300, 0, 0, Brushes.Cyan));

            food.newPos();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gfx.Clear(BackColor);
            body.draw(gfx);
            body.update(ClientSize);
            food.draw(gfx);
            pictureBox1.Image = bitmap;

            if(body.hitbox.IntersectsWith(food.hitbox))
            {
                body.length++;
                food.newPos();
                label2.Text = $"Score = {body.length}";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                body.speedX = -50;
                body.speedY = 0;
            }

            if (e.KeyCode == Keys.Up)
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

            if (body.x < 0 || body.x - body.width > ClientSize.Width || body.y < 0 || body.y - body.height > ClientSize.Height)
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
