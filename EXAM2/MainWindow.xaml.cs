using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace EXAM2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            string constr = "Data Source=LAPTOP-JIVPNC40\\LOSCHAKOVA;Initial Catalog=CONSULTATION;Integrated Security";
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Progress", con);
                adapter.Fill(dt);
                con.Open();
                int average = 0;
                average = ((ToInt32(Text1.Text) + ToInt32(Text2.Text) + ToInt32(Text3.Text)) / 3);
                
            }
            void Button_Click(object sender, RoutedEventArgs e)
            {

            }
        }

        
    }
}
