c:\
cd \cygwin64\bin
mkdir %temp%\OModules
del /s /q %temp%\OModules\*.*
del /s /q %OMODULE_PATH%\*.*

if /i [Development-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Development-Module
)

wget -O "%temp%\OModules\Development-Module_0.2.0.90.exe" %DOWNLOAD_URL%/Development-Module_0.2.0.90.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Development-Module_0.2.0.90.exe" -o"%OMODULE_PATH%\Development-Module\"


if /i [Version-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Version-Module
)

wget -O "%temp%\OModules\Version-Module_0.0.1.36.exe" %DOWNLOAD_URL%/Version-Module_0.0.1.36.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Version-Module_0.0.1.36.exe" -o"%OMODULE_PATH%\Version-Module\"


if /i [Log-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Log-Module
)

wget -O "%temp%\OModules\Log-Module_0.2.0.39.exe" %DOWNLOAD_URL%/Log-Module_0.2.0.39.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Log-Module_0.2.0.39.exe" -o"%OMODULE_PATH%\Log-Module\"


if /i [File-Tagging-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/File-Tagging-Module
)

wget -O "%temp%\OModules\File-Tagging-Module_0.0.0.34.exe" %DOWNLOAD_URL%/File-Tagging-Module_0.0.0.34.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\File-Tagging-Module_0.0.0.34.exe" -o"%OMODULE_PATH%\File-Tagging-Module\"


if /i [Security-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Security-Module
)

wget -O "%temp%\OModules\Security-Module_0.2.0.32.exe" %DOWNLOAD_URL%/Security-Module_0.2.0.32.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Security-Module_0.2.0.32.exe" -o"%OMODULE_PATH%\Security-Module\"


if /i [HTMLExport-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/HTMLExport-Module
)

wget -O "%temp%\OModules\HTMLExport-Module_0.0.0.69.exe" %DOWNLOAD_URL%/HTMLExport-Module_0.0.0.69.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\HTMLExport-Module_0.0.0.69.exe" -o"%OMODULE_PATH%\HTMLExport-Module\"


if /i [PortListenerForText-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/PortListenerForText-Module
)

wget -O "%temp%\OModules\PortListenerForText-Module_0.0.0.4.exe" %DOWNLOAD_URL%/PortListenerForText-Module_0.0.0.4.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\PortListenerForText-Module_0.0.0.4.exe" -o"%OMODULE_PATH%\PortListenerForText-Module\"


if /i [OntologyClasses] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/OntologyClasses
)

wget -O "%temp%\OModules\OntologyClasses_0.0.1.4.exe" %DOWNLOAD_URL%/OntologyClasses_0.0.1.4.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\OntologyClasses_0.0.1.4.exe" -o"%OMODULE_PATH%\OntologyClasses\"


if /i [FileSystem-Connector-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/FileSystem-Connector-Module
)

wget -O "%temp%\OModules\FileSystem-Connector-Module_0.0.0.64.exe" %DOWNLOAD_URL%/FileSystem-Connector-Module_0.0.0.64.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\FileSystem-Connector-Module_0.0.0.64.exe" -o"%OMODULE_PATH%\FileSystem-Connector-Module\"


if /i [ElasticSearchConfig-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ElasticSearchConfig-Module
)

wget -O "%temp%\OModules\ElasticSearchConfig-Module_0.0.0.30.exe" %DOWNLOAD_URL%/ElasticSearchConfig-Module_0.0.0.30.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ElasticSearchConfig-Module_0.0.0.30.exe" -o"%OMODULE_PATH%\ElasticSearchConfig-Module\"


if /i [ModuleLibrary] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ModuleLibrary
)

wget -O "%temp%\OModules\ModuleLibrary_0.0.0.39.exe" %DOWNLOAD_URL%/ModuleLibrary_0.0.0.39.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ModuleLibrary_0.0.0.39.exe" -o"%OMODULE_PATH%\ModuleLibrary\"


if /i [Scenes-Literatur-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Scenes-Literatur-Module
)

wget -O "%temp%\OModules\Scenes-Literatur-Module_0.0.1.63.exe" %DOWNLOAD_URL%/Scenes-Literatur-Module_0.0.1.63.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Scenes-Literatur-Module_0.0.1.63.exe" -o"%OMODULE_PATH%\Scenes-Literatur-Module\"


