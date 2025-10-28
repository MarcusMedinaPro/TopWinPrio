# PowerShell script to commit nullable reference types

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "Staging nullable reference types..." -ForegroundColor Cyan
git add TopWinPrio.CS/TopWinPrio.csproj `
        TopWinPrio.CS/TopWinPrio/MainForm.cs `
        TopWinPrio.Tests/TopWinPrio.Tests.csproj

Write-Host ""
Write-Host "Creating commit..." -ForegroundColor Cyan

$commitMessage = @"
Enable nullable reference types (C# 8+)

- Enabled nullable reference types in TopWinPrio.csproj
- Enabled nullable reference types in TopWinPrio.Tests.csproj
- Fixed CS8632 warning in MainForm.cs (ProcessData? now valid)

Benefits:
- Modern C# 8+ feature for better null safety
- Compile-time null reference checking
- Prevents NullReferenceException at runtime
- Industry standard for .NET 8 projects
- Better code clarity and intent

ProcessData? CreateProcessData() now correctly annotated as nullable
since it returns null on exceptions (Win32Exception, InvalidOperationException, NotSupportedException)

🤖 Generated with [Claude Code](https://claude.com/claude-code)

Co-Authored-By: Claude <noreply@anthropic.com>
"@

git commit -m $commitMessage

Write-Host ""
Write-Host "✅ Commit created!" -ForegroundColor Green
Write-Host "Run 'git push origin main' to push." -ForegroundColor Yellow
