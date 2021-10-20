using System;

namespace classes
{
    class Rect
    {
        private int width;
        private int height;
        public Point point;

        public Rect(int width, int height, Point point)
        {
            if (width <= 0 || height <= 0)
                throw new Exception("Width and Height must be bigger then 0");
            this.point = point;
        }

        public int GetArea()
        {
            return width * height;
        }

        public int GetPerimeter()
        {
            return width * 2 + height * 2;
        }

        public void Move (int offset)
        {
            point.x += offset;
            point.y += offset;
        } 
        
    }
}