if /i [Variable-Value-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Variable-Value-Module
)

wget -O "%temp%\OModules\Variable-Value-Module_0.0.0.28.exe" %DOWNLOAD_URL%/Variable-Value-Module_0.0.0.28.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Variable-Value-Module_0.0.0.28.exe" -o"%OMODULE_PATH%\Variable-Value-Module\"


if /i [Filesystem-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Filesystem-Module
)

wget -O "%temp%\OModules\Filesystem-Module_0.2.0.70.exe" %DOWNLOAD_URL%/Filesystem-Module_0.2.0.70.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Filesystem-Module_0.2.0.70.exe" -o"%OMODULE_PATH%\Filesystem-Module\"


if /i [Appointment-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Appointment-Module
)

wget -O "%temp%\OModules\Appointment-Module_0.0.1.67.exe" %DOWNLOAD_URL%/Appointment-Module_0.0.1.67.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Appointment-Module_0.0.1.67.exe" -o"%OMODULE_PATH%\Appointment-Module\"


if /i [TextParser] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/TextParser
)

wget -O "%temp%\OModules\TextParser_0.0.0.77.exe" %DOWNLOAD_URL%/TextParser_0.0.0.77.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\TextParser_0.0.0.77.exe" -o"%OMODULE_PATH%\TextParser\"


if /i [RDF-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/RDF-Module
)

wget -O "%temp%\OModules\RDF-Module_0.0.0.67.exe" %DOWNLOAD_URL%/RDF-Module_0.0.0.67.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\RDF-Module_0.0.0.67.exe" -o"%OMODULE_PATH%\RDF-Module\"


if /i [Process-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Process-Module
)

wget -O "%temp%\OModules\Process-Module_0.2.0.64.exe" %DOWNLOAD_URL%/Process-Module_0.2.0.64.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Process-Module_0.2.0.64.exe" -o"%OMODULE_PATH%\Process-Module\"


if /i [Structure-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Structure-Module
)

wget -O "%temp%\OModules\Structure-Module_0.0.1.1.exe" %DOWNLOAD_URL%/Structure-Module_0.0.1.1.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Structure-Module_0.0.1.1.exe" -o"%OMODULE_PATH%\Structure-Module\"


if /i [Localization-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Localization-Module
)

wget -O "%temp%\OModules\Localization-Module_0.0.1.33.exe" %DOWNLOAD_URL%/Localization-Module_0.0.1.33.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Localization-Module_0.0.1.33.exe" -o"%OMODULE_PATH%\Localization-Module\"


if /i [Formale-Begriffsanalyse-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Formale-Begriffsanalyse-Module
)

wget -O "%temp%\OModules\Formale-Begriffsanalyse-Module_0.0.0.27.exe" %DOWNLOAD_URL%/Formale-Begriffsanalyse-Module_0.0.0.27.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Formale-Begriffsanalyse-Module_0.0.0.27.exe" -o"%OMODULE_PATH%\Formale-Begriffsanalyse-Module\"


if /i [ClipBoardListener-Url-Connector] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ClipBoardListener-Url-Connector
)

wget -O "%temp%\OModules\ClipBoardListener-Url-Connector_0.0.0.33.exe" %DOWNLOAD_URL%/ClipBoardListener-Url-Connector_0.0.0.33.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ClipBoardListener-Url-Connector_0.0.0.33.exe" -o"%OMODULE_PATH%\ClipBoardListener-Url-Connector\"


if /i [Grid-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Grid-Module
)

wget -O "%temp%\OModules\Grid-Module_0.0.0.2.exe" %DOWNLOAD_URL%/Grid-Module_0.0.0.2.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Grid-Module_0.0.0.2.exe" -o"%OMODULE_PATH%\Grid-Module\"


if /i [Schriftverkehrs-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Schriftverkehrs-Module
)

wget -O "%temp%\OModules\Schriftverkehrs-Module_0.0.0.76.exe" %DOWNLOAD_URL%/Schriftverkehrs-Module_0.0.0.76.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Schriftverkehrs-Module_0.0.0.76.exe" -o"%OMODULE_PATH%\Schriftverkehrs-Module\"


if /i [TimeManagement-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/TimeManagement-Module
)

