c:\
cd \cygwin64\bin
mkdir %temp%\OModules
del /s /q %temp%\OModules\*.*

if /i [OntologyClasses] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/OntologyClasses
)

del /s /q "%OMODULE_PATH%\OntologyClasses\*.*"

wget -O "%temp%\OModules\OntologyClasses_0.0.1.4.exe" %DOWNLOAD_URL%/OntologyClasses_0.0.1.4.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\OntologyClasses_0.0.1.4.exe" -o"%OMODULE_PATH%\OntologyClasses\"


if /i [Structure-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Structure-Module
)

del /s /q "%OMODULE_PATH%\Structure-Module\*.*"

wget -O "%temp%\OModules\Structure-Module_0.0.1.1.exe" %DOWNLOAD_URL%/Structure-Module_0.0.1.1.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Structure-Module_0.0.1.1.exe" -o"%OMODULE_PATH%\Structure-Module\"


if /i [Grid-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Grid-Module
)

del /s /q "%OMODULE_PATH%\Grid-Module\*.*"

wget -O "%temp%\OModules\Grid-Module_0.0.0.2.exe" %DOWNLOAD_URL%/Grid-Module_0.0.0.2.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Grid-Module_0.0.0.2.exe" -o"%OMODULE_PATH%\Grid-Module\"


if /i [ClassLibrary_ShellWork] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ClassLibrary_ShellWork
)

del /s /q "%OMODULE_PATH%\ClassLibrary_ShellWork\*.*"

wget -O "%temp%\OModules\ClassLibrary_ShellWork_0.1.0.1.exe" %DOWNLOAD_URL%/ClassLibrary_ShellWork_0.1.0.1.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ClassLibrary_ShellWork_0.1.0.1.exe" -o"%OMODULE_PATH%\ClassLibrary_ShellWork\"


if /i [ElasticSearchNestConnector] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ElasticSearchNestConnector
)

del /s /q "%OMODULE_PATH%\ElasticSearchNestConnector\*.*"

wget -O "%temp%\OModules\ElasticSearchNestConnector_0.0.0.44.exe" %DOWNLOAD_URL%/ElasticSearchNestConnector_0.0.0.44.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ElasticSearchNestConnector_0.0.0.44.exe" -o"%OMODULE_PATH%\ElasticSearchNestConnector\"


if /i [ElasticSearchNestConnector] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ElasticSearchNestConnector
)

del /s /q "%OMODULE_PATH%\ElasticSearchNestConnector\*.*"

wget -O "%temp%\OModules\ElasticSearchNestConnector_0.0.0.44.exe" %DOWNLOAD_URL%/ElasticSearchNestConnector_0.0.0.44.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ElasticSearchNestConnector_0.0.0.44.exe" -o"%OMODULE_PATH%\ElasticSearchNestConnector\"


if /i [Ontolog-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Ontolog-Module
)

del /s /q "%OMODULE_PATH%\Ontolog-Module\*.*"

wget -O "%temp%\OModules\Ontolog-Module_0.3.0.130.exe" %DOWNLOAD_URL%/Ontolog-Module_0.3.0.130.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Ontolog-Module_0.3.0.130.exe" -o"%OMODULE_PATH%\Ontolog-Module\"


if /i [File-Tagging-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/File-Tagging-Module
)

del /s /q "%OMODULE_PATH%\File-Tagging-Module\*.*"

wget -O "%temp%\OModules\File-Tagging-Module_0.0.0.44.exe" %DOWNLOAD_URL%/File-Tagging-Module_0.0.0.44.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\File-Tagging-Module_0.0.0.44.exe" -o"%OMODULE_PATH%\File-Tagging-Module\"


if /i [Security-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Security-Module
)

del /s /q "%OMODULE_PATH%\Security-Module\*.*"

wget -O "%temp%\OModules\Security-Module_0.2.0.42.exe" %DOWNLOAD_URL%/Security-Module_0.2.0.42.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Security-Module_0.2.0.42.exe" -o"%OMODULE_PATH%\Security-Module\"


if /i [PortListenerForText-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/PortListenerForText-Module
)

del /s /q "%OMODULE_PATH%\PortListenerForText-Module\*.*"

wget -O "%temp%\OModules\PortListenerForText-Module_0.0.0.14.exe" %DOWNLOAD_URL%/PortListenerForText-Module_0.0.0.14.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\PortListenerForText-Module_0.0.0.14.exe" -o"%OMODULE_PATH%\PortListenerForText-Module\"


