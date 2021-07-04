using System.Collections.Generic;

namespace MarsRover.Business.Abstract
{
    public interface IPlateau
    {
        int PlateauX { get; set; }
        int PlateauY { get; set; }
        bool CheckInit { get; }
        bool Initialize(string gridInitializeInput);
        IList<IRover> Rovers { get; set; }
    }
}
