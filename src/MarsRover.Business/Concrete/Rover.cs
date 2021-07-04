using MarsRover.Business.Abstract;
using MarsRover.Business.Concrete.Commands;
using MarsRover.Common.Constants;
using MarsRover.Common.Enums;
using MarsRover.Common.Exceptions;
using System;
using System.Collections.Generic;

namespace MarsRover.Business.Concrete
{
    public class Rover : IRover
    {
        public IRoverPosition CurrentPosition { get; private set; }

        public IPlateau Plateau { get; set; }
        public IList<ICommand> Commands { get; set; }

        public Rover()
        {
            this.Commands = new List<ICommand>();
        }

        public Rover(IRoverPosition roverPosition, IPlateau plateau)
        {
            this.CurrentPosition = roverPosition;
            this.Plateau = plateau;
            this.Commands = new List<ICommand>();
        }

        public void CommandParse(string roverCommandInput)
        {
            foreach (var letter in roverCommandInput.ToCharArray())
            {
                switch (char.ToUpper(letter))
                {
                    case CommandConstants.L:
                        this.Commands.Add(new TurnLeftCommand(this));
                        break;
                    case CommandConstants.R:
                        this.Commands.Add(new TurnRightCommand(this));
                        break;
                    case CommandConstants.M:
                        this.Commands.Add(new MoveCommand(this));
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        public bool Initialize(string roverPositionInput)
        {
            var roverPosition = roverPositionInput.Split(' ');
            if (roverPosition.Length == 3)
            {
                try
                {
                    var x = int.Parse(roverPosition[0]);
                    var y = int.Parse(roverPosition[1]);

                    var direction = roverPosition[2].ToUpper();
                    if (direction == DirectionsConstants.N || direction == DirectionsConstants.S || direction == DirectionsConstants.E || direction == DirectionsConstants.W)
                    {
                        this.CurrentPosition.Direction = (Directions)Enum.Parse(typeof(Directions), direction);
                        this.CurrentPosition.X = x;
                        this.CurrentPosition.Y = y;
                        return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        public void Move()
        {
            CheckRoverIsAtValidGridBoundaries();
            this.CurrentPosition = RoverAction.Move(this.CurrentPosition);
        }

        public void TurnLeft()
        {
            this.CurrentPosition.Direction = RoverAction.TurnLeft(this.CurrentPosition.Direction);
        }

        public void TurnRight()
        {
            this.CurrentPosition.Direction = RoverAction.TurnRight(this.CurrentPosition.Direction);
        }

        /// <summary>
        /// Check rover is at the valid grid boundaries
        /// </summary>
        private void CheckRoverIsAtValidGridBoundaries()
        {
            var currentRoverPosition = this.CurrentPosition;

            if (currentRoverPosition.X > this.Plateau.PlateauX || currentRoverPosition.X < 0)
            {
                throw new OutOfPlateauException(this.Plateau.PlateauX, currentRoverPosition.X, "X");
            }

            if (currentRoverPosition.Y > this.Plateau.PlateauY || currentRoverPosition.Y < 0)
            {
                throw new OutOfPlateauException(this.Plateau.PlateauY, currentRoverPosition.Y, "Y");
            }
        }
    }
}
