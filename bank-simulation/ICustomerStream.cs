using System;

/* 
Franco Cespi
CS-1415 Lab 11: BankSimulation
Started: 22/11/2021
An interface for the costumer stream
*/

namespace bank_simulation
{
    public interface ICustomerStream
    {
        double TimeTillNext { get; }

        void Wait(double minutesPass);
        Customer Next();
    }
}
