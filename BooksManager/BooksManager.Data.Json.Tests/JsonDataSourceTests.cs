namespace BooksManager.Data.Json.Tests
{
    public class JsonDataSourceTests
    {
        [Fact]
        public void Can_serialize_Book_file()
        {
            var ds = new JsonDataSource("Book.json");

            var books = ds.GetBooks();  

            Assert.NotEmpty(books);
        }
    }
}