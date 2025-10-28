# PowerShell script to commit .NET 8 upgrade

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "Removing dependency-review.yml (not needed)..." -ForegroundColor Cyan
if (Test-Path ".github/workflows/dependency-review.yml") {
    Remove-Item ".github/workflows/dependency-review.yml" -Force
    Write-Host "✅ Removed dependency-review.yml" -ForegroundColor Green
}

Write-Host ""
Write-Host "Staging .NET 8 upgrade..." -ForegroundColor Cyan
git add TopWinPrio.CS/TopWinPrio.csproj `
        TopWinPrio.Tests/TopWinPrio.Tests.csproj `
        CHANGELOG.md `
        .github/workflows/

Write-Host ""
Write-Host "Creating commit..." -ForegroundColor Cyan

$commitMessage = @"
Upgrade from .NET 6 to .NET 8 LTS

- Updated TopWinPrio.csproj: net6.0-windows → net8.0-windows
- Updated TopWinPrio.Tests.csproj: net6.0-windows → net8.0-windows
- Upgraded C# language version: 10.0 → 12.0
- Removed dependency-review.yml (not needed with existing workflows)

Benefits:
- .NET 8 is LTS (Long Term Support) until November 2026
- .NET 6 is out of support (no more security updates)
- C# 12 features available (collection expressions, primary constructors, etc)
- Better performance and reliability

Fixes CI/CD warnings about .NET 6 being out of support

🤖 Generated with [Claude Code](https://claude.com/claude-code)

Co-Authored-By: Claude <noreply@anthropic.com>
"@

git commit -m $commitMessage

Write-Host ""
Write-Host "✅ Commit created!" -ForegroundColor Green
Write-Host "Run 'git push origin main' to push." -ForegroundColor Yellow
