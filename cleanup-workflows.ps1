# PowerShell script to remove old/disabled workflow files

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "Removing old workflow files..." -ForegroundColor Cyan

$filesToRemove = @(
    ".github/workflows/security-fixes.yml"
    ".github/workflows/debug-virustotal.yml"
    ".github/workflows/sign_artifacts.yml"
)

foreach ($file in $filesToRemove) {
    if (Test-Path $file) {
        Remove-Item $file -Force
        Write-Host "✅ Removed: $file" -ForegroundColor Green
    } else {
        Write-Host "⚠️  Not found: $file" -ForegroundColor Yellow
    }
}

Write-Host ""
Write-Host "Remaining active workflows:" -ForegroundColor Cyan
Get-ChildItem .github/workflows/*.yml | ForEach-Object {
    Write-Host "  ✓ $($_.Name)" -ForegroundColor Green
}

Write-Host ""
Write-Host "Stage these changes with:" -ForegroundColor Yellow
Write-Host "  git add .github/workflows/" -ForegroundColor White
Write-Host "  git commit -m 'Remove old/disabled workflow files'" -ForegroundColor White
