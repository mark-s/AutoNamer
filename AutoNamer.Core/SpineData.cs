namespace AutoNamer.Core
{
    public class SpineData
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public SpineData(string title, string author)
        {
            Title = RemoveHtmlChars(title);
            Author = RemoveHtmlChars(author);
        }


        private string RemoveHtmlChars(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            return text.Replace("&amp;","&");

        }

    }
}