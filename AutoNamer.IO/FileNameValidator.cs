namespace AutoNamer.IO
{
    public class FileNameValidator : IFileNameValidator
    {
        public string GetValidName(string filename)
        {
            return filename;
        }

        public bool IsValidFileName(string filename)
        {
            return true;
        }
    }
}