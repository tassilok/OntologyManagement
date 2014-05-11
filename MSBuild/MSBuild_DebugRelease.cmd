SET ROOTDIR=%1
SET PROJECTFOLDER=%2
SET PROJECTFILE=%3
SET VERSION=%4

C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe /m "%ROOTDIR%%PROJECTFOLDER%%PROJECTFILE%"
mkdir "%TEMP%\OntologyManamgent\%PROJECTFOLDER%"
del "%TEMP%\OntologyManamgent\%PROJECTFOLDER%\*.*" /s /q
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe /p:Configuration=Release /p:OutputPath="%TEMP%\OntologyManamgent\%PROJECTFOLDER%" "%ROOTDIR%%PROJECTFOLDER%%PROJECTFILE%"
del "%TEMP%\OntologyManamgent\%PROJECTFOLDER%\*.pdb"
"c:\Program Files\7-Zip\7z" a -mmt -mx5 -sfx7z.sfx -r "%TEMP%\OntologyManamgent\%PROJECTFOLDER%_%VERSION%.exe" "%TEMP%\OntologyManamgent\%PROJECTFOLDER%\*.*"