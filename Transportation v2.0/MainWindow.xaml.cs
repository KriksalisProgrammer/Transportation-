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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            PersonTransportation p = e.Item as PersonTransportation;
            if(p!=null)
            {
               
            }
        }

        private void MainTable_Sorting(object sender, DataGridSortingEventArgs e)
        {

        }
    }
}
