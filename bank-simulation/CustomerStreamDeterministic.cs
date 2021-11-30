/* 
Franco Cespi
CS-1415 Lab 11: BankSimulation
Started: 22/11/2021
A representation of a class that does not represent reality
*/

namespace bank_simulation
{
    public class CustomerStreamDeterministic : ICustomerStream
    {
        public double TimeTillNext { get; private set; }
        public CustomerStreamDeterministic()
        {
            TimeTillNext = 0;
        }

        public void Wait(double minutesPass)
        {
            TimeTillNext = TimeTillNext - minutesPass;
        }
        public Customer Next()
        {
            TimeTillNext = 5;
            return new Customer(10);
        }
    }
}
