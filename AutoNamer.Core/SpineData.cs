using System.Web;

namespace AutoNamer.Core
{
    public class SpineData
    {
        public string Title { get; private set; }

        public string Author { get; private set; }

        public SpineData(string title, string author)
        {
            Title = string.IsNullOrEmpty(title) ? title : HttpUtility.HtmlDecode(title);
            Author = string.IsNullOrEmpty(author) ? author : HttpUtility.HtmlDecode(author);
        }

    }
}