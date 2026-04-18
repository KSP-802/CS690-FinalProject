using Xunit;
using System;
using System.Linq;

public class LibraryServiceTests
{
    [Fact]
    public void AddBook_ShouldAddBookToList()
    {
        var service = new LibraryService();
        service.AddBook("Atomic Habits", "James Clear", 320);

        Assert.Single(service.GetBooks());
    }

    [Fact]
    public void DeleteBook_ShouldRemoveBook()
    {
        var service = new LibraryService();
        service.AddBook("Test Book", "Author", 100);

        var id = service.GetBooks()[0].Id;

        service.DeleteBook(id);

        Assert.Empty(service.GetBooks());
    }
}