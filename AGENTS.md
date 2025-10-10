# Repository Guidelines

## Project Structure & Module Organization
The Windows Forms code lives in `TopWinPrio.CS/TopWinPrio` with `MainForm.cs` driving the UI and `NativeMethods.cs` wrapping Win32 calls. Shared helpers belong in `TopWinPrio.CS/Util`, while resources, designers, and settings sit under `TopWinPrio.CS/TopWinPrio.Properties`. The Win32 icon (`App.ico`), configuration (`app.config`), StyleCop settings, and analyzer ruleset remain alongside the project file. Build output goes to `TopWinPrio.CS/bin/<Configuration>/`—clean up artifacts there when preparing releases.

## Build, Test, and Development Commands
Use `msbuild TopWinPrio.sln /t:Build /p:Configuration=Debug` for local debugging; swap `Release` when packaging a drop. Run `msbuild TopWinPrio.sln /p:RunCodeAnalysis=true` before submitting to surface StyleCop and ruleset warnings. GitHub Actions runs the legacy pipeline defined in `.github/workflows/build-legacy.yml`, restoring NuGet packages, building Debug and Release, and publishing zipped Release artifacts. When iterating in Visual Studio, load `TopWinPrio.sln`, select the desired configuration, and press F5 to launch the app. No automated tests exist yet, so manual validation completes the pipeline.

## Coding Style & Naming Conventions
Code targets .NET Framework 3.5 and follows the StyleCop analyzers included via `packages.config`. Keep four-space indentation, place `using` directives inside the namespace, and prefer explicit access modifiers. Classes, forms, and public members use PascalCase; locals and fields use camelCase; constants remain SCREAMING_CASE. Preserve the file header comment block and project copyright text.

## Testing Guidelines
Exercise new features by running the built `TopWinPrio.exe` and verifying window priority automation scenarios. Confirm registry changes via `RegistryTools` only when required, and restore the original Run key values afterwards. Document any new manual test cases in the pull request. If you introduce automated tests (e.g., WinForms UI automation), colocate them under a new `Tests` directory and wire the invocation into the build notes above.

## Branding Updates
Remove historical references to “LunaWorX” when you touch a file; prefer `MarcusMedinaPro` and the `marcusmedina.pro` domain in mutex names, UI strings, and documentation. Update suppressions or resource strings accordingly so the branding stays consistent.

## Commit & Pull Request Guidelines
Recent commits favor short, descriptive subjects such as "Update Readme.md"; follow that style with an imperative mood summary under 60 characters, and add body text for rationale when needed. Reference work items using `#123` or an external link when applicable. Pull requests should describe the user-facing change, outline manual validation, and include screenshots for UI tweaks. Target the `main` branch for fixes and enhancements so CI picks up the build automatically. Mention registry or system prerequisites explicitly so reviewers can reproduce results.
