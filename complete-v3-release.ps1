# PowerShell script to complete v3.0.0 release

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "=== Completing TopWinPrio v3.0.0 Release ===" -ForegroundColor Cyan
Write-Host ""

# 1. Stage all changes
Write-Host "1. Staging all changes..." -ForegroundColor Yellow
git add -A

# 2. Show what's being committed
Write-Host ""
Write-Host "Changes to commit:" -ForegroundColor Cyan
git status --short

Write-Host ""
Read-Host "Press Enter to continue or Ctrl+C to cancel"

# 3. Commit everything
Write-Host ""
Write-Host "2. Committing v3.0.0 changes..." -ForegroundColor Yellow

$commitMessage = @"
Release v3.0.0 - .NET 8 LTS Migration Complete

**Major Changes:**
- Migrated from .NET Framework 4.8 to .NET 8 LTS
- Upgraded to C# 12 with modern language features
- Enabled nullable reference types throughout
- Fixed all compiler warnings and code analysis issues

**Fixed Issues:**
- CS0579: Duplicate assembly attributes
- CS8618/CS8600/CS8603: Nullable reference warnings
- CS8625: Nullable event handler parameters
- CA1837: Performance improvement (Environment.ProcessId)
- CA1822: Static method optimization
- IDE0058: Unused expression values
- IDE0161: File-scoped namespaces
- Runtime crash: Invalid ProcessPriorityClass default value

**Modernization:**
- File-scoped namespaces throughout
- Discard pattern for unused values
- Nullable reference types fully implemented
- Static methods where appropriate
- Modern .editorconfig replacing StyleCop

**Build & CI:**
- Updated GitHub Actions for .NET 8
- Fixed artifact paths for SDK-style projects
- Simplified build process (dotnet build vs msbuild)

**Documentation:**
- Updated CHANGELOG.md with full migration details
- Added GITFLOW.md for development workflow
- Cleaned up obsolete documentation

**Testing:**
- Migrated test project to .NET 8
- All tests passing
- 125% display scaling issues resolved

🤖 Generated with [Claude Code](https://claude.com/claude-code)

Co-Authored-By: Claude <noreply@anthropic.com>
"@

git commit -m $commitMessage

# 4. Push to main
Write-Host ""
Write-Host "3. Pushing to main..." -ForegroundColor Yellow
git push origin main

# 5. Create and push tag
Write-Host ""
Write-Host "4. Creating tag v3.0.0..." -ForegroundColor Yellow
git tag -a v3.0.0 -m "TopWinPrio v3.0.0 - .NET 8 LTS with C# 12 modernization"

Write-Host ""
Write-Host "5. Pushing tag v3.0.0..." -ForegroundColor Yellow
git push origin v3.0.0

Write-Host ""
Write-Host "=== ✅ Release v3.0.0 Complete! ===" -ForegroundColor Green
Write-Host ""
Write-Host "GitHub Actions will now:" -ForegroundColor Cyan
Write-Host "  1. Build & Test" -ForegroundColor White
Write-Host "  2. Run Quality Gate (CodeQL)" -ForegroundColor White
Write-Host "  3. Antivirus Scan" -ForegroundColor White
Write-Host "  4. Code Signing" -ForegroundColor White
Write-Host "  5. Publish Release" -ForegroundColor White
Write-Host ""
Write-Host "Monitor progress at:" -ForegroundColor Yellow
Write-Host "  https://github.com/MarcusMedinaPro/TopWinPrio/actions" -ForegroundColor Gray
Write-Host ""
