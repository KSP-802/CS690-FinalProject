using Xunit;

public class MenuTests
{
    [Fact]
    public void Menu_ShouldInitialize()
    {
        var menu = new Menu();

        Assert.NotNull(menu);
    }
}