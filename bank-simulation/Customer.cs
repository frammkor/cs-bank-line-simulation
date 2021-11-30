using System;

namespace bank_simulation
{
    public class Customer
    {
        public double HelpLeft { get; private set; }

        public Customer(double helpLeft)
        {
            HelpLeft = helpLeft;
        }

        public void Help(double minutesPass)
        {
            HelpLeft = HelpLeft - minutesPass;
        }
    }
}
