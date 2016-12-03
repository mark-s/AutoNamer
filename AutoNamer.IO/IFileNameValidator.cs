namespace AutoNamer.IO
{
    public interface IFileNameValidator
    {
        string GetValidName(string filename);

        bool IsValidFileName(string filename);
    }
}