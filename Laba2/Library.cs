using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    [DataContract]
    public class Library
    {
        [DataMember]
        private string libraryName;
        [DataMember]
        private List<BookFile> booksList;

        public Library(string libraryName)
        {
            this.libraryName = libraryName;
            this.booksList = new List<BookFile>();
        }

        public List<BookFile> GetBookCollection()
        {
            return booksList;
        }

        public void AddBook(BookFile book)
        {
            booksList.Add(book);
        }

        public void Clear()
        {
            booksList.Clear();
        }

        public override string ToString()
        {
            return libraryName;
        }
    }
}
