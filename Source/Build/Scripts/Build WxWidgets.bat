SETLOCAL EnableDelayedExpansion

set SCRIPT_HOME=%~dp0.

dotnet msbuild /t:BuildWxWidgets "%SCRIPT_HOME%\..\Alternet.UI.Pal\Alternet.UI.Pal.proj"
if not !ERRORLEVEL! EQU 0 (
    exit /b !ERRORLEVEL!)

exit /b 0