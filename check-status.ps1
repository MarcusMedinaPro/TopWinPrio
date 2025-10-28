# Check git status and recent commits

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "Git Status:" -ForegroundColor Cyan
git status

Write-Host "`nRecent Commits:" -ForegroundColor Cyan
git log --oneline -5

Write-Host "`nModified files (if any):" -ForegroundColor Cyan
git diff --name-only

Write-Host "`nStaged files (if any):" -ForegroundColor Cyan
git diff --cached --name-only

Write-Host "`nChecking if our fixes are in the code:" -ForegroundColor Cyan

# Check if SuppressMessage exists in NativeMethods.cs
Write-Host "`nNativeMethods.cs:" -ForegroundColor Yellow
if (Select-String -Path "TopWinPrio.CS/TopWinPrio/NativeMethods.cs" -Pattern "SuppressMessage.*unmanaged-code" -Quiet) {
    Write-Host "  ✅ Has SuppressMessage for unmanaged code" -ForegroundColor Green
} else {
    Write-Host "  ❌ Missing SuppressMessage for unmanaged code" -ForegroundColor Red
}

# Check if specific exceptions exist in MainForm.cs
Write-Host "`nMainForm.cs:" -ForegroundColor Yellow
if (Select-String -Path "TopWinPrio.CS/TopWinPrio/MainForm.cs" -Pattern "catch.*Win32Exception" -Quiet) {
    Write-Host "  ✅ Has specific exception catches" -ForegroundColor Green
} else {
    Write-Host "  ❌ Still has generic catches" -ForegroundColor Red
}

# Check if readonly exists in Settings.cs
Write-Host "`nSettings.cs:" -ForegroundColor Yellow
if (Select-String -Path "TopWinPrio.CS/TopWinPrio.Properties/Settings.cs" -Pattern "private static readonly" -Quiet) {
    Write-Host "  ✅ Has readonly modifier" -ForegroundColor Green
} else {
    Write-Host "  ❌ Missing readonly modifier" -ForegroundColor Red
}

# Check Program.cs
Write-Host "`nProgram.cs:" -ForegroundColor Yellow
if (Select-String -Path "TopWinPrio.CS/TopWinPrio/Program.cs" -Pattern "SuppressMessage.*useless-assignment" -Quiet) {
    Write-Host "  ✅ Has SuppressMessage for mutex" -ForegroundColor Green
} else {
    Write-Host "  ❌ Missing SuppressMessage for mutex" -ForegroundColor Red
}
