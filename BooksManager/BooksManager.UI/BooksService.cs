using BooksManager.Common;
using System.Collections.Generic;
using System.Linq;

namespace BooksManager.UI
{
    public class BooksService
    {
        public IDataSource DataSource { get; }

        public BooksService(IDataSource dataSource)
        {
            DataSource = dataSource;

            dataSource.KillAllHumans();
        }

        public IEnumerable<Book> GetBooksByBestPagePriceRatio()
        {
            DataSource.KillAllHumans();


            return DataSource.GetBooks().OrderBy(x => x.Price / x.Pages)
                                        .ThenBy(x => x.Title);

            //Schlecht weil implementierung gegen Klassse
            //new DemoDataSource().GetBooks().OrderBy(x=>x.Price).ToList...
        }
    }
}
