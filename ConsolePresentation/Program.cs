namespace ConsolePresentation
{
    internal class Program
    {
        [Obsolete]
        static async Task Main()
        {
            var application = new MainPage();
            await application.Run();
        }
    }
}
