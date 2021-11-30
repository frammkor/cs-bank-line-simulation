using NUnit.Framework;

namespace bank_simulation.Test
{
    public class BankSimulatorTest
    {
        private BankSimulation bankSim;
        [SetUp]
        public void Setup()
        {
            bankSim = new BankSimulation(new CustomerStreamDeterministic(), 1, 20, new Logger());
        }

        [Test]
        public void Test1()
        {
            bankSim.Simulate();
            Assert.AreEqual(2, bankSim.BankLogger.maxLineLength);
        }
    }
}
