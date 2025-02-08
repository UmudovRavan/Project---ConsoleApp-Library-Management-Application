using Project___ConsoleApp__Library_Management_Application_.Models;
using Project___ConsoleApp__Library_Management_Application_.MyException.Common;
using Project___ConsoleApp__Library_Management_Application_.Service.Implementation;
using Project___ConsoleApp__Library_Management_Application_.Service.Interface;
using System.Text.RegularExpressions;

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
                try
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
                            try
                            {
                                AuthorAction(authorServices);
                            }
                            catch(Exception ex)
                            {

                                Console.WriteLine($"Error in Author Menu: {ex.Message}");
                            }
                            break;
                        case "2":
                            try
                            {
                                BookAction(bookService);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error in Book Menu: {ex.Message}");
                            }
                            break;
                        case "3":
                            try
                            {
                                BorrowerAction(borrowerService);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error in Borrower Menu: {ex.Message}");
                            }
                            break;
                        case "4":
                            try
                            {
                                BorrowBook(loanService, bookService, borrowerService);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error while borrowing book: {ex.Message}");
                            }
                            break;
                        case "5":
                            try
                            {
                                Console.Write("Enter Borrower ID: ");
                                if (int.TryParse(Console.ReadLine(), out int borrowerId))
                                {
                                    ReturnBook(loanService, borrowerId);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid numeric Borrower ID.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error while returning book: {ex.Message}");
                            }
                            break;

                        case "6":
                            try
                            {
                                MostBorrowedBook(loanService);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error while fetching the most borrowed book: {ex.Message}");
                            }
                            break;
                        case "7":
                            try
                            {
                                OverdueBookBorrower(loanService);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error while fetching overdue borrowers: {ex.Message}");
                            }
                            break;
                        case "8":
                            try
                            {
                                BorrowerWithBooks(loanService);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error while fetching borrowers and their books: {ex.Message}");
                            }
                            break;
                        case "9":

                            try
                            {
                                Console.WriteLine("Enter book title:");
                                string? title = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(title))
                                {
                                    Console.WriteLine("Title cannot be empty.");
                                    break;
                                }


                                var filterBook = FilterBooksByTitle(bookService, title.Trim());


                                if (filterBook.Any())
                                {
                                    Console.WriteLine("Axtarış nəticələri:");
                                    foreach (var book in filterBook)
                                    {
                                        Console.WriteLine($"- {book.Title} (Müəlliflər: {string.Join(", ", book.Authors.Select(a => a.Name))})");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"No books found with title containing '{title}'.");
                                }
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Error while filtering books by title: {ex.Message}");
                            }
                            break;
                        case "10":
                            try
                            {
                                Console.WriteLine("Enter author name:");
                                string? authorName = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(authorName))
                                {
                                    Console.WriteLine("Author name cannot be empty.");
                                    break;
                                }



                                var filteredBooksByAuthor = FilterBooksByAuthor(bookService, authorName.Trim());

                                if (filteredBooksByAuthor.Any())
                                {
                                    Console.WriteLine("Axtarış nəticələri:");
                                    foreach (var book in filteredBooksByAuthor)
                                    {
                                        Console.WriteLine($"- {book.Title} (Müəlliflər: {string.Join(", ", book.Authors.Select(a => a.Name))})");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"No books found for author '{authorName}'.");
                                }
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;

                    }
                    

                }
                catch(Exception ex) 
                {
                    Console.WriteLine($"Critical error: {ex.Message}");
                }


            }
        }


        static void AuthorAction(IAuthorServices authorServices)
        {
            try
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
                            try
                            {
                                foreach (var item in authorServices.GetAll())
                                {
                                    Console.WriteLine($"ID:{item.Id},Name: {item.Name}");
                                }
                                break;
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Error authors:{ex.Message}");
                            }
                            break;
                        case "2":
                            try
                            {
                                string? name;
                                while (true)
                                {
                                    Console.Write("🖊️ Enter author name: ");
                                    name = Console.ReadLine()?.Trim();

                                    if (!string.IsNullOrEmpty(name) && Regex.IsMatch(name, @"^[A-Za-zА-Яа-я\s]{3,}$"))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid name! The name must contain only letters and spaces (minimum 3 characters). No digits or special symbols allowed.");
                                    }
                                }

                                var words = name.Split(' ');
                                for (int i = 0; i < words.Length; i++)
                                {
                                    if (!string.IsNullOrEmpty(words[i]))
                                    {
                                        words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                                    }
                                }
                                name = string.Join(" ", words);

                                authorServices.Create(new Author
                                {
                                    Name = name,
                                    IsDeleted = false,
                                    CreateTime = DateTime.UtcNow.AddHours(4),
                                    UpdateAt = DateTime.UtcNow.AddHours(4),
                                });

                                Console.WriteLine("Author created successfully.");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Validation error: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Unexpected error: {ex.Message}");
                            }
                            break;
                        case "3":
                            try
                            {
                                Console.WriteLine("Update author,Enter author ID:");
                                int id = int.Parse(Console.ReadLine());
                                Console.WriteLine("New Author name:");
                                authorServices.Update(id, new Author
                                {
                                    Name = Console.ReadLine(),
                                    IsDeleted = false,
                                    UpdateAt = DateTime.UtcNow.AddHours(4),
                                });
                            }catch(Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        case "4":
                            try
                            {
                                Console.WriteLine("The ID you want to delete");
                                int delete = int.Parse(Console.ReadLine());
                                authorServices.Delete(delete);
                                Console.WriteLine($"{delete} is delete");
                                break;
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine( $"Error: {ex.Message}");
                            }
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
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            }


        static void BookAction(IBookService bookService)
        {
            while (true)
            {
                try
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
                            try
                            {
                                foreach (var item in bookService.GetAll())
                                {
                                    Console.WriteLine($"Id:{item.Id},Title:{item.Title},Description:{item.Description},Pusblishedyear:{item.PublishedYear}");
                                }
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Error :{ex.Message}");
                            }
                            break;
                        case "2":
                            try
                            {
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
                            }
                            catch(NotValidException ex)
                            {
                                Console.WriteLine($"Not created {ex.Message}");
                            }
                            break;
                        case "3":
                            try
                            {
                                Console.WriteLine("Update book,Enter book Id:");
                                int bookId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter new book: Title,Description,Publishedyear");
                                bookService.Update(bookId, new Book
                                {
                                    Title = Console.ReadLine(),
                                    Description = Console.ReadLine(),
                                    PublishedYear = int.Parse(Console.ReadLine()),
                                });
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine( $"Not updated {ex.Message}");
                            }
                            break;
                        case "4":
                            try
                            {

                                Console.WriteLine("The ID you want to delete");
                                int delete = int.Parse(Console.ReadLine());
                                bookService.Delete(delete);
                                Console.WriteLine($"{delete} is delete");
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Not deleted {ex.Message}");
                            }
                            break;
                        case "0":
                            Console.WriteLine("Exit program");
                            return;
                        default:
                            Console.WriteLine("Wrong choice");
                            break;

                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        static void BorrowerAction(IBorrowerService borrowerService)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("                         \nBorrower actions-Menu");
                    Console.WriteLine("                          1 - Butun Borrowerlarin siyahisi");
                    Console.WriteLine("                          2 - Borrower yaratmaq");
                    Console.WriteLine("                          3 - Borrower editlemek");
                    Console.WriteLine("                          4 - Borrower silmek");
                    Console.WriteLine("                          0-Exit");

                    Console.WriteLine("Make your choice");

                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            try
                            {
                                foreach (var item in borrowerService.GetAll())
                                {
                                    Console.WriteLine($"Id: {item.Id},Name: {item.Name},Email: {item.Email}");
                                }
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(  $"Error borrower{ex.Message}");
                            }
                            break;
                        case "2":
                            try
                            {
                                Console.WriteLine("Enter new borrower: Name,Email");
                                borrowerService.Create(new Borrower
                                {
                                    Name = Console.ReadLine(),
                                    Email = Console.ReadLine(),
                                    IsDeleted = false,
                                    CreateTime = DateTime.UtcNow.AddHours(4),
                                    UpdateAt = DateTime.UtcNow.AddHours(4)
                                });
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Not created {ex.Message}");
                            }
                            break;
                        case "3":
                            try
                            {
                                Console.WriteLine("Update borrower,enter borrower ID:");
                                int borrowerId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter new borrower: Name,Email");
                                borrowerService.Update(borrowerId, new Borrower
                                {
                                    Name = Console.ReadLine(),
                                    Email = Console.ReadLine()
                                });
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Not updated {ex.Message}");
                            }
                            break;
                        case "4":
                            try
                            {
                                Console.WriteLine("The ID you want to delete");
                                int delete = int.Parse(Console.ReadLine());
                                borrowerService.Delete(delete);
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Not delete {ex.Message}");
                            }
                            break;
                        case "0":
                            Console.WriteLine("Exit program");
                            return;
                        default:
                            Console.WriteLine("Wrong choice");
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }

            }
        }

        static List<Book> FilterBooksByTitle(IBookService bookService, string title)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("Title cannot be null or empty.");
                    return new List<Book>();
                }

                var books = bookService.GetAll();
                if (books == null || books.Count == 0)
                {
                    Console.WriteLine("No books found in the database.");
                    return new List<Book>();
                }

                var filteredBooks = books
                    .Where(b => !string.IsNullOrEmpty(b.Title) &&
                                b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (filteredBooks.Count == 0)
                {
                    Console.WriteLine($"No books found with title containing '{title}'.");
                }

                return filteredBooks;
            }
            catch(Exception ex)
            {
                Console.WriteLine( $"Error not books{ex.Message}");
                return new List<Book>();
            }
        }

        static void ReturnBook(ILoanService loanService, int borrowerId)
        {
            try
            {
                var activeLoans = loanService.GetAll()
               .Where(x => x.BorrowerId == borrowerId && x.ReturnDate == null)
               .ToList();

                if (activeLoans.Count == 0)
                {
                    Console.WriteLine($"No active loans found for Borrower ID {borrowerId}.");
                    return;
                }

                foreach (var loan in activeLoans)
                {
                    loan.ReturnDate = DateTime.UtcNow.AddHours(4);
                    loan.UpdateAt = DateTime.UtcNow.AddHours(4);
                    loanService.Update(loan.Id, loan);
                }

                Console.WriteLine($"Successfully returned {activeLoans.Count} book(s) for Borrower ID {borrowerId}.");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }

        static void OverdueBookBorrower(ILoanService loanService)
        {
            try {
                DateTime nowDate = DateTime.UtcNow.AddHours(4);

                var loanOverdue = loanService.GetAll()
                    .Where(x => x.MustReturnDate < nowDate && x.ReturnDate == null)
                    .ToList();

                if (loanOverdue == null || !loanOverdue.Any())
                {
                    Console.WriteLine("No overdue loan found");
                    return;
                }

                var borrowerOverdue = loanOverdue
                    .GroupBy(x => x.BorrowerId)
                    .Select(g => new
                    {
                        Borrower = g.FirstOrDefault()?.Borrower,
                        CountOverdue = g.Count()
                    })
                    .Where(b => b.Borrower != null)
                    .ToList();

                Console.WriteLine("Overdue borrowers:");
                foreach (var item in borrowerOverdue)
                {
                    Console.WriteLine($"{item.Borrower.Name} {item.CountOverdue} Number of times overdue.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Unexpected error{ex.Message}");
            }
        }

        static void BorrowerWithBooks(ILoanService loanService)
        {
            try
            {
                var loan = loanService.GetAll()
                ?.Where(x => x.ReturnDate != null)
                .GroupBy(x => x.BorrowerId)
                .Select(g => new
                {
                    Borrower = g.FirstOrDefault()?.Borrower,
                    BorrowerBooks = g.SelectMany(x => x.LoanItems ?? new List<LoanItem>())
                     .Select(x => x.Book?.Title)
                     .Where(title => !string.IsNullOrEmpty(title))
                     .Distinct()
                     .ToList()

                })
                .Where(x => x.Borrower != null && x.BorrowerBooks.Any())
                .ToList();

                if (loan == null || loan.Count == 0)
                {
                    Console.WriteLine("No borrowers with borrowed books found.");
                    return;
                }

                Console.WriteLine("Borrowers and their borrowed books:");
                foreach (var item in loan)
                {
                    Console.WriteLine($"{item.Borrower.Name} borrower:");
                    foreach (var book in item.BorrowerBooks)
                    {
                        Console.WriteLine($" - {book}");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Unexcepted error {ex.Message}");
            }
        }
        static List<Book> FilterBooksByAuthor(IBookService bookService, string authorName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(authorName))
                {
                    Console.WriteLine("Author name cannot be null or empty.");
                    return new List<Book>();
                }


                var books = bookService.GetAll();

                if (books == null || books.Count == 0)
                {
                    Console.WriteLine("No books found in the database.");
                    return new List<Book>();
                }


                var filteredBooks = books
                    .Where(b => b.Authors != null &&
                               b.Authors.Any(a => a.Name.Contains(authorName, StringComparison.OrdinalIgnoreCase)))
                    .ToList();

                if (filteredBooks.Count == 0)
                {
                    Console.WriteLine($" No books found for author '{authorName}'.");
                }

                return filteredBooks;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error filtered authors{ex.Message}");
                return new List<Book>();
            }
        
        }
        static void BorrowBook(ILoanService loanService, IBookService bookService, IBorrowerService borrowerService)
        {
            List<LoanItem> selectBooks = new List<LoanItem>();

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Available books: ");

                    var books = bookService.GetAll() ?? new List<Book>();
                    var unavailableBooksId = loanService.GetAll()
                        .Where(x => x.ReturnDate == null)
                        .SelectMany(x => x.LoanItems?.Select(l => l.BookId) ?? new List<int>())
                        .ToHashSet() ?? new HashSet<int>();

                    if (!books.Any())
                    {
                        Console.WriteLine("No books available");
                        return;
                    }

                    foreach (var item in books)
                    {
                        string status = unavailableBooksId.Contains(item.Id) ? "Not available" : "Available";
                        Console.WriteLine($"{item.Id}, {item.Title} : {status}");
                    }

                    Console.Write("\nEnter Book ID to borrow (or 0 to continue): ");
                    if (!int.TryParse(Console.ReadLine(), out int bookId) || bookId == 0)
                        break;

                    if (!books.Any(b => b.Id == bookId && !unavailableBooksId.Contains(b.Id)))
                    {
                        Console.WriteLine("This book is not available.");
                        continue;
                    }

                    var selectedBook = books.FirstOrDefault(b => b.Id == bookId);
                    if (selectedBook != null)
                    {
                        selectBooks.Add(new LoanItem { BookId = selectedBook.Id });
                        Console.WriteLine($"Added: {selectedBook.Title}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Book ID. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error {ex.Message}");
                }
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("\n Seçim edin:");
                    Console.WriteLine("1️ Başqa kitab Borrow et");
                    Console.WriteLine("2️ Borrower əlavə et və davam et");
                    Console.WriteLine("Seçiminizi daxil edin: ");

                    var choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        break;
                    }
                    else if (choice == "2")
                    {
                        goto SelectBorrower;
                    }
                    else
                    {
                        Console.WriteLine("Wrong choice");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error {ex.Message}");
                }
            }

            if (!selectBooks.Any())
            {
                Console.WriteLine("Error"); //secim edilmedi emelyat legvi
                return;
            }

        SelectBorrower:
            Borrower selectBorrower = null;

            while (selectBorrower == null)
            {
                try
                {

                    Console.Clear();
                    Console.WriteLine("Select borrower:");

                    var borrower = borrowerService.GetAll() ?? new List<Borrower>();

                    if (!borrower.Any())
                    {
                        Console.WriteLine("Borrower not found");
                        return;
                    }

                    foreach (var item in borrower)
                    {
                        Console.WriteLine($"{item.Id}, {item.Name}");
                    }

                    Console.Write("\nEnter Borrower ID: ");
                    if (int.TryParse(Console.ReadLine(), out int borrowersId))
                    {
                        selectBorrower = borrower.FirstOrDefault(b => b.Id == borrowersId);
                        if (selectBorrower == null)
                        {
                            Console.WriteLine("Invalid Borrower ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Console.WriteLine("\nConfirm loan? (Y/N)");
            if (Console.ReadLine()?.Trim().ToLower() != "y")
            {
                Console.WriteLine("Loan canceled.");
                return;
            }
            try
            {

                var newLoan = new Loan
                {
                    BorrowerId = selectBorrower.Id,
                    LoanTime = DateTime.UtcNow.AddHours(4),
                    MustReturnDate = DateTime.UtcNow.AddHours(4).AddDays(15),
                    LoanItems = selectBooks
                };
                loanService.Create(newLoan);
                Console.WriteLine("Loan created");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void MostBorrowedBook(ILoanService loanService)
        {
            try
            {
                var loans = loanService.GetAll();

                if (loans == null || !loans.Any())
                {
                    Console.WriteLine("No loans found.");
                    return;
                }

                var mostBorrowedBook = loans
                    .Where(x => x.LoanItems != null)
                    .SelectMany(x => x.LoanItems)
                    .Where(x => x.Book != null)
                    .GroupBy(x => x.BookId)
                    .OrderByDescending(x => x.Count())
                    .FirstOrDefault();

                if (mostBorrowedBook == null)
                {
                    Console.WriteLine("No books have been borrowed yet.");
                    return;
                }

                var book = mostBorrowedBook.FirstOrDefault()?.Book;
                int borrowCount = mostBorrowedBook.Count();

                if (book == null)
                {
                    Console.WriteLine("Error: The most borrowed book data is invalid.");
                    return;
                }

                Console.WriteLine($"Most borrowed book: {book.Title} (Borrowed {borrowCount} times)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }
    }
}
