using System;
using System.Linq;

var libraryService = new LibraryService();
var readingService = new ReadingService();
var menu = new Menu();

while (true)
{
    Console.Clear();
    menu.Show();

    Console.Write("Select an option: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddBook();
            break;

        case "2":
            ViewBooks();
            break;

        case "3":
            MarkBookCompleted();
            break;

        case "4":
            AddArticle();
            break;

        case "5":
            ViewArticles();
            break;

        case "6":
            CreateCategory();
            break;

        case "7":
            AssignCategory();
            break;

        case "8":
            StartReadingSession();
            break;

        case "9":
            EndReadingSession();
            break;

        case "10":
            ViewYearlyStatistics();
            break;

        case "11":
            SetYearlyGoal();
            break;

        case "12":
            DeleteBook();
            break;

        case "13":
            SearchBooks();
            break;

        case "14":
            ViewReadingHistory();
            break;

        case "15":
            ViewTotalPagesRead();
            break;

        case "16":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid option.");
            Pause();
            break;
    }
}

void AddBook()
{
    Console.Clear();
    Console.WriteLine("--- Add Book ---");

    Console.Write("Title: ");
    string title = Console.ReadLine() ?? "";

    Console.Write("Author: ");
    string author = Console.ReadLine() ?? "";

    Console.Write("Total Pages: ");
    int.TryParse(Console.ReadLine(), out int pages);

    libraryService.AddBook(title, author, pages);

    Console.WriteLine("Book added successfully.");
    Pause();
}

void ViewBooks()
{
    Console.Clear();
    Console.WriteLine("--- Books ---");

    var books = libraryService.GetBooks();

    if (books.Count == 0)
    {
        Console.WriteLine("No books found.");
    }
    else
    {
        foreach (var book in books)
        {
            Console.WriteLine($"{book.Id}. {book.Title} by {book.Author} | Pages: {book.TotalPages}");
            Console.WriteLine($"   Completed: {(book.IsCompleted ? "Yes" : "No")}");
            if (book.CompletedDate.HasValue)
            {
                Console.WriteLine($"   Completed Date: {book.CompletedDate.Value:d}");
            }
            if (book.Categories.Count > 0)
            {
                Console.WriteLine($"   Categories: {string.Join(", ", book.Categories)}");
            }
        }
    }

    Pause();
}

void MarkBookCompleted()
{
    Console.Clear();
    Console.WriteLine("--- Mark Book Completed ---");

    var books = libraryService.GetBooks();

    if (books.Count == 0)
    {
        Console.WriteLine("No books available.");
        Pause();
        return;
    }

    foreach (var book in books)
    {
        Console.WriteLine($"{book.Id}. {book.Title}");
    }

    Console.Write("Enter Book ID: ");
    int.TryParse(Console.ReadLine(), out int bookId);

    Console.Write("Enter completion date (yyyy-mm-dd) or leave blank for today: ");
    string? input = Console.ReadLine();

    DateTime completionDate = DateTime.Today;
    if (!string.IsNullOrWhiteSpace(input))
    {
        DateTime.TryParse(input, out completionDate);
    }

    bool success = libraryService.MarkBookCompleted(bookId, completionDate);

    Console.WriteLine(success ? "Book marked completed." : "Book not found.");
    Pause();
}

void AddArticle()
{
    Console.Clear();
    Console.WriteLine("--- Add Article ---");

    Console.Write("Title: ");
    string title = Console.ReadLine() ?? "";

    Console.Write("URL: ");
    string url = Console.ReadLine() ?? "";

    libraryService.AddArticle(title, url);

    Console.WriteLine("Article added successfully.");
    Pause();
}

void ViewArticles()
{
    Console.Clear();
    Console.WriteLine("--- Articles ---");

    var articles = libraryService.GetArticles();

    if (articles.Count == 0)
    {
        Console.WriteLine("No articles found.");
    }
    else
    {
        foreach (var article in articles)
        {
            Console.WriteLine($"{article.Id}. {article.Title}");
            Console.WriteLine($"   URL: {article.Url}");
            Console.WriteLine($"   Saved: {article.DateSaved}");
            if (article.Categories.Count > 0)
            {
                Console.WriteLine($"   Categories: {string.Join(", ", article.Categories)}");
            }
        }
    }

    Pause();
}

void CreateCategory()
{
    Console.Clear();
    Console.WriteLine("--- Create Category ---");

    Console.Write("Category name: ");
    string name = Console.ReadLine() ?? "";

    string result = libraryService.CreateCategory(name);
    Console.WriteLine(result);

    Pause();
}

