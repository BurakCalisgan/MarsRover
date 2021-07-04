using MarsRover.Business;
using MarsRover.Business.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Business.UnitTests
{
    public class BusinessTest
    {
        [Fact]
        public void TestScenario_12N_LMLMLMLMM()
        {
            var serviceProvider = DependencyInjection.Configure();
            var plateau = serviceProvider.GetService<IPlateau>();
            var rover = serviceProvider.GetService<IRover>();
            var roverCommandManager = serviceProvider.GetService<IRoverCommand>();

            //Plate Size Input: 5 5
            string plateauSize = "5 5";
            plateau.Initialize(plateauSize);

            //Rover Position Input: 1 2 N
            string roverPosition = "1 2 N";
            rover.Initialize(roverPosition);

            //Rover Command Input: LMLMLMLMM
            string roverCommandInput = "LMLMLMLMM";
            rover.CommandParse(roverCommandInput);
            rover.Plateau = plateau;

            plateau.Rovers.Add(rover);

            //Commands Execute
            roverCommandManager.Rover = rover;

            foreach (var roverCommand in rover.Commands)
            {
                roverCommandManager.AddCommand(roverCommand);
            }

            roverCommandManager.ProcessCommands();
            var actualOutput = $"{roverCommandManager.Rover.CurrentPosition.X} " + $"{roverCommandManager.Rover.CurrentPosition.Y} " + $"{roverCommandManager.Rover.CurrentPosition.Direction}";

            var expextedOutput = "1 3 N";

            Assert.Equal(expextedOutput, actualOutput);

        }

        [Fact]
        public void TestScenario_33E_MMRMMRMRRM()
        {
            var serviceProvider = DependencyInjection.Configure();
            var plateau = serviceProvider.GetService<IPlateau>();
            var rover = serviceProvider.GetService<IRover>();
            var roverCommandManager = serviceProvider.GetService<IRoverCommand>();

            //Plate Size Input: 5 5
            string plateauSize = "5 5";
            plateau.Initialize(plateauSize);

            //Rover Position Input: 3 3 E
            string roverPosition = "3 3 E";
            rover.Initialize(roverPosition);

            //Rover Command Input: LMLMLMLMM
            string roverCommandInput = "MMRMMRMRRM";
            rover.CommandParse(roverCommandInput);
            rover.Plateau = plateau;

            plateau.Rovers.Add(rover);

            //Commands Execute
            roverCommandManager.Rover = rover;

            foreach (var roverCommand in rover.Commands)
            {
                roverCommandManager.AddCommand(roverCommand);
            }

            roverCommandManager.ProcessCommands();
            var actualOutput = $"{roverCommandManager.Rover.CurrentPosition.X} " + $"{roverCommandManager.Rover.CurrentPosition.Y} " + $"{roverCommandManager.Rover.CurrentPosition.Direction}";

            var expextedOutput = "5 1 E";

            Assert.Equal(expextedOutput, actualOutput);

        }
    }
}
