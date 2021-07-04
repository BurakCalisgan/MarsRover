using System.Collections.Generic;

namespace MarsRover.Business.Abstract
{
    public interface IRover
    {
        IRoverPosition CurrentPosition { get; }
        IPlateau Plateau { get; set; }
        IList<ICommand> Commands { get; set; }
        bool Initialize(string roverPositionInput);
        void CommandParse(string roverCommandInput);
        void Move();
        void TurnRight();
        void TurnLeft();
    }
}
