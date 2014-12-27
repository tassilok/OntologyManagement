SET PROJECTFOLDER=%2
SET PROJECTFILE=%3
SET VERSION=%4
SET DEBUG=%5
SET RELEASE=%6
SET UPLOAD=%7

mkdir "%TEMP%\OntologyManagement\%PROJECTFOLDER%"
IF NOT [%RELEASE%] EQU [1] Goto Debug

:Debug

:Release
IF NOT [%RELEASE%] EQU [1] goto Ende

del "%TEMP%\OntologyManagement\%PROJECTFOLDER%\*.pdb"
"c:\Program Files\7-Zip\7z" a -mmt -mx5 -sfx7z.sfx -r "%TEMP%\OntologyManagement\%PROJECTFOLDER%_%VERSION%.exe" "%TEMP%\OntologyManagement\%PROJECTFOLDER%\*.*"
if ERRORLEVEL 1 Goto Fehler

echo #!/bin/bash>%TEMP%\Sourceforge.sh

if /i [%PROJECTFOLDER%] EQU [Ontology-Module] GOTO ONTOLOGYMANAGER
:MODULE
IF /i [%UPLOAD%] EQU [0] Goto Ende
cmd /c "C:\cygwin64\bin\scp.exe \Users\Tassilo\AppData\Local\Temp\OntologyManagement\%PROJECTFOLDER%_%VERSION%.exe tassilok,ontologymanager@web.sourceforge.net:/home/frs/project/ontologymanager/Modules/%PROJECTFOLDER%/%PROJECTFOLDER%_%VERSION%.exe"
cmd /c "exit /b 0"
GOTO Ende

:ONTOLOGYMANAGER
IF /i [%UPLOAD%] EQU [0] Goto Ende
cmd /c "C:\cygwin64\bin\scp.exe \Users\Tassilo\AppData\Local\Temp\OntologyManagement\%PROJECTFOLDER%_%VERSION%.exe tassilok,ontologymanager@web.sourceforge.net:/home/frs/project/ontologymanager/OntologyManager/%PROJECTFOLDER%_%VERSION%.exe"
cmd /c "exit /b 0"
GOTO Ende


Goto Ende
:Fehler
Exit 1
:Ende