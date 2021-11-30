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
