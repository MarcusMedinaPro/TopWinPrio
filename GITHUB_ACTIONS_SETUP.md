# GitHub Actions Setup för TopWinPrio

## Översikt
Detta dokument beskriver den nya GitHub Actions pipeline som implementerar den femfasiga planen för build, test, säkerhetskontroll och automatisk release.

## Workflow-filer

### 1. `build-test.yml` - Huvudbyggprocess
**Trigger:** Push till main, tags som börjar med `v*`, pull requests
**Syfte:** Bygga .NET 3.5 appen och köra unit tests

**Viktiga steg:**
- Använder `microsoft/setup-msbuild@v2` för klassisk MSBuild
- Bygger med `msbuild` istället för `dotnet build` (för .NET 3.5 kompatibilitet)
- Kör unit tests på .NET 4.7.2 test-projektet
- Genererar SHA256-checksummor automatiskt
- Förberedd för VirusTotal scanning (Phase 2)
- Sparar build-loggar för StyleCop analys

### 2. `release.yml` - Automatisk release
**Trigger:** Push av tags som börjar med `v*`
**Syfte:** Skapa GitHub release med alla nödvändiga artifacts

**Skapar följande paket:**
- `TopWinPrio-release.zip` - Komplett paket med EXE + Manual.pdf (följer MIGRATION_ROADMAP konvention)
- `TopWinPrio-exe-only.zip` - Bara EXE-filen
- `TopWinPrio.exe` - Ren EXE-fil
- `SHA256SUMS.txt` - Checksummor för alla filer

## Femfasplan Implementation

### ✅ Phase 1 - Baseline build/test (KLAR)
- [x] GitHub-hosted windows-latest runner
- [x] NuGet restore för packages.config
- [x] MSBuild för .NET 3.5 projekt
- [x] dotnet test för .NET 4.7.2 test-projekt
- [x] Artifact upload för Release binaries

### ✅ Phase 2 - Security/reporting (ACTIVE!)
- [x] SHA256SUMS.txt generation
- [x] Build log capture för StyleCop  
- [x] VirusTotal scanning (VIRUSTOTAL_API_KEY configured)
- [x] VirusTotal summary included in release artifacts

### ✅ Phase 3 - Automated release packaging (KLAR)
- [x] Automatisk trigger på v* tags
- [x] Release artifact creation
- [x] GitHub Release med softprops/action-gh-release@v2
- [x] Checksum manifest inkluderad

### 🚀 Phase 4 - Re-enable signing (PLANERAD)
Self-hosted runner workflow för kod-signering:
```yaml
# sign_artifacts.yml (för framtiden)
- Download unsigned artifacts
- Sign med Certum tools på Windows runner
- Re-upload som signed artifacts
```

### 🎯 Phase 5 - Migration-ready pipeline (MÅL)
Full pipeline: build → test → scan → sign → release

## Användning

### För utveckling
```bash
git push origin main  # Triggar build & test
```

### För release
```bash
git tag v1.2.3
git push origin v1.2.3  # Triggar build, test & release
```

### För att aktivera VirusTotal (Phase 2)
1. Skaffa VirusTotal API key
2. Lägg till som GitHub secret: `VIRUSTOTAL_API_KEY`
3. Uncomment VirusTotal steget i build-test.yml

## Troubleshooting

### .NET 3.5 Build Issues
- **Problem:** `MSB3644: The reference assemblies for .NETFramework,Version=v3.5 were not found`
- **Lösning:** Använd MSBuild istället för dotnet build, NuGet package `Microsoft.NETFramework.ReferenceAssemblies.net35` hanterar referenser
- **Fix Applied:** Korrigerat paketnamn från `Microsoft.ReferenceAssemblies.net35` → `Microsoft.NETFramework.ReferenceAssemblies.net35`

### Test Issues
- **Problem:** Tests körs inte
- **Lösning:** Kör `dotnet test` specifikt på test-projektet (.NET 4.7.2) efter MSBuild

### Artifact Issues
- **Problem:** Filer hittas inte
- **Lösning:** Kontrollera att paths matchar MSBuild output (TopWinPrio.CS/bin/Release/)

## Nästa steg
1. Testa den nya workflow genom att pusha till main
2. Aktivera VirusTotal när API key finns tillgänglig
3. Sätta upp self-hosted runner för kod-signering
4. Migrera till nyare .NET versioner enligt MIGRATION_ROADMAP.md