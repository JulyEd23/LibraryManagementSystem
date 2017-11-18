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
    /// Interaction logic for EditBorrowerWindow.xaml
    /// </summary>
    public partial class EditBorrowerWindow : Window
    {
        public EditBorrowerWindow()
        {
            InitializeComponent();
            TextBlockIDNumber.Text = ViewModelLocator.MAINVIEWMODEL.SelectedBorrower.BorrowerIDNumber.ToString();

            if(ViewModelLocator.MAINVIEWMODEL.SelectedBorrower.BorrowerGender == "Male")
            {
                RadioButtonMale.IsChecked = true;
            }
            else
            {
                RadioButtonFemale.IsChecked = true;
            }
            if(ViewModelLocator.MAINVIEWMODEL.SelectedBorrower.BorrowerType == "Student")
            {
                RadioButtonStudent.IsChecked = true;
            }
            else
            {
                RadioButtonTeacher.IsChecked = true;
            }
        }

        private void ButtonSaveEditBorrower_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void ButtonEditBorrowerWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RadioButtonMale_Checked(object sender, RoutedEventArgs e)
        {
            if(RadioButtonMale.IsChecked == true)
            {
                ViewModelLocator.MAINVIEWMODEL.editborrower.BorrowerGender = "Male";
            }
        }

        private void RadioButtonFemale_Checked(object sender, RoutedEventArgs e)
        {
            if(RadioButtonFemale.IsChecked == true)
            {
                ViewModelLocator.MAINVIEWMODEL.editborrower.BorrowerGender = "Female";
            }
        }

        private void RadioButtonStudent_Checked(object sender, RoutedEventArgs e)
        {
            if(RadioButtonStudent.IsChecked == true)
            {
                ViewModelLocator.MAINVIEWMODEL.editborrower.BorrowerType = "Student";
            }
        }

        private void RadioButtonTeacher_Checked(object sender, RoutedEventArgs e)
        {
            if(RadioButtonTeacher.IsChecked == true)
            {
                ViewModelLocator.MAINVIEWMODEL.editborrower.BorrowerType = "Teacher";
            }
        }
    }
}
