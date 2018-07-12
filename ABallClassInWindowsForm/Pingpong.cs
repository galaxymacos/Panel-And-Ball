using System;
using System.Drawing;

namespace ABallClassInWindowsForm
{
    public class Pingpong
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int HorizontalCoordinate { get; set; }
        public int VerticalCoordinate { get; set; }
        public int HorizontalSpeed { get; set; }
        public int VerticalSpeed { get; set; }
        public SolidBrush BackgroundColor { get; set; }

        Random random = new Random();

        public Pingpong()
        {
            Width = 20;
            Height = 20;
            HorizontalCoordinate = 0;
            VerticalCoordinate = 0;
            HorizontalSpeed = 2;
            VerticalSpeed = 2;
            BackgroundColor = new SolidBrush(Color.FromArgb(random.Next(0,255),random.Next(0,255),random.Next(0,255)));
        }

        public Pingpong(int width, int height, int horizontalCoordinate, int verticalCoordinate)
        {
            Width = width;
            Height = height;
            HorizontalCoordinate = horizontalCoordinate;
            VerticalCoordinate = verticalCoordinate;
        }
    }
}