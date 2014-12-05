c:\
cd \cygwin64\bin
mkdir %temp%\OModules
del /s /q %temp%\OModules\*.*
del /s /q "%OMODULE_PATH%\Ontolog-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Ontolog-Module_0.3.0.128.exe" -o"%OMODULE_PATH%\Ontolog-Module\"

del /s /q "%OMODULE_PATH%\File-Tagging-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\File-Tagging-Module_0.0.0.42.exe" -o"%OMODULE_PATH%\File-Tagging-Module\"

del /s /q "%OMODULE_PATH%\Security-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Security-Module_0.2.0.40.exe" -o"%OMODULE_PATH%\Security-Module\"

del /s /q "%OMODULE_PATH%\PortListenerForText-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\PortListenerForText-Module_0.0.0.12.exe" -o"%OMODULE_PATH%\PortListenerForText-Module\"

del /s /q "%OMODULE_PATH%\ElasticSearchConfig-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\ElasticSearchConfig-Module_0.0.0.40.exe" -o"%OMODULE_PATH%\ElasticSearchConfig-Module\"

del /s /q "%OMODULE_PATH%\ModuleLibrary\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\ModuleLibrary_0.0.0.47.exe" -o"%OMODULE_PATH%\ModuleLibrary\"

del /s /q "%OMODULE_PATH%\Variable-Value-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Variable-Value-Module_0.0.0.35.exe" -o"%OMODULE_PATH%\Variable-Value-Module\"

del /s /q "%OMODULE_PATH%\RDF-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\RDF-Module_0.0.0.75.exe" -o"%OMODULE_PATH%\RDF-Module\"

del /s /q "%OMODULE_PATH%\Localization-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Localization-Module_0.0.1.41.exe" -o"%OMODULE_PATH%\Localization-Module\"

del /s /q "%OMODULE_PATH%\Formale-Begriffsanalyse-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Formale-Begriffsanalyse-Module_0.0.0.41.exe" -o"%OMODULE_PATH%\Formale-Begriffsanalyse-Module\"

del /s /q "%OMODULE_PATH%\ClipBoardListener-Url-Connector\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\ClipBoardListener-Url-Connector_0.0.0.43.exe" -o"%OMODULE_PATH%\ClipBoardListener-Url-Connector\"

del /s /q "%OMODULE_PATH%\GraphMLConnector\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\GraphMLConnector_0.0.0.85.exe" -o"%OMODULE_PATH%\GraphMLConnector\"

del /s /q "%OMODULE_PATH%\Hierarchichal-Splitter-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Hierarchichal-Splitter-Module_0.0.0.45.exe" -o"%OMODULE_PATH%\Hierarchichal-Splitter-Module\"

del /s /q "%OMODULE_PATH%\CommandLineRun-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\CommandLineRun-Module_0.0.0.33.exe" -o"%OMODULE_PATH%\CommandLineRun-Module\"

del /s /q "%OMODULE_PATH%\Ping-Test-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Ping-Test-Module_0.0.0.37.exe" -o"%OMODULE_PATH%\Ping-Test-Module\"

del /s /q "%OMODULE_PATH%\Log-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Log-Module_0.2.0.48.exe" -o"%OMODULE_PATH%\Log-Module\"

del /s /q "%OMODULE_PATH%\Database-Configuration-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Database-Configuration-Module_0.0.0.8.exe" -o"%OMODULE_PATH%\Database-Configuration-Module\"

del /s /q "%OMODULE_PATH%\TimeManagement-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\TimeManagement-Module_0.0.0.83.exe" -o"%OMODULE_PATH%\TimeManagement-Module\"

del /s /q "%OMODULE_PATH%\CommandLineCL-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\CommandLineCL-Module_0.0.0.26.exe" -o"%OMODULE_PATH%\CommandLineCL-Module\"

del /s /q "%OMODULE_PATH%\ElasticSearchLogging-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\ElasticSearchLogging-Module_0.0.0.42.exe" -o"%OMODULE_PATH%\ElasticSearchLogging-Module\"

del /s /q "%OMODULE_PATH%\Version-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Version-Module_0.0.1.50.exe" -o"%OMODULE_PATH%\Version-Module\"

