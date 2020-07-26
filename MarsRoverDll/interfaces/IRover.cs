using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverDll.interfaces
{
    public interface IRover
    {
        int Coordinate_X { get; set; }
        int Coordinate_Y { get; set; }
        char Direction { get; set; }
    }
}
