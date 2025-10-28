# PowerShell script to clean up old documentation and commit scripts

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "Cleaning up old files..." -ForegroundColor Cyan
Write-Host ""

# Remove all commit scripts (no longer needed after commits are done)
Write-Host "Removing commit scripts..." -ForegroundColor Yellow
Remove-Item -Path "commit-net6.ps1" -ErrorAction SilentlyContinue
Remove-Item -Path "cleanup-workflows.ps1" -ErrorAction SilentlyContinue
Remove-Item -Path "commit-all-changes.ps1" -ErrorAction SilentlyContinue
Remove-Item -Path "check-status.ps1" -ErrorAction SilentlyContinue
Remove-Item -Path "commit-test-migration.ps1" -ErrorAction SilentlyContinue
Remove-Item -Path "commit-net8-upgrade.ps1" -ErrorAction SilentlyContinue
Remove-Item -Path "commit-code-style-fixes.ps1" -ErrorAction SilentlyContinue
Remove-Item -Path "commit-nullable.ps1" -ErrorAction SilentlyContinue
Remove-Item -Path "commit-fix-warnings.ps1" -ErrorAction SilentlyContinue
Remove-Item -Path "commit-runtime-fix.ps1" -ErrorAction SilentlyContinue

# Remove outdated documentation (migration complete)
Write-Host "Removing outdated migration docs..." -ForegroundColor Yellow
Remove-Item -Path "MIGRATION_ROADMAP.md" -ErrorAction SilentlyContinue
Remove-Item -Path "NEXT_STEPS_NET48.md" -ErrorAction SilentlyContinue
Remove-Item -Path "NET_MIGRATION_PATH.md" -ErrorAction SilentlyContinue

# Remove outdated setup docs (setup complete)
Write-Host "Removing outdated setup docs..." -ForegroundColor Yellow
Remove-Item -Path "SONARCLOUD_SETUP.md" -ErrorAction SilentlyContinue
Remove-Item -Path "GITHUB_ACTIONS_SETUP.md" -ErrorAction SilentlyContinue
Remove-Item -Path "SELF_HOSTED_RUNNER_SETUP.md" -ErrorAction SilentlyContinue

# Remove outdated VirusTotal docs (if no longer relevant)
Write-Host "Removing VirusTotal troubleshooting docs..." -ForegroundColor Yellow
Remove-Item -Path "VIRUSTOTAL_VERIFICATION.md" -ErrorAction SilentlyContinue
Remove-Item -Path "VIRUSTOTAL_TROUBLESHOOTING.md" -ErrorAction SilentlyContinue

# Remove branch strategy docs (if not actively used)
Write-Host "Removing branch strategy docs..." -ForegroundColor Yellow
Remove-Item -Path "BRANCH_STRATEGY.md" -ErrorAction SilentlyContinue
Remove-Item -Path "README_BRANCH_CREATION.md" -ErrorAction SilentlyContinue

# Remove security improvements doc (if implemented)
Write-Host "Removing security improvements doc..." -ForegroundColor Yellow
Remove-Item -Path "SECURITY_IMPROVEMENTS.md" -ErrorAction SilentlyContinue

# Remove agents doc (unclear purpose)
Write-Host "Removing agents doc..." -ForegroundColor Yellow
Remove-Item -Path "AGENTS.md" -ErrorAction SilentlyContinue

Write-Host ""
Write-Host "✅ Cleanup complete!" -ForegroundColor Green
Write-Host ""
Write-Host "Files kept:" -ForegroundColor Cyan
Write-Host "  - README.md (main documentation)"
Write-Host "  - CHANGELOG.md (version history)"
Write-Host "  - CONTRIBUTING.md (contribution guidelines)"
Write-Host "  - CODE_OF_CONDUCT.md (community guidelines)"
Write-Host "  - SECURITY.md (security policy)"
Write-Host "  - RELEASE_CHECKLIST.md (useful for future releases)"
Write-Host ""
Write-Host "Run 'git add -A' and 'git commit -m \"Clean up old documentation and scripts\"' to commit." -ForegroundColor Yellow
