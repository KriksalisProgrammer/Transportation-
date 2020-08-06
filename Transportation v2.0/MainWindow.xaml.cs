using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Transportation_v2._0.DataPerson;
using Transportation_v2._0.IO_service;

namespace Transportation_v2._0
{
    public static class DataGridTextSearch
    {

        public static readonly DependencyProperty SearchValueProperty =
            DependencyProperty.RegisterAttached("SearchValue", typeof(string), typeof(DataGridTextSearch),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.Inherits));

        public static string GetSearchValue(DependencyObject obj)
        {
            return (string)obj.GetValue(SearchValueProperty);
        }

        public static void SetSearchValue(DependencyObject obj, string value)
        {
            obj.SetValue(SearchValueProperty, value);
        }


        public static readonly DependencyProperty IsTextMatchProperty =
            DependencyProperty.RegisterAttached("IsTextMatch", typeof(bool), typeof(DataGridTextSearch), new UIPropertyMetadata(false));

        public static bool GetIsTextMatch(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsTextMatchProperty);
        }

        public static void SetIsTextMatch(DependencyObject obj, bool value)
        {
            obj.SetValue(IsTextMatchProperty, value);
        }
    }
    public class SearchValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string cellText = values[0] == null ? string.Empty : values[0].ToString();
            string searchText = values[1] as string;

            if (!string.IsNullOrEmpty(searchText) && !string.IsNullOrEmpty(cellText))
            {
                return cellText.ToLower().StartsWith(searchText.ToLower());
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
    public partial class MainWindow : Window
    {

        private readonly string _PATH = $"{Environment.CurrentDirectory}\\PersonModel.json";
        private BindingList<PersonTransportation> person;
        private IO IOfiles;

        public MainWindow()
        {
            InitializeComponent();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IOfiles = new IO(_PATH);
            try
            {
                person = IOfiles.LoadingData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            MainTable.ItemsSource = person;
            person.ListChanged += Person_ListChanged;

        }

        private void Person_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    IOfiles.SaveDate(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void MainTable_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
        }

        private void MainTable_Sorting(object sender, DataGridSortingEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
       

    }
}
