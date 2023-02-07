using BooksManager.Common;
using System.Text.Json;

namespace BooksManager.Data.Json
{
    public class JsonDataSource : IDataSource
    {
        public string FilePath { get; }

        public JsonDataSource(string filePath)
        {
            FilePath = filePath;
        }

        public IEnumerable<Book> GetBooks()
        {
            return JsonSerializer.Deserialize<IEnumerable<Book>>(FilePath);
        }

        public void KillAllHumans()
        {

        }
    }
}