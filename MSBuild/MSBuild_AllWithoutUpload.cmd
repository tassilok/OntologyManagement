SET ROOTDIR=C:\Users\Tassilo\Documents\GitHub\OntologyManagement\
del %TEMP%\OntologyManagement\*.* /s /q

C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe /t:Clean,Build /p:Configuration=Release "%ROOTDIR%BuildSolution\BuildSolution.sln" /fl /flp:logfile=%TEMP%\OntologyManagement\BuildSolution_release.log;errorsonly
for %%F in (%TEMP%\OntologyManagement\BuildSolution_release.log) do set size1=%%~zF
if %size1% GTR 1 goto Fehler
CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ OntologyClasses \OntologyClasses.sln 0.0.1.5 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Structure-Module \Structure-Module.sln 0.0.1.1 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ ClassLibrary_ShellWork \ClassLibrary_ShellWork.sln 0.1.0.1 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ ClipBoardListener-Url-Connector \ClipBoardListener-Url-Module.sln 0.0.0.46 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ ElasticSearchNestConnector \ElasticSearchNestConnector.sln 0.0.0.45 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Ontology-Module \Ontolog-Module.sln 0.3.0.132 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ File-Tagging-Module \File-Tagging-Module.sln 0.0.0.46 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Security-Module \Security-Module.sln 0.2.0.44 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ PortListenerForText-Module \PortListenerForText-Module.sln 0.0.0.16 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ ElasticSearchConfig-Module \ElasticSearchConfig-Module.sln 0.0.0.44 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ ModuleLibrary \ModuleLibrary.sln 0.0.0.51 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Variable-Value-Module \Variable-Value-Module.sln 0.0.0.40 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ RDF-Module \RDF-Module.sln 0.0.0.79 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Localization-Module \Localization-Module.sln 0.0.1.45 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Formale-Begriffsanalyse-Module \Formale-Begriffsanalyse-Module.sln 0.0.0.45 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Grid-Module \Grid-Module.sln 0.0.0.3 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ NextGenerationOntoEdit \NextGenerationOntoEdit.sln 0.0.0.5 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ GraphMLConnector \GraphMLConnector.sln 0.0.0.90 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Hierarchichal-Splitter-Module \Hierarchichal-Splitter-Module.sln 0.0.0.49 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Ping-Test-Module \Ping-Test-Module.sln 0.0.0.41 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Log-Manager \Log-Module.sln 0.2.0.52 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ TimeManagement-Module \TimeManagement-Module.sln 0.0.0.89 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ ElasticSearchLogging-Module \ElasticSearchLogging-Module.sln 0.0.0.46 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Version-Module \Version-Module.sln 0.0.1.54 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Filesystem-Module \Filesystem-Module.sln 0.2.0.85 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Manual-Repair-Module \Manual-Repair-Module.sln 0.0.0.39 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ HTMLExport-Module \HTMLExport-Module.sln 0.0.0.84 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ TextParser \TextParser.sln 0.0.0.97 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Office-Module \Office-Module.sln 0.0.1.64 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Typed-Tagging-Module \Typed-Tagging-Module.sln 0.0.0.79 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ AudioPlayer-Module \AudioPlayer-Module.sln 0.0.0.64 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ CommandLineRun-Module \CommandLineRun-Module.sln 0.0.0.39 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ BankTransaction-Module \BankTransaction-Module.sln 0.0.1.66 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Development-Module \Development-Module.sln 0.2.0.118 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ DatabaseConfigurationModule \Database-Configuration-Module.sln 0.0.0.17 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ ScriptingModule \ScriptingModule.sln 0.0.0.8 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ CommandLineCL-Module \CommandLineCL-Module.sln 0.0.0.32 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Media-Viewer-Module \Media-Viewer-Module.sln 0.0.1.118 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ FileResourceModule \FileResourceModule.sln 0.0.0.76 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ FileSystem-Connector-Module \FileSystem-Connector-Module.sln 0.0.0.84 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Scenes-Literatur-Module \Scenes-Literatur-Module.sln 0.0.1.82 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Process-Module \Process-Module.sln 0.2.0.84 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ OutlookConnector-Module \OutlookConnector-Module.sln 0.0.0.95 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Partner-Module \Partner-Module.sln 0.2.0.85 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Report-Module \Report-Module.sln 0.0.1.121 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Appointment-Module \Appointment-Module.sln 0.0.1.88 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Schriftverkehrs-Module \Schriftverkehrs-Module.sln 0.0.0.115 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Bill-Module \Bill-Module.sln 0.0.0.100 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Literaturquellen-Module \LiteraturQuellen-Module.sln 0.0.0.141 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Change-Module \Change-Module.sln 0.0.0.103 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


CALL %USERPROFILE%\Documents\GitHub\OntologyManagement\MSBuild\MSBuild_DebugRelease.cmd %ROOTDIR%\ Checklist-Module \Checklist-Module.sln 0.0.0.131 1 1 0
IF ERRORLEVEL 1 GOTO Fehler


:Fehler
echo package-fehler>%TEMP%\OntologyManagement\Error.txt