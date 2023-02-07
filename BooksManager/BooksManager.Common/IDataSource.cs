namespace BooksManager.Common
{
    public interface IDataSource
    {
        IEnumerable<Book> GetBooks();

        void KillAllHumans();
    }
}