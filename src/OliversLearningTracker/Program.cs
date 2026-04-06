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
            AddArticle();
            break;

        case "4":
            ViewArticles();
            break;

        case "5":
            StartReadingSession();
            break;

        case "6":
            EndReadingSession();
            break;

        case "7":
            DeleteBook();
            break;

        case "8":
            SearchBooks();
            break;

        case "9":
            ViewReadingHistory();
            break;

        case "10":
            ViewTotalPagesRead();
            break;

        case "11":
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
        }
    }

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
        }
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

