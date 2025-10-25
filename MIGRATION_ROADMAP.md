# TopWinPrio - Framework Migration Roadmap

Simple, focused migration plan: One .NET version at a time, release, repeat.

---

## Current Status: 🚧 CI Simplification In Progress

**Blocker**: GitHub-hosted Windows runners can’t reliably provision .NET 3.5 targeting packs or run the full release pipeline
**Action**: Keep releases unsigned and pause VirusTotal/checksum automation until the simplified build/test workflow is stable
**Current Version**: v1.x (.NET Framework 3.5)

---

## Migration Strategy

### One Step at a Time
1. Upgrade .NET version
2. Fix compilation/runtime issues
3. Manual QA testing
4. Build/test in CI (VirusTotal/checksum steps re-enable after stabilization)
5. Push code
6. Create git tag → triggers release
7. Re-enable signing starting with the .NET 8 phase
8. Move to next version

### No Feature Work Until .NET 8
- **Only** framework upgrades
- **Only** fixes needed for compilation
- **No** new features, refactoring, or enhancements
- Feature work starts **after** .NET 8 release

---

## Migration Phases

### Phase 1: ✅ .NET Framework 3.5 (Current - v1.x)
**Status**: Complete – unsigned compatibility release published
**Tag Pattern**: `v1.x-net35`

**Before next migration:**
- [ ] Re-enable VirusTotal + checksum automation once CI is stable
- [ ] Collect feedback on legacy compatibility build

---

### Phase 2: 🔜 .NET Framework 4.8 (v2.x)
**Tag Pattern**: `v2.x-net48`
**Target Date**: After Certum approval

**Tasks (until .NET 8):**
- [ ] Update `TargetFramework` in `.csproj` to `net48`
- [ ] Update `packages.config` dependencies
- [ ] Build and test locally
- [ ] Update CI/CD workflow (if needed)
- [ ] Manual QA: Windows 10/11 testing
- [ ] Tag: `v2.0-net48` → triggers release
- [ ] Update README runtime requirements

**Testing Checklist:**
- Priority management works
- Tray icon functions correctly
- Registry auto-start works
- No crashes or errors

---

### Phase 3: 📋 .NET 6 (v3.x)
**Tag Pattern**: `v3.x-net6`
**Target Date**: After v2.x released

**Tasks:**
- [ ] Convert to SDK-style `.csproj`
- [ ] Update `TargetFramework` to `net6.0-windows`
- [ ] Replace `packages.config` with `PackageReference`
- [ ] Enable nullable reference types (`<Nullable>enable</Nullable>`)
- [ ] Fix namespace declarations (file-scoped if desired)
- [ ] Update test framework to modern xUnit/NUnit
- [ ] Build and test locally
- [ ] Update CI/CD to use .NET 6 SDK
- [ ] Manual QA testing
- [ ] Tag: `v3.0-net6` → triggers release
- [ ] Update README

**Known Changes:**
- SDK-style project format
- Modern C# features available
- Improved build performance

---

### Phase 4: 🎯 .NET 8 (v4.x)
**Tag Pattern**: `v4.x-net8`
**Target Date**: After v3.x released

**Tasks:**
- [ ] Update `TargetFramework` to `net8.0-windows`
- [ ] Update dependencies to .NET 8 compatible versions
- [ ] Test with .NET 8 runtime
- [ ] Fix any breaking changes
- [ ] Update CI/CD to use .NET 8 SDK
- [ ] Manual QA testing
- [ ] Re-enable Certum signing in CI + manual pipeline
- [ ] Tag: `v4.0-net8` → triggers release
- [ ] Update README

**Benefits:**
- Latest runtime
- C# 12 features
- Performance improvements
- Long-term support (LTS)

---

## Post-.NET 8: Feature Work Begins 🚀 (Signing resumes here)

**After v4.x (.NET 8) is released**, we can start:

### Enhancements
- Expand test coverage (unit + integration)
- Add async/await patterns
- Structured logging (ILogger)
- Accessibility improvements
- Code quality tools (SonarCloud, CodeCov)

### Modern Rewrite Planning
- Evaluate MAUI vs WinUI 3
- Design Windows Service architecture
- Prototype service + config UI
- Plan settings migration

---

## Tagging Convention

### Format
`v{major}.{minor}-{framework}`

### Examples
- `v1.0-net35` - .NET Framework 3.5 (current)
- `v2.0-net48` - .NET Framework 4.8
- `v3.0-net6` - .NET 6
- `v4.0-net8` - .NET 8
- `v5.0` - Modern rewrite (future)

### Triggering Releases
Push tag to trigger GitHub Actions release:
```bash
git tag -a v2.0-net48 -m "Release .NET Framework 4.8 version"
git push origin v2.0-net48
```

---

## Code Signing with Certum

**Paused**: Signing is deferred until the .NET 8 migration lands. Until then, releases remain unsigned but are scanned in CI (VirusTotal) before publishing.

### Workflow
1. Build release locally or in CI
2. (Deferred) Sign with Certum certificate – resumes at Phase 4
3. Verify signature: `signtool verify /pa TopWinPrio.exe`
4. Test signed binary
5. Create git tag
6. Push tag → triggers release with signed binary

### CI/CD Integration
- Store Certum certificate securely in GitHub Secrets
- Add signing step to workflow before artifact upload
- Verify signature in workflow

---

## Current Blockers

### Must Complete Before Migration
- [x] .NET 3.5 builds successfully
- [x] CI pipeline builds/tests on GitHub Actions
- [ ] Virus scan + checksum automation restored for unsigned compatibility builds
- [ ] Certum code signing re-enabled for .NET 8+

### Ready to Resume Signing When
- VirusTotal/checksum automation is back online
- Certum certificate can be used non-interactively or via the self-hosted runner
- The `.NET 8` (v4.x) migration is ready to tag

---

## Communication

### README Updates
After each release, update `README.md`:
- Runtime requirements section
- Download links
- Roadmap status
- Supported versions table

### Community
- Tag releases with changelog
- Announce on GitHub Discussions
- Update issues/milestones as completed

---

## Quick Reference

**Current Version**: v1.x-net35 (.NET Framework 3.5)
**Next Version**: v2.x-net48 (.NET Framework 4.8)
**Blocker**: Certum code signing approval
**Strategy**: One framework at a time, sign, release, repeat
**Feature Freeze**: Until .NET 8 (v4.x) released

---

**Last Updated**: 2025-01-18
**Status**: Waiting for Certum