if /i [ElasticSearchConfig-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ElasticSearchConfig-Module
)

del /s /q "%OMODULE_PATH%\ElasticSearchConfig-Module\*.*"

wget -O "%temp%\OModules\ElasticSearchConfig-Module_0.0.0.42.exe" %DOWNLOAD_URL%/ElasticSearchConfig-Module_0.0.0.42.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ElasticSearchConfig-Module_0.0.0.42.exe" -o"%OMODULE_PATH%\ElasticSearchConfig-Module\"


if /i [ModuleLibrary] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ModuleLibrary
)

del /s /q "%OMODULE_PATH%\ModuleLibrary\*.*"

wget -O "%temp%\OModules\ModuleLibrary_0.0.0.49.exe" %DOWNLOAD_URL%/ModuleLibrary_0.0.0.49.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ModuleLibrary_0.0.0.49.exe" -o"%OMODULE_PATH%\ModuleLibrary\"


if /i [Variable-Value-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Variable-Value-Module
)

del /s /q "%OMODULE_PATH%\Variable-Value-Module\*.*"

wget -O "%temp%\OModules\Variable-Value-Module_0.0.0.38.exe" %DOWNLOAD_URL%/Variable-Value-Module_0.0.0.38.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Variable-Value-Module_0.0.0.38.exe" -o"%OMODULE_PATH%\Variable-Value-Module\"


if /i [RDF-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/RDF-Module
)

del /s /q "%OMODULE_PATH%\RDF-Module\*.*"

wget -O "%temp%\OModules\RDF-Module_0.0.0.77.exe" %DOWNLOAD_URL%/RDF-Module_0.0.0.77.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\RDF-Module_0.0.0.77.exe" -o"%OMODULE_PATH%\RDF-Module\"


if /i [Localization-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Localization-Module
)

del /s /q "%OMODULE_PATH%\Localization-Module\*.*"

wget -O "%temp%\OModules\Localization-Module_0.0.1.43.exe" %DOWNLOAD_URL%/Localization-Module_0.0.1.43.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Localization-Module_0.0.1.43.exe" -o"%OMODULE_PATH%\Localization-Module\"


if /i [Formale-Begriffsanalyse-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Formale-Begriffsanalyse-Module
)

del /s /q "%OMODULE_PATH%\Formale-Begriffsanalyse-Module\*.*"

wget -O "%temp%\OModules\Formale-Begriffsanalyse-Module_0.0.0.43.exe" %DOWNLOAD_URL%/Formale-Begriffsanalyse-Module_0.0.0.43.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Formale-Begriffsanalyse-Module_0.0.0.43.exe" -o"%OMODULE_PATH%\Formale-Begriffsanalyse-Module\"


if /i [ClipBoardListener-Url-Connector] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ClipBoardListener-Url-Connector
)

del /s /q "%OMODULE_PATH%\ClipBoardListener-Url-Connector\*.*"

wget -O "%temp%\OModules\ClipBoardListener-Url-Connector_0.0.0.45.exe" %DOWNLOAD_URL%/ClipBoardListener-Url-Connector_0.0.0.45.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ClipBoardListener-Url-Connector_0.0.0.45.exe" -o"%OMODULE_PATH%\ClipBoardListener-Url-Connector\"


if /i [GraphMLConnector] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/GraphMLConnector
)

del /s /q "%OMODULE_PATH%\GraphMLConnector\*.*"

wget -O "%temp%\OModules\GraphMLConnector_0.0.0.87.exe" %DOWNLOAD_URL%/GraphMLConnector_0.0.0.87.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\GraphMLConnector_0.0.0.87.exe" -o"%OMODULE_PATH%\GraphMLConnector\"


if /i [Hierarchichal-Splitter-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Hierarchichal-Splitter-Module
)

del /s /q "%OMODULE_PATH%\Hierarchichal-Splitter-Module\*.*"

wget -O "%temp%\OModules\Hierarchichal-Splitter-Module_0.0.0.47.exe" %DOWNLOAD_URL%/Hierarchichal-Splitter-Module_0.0.0.47.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Hierarchichal-Splitter-Module_0.0.0.47.exe" -o"%OMODULE_PATH%\Hierarchichal-Splitter-Module\"


if /i [CommandLineRun-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/CommandLineRun-Module
)

