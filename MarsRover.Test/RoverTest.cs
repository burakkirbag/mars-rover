using MarsRover.Core;
using Xunit;

namespace MarsRover.Test
{
    public class RoverTest
    {
            [Theory]
            [InlineData(new object[] { "5 5", "1 2 N", "LMLMLMLMM", 1, 3, RoverDirection.N })]
            [InlineData(new object[] { "5 5", "3 3 E", "MMRMMRMRRM", 5, 1, RoverDirection.E })]
            public void GeneratePlateauAndMoveRover(
                string plateauSize,
                string roverPosition,
                string roverCommands, 
                int expectedX, 
                int expectedY, 
                RoverDirection expectedDirection)
            {
                var plateau = new Plateau();
                plateau.Initialize(plateauSize);

                var rover = new Rover();
                rover.Initialize(plateau, roverPosition);
                rover.AddCommand(roverCommands);
                
                var commandManager = new RoverCommandManager(rover);
                commandManager.Execute();
                
                Assert.NotNull(rover);
                Assert.NotNull(rover.Position);
                Assert.Equal(expectedX, rover.Position.X);
                Assert.Equal(expectedY, rover.Position.Y);
                Assert.Equal(expectedDirection, rover.Position.Direction);
            }
        }
}