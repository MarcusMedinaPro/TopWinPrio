#!/bin/bash

cd /mnt/c/Git/MarcusMedina/TopWinPrio

echo "Staging files..."
git add TopWinPrio.CS/TopWinPrio.csproj \
        TopWinPrio.CS/GlobalUsings.cs \
        TopWinPrio.CS/TopWinPrio/MainForm.cs \
        TopWinPrio.CS/TopWinPrio/MainForm.Designer.cs \
        TopWinPrio.CS/TopWinPrio/Program.cs \
        TopWinPrio.CS/TopWinPrio/NativeMethods.cs \
        TopWinPrio.CS/Util/RegistryTools.cs \
        TopWinPrio.CS/AssemblyInfo.cs \
        CHANGELOG.md

echo "Creating commit..."
git commit -m "$(cat <<'EOF'
Migrate to .NET 6 with comprehensive C# 10 modernization

- Converted to SDK-style project (135 → 53 lines)
- Added global usings (GlobalUsings.cs)
- Applied file-scoped namespaces throughout
- Converted ProcessData to record with init-only properties
- Applied target-typed new expressions
- Used generic Enum.Parse<T>()
- Applied record with expressions for immutable updates
- Used using declarations for resource management
- Separated MainForm into partial classes (MainForm.cs + MainForm.Designer.cs)
- Bumped version to 3.0.0
- Updated CHANGELOG with complete migration details

🤖 Generated with [Claude Code](https://claude.com/claude-code)

Co-Authored-By: Claude <noreply@anthropic.com>
EOF
)"

echo "Commit created! Run 'git push origin main' to push."
