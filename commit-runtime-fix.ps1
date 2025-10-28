# PowerShell script to commit runtime bug fix

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "Staging runtime bug fix..." -ForegroundColor Cyan
git add TopWinPrio.CS/TopWinPrio/MainForm.cs

Write-Host ""
Write-Host "Creating commit..." -ForegroundColor Cyan

$commitMessage = @"
Fix runtime crash: Invalid ProcessPriorityClass enum value

**Fixed Runtime Exception:**
- ProcessPriorityClass default value (0) is not a valid enum member
- Application crashed when trying to restore process priority

**Root Cause:**
- oldProc initialized with default values (LastPrio = 0, ProcessID = 0)
- ProcessPriorityClass enum has no 0 value (valid: 32=Normal, 64=Idle, 128=High, etc.)
- SetProcessPrio() tried to set priority to 0, causing ArgumentException

**Fix Applied:**
1. Initialize oldProc with valid default: ProcessPriorityClass.Normal
2. Added validation in SetProcessPrio() to prevent invalid enum values
3. Check ProcessID > 0 before attempting priority change
4. Use Enum.IsDefined() to validate ProcessPriorityClass

**Impact:**
- Application now starts without crashing
- Invalid priority values are safely rejected
- Process priority changes work correctly

**Valid ProcessPriorityClass values:**
- Idle = 64
- BelowNormal = 16384
- Normal = 32
- AboveNormal = 32768
- High = 128
- RealTime = 256

🤖 Generated with [Claude Code](https://claude.com/claude-code)

Co-Authored-By: Claude <noreply@anthropic.com>
"@

git commit -m $commitMessage

Write-Host ""
Write-Host "✅ Commit created!" -ForegroundColor Green
Write-Host "Run 'git push origin main' to push." -ForegroundColor Yellow
