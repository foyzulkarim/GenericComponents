using System;
using System.Collections.Generic;
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
using ApplicationLibrary.Models.Students;

namespace ConsumerWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGrid();
        }

        private async Task LoadGrid()
        {
            StudentRequestModel r = new StudentRequestModel();
            var result = await AppFactory.StudentService.SearchAsync(r);
            dataGrid.ItemsSource = result.Item1.OfType<object>().ToList().ConvertToViewableDynamicList();
        }
    }
}
