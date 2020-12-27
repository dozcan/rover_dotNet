using Microsoft.VisualStudio.TestTools.UnitTesting;
using doga;
using System.Collections.Generic;

namespace dogaUnitTest
{
    [TestClass]
    public class NasaTest
    {
        [TestMethod]
        public void TestHelperFunction()
        {
            string directions = "LMR";
            List<string> expectedResult = new List<string> { "L", "M", "R" };
            var result = Helper.DirectionParser(directions);
            Assert.AreEqual(directions[0].ToString(), expectedResult[0]);
        }

        [TestMethod]
        public void TestHelperFunctionStartNextRoverMovementIndex()
        {
            var result = Helper.StartNextRoverMovementIndex(2, 2);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestCreateRover()
        {
            List<string> roverMove = new List<string> { "L", "M", "R" };
            List<int> coordinates = new List<int> { 1, 5 };
            BaseRover rover = Factory.createRover("N", roverMove, coordinates);
            Assert.AreEqual(1, rover.x_coordinate);
        }

        [TestMethod]
        public void TestManipulateRover()
        {
            List<string> roverMove = new List<string> { "L", "M", "R" };
            List<int> coordinates = new List<int> { 1, 5 };
            BaseRover rover = Factory.createRover("N", roverMove, coordinates);
            rover.ManipulateNextCoordinate();
            Assert.AreEqual(6, rover.y_coordinate);
        }

        [TestMethod]
        public void TestHasMovementExistControl()
        {
            List<string> roverMove = new List<string> { "L", "M", "R" };
            List<int> coordinates = new List<int> { 1, 5 };
            BaseRover rover = Factory.createRover("N", roverMove, coordinates);
            List<BaseRover> rovers = new List<BaseRover>();
            rovers.Add(rover);
            Assert.AreEqual(true, Helper.hasMovementExist(ref rovers));
        }

        [TestMethod]
        public void TestManipulateDirectionAndCoordinate()
        {
            List<string> roverMove = new List<string> { "M" };
            List<int> coordinates = new List<int> { 1, 5 };
            BaseRover rover = Factory.createRover("N", roverMove, coordinates);
            List<BaseRover> rovers = new List<BaseRover>();
            rovers.Add(rover);
            int index = 0;
            int expectedIndex = 1;
            rover.ManipulateDirectionAndCoordinate(rovers,ref index);
            Assert.AreEqual(expectedIndex, index);
        }
        [TestMethod]
        public void TestFindDirection()
        {
            string[] DIRECTION = { "N", "E", "S", "W" };
            List<string> roverMove = new List<string> { "L" };
            List<int> coordinates = new List<int> { 1, 5 };
            BaseRover rover = Factory.createRover("N", roverMove, coordinates);
            rover.FindDirection(0);
            string expectedCompass = "W";
            Assert.AreEqual(expectedCompass, rover.defaultDirection);
        }
    }
}
