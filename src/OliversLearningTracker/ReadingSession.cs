public class ReadingSession
{
    public int SessionId { get; set; }
    public int BookId { get; set; }
    public string BookTitle { get; set; } = "";
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int PagesRead { get; set; }
}
