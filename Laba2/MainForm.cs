using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace Laba2
{
    public partial class MainForm : Form
    {
        Library library = new Library("Библиотека имени Рекардо Милоса");

        public MainForm()
        {
            InitializeComponent();
        }

        private void loadInFile_Click(object sender, EventArgs e)
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
                    listBox.Items.Add("Название: " + book.Name + " | " + "Автор: " + book.Author);
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
            float fileSize = 5000;
            // проверка воодимых данных
            if (string.IsNullOrEmpty(inputNameField.Text) || string.IsNullOrEmpty(inputAuthorField.Text) ||
                string.IsNullOrEmpty(inputYearField.Text) || string.IsNullOrEmpty(inputPublisherField.Text) ||
                string.IsNullOrEmpty(inputFileSizeField.Text))
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(inputYearField.Text, out year) || !float.TryParse(inputFileSizeField.Text, out fileSize))
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

                BookFile book = new BookFile(inputNameField.Text, inputAuthorField.Text, int.Parse(inputYearField.Text),
                bookSizeTrackBar.Value, inputPublisherField.Text, format, int.Parse(inputFileSizeField.Text), System.DateTime.Now);
                library.AddBook(book);
                listBox.Items.Add("Название: " + book.Name + " | " + "Автор: " + book.Author);
                listBox.Update();
            }
        }

        private void bookSizeTrackBar_Scroll(object sender, EventArgs e)
        {
            bookSizeLabel.Text = "Book size (" + bookSizeTrackBar.Value.ToString() + ")";
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version: 0.8.3\nMarkovsky Artemy.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm(library);
            searchForm.Activate();
            searchForm.Show();
        }
    }
}