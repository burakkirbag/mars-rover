using System.Collections.Generic;

namespace MarsRover.Core
{
    public class RoverCommandManager : ICommandManager
    {
        private readonly Queue<ICommand> _queue;
        private readonly Rover _rover;

        public Rover Rover => _rover;

        public RoverCommandManager(Rover rover)
        {
            _rover = rover;
            _queue = new Queue<ICommand>();
            foreach (var command in _rover.Commands)
            {
                Add(command);
            }
        }
        
        public void Add(ICommand command)
        {
            _queue.Enqueue(command);
        }

        public void Execute()
        {
            if(_queue is not {Count: > 0}) return;

            while (_queue.Count > 0)
            {
                var command = _queue.Dequeue();
                command.Execute();
            }
        }
    }
}