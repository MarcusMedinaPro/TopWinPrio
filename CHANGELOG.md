# Changelog

All notable changes to TopWinPrio will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.0.0] - 2025-10-26

### Changed - .NET 6 Migration with Comprehensive C# 10 Modernization
- **BREAKING**: Migrated from .NET Framework 4.8 to .NET 6 (cross-platform .NET)
- **Project Structure**: Converted to SDK-style .csproj format
  - Reduced from 135 lines (old-style) to 53 lines (SDK-style)
  - Implicit file inclusion with globbing patterns
  - Modern MSBuild targets and properties
  - Target Framework: `net6.0-windows` with `UseWindowsForms=true`
  - C# Language Version: 10.0

### Added - Modern C# 10 Features
- **Global Usings** (`GlobalUsings.cs`): Centralized common namespace imports
  - `global using System;`
  - `global using System.Diagnostics;`
  - `global using System.Drawing;`
  - `global using System.Windows.Forms;`
  - Removed redundant using statements from all files

- **File-Scoped Namespaces**: Modern namespace syntax across all files
  ```csharp
  namespace TopWinPrio;  // Instead of namespace TopWinPrio { }
  ```

- **Records with Init-Only Properties**: Immutable data types with value semantics
  ```csharp
  private sealed record ProcessData
  {
      public ProcessPriorityClass LastPrio { get; init; }
      public int ProcessID { get; init; }
  }
  ```

- **Target-Typed New Expressions**: Type inference for object creation
  ```csharp
  oldProc = new();              // Instead of new ProcessData()
  var size = new(0, 0);         // Instead of new Size(0, 0)
  StringBuilder sb = new(256);  // Instead of new StringBuilder(256)
  ```

- **Generic Enum.Parse**: Type-safe enum parsing
  ```csharp
  Enum.Parse<ProcessPriorityClass>(text)  // Instead of (ProcessPriorityClass)Enum.Parse(typeof(...))
  ```

- **Record With Expressions**: Non-destructive immutable updates
  ```csharp
  processData = processData with
  {
      LastPrio = Enum.Parse<ProcessPriorityClass>(inactiveList.Text)
  };
  ```

- **Using Declarations**: Simplified resource management without braces
  ```csharp
  using var mutex = new Mutex(...);  // Disposed at end of scope
  using var frmPrio = new MainForm { Visible = false };
  using var registryKey = Registry.CurrentUser.OpenSubKey(...);
  ```

### Changed - Code Structure Improvements
- **Separated MainForm into partial classes** (standard Windows Forms pattern)
  - **MainForm.cs** (306 lines): Business logic, event handlers, application code
  - **MainForm.Designer.cs** (~700 lines): UI designer-generated code
  - Proper separation of concerns matching Visual Studio designer expectations
  - Easier maintenance: UI changes don't affect business logic

- **Modernized all source files** with C# 10 syntax:
  - `MainForm.cs`: Records, target-typed new, generic Enum.Parse, with expressions
  - `Program.cs`: Using declarations, file-scoped namespace
  - `NativeMethods.cs`: Removed redundant usings, target-typed new for StringBuilder
  - `RegistryTools.cs`: Using declarations, file-scoped namespace

### Version
- Bumped version from 2.1.0 to **3.0.0** (major version for .NET 6 migration)
- Updated `AssemblyInfo.cs`: `AssemblyVersion` and `AssemblyFileVersion` to 3.0.0.0

### Benefits of .NET 6 Migration
- **Cross-Platform .NET**: Modern, unified .NET platform (no longer .NET Framework)
- **Performance**: Significant runtime performance improvements over .NET Framework
- **Language Features**: Access to C# 10 and future C# versions
- **Long-Term Support**: .NET 6 LTS supported until November 2024
- **Modern Tooling**: Better IDE support, SDK-style projects, simplified build system
- **Improved APIs**: Enhanced BCL with spans, value tuples, and async improvements
- **Smaller Deployment**: Self-contained and trimmed deployments available

### Runtime Requirements
- Requires .NET 6 Desktop Runtime (Windows Forms support)
- Windows 10 1607+ or Windows 11
- Previous .NET Framework 4.8 version available on `net4.8` branch (tagged `baseline-net4.8`)

### Migration Notes
- **.NET 6 vs .NET Framework**: This is **cross-platform .NET**, not .NET Framework
- **Breaking Change**: Applications must install .NET 6 runtime (not included in Windows by default)
- **Compatibility**: Full Windows Forms API compatibility maintained
- **Legacy Branch**: .NET Framework 4.8 code preserved on `net4.8` branch for reference

## [2.1.0] - 2025-10-26

### Changed - CI/CD Pipeline Optimization
- **MAJOR**: Restructured CI/CD workflows for efficiency and linear execution
- Split workflows into fast feedback loop (push/PR) and comprehensive release pipeline (tags)
- **build-test.yml**: Simplified for rapid feedback (~2-3 minutes)
  - Removed VirusTotal scan from push/PR workflow
  - Removed checksum generation and analysis logs
  - Focus: Compile + Unit Tests only for development iterations
- **release.yml**: New 5-stage linear pipeline for releases
  - 1️⃣ Build & Unit Test
  - 2️⃣ Quality Gate (CodeQL security + StyleCop + Dependency scan)
  - 3️⃣ Antivirus Scan (VirusTotal - single scan)
  - 4️⃣ Code Signing (Certum with Sign-All.ps1)
  - 5️⃣ Publish Release (signed artifacts only)
  - Each stage blocks next stage on failure (fail fast)
- Enhanced Sign-All.ps1 with `-SkipDefender` parameter for CI mode
  - Avoids duplicate antivirus scans
  - CI uses VirusTotal, local development uses Defender
