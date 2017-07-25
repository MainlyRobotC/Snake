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
        SnakePiece head;

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
            snakePieces.Add(new SnakePiece(50, 50, 500, 300, Brushes.Cyan));
            head = new SnakePiece(50, 50, 500, 300, Brushes.Cyan);

            food.newPos();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gfx.Clear(BackColor);
            for(int i = 0; i < head.Length; i++)
            {
                snakePieces[i].draw(gfx);
                snakePieces[i].update(ClientSize);
            }
            head.draw(gfx);
            head.update(ClientSize);
            food.draw(gfx);
            pictureBox1.Image = bitmap;

            if(head.Hitbox.IntersectsWith(food.hitbox))
            {
                head.Length++;
                food.newPos();
                label2.Text = $"Score = {head.Length}";
                if(head.Direction == 4)
                {
                    snakePieces.Add(new SnakePiece(50, 50, snakePieces[snakePieces.Count - 1].X - snakePieces[snakePieces.Count - 1].Width, snakePieces[snakePieces.Count - 1].Y, Brushes.Cyan));
                }
                if (head.Direction == 1)
                {
                    snakePieces.Add(new SnakePiece(50, 50, snakePieces[snakePieces.Count - 1].X + snakePieces[snakePieces.Count - 1].Width*2, snakePieces[snakePieces.Count - 1].Y, Brushes.Yellow));
                }
                if (head.Direction == 2)
                {
                    snakePieces.Add(new SnakePiece(50, 50, snakePieces[snakePieces.Count - 1].X, snakePieces[snakePieces.Count - 1].Y - snakePieces[snakePieces.Count - 1].Height, Brushes.Chartreuse));
                }
                if (head.Direction == 3)
                {
                    snakePieces.Add(new SnakePiece(50, 50, snakePieces[snakePieces.Count - 1].X, snakePieces[snakePieces.Count - 1].Y + snakePieces[snakePieces.Count - 1].Height*2, Brushes.Purple));
                }

                snakePieces[snakePieces.Count - 1].Direction = snakePieces[snakePieces.Count - 2].Direction;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && head.Direction != 4)
            {
                head.Direction = 1;
                for (int d1 = 0; d1 < head.Length; d1++)
                {
                    snakePieces[d1].Direction = 1;
                }
            }

            if (e.KeyCode == Keys.Up && head.Direction != 3)
            {             
                head.Direction = 2;
                for (int d2 = 0; d2 < head.Length; d2++)
                {
                    snakePieces[d2].Direction = 2;
                }
            }

            if (e.KeyCode == Keys.Down && head.Direction != 2)
            {             
                head.Direction = 3;
                for (int d3 = 0; d3 < head.Length; d3++)
                {
                    snakePieces[d3].Direction = 3;
                }
            }

            if (e.KeyCode == Keys.Right && head.Direction != 1)
            {
                head.Direction = 4;
                for (int d4 = 0; d4 < head.Length; d4++)
                {
                    snakePieces[d4].Direction = 4;
                }
            }

            if (head.X < 0 || head.X - head.Width > ClientSize.Width || head.Y < 0 || head.Y - head.Height > ClientSize.Height)
            {
                label1.Visible = true;
                label1.Text = "YOU LOSE! MWAHAHAHA";
                head.X = ClientSize.Width / 2;
                head.Y = ClientSize.Height / 2;
                head.Direction = 0;                     
                button1.Enabled = true;
                button1.Visible = true;
            }
            if(head.Length >= 20)
            {
                label1.Visible = true;
                label1.Text = "You Win!";
                head.X = ClientSize.Width / 2;
                head.Y = ClientSize.Height / 2;
                head.Direction = 0;
                button1.Enabled = true;
                button1.Visible = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Visible = false;
            head.Length = 0;
            label1.Visible = false;
        }
    }
}
