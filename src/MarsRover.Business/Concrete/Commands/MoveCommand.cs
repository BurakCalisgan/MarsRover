using MarsRover.Business.Abstract;
using System;

namespace MarsRover.Business.Concrete.Commands
{
    public class MoveCommand : ICommand
    {
        IRover rover;

        public MoveCommand(IRover rover)
        {
            this.rover = rover;
        }

        public void Process()
        {
            this.rover.Move();
        }
    }
}
