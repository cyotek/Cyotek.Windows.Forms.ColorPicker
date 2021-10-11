@ECHO OFF

SETLOCAL

CALL %CTKBLDROOT%setupEnv.cmd

SET BASENAME=Cyotek.Windows.Forms.ColorPicker
SET RELDIR=%BASENAME%\bin\Release\
SET PRJFILE=%BASENAME%\%BASENAME%.csproj
SET DLLNAME=%BASENAME%.dll

IF EXIST %RELDIR%*.nupkg  DEL /F %RELDIR%*.nupkg
IF EXIST %RELDIR%*.snupkg DEL /F %RELDIR%*.snupkg
IF EXIST %RELDIR%*.zip    DEL /F %RELDIR%*.zip

dotnet build %PRJFILE% --configuration Release
IF %ERRORLEVEL% NEQ 0 GOTO :failed

PUSHD %RELDIR%

CALL signcmd net35\%DLLNAME%
CALL signcmd net40\%DLLNAME%
CALL signcmd net452\%DLLNAME%
CALL signcmd net462\%DLLNAME%
CALL signcmd net472\%DLLNAME%
CALL signcmd net48\%DLLNAME%
CALL signcmd netcoreapp3.1\%DLLNAME%
CALL signcmd net5.0-windows\%DLLNAME%

%zipexe% a %BASENAME%.x.x.x.zip -r

POPD

dotnet pack %PRJFILE% --configuration Release --no-build
IF %ERRORLEVEL% NEQ 0 GOTO :failed

CALL sign-package %RELDIR%*.nupkg
CALL sign-package %RELDIR%*.snupkg

ENDLOCAL

GOTO :eof

:buildfailed
:failed
cecho {0c}ERROR  {#}: Build failed.{\n}
exit /b 1
