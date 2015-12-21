namespace Grades
{
    public class GradeStatistics
    {
        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;
        }

        public string Description
        {
            get
            {
                string result;

                switch (LetterGrade)
                {
                    case "A":
                        result = "Fantastic!";
                        break;
                    case "B":
                        result = "Good job";
                        break;
                    case "C":
                        result = "Adequate";
                        break;
                    case "D":
                        result = "Below average";
                        break;
                    default:
                        result = "Failing";
                        break;
                }
                return result;
            }
        }

        public string LetterGrade
        {
            get
            {
                string result;

                if (AverageGrade >= 90)
                {
                    result = "A";
                }
                else if (AverageGrade >= 80)
                {
                    result = "B";
                }
                else if (AverageGrade >= 70)
                {
                    result = "C";
                }
                else if (AverageGrade >= 60)
                {
                    result = "D";
                }
                else
                {
                    result = "F";
                }
                return result;
            }
        }

        public float HighestGrade { get; set; }
        public float LowestGrade { get; set; }
        public float AverageGrade { get; set; }

    }
}