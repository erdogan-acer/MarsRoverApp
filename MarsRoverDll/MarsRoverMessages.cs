using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverDll
{
    public class MarsRoverMessages
    {
        //General
        public const string ER_NULL_PARAMETER = "Null or Empty Parameter";

        //PLATEU MESSAGES

        public const string ER_PLATEAU_NULL_CONSTRUCTOR = "An Null Parameter in the Constructor";
        public const string ER_PLATEAU_BAD_PARAMETERS_IN_CONSTRUCTOR = "Incorrect parameter was given in the PLATEAU Constructor";

        //ROVER MESSAGES

        public const string ER_ROVER_MISSING_PARAMETERS_IN_NEWPOSITIONROVER = "Missing Parameter(s) in New Position Rover";
        public const string ER_ROVER_GREATER_THAN_PLATEU_LIMIT = "The given coordinate exceeds the limits.";

    }
}
