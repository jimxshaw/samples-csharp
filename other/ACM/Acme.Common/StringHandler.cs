namespace Acme.Common
{
    public static class StringHandler
    {
        // For extension methods, they must reside in a static class. The 
        // methods themselves must be static. Finally, the this keyword must 
        // be placed in front of the first parameter in an extension method.
        // By putting the this keyword there, the parameter no longer represents 
        // a parameter passed to the method but represents the type being extended.
        public static string InsertSpaces(this string source)
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
