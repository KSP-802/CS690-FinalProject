using Xunit;

public class LibraryServiceTests
{
    [Fact]
    public void AddBook_ShouldAddBookToList()
    {
        var service = new LibraryService();

        service.AddBook("Atomic Habits", "James Clear", 320);

        var books = service.GetBooks();

        Assert.Single(books);
        Assert.Equal("Atomic Habits", books[0].Title);
    }

    [Fact]
    public void DeleteBook_ShouldRemoveBook()
    {
        var service = new LibraryService();

        service.AddBook("Atomic Habits", "James Clear", 320);
        var bookId = service.GetBooks()[0].Id;

        service.DeleteBook(bookId);

        Assert.Empty(service.GetBooks());
    }

    [Fact]
    public void SearchBooks_ShouldReturnMatchingBooks()
    {
        var service = new LibraryService();

        service.AddBook("Atomic Habits", "James Clear", 320);
        service.AddBook("Deep Work", "Cal Newport", 304);

        var results = service.SearchBooks("Atomic");

        Assert.Single(results);
        Assert.Equal("Atomic Habits", results[0].Title);
    }
}