namespace MarsRover.Core
{
    public record RoverPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public RoverDirection Direction { get; set; }

        public RoverPosition(int x, int y, RoverDirection direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}