using System.Collections.Generic;
using System;

namespace bank_simulation
{
    public class Logger
    {
        private List<Log> logs;

        public int maxLineLength;

        Logger()
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
    }
}
