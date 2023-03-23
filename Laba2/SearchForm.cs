using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba2
{
    public enum SearchFormat
    {
        LINQ = 0,
        REGEX
    }

    public partial class SearchForm : Form
    {
        private SearchFormat searchFormat = SearchFormat.LINQ;
        Library library2 = new Library("Библиотека2");
        public SearchForm()
        {
            InitializeComponent();
        }

        public SearchForm(Library library)
        {
            InitializeComponent();
            this.library = library;
        }

        private void inputBookTitle_TextChanged(object sender, EventArgs e) //поиск
        {
            if (searchFormat == SearchFormat.LINQ)
            {
                var search = library.GetBookCollection().Where(x => (x.Name == inputBookTitle.Text.ToString()));
                library2.Clear();
                listBoxSearchResult.Items.Clear();
                foreach (BookFile item in search)
                {
                    library2.AddBook(item);
                    listBoxSearchResult.Items.Add("Название: " + item.Name + " | " + "Автор: " + item.Author + " | " + "Год написания: " + item.Year + " | " + "Страницы: " + item.BookSize + " | " + "Издательство: " + item.Publisher + " | " + "Дата загрузки: " +  item.UploadDate);
                }
                listBoxSearchResult.Update();

                labelFound.Text = "Найдено: " + listBoxSearchResult.Items.Count.ToString() + " Действие: поиск по названию LINQ " + " Дата: " + DateTime.Now;
            }
            else if (searchFormat == SearchFormat.REGEX)
            {
                var search = library.GetBookCollection().Where(x => regCheck(x.Name, inputBookTitle.Text.ToString()));
                library2.Clear();
                listBoxSearchResult.Items.Clear();
                foreach (BookFile item in search)
                {
                    library2.AddBook(item);
                    listBoxSearchResult.Items.Add("Название: " + item.Name + " | " + "Автор: " + item.Author + " | " + "Год написания: " + item.Year + " | " + "Страницы: " + item.BookSize + " | " + "Издательство: " + item.Publisher + " | " + "Дата загрузки: " + item.UploadDate);
                }
                listBoxSearchResult.Update();

                labelFound.Text = "Найдено: " + listBoxSearchResult.Items.Count.ToString() +" Действие: поиск по названию RegEx " + " Дата: " + DateTime.Now;
            }
        }
        private void inputPublisher_TextChanged(object sender, EventArgs e)
        {
            if (searchFormat == SearchFormat.LINQ)
            {
                var search = library.GetBookCollection().Where(x => (x.Publisher == inputPublisher.Text.ToString()));
                library2.Clear();
                listBoxSearchResult.Items.Clear();
                foreach (BookFile item in search)
                {
                    library2.AddBook(item);
                    listBoxSearchResult.Items.Add("Название: " + item.Name + " | " + "Автор: " + item.Author + " | " + "Год написания: " + item.Year + " | " + "Страницы: " + item.BookSize + " | " + "Издательство: " + item.Publisher + " | " + "Дата загрузки: " + item.UploadDate);
                }
                listBoxSearchResult.Update();

                labelFound.Text = "Найдено: " + listBoxSearchResult.Items.Count.ToString() + " Действие: поиск по издательству LINQ " + " Дата: " + DateTime.Now;
            }
            else if (searchFormat == SearchFormat.REGEX)
            {
                var search = library.GetBookCollection().Where(x => regCheck(x.Publisher, inputPublisher.Text.ToString()));
                library2.Clear();
                listBoxSearchResult.Items.Clear();
                foreach (BookFile item in search)
                {
                    library2.AddBook(item);
                    listBoxSearchResult.Items.Add("Название: " + item.Name + " | " + "Автор: " + item.Author + " | " + "Год написания: " + item.Year + " | " + "Страницы: " + item.BookSize + " | " + "Издательство: " + item.Publisher + " | " + "Дата загрузки: " + item.UploadDate);
                }
                listBoxSearchResult.Update();

                labelFound.Text = "Найдено: " + listBoxSearchResult.Items.Count.ToString() + " Действие: поиск по издательству RegEx " + " Дата: " + DateTime.Now;
            }
        }

        private void inputYear_TextChanged(object sender, EventArgs e)
        {
            if (searchFormat == SearchFormat.LINQ)
            {
                var search = library.GetBookCollection().Where(x => (x.Year == Int32.Parse(inputYear.Text)));
                library2.Clear();
                listBoxSearchResult.Items.Clear();
                foreach (BookFile item in search)
                {
                    library2.AddBook(item);
                    listBoxSearchResult.Items.Add("Название: " + item.Name + " | " + "Автор: " + item.Author + " | " + "Год написания: " + item.Year + " | " + "Страницы: " + item.BookSize + " | " + "Издательство: " + item.Publisher + " | " + "Дата загрузки: " + item.UploadDate);
                }
                listBoxSearchResult.Update();
                labelFound.Text = "Найдено: " + listBoxSearchResult.Items.Count.ToString() + " Действие: поиск по году LINQ " + " Дата: " + DateTime.Now;
            }
            else if (searchFormat == SearchFormat.REGEX)
            {
                MessageBox.Show("Невозомжно проверить год издания через RegEx");
            }
        }

        private bool regCheck(string sorce, string substr)
        {
            substr = substr.Trim();
            string[] words = Regex.Split(substr, @"\s+");

            string regex = "";
            foreach (string item in words)
            {
                regex += (item + "|");
            }

            regex = regex.Remove(regex.Length - 1);
            Regex reg = new Regex(regex);

            return Regex.IsMatch(sorce, regex);
        }

        private void btnYearSort_Click(object sender, EventArgs e)
        {
            listBoxSearchResult.Items.Clear();
            var sorted = library2.GetBookCollection().OrderByDescending(u => u.Year);
            foreach (BookFile item in sorted)
            {
                listBoxSearchResult.Items.Add("Название: " + item.Name + " | " + "Автор: " + item.Author + " | " + "Год написания: " + item.Year + " | " + "Страницы: " + item.BookSize + " | " + "Издательство: " + item.Publisher + " | " + "Дата загрузки: " + item.UploadDate);
            }
            listBoxSearchResult.Update();
            labelFound.Text = "Найдено: " + listBoxSearchResult.Items.Count.ToString() + " Действие: сортировка по году  " + " Дата: " + DateTime.Now;
        }

        private void btnPageSort_Click(object sender, EventArgs e)
        {
            listBoxSearchResult.Items.Clear();
            var sorted = library2.GetBookCollection().OrderByDescending(u => u.BookSize);
            foreach (BookFile item in sorted)
            {
                listBoxSearchResult.Items.Add("Название: " + item.Name + " | " + "Автор: " + item.Author + " | " + "Год написания: " + item.Year + " | " + "Страницы: " + item.BookSize + " | " + "Издательство: " + item.Publisher + " | " + "Дата загрузки: " + item.UploadDate);
            }
            listBoxSearchResult.Update();
            labelFound.Text = "Найдено: " + listBoxSearchResult.Items.Count.ToString() + " Действие: сортировка по страницам " + " Дата: " + DateTime.Now;
        }

        private void btnUploadSort_Click(object sender, EventArgs e)
        {
            listBoxSearchResult.Items.Clear();
            var sorted = library2.GetBookCollection().OrderByDescending(u => u.UploadDate);
            foreach (BookFile item in sorted)
            {
                listBoxSearchResult.Items.Add("Название: " + item.Name + " | " + "Автор: " + item.Author + " | " + "Год написания: " + item.Year + " | " + "Страницы: " + item.BookSize + " | " + "Издательство: " + item.Publisher + " | " + "Дата загрузки: " + item.UploadDate);
            }
            listBoxSearchResult.Update();
            labelFound.Text = "Найдено: " + listBoxSearchResult.Items.Count.ToString() + " Действие: сортировка по дате загрузки " + " Дата: " + DateTime.Now;
        }

        private void btnNameSort_Click(object sender, EventArgs e)
        {
            listBoxSearchResult.Items.Clear();
            var sorted = library2.GetBookCollection().OrderByDescending(u => u.Name);
            foreach (BookFile item in sorted)
            {
                listBoxSearchResult.Items.Add("Название: " + item.Name + " | " + "Автор: " + item.Author + " | " + "Год написания: " + item.Year + " | " + "Страницы: " + item.BookSize + " | " + "Издательство: " + item.Publisher + " | " + "Дата загрузки: " + item.UploadDate);
            }
            listBoxSearchResult.Update();
            labelFound.Text = "Найдено: " + listBoxSearchResult.Items.Count.ToString() + " Действие: сортировка по названию " + " Дата: " + DateTime.Now;
        }

        private void rbSearchFormat_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLinq.Checked)
            {
                searchFormat = SearchFormat.LINQ;
            }
            else if (rbRegex.Checked)
            {
                searchFormat = SearchFormat.REGEX;
            }
        }

        private void библиотекаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Activate();
            main.Show();
        }

        private void поГодуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxSearchResult.Items.Clear();
            var sorted = library2.GetBookCollection().OrderByDescending(u => u.Year);
            foreach (BookFile item in sorted)
            {
                listBoxSearchResult.Items.Add("Название: " + item.Name + " | " + "Автор: " + item.Author + " | " + "Год написания: " + item.Year + " | " + "Страницы: " + item.BookSize + " | " + "Издательство: " + item.Publisher + " | " + "Дата загрузки: " + item.UploadDate);
            }
            listBoxSearchResult.Update();
            labelFound.Text = "Найдено: " + listBoxSearchResult.Items.Count.ToString() + " Действие: сортировка по страницам " + " Дата: " + DateTime.Now;
        }

        private void поДатеЗагрузкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxSearchResult.Items.Clear();
            var sorted = library2.GetBookCollection().OrderByDescending(u => u.UploadDate);
            foreach (BookFile item in sorted)
            {
                listBoxSearchResult.Items.Add("Название: " + item.Name + " | " + "Автор: " + item.Author + " | " + "Год написания: " + item.Year + " | " + "Страницы: " + item.BookSize + " | " + "Издательство: " + item.Publisher + " | " + "Дата загрузки: " + item.UploadDate);
            }
            listBoxSearchResult.Update();
            labelFound.Text = "Найдено: " + listBoxSearchResult.Items.Count.ToString() + " Действие: сортировка по дате загрузки " + " Дата: " + DateTime.Now;

        }

        private void поНазваниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxSearchResult.Items.Clear();
            var sorted = library2.GetBookCollection().OrderByDescending(u => u.Name);
            foreach (BookFile item in sorted)
            {
                listBoxSearchResult.Items.Add("Название: " + item.Name + " | " + "Автор: " + item.Author + " | " + "Год написания: " + item.Year + " | " + "Страницы: " + item.BookSize + " | " + "Издательство: " + item.Publisher + " | " + "Дата загрузки: " + item.UploadDate);
            }
            listBoxSearchResult.Update();
            labelFound.Text = "Найдено: " + listBoxSearchResult.Items.Count.ToString() + " Действие: сортировка по названию " + " Дата: " + DateTime.Now;

        }
    }
}
