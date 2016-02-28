//using System.Linq;
//using FluentAssertions;
//using NUnit.Framework;

//namespace AutoNamer.IO.Tests
//{
//    [TestFixture]
//    public class FolderUtilsTests
//    {
//        private FileListService _fileListService;

//        private const string GOOD_FOLDER = @"Books";


//        [SetUp]
//        public void SetUp()
//        {
//            _fileListService = new FileListService();

//            // TODO: initialise the fake book files and the folder on the fly
//        }

//        [Test]
//        public void GetEpubsFromFolder_GoodFolderWithEpubs_ReturnsList()
//        {
//            // Arrange
            
//            // Act
//            var books = _fileListService.GetBooksFromFolder(GOOD_FOLDER);

//            // Assert
//            books.Count.Should().Be(2);
//        }


//        [Test]
//        public void GetEpubsFromFolder_GoodFolderWithEpubs_GetsFileName()
//        {
//            // Arrange

//            // Act
//            var books = _fileListService.GetBooksFromFolder(GOOD_FOLDER);

//            // Assert
//            var firstBook = books.First();

//            firstBook.Current.FileName.Should().Be("epub1");
//        }

//        [Test]
//        public void GetEpubsFromFolder_GoodFolderWithEpubs_GetsFileExtension()
//        {
//            // Arrange

//            // Act
//            var books = _fileListService.GetBooksFromFolder(GOOD_FOLDER);

//            // Assert
//            var firstBook = books.First();

//            firstBook.Current.FileExtension.Should().Be(".epub");
//        }

//        [Test]
//        public void GetEpubsFromFolder_GoodFolderWithEpubs_GetsFilePath()
//        {
//            // Arrange

//            // Act
//            var books = _fileListService.GetBooksFromFolder(GOOD_FOLDER);

//            // Assert
//            var firstBook = books.First();

//            firstBook.Current.FilePath.Should().Be("Books");
//        }


//        [Test]
//        public void GetEpubsFromFolder_ForeignCharsInName_GetsFileName()
//        {
//            // Arrange

//            // Act
//            var books = _fileListService.GetBooksFromFolder(GOOD_FOLDER);

//            // Assert
//            var book = books[1];

//            book.Current.FileName.Should().Be("安全第一");
//        }

//    }
//}
