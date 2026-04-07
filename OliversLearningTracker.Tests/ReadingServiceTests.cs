using Xunit;

public class ReadingServiceTests
{
    [Fact]
    public void StartSession_ShouldReturnSessionStarted()
    {
        var service = new ReadingService();
        var book = new Book
        {
            Id = 1,
            Title = "Atomic Habits",
            Author = "James Clear",
            TotalPages = 320
        };

        var result = service.StartSession(book);

        Assert.Equal("Session started", result);
    }

    [Fact]
    public void EndSession_WithoutActiveSession_ShouldReturnNoActiveSession()
    {
        var service = new ReadingService();

        var result = service.EndSession(25);

        Assert.Equal("No active session", result);
    }

    [Fact]
    public void EndSession_AfterStartingSession_ShouldSaveSession()
    {
        var service = new ReadingService();
        var book = new Book
        {
            Id = 1,
            Title = "Atomic Habits",
            Author = "James Clear",
            TotalPages = 320
        };

        service.StartSession(book);
        var result = service.EndSession(25);

        Assert.Equal("Session saved", result);
        Assert.Single(service.GetSessions());
        Assert.Equal(25, service.GetSessions()[0].PagesRead);
    }

    [Fact]
    public void GetTotalPagesRead_ShouldReturnCorrectTotal()
    {
        var service = new ReadingService();
        var book = new Book
        {
            Id = 1,
            Title = "Atomic Habits",
            Author = "James Clear",
            TotalPages = 320
        };

        service.StartSession(book);
        service.EndSession(25);

        service.StartSession(book);
        service.EndSession(30);

        Assert.Equal(55, service.GetTotalPagesRead());
    }
}