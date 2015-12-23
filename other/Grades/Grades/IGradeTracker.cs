using System.IO;

namespace Grades
{
    internal interface IGradeTracker
    {
        string Name { get; set; }

        void AddGrade(float grade);

        GradeStatistics ComputeStatistics();

        void WriteGrades(TextWriter destination);
    }
}