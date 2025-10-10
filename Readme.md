<p align="center">

# 🪟 TopWinPrio

![Open Source](https://badges.frapsoft.com/os/v3/open-source.svg?v=103)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](#)
[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](#)
[![Windows](https://img.shields.io/badge/platform-Windows%20Desktop-blue?style=for-the-badge&logo=windows)](#)

[![Latest release](https://img.shields.io/github/v/release/MarcusMedina/TopWinPrio?include_prereleases&style=for-the-badge&logo=github)](https://github.com/MarcusMedina/TopWinPrio/releases/latest)
[![Total downloads](https://img.shields.io/github/downloads/MarcusMedina/TopWinPrio/total?style=for-the-badge&logo=github)](https://github.com/MarcusMedina/TopWinPrio/releases)
[![Release date](https://img.shields.io/github/release-date/MarcusMedina/TopWinPrio?style=for-the-badge&logo=calendar)](https://github.com/MarcusMedina/TopWinPrio/releases)

[![Legacy Build](https://github.com/MarcusMedina/TopWinPrio/actions/workflows/build-legacy.yml/badge.svg?style=for-the-badge)](https://github.com/MarcusMedina/TopWinPrio/actions/workflows/build-legacy.yml)

[![Stars](https://img.shields.io/github/stars/MarcusMedina/TopWinPrio?style=social)](https://github.com/MarcusMedina/TopWinPrio/stargazers)
[![Issues](https://img.shields.io/github/issues/MarcusMedina/TopWinPrio?style=for-the-badge&logo=github)](https://github.com/MarcusMedina/TopWinPrio/issues)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=for-the-badge)](https://github.com/MarcusMedina/TopWinPrio/pulls)

[![License: GPLv3](https://img.shields.io/github/license/MarcusMedina/TopWinPrio.svg?style=for-the-badge&color=yellow)](https://github.com/MarcusMedina/TopWinPrio/blob/main/LICENSE)
![Made with ❤️](https://img.shields.io/badge/Made%20with-%E2%9D%A4-red?style=for-the-badge)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=MarcusMedina_TopWinPrio&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=MarcusMedina_TopWinPrio)
[![Coverage](https://codecov.io/gh/MarcusMedina/TopWinPrio/branch/main/graph/badge.svg)](https://codecov.io/gh/MarcusMedina/TopWinPrio)
[![Snyk Vulnerabilities](https://img.shields.io/snyk/vulnerabilities/github/MarcusMedina/TopWinPrio?label=Snyk%20Vulnerabilities)](https://snyk.io/test/github/MarcusMedina/TopWinPrio)
[![CodeQL](https://github.com/MarcusMedina/TopWinPrio/actions/workflows/quality.yml/badge.svg)](https://github.com/MarcusMedina/TopWinPrio/actions/workflows/quality.yml)


</p>

> Smart priority manager for Windows processes — lightweight, reliable, and open source.
>
> 📦 Download the latest installer: [**TopWinPrio Releases**](https://github.com/MarcusMedina/TopWinPrio/rele)



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

Current production build targets **.NET Framework 3.5** (Win32).

- Windows XP SP3, Vista, and Windows 7 include 3.5 or install it via Windows Update.
- Windows 8/8.1/10/11 must enable the optional ".NET Framework 3.5 (includes 2.0 and 3.0)" feature or use the offline installer.
- The `TopWinPrio-exe-only.zip` artifact runs without an installer; it touches `HKCU\Software\Microsoft\Windows\CurrentVersion\Run` only when you enable auto-start, so removing the folder leaves no residue.

## Downloads

Releases are created automatically whenever a tag matching `v*` is pushed. Each release currently publishes:

- `TopWinPrio-release.zip` – zipped Release output (EXE, config, resources) for installers or manual deployment.
- `TopWinPrio-exe-only.zip` – zip containing only the WinForms executable for quick copies.
- `TopWinPrio.exe` – standalone executable artifact for rapid verification.

Browse the latest packages on the [Releases page](https://github.com/MarcusMedina/TopWinPrio/releases).

## Quick Start

1. Download `TopWinPrio-release.zip` from the latest release.
2. Extract and run `TopWinPrio.exe`.
3. Right-click the tray icon to configure auto-start, notifications, and priority rules.
4. Optional: review the original manual (`Manual.pdf`) for historical usage notes.

## Build from Source

The legacy project lives in `TopWinPrio.CS/TopWinPrio.csproj`.

```powershell
msbuild TopWinPrio.sln /t:Build /p:Configuration=Release
```

The GitHub Action in `.github/workflows/build-legacy.yml` mirrors this process on a Windows runner, restoring NuGet packages, compiling Debug/Release, and publishing artifacts; when a tag is pushed the workflow also creates the GitHub Release and attaches the packaged assets automatically.

### Local Development Tips

- Use Visual Studio with the `.sln` file for quickest iteration.
- Run `msbuild TopWinPrio.sln /p:RunCodeAnalysis=true` to surface StyleCop warnings.
- Manual validation remains the primary QA path until automated UI tests are introduced.

## Roadmap

| Milestone | Framework | Highlights |
|-----------|-----------|------------|
| Legacy Classic | .NET Framework 3.5 | CI-built binaries, documentation refresh, branding cleanup |
| WinForms Modernization | .NET 4.x → .NET 6 → .NET 8 | Refactoring, analyzers, accessibility, signed artifacts |
| Next-Gen UI | MAUI/WinUI + Windows Service | Background agent, modern configuration UI, improved installer |

Track progress via [project boards](https://github.com/users/MarcusMedina/projects) (coming soon) or discussion threads.

## Contributing

Contributor guidance—including coding style, testing expectations, and CI details—is maintained in [`AGENTS.md`](AGENTS.md). For quick reference:

- Fork the repo, create a feature branch from `main`.
- Run `msbuild` locally and ensure the workflow succeeds.
- Open a PR with screenshots for UI tweaks and describe manual testing.
- Replace any lingering “LunaWorX” branding with MarcusMedinaPro.

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
