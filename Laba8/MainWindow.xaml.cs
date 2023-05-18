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

namespace Laba8
{
    enum Tables { Student, Address };
    enum PrimaryColumn { ID, Id };

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

        public MainWindow()
        {
            InitializeComponent();
            this.connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillCurrentGrid();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    this.adapter = new SqlDataAdapter(GetSql(), connection);
                    this.commandBuilder = new SqlCommandBuilder(this.adapter);

                    if (this.currentTableName == Tables.Student.ToString())
                    {
                        this.adapter.InsertCommand = new SqlCommand("sp_InsertStudent", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@NAME", SqlDbType.NVarChar, 100, "NAME"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@SPECIALITY", SqlDbType.NVarChar, 200, "SPECIALITY"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@AGE", SqlDbType.Int, 0, "AGE"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@BIRTHDAY", SqlDbType.Date, 0, "BIRTHDAY"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@COURSE", SqlDbType.Int, 0, "COURSE"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@SEX", SqlDbType.Char, 1, "SEX"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@AVGSCORE", SqlDbType.Float, 0, "AVGSCORE"));
                    }

                    if (this.currentTableName == Tables.Address.ToString())
                    {
                        this.adapter.InsertCommand = new SqlCommand("sp_InsertAddress", connection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int, 0, "StudentID"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Town", SqlDbType.NVarChar, 20, "Town"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Index", SqlDbType.Int, 0, "Index"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Street", SqlDbType.NVarChar, 30, "Street"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@House", SqlDbType.Int, 0, "House"));
                        this.adapter.InsertCommand.Parameters.Add(new SqlParameter("@Flat", SqlDbType.Int, 0, "Flat"));

                    }

                    this.currentGrid.CanUserAddRows = false;
                    this.adapter.Update(this.ds);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            while (!(this.ds.Tables[0].Rows.Count < this.pageSize))
            {
                this.pageNumber++;
                GetPage();
            }
            this.currentGrid.CanUserAddRows = true;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            FillCurrentGrid();
            this.currentGrid.CanUserAddRows = false;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
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

        private void Image_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Image image = (Image)sender;
            PhotoViewer photoViewer = new PhotoViewer(image.Source)
            {
                Owner = this
            };
            photoViewer.Show();
        }

        private void MainTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TabItem item = (TabItem)this.mainTab.SelectedItem;
                if (this.currentTableName != item.Header.ToString())
                {
                    this.currentTableName = item.Header.ToString();

                    if (this.currentTableName == Tables.Student.ToString())
                    {
                        this.currentGrid = this.StudentGrid;
                        this.currentPrimaryColumnName = PrimaryColumn.ID.ToString();
                    }
                    if (this.currentTableName == Tables.Address.ToString())
                    {
                        this.currentGrid = this.AddressGrid;
                        this.currentPrimaryColumnName = PrimaryColumn.Id.ToString();
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

        private string GetSql()
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

        private void FillCurrentGrid()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(GetSql(), connection);

                ds = new DataSet();
                adapter.Fill(ds);
                currentGrid.ItemsSource = ds.Tables[0].DefaultView;

                // транзакция
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "select * from Student";
                    command.ExecuteNonQuery();

                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    transaction.Rollback();
                }
            }
        }
    }
}
