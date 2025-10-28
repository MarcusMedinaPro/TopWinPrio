# PowerShell script to commit warning fixes

Set-Location "C:\Git\MarcusMedina\TopWinPrio"

Write-Host "Staging warning fixes..." -ForegroundColor Cyan
git add TopWinPrio.CS/TopWinPrio.csproj `
        TopWinPrio.CS/TopWinPrio/MainForm.cs `
        TopWinPrio.CS/TopWinPrio/Program.cs `
        TopWinPrio.CS/TopWinPrio.Properties/Resources.cs

Write-Host ""
Write-Host "Creating commit..." -ForegroundColor Cyan

$commitMessage = @"
Fix all compiler warnings and code analysis issues

**Fixed CS0579 - Duplicate Assembly Attributes:**
- Added GenerateAssemblyInfo=false to prevent SDK auto-generation
- Keeps manual AssemblyInfo.cs for version control

**Fixed CS8618, CS8600, CS8603 - Resources.cs Nullable Warnings:**
- Made resourceCulture and resourceMan nullable (CultureInfo?, ResourceManager?)
- Made Culture property nullable (CultureInfo?)
- Used null-forgiving operator (!) for embedded resources (always exist)
- Converted to file-scoped namespace (IDE0161)

**Fixed CS8625 - Nullable Reference Warnings:**
- Made event handler parameters nullable: object?, ScrollEventArgs?, MouseEventArgs?
- Used null-forgiving operator (!) when calling with null intentionally

**Fixed CA1837 - Performance:**
- Replaced Process.GetCurrentProcess().Id with Environment.ProcessId
- Simpler and faster in .NET 6+

**Fixed CA1822 - Static Method:**
- Made CreateProcessData static (doesn't use instance state)
- Better performance for static-eligible methods

**Fixed IDE0058 - Unused Expression Values:**
- Discarded unused return values with _ (discard pattern)
- SetProcessPrio(), SubItems.Add(), Items.Insert(), Focus()

**Fixed IDE0079 - Unnecessary Suppressions:**
- Removed cs/useless-assignment-to-local suppression (no longer needed)
- Kept only necessary suppressions (CA1031, cs/catch-of-all-exceptions)

**Modern C# Best Practices:**
- Nullable reference types fully implemented
- Discard pattern for unused values
- Static methods where appropriate
- Environment.ProcessId over Process.GetCurrentProcess().Id
- File-scoped namespaces throughout

🤖 Generated with [Claude Code](https://claude.com/claude-code)

Co-Authored-By: Claude <noreply@anthropic.com>
"@

git commit -m $commitMessage

Write-Host ""
Write-Host "✅ Commit created!" -ForegroundColor Green
Write-Host "Run 'git push origin main' to push." -ForegroundColor Yellow
