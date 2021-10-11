@ECHO OFF

SETLOCAL

CALL %CTKBLDROOT%setupEnv.cmd

SET BASENAME=Cyotek.Windows.Forms.ColorPicker
SET RELDIR=%BASENAME%.Tests\bin\Release\
SET PRJFILE=%BASENAME%.Tests\%BASENAME%.Tests.csproj
SET DLLNAME=%BASENAME%.Tests.dll
SET NUNITVER=3.12.0
SET NUNITEXE=%USERPROFILE%\.nuget\packages\nunit.consolerunner\%NUNITVER%\tools\nunit3-console.exe

IF EXIST testresults RMDIR testresults /Q /S
MKDIR testresults

dotnet build %PRJFILE% --configuration Release
IF %ERRORLEVEL% NEQ 0 GOTO :failed

CALL :runtests net35
IF %ERRORLEVEL% NEQ 0 GOTO :failed
CALL :runtests net40
IF %ERRORLEVEL% NEQ 0 GOTO :failed
CALL :runtests net452
IF %ERRORLEVEL% NEQ 0 GOTO :failed
CALL :runtests net462
IF %ERRORLEVEL% NEQ 0 GOTO :failed
CALL :runtests net472
IF %ERRORLEVEL% NEQ 0 GOTO :failed
CALL :runtests net48
IF %ERRORLEVEL% NEQ 0 GOTO :failed
REM CALL :runtests net5.0
REM IF %ERRORLEVEL% NEQ 0 GOTO :failed
REM CALL :runtests netcoreapp2.1
REM IF %ERRORLEVEL% NEQ 0 GOTO :failed
REM CALL :runtests netcoreapp2.2
REM IF %ERRORLEVEL% NEQ 0 GOTO :failed

ENDLOCAL

GOTO :eof

:failed
CECHO {0c}ERROR  : Test run failed{#}{\n}
EXIT /b 1

:runtests
SET PLATFORM=%1

"%NUNITEXE%" "%RELDIR%%PLATFORM%\%DLLNAME%" -result="./testresults/%BASENAME%-%PLATFORM%.xml"
IF %ERRORLEVEL% NEQ 0 EXIT /b 1

"%NUNITEXE%" "%RELDIR%%PLATFORM%\%DLLNAME%" -result="./testresults/%BASENAME%-%PLATFORM%-x86.xml" -x86
IF %ERRORLEVEL% NEQ 0 EXIT /b 1

EXIT /b 0