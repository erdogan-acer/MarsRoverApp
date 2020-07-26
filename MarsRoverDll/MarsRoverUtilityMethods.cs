using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverDll
{
    public class MarsRoverUtilityMethods
    {
        public static string[] ParsingParameters(string param)
        {
            if (String.IsNullOrEmpty(param))
                throw new ArgumentNullException(MarsRoverMessages.ER_NULL_PARAMETER);
            string[] parseString = param.Split(' ');
            return parseString;
        }
        public static T ToEnum<T>(string @string)
        {
            if (string.IsNullOrEmpty(@string))
            {
                throw new ArgumentException(MarsRoverMessages.ER_NULL_PARAMETER);
            }
            return (T)Enum.Parse(typeof(T), @string);
        }
    }
}
