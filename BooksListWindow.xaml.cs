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
    /// Interaction logic for BooksListWindow.xaml
    /// </summary>
    public partial class BooksListWindow : Window
    {
        public BooksListWindow()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonDeleteBook_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.DeleteBook();
        }

        private void ButtonDefaultSort_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Clear();
            RadioButtonCategoryAscending.IsChecked = false;
            RadioButtonCategoryDescending.IsChecked = false;
            RadioButtonIDNumberAscending.IsChecked = false;
            RadioButtonIDNumberDescending.IsChecked = false;
            RadioButtonTitleAscending.IsChecked = false;
            RadioButtonTitleDescending.IsChecked = false;
        }

        private void RadioButtonTitleAscending_Checked(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Add(new SortDescription("BookTitle", ListSortDirection.Ascending));
        }

        private void RadioButtonTitleDescending_Checked(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Add(new SortDescription("BookTitle", ListSortDirection.Descending));
        }

        private void RadioButtonCategoryAscending_Checked(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Add(new SortDescription("BookCategory", ListSortDirection.Ascending));
        }

        private void RadioButtonCategoryDescending_Checked(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Add(new SortDescription("BookCategory", ListSortDirection.Descending));
        }

        private void RadioButtonIDNumberAscending_Checked(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Add(new SortDescription("BookIDNumber", ListSortDirection.Ascending));
        }

        private void RadioButtonIDNumberDescending_Checked(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Add(new SortDescription("BookIDNumber", ListSortDirection.Descending));
        }
    }
}
