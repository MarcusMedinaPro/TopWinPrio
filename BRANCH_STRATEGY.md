# 🌿 Branch Strategy for TopWinPrio

## Main Branches

### `main` - Current Development Branch
- **Always buildable and deployable**
- **Latest stable version of current .NET version**
- **Automatic CI/CD pipeline active**
- **Protected branch** (requires PR for changes after .NET 8)

### `.NET Version Branches` - Preserved Versions

#### `net3.5` - .NET Framework 3.5 (ORIGINAL)
- **Status**: ✅ **COMPLETE & SECURITY-HARDENED**
- **Version**: v1.0.1-net35  
- **Release**: 2025-10-25
- **Security**: Enterprise-grade (SonarCloud hotspots resolved)
- **CI/CD**: Full pipeline with VirusTotal
- **Description**: The original security-hardened version

```bash
# Create and preserve .NET 3.5 branch
git checkout main
git branch net3.5
git push origin net3.5

# Tag as stable baseline
git tag -a baseline-net3.5 -m "✅ Baseline: Security-hardened .NET 3.5 version
- Enterprise-grade security implemented
- SonarCloud hotspots resolved  
- Registry + P/Invoke security hardening
- Complete CI/CD pipeline
- VirusTotal integration
- SHA256 checksums
- Automatic release process"
git push origin baseline-net3.5
```

#### `net4.8` - .NET Framework 4.8 (UPCOMING)
- **Status**: 🚧 **PLANNED**
- **Version**: v2.0.0-net48 (coming)
- **Migration from**: net3.5
- **Goal**: Preserve all security hardening + .NET 4.8 features

#### `net6.0` - .NET 6.0 (UPCOMING) 
- **Status**: 📋 **PLANNED**
- **Version**: v3.0.0-net6 (coming)
- **Migration from**: net4.8

#### `net8.0` - .NET 8.0 (TARGET)
- **Status**: 🎯 **END GOAL**  
- **Version**: v4.0.0-net8 (coming)
- **Migration from**: net6.0
- **Signing**: Code signing reactivated here

## Migration Workflow

### Fas 1: Bevara Nuvarande (✅ KLAR)
```bash
# 1. Skapa .NET 3.5 branch för bevarande
git branch net3.5
git push origin net3.5

# 2. Tagga som stabil baseline  
git tag baseline-net3.5
git push origin baseline-net3.5
```

### Fas 2: .NET 4.8 Migration (🚧 NÄSTA)
```bash  
# 1. Starta från main (som innehåller .NET 3.5 koden)
git checkout main

# 2. Uppdatera target framework
# Ändra .csproj från v3.5 till v4.8

# 3. Fixa compilation issues
# Hantera breaking changes

# 4. Testa och validera
# Manual QA + automatiserad testning

# 5. Commit och release
git add .
git commit -m "🚀 Migrate to .NET Framework 4.8"
git tag v2.0.0-net48
git push origin main
git push origin v2.0.0-net48

# 6. Skapa bevarande-branch
git branch net4.8  
git push origin net4.8
```

### Fas 3-N: Fortsätt Migration
Upprepa samma process för varje .NET version.

## Branch Protection Rules

### Efter .NET 8 Migration:
- **`main`**: Kräv PR + reviews för alla ändringar
- **Version branches**: Skrivskyddade (endast för historik)
- **Development**: Feature branches → PR → main

## Tagging Strategi

### Version Tags:
- `v1.0.1-net35` - .NET Framework 3.5 release
- `v2.0.0-net48` - .NET Framework 4.8 release  
- `v3.0.0-net6` - .NET 6.0 release
- `v4.0.0-net8` - .NET 8.0 release

### Baseline Tags:
- `baseline-net3.5` - Säker startpunkt för .NET 3.5
- `baseline-net48` - Säker startpunkt för .NET 4.8
- `baseline-net6` - Säker startpunkt för .NET 6.0
- `baseline-net8` - Final modern version

## CI/CD Per Branch

### `net3.5` Branch:
- ✅ Build .NET Framework 3.5
- ✅ VirusTotal scanning  
- ✅ SHA256 checksums
- ✅ Release automation
- ❌ Kod-signering (ej tillgänglig än)

### `main` Branch (current development):
- ✅ Build senaste .NET version
- ✅ Alla säkerhetscheckar
- ✅ Release automation
- 🎯 Kod-signering (från .NET 8)

### Version Branches:
- 📚 **Endast för historik och referens**
- ❌ Ingen aktiv CI/CD
- ✅ Bevarade för nedladdning och jämförelse

## Fördelar med Denna Strategi

### ✅ **Säkerhet**:
- Ursprunglig säkerhetshärdad kod bevaras
- Varje version kan rullas tillbaka
- Ingen risk att förlora working code

### ✅ **Utveckling**:  
- Tydlig migration path
- En .NET version i taget
- Lätt att jämföra versioner

### ✅ **Användare**:
- Kan välja .NET version som passar deras miljö
- Äldre versioner finns kvar tillgängliga
- Tydlig upgrade path

### ✅ **Underhåll**:
- Kritiska säkerhetspatches kan appliceras per branch
- Ingen confusion om vilken kod som är "current"
- Git history bevaras perfekt

---

## 🚀 Nästa Steg

1. **Bevara .NET 3.5**: `git branch net3.5 && git push origin net3.5`
2. **Tagga baseline**: `git tag baseline-net3.5 && git push origin baseline-net3.5`  
3. **Starta .NET 4.8**: Uppdatera .csproj på main branch
4. **Migrera steg för steg** enligt MIGRATION_ROADMAP.md

**Nu har vi en solid grund för säker migration! 🏗️✨**