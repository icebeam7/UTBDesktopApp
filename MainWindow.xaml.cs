using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using UTBDesktopApp.Models;
using UTBDesktopApp.Services;

namespace UTBDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string endpoint = "api/students/All";
        DbService dbs;

        public MainWindow()
        {
            InitializeComponent();

            dbs = new DbService();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        // change 3
        async Task LoadData()
        {
            var students = await dbs.GetAll<Student>(endpoint);
            dgStudents.ItemsSource = new ObservableCollection<Student>(students);
        }

        // change 4
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadData();
        }
    }
}