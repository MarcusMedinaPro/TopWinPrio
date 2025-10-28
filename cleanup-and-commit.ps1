# PowerShell script to clean up and commit

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "Raderar gamla filer..." -ForegroundColor Cyan

# Radera commit scripts
Remove-Item "commit-*.ps1" -Force
Remove-Item "cleanup-workflows.ps1" -Force -ErrorAction SilentlyContinue
Remove-Item "check-status.ps1" -Force -ErrorAction SilentlyContinue
Remove-Item "commit-all-changes.ps1" -Force -ErrorAction SilentlyContinue

# Radera föråldrad dokumentation
Remove-Item "MIGRATION_ROADMAP.md" -Force -ErrorAction SilentlyContinue
Remove-Item "NEXT_STEPS_NET48.md" -Force -ErrorAction SilentlyContinue
Remove-Item "NET_MIGRATION_PATH.md" -Force -ErrorAction SilentlyContinue
Remove-Item "SONARCLOUD_SETUP.md" -Force -ErrorAction SilentlyContinue
Remove-Item "GITHUB_ACTIONS_SETUP.md" -Force -ErrorAction SilentlyContinue
Remove-Item "SELF_HOSTED_RUNNER_SETUP.md" -Force -ErrorAction SilentlyContinue
Remove-Item "VIRUSTOTAL_VERIFICATION.md" -Force -ErrorAction SilentlyContinue
Remove-Item "VIRUSTOTAL_TROUBLESHOOTING.md" -Force -ErrorAction SilentlyContinue
Remove-Item "BRANCH_STRATEGY.md" -Force -ErrorAction SilentlyContinue
Remove-Item "README_BRANCH_CREATION.md" -Force -ErrorAction SilentlyContinue
Remove-Item "SECURITY_IMPROVEMENTS.md" -Force -ErrorAction SilentlyContinue
Remove-Item "AGENTS.md" -Force -ErrorAction SilentlyContinue

Write-Host "Committar..." -ForegroundColor Cyan

git add -A

$commitMessage = @"
Clean up old documentation and scripts

Removed obsolete files after .NET 8 migration completion:
- 10 commit scripts (no longer needed)
- 11 outdated documentation files (migration/setup guides)

Kept essential documentation:
- README.md, CHANGELOG.md
- CONTRIBUTING.md, CODE_OF_CONDUCT.md
- SECURITY.md, RELEASE_CHECKLIST.md

🤖 Generated with [Claude Code](https://claude.com/claude-code)

Co-Authored-By: Claude <noreply@anthropic.com>
"@

git commit -m $commitMessage

Write-Host ""
Write-Host "✅ Klart!" -ForegroundColor Green
Write-Host "Kör 'git push origin main' för att pusha." -ForegroundColor Yellow

# Ta bort detta script också
Remove-Item "cleanup-old-files.ps1" -Force -ErrorAction SilentlyContinue
