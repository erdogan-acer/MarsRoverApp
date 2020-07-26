using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverDll.Tests
{
    [TestClass]
    public class MarsRoverTests
    {
        private static string _plateauSize;
        private static Plateau _plateau;

        [TestInitialize]
        public void Initialize()
        {
            Plateu_Create_5_5_Size();
        }
        [TestMethod]
        public void Rover_Olustur_Verilen_Koordinatlara_Aktar_12N_Ve_Verilen_Komutlari_Uygula_LMLMLMLMM()
        {
            Rover rover         = new Rover(_plateau);
            rover.NewPositionRover("8 2 N");
            rover.CommandsOnRover("LMLMLMLMM");

            var currentResult   = $"{rover.Coordinate_X} {rover.Coordinate_Y} {rover.Direction.ToString()}";
            var expectedOutput  = "1 3 N";

            Assert.AreEqual(expectedOutput, currentResult);
        }

        [TestMethod]
        public void Rover_Olustur_Verilen_Koordinatlara_Aktar_33E_Ve_Verilen_Komutlari_Uygula_MMRMMRMRRM()
        {
            Rover rover         = new Rover(_plateau);
            rover.NewPositionRover("3 3 E");
            rover.CommandsOnRover("MMRMMRMRRM");

            var currentResult   = $"{rover.Coordinate_X} {rover.Coordinate_Y} {rover.Direction}";
            var expectedOutput  = "5 1 E";

            Assert.AreEqual(expectedOutput, currentResult);
        }

        [TestMethod]
        public void Plateu_Create_5_5_Size()
        {
            _plateauSize        = "5 5";
            _plateau            = new Plateau(_plateauSize);

            var currentResult   = $"{_plateau.GetXCoordinate().ToString()} {_plateau.GetYCoordinate().ToString()}";
            var expectedOutput  = "5 5";
            
            Assert.AreEqual(expectedOutput, currentResult);
        }
    }
}
