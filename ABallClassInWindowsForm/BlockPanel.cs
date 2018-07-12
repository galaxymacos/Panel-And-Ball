using System.Drawing;

namespace ABallClassInWindowsForm
{
    public class BlockPanel
    {
        public int HorizontalCoordinate { get; set; }
        public int VerticalCoordiante { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public SolidBrush BackgroundColor { get; set; }

        public BlockPanel()
        {
            
        }

        public BlockPanel(int horizontalCoordinate, int verticalCoordiante, int width, int height, SolidBrush backgroundColor)
        {
            HorizontalCoordinate = horizontalCoordinate;
            VerticalCoordiante = verticalCoordiante;
            Width = width;
            Height = height;
            BackgroundColor = backgroundColor;
        }
    }
}