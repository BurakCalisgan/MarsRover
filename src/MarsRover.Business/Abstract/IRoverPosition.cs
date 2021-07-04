using MarsRover.Common.Enums;

namespace MarsRover.Business.Abstract
{
    public interface IRoverPosition
    {
        int X { get; set; }
        int Y { get; set; }
        Directions Direction { get; set; }
    }
}
