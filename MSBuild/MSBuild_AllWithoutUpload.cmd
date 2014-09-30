SET ROOTDIR=%USERPROFILE%\Documents\GitHub\OntologyManagement\
del %TEMP%\OntologyManagement\*.* /s /q
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Ontolog-Module \Ontolog-Module.sln 0.3.0.118 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ File-Tagging-Module \File-Tagging-Module.sln 0.0.0.36 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Security-Module \Security-Module.sln 0.2.0.34 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ PortListenerForText-Module \PortListenerForText-Module.sln 0.0.0.6 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ ElasticSearchConfig-Module \ElasticSearchConfig-Module.sln 0.0.0.32 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ ModuleLibrary \ModuleLibrary.sln 0.0.0.41 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Variable-Value-Module \Variable-Value-Module.sln 0.0.0.30 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ RDF-Module \RDF-Module.sln 0.0.0.69 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Localization-Module \Localization-Module.sln 0.0.1.35 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Formale-Begriffsanalyse-Module \Formale-Begriffsanalyse-Module.sln 0.0.0.29 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ ClipBoardListener-Url-Connector \ClipBoardListener-Url-Module.sln 0.0.0.35 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ GraphMLConnector \GraphMLConnector.sln 0.0.0.78 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Hierarchichal-Splitter-Module \Hierarchichal-Splitter-Module.sln 0.0.0.39 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ CommandLineRun-Module \CommandLineRun-Module.sln 0.0.0.17 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Ping-Test-Module \Ping-Test-Module.sln 0.0.0.31 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Log-Module \Log-Module.sln 0.2.0.41 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ TimeManagement-Module \TimeManagement-Module.sln 0.0.0.77 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ CommandLineCL-Module \CommandLineCL-Module.sln 0.0.0.10 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ ElasticSearchLogging-Module \ElasticSearchLogging-Module.sln 0.0.0.34 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Version-Module \Version-Module.sln 0.0.1.38 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Filesystem-Module \Filesystem-Module.sln 0.2.0.72 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Manual-Repair-Module \Manual-Repair-Module.sln 0.0.0.29 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ HTMLExport-Module \HTMLExport-Module.sln 0.0.0.71 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ TextParser \TextParser.sln 0.0.0.79 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Office-Module \Office-Module.sln 0.0.1.50 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Typed-Tagging-Module \Typed-Tagging-Module.sln 0.0.0.63 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ AudioPlayer-Module \AudioPlayer-Module.sln 0.0.0.47 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ BankTransaction-Module \BankTransaction-Module.sln 0.0.1.49 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Development-Module \Development-Module.sln 0.2.0.92 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Media-Viewer-Module \Media-Viewer-Module.sln 0.0.1.102 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ FileResourceModule \FileResourceModule.sln 0.0.0.56 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ FileSystem-Connector-Module \FileSystem-Connector-Module.sln 0.0.0.66 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Scenes-Literatur-Module \Scenes-Literatur-Module.sln 0.0.1.65 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Process-Module \Process-Module.sln 0.2.0.66 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ OutlookConnector-Module \OutlookConnector-Module.sln 0.0.0.79 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Partner-Module \Partner-Module.sln 0.2.0.69 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Report-Module \Report-Module.sln 0.0.1.83 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Appointment-Module \Appointment-Module.sln 0.0.1.69 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Schriftverkehrs-Module \Schriftverkehrs-Module.sln 0.0.0.78 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Bill-Module \Bill-Module.sln 0.0.0.79 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ LiteraturQuellen-Module \LiteraturQuellen-Module.sln 0.0.0.124 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Change-Module \Change-Module.sln 0.2.0.83 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Checklist-Module \Checklist-Module.sln 0.0.0.88 1 1 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler