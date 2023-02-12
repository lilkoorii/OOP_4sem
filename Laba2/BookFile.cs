using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    public enum FileFormat
    {
        FB2 = 1,
        EPUB,
        TXT
    }

    [DataContract]
    public class BookFile : IComparable
    {
        // ПОЛЯ
        [DataMember]
        private string name;
        [DataMember]
        private string author;
        [DataMember]
        private int year;
        [DataMember]
        private int bookSize;
        [DataMember]
        private string publisher;
        [DataMember]
        private FileFormat fileFormat;
        [DataMember]
        private float fileSize;
        [DataMember]
        private DateTime uploadDate;

        // КОНСТРУКТОРЫ --------------------------------------------------------------------------

        public BookFile(string name, string author, int year, int bookSize, string publisher, FileFormat fileFormat, float fileSize, DateTime uploadDate)
        {
            this.Name = name;
            this.Author = author;
            this.Year = year;
            this.BookSize = bookSize;
            this.Publisher = publisher;
            this.FileFormat = fileFormat;
            this.FileSize = fileSize;
            this.UploadDate = uploadDate;
        }

        // СВОЙСТВА --------------------------------------------------------------------------

        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 2)
                    throw new Exception("Недопустимая длина Имени.");
                else
                    name = value;
            }
        }

        public string Author
        {
            get => author;
            set
            {
                if (value.Length < 2)
                    throw new Exception("Недопустимая длина Автора.");
                else
                    author = value;
            }
        }

        public int Year
        {
            get => year;
            set
            {
                if (value < 0 || value > 2019)
                    throw new Exception("Недопустимый год создания.");
                else
                    year = value;
            }
        }

        public int BookSize
        {
            get => bookSize;
            set
            {
                if (value < 1)
                    throw new Exception("Недопустимое кол-во страниц.");
                else
                    bookSize = value;
            }
        }

        public string Publisher
        {
            get => publisher;
            set
            {
                if (value.Length < 2)
                    throw new Exception("Недопустимая длина Издательства.");
                else
                    publisher = value;
            }
        }

        public float FileSize
        {
            get => fileSize;
            set
            {
                if (value < 0.001)
                    throw new Exception("Недопустимаый размер файла.");
                else
                    fileSize = value;
            }
        }

        public DateTime UploadDate
        {
            get => uploadDate;
            set => uploadDate = value;
        }
        internal FileFormat FileFormat
        {
            get => fileFormat;
            set => fileFormat = value;
        }

        // МЕТОДЫ --------------------------------------------------------------------------

        public int CompareTo(object obj)
        {
            return name.CompareTo(obj);
        }
    }
}
