
namespace MinimalApis
{

    public class ArticleService
    {

        private List<Article> list = new List<Article>
            {
                new Article(1, "Marteau"),
                new Article(2, "Scie")
            };

        public List<Article> GetAll() => list;

        public Article Add(string title)
        {
            var article = new Article(list.Max(a => a.Id) + 1, title);
            list.Add(article);
            return article;
        }
    }
}