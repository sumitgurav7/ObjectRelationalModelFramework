using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRelationalModelFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            BookLibraryDataContext bookLibraryData = new BookLibraryDataContext();

            IEnumerable<bookdata> bookdatas = bookLibraryData.bookdatas.Where(book => book.Title.Contains("India"));

            foreach(bookdata book in bookdatas)
            {
                Console.WriteLine(book);
            }

        }
    }
}
