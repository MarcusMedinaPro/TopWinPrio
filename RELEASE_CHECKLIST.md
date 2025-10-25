# Release Checklist för TopWinPrio v1.0-net35

## Förberedelser

### 1. Ta bort befintlig 1.0.1-net35 release (om den finns)
```bash
# Via GitHub CLI
gh release delete v1.0.1-net35 --yes

# Via GitHub web interface
# Gå till: https://github.com/MarcusMedina/TopWinPrio/releases
# Ta bort v1.0.1-net35 release och dess tag
```

### 2. Testa GitHub Actions
```bash
# Pusha fixes och testa build
git push origin main

# Vänta på att workflow "🧪 Build & Test" går igenom
# Kontrollera: https://github.com/MarcusMedina/TopWinPrio/actions
```

### 3. Verifiera artifacts
När build-workflow är klar, kontrollera att följande artifacts skapas:
- [ ] release-bin/TopWinPrio.exe
- [ ] release-bin/SHA256SUMS.txt
- [ ] build-logs/build-analysis.log
- [ ] test-results/*.trx

## Skapa v1.0-net35 Release

### 4. Tagga och pusha för release
```bash
# Skapa annotated tag enligt MIGRATION_ROADMAP konvention
git tag -a v1.0-net35 -m "Release v1.0-net35: .NET Framework 3.5 compatibility build

- Fixed GitHub Actions pipeline for .NET 3.5 builds
- Automated SHA256 checksum generation  
- Unsigned release (signing resumes at .NET 8 phase)
- Manual.pdf included in full package

Artifacts:
- TopWinPrio-release.zip (EXE + Manual)
- TopWinPrio-exe-only.zip  
- TopWinPrio.exe (standalone)
- SHA256SUMS.txt (checksums)"

# Pusha taggen för att trigga release workflow
git push origin v1.0-net35
```

### 5. Verifiera release
Kontrollera att följande filer skapas i GitHub Release:
- [ ] TopWinPrio-release.zip
- [ ] TopWinPrio-exe-only.zip  
- [ ] TopWinPrio.exe
- [ ] SHA256SUMS.txt

### 6. Testa release artifacts
```bash
# Ladda ner och testa
curl -L -o TopWinPrio.exe https://github.com/MarcusMedina/TopWinPrio/releases/download/v1.0-net35/TopWinPrio.exe

# Verifiera checksum
curl -L https://github.com/MarcusMedina/TopWinPrio/releases/download/v1.0-net35/SHA256SUMS.txt
```

## Post-Release

### 7. Uppdatera README.md
- [ ] Runtime requirements (.NET Framework 3.5)
- [ ] Download links till v1.0-net35
- [ ] Migration roadmap status

### 8. Förbered nästa fas
- [ ] Markera Phase 1 som Complete i MIGRATION_ROADMAP.md
- [ ] Börja planera Phase 2 (.NET Framework 4.8)

## Troubleshooting

### Om build failar:
1. Kontrollera att `Microsoft.NETFramework.ReferenceAssemblies.net35` paketet installeras korrekt
2. Verifiera MSBuild vs dotnet build används rätt
3. Kolla GitHub Actions logs för specifika fel

### Om release failar:
1. Kontrollera att release workflow har `contents: write` permissions
2. Verifiera att alla artifacts från build workflow är tillgängliga
3. Kontrollera att Manual.pdf finns i repo root

### Om checksums är fel:
1. Verifiera att PowerShell Get-FileHash kör korrekt
2. Kontrollera att alla filer finns innan checksum-generering