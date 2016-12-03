using System;
using System.Text.RegularExpressions;

namespace AutoNamer.Epub
{
    public class EpubSectionParser : ISectionParser
    {
        // TODO: Regex may or may not be the fastest way of doing this .

        public string GetAuthor(string opfText)
        {
            const string author = @"<.{0,30}:creator.{0,150}>(.+)<\/.{0,10}:creator>";
            var regexAuthor = new Regex(author, RegexOptions.IgnoreCase | RegexOptions.Compiled, TimeSpan.FromSeconds(3));

            var authorMatch = regexAuthor.Match(opfText);
            return authorMatch.Success ? authorMatch.Groups[1].Value : string.Empty;
        }
        
        public string GetTitle(string opfText)
        {
            const string title = @"<.{0,30}:title.{0,30}>(.+)<\/.{0,30}:title>";
            var regexTitle = new Regex(title, RegexOptions.IgnoreCase | RegexOptions.Compiled, TimeSpan.FromSeconds(3));

            var titleMatch = regexTitle.Match(opfText);
            return titleMatch.Success ? titleMatch.Groups[1].Value : string.Empty;
        }

    }
}