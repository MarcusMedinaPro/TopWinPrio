# CI/CD Strategy - Branch-Based Pipeline

## Overview

Three-tier progressive CI/CD strategy optimizing for speed in development and thorough validation before release.

## Branch Strategy

### 1. `develop` Branch - Fast Feedback
**Goal**: Quick validation for active development

**Workflow**: `develop.yml`
- ✅ Unit tests only
- ⏱️ Fast execution (~2-3 min)
- 🎯 Immediate feedback on code changes

**When it runs**: Push/PR to `develop`

### 2. `test` Branch - Quality Gate
**Goal**: Comprehensive quality validation before release prep

**Workflow**: `test.yml`
- ✅ Unit tests
- 🔍 CodeQL security analysis
- 📊 Code quality analysis
- 🔒 Dependency vulnerability scan
- ⏱️ Medium execution (~8-12 min)
- 🎯 Thorough validation before merging to release

**When it runs**: Push/PR to `test`

### 3. `release`/`main` Branch - Full Pipeline
**Goal**: Production-ready release with signing and security validation

**Workflow**: `release.yml`
- ✅ Unit tests
- 🔍 Code quality (CodeQL, analysis, dependencies)
- 🔐 **Code signing** (self-hosted runner required)
- 🦠 **VirusTotal antivirus scan** (on signed files)
- 📦 **Package creation** (signed artifacts)
- 🚀 **GitHub Release** (tags only)
- ⏱️ Full execution (~15-25 min)
- 🎯 Production deployment

**When it runs**:
- Push/PR to `release`/`main` (no publish)
- Tags `v*` (full pipeline with publish)

## Key Design Decisions

### 1. Sign Before Scan
```
Build → Test → Quality → SIGN → Scan → Package → Publish
```

**Why**: VirusTotal and users should scan the actual signed binary that will be distributed.

### 2. VirusTotal 409 Handling
```yaml
continue-on-error: true  # Don't fail on duplicate scans
```

**Why**: Re-releases trigger 409 errors (file already scanned). This is normal and shouldn't block pipeline.

### 3. Progressive Validation
- **develop**: Fast iteration (tests only)
- **test**: Quality assurance (tests + quality)
- **release**: Full security (tests + quality + sign + scan + publish)

**Why**: Developers get fast feedback. Release process ensures security and quality.

### 4. Self-Hosted Signing
```yaml
runs-on: [self-hosted, windows, code-sign]
```

**Why**: Code signing requires local certificate access. Self-hosted runner has signing infrastructure.

## Support Workflows

### `dependency-review.yml` - Weekly Monitoring
- Manual trigger or weekly cron
- Submits dependency graph to GitHub
- Background security monitoring

### `security-quality.yml` - Disabled
- Manual trigger only
- Legacy comprehensive security scan
- Use for ad-hoc security audits

## Workflow Files

### Active Workflows
- `develop.yml` - Develop branch (tests only)
- `test.yml` - Test branch (tests + quality)
- `release.yml` - Release/main + tags (full pipeline)
- `dependency-review.yml` - Weekly dependency monitoring

### Disabled Workflows
- `develop-quality.yml.disabled` - Replaced by `develop.yml`
- `build-test.yml.disabled` - Replaced by branch-specific workflows
- `security-quality.yml` - Manual only (not automatic)

## Setup Requirements

### GitHub Secrets
```
VIRUSTOTAL_API_KEY  # VirusTotal scanning
```

### Self-Hosted Runner Setup
1. Windows machine with signing certificate installed
2. GitHub runner with labels: `self-hosted`, `windows`, `code-sign`
3. `Sign-All.ps1` script at `C:\Git\Certskit\Sign-All.ps1`

### Branch Protection Rules
```
develop  → Require: develop.yml passing
test     → Require: test.yml passing
release  → Require: release.yml passing
main     → Require: release.yml passing
```

## Usage Examples

### Development Flow
```bash
# Feature development
git checkout develop
git add .
git commit -m "Add feature"
git push origin develop
# ✅ develop.yml runs (tests only, ~2 min)

# Ready for quality review
git checkout test
git merge develop
git push origin test
# ✅ test.yml runs (tests + quality, ~10 min)

# Ready for release
git checkout release
git merge test
git push origin release
# ✅ release.yml runs (full pipeline, ~20 min)

# Create release
git tag v1.0.0
git push origin v1.0.0
# ✅ release.yml runs + publishes GitHub release
```

## Adapting for Other Projects

### For Projects Without Code Signing
Remove signing step from `release.yml`:
```yaml
# Remove or comment out:
# - code-signing job
# - Change antivirus-scan needs from code-signing to quality-gate
# - Scan unsigned binaries instead
```

### For Projects Without VirusTotal
Remove antivirus scan:
```yaml
# Remove or comment out:
# - antivirus-scan job
# - Change publish-release needs from antivirus-scan to code-signing
```

### For Open Source Projects (No Self-Hosted)
Use cloud-based signing services:
```yaml
# Replace code-signing job with:
- uses: azure/code-signing-action@v1  # Example
  # or
- uses: digicert/sign-action@v1  # Example
```

### For Non-Windows Projects
Replace Windows runners with appropriate platform:
```yaml
runs-on: ubuntu-latest  # Linux
runs-on: macos-latest   # macOS
```

## Performance Optimization Tips

1. **Cache Dependencies**: Add caching for NuGet/npm packages
2. **Parallel Jobs**: Run independent checks in parallel
3. **Conditional Steps**: Skip unnecessary steps based on file changes
4. **Artifact Reuse**: Build once, use artifacts in subsequent jobs

## Monitoring and Maintenance

### Weekly Tasks
- Review dependency scan results
- Check security advisory alerts
- Verify self-hosted runner health

### Monthly Tasks
- Review CodeQL findings
- Update GitHub Actions versions
- Audit workflow execution times

### Quarterly Tasks
- Review and update strategy
- Evaluate new security tools
- Optimize pipeline performance

## Troubleshooting

### Sign-All.ps1 Not Found
```powershell
# Verify path on self-hosted runner
Test-Path C:\Git\Certskit\Sign-All.ps1
```

### VirusTotal 409 Errors
Normal for re-releases. Pipeline continues with warning.

### Unsigned Artifacts
Check self-hosted runner:
1. Certificate installed and valid
2. Runner has proper labels
3. Sign-All.ps1 executable permissions

### Test Failures
Check test results artifact in workflow run for detailed logs.

## References

- [GitHub Actions Documentation](https://docs.github.com/actions)
- [CodeQL Documentation](https://codeql.github.com/docs/)
- [VirusTotal API](https://developers.virustotal.com/)
