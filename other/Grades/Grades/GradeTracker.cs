using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        protected string _name;

        // The difference between a delegate and an event is
        // the inclusion of the event key word. Events are
        // based on delegates.
        public event NameChangedDelegate NameChanged;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                if (_name != value && NameChanged != null)
                {
                    var args = new NameChangedEventArgs();
                    args.EvistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }
                _name = value;

            }
        }

        public abstract void AddGrade(float grade);

        public abstract GradeStatistics ComputeStatistics();

        public abstract void WriteGrades(TextWriter destination);
    }
}
