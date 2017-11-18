using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace LIBRARYMANAGEMENTPART2
{
    public class Book: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string BookTitle { get; set; }
        public string BookCategory { get; set; }
        public int BookIDNumber { get; set; }
        public string bookavailability;
        public string BookAvailability
        {
            get { return bookavailability; }
            set { bookavailability = value; OnPropertyChanged("BookAvailability"); }
        }
        public DateTime BookDateBorrowed { get; set; }
        public DateTime BookDateDeadline { get; set; }
        public DateTime BookDateReturn { get; set; }
        private ObservableCollection<Author> BookAuthor = new ObservableCollection<Author>();
        public ObservableCollection<Author> BOOKAUTHOR
        {
            get { return BookAuthor; }
            set { BookAuthor = value; }
        }

        public Book() { }

        //public Book(string title, string category, int id, string availability)
        //{
        //    BookTitle = title;
        //    BookCategory = category;
        //    BookIDNumber = id;
        //    BookAvailability = availability;
        //}
    }

    public class Borrower: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _borrowertype;
        public string BorrowerType
        {
            get { return _borrowertype; }
            set { _borrowertype = value; OnPropertyChanged("BorrowerType"); }
        }
        public string _borrowerfirstname;
        public string BorrowerFirstName
        {
            get { return _borrowerfirstname; }
            set { _borrowerfirstname = value; OnPropertyChanged("BorrowerFirstName"); }
        }
        public string _borrowerlastname;
        public string BorrowerLastName
        {
            get { return _borrowerlastname; }
            set { _borrowerlastname = value; OnPropertyChanged("BorrowerLastName"); }
        }
        public string _borrowergender;
        public string BorrowerGender
        {
            get { return _borrowergender; }
            set { _borrowergender = value; OnPropertyChanged("BorrowerGender"); }
        }
        public int _borroweridnumber;
        public int BorrowerIDNumber
        {
            get { return _borroweridnumber; }
            set { _borroweridnumber = value; OnPropertyChanged("BorrowerIDNumber"); }
        }
        public string _borrowercheckborrowingbooks;
        public string BorrowerCheckBorrowingBooks
        {
            get { return _borrowercheckborrowingbooks; }
            set { _borrowercheckborrowingbooks = value; OnPropertyChanged("BorrowerCheckBorrowingBooks"); }
        }
        private ObservableCollection<Book> BorrowerBooksBorrowed = new ObservableCollection<Book>();
        public ObservableCollection<Book> BORROWERBOOKSBORROWED
        {
            get { return BorrowerBooksBorrowed; }
            set { BorrowerBooksBorrowed = value; }
        }

        public Borrower() { }

        public Borrower(string lastname, string firtsname, string gender, string type, int id, string checkborrowing)
        {
            BorrowerLastName = lastname;
            BorrowerFirstName = firtsname;
            BorrowerGender = gender;
            BorrowerType = type;
            BorrowerIDNumber = id;
            BorrowerCheckBorrowingBooks = checkborrowing;
        }

        public override string ToString()
        {
            return BorrowerLastName+", "+BorrowerFirstName;
        }
    }
    public class Author
    {
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }

        public Author() { }

        public Author(string lastname, string firstname)
        {
            AuthorLastName = lastname;
            AuthorFirstName = firstname;
        }

        public override string ToString()
        {
            return AuthorLastName+", "+AuthorFirstName;
        }
    }

    public class Violator
    {
        public string ViolatorFirstName { get; set; }
        public string ViolatorLastName { get; set; }
        public int ViolatorTotalFine { get; set; }
        public DateTime ViolatorDateFined { get; set; }

        public Violator() { }

        public override string ToString()
        {
            return ViolatorLastName+", "+ViolatorFirstName;
        }
    }

    public enum Availability
    {
        AVAILABLE,
        UNAVAILABLE
    }
}