void AssignCategory()
{
    Console.Clear();
    Console.WriteLine("--- Assign Category ---");

    var categories = libraryService.GetCategories();

    if (categories.Count == 0)
    {
        Console.WriteLine("No categories available. Create a category first.");
        Pause();
        return;
    }

    Console.WriteLine("Assign to:");
    Console.WriteLine("1. Book");
    Console.WriteLine("2. Article");
    Console.Write("Select option: ");
    string? targetChoice = Console.ReadLine();

    Console.WriteLine("Available Categories:");
    foreach (var category in categories)
    {
        Console.WriteLine($"{category.Id}. {category.Name}");
    }

    Console.Write("Enter Category ID: ");
    int.TryParse(Console.ReadLine(), out int categoryId);

    if (targetChoice == "1")
    {
        var books = libraryService.GetBooks();
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            Pause();
            return;
        }

        foreach (var book in books)
        {
            Console.WriteLine($"{book.Id}. {book.Title}");
        }

        Console.Write("Enter Book ID: ");
        int.TryParse(Console.ReadLine(), out int bookId);

        string result = libraryService.AssignCategoryToBook(bookId, categoryId);
        Console.WriteLine(result);
    }
    else if (targetChoice == "2")
    {
        var articles = libraryService.GetArticles();
        if (articles.Count == 0)
        {
            Console.WriteLine("No articles available.");
            Pause();
            return;
        }

        foreach (var article in articles)
        {
            Console.WriteLine($"{article.Id}. {article.Title}");
        }

        Console.Write("Enter Article ID: ");
        int.TryParse(Console.ReadLine(), out int articleId);

        string result = libraryService.AssignCategoryToArticle(articleId, categoryId);
        Console.WriteLine(result);
    }
    else
    {
        Console.WriteLine("Invalid option.");
    }

    Pause();
}

void StartReadingSession()
{
    Console.Clear();
    Console.WriteLine("--- Start Reading Session ---");

    var books = libraryService.GetBooks();

    if (books.Count == 0)
    {
        Console.WriteLine("No books available.");
        Pause();
        return;
    }

    foreach (var book in books)
    {
        Console.WriteLine($"{book.Id}. {book.Title}");
    }

    Console.Write("Enter Book ID: ");
    int.TryParse(Console.ReadLine(), out int bookId);

    var selectedBook = books.FirstOrDefault(b => b.Id == bookId);

    if (selectedBook == null)
    {
        Console.WriteLine("Invalid Book ID.");
        Pause();
        return;
    }

    string result = readingService.StartSession(selectedBook);
    Console.WriteLine(result);

    Pause();
}

void EndReadingSession()
{
    Console.Clear();
    Console.WriteLine("--- End Reading Session ---");

    Console.Write("Pages Read: ");
    int.TryParse(Console.ReadLine(), out int pagesRead);

    string result = readingService.EndSession(pagesRead);
    Console.WriteLine(result);

    Pause();
}

void ViewYearlyStatistics()
{
    Console.Clear();
    Console.WriteLine("--- Yearly Statistics ---");

    int year = DateTime.Now.Year;
    int completedBooks = libraryService.GetCompletedBooksCountForYear(year);
    double hoursRead = readingService.GetTotalHoursReadForYear(year);
    string goalProgress = readingService.GetGoalProgressText(completedBooks);

    Console.WriteLine($"Year: {year}");
    Console.WriteLine($"Books Completed: {completedBooks}");
    Console.WriteLine($"Hours Read: {hoursRead:F2}");
    Console.WriteLine($"Goal Progress: {goalProgress}");

    Pause();
}

void SetYearlyGoal()
{
    Console.Clear();
    Console.WriteLine("--- Set Yearly Goal ---");

    int year = DateTime.Now.Year;

    Console.Write($"Enter number of books to complete in {year}: ");
    int.TryParse(Console.ReadLine(), out int goalBooks);

    readingService.SetYearlyGoal(year, goalBooks);

    Console.WriteLine("Yearly goal saved.");
    Pause();
}

void DeleteBook()
{
    Console.Clear();
    Console.WriteLine("--- Delete Book ---");

    var books = libraryService.GetBooks();

    if (books.Count == 0)
    {
        Console.WriteLine("No books available.");
        Pause();
        return;
    }

    foreach (var book in books)
    {
        Console.WriteLine($"{book.Id}. {book.Title}");
    }

    Console.Write("Enter Book ID to delete: ");
    int.TryParse(Console.ReadLine(), out int bookId);

    libraryService.DeleteBook(bookId);

    Console.WriteLine("Book deleted if ID existed.");
    Pause();
}

void SearchBooks()
{
    Console.Clear();
    Console.WriteLine("--- Search Books ---");

    Console.Write("Enter keyword: ");
    string keyword = Console.ReadLine() ?? "";

    var results = libraryService.SearchBooks(keyword);

    if (results.Count == 0)
    {
        Console.WriteLine("No matching books found.");
    }
    else
    {
        foreach (var book in results)
        {
            Console.WriteLine($"{book.Id}. {book.Title} by {book.Author}");
        }
    }

    Pause();
}

void ViewReadingHistory()
{
    Console.Clear();
    Console.WriteLine("--- Reading History ---");

    var sessions = readingService.GetSessions();

    if (sessions.Count == 0)
    {
        Console.WriteLine("No reading history available.");
    }
    else
    {
        foreach (var session in sessions)
        {
            Console.WriteLine($"Book: {session.BookTitle}");
            Console.WriteLine($"Start: {session.StartTime}");
            Console.WriteLine($"End: {session.EndTime}");
            Console.WriteLine($"Pages Read: {session.PagesRead}");
            Console.WriteLine();
        }
    }

    Pause();
}

void ViewTotalPagesRead()
{
    Console.Clear();
    Console.WriteLine("--- Total Pages Read ---");

    int totalPages = readingService.GetTotalPagesRead();
    Console.WriteLine($"Total Pages Read: {totalPages}");

    Pause();
}

void Pause()
{
    Console.WriteLine();
    Console.WriteLine("Press Enter to continue...");
    Console.ReadLine();
}

