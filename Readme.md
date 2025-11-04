<p align="center">

# 🪟 TopWinPrio

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](https://github.com/MarcusMedina/TopWinPrio/blob/main/LICENSE.txt)
![Open Source](https://badges.frapsoft.com/os/v3/open-source.svg?v=103)
![Made with ❤️](https://img.shields.io/badge/Made%20with-%E2%9D%A4-red?style=for-the-badge)


[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](#)
[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](#)
[![Windows](https://img.shields.io/badge/platform-Windows%20Desktop-blue?style=for-the-badge&logo=windows)](#)

[![Latest release](https://img.shields.io/github/v/release/MarcusMedina/TopWinPrio?include_prereleases&style=for-the-badge&logo=github)](https://github.com/MarcusMedina/TopWinPrio/releases/latest)
[![Total downloads](https://img.shields.io/github/downloads/MarcusMedina/TopWinPrio/total?style=for-the-badge&logo=github)](https://github.com/MarcusMedina/TopWinPrio/releases)
[![Release date](https://img.shields.io/github/release-date/MarcusMedina/TopWinPrio?style=for-the-badge&logo=calendar)](https://github.com/MarcusMedina/TopWinPrio/releases)

[![Build & Test](https://github.com/MarcusMedina/TopWinPrio/actions/workflows/build-test.yml/badge.svg)](https://github.com/MarcusMedina/TopWinPrio/actions/workflows/build-test.yml)
[![Release Pipeline](https://github.com/MarcusMedina/TopWinPrio/actions/workflows/release.yml/badge.svg)](https://github.com/MarcusMedina/TopWinPrio/actions/workflows/release.yml)
[![SonarCloud](https://sonarcloud.io/images/project_badges/sonarcloud-highlight.svg)](https://sonarcloud.io/summary/new_code?id=MarcusMedinaPro_TopWinPrio)

[![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=MarcusMedinaPro_TopWinPrio&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=MarcusMedinaPro_TopWinPrio)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=MarcusMedinaPro_TopWinPrio&metric=bugs)](https://sonarcloud.io/summary/new_code?id=MarcusMedinaPro_TopWinPrio)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=MarcusMedinaPro_TopWinPrio&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=MarcusMedinaPro_TopWinPrio)
[![Security](https://sonarcloud.io/api/project_badges/measure?project=MarcusMedinaPro_TopWinPrio&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=MarcusMedinaPro_TopWinPrio)
[![Maintainability](https://sonarcloud.io/api/project_badges/measure?project=MarcusMedinaPro_TopWinPrio&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=MarcusMedinaPro_TopWinPrio)



</p>

> Smart priority manager for Windows processes — lightweight, reliable, and open source.
>
> 📦 Download the latest installer: [**TopWinPrio Releases**](https://github.com/MarcusMedina/TopWinPrio/releases/latest)
>
> ✅ All releases are **code-signed**, built on GitHub Actions, and scanned via VirusTotal before publishing.



Windows Foreground Priority Manager for gamers and multitaskers. TopWinPrio keeps your active window responsive by nudging CPU priorities on the fly—revived as a community-driven, MIT-licensed project.

## Open Source Status

TopWinPrio is 100% open source under the [MIT License](LICENSE.txt). Source code, build scripts, issue history, and release binaries live in this public repository. Every `v*` tag is built in GitHub Actions with artifacts published to the Releases page so anyone can verify or fork the project.

## Table of Contents

- [Project Status](#project-status)
- [Features](#features)
- [Runtime Requirements](#runtime-requirements)
- [Downloads](#downloads)
- [Quick Start](#quick-start)
- [Build from Source](#build-from-source)
- [Roadmap](#roadmap)
- [Contributing](#contributing)
- [Security](#security)
- [License](#license)
- [Credits & History](#credits--history)
- [Resources](#resources)

## Project Status

- **Legacy refresh (complete):** The historical v1.0 sources build on GitHub Actions and publish artifacts directly from CI. No functionality changes were introduced.
- **Framework upgrades (in progress):** The WinForms app will step through supported .NET targets—.NET 4.x → .NET 6 → .NET 8—shipping binaries at every milestone so users can pick their runtime.
- **Modern rewrite (planned):** After the .NET 8 WinForms stabilization, the app will evolve into a Windows 11-ready experience (MAUI/WinUI candidate) with a background service plus configuration UI.

Follow upgrades or pitch ideas in [issues](https://github.com/MarcusMedina/TopWinPrio/issues) and [pull requests](https://github.com/MarcusMedina/TopWinPrio/pulls). Branding has moved from LunaWorX to MarcusMedinaPro; lingering references are cleaned up as files are touched.

## Features

- ⚙️ **Foreground priority tuning** – Automatically raises the active window’s priority while lowering background apps.
- 🎮 **Game-friendly defaults** – Minimal UI, tray resident, and safe registry hooks for auto-start.
- 🧰 **Win32 interop** – Managed wrapper around key Windows APIs (`SetPriorityClass`, `SetForegroundWindow`).
- 🛠️ **Configurable** – Toggle auto-start, tray notifications, and per-process overrides via the UI.
- 📦 **CI-packaged binaries** – Reproducible builds with zipped artifacts ready for distribution.

## Runtime Requirements

Current production build targets **.NET 8 LTS** (modern cross-platform .NET).

- **Windows 10 (1607+)** or **Windows 11** required
- **[.NET 8 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/8.0)** must be installed (free download from Microsoft)
- Long-term support until **November 2026** with security updates
- The `TopWinPrio-exe-only.zip` artifact runs without an installer; it touches `HKCU\Software\Microsoft\Windows\CurrentVersion\Run` only when you enable auto-start, so removing the folder leaves no residue.

**Legacy versions:**
- **v2.x**: .NET Framework 4.8 (for Windows 7/8)
- **v1.x**: .NET Framework 3.5 (for Windows XP/Vista)

## Downloads

Releases are **fully automated** via GitHub Actions with a comprehensive 5-stage pipeline:

1. ✅ Build & Test
2. ✅ Quality Gate (CodeQL security analysis)
3. ✅ Antivirus Scan (VirusTotal)
4. ✅ Code Signing (Certum certificate)
5. ✅ Publish Release

Each release includes:
- `TopWinPrio-release.zip` - Complete package with manual
- `TopWinPrio-exe-only.zip` - Just the signed executable
- `TopWinPrio.exe` - Standalone signed binary
- `SHA256SUMS.txt` - Checksum verification
- `VirusTotal-Summary.txt` - Antivirus scan results

Download from the [Releases page](https://github.com/MarcusMedina/TopWinPrio/releases) or build from source.

## Quick Start

1. Download `TopWinPrio-release.zip` from the latest release.
2. Extract and run `TopWinPrio.exe`.
3. Right-click the tray icon to configure auto-start, notifications, and priority rules.
4. Optional: review the original manual (`Manual.pdf`) for historical usage notes.

## Build from Source

The modern .NET 8 project uses SDK-style projects in `TopWinPrio.CS/`.

**Prerequisites:**
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 (or VS Code with C# extension)

**Build commands:**
```bash
# Restore dependencies
dotnet restore TopWinPrio.sln

# Build
dotnet build TopWinPrio.sln --configuration Release

# Run tests
dotnet test TopWinPrio.Tests/TopWinPrio.Tests.csproj --configuration Release

# Pack (creates deployment package)
dotnet pack TopWinPrio.sln --configuration Release
```

### Local Development Tips

- Use **Visual Studio 2022** with the `.sln` file for best experience
- Code analysis runs automatically during build (no StyleCop needed - using `.editorconfig`)
- Nullable reference types are **enabled** - the compiler will warn about potential null issues
- All GitHub Actions workflows are documented in `.github/workflows/`

## Roadmap

**Current Status**: ✅ .NET 8 LTS migration complete with full CI/CD automation, code signing, and security scanning.

**Migration Completed:**

| Phase | Framework | Status | Release Tag |
|-------|-----------|--------|-------------|
| 1️⃣ Legacy | .NET Framework 3.5 | ✅ Released | `v1.x` |
| 2️⃣ Modernization | .NET Framework 4.8 | ✅ Released | `v2.x` |
| 3️⃣ Modern .NET | .NET 8 LTS | ✅ **Current** | `v3.0.0` |

**Future Roadmap:**

| Phase | Description | Status | Target |
|-------|-------------|--------|--------|
| 4️⃣ Feature enhancements | Performance optimization, new features | 📋 Planned | `v3.x` |
| 5️⃣ Next-gen UI | MAUI/WinUI + background service | 🔮 Exploring | `v4.x` |

**Focus for v3.x:**
- Performance optimizations
- Enhanced UI/UX
- Additional process management features
- Improved system tray integration

## Verify Downloads

All releases include comprehensive verification:

- **Code Signing:** All executables are signed with a **Certum code-signing certificate**
  - Verify signature: Right-click EXE → Properties → Digital Signatures
  - Certificate issuer: Certum
  - Signer: MarcusMedina / Marcus Medina

- **Checksums:** Every release includes `SHA256SUMS.txt`
  ```powershell
  # Windows
  Get-FileHash .\TopWinPrio.exe -Algorithm SHA256

  # Linux/macOS
  shasum -a 256 TopWinPrio.exe
  ```

- **VirusTotal:** Scan results included in `VirusTotal-Summary.txt`
  - Automatically scanned before release
  - Results published with each release
  - Or verify manually at [VirusTotal](https://www.virustotal.com/)

## Contributing

We welcome contributions! Here's how to get started:

**Development Workflow:**
- See [GITFLOW.md](GITFLOW.md) for our branch strategy (`develop` → `main`)
- Fork the repo, create a feature branch from `develop`
- Run `dotnet build` and `dotnet test` locally
- Open a PR with clear description and screenshots for UI changes
- Ensure all GitHub Actions checks pass

**Code Standards:**
- C# 12 with nullable reference types enabled
- Follow `.editorconfig` conventions (no StyleCop needed)
- File-scoped namespaces throughout
- Comprehensive XML documentation comments
- Unit tests for new features

**Quick start:**
```bash
git checkout develop
git checkout -b feature/your-feature
# Make changes...
dotnet build TopWinPrio.sln
dotnet test TopWinPrio.Tests/TopWinPrio.Tests.csproj
git commit -m "feat: your feature"
git push origin feature/your-feature
```

See also: [CONTRIBUTING.md](CONTRIBUTING.md) and the [Code of Conduct](CODE_OF_CONDUCT.md).

## Security

Please review [SECURITY.md](SECURITY.md) for responsible disclosure guidelines. In short, email security concerns to `security@marcusmedina.pro` (PGP details coming soon) rather than opening public issues.

## License

TopWinPrio is released under the [MIT License](LICENSE.txt). Use it in open or closed-source projects, modify it, and redistribute it—just keep the copyright notice intact.

## Credits & History

- **Author:** Marcus Ackre Medina ([marcusmedina.pro](https://marcusmedina.pro/))
- **Origins:** Written in 2008, recovered via decompilation after a disk crash, and open-sourced so the community can keep it alive.
- **Community:** Thanks to everyone who shared tutorials, videos, and feedback—your enthusiasm keeps this utility moving forward.

## Resources

- [Legacy Manual (PDF)](Manual.pdf)
- [Issues](https://github.com/MarcusMedina/TopWinPrio/issues)
- [Pull Requests](https://github.com/MarcusMedina/TopWinPrio/pulls)
- [Discussions](https://github.com/MarcusMedina/TopWinPrio/discussions) *(start one!)*
- [MarcusMedina Blog](https://marcusmedina.pro/)

---

> ❤️ Enjoying TopWinPrio? Star the repo, spread the word, or chip in via the funding links once they go live.
