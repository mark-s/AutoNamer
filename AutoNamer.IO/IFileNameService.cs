using System;
using AutoNamer.Core;

namespace AutoNamer.IO
{
    public interface IFileNameService
    {
        IRenameResult RenameFile(IBook book, Func<IBook, string> renamer);
    }
}