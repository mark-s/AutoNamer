using System;
using System.IO;
using System.Reactive.Subjects;

namespace AutoNamer.Core
{
    public interface IBookDataService
    {
         string FileTypeIHandle { get;  }

        ISubject<IBook> Books { get; }

        void ParseBooks(IObservable<FileInfo> fileList);
    }
}