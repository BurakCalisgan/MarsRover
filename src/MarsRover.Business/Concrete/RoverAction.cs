using MarsRover.Business.Abstract;
using MarsRover.Common.Enums;
using System;

namespace MarsRover.Business.Concrete
{
    public class RoverAction
    {
        public static IRoverPosition Move(IRoverPosition roverPosition)
        {

            return roverPosition.Direction switch
            {
                Directions.N => new RoverPosition(roverPosition.Direction, roverPosition.X, roverPosition.Y + 1),
                Directions.S => new RoverPosition(roverPosition.Direction, roverPosition.X, roverPosition.Y - 1),
                Directions.W => new RoverPosition(roverPosition.Direction, roverPosition.X - 1, roverPosition.Y),
                Directions.E => new RoverPosition(roverPosition.Direction, roverPosition.X + 1, roverPosition.Y),
                _ => throw new InvalidOperationException(),
            };
        }

        public static Directions TurnRight(Directions roverDirection)
        {
            return roverDirection switch
            {
                Directions.N => Directions.E,
                Directions.E => Directions.S,
                Directions.S => Directions.W,
                Directions.W => Directions.N,
                _ => throw new InvalidOperationException(),
            };
        }

        public static Directions TurnLeft(Directions roverDirection)
        {
            return roverDirection switch
            {
                Directions.N => Directions.W,
                Directions.E => Directions.N,
                Directions.S => Directions.E,
                Directions.W => Directions.S,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
