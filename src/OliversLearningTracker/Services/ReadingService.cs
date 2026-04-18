using System;
using System.Collections.Generic;
using System.Linq;

public class ReadingService
{
    private List<ReadingSession> sessions = new();
    private ReadingSession? activeSession;
    private int nextSessionId = 1;

    private int yearlyGoalBooks = 0;
    private int goalYear = DateTime.Now.Year;

    public string StartSession(Book book)
    {
        if (activeSession != null)
        {
            return "Session already active";
        }

        activeSession = new ReadingSession
        {
            SessionId = nextSessionId++,
            BookId = book.Id,
            BookTitle = book.Title,
            StartTime = DateTime.Now
        };

        return "Session started";
    }

    public string EndSession(int pagesRead)
    {
        if (activeSession == null)
        {
            return "No active session";
        }

        activeSession.EndTime = DateTime.Now;
        activeSession.PagesRead = pagesRead;

        sessions.Add(activeSession);
        activeSession = null;

        return "Session saved";
    }

    public List<ReadingSession> GetSessions()
    {
        return sessions;
    }

    public int GetTotalPagesRead()
    {
        return sessions.Sum(s => s.PagesRead);
    }

    public double GetTotalHoursReadForYear(int year)
    {
        return sessions
            .Where(s => s.EndTime.HasValue && s.EndTime.Value.Year == year)
            .Sum(s => (s.EndTime!.Value - s.StartTime).TotalHours);
    }

    public void SetYearlyGoal(int year, int goalBooks)
    {
        goalYear = year;
        yearlyGoalBooks = goalBooks;
    }

    public int GetGoalYear()
    {
        return goalYear;
    }

    public int GetYearlyGoalBooks()
    {
        return yearlyGoalBooks;
    }

    public string GetGoalProgressText(int completedBooks)
    {
        if (yearlyGoalBooks <= 0)
        {
            return "No yearly goal set.";
        }

        return $"{completedBooks} / {yearlyGoalBooks} books completed";
    }
}