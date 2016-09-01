namespace Acme.Common
{
    public class StringHandler
    {

        public string InsertSpaces(string source)
        {
            string result = string.Empty;

            if (!string.IsNullOrWhiteSpace(source))
            {
                foreach (char letter in source)
                {
                    if (char.IsUpper(letter))
                    {
                        result += " ";
                    }
                    result += letter;
                }
                // Trim excess spaces from the beginning and end of the string
                // before assigning back to our result.
                result = result.Trim();
            }

            return result;
        }
    }
}
