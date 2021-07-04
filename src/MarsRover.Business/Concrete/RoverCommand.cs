using MarsRover.Business.Abstract;
using System;
using System.Collections.Generic;

namespace MarsRover.Business.Concrete
{
    public class RoverCommand : IRoverCommand
    {
        public IRover Rover { get; set; }
        private Queue<ICommand> commands = new Queue<ICommand>();

        public RoverCommand(IRover rover)
        {
            this.Rover = rover;
        }

        public void AddCommand(ICommand command)
        {
            commands.Enqueue(command);
        }

        public void ProcessCommands()
        {
            while (commands.Count > 0)
            {
                ICommand command = commands.Dequeue();
                command.Process();
            }
        }
    }
}
