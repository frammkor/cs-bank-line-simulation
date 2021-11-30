/* 
Franco Cespi
CS-1415 Lab 11: BankSimulation
Started: 22/11/2021
The main simulation
*/

using System;
using System.Collections.Generic;

namespace bank_simulation
{
    public class BankSimulation
    {
        private ICustomerStream CustomerStream;
        private TellerPool Tellers;
        private double TimeLeftToClose;
        public Logger BankLogger;
        private Queue<Customer> CustomersLine;
        public BankSimulation(ICustomerStream customerStream, int numberOfTellers, double workingTime, Logger bankLog)
        {
            CustomerStream = customerStream;
            Tellers = new TellerPool(numberOfTellers);
            TimeLeftToClose = workingTime;
            BankLogger = bankLog;
            CustomersLine = new Queue<Customer>();
        }

        public void Simulate()
        {
            // clear Tellers Pool from customers that are done with the things
            Tellers.RemoveFinishedCustomers();
            // if there are available tellers and customers waiting assing one of them to a teller, remove the customer from the line and generate an exit log
            if(Tellers.IsFree && CustomersLine.Count > 0)
            {
                Tellers.Assign(CustomersLine.Dequeue());
                BankLogger.MarkExit(DateTime.Now);
            }
            if (CustomerStream.TimeTillNext >= 0)
            {
                CustomersLine.Enqueue(CustomerStream.Next());
                BankLogger.MarkArrival(DateTime.Now, CustomersLine.Count);
            }
            // QUESTION: best way to do this to actions happen like at the same time
            while (TimeLeftToClose > 0)
            {
                double tellersNextEvent = Tellers.TimeTillNext;
                double CustomerStreamNextEvent = CustomerStream.TimeTillNext;
                // find the next event
                double timeTillNextEvent = tellersNextEvent > CustomerStreamNextEvent ? tellersNextEvent : CustomerStreamNextEvent;

                Tellers.Wait(timeTillNextEvent);
                CustomerStream.Wait(timeTillNextEvent);
                TimeLeftToClose = TimeLeftToClose - timeTillNextEvent;
            }
        }
    }
}
