# SonarCloud Setup Guide

**✅ USING AUTOMATIC ANALYSIS** - No CI workflow needed!

SonarCloud automatically scans code when pushed to main branch.

---

## Prerequisites

- GitHub repository: `MarcusMedina/TopWinPrio` (done ✅)
- SonarCloud account (free for open source)

---

## Quick Setup

### 1. Create SonarCloud Account

1. Go to https://sonarcloud.io/
2. Click **"Log in"**
3. Choose **"Sign up with GitHub"**
4. Authorize SonarCloud to access your GitHub account

### 2. Import TopWinPrio Project

1. In SonarCloud, click **"+"** (top right) → **"Analyze new project"**
2. Select **"MarcusMedinaPro"** organization
3. Find and select **"TopWinPrio"**
4. Click **"Set Up"**

### 3. Configure Automatic Analysis

**Choose analysis method:**
- Select **"Automatic Analysis"** ✅ (simplest option)
- No workflows, tokens, or configuration needed!

**Project Information:**
- Project Key: `MarcusMedinaPro_TopWinPrio`
- Organization: `marcusmedinapro`

**That's it!** Analysis happens automatically when you push to main 🎉

---

## What Happens Automatically

When you push to `main` branch:
1. SonarCloud detects the push
2. Automatically analyzes C# code
3. Updates quality metrics
4. Badges in README update

**No workflow files needed!**

---

## Verify Analysis

1. Push any commit to main branch
2. Wait ~2-3 minutes for analysis
3. Check dashboard: https://sonarcloud.io/project/overview?id=MarcusMedinaPro_TopWinPrio
4. Verify README badges show data

---

## Troubleshooting

### Badges show "unknown"
- Wait for first successful analysis
- Hard refresh browser (Ctrl+F5)
- Verify project key matches: `MarcusMedinaPro_TopWinPrio`

### No analysis running
- Ensure "Automatic Analysis" is enabled in SonarCloud project settings
- Check that code was pushed to `main` branch
- Verify organization: `marcusmedinapro`

---

## Configuration (Optional)

### Custom Exclusions

Create `sonar-project.properties` in repo root:

```properties
# Project identification
sonar.projectKey=MarcusMedinaPro_TopWinPrio
sonar.organization=marcusmedinapro

# Exclude patterns (optional)
sonar.exclusions=**/bin/**,**/obj/**,**/packages/**,**/TestResults/**
```

---

## Future: CI-Based Analysis

After .NET 8 migration, we may switch to CI-based analysis for more control.

**To enable CI analysis:**
1. Disable "Automatic Analysis" in SonarCloud
2. Rename `.github/workflows/sonarcloud.yml.disabled` → `sonarcloud.yml`
3. Add `SONAR_TOKEN` secret to GitHub repository
4. Workflow will run on every push

**Why wait?**
- .NET Framework 3.5 works better with Automatic Analysis
- .NET 8 SDK-style projects work better with CI analysis
- Keep it simple until the migration is complete

---

## Quality Metrics

SonarCloud tracks:
- **Quality Gate**: Pass/Fail overall status
- **Bugs**: Potential runtime errors
- **Vulnerabilities**: Security issues
- **Code Smells**: Maintainability issues
- **Security Hotspots**: Code requiring security review
- **Coverage**: Test coverage % (when tests added)
- **Duplications**: Duplicate code blocks

---

## Resources

- **SonarCloud Dashboard**: https://sonarcloud.io/organizations/marcusmedinapro/projects
- **Project Overview**: https://sonarcloud.io/project/overview?id=MarcusMedinaPro_TopWinPrio
- **SonarCloud Docs**: https://docs.sonarcloud.io/
- **Automatic Analysis**: https://docs.sonarcloud.io/advanced-setup/automatic-analysis/

---

**Setup Date**: 2025-01-18
**Method**: Automatic Analysis
**Status**: ✅ Active (no tokens needed)
