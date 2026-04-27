@echo off
setlocal

set "SCRIPT_DIR=%~dp0"
set "PS_SCRIPT=%SCRIPT_DIR%Setup-Sysmon.ps1"

if not exist "%PS_SCRIPT%" (
    echo Setup-Sysmon.ps1 was not found in:
    echo %SCRIPT_DIR%
    exit /b 1
)

net session >nul 2>&1
if %errorlevel% neq 0 (
    powershell -NoProfile -ExecutionPolicy Bypass -Command "Start-Process -FilePath '%ComSpec%' -ArgumentList '/c ""%~f0""' -Verb RunAs"
    exit /b
)

powershell -NoProfile -ExecutionPolicy Bypass -File "%PS_SCRIPT%" %*
set "EXIT_CODE=%ERRORLEVEL%"

if not "%EXIT_CODE%"=="0" (
    echo.
    echo Sysmon setup failed with exit code %EXIT_CODE%.
)

exit /b %EXIT_CODE%