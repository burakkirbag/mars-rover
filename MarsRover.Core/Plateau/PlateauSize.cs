namespace MarsRover.Core
{
    public record PlateauSize
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public PlateauSize(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}