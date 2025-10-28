# PowerShell script to commit release workflow fix

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "Staging release workflow fix..." -ForegroundColor Cyan
git add .github/workflows/release.yml

Write-Host ""
Write-Host "Creating commit..." -ForegroundColor Cyan

$commitMessage = @"
Fix release workflow for .NET 8 SDK-style project

**Fixed Artifact Upload Path:**
- Changed from TopWinPrio.CS/bin/Release/*.exe
- To TopWinPrio.CS/TopWinPrio/bin/Release/net8.0-windows/*.exe
- SDK-style projects output to net8.0-windows subfolder

**Fixed Build Commands:**
- Replaced msbuild with dotnet build
- Removed unnecessary MSBuild and NuGet setup steps
- Simplified restore to dotnet restore

**Removed StyleCop:**
- Removed StyleCop-Report.log upload (no longer used)
- Kept CodeAnalysis-Report.log for compiler warnings

**Impact:**
- unsigned-bin artifact now uploads correctly
- Release pipeline can complete all 5 jobs
- Cleaner build process for .NET 8

🤖 Generated with [Claude Code](https://claude.com/claude-code)

Co-Authored-By: Claude <noreply@anthropic.com>
"@

git commit -m $commitMessage

Write-Host ""
Write-Host "✅ Commit created!" -ForegroundColor Green
Write-Host "Run 'git push origin main' to push." -ForegroundColor Yellow
