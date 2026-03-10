using System;
using System.Collections.Generic;
using System.Linq;

List<Book> books = new();
List<Article> articles = new();
List<ReadingSession> sessions = new();

ReadingSession? activeSession = null;

int nextBookId = 1;
int nextArticleId = 1;
int nextSessionId = 1;

while (true)
{
    Console.Clear();
    Console.WriteLine("====================================");
    Console.WriteLine(" Oliver's Learning Tracker");
    Console.WriteLine("====================================");
    Console.WriteLine("1. Add Book");
    Console.WriteLine("2. View Books");
    Console.WriteLine("3. Add Article");
    Console.WriteLine("4. View Articles");
    Console.WriteLine("5. Start Reading Session");
    Console.WriteLine("6. End Reading Session");
    Console.WriteLine("7. Exit");
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

    books.Add(new Book
    {
        Id = nextBookId++,
        Title = title,
        Author = author,
        TotalPages = pages
    });

    Console.WriteLine("Book added.");
    Pause();
}

void ViewBooks()
{
    Console.Clear();
    Console.WriteLine("--- Books ---");

    if (!books.Any())
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

    articles.Add(new Article
    {
        Id = nextArticleId++,
        Title = title,
        Url = url,
        DateSaved = DateTime.Now
    });

    Console.WriteLine("Article saved.");
    Pause();
}

void ViewArticles()
{
    Console.Clear();
    Console.WriteLine("--- Articles ---");

    if (!articles.Any())
    {
        Console.WriteLine("No articles found.");
    }
    else
    {
        foreach (var article in articles)
        {
            Console.WriteLine($"{article.Id}. {article.Title} ({article.Url}) | Saved: {article.DateSaved}");
        }
    }

    Pause();
}

void StartReadingSession()
{
    Console.Clear();
    Console.WriteLine("--- Start Reading Session ---");

    if (activeSession != null)
    {
        Console.WriteLine("A reading session is already active.");
        Pause();
        return;
    }

    if (!books.Any())
    {
        Console.WriteLine("No books available.");
        Pause();
        return;
    }

    foreach (var book in books)
    {
        Console.WriteLine($"{book.Id}. {book.Title}");
    }

    Console.Write("Book ID: ");
    int.TryParse(Console.ReadLine(), out int bookId);

    var bookSelected = books.FirstOrDefault(b => b.Id == bookId);

    if (bookSelected == null)
    {
        Console.WriteLine("Invalid selection.");
        Pause();
        return;
    }

    activeSession = new ReadingSession
    {
        SessionId = nextSessionId++,
        BookId = bookSelected.Id,
        BookTitle = bookSelected.Title,
        StartTime = DateTime.Now
    };

    Console.WriteLine($"Reading session started for {bookSelected.Title}.");
    Pause();
}

void EndReadingSession()
{
    Console.Clear();
    Console.WriteLine("--- End Reading Session ---");

    if (activeSession == null)
    {
        Console.WriteLine("No active session.");
        Pause();
        return;
    }

    Console.Write("Pages read: ");
    int.TryParse(Console.ReadLine(), out int pages);

    activeSession.EndTime = DateTime.Now;
    activeSession.PagesRead = pages;

    sessions.Add(activeSession);

    var duration = activeSession.EndTime.Value - activeSession.StartTime;

    Console.WriteLine($"Session saved for {activeSession.BookTitle}.");
    Console.WriteLine($"Duration: {duration.TotalMinutes:F1} minutes");
    Console.WriteLine($"Pages Read: {activeSession.PagesRead}");

    activeSession = null;

    Pause();
}

void Pause()
{
    Console.WriteLine("Press Enter to continue...");
    Console.ReadLine();
}


