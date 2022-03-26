using System;
using System.Collections.Generic;

namespace MarsRover.Core
{
    public class Rover
    {
        public Plateau Plateau { get; private set; }
        public RoverPosition Position { get; private set; }

        private List<ICommand> _commands;
        public IReadOnlyList<ICommand> Commands => _commands.AsReadOnly();

        public Rover()
        {
            _commands = new List<ICommand>();
        }

        public Rover(Plateau plateau, RoverPosition position) : this()
        {
            Plateau = plateau;
            Position = position;
        }

        public bool Initialize(Plateau plateau, string positionInput)
        {
            Plateau = plateau;
            
            if (!string.IsNullOrEmpty(positionInput))
            {
                var roverPosition = positionInput.Split(' ');
                if (roverPosition.Length == 3)
                {
                    try
                    {
                        var x = int.Parse(roverPosition[0]);
                        var y = int.Parse(roverPosition[1]);
                        var direction = roverPosition[2].ToUpper();

                        if (direction.Equals("N", StringComparison.InvariantCultureIgnoreCase) ||
                            direction.Equals("S", StringComparison.InvariantCultureIgnoreCase) ||
                            direction.Equals("E", StringComparison.InvariantCultureIgnoreCase) ||
                            direction.Equals("W", StringComparison.InvariantCultureIgnoreCase))
                        {
                            Position = new RoverPosition(x, y, Enum.Parse<RoverDirection>(direction));
                            return true;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            return false;
        }

        public void TurnLeft()
        {
            Position.Direction = Position.Direction - 1 < RoverDirection.N ? RoverDirection.W : Position.Direction - 1;
        }

        public void TurnRight()
        {
            Position.Direction = Position.Direction + 1 > RoverDirection.W ? RoverDirection.N : Position.Direction + 1;
        }

        public void Move()
        {
            switch (Position.Direction)
            {
                case RoverDirection.N:
                    Position.Y++;
                    break;
                case RoverDirection.E:
                    Position.X++;
                    break;
                case RoverDirection.S:
                    Position.Y--;
                    break;
                case RoverDirection.W:
                    Position.X--;
                    break;
                default:
                    throw new InvalidRoverDirectionException();
            }

            CheckIfInsideBoundaries();
        }

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public void AddCommand(string commandInput)
        {
            CommandParse(commandInput);
        }

        private void CheckIfInsideBoundaries()
        {
            if (Position.X > Plateau.Size.Width ||
                Position.X < 0 ||
                Position.Y > Plateau.Size.Height ||
                Position.Y < 0)
            {
                throw new RoverOutOfBoundaryException();
            }
        }
        
        private void CommandParse(string commandInput)
        {
            foreach (var letter in commandInput.ToCharArray())
            {
                switch (char.ToUpper(letter))
                {
                    case 'L':
                        _commands.Add(new TurnLeftCommand(this));
                        break;
                    case 'R':
                        _commands.Add(new TurnRightCommand(this));
                        break;
                    case 'M':
                        _commands.Add(new MoveCommand(this));
                        break;
                    default:
                        throw new InvalidRoverCommandException();
                }
            }
        }
    }
}