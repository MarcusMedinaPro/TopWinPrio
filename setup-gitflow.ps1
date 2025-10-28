# PowerShell script to setup gitflow

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "=== Setup Gitflow ===" -ForegroundColor Cyan
Write-Host ""

# Skapa develop branch
Write-Host "Skapar develop branch..." -ForegroundColor Yellow
git checkout -b develop
git push -u origin develop

Write-Host ""
Write-Host "✅ Gitflow setup klar!" -ForegroundColor Green
Write-Host ""
Write-Host "Workflow:" -ForegroundColor Cyan
Write-Host "  1. develop - Daglig utveckling + quality tests" -ForegroundColor White
Write-Host "  2. main    - Produktionsklar, endast från develop" -ForegroundColor White
Write-Host ""
Write-Host "Arbetsflöde:" -ForegroundColor Yellow
Write-Host "  git checkout develop"
Write-Host "  # Gör ändringar..."
Write-Host "  git add -A"
Write-Host "  git commit -m 'feat: something'"
Write-Host "  git push origin develop"
Write-Host ""
Write-Host "  # När quality tests passerar:"
Write-Host "  git checkout main"
Write-Host "  git merge develop"
Write-Host "  git push origin main"
Write-Host "  git tag -a v3.1.0 -m 'Release v3.1.0'"
Write-Host "  git push origin v3.1.0"
Write-Host ""
