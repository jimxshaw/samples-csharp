using System;

namespace FunctionalCSharp.Intro
{
    public class DateRange
    {
        // To enforce immutability, make the setters private and
        // then add a constructor.

        // That's not enough. First, private read only fields will need to
        // be added so that the DateRange is immutable from within the
        // class as well. Readonly means we can only set the value within
        // the declaration or within the constructor. Trying to set the value
        // anywhere else (like using the Slide() method) will result in a 
        // compile error.

        // Second, explicit getters must be created. This breaks the Slide()
        // method so a new Slide() method will have to be created.

        private readonly DateTime _start;
        private readonly DateTime _end;

        public DateTime Start
        {
            get { return _start; }
            // private set
        }

        public DateTime End
        {
            get { return _end; }
            // private set
        }

        public DateRange(DateTime start, DateTime end)
        {
            if (start.CompareTo(end) >= 0) throw new Exception("End date must occur after start date");

            _start = start;
            _end = end;
        }

        public bool DateIsInRange(DateTime checkDate)
        {
            // True or False: the start date is prior to the end date AND the end
            // date is past the start end.
            return Start.CompareTo(checkDate) <= 0 && End.CompareTo(checkDate) >= 0;
        }

        //public void Slide(int days)
        //{
        //    Start = Start.AddDays(days);
        //    End = End.AddDays(days);
        //}

        public DateRange Slide(int days)
        {
            return new DateRange(Start.AddDays(days), End.AddDays(days));
        }
    }
}