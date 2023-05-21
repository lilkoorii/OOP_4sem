using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AppAdo
{
    enum Tables { Student, Address, BOOKS, AUTHORS };
    enum PrimaryColumn { ID, Id, Book_Name };

    public partial class MainWindow : Window
    {
        int pageSize = 5;
        int pageNumber = 0;

        string currentTableName;
        string currentPrimaryColumnName;
        string connectionString;

        DataSet ds;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
        DataGrid currentGrid;
        // List<Image> images;

        SqlConnection thisConnection =
                       new SqlConnection(
                       ConfigurationManager.
                       ConnectionStrings["DefaultConnection"].
                       ConnectionString);

        public void createDatabase()
        {
            try
            {
                SqlConnection thisConnection =
                       new SqlConnection(
                       ConfigurationManager.
                       ConnectionStrings["DefaultConnection"].
                       ConnectionString);
            }
            catch (SqlException ex)
            {
                thisConnection.Open();
                SqlCommand cmd = new SqlCommand("Create database ELIBRARY", thisConnection);
                cmd.ExecuteNonQuery();
                SqlCommand command = thisConnection.CreateCommand();

                //ниже SQL-запросы на создание таблиц
                command.CommandText = "CREATE TABLE [dbo].[Student] (\r\n    [NAME]      NVARCHAR (50) NULL,\r\n    [SPECIALTY] NVARCHAR (20) NULL,\r\n    [AGE]       INT           NULL,\r\n    [BIRTHDAY]  DATE          NULL,\r\n    [COURSE]    INT           NULL,\r\n    [SEX]       CHAR (1)      NULL,\r\n    [AVGSCORE]  FLOAT (53)    NULL\r\n);";
                command.ExecuteNonQuery();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            currentTableName = "BOOKS";
            FillCurrentGrid();
        }

        private void BooksGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e) //ВАЛИДАЦИЯ
        {
            var editedTextbox = (TextBox)e.EditingElement;
            if (e.Column.Header.ToString() == "Название")
            {
                if (string.IsNullOrWhiteSpace(editedTextbox.Text))
                {
                    e.Cancel = true;
                    MessageBox.Show("Название должно быть строкой!");
                }
            }
            else if (e.Column.Header.ToString() == "Размер файла")
            {
                if ((int.TryParse(editedTextbox.Text, out int size) && size <= 0) || (!float.TryParse(editedTextbox.Text, out float fl)))
                {
                    e.Cancel = true;
                    MessageBox.Show("Размер файла не может быть меньше или равно нулю!");
                }
            }
           else if (e.Column.Header.ToString() == "Тип")
            {
                if (string.IsNullOrWhiteSpace(editedTextbox.Text))
                {
                    MessageBox.Show("Введите корректный тип файла! (FB2, PDF, EPUB и т.п.)");

                }
            }
            else if (e.Column.Header.ToString() == "УДК")
            {
                if (string.IsNullOrWhiteSpace(editedTextbox.Text) || !int.TryParse(editedTextbox.Text, out int udk))
                {
                    e.Cancel = true;
                    MessageBox.Show("Введите корректный УДК! (состоит из цифр)");

                }
            }
            else if (e.Column.Header.ToString() == "Страницы")
            {
                //if (Convert.ToDateTime(editedTextbox.Text) > DateTime.Now)
                if ((int.TryParse(editedTextbox.Text, out int str) && str <= 3) || (!int.TryParse(editedTextbox.Text, out int fl)))
                {
                    MessageBox.Show("Введите корректное количество страниц!");

                }
            }
            else if (e.Column.Header.ToString() == "Изд-ль")
            {
                if (string.IsNullOrWhiteSpace(editedTextbox.Text))
                {
                    e.Cancel = true;
                    MessageBox.Show("Введите издательство!");

                }
            }
            else if (e.Column.Header.ToString() == "Год изд-ва")
            {
                if ((Convert.ToInt32(editedTextbox.Text) < 1900) || (Convert.ToInt32(editedTextbox.Text) > 2023))
                {
                    MessageBox.Show("Введите корректный год издательства! (1900-2023)");

                }
            }
            else if ((e.Column.Header.ToString() == "ID автора") || (e.Column.Header.ToString() == "ID"))
            {
                if (string.IsNullOrWhiteSpace(editedTextbox.Text) || (!int.TryParse(editedTextbox.Text, out int parse)))
                {
                    MessageBox.Show("Введите корректный ID (содержит цифры)");

                }
            }
            else if (e.Column.Header.ToString() == "Дата загрузки")
            {
                if (Convert.ToDateTime(editedTextbox.Text) > DateTime.Now)
                {
                    MessageBox.Show("Введите корректную дату загрузки!");

                }
            }
            else if ((e.Column.Header.ToString() == "Имя") || (e.Column.Header.ToString() == "Фамилия") || (e.Column.Header.ToString() == "Отчество"))
            {
                if (string.IsNullOrWhiteSpace(editedTextbox.Text) || (int.TryParse(editedTextbox.Text, out int parse)))
                {
                    MessageBox.Show("Введите корректное ФИО! (не содержит цифр)");

                }
            }
            else if (e.Column.Header.ToString() == "Страна")
            {
                if (string.IsNullOrWhiteSpace(editedTextbox.Text) || (int.TryParse(editedTextbox.Text, out int parse)))
                {
                    MessageBox.Show("Введите корректную страну! (не содержит цифр)");

                }
            }
        }

            private void SaveButton_Click(object sender, RoutedEventArgs e)
            {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                   
                    try
                    {
                        SqlConnection thisConnection =   //попробовать открыть соединение по ConnectionString если есть БД
                               new SqlConnection(
                               ConfigurationManager.
                               ConnectionStrings["DefaultConnection"].
                               ConnectionString);
                        thisConnection.Open();
                    }
                    catch (SqlException ex)
                    {
                        thisConnection.Open();
                        SqlCommand cmd = new SqlCommand("Create database ELIBRARY", thisConnection); //создать новую БД если ее нет
                    }

                    this.adapter = new SqlDataAdapter(GetSql(), connection);
                    this.commandBuilder = new SqlCommandBuilder(this.adapter);


                    if (this.currentTableName == Tables.AUTHORS.ToString()) //заполняем адаптер данными из БД
                    {
                        this.adapter.InsertCommand = new SqlCommand("sp_InsertAuthors", connection) //sp_InsertAuthors - Хранимая процедура в БД
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 0, "ID"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50, "Name"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Surname", SqlDbType.NVarChar, 50, "Surname"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Lastname", SqlDbType.NVarChar, 50, "Lastname"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.NVarChar, 50, "Country"));

                    }
                    if (this.currentTableName == Tables.BOOKS.ToString())
                    {
                        this.adapter.InsertCommand = new SqlCommand("sp_InsertBooks", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Book_Name", SqlDbType.NVarChar, 100, "Book_Name"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@File_Size", SqlDbType.Float, 0, "File_Size"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Type", SqlDbType.NVarChar, 7, "Type"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@UDK", SqlDbType.Int, 0, "UDK"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Page_Quantity", SqlDbType.Int, 0, "Page_Quantity"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Publisher", SqlDbType.NVarChar, 30, "Publisher"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Publishing_Year", SqlDbType.Int, 0, "Publishing_Year"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Author_ID", SqlDbType.Int, 0, "Author_ID"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Upload_Time", SqlDbType.DateTime, 0, "Upload_Time"));

                    }
                    this.currentGrid.CanUserAddRows = false;
                    this.currentGrid.IsReadOnly = false;
                    this.adapter.Update(this.ds);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e) //добавление книги/автора
        {
            while (!(this.ds.Tables[0].Rows.Count < this.pageSize))
            {
                this.pageNumber++;
                GetPage();
            }
            this.currentGrid.CanUserAddRows = true;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) //обновление DataGrid-а
        {
            FillCurrentGrid();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) //навигация по страницам (NextButton - вперед)
        {
            if (this.pageNumber == 0)
            {
                return;
            }

            this.currentGrid.CanUserAddRows = false;
            this.pageNumber--;
            GetPage();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.ds.Tables[0].Rows.Count < this.pageSize)
            {
                return;
            }

            this.currentGrid.CanUserAddRows = false;
            this.pageNumber++;
            GetPage();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) //удалить книгу/автора
        {
            if (this.currentGrid.SelectedItems != null)
            {
                for (int i = this.currentGrid.SelectedItems.Count - 1; i >= 0; i--)
                {
                    if (this.currentGrid.SelectedItems[i] is DataRowView datarowView)
                    {
                        DataRow dataRow = datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
        }

        private void DescButton_Click(object sender, RoutedEventArgs e)
        {
            thisConnection.Open();
            SqlCommand cmd = new SqlCommand("Select * from BOOKS order by Page_Quantity desc", thisConnection); //Запрос, сортировать кол-во страниц по убыванию
            try
            {
                cmd.ExecuteNonQuery(); //пробуем выполнить SQL-запрос
                SortDescGrid();
                this.adapter.Update(this.ds);
                MessageBox.Show("Сортировка прошла успешно ", "Отсортировано", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                thisConnection.Close();
            }
        }

        public void SortDescGrid()  //сортируем и обновляем данные DataGrid-а
        {
            SqlCommand cmd = new SqlCommand("Select * from BOOKS order by Page_Quantity desc", thisConnection);
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            thisConnection.Close();
            BooksGrid.ItemsSource = dt.DefaultView;
        }

        private void AscButton_Click(object sender, RoutedEventArgs e) //сорт. по возрастанию через SQL-запрос
        {
            thisConnection.Open();
            SqlCommand cmd = new SqlCommand("Select * from BOOKS order by Page_Quantity asc", thisConnection);
            try
            {
                cmd.ExecuteNonQuery();
                SortAscGrid();
                this.adapter.Update(this.ds);
                MessageBox.Show("Сортировка прошла успешно ", "Отсортировано", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                thisConnection.Close();
            }
        }

        public void SortAscGrid()
        {
            SqlCommand cmd = new SqlCommand("Select * from BOOKS order by Page_Quantity asc", thisConnection);
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            thisConnection.Close();
            BooksGrid.ItemsSource = dt.DefaultView;
        }

        private void Image_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Image image = (Image)sender;
            PhotoViewer photoViewer = new PhotoViewer(image.Source)
            {
                Owner = this
            };
            photoViewer.Show();
        }

        private void MainTab_SelectionChanged(object sender, SelectionChangedEventArgs e) //меняем вкладку с таблицами (BOOKS на AUTHORS и наоборот)
        {
            try
            {
                TabItem item = (TabItem)this.mainTab.SelectedItem;
                if (this.currentTableName != item.Header.ToString())
                {
                    this.currentTableName = item.Header.ToString();

                    if (this.currentTableName == Tables.AUTHORS.ToString())
                    {
                        this.currentGrid = this.AuthorsGrid;
                        this.currentPrimaryColumnName = PrimaryColumn.ID.ToString();
                    }
                    if (this.currentTableName == Tables.BOOKS.ToString())
                    {
                        this.currentGrid = this.BooksGrid;
                        this.currentPrimaryColumnName = PrimaryColumn.Book_Name.ToString();
                    }
                    this.pageNumber = 0;
                    FillCurrentGrid();
                }
            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        private string GetSql() //запрос для получения строк из БД на странице
        {
            return "SELECT * FROM " + this.currentTableName + " ORDER BY " + this.currentPrimaryColumnName + " OFFSET ((" + this.pageNumber + ") * " + this.pageSize + ") " +
                "ROWS FETCH NEXT " + this.pageSize + " ROWS ONLY";
        }

        private void GetPage()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    this.adapter = new SqlDataAdapter(GetSql(), connection);
                    this.ds.Tables[0].Rows.Clear();
                    this.adapter.Fill(this.ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        private void FillCurrentGrid() //заполнение DataGrid-а данными
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(GetSql(), connection);

                ds = new DataSet();
                adapter.Fill(ds);
                currentGrid.ItemsSource = ds.Tables[0].DefaultView;

                //Создать комманду для соединения
                SqlCommand getCommand =
                connection.CreateCommand();
                //Специфицировать запрос SQL для команды
                getCommand.CommandText =
                "SELECT * from BOOKS";
                //Выполить команду и получить данные
                SqlDataReader thisReader =
                getCommand.ExecuteReader();
                while (thisReader.Read())  //по колонкам получаем значения в ListBox (для разработки, можно игнорить)
                {
                    string itemText = (string)thisReader.GetValue(0) +
                      " | " +
                      (double)thisReader.GetValue(1) +
                      " | " +
                      (string)thisReader.GetValue(2) +
                      " | " +
                      (int)thisReader.GetValue(3) +
                      " | " +
                      (int)thisReader.GetValue(4) +
                      " | " +
                      (string)thisReader.GetValue(5) +
                      " | " +
                      (int)thisReader.GetValue(6) +
                      " | " +
                      (int)thisReader.GetValue(7) +
                      " | " +
                      (DateTime)thisReader.GetValue(8);

                    rezult.Items.Insert(0, itemText);
                }
                //закрыть читатель
                thisReader.Close();/*
                //закрыть соединение
                connection.Close();*/
                this.currentGrid.IsReadOnly = false;
                // транзакция
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;      //транзакция
                try
                {
                    command.CommandText = "select * from BOOKS";
                    command.ExecuteNonQuery();
                    command.CommandText = "Delete from BOOKS where Page_Quantity = 200";
                    command.ExecuteNonQuery();
                    //command.CommandText = "Insert into BOOKS values ('Книга2', 13.6, 'PDF', 12348, 250, 'Роскнига', 2020, 11112, 05/05/2020)"; //выдаст ошибку транзакции, т.к. Книга2 уже есть
                    //command.ExecuteNonQuery();

                    transaction.Commit();

                }
                catch (Exception ex)  //откат транзакции в случае ошибки
                {
                    MessageBox.Show(ex.Message);
                    transaction.Rollback();
                }

                thisConnection.Close();
            }
        }
    }
}
