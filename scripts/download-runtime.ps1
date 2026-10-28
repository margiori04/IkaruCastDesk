# Download .NET 8 Desktop Runtime for offline bundle in installer
$ErrorActionPreference = "Stop"
$Root = Split-Path -Parent (Split-Path -Parent $MyInvocation.MyCommand.Path)
$Dir = Join-Path $Root "installer\runtime"
New-Item -ItemType Directory -Force -Path $Dir | Out-Null
$Out = Join-Path $Dir "windowsdesktop-runtime-8.0-win-x64.exe"
$Url = "https://aka.ms/dotnet/8.0/windowsdesktop-runtime-win-x64.exe"

Write-Host "Downloading $Url"
Write-Host " -> $Out"
Invoke-WebRequest -Uri $Url -OutFile $Out -UseBasicParsing

$size = [math]::Round((Get-Item $Out).Length / 1MB, 1)
Write-Host "OK ($size MB)"
Write-Host "Next: compile installer\KantorCast.iss - runtime will be offline in Setup.exe"