del /s /q "%OMODULE_PATH%\CommandLineRun-Module\*.*"

wget -O "%temp%\OModules\CommandLineRun-Module_0.0.0.35.exe" %DOWNLOAD_URL%/CommandLineRun-Module_0.0.0.35.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\CommandLineRun-Module_0.0.0.35.exe" -o"%OMODULE_PATH%\CommandLineRun-Module\"


if /i [Ping-Test-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Ping-Test-Module
)

del /s /q "%OMODULE_PATH%\Ping-Test-Module\*.*"

wget -O "%temp%\OModules\Ping-Test-Module_0.0.0.39.exe" %DOWNLOAD_URL%/Ping-Test-Module_0.0.0.39.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Ping-Test-Module_0.0.0.39.exe" -o"%OMODULE_PATH%\Ping-Test-Module\"


if /i [Log-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Log-Module
)

del /s /q "%OMODULE_PATH%\Log-Module\*.*"

wget -O "%temp%\OModules\Log-Module_0.2.0.50.exe" %DOWNLOAD_URL%/Log-Module_0.2.0.50.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Log-Module_0.2.0.50.exe" -o"%OMODULE_PATH%\Log-Module\"


if /i [Database-Configuration-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Database-Configuration-Module
)

del /s /q "%OMODULE_PATH%\Database-Configuration-Module\*.*"

wget -O "%temp%\OModules\Database-Configuration-Module_0.0.0.13.exe" %DOWNLOAD_URL%/Database-Configuration-Module_0.0.0.13.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Database-Configuration-Module_0.0.0.13.exe" -o"%OMODULE_PATH%\Database-Configuration-Module\"


if /i [TimeManagement-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/TimeManagement-Module
)

del /s /q "%OMODULE_PATH%\TimeManagement-Module\*.*"

wget -O "%temp%\OModules\TimeManagement-Module_0.0.0.86.exe" %DOWNLOAD_URL%/TimeManagement-Module_0.0.0.86.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\TimeManagement-Module_0.0.0.86.exe" -o"%OMODULE_PATH%\TimeManagement-Module\"


if /i [CommandLineCL-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/CommandLineCL-Module
)

del /s /q "%OMODULE_PATH%\CommandLineCL-Module\*.*"

wget -O "%temp%\OModules\CommandLineCL-Module_0.0.0.28.exe" %DOWNLOAD_URL%/CommandLineCL-Module_0.0.0.28.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\CommandLineCL-Module_0.0.0.28.exe" -o"%OMODULE_PATH%\CommandLineCL-Module\"


if /i [ElasticSearchLogging-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ElasticSearchLogging-Module
)

del /s /q "%OMODULE_PATH%\ElasticSearchLogging-Module\*.*"

wget -O "%temp%\OModules\ElasticSearchLogging-Module_0.0.0.44.exe" %DOWNLOAD_URL%/ElasticSearchLogging-Module_0.0.0.44.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ElasticSearchLogging-Module_0.0.0.44.exe" -o"%OMODULE_PATH%\ElasticSearchLogging-Module\"


if /i [Version-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Version-Module
)

del /s /q "%OMODULE_PATH%\Version-Module\*.*"

wget -O "%temp%\OModules\Version-Module_0.0.1.52.exe" %DOWNLOAD_URL%/Version-Module_0.0.1.52.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Version-Module_0.0.1.52.exe" -o"%OMODULE_PATH%\Version-Module\"


if /i [Filesystem-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Filesystem-Module
)

del /s /q "%OMODULE_PATH%\Filesystem-Module\*.*"

wget -O "%temp%\OModules\Filesystem-Module_0.2.0.82.exe" %DOWNLOAD_URL%/Filesystem-Module_0.2.0.82.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Filesystem-Module_0.2.0.82.exe" -o"%OMODULE_PATH%\Filesystem-Module\"


if /i [Manual-Repair-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Manual-Repair-Module
)

del /s /q "%OMODULE_PATH%\Manual-Repair-Module\*.*"

wget -O "%temp%\OModules\Manual-Repair-Module_0.0.0.37.exe" %DOWNLOAD_URL%/Manual-Repair-Module_0.0.0.37.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Manual-Repair-Module_0.0.0.37.exe" -o"%OMODULE_PATH%\Manual-Repair-Module\"


if /i [HTMLExport-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/HTMLExport-Module
)