wget -O "%temp%\OModules\TimeManagement-Module_0.0.0.75.exe" %DOWNLOAD_URL%/TimeManagement-Module_0.0.0.75.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\TimeManagement-Module_0.0.0.75.exe" -o"%OMODULE_PATH%\TimeManagement-Module\"


if /i [Checklist-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Checklist-Module
)

wget -O "%temp%\OModules\Checklist-Module_0.0.0.86.exe" %DOWNLOAD_URL%/Checklist-Module_0.0.0.86.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Checklist-Module_0.0.0.86.exe" -o"%OMODULE_PATH%\Checklist-Module\"


if /i [OutlookConnector-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/OutlookConnector-Module
)

wget -O "%temp%\OModules\OutlookConnector-Module_0.0.0.77.exe" %DOWNLOAD_URL%/OutlookConnector-Module_0.0.0.77.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\OutlookConnector-Module_0.0.0.77.exe" -o"%OMODULE_PATH%\OutlookConnector-Module\"


if /i [ClassLibrary_ShellWork] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ClassLibrary_ShellWork
)

wget -O "%temp%\OModules\ClassLibrary_ShellWork_0.1.0.1.exe" %DOWNLOAD_URL%/ClassLibrary_ShellWork_0.1.0.1.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ClassLibrary_ShellWork_0.1.0.1.exe" -o"%OMODULE_PATH%\ClassLibrary_ShellWork\"


if /i [Office-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Office-Module
)

wget -O "%temp%\OModules\Office-Module_0.0.1.48.exe" %DOWNLOAD_URL%/Office-Module_0.0.1.48.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Office-Module_0.0.1.48.exe" -o"%OMODULE_PATH%\Office-Module\"


if /i [Bill-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Bill-Module
)

wget -O "%temp%\OModules\Bill-Module_0.0.0.76.exe" %DOWNLOAD_URL%/Bill-Module_0.0.0.76.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Bill-Module_0.0.0.76.exe" -o"%OMODULE_PATH%\Bill-Module\"


if /i [CommandLineCL-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/CommandLineCL-Module
)

wget -O "%temp%\OModules\CommandLineCL-Module_0.0.0.8.exe" %DOWNLOAD_URL%/CommandLineCL-Module_0.0.0.8.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\CommandLineCL-Module_0.0.0.8.exe" -o"%OMODULE_PATH%\CommandLineCL-Module\"


if /i [Manual-Repair-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Manual-Repair-Module
)

wget -O "%temp%\OModules\Manual-Repair-Module_0.0.0.27.exe" %DOWNLOAD_URL%/Manual-Repair-Module_0.0.0.27.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Manual-Repair-Module_0.0.0.27.exe" -o"%OMODULE_PATH%\Manual-Repair-Module\"


if /i [Media-Viewer-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Media-Viewer-Module
)

wget -O "%temp%\OModules\Media-Viewer-Module_0.0.1.100.exe" %DOWNLOAD_URL%/Media-Viewer-Module_0.0.1.100.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Media-Viewer-Module_0.0.1.100.exe" -o"%OMODULE_PATH%\Media-Viewer-Module\"


if /i [Partner-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Partner-Module
)

wget -O "%temp%\OModules\Partner-Module_0.2.0.67.exe" %DOWNLOAD_URL%/Partner-Module_0.2.0.67.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Partner-Module_0.2.0.67.exe" -o"%OMODULE_PATH%\Partner-Module\"


if /i [ElasticSearchNestConnector] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ElasticSearchNestConnector
)

wget -O "%temp%\OModules\ElasticSearchNestConnector_0.0.0.44.exe" %DOWNLOAD_URL%/ElasticSearchNestConnector_0.0.0.44.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ElasticSearchNestConnector_0.0.0.44.exe" -o"%OMODULE_PATH%\ElasticSearchNestConnector\"


if /i [LiteraturQuellen-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/LiteraturQuellen-Module
)

wget -O "%temp%\OModules\LiteraturQuellen-Module_0.0.0.122.exe" %DOWNLOAD_URL%/LiteraturQuellen-Module_0.0.0.122.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\LiteraturQuellen-Module_0.0.0.122.exe" -o"%OMODULE_PATH%\LiteraturQuellen-Module\"


if /i [GraphMLConnector] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/GraphMLConnector
)

