# PowerShell script to fix artifact path and retry release

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "=== Fixing Artifact Path & Retrying v3.0.0 ===" -ForegroundColor Cyan
Write-Host ""

# 1. Delete tags
Write-Host "1. Removing tags..." -ForegroundColor Yellow
git tag -d v3.0.0
git push origin :refs/tags/v3.0.0

# 2. Commit fix
Write-Host ""
Write-Host "2. Committing artifact path fix..." -ForegroundColor Yellow
git add .github/workflows/release.yml TopWinPrio.CS/TopWinPrio/Program.cs README.md CHANGELOG.md

$commitMessage = @"
Fix artifact upload path for v3.0.0 release

**Root Cause:**
- TopWinPrio.csproj is in TopWinPrio.CS/ (not TopWinPrio.CS/TopWinPrio/)
- Build output goes to TopWinPrio.CS/bin/Release/net8.0-windows/
- Workflow was looking in TopWinPrio.CS/TopWinPrio/bin/ (wrong!)

**Fixed:**
- Corrected artifact upload path to TopWinPrio.CS/bin/Release/net8.0-windows/
- Added debug output to list all .exe files for troubleshooting
- Fixed CodeQL mutex warning suppress message
- Updated README.md build commands
- Fixed CHANGELOG.md date

**Impact:**
- unsigned-bin artifact will now upload successfully
- Release pipeline can complete all 5 stages
- Build → Quality → Antivirus → Sign → Publish

🤖 Generated with [Claude Code](https://claude.com/claude-code)

Co-Authored-By: Claude <noreply@anthropic.com>
"@

git commit -m $commitMessage

# 3. Push
Write-Host ""
Write-Host "3. Pushing to main..." -ForegroundColor Yellow
git push origin main

# 4. Create tag
Write-Host ""
Write-Host "4. Creating tag v3.0.0..." -ForegroundColor Yellow
git tag -a v3.0.0 -m "TopWinPrio v3.0.0 - .NET 8 LTS with C# 12 modernization"

# 5. Push tag
Write-Host ""
Write-Host "5. Pushing tag v3.0.0..." -ForegroundColor Yellow
git push origin v3.0.0

Write-Host ""
Write-Host "=== ✅ Third time's the charm! ===" -ForegroundColor Green
Write-Host ""
Write-Host "Monitor: https://github.com/MarcusMedinaPro/TopWinPrio/actions" -ForegroundColor Yellow
Write-Host ""
