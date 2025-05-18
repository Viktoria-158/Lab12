using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantsLibrary;
using System;

namespace PlantsLibrary
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        [TestMethod]
        public void ConstructorWithSizeCreatesCorrectNumberOfElements()
        {
            DoublyLinkedList<Plant> list = new DoublyLinkedList<Plant>(3);

            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorNegativeSize_ThrowsException()
        {
            DoublyLinkedList<Plant> list = new DoublyLinkedList<Plant>(-1);
        }

        [TestMethod]
        public void AddToBeginAddsElementCorrectly()
        {
            DoublyLinkedList<Plant> list = new DoublyLinkedList<Plant>();
            Plant plant = new Plant("Ромашка", "Белый");

            list.AddToBegin(plant);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(plant, list.Begin.Data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddToBeginNullData_ThrowsException()
        {
            DoublyLinkedList<Plant> list = new DoublyLinkedList<Plant>();
            list.AddToBegin(null);
        }

        [TestMethod]
        public void RemoveElementExistingElementReturnsTrue()
        {
            DoublyLinkedList<Plant> list = new DoublyLinkedList<Plant>();
            Plant plant = new Plant("Ландыш", "Белый");
            list.AddToEnd(plant);
            bool result = list.RemoveElement(plant);

            Assert.IsTrue(result);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void CloneCreatesIndependentCopy()
        {
            DoublyLinkedList<Plant> original = new DoublyLinkedList<Plant>();
            original.AddToEnd(new Plant("Орхидея", "Фиолетовый"));

            DoublyLinkedList<Plant> clone = (DoublyLinkedList<Plant>)original.Clone();
            clone.Begin.Data.Name = "Измененная";

            Assert.AreNotEqual(original.Begin.Data.Name, clone.Begin.Data.Name);
        }
    }
}