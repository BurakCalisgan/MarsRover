using MarsRover.Business.Abstract;

namespace MarsRover.Business.Concrete.Commands
{
    public class TurnRightCommand : ICommand
    {
        IRover rover;

        public TurnRightCommand(IRover rover)
        {
            this.rover = rover;
        }

        public void Process()
        {
            this.rover.TurnRight();
        }
    }
}
