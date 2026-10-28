# Publish Ikaru CastDesk (framework-dependent)
$ErrorActionPreference = "Stop"
$Root = Split-Path -Parent (Split-Path -Parent $MyInvocation.MyCommand.Path)
Set-Location $Root

$Out = Join-Path $Root "dist\IkaruCastDesk"
Remove-Item -Recurse -Force $Out -ErrorAction SilentlyContinue
New-Item -ItemType Directory -Force -Path $Out | Out-Null

Write-Host "==> Publish framework-dependent"

dotnet publish .\src\KantorCast\KantorCast.csproj `
  -c Release `
  --self-contained false `
  -p:PublishSingleFile=false `
  -p:DebugType=None `
  -p:DebugSymbols=false `
  -o $Out

if ($LASTEXITCODE -ne 0) {
  Write-Host "Publish gagal." -ForegroundColor Red
  exit $LASTEXITCODE
}

Write-Host ""
Write-Host "OK: $Out\IkaruCastDesk.exe"
Write-Host "PC target perlu: .NET 8 Desktop Runtime x64"
Write-Host "Opsional H.264/audio: salin ffmpeg.exe ke $Out"
