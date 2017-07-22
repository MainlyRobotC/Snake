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
        public int width;
        public int height;
        public int x;
        public int y;
        public int speedX;
        public int speedY;
        public Brush brush;
        public int length;

        public Rectangle hitbox;

        public SnakePiece(int width, int height, int x, int y, int speedX, int speedY, Brush brush)
        {
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
            this.speedX = speedX;
            this.speedY = speedY;
            this.brush = brush; 
            hitbox = new Rectangle(x,y,width,height);
        }

        public void update(Size ClientSize)
        {
            x += speedX;
            y += speedY;

            hitbox.X = x;
            hitbox.Y = y;
        }

        public void draw(Graphics gfx)
        {
            gfx.FillRectangle(brush, x, y, width, height);
        }
    }
}
