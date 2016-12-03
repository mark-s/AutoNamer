namespace AutoNamer.Epub
{
    public interface ISectionParser
    {
        string GetAuthor(string text);
        string GetTitle(string test);
    }
}