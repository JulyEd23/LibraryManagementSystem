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
    /// Interaction logic for BorrowBooksWindow.xaml
    /// </summary>
    public partial class BorrowBooksWindow : Window
    {
        public BorrowBooksWindow()
        {
            InitializeComponent();
        }

        private void ButtonBorrowBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ViewModelLocator.MAINVIEWMODEL.SelectedBook.BookAvailability == Availability.AVAILABLE.ToString())
                {
                    DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Book unavailable, cannot be borrow... Sorry");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Kindly select a book to borrow");
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DatePickerDateBorrowed.DisplayDateStart = DateTime.Now.Date;
            DatePickerDateBorrowed.SelectedDate = DateTime.Now.Date;
        }

        private void DatePickerDateBorrowed_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewModelLocator.MAINVIEWMODEL.SelectedBorrower.BorrowerType == "Student")
            {
                TextBlockDateDeadline.Text = DatePickerDateBorrowed.SelectedDate.Value.AddDays(7).ToShortDateString();
            }
            else
            {
                TextBlockDateDeadline.Text = DatePickerDateBorrowed.SelectedDate.Value.AddDays(14).ToShortDateString();
            }
        }

        private void TitleAscending_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Add(new SortDescription("BookTitle", ListSortDirection.Ascending));
        }

        private void TitleDescscending_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Add(new SortDescription("BookTitle", ListSortDirection.Descending));
        }

        private void CategoryAscending_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Add(new SortDescription("BookCategory", ListSortDirection.Ascending));
        }

        private void CategoryDescscending_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Add(new SortDescription("BookCategory", ListSortDirection.Descending));
        }

        private void IDNumberAscending_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Add(new SortDescription("BookIDNumber", ListSortDirection.Ascending));
        }

        private void IDNumberDescscending_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Clear();
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Add(new SortDescription("BookIDNumber", ListSortDirection.Descending));
        }

        private void DefaultSort_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.viewbooks.SortDescriptions.Clear();
        }
    }
}
