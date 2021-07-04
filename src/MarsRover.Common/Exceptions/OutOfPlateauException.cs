using System;

namespace MarsRover.Common.Exceptions
{
    public class OutOfPlateauException : Exception
    {
        public int Plateau { get; set; }
        public int Actual { get; set; }
        public string Axis { get; set; }

        public OutOfPlateauException(int plateau, int actual, string axis)
           : base($"Out of plateau on axis {axis}. (plateau limit: {plateau}, Actual: {actual})")
        {
            Plateau = plateau;
            Actual = actual;
            Axis = axis;
        }
    }
}
