namespace ArticleStream.Model
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string FullText { get; set; }
        public List<string> Images { get; set; } = new List<string>();
    }
}
