namespace ArticleStream.Service
{
    public interface IErrorLogger
    {
        void LogError(Exception ex);
    }
}
