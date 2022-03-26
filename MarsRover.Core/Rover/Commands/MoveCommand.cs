namespace MarsRover.Core
{
    public class MoveCommand: ICommand
    {
        private readonly Rover _rover;

        public MoveCommand(Rover rover)
        {
            _rover = rover;
        }
        
        public void Execute()
        {
            _rover.Move();
        }
    }
}