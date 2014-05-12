SET ROOTDIR=%1
SET PROJECTFOLDER=%2
SET PROJECTFILE=%3
SET VERSION=%4

mkdir "%TEMP%\OntologyManamgent\%PROJECTFOLDER%"
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe /m "%ROOTDIR%%PROJECTFOLDER%%PROJECTFILE%" /fl /flp:logfile=%TEMP%\OntologyManamgent\%PROJECTFOLDER%_dbg.log;errorsonly
for %%F in (%TEMP%\OntologyManamgent\%PROJECTFOLDER%_dbg.log) do set size1=%%~zF
if %size1% GTR 1 goto Fehler
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe /p:Configuration=Release /p:OutputPath="%TEMP%\OntologyManamgent\%PROJECTFOLDER%" "%ROOTDIR%%PROJECTFOLDER%%PROJECTFILE%" /fl /flp:logfile=%TEMP%\OntologyManamgent\%PROJECTFOLDER%_rel.log;errorsonly
if %size1% GTR 1 goto Fehler
del "%TEMP%\OntologyManamgent\%PROJECTFOLDER%\*.pdb"
"c:\Program Files\7-Zip\7z" a -mmt -mx5 -sfx7z.sfx -r "%TEMP%\OntologyManamgent\%PROJECTFOLDER%_%VERSION%.exe" "%TEMP%\OntologyManamgent\%PROJECTFOLDER%\*.*"
if ERRORLEVEL 1 Goto Fehler
Goto Ende
:Fehler
Exit 1
:Ende