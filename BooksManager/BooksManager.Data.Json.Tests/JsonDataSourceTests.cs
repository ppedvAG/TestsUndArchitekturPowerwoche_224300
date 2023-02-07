namespace BooksManager.Data.Json.Tests
{
    public class JsonDataSourceTests
    {
        [Fact]
        [Trait("Category","Integration")]
        public void Can_serialize_Book_file()
        {
            var ds = new JsonDataSource("Book.json");

            var books = ds.GetBooks();  

            Assert.NotEmpty(books);
        }
    }
}