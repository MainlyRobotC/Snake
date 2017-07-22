using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OliverSnake
{
    class Food
    {
        Random xy;
        public int width;
        public int height;
        public int x;
        public int y;
        public Brush brush;

        public Rectangle hitbox;
        public Food(int width, int height, int x, int y, Brush brush)
        {
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
            this.brush = brush;
            hitbox = new Rectangle(x, y, width, height);
        }

        public void newPos()
        {
            xy = new Random();

            x = (xy.Next(1, 10)) * 100;
            y = (xy.Next(1, 10)) * 60;

            hitbox.X = x;
            hitbox.Y = y;
        }

        public void draw(Graphics gfx)
        {
            gfx.FillRectangle(brush, x, y, width, height);
        }
    }
}
