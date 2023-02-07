using BooksManager.Common;

namespace BooksManager.Data.Demo
{
    public class DemoDataSource : IDataSource
    {
        public IEnumerable<Book> GetBooks()
        {
            yield return new Book() { Id = 1, Title = "Book #1", Description = "Testbook No.1", Price = 14.99m, Pages = 60, Authors = new[] { "Fred", "Wilma" } };
            yield return new Book() { Id = 1, Title = "Book #2", Description = "Testbook No.2", Price = 5.99m, Pages = 70, Authors = new[] { "Fred", "Wilma" } };
            yield return new Book() { Id = 1, Title = "Book #3", Description = "Testbook No.3", Price = 6.99m, Pages = 99, Authors = new[] { "Fred", "Wilma" } };
            yield return new Book() { Id = 1, Title = "Book #4", Description = "Testbook No.4", Price = 7.99m, Pages = 90, Authors = new[] { "Fred", "Wilma" } };
        }
    }
}