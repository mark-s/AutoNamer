//using FluentAssertions;
//using NUnit.Framework;

//namespace AutoNamer.Epub.Tests
//{
//    [TestFixture]
//    public class EpubDetailsProviderTests
//    {
//        private IBookDetailsProvider _epubDetailsProvider;

//        [SetUp]
//        public void Setup()
//        {
//            _epubDetailsProvider = new EpubDetailsProvider();
//        }


//        [Test]
//        public async void GetBookData_GoodBook_ReturnsAuthor()
//        {
//             var bookData = await _epubDetailsProvider.GetBookSpineData("pg11.epub");

//             bookData.Current.Author.Should().Be("Lewis Carroll");

//        }


//        [Test]
//        public async void GetBookData_GoodBook_ReturnsTitle()
//        {
//            var bookData = await _epubDetailsProvider.GetBookSpineData("pg11.epub");

//            bookData.Current.Title.Should().Be("Alice's Adventures in Wonderland");
//        }
//    }
//}
