using MarsRover.Core;

namespace MarsRover.Core
{
    public interface ICommandManager
    {
        void Add(ICommand command);
        void Execute();
    }
}