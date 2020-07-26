using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverDll
{
    public class MarsRoverEnums
    {
        public enum ControlOfRover
        {
            TurnLeft = 'L',
            TurnRight = 'R',
            MoveForward = 'M'
        }
        public enum DirectionsOfRover
        {
            North = 'N',
            East = 'E',
            South = 'S',
            West = 'W'
        }
    }
}
