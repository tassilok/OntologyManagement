SET ROOTDIR=%USERPROFILE%\Documents\GitHub\OntologyManagement\
del %TEMP%\OntologyManamgent\*.* /s /q
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ OntologyClasses \OntologyClasses.sln 0.0.1.3 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ ClassLibrary_ShellWork \ClassLibrary_ShellWork.sln 0.1.0.0 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ ElasticSearchNestConnector \ElasticSearchNestConnector.sln 0.0.0.1 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Ontolog-Module \Ontolog-Module.sln 0.3.0.86 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Security-Module \Security-Module.sln 0.2.0.4 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ ElasticSearchConfig-Module \ElasticSearchConfig-Module.sln 0.0.0.2 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Variable-Value-Module \Variable-Value-Module.sln 0.0.0.2 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Localization-Module \Localization-Module.sln 0.0.1.4 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ GraphMLConnector \GraphMLConnector.sln 0.0.0.45 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Ping-Test-Module \Ping-Test-Module.sln 0.0.0.2 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Log-Module \Log-Module.sln 0.2.0.9 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ TimeManagement-Module \TimeManagement-Module.sln 0.0.0.44 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Typed-Tagging-Module \Typed-Tagging-Module.sln 0.0.0.11 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ ElasticSearchLogging-Module \ElasticSearchLogging-Module.sln 0.0.0.2 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Version-Module \Version-Module.sln 0.0.1.5 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Filesystem-Module \Filesystem-Module.sln 0.2.0.29 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Development-Module \Development-Module.sln 0.2.0.11 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ TextParser \TextParser.sln 0.0.0.23 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Office-Module \Office-Module.sln 0.0.1.8 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Media-Viewer-Module \Media-Viewer-Module.sln 0.0.1.47 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ AudioPlayer-Module \AudioPlayer-Module.sln 0.0.0.3 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ BankTransaction-Module \BankTransaction-Module.sln 0.0.1.4 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ FileSystem-Connector-Module \FileSystem-Connector-Module.sln 0.0.0.5 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Scenes-Literatur-Module \Scenes-Literatur-Module.sln 0.0.1.6 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Process-Module \Process-Module.sln 0.2.0.7 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Checklist-Module \Checklist-Module.sln 0.0.0.9 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ OutlookConnector-Module \OutlookConnector-Module.sln 0.0.0.22 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Partner-Module \Partner-Module.sln 0.2.0.13 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ FileResourceModule \FileResourceModule.sln 0.0.0.5 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Report-Module \Report-Module.sln 0.0.1.10 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Appointment-Module \Appointment-Module.sln 0.0.1.7 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Schriftverkehrs-Module \Schriftverkehrs-Module.sln 0.0.0.7 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Bill-Module \Bill-Module.sln 0.0.1.8 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ LiteraturQuellen-Module \LiteraturQuellen-Module.sln 0.0.0.64 1 0
IF ERRORLEVEL 1 GOTO Fehler
CALL .\MSBuild_DebugRelease.cmd %ROOTDIR%\ Change-Module \Change-Module.sln 0.2.0.19 1 0
IF ERRORLEVEL 1 GOTO Fehler
GOTO Ende
:Fehler
echo Fehler>%TEMP%\OntologyManamgent\Error.log
:Ende