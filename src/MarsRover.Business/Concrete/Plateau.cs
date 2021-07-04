using MarsRover.Business.Abstract;
using System.Collections.Generic;

namespace MarsRover.Business.Concrete
{
    public class Plateau : IPlateau
    {
        public int PlateauX { get; set; }
        public int PlateauY { get; set; }
        public bool CheckInit { get; private set; }
        public IList<IRover> Rovers { get; set; }
        
        public Plateau()
        {
            Rovers = new List<IRover>();
        }

        public Plateau(int plateauX, int plateauY)
        {
            PlateauX = plateauX;
            PlateauY = plateauY;
        }

        public bool Initialize(string gridInitializeInput)
        {
            this.CheckInit = false;
            if (!string.IsNullOrWhiteSpace(gridInitializeInput))
            {
                var gridSize = gridInitializeInput.Split(' ');

                if (gridSize.Length == 2)
                {
                    if (int.TryParse(gridSize[0], out int plateauX))
                    {
                        if (int.TryParse(gridSize[1], out int plateauY))
                        {
                            this.PlateauX = plateauX;
                            this.PlateauY = plateauY;
                            this.CheckInit = true;
                        }
                    }

                }
            }
            return this.CheckInit;
        }
    }
}
