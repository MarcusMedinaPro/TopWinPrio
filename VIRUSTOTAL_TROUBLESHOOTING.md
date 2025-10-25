# 🦠 VirusTotal API Troubleshooting Guide

## 401 Unauthorized Error - Common Causes & Solutions

### 1. **Secret Configuration Issues** 🔐

**Check Secret Name:**
- Must be exactly `VIRUSTOTAL_API_KEY` (case-sensitive)
- No extra spaces or characters

**Organization vs Repository Secrets:**
- If set at Organization level, ensure "Selected repositories" includes this repo
- Or set at Repository level: Settings → Secrets and variables → Actions

**Verify Secret Value:**
```bash
# Your API key should be 64 characters long
# Format: a1b2c3d4e5f6...(hex string)
```

### 2. **API Key Validity Issues** 🗝️

**Check on VirusTotal Website:**
1. Login to https://www.virustotal.com
2. Go to your profile → API Key
3. Verify the key matches exactly what's in GitHub Secrets
4. Check if key is active and not suspended

**API Key Permissions:**
- Ensure your VirusTotal account has file upload permissions
- Free tier has rate limits (4 requests/minute)

### 3. **Rate Limiting** ⏱️

**Symptoms:**
- Works sometimes, fails other times
- 401 or 429 status codes

**Solutions:**
- Wait 15+ minutes between attempts
- Use `request_rate` parameter to slow down requests
- Upgrade to paid VirusTotal API if needed

### 4. **Network/Connectivity Issues** 🌐

**GitHub Actions Network:**
- Occasionally GitHub runners have connectivity issues
- VirusTotal API might be temporarily unavailable

**Debugging Steps:**
```yaml
# Add to workflow for debugging
- name: Test VirusTotal API
  run: |
    curl -H "x-apikey: ${{ secrets.VIRUSTOTAL_API_KEY }}" \
         "https://www.virustotal.com/vtapi/v2/file/report?resource=test"
```

## 🔧 Quick Fixes to Try

### Fix 1: Update API Endpoint
The action might be using an older API version. Try specifying:
```yaml
- name: VirusTotal Scan
  uses: crazy-max/ghaction-virustotal@v4
  with:
    vt_api_key: ${{ secrets.VIRUSTOTAL_API_KEY }}
    files: TopWinPrio.exe
    vt_monitor: false  # Disable monitoring features
```

### Fix 2: Single File Scanning
Try scanning one file at a time:
```yaml
files: TopWinPrio.CS/bin/Release/TopWinPrio.exe
# Instead of: TopWinPrio.CS/bin/Release/*.exe
```

### Fix 3: Alternative Action
If the current action continues failing:
```yaml
- name: Upload to VirusTotal
  run: |
    $file = "TopWinPrio.CS/bin/Release/TopWinPrio.exe"
    $uri = "https://www.virustotal.com/vtapi/v2/file/scan"
    $headers = @{"apikey" = "${{ secrets.VIRUSTOTAL_API_KEY }}"}
    
    # Use Invoke-RestMethod for direct API call
```

## 🧪 Debugging Workflow

Run the debug workflow to test your setup:

1. Go to Actions → "🧪 Debug VirusTotal API"
2. Click "Run workflow"
3. Select test mode: `api_test` for basic connectivity
4. Review the results

## ✅ Verification Steps

### Test 1: Secret Accessibility
```bash
# In GitHub Actions, this should show key info:
echo "Key length: ${#VIRUSTOTAL_API_KEY}"
echo "Key start: ${VIRUSTOTAL_API_KEY:0:8}..."
```

### Test 2: Manual API Call
```bash
# This should return JSON, not 401:
curl -H "x-apikey: YOUR_API_KEY" \
     "https://www.virustotal.com/vtapi/v2/file/report?resource=test"
```

### Test 3: File Upload Test
Upload a small test file manually to verify your account works.

## 📞 Getting Help

### If Still Failing:
1. **Run debug workflow** and share results
2. **Check VirusTotal API status**: https://docs.virustotal.com/
3. **Verify account status** on VirusTotal website
4. **Consider alternative**: Manual verification (see VIRUSTOTAL_VERIFICATION.md)

### Common Solutions Summary:
- ✅ **90% of cases**: Secret name mismatch or organization access
- ✅ **8% of cases**: API key expired or account issues  
- ✅ **2% of cases**: Rate limiting or network issues

### Contact Support:
- **VirusTotal API issues**: contact@virustotal.com
- **GitHub Actions issues**: GitHub support
- **Repository issues**: Create GitHub Discussion

---
**Pro Tip**: Always test with the debug workflow first before troubleshooting in the main release pipeline! 🎯