del /s /q "%OMODULE_PATH%\HTMLExport-Module\*.*"

wget -O "%temp%\OModules\HTMLExport-Module_0.0.0.81.exe" %DOWNLOAD_URL%/HTMLExport-Module_0.0.0.81.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\HTMLExport-Module_0.0.0.81.exe" -o"%OMODULE_PATH%\HTMLExport-Module\"


if /i [TextParser] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/TextParser
)

del /s /q "%OMODULE_PATH%\TextParser\*.*"

wget -O "%temp%\OModules\TextParser_0.0.0.94.exe" %DOWNLOAD_URL%/TextParser_0.0.0.94.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\TextParser_0.0.0.94.exe" -o"%OMODULE_PATH%\TextParser\"


if /i [Office-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Office-Module
)

del /s /q "%OMODULE_PATH%\Office-Module\*.*"

wget -O "%temp%\OModules\Office-Module_0.0.1.60.exe" %DOWNLOAD_URL%/Office-Module_0.0.1.60.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Office-Module_0.0.1.60.exe" -o"%OMODULE_PATH%\Office-Module\"


if /i [Typed-Tagging-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Typed-Tagging-Module
)

del /s /q "%OMODULE_PATH%\Typed-Tagging-Module\*.*"

wget -O "%temp%\OModules\Typed-Tagging-Module_0.0.0.75.exe" %DOWNLOAD_URL%/Typed-Tagging-Module_0.0.0.75.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Typed-Tagging-Module_0.0.0.75.exe" -o"%OMODULE_PATH%\Typed-Tagging-Module\"


if /i [AudioPlayer-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/AudioPlayer-Module
)

del /s /q "%OMODULE_PATH%\AudioPlayer-Module\*.*"

wget -O "%temp%\OModules\AudioPlayer-Module_0.0.0.61.exe" %DOWNLOAD_URL%/AudioPlayer-Module_0.0.0.61.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\AudioPlayer-Module_0.0.0.61.exe" -o"%OMODULE_PATH%\AudioPlayer-Module\"


if /i [BankTransaction-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/BankTransaction-Module
)

del /s /q "%OMODULE_PATH%\BankTransaction-Module\*.*"

wget -O "%temp%\OModules\BankTransaction-Module_0.0.1.62.exe" %DOWNLOAD_URL%/BankTransaction-Module_0.0.1.62.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\BankTransaction-Module_0.0.1.62.exe" -o"%OMODULE_PATH%\BankTransaction-Module\"


if /i [Development-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Development-Module
)

del /s /q "%OMODULE_PATH%\Development-Module\*.*"

wget -O "%temp%\OModules\Development-Module_0.2.0.115.exe" %DOWNLOAD_URL%/Development-Module_0.2.0.115.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Development-Module_0.2.0.115.exe" -o"%OMODULE_PATH%\Development-Module\"


if /i [Media-Viewer-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Media-Viewer-Module
)

del /s /q "%OMODULE_PATH%\Media-Viewer-Module\*.*"

wget -O "%temp%\OModules\Media-Viewer-Module_0.0.1.114.exe" %DOWNLOAD_URL%/Media-Viewer-Module_0.0.1.114.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Media-Viewer-Module_0.0.1.114.exe" -o"%OMODULE_PATH%\Media-Viewer-Module\"


if /i [FileResourceModule] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/FileResourceModule
)

del /s /q "%OMODULE_PATH%\FileResourceModule\*.*"

wget -O "%temp%\OModules\FileResourceModule_0.0.0.73.exe" %DOWNLOAD_URL%/FileResourceModule_0.0.0.73.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\FileResourceModule_0.0.0.73.exe" -o"%OMODULE_PATH%\FileResourceModule\"


if /i [FileSystem-Connector-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/FileSystem-Connector-Module
)

del /s /q "%OMODULE_PATH%\FileSystem-Connector-Module\*.*"

wget -O "%temp%\OModules\FileSystem-Connector-Module_0.0.0.80.exe" %DOWNLOAD_URL%/FileSystem-Connector-Module_0.0.0.80.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\FileSystem-Connector-Module_0.0.0.80.exe" -o"%OMODULE_PATH%\FileSystem-Connector-Module\"


if /i [Scenes-Literatur-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Scenes-Literatur-Module
)

del /s /q "%OMODULE_PATH%\Scenes-Literatur-Module\*.*"

