# PowerShell script to retry v3.0.0 release

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "=== Retrying v3.0.0 Release ===" -ForegroundColor Cyan
Write-Host ""

# 1. Ta bort lokal tag
Write-Host "1. Removing local tag v3.0.0..." -ForegroundColor Yellow
git tag -d v3.0.0

# 2. Ta bort remote tag
Write-Host "2. Removing remote tag v3.0.0..." -ForegroundColor Yellow
git push origin :refs/tags/v3.0.0

# 3. Committa nya ändringar (workflow + docs + suppress fix)
Write-Host ""
Write-Host "3. Committing workflow fix and documentation updates..." -ForegroundColor Yellow
git add .github/workflows/release.yml README.md CHANGELOG.md TopWinPrio.CS/TopWinPrio/Program.cs

$commitMessage = @"
Fix release workflow and update documentation for v3.0.0

**Fixed Release Workflow (.github/workflows/release.yml):**
- Fixed solution path: TopWinPrio.sln (not TopWinPrio.CS/TopWinPrio.sln)
- Solution file is in repository root, not subdirectory
- Applied fix to all 3 build steps in workflow

**Fixed CodeQL Warning (Program.cs):**
- Updated SuppressMessage justification for mutex variable
- Clarified that mutex MUST be held for app lifetime
- Prevents false positive: variable is not useless, it prevents multiple instances

**README.md Updates:**
- Updated status: Code-signed and fully automated
- Runtime requirements: .NET 8 LTS
- Downloads: 5-stage automated pipeline documented
- Build: Modern dotnet CLI commands (fixed paths)
- Roadmap: .NET 8 migration marked complete
- Verify: Code signing and checksums documented
- Contributing: GITFLOW.md workflow with correct paths
- Badges: Updated to build-test.yml + release.yml

**CHANGELOG.md Updates:**
- Fixed release date: 2025-01-15

**Impact:**
- Release workflow will now build successfully
- Documentation has correct build commands
- Ready for v3.0.0 automated release

🤖 Generated with [Claude Code](https://claude.com/claude-code)

Co-Authored-By: Claude <noreply@anthropic.com>
"@

git commit -m $commitMessage

# 4. Push till main
Write-Host ""
Write-Host "4. Pushing to main..." -ForegroundColor Yellow
git push origin main

# 5. Skapa ny tag
Write-Host ""
Write-Host "5. Creating new tag v3.0.0..." -ForegroundColor Yellow
git tag -a v3.0.0 -m "TopWinPrio v3.0.0 - .NET 8 LTS with C# 12 modernization"

# 6. Push tag
Write-Host ""
Write-Host "6. Pushing tag v3.0.0..." -ForegroundColor Yellow
git push origin v3.0.0

Write-Host ""
Write-Host "=== ✅ Release Retry Complete! ===" -ForegroundColor Green
Write-Host ""
Write-Host "Monitor at: https://github.com/MarcusMedinaPro/TopWinPrio/actions" -ForegroundColor Yellow
Write-Host ""
