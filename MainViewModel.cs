using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;

namespace LIBRARYMANAGEMENTPART2
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            viewborrowers = CollectionViewSource.GetDefaultView(BORROWERSLIST);
            viewbooks = CollectionViewSource.GetDefaultView(BOOKSLIST);
            viewviolators = CollectionViewSource.GetDefaultView(VIOLATORSLIST);

            BOOKCATEGORIES.Add("Math");
            BOOKCATEGORIES.Add("Science");
            BOOKCATEGORIES.Add("Religion");
            BOOKCATEGORIES.Add("Arts");
            BOOKCATEGORIES.Add("History");
            BOOKCATEGORIES.Add("English");
            BOOKCATEGORIES.Add("Business");

            BORROWERSLIST.Add(new Borrower("Catubog","July","Male","Student",10293, CheckBorrowedBook.NONE.ToString()));
            BORROWERSLIST.Add(new Borrower("Libadisos", "Keiji", "Male", "Student", 62748, CheckBorrowedBook.NONE.ToString()));
            BORROWERSLIST.Add(new Borrower("Yamamoto", "Ryu", "Male", "Teacher", 81639, CheckBorrowedBook.NONE.ToString()));
            BORROWERSLIST.Add(new Borrower("Salazar", "Aprilyn", "Female", "Teacher", 72538, CheckBorrowedBook.NONE.ToString()));
            BORROWERSLIST.Add(new Borrower("Jaleco", "Rene", "Male", "Student", 13256, CheckBorrowedBook.NONE.ToString()));
            BORROWERSLIST.Add(new Borrower("Ottoman", "GG", "Male", "Teacher", 12345, CheckBorrowedBook.NONE.ToString()));
            BORROWERSLIST.Add(new Borrower("Ferraren", "Jiji", "Female", "Teacher", 37702, CheckBorrowedBook.NONE.ToString()));
            BORROWERSLIST.Add(new Borrower("Nursing", "Puti", "Female", "Student", 72635, CheckBorrowedBook.NONE.ToString()));
            BORROWERSLIST.Add(new Borrower("Saluage", "Angelito", "Male", "Teacher", 25363, CheckBorrowedBook.NONE.ToString()));
        }

        ////////////////////////////////////////////// ICOLLECTION ///////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        public ICollectionView viewborrowers;

        public ICollectionView viewbooks;

        public ICollectionView viewviolators;

        ////////////////////////////////////////////// SEARCH ///////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        private string _searchtextborrower;
        public string SearchTextBorrower
        {
            get { return _searchtextborrower; }
            set
            {
                _searchtextborrower = value;
                viewborrowers.Filter = FilterBorrower;
            }
        }
        private bool FilterBorrower(object o)
        {
            var item = o as Borrower;
            if(item == null)
            {
                return false;
            }
            else
            {
                return (item.BorrowerFirstName.ToLower().Contains(SearchTextBorrower.ToLower()) || item.BorrowerGender.ToLower().Contains(SearchTextBorrower.ToLower()) || item.BorrowerIDNumber.ToString().ToLower().Contains(SearchTextBorrower.ToLower()) || item.BorrowerLastName.ToLower().Contains(SearchTextBorrower.ToLower()) || item.BorrowerType.ToLower().Contains(SearchTextBorrower.ToLower()));
            }
        }


        private string _searchtextbooks;
        public string SearchTextBooks
        {
            get { return _searchtextbooks; }
            set
            {
                _searchtextbooks = value;
                viewbooks.Filter = FilterBooks;
            }
        }
        private bool FilterBooks(object o)
        {
            var item = o as Book;
            if(item == null)
            {
                return false;
            }
            else
            {
                return (item.BookCategory.ToLower().Contains(SearchTextBooks.ToLower())||item.BookIDNumber.ToString().Contains(SearchTextBooks.ToLower())||item.BookTitle.ToLower().Contains(SearchTextBooks.ToLower()));
            }
        }

        //////////////////////////////////////////// BOOKS ////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////

        public Book SelectedBook { get; set; }

        private ObservableCollection<Book> BooksList = new ObservableCollection<Book>();
        public ObservableCollection<Book> BOOKSLIST
        {
            get { return BooksList; }
            set { BooksList = value; }
        }

        public string title { get; set; }
        public string category { get; set; }
        public ObservableCollection<int> bookid { get; set; } = new ObservableCollection<int>();
        public string authorfirstname { get; set; }
        public string authorlastname { get; set; }
        public Author selectedauthor { get; set; }
        public ObservableCollection<Author> bookauthor { get; set; } = new ObservableCollection<Author>();

        public void AddBook()
        {
            var addbookwindow = new AddBookWindow();
            addbookwindow.DataContext = this;
            var result = addbookwindow.ShowDialog();
            if(result == true)
            {
                if (title == null | category == null | bookid.Count == 0 | bookauthor.Count == 0)
                {
                    MessageBox.Show("incomplete of filling up the information");
                }
                else
                {
                    for (int i = 0; i < bookid.Count; i++)
                    {
                        var newbook = new Book();
                        newbook.BookTitle = title;
                        newbook.BookCategory = category;
                        newbook.BookAvailability = Availability.AVAILABLE.ToString();
                        for (int a = 0; a < bookauthor.Count; a++)
                        {
                            newbook.BOOKAUTHOR.Add(bookauthor[a]);
                        }
                        newbook.BookIDNumber = bookid[i];
                        BOOKSLIST.Add(newbook);
                    }
                    MessageBox.Show("successfully added the book");
                }
                title = null;
                category = null;
                bookid.Clear();
                bookauthor.Clear();
            }
            else
            {
                title = null;
                category = null;
                bookid.Clear();
                bookauthor.Clear();
            }
        }

        public void ViewBooksList()
        {
            var bookslistwindow = new BooksListWindow();
            bookslistwindow.DataContext = this;
            bookslistwindow.ShowDialog();
        }

        public void AddBookAuthor()
        {
            bookauthor.Add(new Author(authorlastname, authorfirstname));
        }
        public void DeleteBookAuthor()
        {
            bookauthor.Remove(selectedauthor);
        }

        public DateTime bookdateborrowed { get; set; }

        public void BorrowBook()
        {
            var borrowbookwindow = new BorrowBooksWindow();
            borrowbookwindow.DataContext = this;
            var result = borrowbookwindow.ShowDialog();
            if(result == true)
            {
                SelectedBook.BookAvailability = Availability.UNAVAILABLE.ToString();
                SelectedBook.BookDateBorrowed = bookdateborrowed;
                if(SelectedBorrower.BorrowerType == "Student")
                {
                    SelectedBook.BookDateDeadline = SelectedBook.BookDateBorrowed.AddDays(7);
                    MessageBox.Show("Date Borrowed: " + SelectedBook.BookDateBorrowed.ToString("MMMM dd, yyyy") + "\n" + "Date Deadline: " + SelectedBook.BookDateDeadline.ToString("MMMM dd, yyyy"));
                }
                else
                {
                    SelectedBook.BookDateDeadline = SelectedBook.BookDateBorrowed.AddDays(14);
                    MessageBox.Show("Date Borrowed: " + SelectedBook.BookDateBorrowed.ToString("MMMM dd, yyyy") + "\n" + "Date Deadline: " + SelectedBook.BookDateDeadline.ToString("MMMM dd, yyyy"));
                }
                SelectedBorrower.BORROWERBOOKSBORROWED.Add(SelectedBook);
                if(SelectedBorrower.BORROWERBOOKSBORROWED.Count>0)
                {
                    SelectedBorrower.BorrowerCheckBorrowingBooks = CheckBorrowedBook.BORROWING.ToString();
                }
                SelectedBook = null;
            }
        }

        public void BooksListWindow()
        {
            var bookslistwindow = new BooksListWindow();
            bookslistwindow.DataContext = this;
            bookslistwindow.ShowDialog();
        }

        public void DeleteBook()
        {
            if (SelectedBook != null)
            {
                BOOKSLIST.Remove(SelectedBook);
                SelectedBook = null;
            }
            else
            {
                MessageBox.Show("Select a book to delete");
            }
        }

        ////////////////////////////////////////// BORROWER //////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////

        public Borrower SelectedBorrower { get; set; }

        public string lastname { get; set; }
        public string firstname { get; set; }
        public string gender { get; set; }
        public string type { get; set; }
        public int idnumber { get; set; }
        
        private ObservableCollection<Borrower> BorrowersList = new ObservableCollection<Borrower>();
        public ObservableCollection<Borrower> BORROWERSLIST
        {
            get { return BorrowersList; }
            set { BorrowersList = value; }
        }

        public void AddBorrower()
        {
            var addborrowerwindow = new AddBorrowerWindow();
            addborrowerwindow.DataContext = this;
            var result = addborrowerwindow.ShowDialog();
            if(result == true)
            {
                if (firstname == null | lastname == null | gender == null | type == null)
                {
                    MessageBox.Show("incomplete of filling up the information");
                }
                else
                {
                    BORROWERSLIST.Add(new Borrower(lastname, firstname, gender, type, idnumber, CheckBorrowedBook.NONE.ToString()));
                    MessageBox.Show("successfully added the borrower");
                }
                lastname = null;
                firstname = null;
                gender = null;
                type = null;
            }
            else
            {
                lastname = null;
                firstname = null;
                gender = null;
                type = null;
            }
        }
        public Borrower editborrower = new Borrower();
        public void EditBorrower()
        {
            var editborrowerwindow = new EditBorrowerWindow();

            editborrower.BorrowerLastName = SelectedBorrower.BorrowerLastName;
            editborrower.BorrowerFirstName = SelectedBorrower.BorrowerFirstName;
            editborrower.BorrowerGender = SelectedBorrower.BorrowerGender;
            editborrower.BorrowerType = SelectedBorrower.BorrowerType;

            editborrowerwindow.DataContext = editborrower;
            var result = editborrowerwindow.ShowDialog();
            if(result == true)
            {
                SelectedBorrower.BorrowerLastName = editborrower.BorrowerLastName;
                SelectedBorrower.BorrowerFirstName = editborrower.BorrowerFirstName;
                SelectedBorrower.BorrowerGender = editborrower.BorrowerGender;
                SelectedBorrower.BorrowerType = editborrower.BorrowerType;
            }
        }


        /////////////////////////////////////////// CATEGORY /////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////

        private ObservableCollection<string> BookCategories = new ObservableCollection<string>();
        public ObservableCollection<string> BOOKCATEGORIES
        {
            get { return BookCategories; }
            set { BookCategories = value; }
        }

        public string addcategory { get; set; }

        public void AddCategory()
        {
            var addcategorywindow = new AddCategoryWindow();
            addcategorywindow.DataContext = this;
            var result = addcategorywindow.ShowDialog();
            if(result == true)
            {
                BOOKCATEGORIES.Add(addcategory);
            }
        }

        public string selectedcategory { get; set; }

        public void DeleteCategory()
        {
            BOOKCATEGORIES.Remove(selectedcategory);
        }

        ///////////////////////////////////////////// RETURN ///////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////

        public Book SelectedReturnBook { get; set; }

        public void ReturnBook()
        {
            var returnbookwindow = new BorrowersBorrowedBooks();
            returnbookwindow.DataContext = this;
            var result = returnbookwindow.ShowDialog();
            if(result == true)
            {
                for(int a = 0;a< BOOKSLIST.Count; a++)
                {
                    if(BOOKSLIST[a].BookIDNumber == SelectedReturnBook.BookIDNumber)
                    {
                        BOOKSLIST[a].BookAvailability = Availability.AVAILABLE.ToString();
                        SelectedBorrower.BORROWERBOOKSBORROWED.Remove(SelectedReturnBook);
                        if (SelectedBorrower.BORROWERBOOKSBORROWED.Count > 0)
                        {
                            SelectedBorrower.BorrowerCheckBorrowingBooks = CheckBorrowedBook.BORROWING.ToString();
                        }
                        else if(SelectedBorrower.BORROWERBOOKSBORROWED.Count == 0)
                        {
                            SelectedBorrower.BorrowerCheckBorrowingBooks = CheckBorrowedBook.NONE.ToString();
                        }
                        SelectedReturnBook = null;
                        break;
                    }
                }
                MessageBox.Show("successfully returned the book");
            }
        }


        ////////////////////////////////////////////// VIOLATORS or FINES ///////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        private ObservableCollection<Violator> ViolatorsList = new ObservableCollection<Violator>();

        public ObservableCollection<Violator> VIOLATORSLIST
        {
            get { return ViolatorsList; }
            set { ViolatorsList = value; }
        }
        
        public DateTime violatordatefined { get; set; }
        public int violatorfine { get; set; }

        public void FinedViolators()
        {
            var newviolator = new Violator();
            newviolator.ViolatorLastName = SelectedBorrower.BorrowerLastName;
            newviolator.ViolatorFirstName = SelectedBorrower.BorrowerFirstName;
            newviolator.ViolatorDateFined = violatordatefined;
            newviolator.ViolatorTotalFine = violatorfine;

            VIOLATORSLIST.Add(newviolator);
        }
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        public enum Availability
        {
            AVAILABLE,
            UNAVAILABLE
        }

        public enum CheckBorrowedBook
        {
            NONE,
            BORROWING
        }

    }
}
