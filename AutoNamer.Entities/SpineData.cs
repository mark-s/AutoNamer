using System.CodeDom;
using PropertyChanged;

namespace AutoNamer.Entities
{
    [ImplementPropertyChanged]
    public class SpineData
    {
        public string Title { get; set; }
        public string Author { get; set; }

        internal SpineData() { }

        internal SpineData(string title, string author)
        {
            Title = RemoveHtmlChars(title);
            Author = author;
        }


        private string RemoveHtmlChars(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            return text.Replace("&amp;","&");

        }

    }
}