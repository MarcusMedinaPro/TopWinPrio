# PowerShell script to commit .NET 6 migration

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "Staging files..." -ForegroundColor Cyan
git add TopWinPrio.CS/TopWinPrio.csproj `
        TopWinPrio.CS/GlobalUsings.cs `
        TopWinPrio.CS/TopWinPrio/MainForm.cs `
        TopWinPrio.CS/TopWinPrio/MainForm.Designer.cs `
        TopWinPrio.CS/TopWinPrio/Program.cs `
        TopWinPrio.CS/TopWinPrio/NativeMethods.cs `
        TopWinPrio.CS/TopWinPrio.Properties/Settings.cs `
        TopWinPrio.CS/Util/RegistryTools.cs `
        TopWinPrio.CS/AssemblyInfo.cs `
        CHANGELOG.md

Write-Host "Creating commit..." -ForegroundColor Cyan
$commitMessage = @"
Migrate to .NET 6 with comprehensive C# 10 modernization

- Converted to SDK-style project (135 → 53 lines)
- Added global usings (GlobalUsings.cs)
- Applied file-scoped namespaces throughout
- Converted ProcessData to record with init-only properties
- Applied target-typed new expressions
- Used generic Enum.Parse<T>()
- Applied record with expressions for immutable updates
- Used using declarations for resource management
- Separated MainForm into partial classes (MainForm.cs + MainForm.Designer.cs)
- Fixed CodeQL warnings: Replaced generic catch clauses with specific exception types
- Added SuppressMessage attributes for P/Invoke methods with justifications
- Added SuppressMessage for top-level exception handler in Main()
- Added readonly modifier to Settings.defaultInstance field
- Suppressed false positive mutex assignment warning (intentional using declaration)
- Bumped version to 3.0.0
- Updated CHANGELOG with complete migration details

🤖 Generated with [Claude Code](https://claude.com/claude-code)

Co-Authored-By: Claude <noreply@anthropic.com>
"@

git commit -m $commitMessage

Write-Host ""
Write-Host "✅ Commit created!" -ForegroundColor Green
Write-Host "Run 'git push origin main' to push." -ForegroundColor Yellow
