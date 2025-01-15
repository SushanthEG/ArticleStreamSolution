namespace ArticleStream.Service
{
    public interface IErrorLogger
    {
        void LogError(Exception ex);
        void LogError(string message, Exception ex);
    }
}
