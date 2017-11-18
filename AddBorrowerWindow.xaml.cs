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
    /// Interaction logic for AddBorrowerWindow.xaml
    /// </summary>
    public partial class AddBorrowerWindow : Window
    {
        public AddBorrowerWindow()
        {
            InitializeComponent();
            bool oops;

            do
            {
                oops = false;
                Random r = new Random();
                int a = r.Next(0,2);
                int b = r.Next(0, 2);
                int c = r.Next(0, 10);
                int d = r.Next(0, 10);
                int e = r.Next(0, 10);

                for (int i = 0; i < ViewModelLocator.MAINVIEWMODEL.BORROWERSLIST.Count;i++)
                {
                    if(ViewModelLocator.MAINVIEWMODEL.BORROWERSLIST[i].BorrowerIDNumber == int.Parse(a.ToString()+b.ToString() + c.ToString() + d.ToString() + e.ToString()))
                    {
                        oops = true;
                        break;
                    }
                }
                if(oops == false)
                {
                    TextBlockIDNumber.Text = a.ToString() + b.ToString() + c.ToString() + d.ToString() + e.ToString();
                }
            }
            while (oops == true);
        }

        private void ButtonAddBorrowerWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RadioButtonMale_Checked(object sender, RoutedEventArgs e)
        {
            if(RadioButtonMale.IsChecked == true)
            {
                ViewModelLocator.MAINVIEWMODEL.gender = "Male";
            }
        }

        private void RadioButtonFemale_Checked(object sender, RoutedEventArgs e)
        {
            if (RadioButtonFemale.IsChecked == true)
            {
                ViewModelLocator.MAINVIEWMODEL.gender = "Female";
            }
        }

        private void RadioButtonStudent_Checked(object sender, RoutedEventArgs e)
        {
            if(RadioButtonStudent.IsChecked == true)
            {
                ViewModelLocator.MAINVIEWMODEL.type = "Student";
            }
        }

        private void RadioButtonTeacher_Checked(object sender, RoutedEventArgs e)
        {
            if(RadioButtonTeacher.IsChecked == true)
            {
                ViewModelLocator.MAINVIEWMODEL.type = "Teacher";
            }
        }

        private void ButtonAddBorrower_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
