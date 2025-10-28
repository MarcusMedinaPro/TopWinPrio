# Git Workflow

## Branch Structure

### `main` branch
- **Produktionsklar kod**
- Skyddad branch (endast merge från develop)
- Alla commits taggade med versioner (v3.0.0, v3.1.0, etc.)
- CI/CD bygger release artifacts

### `develop` branch
- **Daglig utveckling**
- Quality checks körs automatiskt (GitHub Actions)
- Tester måste passera innan merge till main
- Fritt att pusha ändringar

## Workflow

### 1. Daglig utveckling
```bash
git checkout develop
# Gör ändringar...
git add -A
git commit -m "feat: add new feature"
git push origin develop
```

### 2. Vänta på quality checks
- GitHub Actions kör automatiskt:
  - Build
  - Tests
  - Code quality checks

### 3. Merge till main (när tests passerar)
```bash
git checkout main
git merge develop
git push origin main
```

### 4. Tagga release
```bash
git tag -a v3.1.0 -m "Release v3.1.0"
git push origin v3.1.0
```

## Commit Message Format

Använd [Conventional Commits](https://www.conventionalcommits.org/):

- `feat:` Ny feature
- `fix:` Buggfix
- `docs:` Dokumentation
- `style:` Formatering
- `refactor:` Refaktorering
- `test:` Tester
- `chore:` Underhåll

**Exempel:**
```
feat: add dark mode support
fix: resolve crash on startup
docs: update README with new features
```

## Hotfixes

Om kritisk bugg i main:
```bash
git checkout main
git checkout -b hotfix/critical-bug
# Fix bug...
git commit -m "fix: critical security issue"
git checkout main
git merge hotfix/critical-bug
git push origin main
git tag -a v3.0.1 -m "Hotfix v3.0.1"
git push origin v3.0.1

# Merge tillbaka till develop också
git checkout develop
git merge main
git push origin develop
```

## Setup

Kör setup script:
```bash
.\setup-gitflow.ps1
```

## Protection Rules (GitHub Settings)

### Main Branch Protection
- ✅ Require pull request reviews
- ✅ Require status checks (develop-quality)
- ✅ Require branches to be up to date
- ✅ Include administrators

### Develop Branch Protection
- ✅ Require status checks (build + tests)
- ✅ Allow force push (för rebasing)
