# PowerShell script to commit documentation updates

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "Staging documentation updates..." -ForegroundColor Cyan
git add README.md CHANGELOG.md

Write-Host ""
Write-Host "Creating commit..." -ForegroundColor Cyan

$commitMessage = @"
Update README and CHANGELOG for v3.0.0 release

**README.md Updates:**
- ✅ Updated status: Now code-signed and fully automated
- ✅ Runtime requirements: .NET 8 LTS instead of .NET Framework 3.5
- ✅ Downloads: Document 5-stage automated release pipeline
- ✅ Build from source: Modern dotnet CLI commands instead of msbuild
- ✅ Roadmap: Mark .NET 8 migration as complete
- ✅ Verify downloads: Document code signing and checksums
- ✅ Contributing: Reference GITFLOW.md and modern workflow
- ❌ Removed outdated references to:
  - Unsigned releases
  - StyleCop (replaced with .editorconfig)
  - MIGRATION_ROADMAP.md (removed file)
  - AGENTS.md (removed file)

**CHANGELOG.md Updates:**
- Fixed release date: 2025-01-15 (was incorrectly 2025-10-26)

**Impact:**
- Documentation now accurately reflects v3.0.0 state
- Clear instructions for .NET 8 requirements
- Updated contribution workflow
- Accurate roadmap showing completed migration

🤖 Generated with [Claude Code](https://claude.com/claude-code)

Co-Authored-By: Claude <noreply@anthropic.com>
"@

git commit -m $commitMessage

Write-Host ""
Write-Host "✅ Commit created!" -ForegroundColor Green
Write-Host "Run 'git push origin main' to push." -ForegroundColor Yellow
