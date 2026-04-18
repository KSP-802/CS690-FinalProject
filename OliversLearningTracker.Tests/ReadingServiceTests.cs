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
            Title = "Test Book",
            Author = "Author",
            TotalPages = 100
        };

        var result = service.StartSession(book);

        Assert.Equal("Session started", result);
    }

    [Fact]
    public void EndSession_NoSession_ShouldReturnMessage()
    {
        var service = new ReadingService();

        var result = service.EndSession(10);

        Assert.Equal("No active session", result);
    }

    [Fact]
    public void GetTotalPagesRead_ShouldSumPages()
    {
        var service = new ReadingService();
        var book = new Book
        {
            Id = 1,
            Title = "Test Book",
            Author = "Author",
            TotalPages = 100
        };

        service.StartSession(book);
        service.EndSession(20);

        service.StartSession(book);
        service.EndSession(30);

        Assert.Equal(50, service.GetTotalPagesRead());
    }

    [Fact]
    public void SetYearlyGoal_ShouldStoreGoal()
    {
        var service = new ReadingService();

        service.SetYearlyGoal(2026, 10);

        Assert.Equal(2026, service.GetGoalYear());
        Assert.Equal(10, service.GetYearlyGoalBooks());
    }

    [Fact]
    public void GetGoalProgressText_ShouldReturnProgressString()
    {
        var service = new ReadingService();

        service.SetYearlyGoal(2026, 10);

        var result = service.GetGoalProgressText(3);

        Assert.Equal("3 / 10 books completed", result);
    }
}