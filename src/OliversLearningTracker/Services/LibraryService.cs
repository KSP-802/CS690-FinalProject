using System;
using System.Collections.Generic;
using System.Linq;

public class LibraryService
{
    private List<Book> books = new();
    private List<Article> articles = new();
    private List<Category> categories = new();

    private int nextBookId = 1;
    private int nextArticleId = 1;
    private int nextCategoryId = 1;

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

    public bool MarkBookCompleted(int bookId, DateTime completionDate)
    {
        var book = books.FirstOrDefault(b => b.Id == bookId);
        if (book == null)
        {
            return false;
        }

        book.IsCompleted = true;
        book.CompletedDate = completionDate;
        return true;
    }

    public int GetCompletedBooksCountForYear(int year)
    {
        return books.Count(b => b.IsCompleted && b.CompletedDate.HasValue && b.CompletedDate.Value.Year == year);
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

    public string CreateCategory(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return "Category name is required.";
        }

        bool exists = categories.Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (exists)
        {
            return "Category already exists.";
        }

        categories.Add(new Category
        {
            Id = nextCategoryId++,
            Name = name
        });

        return "Category created.";
    }

    public List<Category> GetCategories()
    {
        return categories;
    }

    public string AssignCategoryToBook(int bookId, int categoryId)
    {
        var book = books.FirstOrDefault(b => b.Id == bookId);
        var category = categories.FirstOrDefault(c => c.Id == categoryId);

        if (book == null || category == null)
        {
            return "Invalid book or category ID.";
        }

        if (!book.Categories.Contains(category.Name))
        {
            book.Categories.Add(category.Name);
        }

        return "Category assigned to book.";
    }

    public string AssignCategoryToArticle(int articleId, int categoryId)
    {
        var article = articles.FirstOrDefault(a => a.Id == articleId);
        var category = categories.FirstOrDefault(c => c.Id == categoryId);

        if (article == null || category == null)
        {
            return "Invalid article or category ID.";
        }

        if (!article.Categories.Contains(category.Name))
        {
            article.Categories.Add(category.Name);
        }

        return "Category assigned to article.";
    }
}
