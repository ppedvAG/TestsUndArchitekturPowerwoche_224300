using BooksManager.Common;
using Moq;

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

        [Fact]
        public void GetBooksByBestPagePriceRatio_3_Books_Number_2_is_first_moq()
        {
            var mock = new Mock<IDataSource>();
            mock.Setup(x => x.GetBooks()).Returns(() =>
            {
                var books = new List<Book>();
                books.Add(new Book { Id = 1, Pages = 100, Price = 100m });
                books.Add(new Book { Id = 2, Pages = 500, Price = 200m });
                books.Add(new Book { Id = 3, Pages = 200, Price = 200m });
                return books;
            });
            var service = new BooksService(mock.Object);

            var result = service.GetBooksByBestPagePriceRatio();

            Assert.Equal(2, result.First().Id);
        }

        [Fact]
        public void GetBooksByBestPagePriceRatio_2_book_have_same_ratio_should_be_order_by_title()
        {
            var mock = new Mock<IDataSource>();
            _ = mock.Setup(x => x.GetBooks()).Returns(() =>
            {
                var books = new List<Book>
                {
                    new Book { Id = 1, Title = "B3", Pages = 100, Price = 100m },
                    new Book { Id = 2, Title = "B1", Pages = 10, Price = 200m },
                    new Book { Id = 3, Title = "B2", Pages = 200, Price = 200m }
                };
                return books;
            });
            var service = new BooksService(mock.Object);

            var result = service.GetBooksByBestPagePriceRatio();

            Assert.Equal(3, result.First().Id);
            Assert.Equal(1, result.ElementAt(1).Id);
            Assert.Equal(2, result.ElementAt(2).Id);

            mock.Verify(x => x.GetBooks(), Times.Once());
            //mock.Verify(x => x.KillAllHumans(), Times.Exactly(2));

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

        public void KillAllHumans()
        {
            //throw new NotImplementedException();
        }
    }
}