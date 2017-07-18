﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OliverSnake
{
    class Body
    {
        public int width;
        public int height;
        public int x;
        public int y;
        public int speedX;
        public int speedY;
        public Brush brush;

        Rectangle hitbox;

        public Body(int width, int height, int x, int y, int speedX, int speedY, Brush brush)
        {
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
            this.speedX = speedX;
            this.speedY = speedY;
            this.brush = brush; 
        }

        public void update(Size ClientSize)
        {
            x += speedX;
            y += speedY;
        }

        public void draw(Graphics gfx)
        {
            gfx.FillRectangle(brush, x, y, width, height);
        }
    }
}
