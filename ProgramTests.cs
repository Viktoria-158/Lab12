using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantsLibrary;

namespace PlantsLibrary
{
    [TestClass]
    public class ProgramLogicTests
    {
        [TestMethod]
        public void RemoveAllByNameRemovesCorrectElements()
        {
            DoublyLinkedList<Plant> list = new DoublyLinkedList<Plant>();
            list.AddToEnd(new Plant("Роза", "Красный"));
            list.AddToEnd(new Plant("Тюльпан", "Желтый"));
            list.AddToEnd(new Plant("Роза", "Белый"));

            bool found;
            do
            {
                found = list.RemoveElement(new Plant("Роза", ""));
            } while (found);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Тюльпан", list.Begin.Data.Name);
        }

        [TestMethod]
        public void AddKRandomPlantsAddsCorrectNumber()
        {
            DoublyLinkedList<Plant> list = new DoublyLinkedList<Plant>();
            int k = 5;

            for (int i = 0; i < k; i++)
            {
                Plant plant = new Plant();
                plant.RandomInit();
                list.AddToBegin(plant);
            }

            Assert.AreEqual(k, list.Count);
        }
    }
}