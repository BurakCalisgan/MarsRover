using MarsRover.Business;
using MarsRover.Business.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = DependencyInjection.Configure();
            
            //
            var plateau = serviceProvider.GetService<IPlateau>();

            while (!plateau.CheckInit)
            {
                Console.WriteLine("Plateau size :");
                var plateauSizeInput = Console.ReadLine();
                Console.WriteLine(plateau.Initialize(plateauSizeInput));
            }

            var isAnotherRover = true;

            while (isAnotherRover)
            {
                Console.WriteLine("Rover position :");
                var roverPositionInput = Console.ReadLine();
                Console.WriteLine("Rover command :");
                var roverCommandInput = Console.ReadLine();

                var rover = serviceProvider.GetService<IRover>();
                if (rover.Initialize(roverPositionInput))
                {
                    rover.Plateau = plateau;
                    rover.CommandParse(roverCommandInput);
                    plateau.Rovers.Add(rover);
                }

                Console.WriteLine("Do you want to deploy another rover ? (Y)");
                var addAnotherRoverInput = Console.ReadLine();
                if (addAnotherRoverInput.ToUpper() != "Y")
                {
                    isAnotherRover = false;
                }
            }

            Console.WriteLine("Expected Output :");
            foreach (var rover in plateau.Rovers)
            {
                var roverCommandManager = serviceProvider.GetService<IRoverCommand>();
                roverCommandManager.Rover = rover;

                foreach (var roverCommand in rover.Commands)
                {
                    roverCommandManager.AddCommand(roverCommand);
                }

                roverCommandManager.ProcessCommands();

                Console.WriteLine($"{roverCommandManager.Rover.CurrentPosition.X} " + $"{roverCommandManager.Rover.CurrentPosition.Y} " + $"{roverCommandManager.Rover.CurrentPosition.Direction}");

                Console.ReadKey();
            }
        }
    }
}
