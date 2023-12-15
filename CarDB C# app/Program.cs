namespace CarDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Helpers.InsertTestData();
            App app = new App();
            app.Run();
        }
    }
}