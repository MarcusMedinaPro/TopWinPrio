# TopWinPrio Modernization Roadmap Setup

This document explains the GitHub project structure for the TopWinPrio modernization roadmap.

## Quick Setup

Run the PowerShell script to create all milestones, labels, and issues:

```powershell
cd C:\Git\MarcusMedina\TopWinPrio
.\setup-github-roadmap.ps1
```

## What Gets Created

### 📌 Labels (8)
- **migration** - Framework migration tasks
- **enhancement** - New features and improvements
- **testing** - Test-related tasks
- **release** - Release and tagging tasks
- **code-signing** - Code signing and security
- **documentation** - Documentation improvements
- **quality** - Code quality and analysis
- **ci-cd** - CI/CD pipeline improvements

### 🎯 Milestones (5)

#### 1. .NET 4.x Migration (Due: Feb 2025)
Upgrade from .NET Framework 3.5 to 4.8
- 5 issues covering project updates, quality, CI/CD, testing, and release

#### 2. .NET 6 Migration (Due: Mar 2025)
Upgrade from .NET Framework 4.8 to .NET 6
- 5 issues covering SDK migration, async patterns, CI/CD, and release

#### 3. .NET 8 Migration (Due: Apr 2025)
Upgrade from .NET 6 to .NET 8
- 4 issues covering framework upgrade, modern features, CI/CD, and release

#### 4. Post-Migration Enhancements (Due: Jun 2025)
Code modernization, testing, and signing
- 7 issues covering:
  - Unit test expansion
  - Integration tests
  - Code signing (Certum)
  - Accessibility
  - Structured logging
  - SonarCloud setup
  - CodeCov setup

#### 5. Modern Rewrite Planning (Due: Dec 2025)
MAUI/WinUI evaluation and architecture
- 5 issues covering:
  - Technology evaluation
  - Service architecture design
  - Prototyping
  - Migration planning
  - Roadmap creation

## Total: ~25 Issues

Each issue is tagged with appropriate labels and assigned to its milestone.

## Manual Steps Required

### Create Project Board
1. Go to https://github.com/MarcusMedina/TopWinPrio/projects
2. Click **"New project"**
3. Choose **"Board"** template
4. Name: **"TopWinPrio Modernization Roadmap"**
5. Add columns:
   - 📋 Backlog
   - 🔄 In Progress
   - 👀 In Review
   - ✅ Done
6. Link issues to the board
7. Organize by milestone

### Configure Issue Templates
Create `.github/ISSUE_TEMPLATE/` files for:
- Bug reports
- Feature requests
- Migration tasks

## Viewing the Roadmap

### Issues
```bash
# List all issues
gh issue list --limit 50

# Filter by milestone
gh issue list --milestone ".NET 4.x Migration"

# Filter by label
gh issue list --label "migration"
```

### Milestones
```bash
# List milestones
gh milestone list

# View specific milestone
gh issue list --milestone ".NET 4.x Migration"
```

### Web Interface
- **Issues**: https://github.com/MarcusMedina/TopWinPrio/issues
- **Milestones**: https://github.com/MarcusMedina/TopWinPrio/milestones
- **Projects**: https://github.com/MarcusMedina/TopWinPrio/projects

## Workflow

### Starting a New Phase
1. Review milestone issues
2. Prioritize tasks
3. Create feature branch
4. Work through issues
5. Tag and release after milestone completion

### Issue Lifecycle
1. **Backlog** - Issue created, not started
2. **In Progress** - Someone is working on it
3. **In Review** - PR submitted, awaiting review
4. **Done** - Merged and deployed

### Tagging Strategy
- Legacy: `v1.x-net35` (.NET Framework 3.5)
- Phase 2a: `v2.x-net48` (.NET Framework 4.8)
- Phase 2b: `v3.x-net6` (.NET 6)
- Phase 2c: `v4.x-net8` (.NET 8)
- Phase 4: `v5.x` (Modern rewrite)

## CI/CD Integration

Each migration phase updates:
- `.github/workflows/build-legacy.yml` (or new workflow files)
- `AGENTS.md` (build instructions)
- `README.md` (runtime requirements)

## Updating the Roadmap

To add new issues:
```bash
gh issue create \
  --title "Issue title" \
  --body "Issue description" \
  --label "migration,enhancement" \
  --milestone ".NET 4.x Migration"
```

To modify milestones:
```bash
gh milestone edit ".NET 4.x Migration" --due-date 2025-03-01
```

## Resources

- **GitHub CLI Docs**: https://cli.github.com/manual/
- **Project Boards**: https://docs.github.com/en/issues/organizing-your-work-with-project-boards
- **Milestones**: https://docs.github.com/en/issues/using-labels-and-milestones-to-track-work/about-milestones

---

**Created**: 2025-01-18
**Author**: Marcus Ackre Medina
**Purpose**: Structure the TopWinPrio modernization journey
