public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public int TotalPages { get; set; }

    public bool IsCompleted { get; set; }
    public DateTime? CompletedDate { get; set; }

    public List<string> Categories { get; set; } = new();
}