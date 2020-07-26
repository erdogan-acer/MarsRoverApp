using MarsRoverDll.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverDll
{
    public class Rover : IRover
    {
        private readonly Plateau _plateau;
        public int Coordinate_X { get; set; }
        public int Coordinate_Y { get; set; }
        public char Direction { get; set; }

        public Rover(Plateau plateau)
        {
            this._plateau = plateau;
        }

        /// <summary>
        /// Gönderilen Parametreye göre uygun konuma gelir.
        /// </summary>
        /// <param name="newPosition"> "1 2 N"</param>
        public void NewPositionRover(string newPosition)
        {
            string[] _newPosition = MarsRoverUtilityMethods.ParsingParameters(newPosition);
            if (_newPosition.Count() != 3)
                throw new ArgumentNullException(MarsRoverMessages.ER_ROVER_MISSING_PARAMETERS_IN_NEWPOSITIONROVER);
            Check_NewPositionRover(_newPosition);
        }

        /// <summary>
        /// Gönderilen komut ile, rover'in keşif yapılmasını sağlıyoruz
        /// </summary>
        /// <param name="commands">"LMLMLMLMM"</param>
        public void CommandsOnRover(string commands)
        {
            if (String.IsNullOrEmpty(commands))
                throw new ArgumentNullException(MarsRoverMessages.ER_NULL_PARAMETER);

            char[] _commands = commands.ToCharArray();

            foreach (char command in _commands)
            {
                switch (command)
                {
                    case (char)MarsRoverEnums.ControlOfRover.MoveForward:
                        this.RoverMoveForward();
                        break;
                    case (char)MarsRoverEnums.ControlOfRover.TurnLeft:
                        this.TurnRover(command);
                        break;
                    case (char)MarsRoverEnums.ControlOfRover.TurnRight:
                        this.TurnRover(command);
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        /// <summary>
        /// Gönderilen Komutlara Uygun, Hareketleri Gerçekleştirir.
        /// Yön bilgisi atanan this.Direction sayesinde, hangi yöne ilerleneceği belirlenir.
        /// </summary>
        /// <param>this.Direction</param>
        private void RoverMoveForward()
        {
            switch (this.Direction)
            {
                case (char)MarsRoverEnums.DirectionsOfRover.North:
                    this.Coordinate_Y += 1;
                    break;
                case (char)MarsRoverEnums.DirectionsOfRover.South:
                    this.Coordinate_Y -= 1;
                    break;

                case (char)MarsRoverEnums.DirectionsOfRover.East:
                    this.Coordinate_X += 1;
                    break;
                case (char)MarsRoverEnums.DirectionsOfRover.West:
                    this.Coordinate_X -= 1;
                    break;
            }
        }
        /// <summary>
        /// Gönderilen Sağ-Sol komutuna göre, hangi yöne dönüleceği method'ları çağırıyoruz.
        /// </summary>
        /// <param name="directionCommand"></param>
        private void TurnRover(char directionCommand)
        {
            switch (directionCommand)
            {
                case (char)MarsRoverEnums.ControlOfRover.TurnLeft:
                    this.TurnLeft();
                    break;

                case (char)MarsRoverEnums.ControlOfRover.TurnRight:
                    this.TurnRight();
                    break;

                default:
                    throw new NotSupportedException();
            }
        }
        /// <summary>
        /// Gezgin aracımızın Sağ'a dönüş komutuna uygun yöne çeviriyoruz.
        /// </summary>
        private void TurnRight()
        {
            switch (this.Direction)
            {
                case (char)MarsRoverEnums.DirectionsOfRover.North:
                    this.Direction = (char)MarsRoverEnums.DirectionsOfRover.East;
                    break;
                case (char)MarsRoverEnums.DirectionsOfRover.East:
                    this.Direction = (char)MarsRoverEnums.DirectionsOfRover.South;
                    break;
                case (char)MarsRoverEnums.DirectionsOfRover.South:
                    this.Direction = (char)MarsRoverEnums.DirectionsOfRover.West;
                    break;
                case (char)MarsRoverEnums.DirectionsOfRover.West:
                    this.Direction = (char)MarsRoverEnums.DirectionsOfRover.North;
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Gezgin aracımızın Sol'a dönüş komutuna uygun yöne çeviriyoruz.
        /// </summary>
        private void TurnLeft()
        {
            switch (this.Direction)
            {
                case (char)MarsRoverEnums.DirectionsOfRover.North:
                    this.Direction = (char)MarsRoverEnums.DirectionsOfRover.West;
                    break;

                case (char)MarsRoverEnums.DirectionsOfRover.West:
                    this.Direction = (char)MarsRoverEnums.DirectionsOfRover.South;
                    break;

                case (char)MarsRoverEnums.DirectionsOfRover.South:
                    this.Direction = (char)MarsRoverEnums.DirectionsOfRover.East;
                    break;

                case (char)MarsRoverEnums.DirectionsOfRover.East:
                    this.Direction = (char)MarsRoverEnums.DirectionsOfRover.North;
                    break;
            }
        }

        /// <summary>
        /// Gönderilen Yeni Pozisyon Bilgilerini Kontrol Ediyor ve Bunu İlgili Alanlara Set Ediyor.
        /// </summary>
        /// <param name="Param"></param>
        private void Check_NewPositionRover(string[] Param)
        {
            int tempCoordinate;
            if (int.TryParse(Param[0], out tempCoordinate))
            {
                if ((tempCoordinate > this._plateau.GetXCoordinate()) || (tempCoordinate < 0))
                    throw new ArgumentException(MarsRoverMessages.ER_ROVER_GREATER_THAN_PLATEU_LIMIT);
                this.Coordinate_X = tempCoordinate;
            }                
            else
                throw new ArgumentException(MarsRoverMessages.ER_PLATEAU_BAD_PARAMETERS_IN_CONSTRUCTOR);
            if (int.TryParse(Param[1], out tempCoordinate))
            {
                if ((tempCoordinate > this._plateau.GetYCoordinate()) || (tempCoordinate < 0))
                    throw new ArgumentException(MarsRoverMessages.ER_ROVER_GREATER_THAN_PLATEU_LIMIT);
                this.Coordinate_Y = tempCoordinate;
            }                
            else
                throw new ArgumentException(MarsRoverMessages.ER_PLATEAU_BAD_PARAMETERS_IN_CONSTRUCTOR);

            if ((String.IsNullOrEmpty(Param[2]) == false) && (Enum.IsDefined(typeof(MarsRoverEnums.DirectionsOfRover), ((int)Param[2].ToCharArray()[0]))))
                this.Direction = Param[2].ToCharArray()[0];
            else
                throw new ArgumentException(MarsRoverMessages.ER_PLATEAU_BAD_PARAMETERS_IN_CONSTRUCTOR);


        }
    }
}
