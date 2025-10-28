# PowerShell script to release v3.0.0

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "=== TopWinPrio v3.0.0 Release ===" -ForegroundColor Cyan
Write-Host ""

# Commit pending changes
Write-Host "Staging changes..." -ForegroundColor Yellow
git add -A

Write-Host "Committing fixes..." -ForegroundColor Yellow

$commitMessage = @"
Fix all warnings and runtime issues for v3.0.0 release

**Fixed Nullable Warnings (Resources.cs):**
- Made resourceCulture and resourceMan nullable
- Made Culture property nullable
- Used null-forgiving operator for embedded resources
- Converted to file-scoped namespace

**Fixed Runtime Crash:**
- ProcessPriorityClass default value (0) invalid
- Initialize oldProc with ProcessPriorityClass.Normal
- Added validation in SetProcessPrio()
- Check ProcessID > 0 and Enum.IsDefined()

**Impact:**
- Application starts without crashing
- Clean build with no warnings
- All nullable reference types properly handled

🤖 Generated with [Claude Code](https://claude.com/claude-code)

Co-Authored-By: Claude <noreply@anthropic.com>
"@

git commit -m $commitMessage

Write-Host ""
Write-Host "Creating tag v3.0.0..." -ForegroundColor Yellow
git tag -a v3.0.0 -m "TopWinPrio v3.0.0 - .NET 8 LTS with C# 12 modernization"

Write-Host ""
Write-Host "Pushing to origin..." -ForegroundColor Yellow
git push origin main
git push origin v3.0.0

Write-Host ""
Write-Host "✅ Release v3.0.0 complete!" -ForegroundColor Green
Write-Host ""
Write-Host "Next steps:" -ForegroundColor Cyan
Write-Host "  1. Go to GitHub Releases"
Write-Host "  2. Create release from tag v3.0.0"
Write-Host "  3. Upload binaries"
Write-Host ""
