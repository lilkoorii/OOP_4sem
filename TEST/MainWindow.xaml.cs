using System;
using System.Collections.Generic;
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
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace TEST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = "Data Source=LAPTOP-JIVPNC40\\LOSCHAKOVA;Initial Catalog=CONSULTATION;Integrated Security=True";

        public MainWindow()
        {
            InitializeComponent();

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                DataTable ds = new DataTable();
                SqlCommand cmd = new SqlCommand(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM STUDENTS", connectionString);
                con.Open();
                adapter.Fill(ds);
                dataGrid.ItemsSource = ds.AsDataView();
                dataGrid.CanUserAddRows = true;
                con.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    DataTable ds = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM STUDENTS", connectionString);
                    adapter.InsertCommand = new SqlCommand("ParamProcedureInsert", con);
                    // это будет хранимая процедура
                    adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                    adapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@ID", SqlDbType.UniqueIdentifier, 38, "ID"));
                    adapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@Name", SqlDbType.NVarChar, 50, "Name"));
                    adapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@Surname", SqlDbType.NVarChar, 50, "Surname"));

                    adapter.Update(ds);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка");
            }
            finally
            {
                MessageBox.Show("Успешно сохранено");
            }
        }
    }
}
