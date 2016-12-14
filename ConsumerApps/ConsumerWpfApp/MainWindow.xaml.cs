using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Commons.Utility;

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
            tabControl.SelectionChanged += TabControl_SelectionChanged;

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabControl.SelectedIndex==0)
            {
                var x = "test";
            }
            else
            {
                DetailsGrid.Children.Clear();
                var list1 = Enum.GetNames(typeof(DayOfWeek)).ToList().Select(x => new { Name = x, Value = x }).ToList();
                var list = new ObservableCollection<dynamic>(list1);
                var comboBox = CreateComboBox("test", 1, 3);
                comboBox.ItemsSource = list;
                comboBox.DisplayMemberPath = "Name";
                comboBox.SelectedValuePath = "Value";
                comboBox.SelectedIndex = 0;
                comboBox.SelectionChanged += Box1_SelectionChanged;
                DetailsGrid.Children.Add(comboBox);
            }
        }

        private void Box1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox c = sender as ComboBox;
            var d = e.AddedItems[0] as dynamic;
            int i = c.SelectedIndex;            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var d = DateTime.Now;
        }


        public static ComboBox CreateComboBox(string x, int columnIndex, int rowIndex)
        {
            var element = new ComboBox()
            {
                Name = x + "ComboBox",
                Margin = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };
            Grid.SetColumn(element, columnIndex);
            Grid.SetRow(element, rowIndex);
            return element;
        }
    }
}
