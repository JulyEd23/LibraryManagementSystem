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
using System.Windows.Shapes;
using System.ComponentModel;

namespace LIBRARYMANAGEMENTPART2
{
    /// <summary>
    /// Interaction logic for FinesWindow.xaml
    /// </summary>
    public partial class FinesWindow : Window
    {
        public FinesWindow()
        {
            InitializeComponent();

            int total = 0;

            for(int a = 0; a<ViewModelLocator.MAINVIEWMODEL.VIOLATORSLIST.Count;a++)
            {
                total = total + ViewModelLocator.MAINVIEWMODEL.VIOLATORSLIST[a].ViolatorTotalFine;
            }
            TextBlockTotalFine.Text = total.ToString() + ".00";
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LastNameAscending_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewviolators.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewviolators.SortDescriptions.Add(new SortDescription("ViolatorLastName", ListSortDirection.Ascending));
        }

        private void LastNameDescending_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewviolators.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewviolators.SortDescriptions.Add(new SortDescription("ViolatorLastName", ListSortDirection.Descending));
        }

        private void FirstNameAscending_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewviolators.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewviolators.SortDescriptions.Add(new SortDescription("ViolatorFirstName", ListSortDirection.Ascending));
        }

        private void FirstNameDescending_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewviolators.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewviolators.SortDescriptions.Add(new SortDescription("ViolatorFirstName", ListSortDirection.Descending));
        }

        private void DateFinedAscending_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewviolators.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewviolators.SortDescriptions.Add(new SortDescription("ViolatorDateFined", ListSortDirection.Ascending));
        }

        private void DateFinedDescending_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewviolators.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewviolators.SortDescriptions.Add(new SortDescription("ViolatorDateFined", ListSortDirection.Descending));
        }

        private void FineAscending_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewviolators.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewviolators.SortDescriptions.Add(new SortDescription("ViolatorTotalFine", ListSortDirection.Ascending));
        }

        private void FineDescending_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewviolators.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewviolators.SortDescriptions.Add(new SortDescription("ViolatorTotalFine", ListSortDirection.Descending));
        }
    }
}
