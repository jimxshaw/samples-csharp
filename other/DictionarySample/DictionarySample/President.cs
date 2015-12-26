namespace DictionarySample
{
    public class President
    {
        public string Name { get; set; }
        public int YearElected { get; set; }

        public President(string name, int yearElected)
        {
            Name = name;
            YearElected = yearElected;
        }

        public override string ToString()
        {
            return string.Format("{0}, elected: {1}", Name, YearElected);
        }
    }
}