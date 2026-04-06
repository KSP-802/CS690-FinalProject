# Oliver's Learning Tracker

Oliver's Learning Tracker is a console-based .NET 10 application developed for the CS690 Final Project.

The application helps users organize books, save learning articles, and track reading sessions.

## Version 2.0.0 Features

### Core Features
- Add Book
- View Books
- Add Article
- View Articles
- Start Reading Session
- End Reading Session

### Version 2 Additional Functional Requirements
- Delete Book
- Search Books
- View Reading History
- View Total Pages Read

## Modular Structure

The application is organized into the following modules:

### Models
- `Book.cs`
- `Article.cs`
- `ReadingSession.cs`

### Services
- `LibraryService.cs`
- `ReadingService.cs`

### UI
- `Menu.cs`

### Program
- `Program.cs`

This modular structure improves readability, maintainability, and testability.

## Technologies Used

- C#
- .NET 10
- Console Application
- xUnit (for testing, if included)

## Project Structure

```text
CS690-FinalProject
├── src
│   └── OliversLearningTracker
│       ├── Models
│       │   ├── Book.cs
│       │   ├── Article.cs
│       │   └── ReadingSession.cs
│       ├── Services
│       │   ├── LibraryService.cs
│       │   └── ReadingService.cs
│       ├── UI
│       │   └── Menu.cs
│       ├── Program.cs
│       └── OliversLearningTracker.csproj

## How to Run

Clone the repository:

git clone https://github.com/KSP-802/CS690-FinalProject.git

Navigate to the project:

cd CS690-FinalProject/src/OliversLearningTracker

Run the application:

dotnet run

## Releases

- v1.0.0 — Initial working console version
- v2.0.0 — Modular and enhanced version with additional functional requirements

## Purpose

Even at Version 2.0.0, the software is already functional and useful because users can:

- manage books
- save learning articles
- track reading sessions
- search books
- remove books
- review reading history
- monitor total pages read
This makes the system meaningful for Oliver even if development stopped after Iteration 2.
