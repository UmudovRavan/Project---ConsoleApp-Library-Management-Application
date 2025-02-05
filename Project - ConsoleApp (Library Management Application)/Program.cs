using Project___ConsoleApp__Library_Management_Application_.Models;
using Project___ConsoleApp__Library_Management_Application_.Service.Implementation;
using Project___ConsoleApp__Library_Management_Application_.Service.Interface;

namespace Project___ConsoleApp__Library_Management_Application_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IBookService bookService = new BookService();
            IAuthorServices authorServices = new AuthorService();
            IBorrowerService borrowerService = new BorrowerService();
            ILoanService loanService = new LoanService();
            ILoanItemService loanItemService = new LoanItemServices();


            while (true)
            {
                Console.WriteLine("                            \nLibrary Management Application");
                Console.WriteLine("                            1 - Author actions");
                Console.WriteLine("                            2 - Book actions");
                Console.WriteLine("                            3 - Borrower actions");
                Console.WriteLine("                            4 - BorrowBook");
                Console.WriteLine("                            5 - ReturnBook ");
                Console.WriteLine("                            6 - En cox borrow olunan kitab");
                Console.WriteLine("                            7 - Kitabi gecikdiren Borrowerlerin listi");
                Console.WriteLine("                            8 - Hansi borrower indiye qeder borrow olunan kitablar");
                Console.WriteLine("                            9 - FilterBooksByTitle");
                Console.WriteLine("                            10 - FilterBooksByAuthor");
                Console.WriteLine("                            0-Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AuthorAction(authorServices);
                        break;
                    case "2":
                        BookAction(bookService);
                        break;
                    case "3":
                        BorrowerAction(borrowerService);
                        break;
                        case "6":
                        MostBorrowedBook(loanService);
                        break;
                    case "9":
                        Console.WriteLine("Enter book title");
                        string? title = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(title))
                        {
                            Console.WriteLine("Title connot be empty");
                            break;
                        }
                        var filterBook = FilterBooksByTitle(bookService,title.Trim());
                        break;

                }


            }
        }


        static void AuthorAction(IAuthorServices authorServices)
        {
            while (true)
            {
                Console.WriteLine("                         \nAuthor actions-Menu");
                Console.WriteLine("                           1 - Butun authorlarin siyahisi");
                Console.WriteLine("                           2 - Author yaratmaq");
                Console.WriteLine("                           3 - Author editlemek");
                Console.WriteLine("                           4 - Author silmek");
                Console.WriteLine("                           0-Exit");

                Console.WriteLine("                           Make your choice");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        foreach (var item in authorServices.GetAll())
                        {
                            Console.WriteLine($"ID:{item.Id},Name: {item.Name}");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Enter Name");
                        authorServices.Create(new Author
                        {
                            Name = Console.ReadLine(),
                            IsDeleted = false,
                            UpdateAt = DateTime.UtcNow.AddHours(4),
                            CreateTime = DateTime.UtcNow.AddHours(4)
                        });
                        break;
                    case "3":
                        Console.WriteLine("Update author,Enter author ID:");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("New Author name:");
                        authorServices.Update(id, new Author
                        {
                            Name = Console.ReadLine(),
                            IsDeleted = false,
                            UpdateAt = DateTime.UtcNow.AddHours(4),
                        });
                        break;
                    case "4":
                        Console.WriteLine("The ID you want to delete");
                        int delete = int.Parse(Console.ReadLine());
                        authorServices.Delete(delete);
                        Console.WriteLine($"{delete} is delete");
                        break;
                    case "0":
                        Console.WriteLine("Exit program");
                        return;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;


                }

            }
        }


        static void BookAction(IBookService bookService)
        {
            while (true)
            {
                Console.WriteLine("                         \nBook actions-Menu");
                Console.WriteLine("                          1 - Butun booklarin siyahisi");
                Console.WriteLine("                          2 - Book yaratmaq");
                Console.WriteLine("                          3 - Book editlemek");
                Console.WriteLine("                          4 - Book silmek");
                Console.WriteLine("                          0-Exit");

                Console.WriteLine("Make your choice");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        foreach (var item in bookService.GetAll())
                        {
                            Console.WriteLine($"Id:{item.Id},Title:{item.Title},Description:{item.Description},Pusblishedyear:{item.PublishedYear}");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Enter new book: Title,Description,Publishedyear");
                        bookService.Create(new Book
                        {
                            Title = Console.ReadLine(),
                            Description = Console.ReadLine(),
                            PublishedYear = int.Parse(Console.ReadLine()),
                            IsDeleted = false,
                            CreateTime = DateTime.UtcNow.AddHours(4),
                            UpdateAt = DateTime.UtcNow.AddHours(4)
                        });
                        break;
                    case "3":
                        Console.WriteLine("Update book,Enter book Id:");
                        int bookId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new book: Title,Description,Publishedyear");
                        bookService.Update(bookId, new Book
                        {
                            Title = Console.ReadLine(),
                            Description = Console.ReadLine(),
                            PublishedYear = int.Parse(Console.ReadLine()),
                        });
                        break;
                    case "4":
                        Console.WriteLine("The ID you want to delete");
                        int delete = int.Parse(Console.ReadLine());
                        bookService.Delete(delete);
                        Console.WriteLine($"{delete} is delete");
                        break;
                    case "0":
                        Console.WriteLine("Exit program");
                        return;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;

                }
            }
        }
        static void BorrowerAction(IBorrowerService borrowerService)
        {
            while (true)
            {
                Console.WriteLine("                         \nBorrower actions-Menu");
                Console.WriteLine("                          1 - Butun Borrowerlarin siyahisi");
                Console.WriteLine("                          2 - Borrower yaratmaq");
                Console.WriteLine("                          3 - Borrower editlemek");
                Console.WriteLine("                          4 - Borrower silmek");
                Console.WriteLine("                          0-Exit");

                Console.WriteLine("Make your choice");

                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        foreach (var item in borrowerService.GetAll())
                        {
                            Console.WriteLine($"Id: {item.Id},Name: {item.Name},Email: {item.Email}");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Enter new borrower: Name,Email");
                        borrowerService.Create(new Borrower
                        {
                            Name = Console.ReadLine(),
                            Email = Console.ReadLine(),
                            IsDeleted = false,
                            CreateTime = DateTime.UtcNow.AddHours(4),
                            UpdateAt = DateTime.UtcNow.AddHours(4)
                        });
                        break;
                        case"3":
                        Console.WriteLine("Update borrower,enter borrower ID:");
                        int borrowerId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new borrower: Name,Email");
                        borrowerService.Update(borrowerId, new Borrower
                        {
                            Name = Console.ReadLine(),
                            Email = Console.ReadLine()
                        });
                        break;
                        case "4":
                        Console.WriteLine("The ID you want to delete");
                        int delete = int.Parse(Console.ReadLine());
                        borrowerService.Delete(delete);
                        break;
                    case "0":
                        Console.WriteLine("Exit program");
                        return;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }

            }
        }

        static List<Book> FilterBooksByTitle(IBookService bookService,string title)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            var allBooks = bookService.GetAll();
            if(allBooks == null || allBooks.Count == 0)
            {
                Console.WriteLine("Book not found");
                return new List<Book>();
            }

            var filteredBooks = allBooks
                .Where(x => !string.IsNullOrWhiteSpace(x.Title) &&
                x.Title.Contains(title,StringComparison.OrdinalIgnoreCase))
                .ToList();
            if(filteredBooks.Count == 0)
            {
                Console.WriteLine("Not found books");
            }
            return filteredBooks;
        }

        static void FilterBooksByAuthor(IBookService bookService,string authorName)
        {
            if (string.IsNullOrWhiteSpace(authorName))
            {
                throw new ArgumentNullException();
            }
            var books = bookService.GetAll();   

            
        }

        static void BorrowBook(ILoanService loanService,IBookService bookService,IBorrowerService borrowerService)
        {
            List<LoanItem> selectBooks = new List<LoanItem>();
            Borrower selectBorrower = null;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Available books: ");

                var books = bookService.GetAll() ?? new List<Book>();
                
            }
        }

        static void MostBorrowedBook(ILoanService loanService)
        {
            var allLoans = loanService.GetAll();

            if( allLoans == null || !allLoans.Any())
            {
                Console.WriteLine("No loans found");
                return ;
            }

            var mostBorrowedBooks = allLoans
                .SelectMany(x => x.LoanItems)
                .GroupBy(x => x.BookId)
                .OrderByDescending(x => x.Count())
                .FirstOrDefault();

            if( mostBorrowedBooks == null)
            {
                Console.WriteLine("Books have been borrowed");
                return ;
            }
            var mostBook = mostBorrowedBooks.FirstOrDefault()?.Book;
            int borrowCount = mostBorrowedBooks.Count();

            if(mostBook == null)
            {
                Console.WriteLine("Error");
                return ;
            }

            Console.WriteLine($"Most borrowed book: {mostBook.Title},{borrowCount} times borrowed");
        }
    }
}