wget -O "%temp%\OModules\Scenes-Literatur-Module_0.0.1.77.exe" %DOWNLOAD_URL%/Scenes-Literatur-Module_0.0.1.77.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Scenes-Literatur-Module_0.0.1.77.exe" -o"%OMODULE_PATH%\Scenes-Literatur-Module\"


if /i [Process-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Process-Module
)

del /s /q "%OMODULE_PATH%\Process-Module\*.*"

wget -O "%temp%\OModules\Process-Module_0.2.0.78.exe" %DOWNLOAD_URL%/Process-Module_0.2.0.78.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Process-Module_0.2.0.78.exe" -o"%OMODULE_PATH%\Process-Module\"


if /i [OutlookConnector-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/OutlookConnector-Module
)

del /s /q "%OMODULE_PATH%\OutlookConnector-Module\*.*"

wget -O "%temp%\OModules\OutlookConnector-Module_0.0.0.91.exe" %DOWNLOAD_URL%/OutlookConnector-Module_0.0.0.91.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\OutlookConnector-Module_0.0.0.91.exe" -o"%OMODULE_PATH%\OutlookConnector-Module\"


if /i [Partner-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Partner-Module
)

del /s /q "%OMODULE_PATH%\Partner-Module\*.*"

wget -O "%temp%\OModules\Partner-Module_0.2.0.81.exe" %DOWNLOAD_URL%/Partner-Module_0.2.0.81.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Partner-Module_0.2.0.81.exe" -o"%OMODULE_PATH%\Partner-Module\"


if /i [Report-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Report-Module
)

del /s /q "%OMODULE_PATH%\Report-Module\*.*"

wget -O "%temp%\OModules\Report-Module_0.0.1.109.exe" %DOWNLOAD_URL%/Report-Module_0.0.1.109.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Report-Module_0.0.1.109.exe" -o"%OMODULE_PATH%\Report-Module\"


if /i [Appointment-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Appointment-Module
)

del /s /q "%OMODULE_PATH%\Appointment-Module\*.*"

wget -O "%temp%\OModules\Appointment-Module_0.0.1.84.exe" %DOWNLOAD_URL%/Appointment-Module_0.0.1.84.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Appointment-Module_0.0.1.84.exe" -o"%OMODULE_PATH%\Appointment-Module\"


if /i [Schriftverkehrs-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Schriftverkehrs-Module
)

del /s /q "%OMODULE_PATH%\Schriftverkehrs-Module\*.*"

wget -O "%temp%\OModules\Schriftverkehrs-Module_0.0.0.104.exe" %DOWNLOAD_URL%/Schriftverkehrs-Module_0.0.0.104.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Schriftverkehrs-Module_0.0.0.104.exe" -o"%OMODULE_PATH%\Schriftverkehrs-Module\"


if /i [Bill-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Bill-Module
)

del /s /q "%OMODULE_PATH%\Bill-Module\*.*"

wget -O "%temp%\OModules\Bill-Module_0.0.0.94.exe" %DOWNLOAD_URL%/Bill-Module_0.0.0.94.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Bill-Module_0.0.0.94.exe" -o"%OMODULE_PATH%\Bill-Module\"


if /i [LiteraturQuellen-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/LiteraturQuellen-Module
)

del /s /q "%OMODULE_PATH%\LiteraturQuellen-Module\*.*"

wget -O "%temp%\OModules\LiteraturQuellen-Module_0.0.0.136.exe" %DOWNLOAD_URL%/LiteraturQuellen-Module_0.0.0.136.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\LiteraturQuellen-Module_0.0.0.136.exe" -o"%OMODULE_PATH%\LiteraturQuellen-Module\"


if /i [Change-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Change-Module
)

del /s /q "%OMODULE_PATH%\Change-Module\*.*"

wget -O "%temp%\OModules\Change-Module_0.0.0.97.exe" %DOWNLOAD_URL%/Change-Module_0.0.0.97.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Change-Module_0.0.0.97.exe" -o"%OMODULE_PATH%\Change-Module\"


if /i [Checklist-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Checklist-Module
)

del /s /q "%OMODULE_PATH%\Checklist-Module\*.*"

wget -O "%temp%\OModules\Checklist-Module_0.0.0.117.exe" %DOWNLOAD_URL%/Checklist-Module_0.0.0.117.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Checklist-Module_0.0.0.117.exe" -o"%OMODULE_PATH%\Checklist-Module\"
