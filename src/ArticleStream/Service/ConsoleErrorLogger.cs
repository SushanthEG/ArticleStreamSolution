namespace ArticleStream.Service
{
    public class ConsoleErrorLogger : IErrorLogger
    {
        public void LogError(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
        }

        public void LogError(string message, Exception ex)
        {
            Console.WriteLine($"Error: {message}\nException: {ex.Message}\n{ex.StackTrace}");
        }
    }
}
