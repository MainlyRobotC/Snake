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
        public int width;
        public int height;
        public int x;
        public int y;
        public Brush brush;

        Rectangle hitbox;
        public Food(int width, int height, int x, int y, Brush brush)
        {
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
            this.brush = brush;
        }

        public void draw(Graphics gfx)
        {
            gfx.FillRectangle(brush, x, y, width, height);
        }
    }
}
