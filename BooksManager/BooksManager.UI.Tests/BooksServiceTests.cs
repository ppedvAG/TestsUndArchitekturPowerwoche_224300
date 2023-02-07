using BooksManager.Common;

namespace BooksManager.UI.Tests
{
    public class BooksServiceTests
    {
        [Fact]
        public void GetBooksByBestPagePriceRatio_3_Books_Number_2_is_first()
        {
            var service = new BooksService(new MyTestDataSource());

            var result = service.GetBooksByBestPagePriceRatio();

            Assert.Equal(2, result.First().Id);

        }
    }

    public class MyTestDataSource : IDataSource
    {
        public IEnumerable<Book> GetBooks()
        {
            var books = new List<Book>();
            books.Add(new Book { Id = 1, Pages = 100, Price = 100m });
            books.Add(new Book { Id = 2, Pages = 500, Price = 200m });
            books.Add(new Book { Id = 3, Pages = 200, Price = 200m });
            return books;
        }
    }
}