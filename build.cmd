@ECHO OFF

SETLOCAL

CALL ..\..\..\build\set35vars.bat

%msbuildexe% Cyotek.Windows.Forms.ColorPicker.sln /p:Configuration=Release /verbosity:minimal /nologo /t:Clean,Build
CALL dualsigncmd Cyotek.Windows.Forms.ColorPicker\bin\Release\Cyotek.Windows.Forms.ColorPicker.dll

PUSHD
IF NOT EXIST nuget MKDIR nuget
CD nuget
%nugetexe% pack ..\Cyotek.Windows.Forms.ColorPicker\Cyotek.Windows.Forms.ColorPicker.csproj -Prop Configuration=Release
%zipexe% a -bd -tZip  Cyotek.Windows.Forms.ColorPicker.x.x.x.x.zip ..\Cyotek.Windows.Forms.ColorPicker\bin\Release\Cyotek.Windows.Forms.ColorPicker.*
POPD

ENDLOCAL
