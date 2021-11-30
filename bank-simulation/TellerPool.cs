using System;
using System.Collections.Generic;

namespace bank_simulation
{
    public class TellerPool
    {
        private int _totalTellers;
        private List<Customer> _tellersSlot;
        public bool IsFree {
            get => _tellersSlot.Count < _totalTellers;
        }
        public double TimeTillNext { get; private set; }

        public TellerPool(int amountOfTellers)
        {
            if (amountOfTellers < 1) throw new ArgumentException("There must be at least 1 teller");
            _tellersSlot = new List<Customer>(amountOfTellers);
            _totalTellers = amountOfTellers;
            TimeTillNext = 0;
        }

        public void Wait(double minutesPass)
        {
            if(_tellersSlot.Count > 0)
            {
                TimeTillNext = TimeTillNext - minutesPass;
                _tellersSlot.ForEach(customer => customer.Help(minutesPass));
            }
        }

        public void Assign(Customer commingCustomer)
        {
            if(!IsFree) throw new OverflowException("No more tellers are available");
            if(TimeTillNext < commingCustomer.HelpLeft) TimeTillNext = commingCustomer.HelpLeft;
            _tellersSlot.Add(commingCustomer);
        }

        public void RemoveFinishedCustomers()
        {
            _tellersSlot.RemoveAll(customer => customer.HelpLeft <= 0);
        }
    }
}
