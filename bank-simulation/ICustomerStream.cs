using System;

namespace bank_simulation
{
    public interface ICustomerStream
    {
        double TimeTillNext { get; protected set; }

        void Wait(double minutesPass);
        Customer Next();
    }
}
