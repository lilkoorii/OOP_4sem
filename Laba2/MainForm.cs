using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace Laba2
{
    public partial class MainForm : Form
    {
        Library library = new Library("Библиотека!");

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(Library library)
        {
            InitializeComponent();
            this.library = library;
        }

        private void loadInFile_Click(object sender, EventArgs e)
        {
            if (listBox.Items.Count == 0)
            {
                MessageBox.Show("Невозможно сохранить пустой список!");
            }
            else
            {
                try
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Library));

                    using (FileStream fs = new FileStream("library.json", FileMode.OpenOrCreate))
                    {
                        jsonFormatter.WriteObject(fs, library);
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void loadFromFile_Click(object sender, EventArgs e)
        {
            Library jsonLibrary;

            try
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Library));

                using (FileStream fs = new FileStream("library.json", FileMode.OpenOrCreate))
                {
                    jsonLibrary = (Library)jsonFormatter.ReadObject(fs);
                }
                List<BookFile> books = jsonLibrary.GetBookCollection();

                foreach (BookFile book in books)
                {
                    library.GetBookCollection().Add(book);
                    listBox.Items.Add("Название: " + book.Name + " | " + "Автор: " + book.Author + " | " + "Год написания: " + book.Year + " | " + "Страницы: " + book.BookSize + " | " + "Издательство: " + book.Publisher);
                }
                listBox.Update();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Успешно загружено!", "Загрузка из файла.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int year = 1000;
            float fileSize = 0.5f;
            // проверка воодимых данных
            /*if (string.IsNullOrEmpty(inputNameField.Text) || string.IsNullOrEmpty(inputAuthorField.Text) ||
                string.IsNullOrEmpty(inputYearUpDown.Text) || string.IsNullOrEmpty(inputPublisherField.Text) ||
                string.IsNullOrEmpty(inputFileSizeField.Text))
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            
            if (!int.TryParse(inputYearUpDown.Text, out year) || !float.TryParse(inputFileSizeField.Text, out fileSize))
            {
                MessageBox.Show("Ожидалось числовое значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FileFormat format = FileFormat.FB2;
                if (rbFormat1.Checked)
                    format = FileFormat.FB2;
                if (rbFormat2.Checked)
                    format = FileFormat.EPUB;
                if (rbFormat3.Checked)
                    format = FileFormat.TXT;
       

                BookFile book = new BookFile(inputNameField.Text, inputAuthorField.Text, int.Parse(inputYearUpDown.Text),
                bookSizeTrackBar.Value, inputPublisherField.Text, format, float.Parse(inputFileSizeField.Text), ulpDatePicker.Value);
                //валидейшен
                var results = new List<ValidationResult>();
                var context = new ValidationContext(book);
                if (!Validator.TryValidateObject(book, context, results, true))
                {
                    foreach (var error in results)
                    {
                        MessageBox.Show(error.ErrorMessage);
                    }
                }
                else
                {
                    library.AddBook(book);
                    listBox.Items.Add("Название: " + book.Name + " | " + "Автор: " + book.Author + " | " + "Год написания: " + book.Year + " | " + "Страницы: " + book.BookSize + " | " + "Издательство: " + book.Publisher);
                    listBox.Update();
                }

            }
        }

        private void bookSizeTrackBar_Scroll(object sender, EventArgs e)
        {
            bookSizeLabel.Text = "Страницы (" + bookSizeTrackBar.Value.ToString() + ")";
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Версия 0.0.1\nЛощакова Мария", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm(library);
            search.Activate();
            search.Show();
        }

        private void nameLable_Click(object sender, EventArgs e)
        {

        }

        private void formatBox_Enter(object sender, EventArgs e)
        {

        }

        private void ulpDatePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime datefloor = Convert.ToDateTime("01/01/1900");
            DateTime dateceiling = Convert.ToDateTime("01/01/2024");
            if (ulpDatePicker.Value > dateceiling || ulpDatePicker.Value < datefloor)
            {
                MessageBox.Show("Неправильная дата!");
            }
        }

        private void btnHideShowMenu_Click(object sender, EventArgs e)
        {
            if (menuStrip1.Visible)
            {
                menuStrip1.Visible = false;
            }
            else
            {
                menuStrip1.Visible = true;
            }
        }

        private void очиститьПолеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
        }
    }
}