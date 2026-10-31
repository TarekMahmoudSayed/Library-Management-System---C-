# 📚 Library Management System (C# Console App)

A console-based library management system written in **C# / .NET 10**, built as a layered solution with four separate projects. It supports two roles (**Librarian** and **Member**), secure password storage, and plain-text file persistence.

> Designed and built from scratch as a learning project: the user stories, UML diagram, architecture, and code were all written by the author with C# fundamentals and OOP only.

---

## Table of Contents

- [Features](#features)
- [Roles & Permissions](#roles--permissions)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Data Storage](#data-storage)
- [Security](#security)
- [Getting Started](#getting-started)
- [Usage Walkthrough](#usage-walkthrough)
- [Design Documents](#design-documents)
- [Known Limitations](#known-limitations)
- [Roadmap](#roadmap)
- [Author](#author)

---

## Features

**Authentication & Authorization**
- Login with a library card username and password (masked input with `*`).
- Passwords are hashed with salted PBKDF2, never stored in plain text.
- Authentication ("who are you?") is separated from authorization ("what can you do?").
- Cards can be active or inactive; inactive cards are denied access.

**Book Management (Librarian)**
- Add a new book (title, ID, author, year) with duplicate-ID protection.
- Remove a book by ID or by title.
- List all books and view the details of a single book.

**Borrowing (Member)**
- Search for a book by ID or title (case-insensitive).
- Request to borrow an available book, with a confirmation prompt.
- Return a borrowed book.
- A book that is already borrowed cannot be borrowed again, and an available book cannot be "returned".

**User Management (Librarian)**
- Issue a new library card (name, phone, username, card ID, password, role).
- Usernames and card IDs must be unique.

**Robustness**
- Input validation for menu choices (numbers only, within range).
- Malformed or blank lines in the data files are skipped instead of crashing the app.
- Safe parsing with sensible fallbacks (`TryParse`) when reading records.

---

## Roles & Permissions

| Feature              | Librarian | Member |
|----------------------|:---------:|:------:|
| Add new book         |     ✅    |   ❌   |
| Remove book          |     ✅    |   ❌   |
| Add user card        |     ✅    |   ❌   |
| List all books       |     ✅    |   ✅   |
| Show book details    |     ✅    |   ✅   |
| Request borrow book  |     ❌    |   ✅   |
| Return book          |     ❌    |   ✅   |
| Logout               |     ✅    |   ✅   |

Roles are stored on the library card as a permission value: `-1` = Librarian, `1` = Member.

---

## Architecture

The solution follows a layered design. Each layer is its own project, and dependencies point in one direction only.

```
┌──────────────────────────────┐
│        Presentation          │  Console screens, menus, input handling
└──────────────┬───────────────┘
               │ uses
┌──────────────▼───────────────┐
│       Bussiness Layer        │  Use cases: AddNewBook, ReturnBook, Login, ...
└──────────────┬───────────────┘
               │ uses
┌──────────────▼───────────────┐      ┌──────────────────────────┐
│         Data Acess           │─────▶│      Infrastructure      │
│  Entities + file storage     │ uses │  Password hashing (PBKDF2)│
└──────────────────────────────┘      └──────────────────────────┘
```

| Project            | Responsibility                                                              |
|--------------------|-----------------------------------------------------------------------------|
| **Presentation**   | Console UI: login screen, menus, forms, input validation, program entry     |
| **Bussiness Layer**| Use cases, one class per operation, each exposing a static `Execute` method |
| **Data Acess**     | Entities (`Book`, `User`, `LibraryCard`, `Library`) and `TextFileStorage`   |
| **Infrastructure** | `EncryptionUtility` for hashing and verifying passwords                     |

The business layer uses one class per use case (for example `AddNewBook.Execute`, `RequestBorrowBook.Execute`), which keeps every file focused on a single responsibility.

---

## Project Structure

```
Library-Management-System---C-/
├── Library Management System.slnx
├── UML.png
├── User Stories.png
│
├── Presentation/
│   ├── Program.cs                  # Entry point (main loop)
│   ├── App.cs                      # Login flow and role routing
│   ├── LibrarianForm.cs            # Librarian session start
│   ├── LibraryUserForm.cs          # Member session start
│   ├── InputValidate.cs            # Safe int reading, masked password input
│   └── Screens/
│       ├── Screen.cs               # Shared screen header
│       ├── LoginScreen.cs
│       ├── LibrarianMenuScreen.cs
│       ├── LibraryUserMenuScreen.cs
│       ├── AddNewBookScreen.cs
│       ├── RemoveBookScreen.cs
│       ├── ListAllBooksScreen.cs
│       ├── ListBookDetails.cs
│       ├── AddNewUserScreen.cs
│       ├── RequestBorrowBookScreen.cs
│       └── ReturnBookScreen.cs
│
├── Bussiness Layer/
│   ├── UserRole.cs                 # None / Member / Librarian
│   ├── SearchBy.cs                 # ById / ByTitle
│   ├── Books/    (AddNewBook, RemoveBook, FindBook, ListAllBooks, LoadBooks)
│   ├── Borrowing/(RequestBorrowBook, ReturnBook)
│   └── Users/    (Login, AddNewUser)
│
├── Data Acess/
│   ├── Entities/ (Book, User, LibraryCard, Library, TextFileStorage, ...)
│   └── Data/
│       ├── Books.txt
│       └── Users.txt
│
└── Infrastructure/
    └── EncryptionUtility.cs
```

---

## Data Storage

Data is stored in plain-text files inside `Data Acess/Data/`. Each record is one line, with fields separated by the delimiter `#//#`.

**`Books.txt`**: `Title#//#ID#//#Author#//#Year#//#IsBorrowed`

```
The Pragmatic Programmer#//#102#//#Andrew Hunt#//#1999#//#False
```

**`Users.txt`**: `Name#//#Phone#//#UserName#//#CardID#//#PasswordHash#//#IssueDate#//#Permission#//#IsActive`

```
Ahmed Hassan#//#01012345678#//#ahmed_hassan#//#CARD-1001#//#<hash>#//#2023-01-15#//#1#//#true
```

- Books are loaded into memory when a session starts and saved back whenever a book is removed, borrowed, or returned.
- New books and new users are appended to their files.
- The storage layer locates the data folder dynamically by walking up from the build output directory, so the app works when run from Visual Studio or from the command line.

> ⚠️ Do not type the delimiter `#//#` inside any field, because it would corrupt the record.

---

## Security

- **Hashing:** PBKDF2 with SHA-256, a random 16-byte salt per password, 100,000 iterations, and a 32-byte derived key.
- **Storage format:** `iterations.salt.hash`, all Base64, so the parameters travel with the hash.
- **Verification:** fixed-time comparison (`CryptographicOperations.FixedTimeEquals`) to avoid timing leaks.
- **Masked input:** the password is hidden with `*` while typing.

---

## Getting Started

### Prerequisites

- [.NET SDK 10](https://dotnet.microsoft.com/download) (the projects target `net10.0`)
- Any editor: Visual Studio, VS Code, or Rider

### Clone and run

```bash
git clone https://github.com/TarekMahmoudSayed/Library-Management-System---C-.git
cd Library-Management-System---C-
dotnet build
dotnet run --project Presentation
```

Or open `Library Management System.slnx` in Visual Studio, set **Presentation** as the startup project, and press **F5**.

### Sample accounts

The repository ships with sample users in `Users.txt`:

| Username      | Name           | Role      |
|---------------|----------------|-----------|
| `ahmed_hassan`| Ahmed Hassan   | Member    |
| `sara_m`      | Sara Mohamed   | Member    |
| `mahmoud_ali` | Mahmoud Ali    | Librarian |

Passwords are stored only as hashes. To get a login you know, sign in as an existing Librarian (or create a user card yourself, since the app hashes the password for you), then add a new user from the menu.

---

## Usage Walkthrough

1. **Login:** enter your card username, then your password. A valid active card unlocks the menu for your role.
2. **Librarian menu**
   ```
   [1] Add New Book     [2] List All Books    [3] Remove Book
   [4] Show Book Details [5] Add User Card    [6] Logout
   ```
3. **Member menu**
   ```
   [1] List All Books        [2] Show Book Details
   [3] Request Borrow Book   [4] Return Book      [5] Logout
   ```
4. **Searching:** wherever a book is needed, choose to search by `[1] ID` or `[2] Title`.
5. **Borrowing:** find the book, confirm with `y`, and the book is marked as borrowed and saved.

---

## Design Documents

- **[UML.png](UML.png):** class diagram of the entities and layers.
- **[User Stories.png](User%20Stories.png):** the requirements the system was designed around.

---

## Known Limitations

- Borrowing records only whether a book is borrowed, not **who** borrowed it, when, or the due date.
- Data lives in text files, so there is no concurrent access and no transactions.
- The application state (`Library`, current user) is held in static classes.
- Book `ID` and `Year` are stored as strings, and there are no password-strength rules or login-attempt limits.
- No automated tests yet.

---


## Author

**Tarek Mahmoud Sayed**
GitHub: [@TarekMahmoudSayed](https://github.com/TarekMahmoudSayed)