wget -O "%temp%\OModules\GraphMLConnector_0.0.0.76.exe" %DOWNLOAD_URL%/GraphMLConnector_0.0.0.76.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\GraphMLConnector_0.0.0.76.exe" -o"%OMODULE_PATH%\GraphMLConnector\"


if /i [Typed-Tagging-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Typed-Tagging-Module
)

wget -O "%temp%\OModules\Typed-Tagging-Module_0.0.0.61.exe" %DOWNLOAD_URL%/Typed-Tagging-Module_0.0.0.61.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Typed-Tagging-Module_0.0.0.61.exe" -o"%OMODULE_PATH%\Typed-Tagging-Module\"


if /i [AudioPlayer-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/AudioPlayer-Module
)

wget -O "%temp%\OModules\AudioPlayer-Module_0.0.0.45.exe" %DOWNLOAD_URL%/AudioPlayer-Module_0.0.0.45.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\AudioPlayer-Module_0.0.0.45.exe" -o"%OMODULE_PATH%\AudioPlayer-Module\"


if /i [Hierarchichal-Splitter-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Hierarchichal-Splitter-Module
)

wget -O "%temp%\OModules\Hierarchichal-Splitter-Module_0.0.0.37.exe" %DOWNLOAD_URL%/Hierarchichal-Splitter-Module_0.0.0.37.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Hierarchichal-Splitter-Module_0.0.0.37.exe" -o"%OMODULE_PATH%\Hierarchichal-Splitter-Module\"


if /i [CommandLineRun-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/CommandLineRun-Module
)

wget -O "%temp%\OModules\CommandLineRun-Module_0.0.0.15.exe" %DOWNLOAD_URL%/CommandLineRun-Module_0.0.0.15.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\CommandLineRun-Module_0.0.0.15.exe" -o"%OMODULE_PATH%\CommandLineRun-Module\"


if /i [BankTransaction-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/BankTransaction-Module
)

wget -O "%temp%\OModules\BankTransaction-Module_0.0.1.47.exe" %DOWNLOAD_URL%/BankTransaction-Module_0.0.1.47.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\BankTransaction-Module_0.0.1.47.exe" -o"%OMODULE_PATH%\BankTransaction-Module\"


if /i [Ping-Test-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Ping-Test-Module
)

wget -O "%temp%\OModules\Ping-Test-Module_0.0.0.29.exe" %DOWNLOAD_URL%/Ping-Test-Module_0.0.0.29.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Ping-Test-Module_0.0.0.29.exe" -o"%OMODULE_PATH%\Ping-Test-Module\"


if /i [FileResourceModule] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/FileResourceModule
)

wget -O "%temp%\OModules\FileResourceModule_0.0.0.54.exe" %DOWNLOAD_URL%/FileResourceModule_0.0.0.54.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\FileResourceModule_0.0.0.54.exe" -o"%OMODULE_PATH%\FileResourceModule\"


if /i [ElasticSearchLogging-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ElasticSearchLogging-Module
)

wget -O "%temp%\OModules\ElasticSearchLogging-Module_0.0.0.32.exe" %DOWNLOAD_URL%/ElasticSearchLogging-Module_0.0.0.32.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ElasticSearchLogging-Module_0.0.0.32.exe" -o"%OMODULE_PATH%\ElasticSearchLogging-Module\"


if /i [Report-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Report-Module
)

wget -O "%temp%\OModules\Report-Module_0.0.1.81.exe" %DOWNLOAD_URL%/Report-Module_0.0.1.81.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Report-Module_0.0.1.81.exe" -o"%OMODULE_PATH%\Report-Module\"


if /i [Change-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Change-Module
)

wget -O "%temp%\OModules\Change-Module_0.2.0.81.exe" %DOWNLOAD_URL%/Change-Module_0.2.0.81.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Change-Module_0.2.0.81.exe" -o"%OMODULE_PATH%\Change-Module\"


if /i [Ontolog-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Ontolog-Module
)

wget -O "%temp%\OModules\Ontolog-Module_0.3.0.116.exe" %DOWNLOAD_URL%/Ontolog-Module_0.3.0.116.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Ontolog-Module_0.3.0.116.exe" -o"%OMODULE_PATH%\Ontolog-Module\"
