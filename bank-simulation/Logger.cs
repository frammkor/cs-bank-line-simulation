/* 
Franco Cespi
CS-1415 Lab 11: BankSimulation
Started: 22/11/2021
A logger that will be able to keep track of how long a costumer waited in the line and how long it was
*/

using System.Collections.Generic;
using System;
using System.Linq;

namespace bank_simulation
{
    public class Logger
    {
        private List<Log> logs;

        public int maxLineLength;

        public Logger()
        {
            maxLineLength = 0;
            logs = new List<Log>();
        }

        public void MarkArrival(DateTime timeStamp, int lineLength)
        {
            if (lineLength > maxLineLength) maxLineLength = lineLength;
            // add to list
            logs.Add(new Log(true, timeStamp));
        }

        public void MarkExit(DateTime timeStamp)
        {
            logs.Add(new Log(false, timeStamp));
        }

        public double GetMaxLineLength()
        {
            return maxLineLength;
        }

        public double GetAverageLineLength()
        {
            IEnumerable<Log> arrivals = logs.Where(log => log.IsArrival == true);
            List<Log> arrivalsList = new List<Log>(arrivals);
            return maxLineLength / arrivals.Count();
        }
    }
}
