# LabubuVerificator (Simplified)

This is a simplified, beginner-friendly rewrite of the Labubu verification tool. It intentionally uses minimal C# features so a newcomer can read and understand everything quickly.

Files included:

- `Program.cs` - Interactive CLI with continuous menu
- `SimpleVerifier.cs` - Core verification logic with fallback support
- `SimpleStorage.cs` - SQLite database helper for persistent storage
- `LabubuVerificator.csproj` - Project file with SQLite package reference

Features:

- Code verification with series information
- Manual product evaluation
- Persistent SQLite storage for verification codes
- Verification tracking:
  - First verification timestamp
  - Verification count with status messages
  - Series information for each code
- Interactive menu system (stays open until you exit)

Default verification codes:
- `ABC123` (Series: Big Into Energy)
- `XYZ999` (Series: Exciting Macarons)

How to run locally:

```bash
dotnet build
dotnet run
```

The CLI will present a menu with these options:
1. Verify by code
2. Manual check (teeth, colored teeth, glossy eyes, nose color)
3. Exit program

When verifying a code, you'll see:
- Whether the code is valid
- The product series
- When it was first verified
- How many times it has been checked
- Status message based on verification count:
  - First check: "First time ever checked MUNDUS"
  - 2-4 checks: "Several checks have been made on this product MUNDUS"
  - 5+ checks: "Product checked too many times, still genuine, but suspicious MUNDUS"

Storage:

The program uses a local SQLite database (`labubu.db`) to store:
- Verification codes
- Series information
- First verification timestamps
- Verification counts

Why this simplified version?

- Beginner-friendly code structure
- Simple SQLite integration for persistence
- Clear feedback and status messages
- Interactive menu for better usability
- Fallback verification if database is unavailable

Next steps (suggested):

- Add small unit tests to validate behavior
- Add admin interface for managing codes
- Add data export/import features
- Gradually reintroduce small abstractions (interfaces) as needed
