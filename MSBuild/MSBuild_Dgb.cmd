SET ROOTDIR=%USERPROFILE%\Documents\GitHub\OntologyManagement\
del %TEMP%\OntologyManagement\*.* /s /q
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ OntologyClasses \OntologyClasses.sln 0.0.1.4 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Structure-Module \Structure-Module.sln 0.0.1.1 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ ClassLibrary_ShellWork \ClassLibrary_ShellWork.sln 0.1.0.1 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ ElasticSearchNestConnector \ElasticSearchNestConnector.sln 0.0.0.44 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Ontolog-Module \Ontolog-Module.sln 0.3.0.115 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ File-Tagging-Module \File-Tagging-Module.sln 0.0.0.33 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Security-Module \Security-Module.sln 0.2.0.31 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ PortListenerForText-Module \PortListenerForText-Module.sln 0.0.0.3 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ ElasticSearchConfig-Module \ElasticSearchConfig-Module.sln 0.0.0.29 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ ModuleLibrary \ModuleLibrary.sln 0.0.0.38 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Variable-Value-Module \Variable-Value-Module.sln 0.0.0.27 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ RDF-Module \RDF-Module.sln 0.0.0.66 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Localization-Module \Localization-Module.sln 0.0.1.32 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Formale-Begriffsanalyse-Module \Formale-Begriffsanalyse-Module.sln 0.0.0.26 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ ClipBoardListener-Url-Connector \ClipBoardListener-Url-Module.sln 0.0.0.31 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ GraphMLConnector \GraphMLConnector.sln 0.0.0.74 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Hierarchichal-Splitter-Module \Hierarchichal-Splitter-Module.sln 0.0.0.35 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ CommandLineRun-Module \CommandLineRun-Module.sln 0.0.0.13 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Ping-Test-Module \Ping-Test-Module.sln 0.0.0.28 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Log-Module \Log-Module.sln 0.2.0.37 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ TimeManagement-Module \TimeManagement-Module.sln 0.0.0.73 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ CommandLineCL-Module \CommandLineCL-Module.sln 0.0.0.6 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ ElasticSearchLogging-Module \ElasticSearchLogging-Module.sln 0.0.0.31 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Version-Module \Version-Module.sln 0.0.1.34 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Filesystem-Module \Filesystem-Module.sln 0.2.0.68 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Manual-Repair-Module \Manual-Repair-Module.sln 0.0.0.26 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ HTMLExport-Module \HTMLExport-Module.sln 0.0.0.67 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ TextParser \TextParser.sln 0.0.0.74 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Office-Module \Office-Module.sln 0.0.1.46 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Typed-Tagging-Module \Typed-Tagging-Module.sln 0.0.0.58 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ AudioPlayer-Module \AudioPlayer-Module.sln 0.0.0.42 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ BankTransaction-Module \BankTransaction-Module.sln 0.0.1.45 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Development-Module \Development-Module.sln 0.2.0.85 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Media-Viewer-Module \Media-Viewer-Module.sln 0.0.1.96 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ FileResourceModule \FileResourceModule.sln 0.0.0.50 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ FileSystem-Connector-Module \FileSystem-Connector-Module.sln 0.0.0.60 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Scenes-Literatur-Module \Scenes-Literatur-Module.sln 0.0.1.59 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Process-Module \Process-Module.sln 0.2.0.60 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ OutlookConnector-Module \OutlookConnector-Module.sln 0.0.0.72 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Partner-Module \Partner-Module.sln 0.2.0.63 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Report-Module \Report-Module.sln 0.0.1.75 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Appointment-Module \Appointment-Module.sln 0.0.1.62 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Schriftverkehrs-Module \Schriftverkehrs-Module.sln 0.0.0.69 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Bill-Module \Bill-Module.sln 0.0.0.70 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ LiteraturQuellen-Module \LiteraturQuellen-Module.sln 0.0.0.116 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Change-Module \Change-Module.sln 0.2.0.77 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Checklist-Module \Checklist-Module.sln 0.0.0.78 1 0 0
IF ERRORLEVEL 1 GOTO Fehler

:Fehler