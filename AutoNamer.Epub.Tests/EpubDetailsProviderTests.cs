using FluentAssertions;
using NUnit.Framework;

namespace AutoNamer.Epub.Tests
{
    [TestFixture]
    public class EpubDetailsProviderTests
    {
        private IBookDetailsProvider _epubDetailsProvider;

        [SetUp]
        public void Setup()
        {
            _epubDetailsProvider = new EpubDetailsProvider();
        }


        [Test]
        public void GetBookData_GoodBook_ReturnsAuthor()
        {
            var bookData =_epubDetailsProvider.GetBookData("pg11.epub");

            bookData.Current.Author.Should().Be("Lewis Carroll");

        }


        [Test]
        public void GetBookData_GoodBook_ReturnsTitle()
        {
            var bookData = _epubDetailsProvider.GetBookData("pg11.epub");

            bookData.Current.Title.Should().Be("Alice's Adventures in Wonderland");
        }
    }
}