del /s /q "%OMODULE_PATH%\Filesystem-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Filesystem-Module_0.2.0.79.exe" -o"%OMODULE_PATH%\Filesystem-Module\"

del /s /q "%OMODULE_PATH%\Manual-Repair-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Manual-Repair-Module_0.0.0.35.exe" -o"%OMODULE_PATH%\Manual-Repair-Module\"

del /s /q "%OMODULE_PATH%\HTMLExport-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\HTMLExport-Module_0.0.0.78.exe" -o"%OMODULE_PATH%\HTMLExport-Module\"

del /s /q "%OMODULE_PATH%\TextParser\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\TextParser_0.0.0.88.exe" -o"%OMODULE_PATH%\TextParser\"

del /s /q "%OMODULE_PATH%\Office-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Office-Module_0.0.1.57.exe" -o"%OMODULE_PATH%\Office-Module\"

del /s /q "%OMODULE_PATH%\Typed-Tagging-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Typed-Tagging-Module_0.0.0.72.exe" -o"%OMODULE_PATH%\Typed-Tagging-Module\"

del /s /q "%OMODULE_PATH%\AudioPlayer-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\AudioPlayer-Module_0.0.0.58.exe" -o"%OMODULE_PATH%\AudioPlayer-Module\"

del /s /q "%OMODULE_PATH%\BankTransaction-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\BankTransaction-Module_0.0.1.59.exe" -o"%OMODULE_PATH%\BankTransaction-Module\"

del /s /q "%OMODULE_PATH%\Development-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Development-Module_0.2.0.109.exe" -o"%OMODULE_PATH%\Development-Module\"

del /s /q "%OMODULE_PATH%\Media-Viewer-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Media-Viewer-Module_0.0.1.111.exe" -o"%OMODULE_PATH%\Media-Viewer-Module\"

del /s /q "%OMODULE_PATH%\FileResourceModule\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\FileResourceModule_0.0.0.67.exe" -o"%OMODULE_PATH%\FileResourceModule\"

del /s /q "%OMODULE_PATH%\FileSystem-Connector-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\FileSystem-Connector-Module_0.0.0.77.exe" -o"%OMODULE_PATH%\FileSystem-Connector-Module\"

del /s /q "%OMODULE_PATH%\Scenes-Literatur-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Scenes-Literatur-Module_0.0.1.74.exe" -o"%OMODULE_PATH%\Scenes-Literatur-Module\"

del /s /q "%OMODULE_PATH%\Process-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Process-Module_0.2.0.75.exe" -o"%OMODULE_PATH%\Process-Module\"

del /s /q "%OMODULE_PATH%\OutlookConnector-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\OutlookConnector-Module_0.0.0.88.exe" -o"%OMODULE_PATH%\OutlookConnector-Module\"

del /s /q "%OMODULE_PATH%\Partner-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Partner-Module_0.2.0.78.exe" -o"%OMODULE_PATH%\Partner-Module\"

del /s /q "%OMODULE_PATH%\Report-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Report-Module_0.0.1.105.exe" -o"%OMODULE_PATH%\Report-Module\"

del /s /q "%OMODULE_PATH%\Appointment-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Appointment-Module_0.0.1.81.exe" -o"%OMODULE_PATH%\Appointment-Module\"

del /s /q "%OMODULE_PATH%\Schriftverkehrs-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Schriftverkehrs-Module_0.0.0.100.exe" -o"%OMODULE_PATH%\Schriftverkehrs-Module\"

del /s /q "%OMODULE_PATH%\Bill-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Bill-Module_0.0.0.91.exe" -o"%OMODULE_PATH%\Bill-Module\"

del /s /q "%OMODULE_PATH%\LiteraturQuellen-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\LiteraturQuellen-Module_0.0.0.133.exe" -o"%OMODULE_PATH%\LiteraturQuellen-Module\"

del /s /q "%OMODULE_PATH%\Change-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Change-Module_0.0.0.94.exe" -o"%OMODULE_PATH%\Change-Module\"

del /s /q "%OMODULE_PATH%\Checklist-Module\*.*"
"%PROGRAMFILES%\7-Zip\7z.exe" x "%OMODULE_INST_PATH%\Checklist-Module_0.0.0.113.exe" -o"%OMODULE_PATH%\Checklist-Module\"
