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

namespace LIBRARYMANAGEMENTPART2
{
    /// <summary>
    /// Interaction logic for BorrowersBorrowedBooks.xaml
    /// </summary>
    public partial class BorrowersBorrowedBooks : Window
    {
        public BorrowersBorrowedBooks()
        {
            InitializeComponent();
            
            DatePickerSelectedDateReturn.IsEnabled = false;

            TextBlockDaysExceeded.Text = "0";
            TextBlockTotalFines.Text = "0.00";
            if (ViewModelLocator.MAINVIEWMODEL.SelectedBorrower.BorrowerType == "Student")
            {
                TextBlockFinePerExceedDay.Text = "20.00";
            }
            else
            {
                TextBlockFinePerExceedDay.Text = "30.00";
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DatePickerSelectedDateReturn_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            int days = 0;
            bool oops = false;

            if (DatePickerSelectedDateReturn.SelectedDate <= ViewModelLocator.MAINVIEWMODEL.SelectedReturnBook.BookDateDeadline)
            {
                TextBlockDaysExceeded.Text = "0";
                TextBlockTotalFines.Text = "0.00";
            }
            else
            {
                do
                {
                    days++;
                    if (ViewModelLocator.MAINVIEWMODEL.SelectedReturnBook.BookDateDeadline.AddDays(days) == DatePickerSelectedDateReturn.SelectedDate)
                    {
                        oops = true;
                    }
                }
                while (oops == false);

                TextBlockDaysExceeded.Text = days.ToString();
                TextBlockTotalFines.Text = (1.00 * days * double.Parse(TextBlockFinePerExceedDay.Text)).ToString() + ".00";
            }
        }

        private void ButtonReturnBook_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModelLocator.MAINVIEWMODEL.SelectedReturnBook == null)
            {
                MessageBox.Show("select a book to return");
            }
            else
            {
                if (DatePickerSelectedDateReturn.SelectedDate == null)
                {
                    MessageBox.Show("Select a date when to return");
                }
                else
                {
                    if (TextBlockTotalFines.Text != "0.00")
                    {
                        ViewModelLocator.MAINVIEWMODEL.FinedViolators();
                    }
                    DialogResult = true;
                }
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewModelLocator.MAINVIEWMODEL.SelectedReturnBook != null)
            {
                DatePickerSelectedDateReturn.IsEnabled = true;
                DatePickerSelectedDateReturn.DisplayDateStart = ViewModelLocator.MAINVIEWMODEL.SelectedReturnBook.BookDateBorrowed;
            }
        }
    }
}
