namespace ExtensionMethods
{
    public static class Extensions
    {
        public static bool IsGreatarThanZero(this int n)
        {
            return n > 0;
        }

        public static string FillSpaceWithStar(this string str)
        {
            str.Replace(" ", "*");
            return str;
        }

        public static string GetYourCountry(this string str, string value)
        {
            return $"The name of {str}'s country is {value}";
        }

    }
}
