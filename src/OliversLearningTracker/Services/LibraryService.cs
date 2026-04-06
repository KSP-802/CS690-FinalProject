using System;
using System.Collections.Generic;
using System.Linq;

public class LibraryService
{
    private List<Book> books = new();
    private List<Article> articles = new();

    private int nextBookId = 1;
    private int nextArticleId = 1;

    public void AddBook(string title, string author, int pages)
    {
        books.Add(new Book
        {
            Id = nextBookId++,
            Title = title,
            Author = author,
            TotalPages = pages
        });
    }

    public List<Book> GetBooks()
    {
        return books;
    }

    public void DeleteBook(int id)
    {
        books.RemoveAll(b => b.Id == id);
    }

    public List<Book> SearchBooks(string keyword)
    {
        return books
            .Where(b => b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public void AddArticle(string title, string url)
    {
        articles.Add(new Article
        {
            Id = nextArticleId++,
            Title = title,
            Url = url,
            DateSaved = DateTime.Now
        });
    }

    public List<Article> GetArticles()
    {
        return articles;
    }
}
