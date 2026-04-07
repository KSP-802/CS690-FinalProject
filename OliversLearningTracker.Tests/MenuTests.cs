using Xunit;

public class MenuTests
{
    [Fact]
    public void Menu_ShouldBeCreated()
    {
        var menu = new Menu();

        Assert.NotNull(menu);
    }
}