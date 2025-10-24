# LabubuVerificator (Simplified)

This is a simplified, beginner-friendly rewrite of the Labubu verification tool. It intentionally uses minimal C# features so a newcomer can read and understand everything quickly.

Files included:

- `Program.cs` - simple CLI entrypoint
- `SimpleVerifier.cs` - tiny verifier with two helpers:
  - `SimpleVerifyCode(string)` -> bool
  - `SimpleEvaluateManual(int teeth, int coloredTeeth, bool eyesGlossy, string noseColor)` -> string (High/Medium/Low)
- `LabubuVerificator.csproj` - project file

How to run locally:

```bash
dotnet build
dotnet run
```

The CLI will ask if you want to verify by code or do a manual check.

Why this simplified version?

- No interfaces, LINQ, or advanced patterns.
- Explicit control flow and plain lists to make the logic easy to follow.
- Good starting point for learning and then gradually refactoring to better patterns.

Next steps (suggested):

- Add small unit tests to validate behavior.
- Replace the in-memory code list with a JSON file or SQLite DB when ready.
- Gradually reintroduce small abstractions (interfaces) as you learn them.
