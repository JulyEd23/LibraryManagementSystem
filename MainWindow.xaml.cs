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
using System.ComponentModel;

namespace LIBRARYMANAGEMENTPART2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModelLocator.MAINVIEWMODEL;
        }

        private void ButtonExitProgram_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAddBorrower_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.AddBorrower();
        }

        private void ButtonAddBook_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.AddBook();
        }

        private void ButtonDeleteBorrower_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModelLocator.MAINVIEWMODEL.SelectedBorrower.BORROWERBOOKSBORROWED.Count > 0)
            {
                MessageBox.Show("Borrower cannot be delete unless the borrower return all the books that he/she borrowed");
            }
            else
            {
                ViewModelLocator.MAINVIEWMODEL.BORROWERSLIST.Remove(ViewModelLocator.MAINVIEWMODEL.SelectedBorrower);
            }
        }

        private void ButtonEditBorrower_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.EditBorrower();
        }

        private void ButtonBorrowBook_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModelLocator.MAINVIEWMODEL.SelectedBorrower != null)
            {
                ViewModelLocator.MAINVIEWMODEL.BorrowBook();
            }
            else
            {
                MessageBox.Show("PLEASE SELECT A BORROWER TO PROCEED BORROWING BOOKS");
            }
        }

        private void ButtonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.AddCategory();
        }

        private void ButtonReturnBook_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.ReturnBook();
        }

        private void ButtonFines_Click(object sender, RoutedEventArgs e)
        {
            var finewindow = new FinesWindow();
            finewindow.DataContext = ViewModelLocator.MAINVIEWMODEL;
            finewindow.ShowDialog();
        }

        private void RadioButtonIDNumberAscending_Checked(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewborrowers.SortDescriptions.Clear();
            RadioButtonFirstNameAscending.IsChecked = false;
            RadioButtonFirstNameDescending.IsChecked = false;
            RadioButtonIDNumberDescending.IsChecked = false;
            RadioButtonLastNameAscending.IsChecked = false;
            RadioButtonLastNameDescending.IsChecked = false;
            ViewModelLocator.MAINVIEWMODEL.viewborrowers.SortDescriptions.Add(new SortDescription("BorrowerIDNumber",ListSortDirection.Ascending));
        }

        private void RadioButtonLastNameAscending_Checked(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewborrowers.SortDescriptions.Clear();
            RadioButtonFirstNameAscending.IsChecked = false;
            RadioButtonFirstNameDescending.IsChecked = false;
            RadioButtonIDNumberAscending.IsChecked = false;
            RadioButtonIDNumberDescending.IsChecked = false;
            RadioButtonLastNameDescending.IsChecked = false;
            ViewModelLocator.MAINVIEWMODEL.viewborrowers.SortDescriptions.Add(new SortDescription("BorrowerLastName", ListSortDirection.Ascending));
        }

        private void RadioButtonLastNameDescending_Checked(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewborrowers.SortDescriptions.Clear();
            RadioButtonFirstNameAscending.IsChecked = false;
            RadioButtonFirstNameDescending.IsChecked = false;
            RadioButtonIDNumberAscending.IsChecked = false;
            RadioButtonIDNumberDescending.IsChecked = false;
            RadioButtonLastNameAscending.IsChecked = false;
            ViewModelLocator.MAINVIEWMODEL.viewborrowers.SortDescriptions.Add(new SortDescription("BorrowerLastName", ListSortDirection.Descending));
            //RadioButtonFirstNameAscending.IsChecked = false;
            //RadioButtonFirstNameDescending.IsChecked = false;
            //RadioButtonIDNumberAscending.IsChecked = false;
            //RadioButtonIDNumberDescending.IsChecked = false;
            //nilo code // z
        }

        private void RadioButtonFirstNameAscending_Checked(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewborrowers.SortDescriptions.Clear();
            RadioButtonFirstNameDescending.IsChecked = false;
            RadioButtonIDNumberAscending.IsChecked = false;
            RadioButtonIDNumberDescending.IsChecked = false;
            RadioButtonLastNameAscending.IsChecked = false;
            RadioButtonLastNameDescending.IsChecked = false;
            ViewModelLocator.MAINVIEWMODEL.viewborrowers.SortDescriptions.Add(new SortDescription("BorrowerFirstName", ListSortDirection.Ascending));
        }

        private void RadioButtonFirstNameDescending_Checked(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewborrowers.SortDescriptions.Clear();
            RadioButtonFirstNameAscending.IsChecked = false;
            RadioButtonIDNumberAscending.IsChecked = false;
            RadioButtonIDNumberDescending.IsChecked = false;
            RadioButtonLastNameAscending.IsChecked = false;
            RadioButtonLastNameDescending.IsChecked = false;
            ViewModelLocator.MAINVIEWMODEL.viewborrowers.SortDescriptions.Add(new SortDescription("BorrowerFirstName", ListSortDirection.Descending));
        }

        private void RadioButtonIDNumberDescending_Checked(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewborrowers.SortDescriptions.Clear();
            RadioButtonFirstNameAscending.IsChecked = false;
            RadioButtonFirstNameDescending.IsChecked = false;
            RadioButtonIDNumberAscending.IsChecked = false;
            RadioButtonLastNameAscending.IsChecked = false;
            RadioButtonLastNameDescending.IsChecked = false;
            ViewModelLocator.MAINVIEWMODEL.viewborrowers.SortDescriptions.Add(new SortDescription("BorrowerIDNumber", ListSortDirection.Descending));
        }

        private void ButtonDefaultSort_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewborrowers.SortDescriptions.Clear();
            RadioButtonFirstNameAscending.IsChecked = false;
            RadioButtonFirstNameDescending.IsChecked = false;
            RadioButtonIDNumberAscending.IsChecked = false;
            RadioButtonIDNumberDescending.IsChecked = false;
            RadioButtonLastNameAscending.IsChecked = false;
            RadioButtonLastNameDescending.IsChecked = false;
        }

        private void ButtonBooksList_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.BooksListWindow();
        }
    }
}
