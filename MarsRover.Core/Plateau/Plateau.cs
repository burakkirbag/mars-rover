using System.Collections.Generic;

namespace MarsRover.Core
{
    public class Plateau
    {
        public PlateauSize Size { get; private set; }
        public bool CheckInit { get; private set; }

        private List<Rover> _rovers;
        public IReadOnlyList<Rover> Rovers => _rovers.AsReadOnly();

        public Plateau()
        {
            _rovers = new List<Rover>();
        }

        public Plateau(int width, int height) : this()
        {
            CheckInit = true;
            Size = new PlateauSize(width, height);
        }

        public bool Initialize(string sizeInput)
        {
            CheckInit = false;
            if (!string.IsNullOrEmpty(sizeInput))
            {
                var plateauSize = sizeInput.Split(' ');
                if (plateauSize.Length == 2)
                {
                    if (int.TryParse(plateauSize[0], out var width))
                    {
                        if (int.TryParse(plateauSize[1], out var height))
                        {
                            Size = new PlateauSize(width, height);
                            CheckInit = true;
                        }
                    }
                }
            }

            return CheckInit;
        }
        
        public void AddRover(string positionInput, string commandInput)
        {
            var rover = new Rover();
            rover.Initialize(this, positionInput);
            rover.AddCommand(commandInput);
            _rovers.Add(rover);
        }

        public override string ToString()
        {
            return $"[Plateau Size] => Width : {Size.Width}, Height : {Size.Height}";
        }
    }
}