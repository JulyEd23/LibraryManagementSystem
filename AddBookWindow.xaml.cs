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
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();
            int[] numbers = new int[] {1,2,3,4,5,6,7,8,9,10};
            ComboBoxNoofCopies.ItemsSource = numbers;
        }

        private void ComboBoxNoofCopies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModelLocator.MAINVIEWMODEL.bookid.Clear();
            Random r = new Random();
            for (int i = 0; i<int.Parse(ComboBoxNoofCopies.SelectedItem.ToString()); i++)
            {
                bool oops;
                do
                {
                    oops = false;
                    int a = r.Next(0, 10);
                    int b = r.Next(0, 10);
                    int c = r.Next(0, 10);
                    int d = r.Next(0, 10);
                    int f = r.Next(0, 10);

                    for (int x = 0; x < ViewModelLocator.MAINVIEWMODEL.BOOKSLIST.Count; x++)
                    {
                        if (ViewModelLocator.MAINVIEWMODEL.BOOKSLIST[x].BookIDNumber == int.Parse(a.ToString() + b.ToString() + c.ToString() + d.ToString() + f.ToString()))
                        {
                            oops = true;
                            break;
                        }
                    }
                    if (oops == false)
                    {
                        ViewModelLocator.MAINVIEWMODEL.bookid.Add(int.Parse(a.ToString() + b.ToString() + c.ToString() + d.ToString() + f.ToString()));
                    }
                }
                while (oops == true);
            }
        }

        private void ButtonAddBook_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void ButtonDeleteAuthor_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModelLocator.MAINVIEWMODEL.selectedauthor == null)
            {
                MessageBox.Show("Select an author to delete");
            }
            else
            {
                ViewModelLocator.MAINVIEWMODEL.DeleteBookAuthor();
            }
        }

        private void ButtonAddAuthor_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxAuthorFirstName.Text == "" || TextboxAuthorLastName.Text == "")
            {
                MessageBox.Show("Kindly fill all  the blanks about the author's name");
            }
            else
            {
                ViewModelLocator.MAINVIEWMODEL.AddBookAuthor();
                ViewModelLocator.MAINVIEWMODEL.authorfirstname = null;
                ViewModelLocator.MAINVIEWMODEL.authorlastname = null;
                TextBoxAuthorFirstName.Text = "";
                TextboxAuthorLastName.Text = "";
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
