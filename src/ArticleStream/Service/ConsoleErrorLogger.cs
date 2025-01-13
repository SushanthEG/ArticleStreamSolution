namespace ArticleStream.Service
{
    public class ConsoleErrorLogger : IErrorLogger
    {
        public void LogError(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
        }
    }
}
