SET ROOTDIR=%1
SET PROJECTFOLDER=%2
SET PROJECTFILE=%3
SET VERSION=%4
SET DEBUG=%5
SET RELEASE=%6

IF NOT [%RELEASE%] EQU [1] Goto Debug
mkdir "%TEMP%\OntologyManamgent\%PROJECTFOLDER%"

:Debug
IF NOT [%DEBUG%] EQU [1] Goto Release
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe /m "%ROOTDIR%%PROJECTFOLDER%%PROJECTFILE%" /fl /flp:logfile=%TEMP%\OntologyManamgent\%PROJECTFOLDER%_dbg.log;errorsonly
for %%F in (%TEMP%\OntologyManamgent\%PROJECTFOLDER%_dbg.log) do set size1=%%~zF
if %size1% GTR 1 goto Fehler


:Release
IF NOT [%RELEASE%] EQU [1] goto Ende
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe /p:Configuration=Release /p:OutputPath="%TEMP%\OntologyManamgent\%PROJECTFOLDER%" "%ROOTDIR%%PROJECTFOLDER%%PROJECTFILE%" /fl /flp:logfile=%TEMP%\OntologyManamgent\%PROJECTFOLDER%_rel.log;errorsonly
if %size1% GTR 1 goto Fehler
del "%TEMP%\OntologyManamgent\%PROJECTFOLDER%\*.pdb"
"c:\Program Files\7-Zip\7z" a -mmt -mx5 -sfx7z.sfx -r "%TEMP%\OntologyManamgent\%PROJECTFOLDER%_%VERSION%.exe" "%TEMP%\OntologyManamgent\%PROJECTFOLDER%\*.*"
if ERRORLEVEL 1 Goto Fehler

Goto Ende
:Fehler
Exit 1
:Ende