- Disabled redundant workflows:
  - `sign_artifacts.yml` - Replaced by release.yml stage 4
  - `security-quality.yml` - Replaced by release.yml stage 2 (kept weekly monitoring)

### Added
- Linear dependency chain in release pipeline prevents waste of signing operations on bad code
- Quality gates block expensive operations (signing, publishing) until all checks pass
- Clear stage-by-stage progress visualization with emoji indicators

### Fixed
- Eliminated duplicate antivirus scanning (was running 2-3 times per release)
- Prevented signing of code that fails quality checks
- Reduced VirusTotal API usage by 60-70% (single scan per release instead of multiple)

### Performance
- Push/PR workflow: ~2-3 minutes (down from ~8-10 minutes)
- Release workflow: Same total time, but fails faster on quality issues
- Signing ratio optimization: No wasted signatures on unscanned or low-quality code

## [2.0.0] - 2025-10-25

### Changed - .NET Framework 4.8 Migration
- **BREAKING**: Migrated from .NET Framework 3.5 to .NET Framework 4.8
- Updated `app.config` to target .NET 4.0 runtime (fixes silent crash on startup)
- Modernized C# syntax to leverage .NET 4.8 features:
  - String interpolation (`$"text {variable}"`)
  - Null-conditional operators (`?.`)
  - Pattern matching with `is` expressions
  - Inline `out` variable declarations
  - `nameof()` operator for parameter names
- Updated mutex name from "LunaWorX TopWinPrio" to "MarcusMedinaPro TopWinPrio"
- Removed unnecessary `NativeMethods` class qualifier prefixes
- Removed empty static constructor from `NativeMethods`
- Simplified `Dispose` method with null-conditional operator
- Modernized registry operations with pattern matching

### Added
- Comprehensive global exception handling in `Program.Main`:
  - `Application.ThreadException` handler
  - `AppDomain.UnhandledException` handler
  - User-friendly error MessageBox dialogs
- "Already running" notification when second instance is detected
- SonarCloud Automatic Analysis integration for continuous code quality monitoring
- Quality Gate, Bugs, Code Smells, Security, and Maintainability badges in README
- SONARCLOUD_SETUP.md documentation for SonarCloud configuration
- Private constructor to Program class to prevent instantiation (code quality)
- Comprehensive SonarCloud analysis badges to track code health

### Changed
- Refactored `TimerTopWindowCheck_Tick` method to reduce cognitive complexity from 27 to ~5
  - Extracted `ProcessWindowChange(int newHandle)` method
  - Extracted `ShouldBoostProcess(Process process)` method
  - Extracted `CreateProcessData(Process process)` method
  - Extracted `UpdateProcessPriority(ProcessData, Process)` method
  - Extracted `LogPriorityChange(Process process)` method
- Updated README with SonarCloud integration details
- Improved code maintainability and readability in MainForm.cs

### Fixed
- **CRITICAL**: Fixed silent crash on startup caused by `app.config` targeting .NET 2.0 runtime
- Critical null reference bug in MainForm.cs (L1087) that could cause NullReferenceException
- Uncommented necessary null check for `processData1` to prevent crashes
- Removed commented dead code that was causing code smell warnings

### Security
- Added SonarCloud security analysis to detect vulnerabilities
- Configured security rating monitoring through badges

### Runtime Requirements
- Requires .NET Framework 4.8 (included in Windows 10 1903+ and Windows 11)
- No longer supports Windows XP/Vista (use v1.x for legacy OS support)

## [1.0.0] - 2025-01-18

### Added
- Initial open-source release of TopWinPrio
- MIT License for community contributions
- GitHub Actions CI/CD workflows (build-legacy.yml, quality.yml)
- Multi-artifact release system (release.zip, exe-only.zip, standalone exe)
- Comprehensive README with project documentation
- MIGRATION_ROADMAP.md for planned .NET framework upgrades
- AGENTS.md contributor guidance
- CONTRIBUTING.md and CODE_OF_CONDUCT.md
- SECURITY.md for vulnerability disclosure
- Manual.pdf legacy documentation

### Changed
- Rebranded from LunaWorX to MarcusMedinaPro organization
- Migrated repository to https://github.com/MarcusMedina/TopWinPrio
- Updated all copyright notices and branding references

### Fixed
- Recovered original source code from decompilation after disk crash
- Ensured reproducible builds through GitHub Actions
- Fixed legacy build system for modern CI/CD compatibility

## [1.0.0-beta] - 2008

### Added
- Original TopWinPrio Windows priority manager
- Automatic foreground window priority boosting
- Background process priority management
- System tray integration
- Auto-start configuration
- Per-process priority override settings
- Activity logging and monitoring
- .NET Framework 3.5 WinForms application
- Win32 API interop for process management

---

## Migration Roadmap

Future releases will follow incremental .NET framework migrations:

- **v2.x (Planned)**: .NET Framework 4.8 migration
- **v3.x (Planned)**: .NET 6 migration
- **v4.x (Planned)**: .NET 8 migration
- **v5.x (Future)**: MAUI/WinUI rewrite with background service architecture

Each version will be code-signed with Certum certificate for Windows SmartScreen compatibility.

---

## Quality Standards

Starting with v1.0.0, all releases:
- Pass GitHub Actions build and quality workflows
- Meet SonarCloud Quality Gate requirements
- Include reproducible build artifacts
- Are signed with code-signing certificate (post-Certum approval)
- Follow semantic versioning

---

**Legend**:
- `Added` for new features
- `Changed` for changes in existing functionality
- `Deprecated` for soon-to-be removed features
- `Removed` for now removed features
- `Fixed` for any bug fixes
- `Security` for vulnerability fixes
