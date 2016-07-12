using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLog.Schedule
{
    [Serializable]
    public struct Shift
    {
        public TimeSpan timeWorked { get; private set; }
        public DateTime shiftStart { get; private set; }
        public DateTime shiftEnd { get; private set;  }

        public Shift(DateTime sStart, DateTime sEnd)
        { 
            shiftStart = sStart;
            shiftEnd = sEnd;
            timeWorked = sEnd - sStart;
        }

        public double getTotalHours()
        {
            return (shiftEnd - shiftStart).TotalSeconds / 3600;
        }

        public override string ToString()
        {
            return shiftStart.ToString("h:mm tt - ") + shiftEnd.ToString("h:mm tt"); 
        }
    }
}
