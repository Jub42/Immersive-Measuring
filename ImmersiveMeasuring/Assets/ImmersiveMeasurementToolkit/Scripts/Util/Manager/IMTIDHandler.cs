
namespace Util
{
    /// <summary>
    /// Provides an ID.
    /// </summary>
    public static class IMTIDHandler
    {
        static int number = 0;

        private static int Next()
        {
            return number++;
        }
        public static string GetID()
        {
            return System.DateTime.Now.ToString() + " " + Next().ToString();
        }
    }
}

