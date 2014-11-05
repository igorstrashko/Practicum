using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IgorStrashko.Practicum.BLL;

namespace IgorStrashko.Practicum.Test
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void TestInvalidInput()
        {
            //Empty order
            Order order = new Order("");
            Assert.AreEqual(false, order.IsValid, "Empty order validation failed"); 

            //Invalid meal type
            order = new Order("day,1,1");
            Assert.AreEqual(Order.INVALID_TOD, order.ProcessOrder(), "Invalid meal type validation failed");

            //No dish type selection
            order = new Order("morning");
            Assert.AreEqual(Order.INVALID_LENGTH, order.ProcessOrder(), "Invalid dish type selection validation failed");
        }
        [TestMethod]
        public void PlaceOrder()
        {
            //Straightforward morning order
            Order order = new Order("morning, 1, 2, 3");
            Assert.AreEqual("eggs, toast, coffee", order.ProcessOrder(), "Invalid morning order return ");

            //Reverse order morning order
            order = new Order("morning, 2 , 1, 3");
            Assert.AreEqual("eggs, toast, coffee", order.ProcessOrder(), "Invalid reverse morning order return ");

            //Invalid dish type for the morning
            order = new Order("morning, 1, 2, 3, 4");
            Assert.AreEqual("eggs, toast, coffee, error", order.ProcessOrder(), "Invalid morning invalid dish type order return ");

            //3 coffees for the morning
            order = new Order("morning, 1, 2, 3, 3, 3");
            Assert.AreEqual("eggs, toast, coffee(x3)", order.ProcessOrder(), "Invalid triple coffee morning  type order return ");

            //Straightforward night order
            order = new Order("night, 1, 2, 3, 5");
            Assert.AreEqual("steak, potato, wine, error", order.ProcessOrder(), "Invalid night order return ");

            //Night double potato
            order = new Order("night, 1, 2, 2, 4");
            Assert.AreEqual("steak, potato(x2), cake", order.ProcessOrder(), "Invalid night double potatoe return ");

            //Invalid night dish type
            order = new Order("night, 1, 2, 3, 5");
            Assert.AreEqual("steak, potato, wine, error", order.ProcessOrder(), "Invalid night dish type return ");

            //Invalid night entree number
            order = new Order("night, 1, 1, 2, 3, 5");
            Assert.AreEqual("steak, error", order.ProcessOrder(), "Invalid night entree number return ");

        }


    }
}
