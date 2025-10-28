# PowerShell script to commit test project migration

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "Staging test project migration..." -ForegroundColor Cyan
git add TopWinPrio.Tests/TopWinPrio.Tests.csproj `
        TopWinPrio.Tests/RegistryToolsTests.cs `
        CHANGELOG.md

Write-Host ""
Write-Host "Creating commit..." -ForegroundColor Cyan

$commitMessage = @"
Migrate test project to .NET 6

- Converted TopWinPrio.Tests to SDK-style project
- Updated MSTest to v3.6.3 (latest)
- Added coverlet.collector for code coverage support
- Applied file-scoped namespace to test files
- Removed System.ArgumentException fully qualified name (use global using)
- Test project now compatible with .NET 6 main project

Fixes CI/CD error: NU1201 compatibility issue between net48 and net6.0-windows

🤖 Generated with [Claude Code](https://claude.com/claude-code)

Co-Authored-By: Claude <noreply@anthropic.com>
"@

git commit -m $commitMessage

Write-Host ""
Write-Host "✅ Commit created!" -ForegroundColor Green
Write-Host "Run 'git push origin main' to push." -ForegroundColor Yellow
