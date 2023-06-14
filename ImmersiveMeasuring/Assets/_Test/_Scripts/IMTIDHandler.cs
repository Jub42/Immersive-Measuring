public static class IMTIDHandler
{
    static int number = 0;

    public static int Next()
    {
        return number++;
    }
    public static string GetID()
    {
        return System.DateTime.Now.ToString() + " " + Next();
    }
}
