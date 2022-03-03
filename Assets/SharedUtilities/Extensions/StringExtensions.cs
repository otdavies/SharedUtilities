namespace Psyfer.Utilities
{
    public static class StringExtensionMethods
    {
        /// <summary>
        /// This function will parse the string to the integer if possible.
        /// </summary>
        public static int ToInt(this string tempVal)
        {
            return int.Parse(tempVal);
        }

        /// <summary>
        /// This function will parse the string to the float if possible.
        /// </summary>
        public static float ToFloat(this string tempVal)
        {
            return float.Parse(tempVal);
        }
    }
}
