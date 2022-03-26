using System;
using MarsRover.Core;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                Console.Clear();
                
                ExceptionHandler.Handle(ex);
                
                Run();
            }
        }

        static void Run()
        {
            Console.WriteLine("Test Input :");

            var plateau = new Plateau();
            while (!plateau.CheckInit)
            {
                Console.WriteLine("Plateau size :");
                var sizeInput = Console.ReadLine();
                plateau.Initialize(sizeInput);
            }

            while (true)
            {
                Console.WriteLine("Rover position :");
                var roverPositionInput = Console.ReadLine();

                Console.WriteLine("Rover command :");
                var roverCommandInput = Console.ReadLine();

                plateau.AddRover(roverPositionInput, roverCommandInput);

                Console.WriteLine("Do you want to add another rover ? (Y/N)");
                var addAnotherRoverInput = Console.ReadLine();
                if (addAnotherRoverInput.ToUpper() != "Y")
                {
                    break;
                }
            }

            Console.WriteLine("Expected Output :");
            foreach (var rover in plateau.Rovers)
            {
                var commandManager = new RoverCommandManager(rover);
                commandManager.Execute();

                Console.WriteLine($"{commandManager.Rover.Position.X} " +
                                  $"{commandManager.Rover.Position.Y} " +
                                  $"{commandManager.Rover.Position.Direction.ToString()}");
            }
        }
    }
}