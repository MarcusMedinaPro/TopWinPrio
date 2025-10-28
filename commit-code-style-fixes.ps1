# PowerShell script to commit code style fixes

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "Removing StyleCop (replaced by .editorconfig)..." -ForegroundColor Cyan
if (Test-Path "TopWinPrio.CS/stylecop.json") {
    Remove-Item "TopWinPrio.CS/stylecop.json" -Force
    Write-Host "✅ Removed stylecop.json" -ForegroundColor Green
}

Write-Host ""
Write-Host "Staging code style fixes..." -ForegroundColor Cyan
git add TopWinPrio.CS/TopWinPrio/Program.cs `
        TopWinPrio.CS/TopWinPrio.csproj `
        .editorconfig

Write-Host ""
Write-Host "Creating commit..." -ForegroundColor Cyan

$commitMessage = @"
Remove StyleCop and modernize code analysis

**Removed StyleCop.Analyzers:**
- Removed outdated StyleCop.Analyzers package (v1.1.118 from 2018)
- Removed stylecop.json configuration
- Replaced with modern .editorconfig + built-in Roslyn analyzers

**Added Modern .editorconfig:**
- C# 12 / .NET 8 conventions
- File-scoped namespace support
- Modern naming conventions (interfaces start with I, PascalCase for types)
- Code quality rules (unused parameters, unnecessary suppressions)
- Consistent formatting across all editors (VS, Rider, VSCode)

**Syntax Fixes:**
- Moved SuppressMessage attributes from invalid position (between try/catch) to Main method
- Fixed CS7014: Attributes cannot be placed between try and catch blocks
- Fixed CS1524/CS1003: Try-catch syntax errors
- Expression body for simple lambda (IDE0053)
- Added period to XML documentation comments
- Improved pattern matching in UnhandledException handler

**Benefits:**
- .editorconfig is industry standard (works with all modern editors)
- Built-in Roslyn analyzers are more modern and maintained by Microsoft
- Better support for C# 12 features
- Faster builds (one less analyzer package)

🤖 Generated with [Claude Code](https://claude.com/claude-code)

Co-Authored-By: Claude <noreply@anthropic.com>
"@

git commit -m $commitMessage

Write-Host ""
Write-Host "✅ Commit created!" -ForegroundColor Green
Write-Host "Run 'git push origin main' to push." -ForegroundColor Yellow
