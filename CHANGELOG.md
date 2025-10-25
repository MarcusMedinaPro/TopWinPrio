# Changelog

All notable changes to TopWinPrio will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

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
