using System;

namespace FunctionalCSharp
{
    public class DateRange
    {
        // To enforce immutability, make the setters private and
        // then add a constructor.

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public DateRange(DateTime start, DateTime end)
        {
            if (start.CompareTo(end) >= 0) throw new Exception("End date must occur after start date");

            Start = start;
            End = end;
        }

        public bool DateIsInRange(DateTime checkDate)
        {
            // True or False: the start date is prior to the end date AND the end
            // date is past the start end.
            return Start.CompareTo(checkDate) <= 0 && End.CompareTo(checkDate) >= 0;
        }  
    }
}