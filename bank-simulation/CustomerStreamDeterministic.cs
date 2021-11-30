using System;

namespace bank_simulation
{
    public interface CustomerStreamDeterministic
    {
        double TimeTillNext { get; protected set; }

        void Wait(double minutesPass)
        {
            TimeTillNext = TimeTillNext - minutesPass;
        }
        Customer Next()
        {
            TimeTillNext = 5;
            return new Customer(10);
        }
    }
}
