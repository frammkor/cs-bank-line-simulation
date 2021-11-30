/* 
Franco Cespi
CS-1415 Lab 11: BankSimulation
Started: 22/11/2021
Log for the Logger
*/

using System;

namespace bank_simulation
{
    public struct Log
    {
        public bool IsArrival;
        public DateTime TimeStamp;

        public Log(bool isArrival, DateTime timeStamp)
        {
            IsArrival = isArrival;
            TimeStamp = timeStamp;
        }
    }
}
