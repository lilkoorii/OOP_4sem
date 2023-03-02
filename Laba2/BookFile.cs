using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
        // Поля
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

        // Конструкторы

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

        // Свойства

        [Required(ErrorMessage = "Введите название книжки!")] //собств аттрибут
        [Length]
        public string Name { get => name; set => name = value; }

        [Required(ErrorMessage = "Необходимо указать автора")]
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

        [Required(ErrorMessage = "Необходимо указать год")]
        [Range(1900, 2023, ErrorMessage = "Неправильный год создания!")]
        public int Year { get => year; set => year = value; }

        [Required(ErrorMessage = "Обязательно ввести кол-во страниц!")]
        [Range(1, 1000, ErrorMessage = "Неправильное кол-во страниц!")]
        public int BookSize { get => bookSize; set => bookSize = value; }

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

        [Required(ErrorMessage = "Нужно ввести размер файла!")]
        [RegularExpression(@"[0-9]*\.{1}[0-9]*", ErrorMessage = "Некорректный ввод размера!")]
        public float FileSize
        { get => fileSize; set => fileSize = value; }

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

        // Мэтоды

        public int CompareTo(object obj)
        {
            return name.CompareTo(obj);
        }

    }
    public class LengthAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int name = value.ToString().Length;
            if (value != null)
            { 
                if (name >= 2)
                    return true;
                else
                    this.ErrorMessage = "Имя должно быть длиннее двух букв!";
            }
            return false;
        }
    }
}
