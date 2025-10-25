# 🦠 VirusTotal Verification for TopWinPrio v1.0.1-net35

## Automated Scanning Status
The GitHub Actions workflow attempts to scan all release binaries with VirusTotal automatically. However, if the automated scan fails (401 Unauthorized), manual verification is recommended.

## Manual VirusTotal Verification Steps

### 1. Download Release Files
Download these files from the GitHub Release:
- `TopWinPrio.exe` (main executable)
- `TopWinPrio-release.zip` (complete package)
- `SHA256SUMS.txt` (integrity verification)

### 2. Verify File Integrity
Before scanning, verify the checksums match:
```bash
# Windows PowerShell
Get-FileHash TopWinPrio.exe -Algorithm SHA256
# Compare result with SHA256SUMS.txt
```

### 3. Manual VirusTotal Scan
1. Visit: https://www.virustotal.com/gui/home/upload
2. Upload `TopWinPrio.exe`
3. Wait for scan completion (usually 1-2 minutes)
4. Review the results from multiple antivirus engines

### 4. Expected Results
**✅ Clean Results Expected:**
- 0/70+ detections (or similar ratio)
- No major antivirus engines flagging as malicious
- Possible false positives from heuristic scanners (common for unsigned binaries)

**⚠️ Investigate Further If:**
- Multiple established engines (Windows Defender, Kaspersky, etc.) flag as malicious
- Consistent "trojan" or "malware" classifications
- Significantly different results between builds

## Current Build Security Measures

### Automated Security Pipeline ✅
- **Source Code**: Open source and auditable on GitHub
- **Build Process**: Fully automated on GitHub Actions (windows-latest)
- **Dependencies**: Only Microsoft .NET Framework 3.5 + minimal NuGet packages
- **Code Analysis**: SonarCloud + CodeQL security scanning active
- **Checksums**: SHA256 hashes for integrity verification

### Security Improvements Applied ✅
- Registry operations with proper resource disposal
- P/Invoke security validation and error handling
- Input validation and bounds checking
- Exception handling security improvements
- SonarCloud security hotspots resolved

## False Positive Indicators
Unsigned binaries commonly trigger false positives for:
- **Generic detection names** (e.g., "Gen:Variant.Zusy", "Artemis!...")
- **Heuristic engines** flagging process manipulation (normal for window priority tools)
- **Behavior analysis** detecting registry access (expected for auto-start functionality)

## Reporting Security Issues
If you find legitimate security concerns:
1. **DO NOT** create public GitHub issues for security vulnerabilities
2. Use GitHub Security Advisories: https://github.com/MarcusMedinaPro/TopWinPrio/security/advisories
3. Follow responsible disclosure practices

## Community Verification
Users are encouraged to:
- Perform their own VirusTotal scans
- Share results in GitHub Discussions
- Report any concerning findings through proper channels

## VirusTotal API Key Issues
If you're a contributor experiencing API key issues:
- Organization secrets may not be accessible to forks
- API rate limits may be exceeded during development
- Manual scanning is always available as backup verification

---
**Last Updated**: 2025-10-25  
**Applies To**: TopWinPrio v1.0.1-net35 and later releases