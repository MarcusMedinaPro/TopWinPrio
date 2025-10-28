# PowerShell script to commit .NET 6 migration + cleanup workflows

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "==================================" -ForegroundColor Cyan
Write-Host "STEP 1: Remove old workflow files" -ForegroundColor Cyan
Write-Host "==================================" -ForegroundColor Cyan

$filesToRemove = @(
    ".github/workflows/security-fixes.yml"
    ".github/workflows/debug-virustotal.yml"
    ".github/workflows/sign_artifacts.yml"
)

foreach ($file in $filesToRemove) {
    if (Test-Path $file) {
        Remove-Item $file -Force
        Write-Host "✅ Removed: $file" -ForegroundColor Green
    }
}

Write-Host ""
Write-Host "================================" -ForegroundColor Cyan
Write-Host "STEP 2: Stage all changes" -ForegroundColor Cyan
Write-Host "================================" -ForegroundColor Cyan

git add TopWinPrio.CS/TopWinPrio.csproj `
        TopWinPrio.CS/GlobalUsings.cs `
        TopWinPrio.CS/TopWinPrio/MainForm.cs `
        TopWinPrio.CS/TopWinPrio/MainForm.Designer.cs `
        TopWinPrio.CS/TopWinPrio/Program.cs `
        TopWinPrio.CS/TopWinPrio/NativeMethods.cs `
        TopWinPrio.CS/TopWinPrio.Properties/Settings.cs `
        TopWinPrio.CS/Util/RegistryTools.cs `
        TopWinPrio.CS/AssemblyInfo.cs `
        CHANGELOG.md `
        .github/workflows/

Write-Host ""
Write-Host "================================" -ForegroundColor Cyan
Write-Host "STEP 3: Create commit" -ForegroundColor Cyan
Write-Host "================================" -ForegroundColor Cyan

$commitMessage = @"
Migrate to .NET 6 with comprehensive C# 10 modernization

**Code Modernization:**
- Converted to SDK-style project (135 → 53 lines)
- Added global usings (GlobalUsings.cs)
- Applied file-scoped namespaces throughout
- Converted ProcessData to record with init-only properties
- Applied target-typed new expressions
- Used generic Enum.Parse<T>()
- Applied record with expressions for immutable updates
- Used using declarations for resource management
- Separated MainForm into partial classes (MainForm.cs + MainForm.Designer.cs)

**CodeQL Fixes:**
- Fixed CodeQL warnings: Replaced generic catch clauses with specific exception types
- Added SuppressMessage attributes for P/Invoke methods with justifications
- Added SuppressMessage for top-level exception handler in Main()
- Added readonly modifier to Settings.defaultInstance field
- Suppressed false positive mutex assignment warning (intentional using declaration)

**Workflow Cleanup:**
- Removed security-fixes.yml (replaced by CodeQL in release.yml)
- Removed debug-virustotal.yml (no longer needed)
- Removed sign_artifacts.yml (replaced by release.yml stage 4)

**Version:**
- Bumped version to 3.0.0
- Updated CHANGELOG with complete migration details

🤖 Generated with [Claude Code](https://claude.com/claude-code)

Co-Authored-By: Claude <noreply@anthropic.com>
"@

git commit -m $commitMessage

Write-Host ""
Write-Host "✅ Commit created!" -ForegroundColor Green
Write-Host ""
Write-Host "Active workflows remaining:" -ForegroundColor Cyan
Get-ChildItem .github/workflows/*.yml | ForEach-Object {
    Write-Host "  ✓ $($_.Name)" -ForegroundColor Green
}

Write-Host ""
Write-Host "Run 'git push origin main' to push changes." -ForegroundColor Yellow
