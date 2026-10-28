# Self-contained (butuh akses NuGet ke runtime pack). Jika NU1100, pakai publish.ps1 saja.
$ErrorActionPreference = "Stop"
$Root = Split-Path -Parent (Split-Path -Parent $MyInvocation.MyCommand.Path)
Set-Location $Root
$Out = Join-Path $Root "dist\Ikaru CastDesk-SC"
New-Item -ItemType Directory -Force -Path $Out | Out-Null

dotnet publish .\src\KantorCast\KantorCast.csproj `
  -c Release -r win-x64 --self-contained true `
  -p:PublishSingleFile=true `
  -p:IncludeNativeLibrariesForSelfExtract=true `
  -p:EnableCompressionInSingleFile=true `
  -p:PublishTrimmed=false `
  -o $Out

Write-Host "Output: $Out"
