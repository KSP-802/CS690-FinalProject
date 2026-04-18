public class Article
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Url { get; set; } = "";
    public DateTime DateSaved { get; set; }

    public List<string> Categories { get; set; } = new();
}
