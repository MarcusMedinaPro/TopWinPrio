# TopWinPrio

TopWinPrio monitors running processes and dynamically adjusts their priorities so the foreground application keeps its share of CPU time. The original Windows Forms code base dates back to 2008 and targets .NET Framework 3.5; this repository now preserves that legacy release and documents the roadmap toward modern Windows 11 support.

## Project Status

- **Legacy refresh (complete):** The historical v1.0 sources build on GitHub Actions and publish signed artifacts straight from CI. No functional changes were introduced, only pipeline automation.
- **Framework upgrades (planned):** We will migrate the WinForms application through supported .NET targets—stopping at .NET 4.x, .NET 6, and finally .NET 8—releasing binaries for every milestone so users can pick the runtime that fits their environment.
- **Modern rewrite (planned):** After the .NET 8 WinForms stabilisation, the app will be redesigned with a contemporary Windows 11 experience (MAUI/WinUI candidate) and a background service paired with a configuration UI.

Follow progress and discussion in repository issues and pull requests. Branding has moved from LunaWorX to MarcusMedinaPro; any remaining references will be updated as files are touched.

## Runtime Requirements

Current production build targets **.NET Framework 3.5** (Win32).

- Windows XP SP3, Vista, and Windows 7 include 3.5 or install it via Windows Update.
- Windows 8/8.1/10/11 must enable the optional ".NET Framework 3.5 (includes 2.0 and 3.0)" feature or use the offline installer.
- The `TopWinPrio-exe-only.zip` artifact runs without an installer; it touches `HKCU\Software\Microsoft\Windows\CurrentVersion\Run` only when you enable auto-start, so removing the folder leaves no residue.

## Downloads

Releases are created automatically whenever a tag matching `v*` is pushed. Each release currently publishes:

- `TopWinPrio-release.zip` – zipped Release output (EXE, config, resources) for installers or manual deployment.
- `TopWinPrio-exe-only.zip` – zip that contains only the WinForms executable for quick copies.
- `TopWinPrio.exe` – standalone executable artifact for rapid verification.

## Building Locally

The legacy project lives in `TopWinPrio.CS/TopWinPrio.csproj`. Build it with:

```bash
msbuild TopWinPrio.sln /t:Build /p:Configuration=Release
```

The GitHub Action in `.github/workflows/build-legacy.yml` mirrors this process on a Windows runner, restoring NuGet packages, compiling Debug/Release, and publishing artifacts; when a tag is pushed the workflow also creates the GitHub Release and attaches the packaged assets automatically.

## Contributing

Contributor guidance—including coding style, testing expectations, and CI details—is maintained in [`AGENTS.md`](AGENTS.md). Target the `main` branch for fixes and feature work. If you plan to adjust branding or prepare the framework upgrades, coordinate via issues so releases align with the roadmap above.

## License

TopWinPrio is licensed under the [GNU General Public License v3](LICENSE.txt). Commercial use is permitted within the GPL terms.

## Credits & History

I (Marcus Ackre Medina) originally released TopWinPrio while studying C#. The source was later recovered through decompilation after a disk failure and open-sourced so the community can keep it alive. Thank you to everyone who has shared tutorials, videos, and feedback over the years—the enthusiasm for a small utility is what keeps the project moving forward.
