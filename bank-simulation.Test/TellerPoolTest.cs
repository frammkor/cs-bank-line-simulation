using System;
using NUnit.Framework;

namespace bank_simulation.Test
{
    public class TellerPoolTest
    {
        private TellerPool tellers;
        [SetUp]
        public void Setup()
        {
            tellers = new TellerPool(3);
        }

        [Test]
        public void Test1()
        {
            Assert.IsTrue(tellers.IsFree);
            tellers.Assign(new Customer(1));
            tellers.Assign(new Customer(2));
            Assert.IsTrue(tellers.IsFree);
            tellers.Assign(new Customer(3));
            Assert.IsFalse(tellers.IsFree);
            Assert.Throws<OverflowException>(() => tellers.Assign(new Customer(3)));

            // await and remove costumer, test is free
            tellers.Wait(1);
            tellers.RemoveFinishedCustomers();
            Assert.IsTrue(tellers.IsFree);
        }
    }
}
