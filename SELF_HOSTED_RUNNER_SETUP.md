# Self-Hosted Runner Setup for Code Signing

This guide explains how to set up a self-hosted GitHub Actions runner on your local Windows machine for code signing with Certum certificates.

## Prerequisites

- Windows 10/11 with Administrator access
- Certum Code Signing certificate installed in Windows Certificate Store
- Windows SDK (for signtool.exe)

## Step 1: Install Windows SDK

1. Download **Windows SDK** from: https://developer.microsoft.com/en-us/windows/downloads/windows-sdk/
2. Install with at least these components:
   - Windows SDK Signing Tools for Desktop Apps
3. Verify installation:
   ```powershell
   Test-Path "C:\Program Files (x86)\Windows Kits\10\bin\x64\signtool.exe"
   ```

## Step 2: Verify Certum Certificate

Check that your Certum certificate is installed:

```powershell
# List certificates in Personal store
Get-ChildItem Cert:\CurrentUser\My | Where-Object {$_.Subject -like "*Marcus*"}

# Expected subject name (update in workflow if different):
# "Open Source Developer, Marcus Ackre Medina"
```

## Step 3: Setup GitHub Actions Runner

### Create Runner Directory

```powershell
# Run as Administrator
New-Item -ItemType Directory -Path C:\actions-runner -Force
Set-Location C:\actions-runner
```

### Download and Configure Runner

1. Go to GitHub: **TopWinPrio → Settings → Actions → Runners**
2. Click **"New self-hosted runner"**
3. Select **Windows** as OS
4. Copy and run the download command:
   ```powershell
   # Example (GitHub provides the exact URL):
   Invoke-WebRequest -Uri https://github.com/actions/runner/releases/download/v2.xxx/actions-runner-win-x64-2.xxx.zip -OutFile actions-runner.zip
   ```

5. Extract:
   ```powershell
   Expand-Archive -Path actions-runner.zip -DestinationPath . -Force
   ```

6. Configure with **code-sign** label:
   ```powershell
   # GitHub provides the token - replace YOUR_TOKEN
   .\config.cmd --url https://github.com/MarcusMedina/TopWinPrio --token YOUR_TOKEN --labels windows,code-sign --name local-code-signer
   ```

### Install as Windows Service

```powershell
# Install service (runs as SYSTEM by default)
.\svc.cmd install

# Start service
.\svc.cmd start

# Verify status
.\svc.cmd status
```

## Step 4: Verify Runner Registration

1. Go to GitHub: **TopWinPrio → Settings → Actions → Runners**
2. You should see **"local-code-signer"** with status **"Idle"** (green dot)
3. Labels should show: `self-hosted`, `Windows`, `code-sign`

## Step 5: Test Signing Workflow

### Manual Test (Local)

Test signing locally before running in Actions:

```powershell
cd C:\Git\MarcusMedina\TopWinPrio
msbuild TopWinPrio.sln /p:Configuration=Release /p:Platform="Any CPU"

$signtool = "C:\Program Files (x86)\Windows Kits\10\bin\x64\signtool.exe"
& $signtool sign /n "Open Source Developer, Marcus Ackre Medina" /fd SHA256 /tr http://time.certum.pl /td SHA256 /v "TopWinPrio.CS\bin\Release\TopWinPrio.exe"

# Verify signature
& $signtool verify /pa /v "TopWinPrio.CS\bin\Release\TopWinPrio.exe"
```

### Trigger Workflow Test

Push to main to trigger build and signing:

```powershell
git add .
git commit -m "Enable code signing workflow"
git push origin main
```

Watch the workflow: **Actions → 🔏 Sign Artifacts (Local Runner)**

## Troubleshooting

### Runner Not Starting

```powershell
# Check service status
.\svc.cmd status

# View service logs
Get-Content C:\actions-runner\_diag\*.log -Tail 50
```

### Certificate Not Found

```powershell
# List all certificates with details
Get-ChildItem Cert:\CurrentUser\My | Format-List Subject, Thumbprint, FriendlyName

# Update CERTUM_CERT_NAME in workflow if subject differs
```

### Signtool Not Found

```powershell
# Find signtool location
Get-ChildItem "C:\Program Files (x86)\Windows Kits" -Recurse -Filter signtool.exe

# Update signtool path in workflow if different
```

### Workflow Not Triggering

Check workflow conditions in `sign_artifacts.yml`:
- `ENABLE_CODE_SIGN` must be `"true"`
- Build workflow must complete successfully
- Push must be to `main` branch or start with `v` (tags)

## Security Notes

- Runner runs as Windows SYSTEM account by default
- Certificate access requires proper permissions
- Keep runner machine secure - it has write access to repository
- Monitor runner logs regularly: `C:\actions-runner\_diag\`

## Maintenance

### Update Runner

```powershell
# Stop service
.\svc.cmd stop

# Download new version
Invoke-WebRequest -Uri NEW_RUNNER_URL -OutFile actions-runner-new.zip

# Backup old config
Copy-Item .runner -Destination .runner.backup
Copy-Item .credentials -Destination .credentials.backup

# Extract new version
Expand-Archive -Path actions-runner-new.zip -DestinationPath . -Force

# Start service
.\svc.cmd start
```

### Remove Runner

```powershell
# Stop and uninstall service
.\svc.cmd stop
.\svc.cmd uninstall

# Remove from GitHub
.\config.cmd remove --token YOUR_REMOVAL_TOKEN
```

## Reference

- GitHub Actions Self-Hosted Runners: https://docs.github.com/en/actions/hosting-your-own-runners
- Certum Documentation: https://www.certum.eu/en/code-signing/
- Windows SDK: https://developer.microsoft.com/en-us/windows/downloads/windows-sdk/
