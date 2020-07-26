using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverDll
{
    public class Plateau
    {
        private readonly int _Coordinate_X;
        private readonly int _Coordinate_Y;
        public Plateau(string size)
        {
            try
            {
                string[] _size = MarsRoverUtilityMethods.ParsingParameters(size);
                if ((!int.TryParse(_size[0], out _Coordinate_X)) || (!int.TryParse(_size[1], out _Coordinate_Y)))
                    throw new ArgumentNullException(MarsRoverMessages.ER_PLATEAU_BAD_PARAMETERS_IN_CONSTRUCTOR);
            }
            catch (Exception e)
            {
                throw ;
            }
        }
        public int GetXCoordinate()
        {
            return this._Coordinate_X;
        }
        public int GetYCoordinate()
        {
            return this._Coordinate_Y;
        }
    }
}
