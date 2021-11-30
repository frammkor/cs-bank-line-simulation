/* 
Franco Cespi
CS-1415 Lab 11: BankSimulation
Started: 22/11/2021
A customer
*/

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
