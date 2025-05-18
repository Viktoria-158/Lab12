using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantsLibrary;

namespace PlantsLibrary
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void ConstructorWithDataInitializesProperties()
        {
            Plant plant = new Plant("Роза", "Красный");

            Point<Plant> point = new Point<Plant>(plant);

            Assert.AreEqual(plant, point.Data);
            Assert.IsNull(point.Next);
            Assert.IsNull(point.Prev);
        }

        [TestMethod]
        public void ToStringReturnsCorrectFormat()
        {
            Plant plant = new Plant("Тюльпан", "Желтый");
            Point<Plant> point = new Point<Plant>(plant);
            Assert.AreEqual(plant.ToString(), point.ToString());
        }
    }
}