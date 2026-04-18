# Oliver's Learning Tracker

Oliver's Learning Tracker is a console-based .NET 10 application developed for the CS690 Final Project.

The application helps users organize books, save learning articles, manage categories, and track reading sessions, goals, and statistics.

---

## Version 3.0.0 Features (Final)

### Core Features
- Add Book
- View Books
- Mark Book as Completed with Completion Date
- Add Article
- View Articles

### Category Management
- Create Categories
- Assign Categories to Books
- Assign Categories to Articles

### Reading Session Tracking
- Start Reading Session
- End Reading Session (tracks pages read and duration)

### Analytics and Goals
- View Yearly Statistics (books completed and hours read)
- Set Yearly Reading Goal
- View Goal Progress

### Additional Features (Version 2 Enhancements)
- Delete Book
- Search Books
- View Reading History
- View Total Pages Read

---

## Modular Structure

The application follows a modular design:

### Models
- `Book.cs`
- `Article.cs`
- `ReadingSession.cs`
- `Category.cs`

### Services
- `LibraryService.cs` (books, articles, categories)
- `ReadingService.cs` (sessions, goals, statistics)

### UI
- `Menu.cs` (console interface)

### Program
- `Program.cs` (application flow and orchestration)

This modular structure improves:
- readability
- maintainability
- testability

---

## Testing

A separate test project is included:

- `OliversLearningTracker.Tests`

Tests cover:
- LibraryService
- ReadingService
- Menu

Run tests with:

```bash
dotnet test CS690-FinalProject.slnx
