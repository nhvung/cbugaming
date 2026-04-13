Write-Host "Hello from PowerShell!" -ForegroundColor Green
Write-Host "Current Time: $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')"
Write-Host "Computer: $env:COMPUTERNAME"
Write-Host "User: $env:USERNAME"
