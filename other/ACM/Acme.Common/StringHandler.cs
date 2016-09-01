namespace Acme.Common
{
    public static class StringHandler
    {

        public static string InsertSpaces(string source)
        {
            string result = string.Empty;

            if (!string.IsNullOrWhiteSpace(source))
            {
                foreach (char letter in source)
                {
                    if (char.IsUpper(letter))
                    {
                        // Trim any spaces already in the source string.
                        result = result.Trim();
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
