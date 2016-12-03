using AutoNamer.Core;

namespace AutoNamer.IO
{
    public interface IRenameResult
    {
        IBook Book { get; }
        bool IsError { get; }
        string ErrorText { get; }
    }
}