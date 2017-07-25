using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OliverSnake
{
    class SnakePiece
    {
        public int Width;
        public int Height;
        public int X;
        public int Y;
        public Brush Brush;
        public int Length;
        private int direction;

        public Rectangle Hitbox
        {
            get { return new Rectangle(X, Y, Width, Height); }
        }

        public int Direction
        {
            get
            {
                return direction;
            }

            set
            {
                direction = value;
            }
        }

        public SnakePiece(int width, int height, int x, int y, Brush brush)
        {
            this.Width = width;
            this.Height = height;
            this.X = x;
            this.Y = y;
            this.Brush = brush;          
        }

        public void update(Size ClientSize)
        {
            if (direction == 1)
            {
                X -= Width;
            }

            if (direction == 2)
            {
                Y -= Height;
            }

            if (direction == 3)
            {
                Y += Height;
            }

            if (direction == 4)
            {
                X += Width;
            }
        }

        public void draw(Graphics gfx)
        {
            gfx.FillRectangle(Brush, X, Y, Width, Height);
        }
    }
}
