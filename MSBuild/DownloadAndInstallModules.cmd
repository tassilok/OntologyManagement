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

wget -O "%temp%\OModules\OntologyClasses_0.0.1.7.exe" %DOWNLOAD_URL%/OntologyClasses_0.0.1.7.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\OntologyClasses_0.0.1.7.exe" -o"%OMODULE_PATH%\OntologyClasses\"


if /i [Structure-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Structure-Module
)

del /s /q "%OMODULE_PATH%\Structure-Module\*.*"

wget -O "%temp%\OModules\Structure-Module_0.0.1.1.exe" %DOWNLOAD_URL%/Structure-Module_0.0.1.1.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Structure-Module_0.0.1.1.exe" -o"%OMODULE_PATH%\Structure-Module\"


if /i [TestAutomation-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/TestAutomation-Module
)

del /s /q "%OMODULE_PATH%\TestAutomation-Module\*.*"

wget -O "%temp%\OModules\TestAutomation-Module_0.0.0.1.exe" %DOWNLOAD_URL%/TestAutomation-Module_0.0.0.1.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\TestAutomation-Module_0.0.0.1.exe" -o"%OMODULE_PATH%\TestAutomation-Module\"


if /i [ClassLibrary_ShellWork] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ClassLibrary_ShellWork
)

del /s /q "%OMODULE_PATH%\ClassLibrary_ShellWork\*.*"

wget -O "%temp%\OModules\ClassLibrary_ShellWork_0.1.0.1.exe" %DOWNLOAD_URL%/ClassLibrary_ShellWork_0.1.0.1.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ClassLibrary_ShellWork_0.1.0.1.exe" -o"%OMODULE_PATH%\ClassLibrary_ShellWork\"


if /i [ClipBoardListener-Url-Connector] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ClipBoardListener-Url-Connector
)

del /s /q "%OMODULE_PATH%\ClipBoardListener-Url-Connector\*.*"

wget -O "%temp%\OModules\ClipBoardListener-Url-Connector_0.0.0.46.exe" %DOWNLOAD_URL%/ClipBoardListener-Url-Connector_0.0.0.46.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ClipBoardListener-Url-Connector_0.0.0.46.exe" -o"%OMODULE_PATH%\ClipBoardListener-Url-Connector\"


if /i [ElasticSearchNestConnector] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ElasticSearchNestConnector
)

del /s /q "%OMODULE_PATH%\ElasticSearchNestConnector\*.*"

wget -O "%temp%\OModules\ElasticSearchNestConnector_0.0.0.49.exe" %DOWNLOAD_URL%/ElasticSearchNestConnector_0.0.0.49.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ElasticSearchNestConnector_0.0.0.49.exe" -o"%OMODULE_PATH%\ElasticSearchNestConnector\"


if /i [Ontology-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Ontology-Module
)

del /s /q "%OMODULE_PATH%\Ontology-Module\*.*"

wget -O "%temp%\OModules\Ontology-Module_0.4.0.153.exe" %DOWNLOAD_URL%/Ontology-Module_0.4.0.153.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Ontology-Module_0.4.0.153.exe" -o"%OMODULE_PATH%\Ontology-Module\"


if /i [File-Tagging-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/File-Tagging-Module
)

del /s /q "%OMODULE_PATH%\File-Tagging-Module\*.*"

wget -O "%temp%\OModules\File-Tagging-Module_0.1.0.67.exe" %DOWNLOAD_URL%/File-Tagging-Module_0.1.0.67.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\File-Tagging-Module_0.1.0.67.exe" -o"%OMODULE_PATH%\File-Tagging-Module\"


if /i [Security-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Security-Module
)

del /s /q "%OMODULE_PATH%\Security-Module\*.*"

wget -O "%temp%\OModules\Security-Module_0.3.0.65.exe" %DOWNLOAD_URL%/Security-Module_0.3.0.65.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Security-Module_0.3.0.65.exe" -o"%OMODULE_PATH%\Security-Module\"


if /i [PortListenerForText-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/PortListenerForText-Module
)

del /s /q "%OMODULE_PATH%\PortListenerForText-Module\*.*"

wget -O "%temp%\OModules\PortListenerForText-Module_0.1.0.37.exe" %DOWNLOAD_URL%/PortListenerForText-Module_0.1.0.37.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\PortListenerForText-Module_0.1.0.37.exe" -o"%OMODULE_PATH%\PortListenerForText-Module\"


if /i [ElasticSearchConfig-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ElasticSearchConfig-Module
)

del /s /q "%OMODULE_PATH%\ElasticSearchConfig-Module\*.*"

wget -O "%temp%\OModules\ElasticSearchConfig-Module_0.1.0.65.exe" %DOWNLOAD_URL%/ElasticSearchConfig-Module_0.1.0.65.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ElasticSearchConfig-Module_0.1.0.65.exe" -o"%OMODULE_PATH%\ElasticSearchConfig-Module\"


if /i [ModuleLibrary] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ModuleLibrary
)

del /s /q "%OMODULE_PATH%\ModuleLibrary\*.*"

wget -O "%temp%\OModules\ModuleLibrary_0.1.0.72.exe" %DOWNLOAD_URL%/ModuleLibrary_0.1.0.72.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ModuleLibrary_0.1.0.72.exe" -o"%OMODULE_PATH%\ModuleLibrary\"


if /i [Variable-Value-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Variable-Value-Module
)

del /s /q "%OMODULE_PATH%\Variable-Value-Module\*.*"

wget -O "%temp%\OModules\Variable-Value-Module_0.1.0.61.exe" %DOWNLOAD_URL%/Variable-Value-Module_0.1.0.61.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Variable-Value-Module_0.1.0.61.exe" -o"%OMODULE_PATH%\Variable-Value-Module\"


if /i [RDF-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/RDF-Module
)

del /s /q "%OMODULE_PATH%\RDF-Module\*.*"

wget -O "%temp%\OModules\RDF-Module_0.1.0.100.exe" %DOWNLOAD_URL%/RDF-Module_0.1.0.100.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\RDF-Module_0.1.0.100.exe" -o"%OMODULE_PATH%\RDF-Module\"


if /i [Localization-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Localization-Module
)

del /s /q "%OMODULE_PATH%\Localization-Module\*.*"

wget -O "%temp%\OModules\Localization-Module_0.1.1.67.exe" %DOWNLOAD_URL%/Localization-Module_0.1.1.67.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Localization-Module_0.1.1.67.exe" -o"%OMODULE_PATH%\Localization-Module\"


if /i [Formale-Begriffsanalyse-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Formale-Begriffsanalyse-Module
)

del /s /q "%OMODULE_PATH%\Formale-Begriffsanalyse-Module\*.*"

wget -O "%temp%\OModules\Formale-Begriffsanalyse-Module_0.1.0.66.exe" %DOWNLOAD_URL%/Formale-Begriffsanalyse-Module_0.1.0.66.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Formale-Begriffsanalyse-Module_0.1.0.66.exe" -o"%OMODULE_PATH%\Formale-Begriffsanalyse-Module\"


if /i [Grid-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Grid-Module
)

del /s /q "%OMODULE_PATH%\Grid-Module\*.*"

wget -O "%temp%\OModules\Grid-Module_0.1.0.24.exe" %DOWNLOAD_URL%/Grid-Module_0.1.0.24.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Grid-Module_0.1.0.24.exe" -o"%OMODULE_PATH%\Grid-Module\"


if /i [NextGenerationOntoEdit] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/NextGenerationOntoEdit
)

del /s /q "%OMODULE_PATH%\NextGenerationOntoEdit\*.*"

wget -O "%temp%\OModules\NextGenerationOntoEdit_0.1.0.26.exe" %DOWNLOAD_URL%/NextGenerationOntoEdit_0.1.0.26.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\NextGenerationOntoEdit_0.1.0.26.exe" -o"%OMODULE_PATH%\NextGenerationOntoEdit\"


if /i [OntoMsg-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/OntoMsg-Module
)

del /s /q "%OMODULE_PATH%\OntoMsg-Module\*.*"

wget -O "%temp%\OModules\OntoMsg-Module_0.0.0.3.exe" %DOWNLOAD_URL%/OntoMsg-Module_0.0.0.3.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\OntoMsg-Module_0.0.0.3.exe" -o"%OMODULE_PATH%\OntoMsg-Module\"


if /i [GraphMLConnector] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/GraphMLConnector
)

del /s /q "%OMODULE_PATH%\GraphMLConnector\*.*"

wget -O "%temp%\OModules\GraphMLConnector_0.1.0.111.exe" %DOWNLOAD_URL%/GraphMLConnector_0.1.0.111.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\GraphMLConnector_0.1.0.111.exe" -o"%OMODULE_PATH%\GraphMLConnector\"


if /i [Hierarchichal-Splitter-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Hierarchichal-Splitter-Module
)

del /s /q "%OMODULE_PATH%\Hierarchichal-Splitter-Module\*.*"

wget -O "%temp%\OModules\Hierarchichal-Splitter-Module_0.1.0.70.exe" %DOWNLOAD_URL%/Hierarchichal-Splitter-Module_0.1.0.70.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Hierarchichal-Splitter-Module_0.1.0.70.exe" -o"%OMODULE_PATH%\Hierarchichal-Splitter-Module\"


if /i [Ping-Test-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Ping-Test-Module
)

del /s /q "%OMODULE_PATH%\Ping-Test-Module\*.*"

wget -O "%temp%\OModules\Ping-Test-Module_0.1.0.62.exe" %DOWNLOAD_URL%/Ping-Test-Module_0.1.0.62.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Ping-Test-Module_0.1.0.62.exe" -o"%OMODULE_PATH%\Ping-Test-Module\"


if /i [Log-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Log-Module
)

del /s /q "%OMODULE_PATH%\Log-Module\*.*"

wget -O "%temp%\OModules\Log-Module_0.3.0.74.exe" %DOWNLOAD_URL%/Log-Module_0.3.0.74.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Log-Module_0.3.0.74.exe" -o"%OMODULE_PATH%\Log-Module\"


if /i [TimeManagement-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/TimeManagement-Module
)

del /s /q "%OMODULE_PATH%\TimeManagement-Module\*.*"

wget -O "%temp%\OModules\TimeManagement-Module_0.1.0.110.exe" %DOWNLOAD_URL%/TimeManagement-Module_0.1.0.110.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\TimeManagement-Module_0.1.0.110.exe" -o"%OMODULE_PATH%\TimeManagement-Module\"


if /i [OntologySync-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/OntologySync-Module
)

del /s /q "%OMODULE_PATH%\OntologySync-Module\*.*"

wget -O "%temp%\OModules\OntologySync-Module_0.0.0.16.exe" %DOWNLOAD_URL%/OntologySync-Module_0.0.0.16.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\OntologySync-Module_0.0.0.16.exe" -o"%OMODULE_PATH%\OntologySync-Module\"


if /i [LocalizedTemplate-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/LocalizedTemplate-Module
)

del /s /q "%OMODULE_PATH%\LocalizedTemplate-Module\*.*"

wget -O "%temp%\OModules\LocalizedTemplate-Module_0.1.0.25.exe" %DOWNLOAD_URL%/LocalizedTemplate-Module_0.1.0.25.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\LocalizedTemplate-Module_0.1.0.25.exe" -o"%OMODULE_PATH%\LocalizedTemplate-Module\"


if /i [ElasticSearchLogging-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ElasticSearchLogging-Module
)

del /s /q "%OMODULE_PATH%\ElasticSearchLogging-Module\*.*"

wget -O "%temp%\OModules\ElasticSearchLogging-Module_0.1.0.67.exe" %DOWNLOAD_URL%/ElasticSearchLogging-Module_0.1.0.67.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ElasticSearchLogging-Module_0.1.0.67.exe" -o"%OMODULE_PATH%\ElasticSearchLogging-Module\"


if /i [Version-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Version-Module
)

del /s /q "%OMODULE_PATH%\Version-Module\*.*"

wget -O "%temp%\OModules\Version-Module_0.1.1.76.exe" %DOWNLOAD_URL%/Version-Module_0.1.1.76.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Version-Module_0.1.1.76.exe" -o"%OMODULE_PATH%\Version-Module\"


if /i [FileSystem-BaseModel] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/FileSystem-BaseModel
)

del /s /q "%OMODULE_PATH%\FileSystem-BaseModel\*.*"

wget -O "%temp%\OModules\FileSystem-BaseModel_0.1.0.20.exe" %DOWNLOAD_URL%/FileSystem-BaseModel_0.1.0.20.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\FileSystem-BaseModel_0.1.0.20.exe" -o"%OMODULE_PATH%\FileSystem-BaseModel\"


if /i [Manual-Repair-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Manual-Repair-Module
)

del /s /q "%OMODULE_PATH%\Manual-Repair-Module\*.*"

wget -O "%temp%\OModules\Manual-Repair-Module_0.1.0.60.exe" %DOWNLOAD_URL%/Manual-Repair-Module_0.1.0.60.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Manual-Repair-Module_0.1.0.60.exe" -o"%OMODULE_PATH%\Manual-Repair-Module\"


if /i [Filesystem-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Filesystem-Module
)

del /s /q "%OMODULE_PATH%\Filesystem-Module\*.*"

wget -O "%temp%\OModules\Filesystem-Module_0.3.0.111.exe" %DOWNLOAD_URL%/Filesystem-Module_0.3.0.111.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Filesystem-Module_0.3.0.111.exe" -o"%OMODULE_PATH%\Filesystem-Module\"


if /i [HTMLExport-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/HTMLExport-Module
)

del /s /q "%OMODULE_PATH%\HTMLExport-Module\*.*"

wget -O "%temp%\OModules\HTMLExport-Module_0.1.0.109.exe" %DOWNLOAD_URL%/HTMLExport-Module_0.1.0.109.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\HTMLExport-Module_0.1.0.109.exe" -o"%OMODULE_PATH%\HTMLExport-Module\"


if /i [Media-Web-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Media-Web-Module
)

del /s /q "%OMODULE_PATH%\Media-Web-Module\*.*"

wget -O "%temp%\OModules\Media-Web-Module_0.1.0.24.exe" %DOWNLOAD_URL%/Media-Web-Module_0.1.0.24.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Media-Web-Module_0.1.0.24.exe" -o"%OMODULE_PATH%\Media-Web-Module\"


if /i [Office-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Office-Module
)

del /s /q "%OMODULE_PATH%\Office-Module\*.*"

wget -O "%temp%\OModules\Office-Module_0.1.1.90.exe" %DOWNLOAD_URL%/Office-Module_0.1.1.90.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Office-Module_0.1.1.90.exe" -o"%OMODULE_PATH%\Office-Module\"


if /i [Typed-Tagging-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Typed-Tagging-Module
)

del /s /q "%OMODULE_PATH%\Typed-Tagging-Module\*.*"

wget -O "%temp%\OModules\Typed-Tagging-Module_0.1.0.105.exe" %DOWNLOAD_URL%/Typed-Tagging-Module_0.1.0.105.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Typed-Tagging-Module_0.1.0.105.exe" -o"%OMODULE_PATH%\Typed-Tagging-Module\"


if /i [AudioPlayer-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/AudioPlayer-Module
)

del /s /q "%OMODULE_PATH%\AudioPlayer-Module\*.*"

wget -O "%temp%\OModules\AudioPlayer-Module_0.1.0.88.exe" %DOWNLOAD_URL%/AudioPlayer-Module_0.1.0.88.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\AudioPlayer-Module_0.1.0.88.exe" -o"%OMODULE_PATH%\AudioPlayer-Module\"


if /i [CommandLineRun-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/CommandLineRun-Module
)

del /s /q "%OMODULE_PATH%\CommandLineRun-Module\*.*"

wget -O "%temp%\OModules\CommandLineRun-Module_0.1.0.73.exe" %DOWNLOAD_URL%/CommandLineRun-Module_0.1.0.73.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\CommandLineRun-Module_0.1.0.73.exe" -o"%OMODULE_PATH%\CommandLineRun-Module\"


if /i [BankTransaction-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/BankTransaction-Module
)

del /s /q "%OMODULE_PATH%\BankTransaction-Module\*.*"

wget -O "%temp%\OModules\BankTransaction-Module_0.1.1.91.exe" %DOWNLOAD_URL%/BankTransaction-Module_0.1.1.91.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\BankTransaction-Module_0.1.1.91.exe" -o"%OMODULE_PATH%\BankTransaction-Module\"


if /i [TextParser] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/TextParser
)

del /s /q "%OMODULE_PATH%\TextParser\*.*"

wget -O "%temp%\OModules\TextParser_0.1.0.139.exe" %DOWNLOAD_URL%/TextParser_0.1.0.139.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\TextParser_0.1.0.139.exe" -o"%OMODULE_PATH%\TextParser\"


if /i [DatabaseConfigurationModule] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/DatabaseConfigurationModule
)

del /s /q "%OMODULE_PATH%\DatabaseConfigurationModule\*.*"

wget -O "%temp%\OModules\DatabaseConfigurationModule_0.1.0.56.exe" %DOWNLOAD_URL%/DatabaseConfigurationModule_0.1.0.56.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\DatabaseConfigurationModule_0.1.0.56.exe" -o"%OMODULE_PATH%\DatabaseConfigurationModule\"


if /i [ScriptingModule] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/ScriptingModule
)

del /s /q "%OMODULE_PATH%\ScriptingModule\*.*"

wget -O "%temp%\OModules\ScriptingModule_0.1.0.49.exe" %DOWNLOAD_URL%/ScriptingModule_0.1.0.49.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\ScriptingModule_0.1.0.49.exe" -o"%OMODULE_PATH%\ScriptingModule\"


if /i [CommandLineCL-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/CommandLineCL-Module
)

del /s /q "%OMODULE_PATH%\CommandLineCL-Module\*.*"

wget -O "%temp%\OModules\CommandLineCL-Module_0.1.0.66.exe" %DOWNLOAD_URL%/CommandLineCL-Module_0.1.0.66.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\CommandLineCL-Module_0.1.0.66.exe" -o"%OMODULE_PATH%\CommandLineCL-Module\"


if /i [Media-Viewer-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Media-Viewer-Module
)

del /s /q "%OMODULE_PATH%\Media-Viewer-Module\*.*"

wget -O "%temp%\OModules\Media-Viewer-Module_0.1.1.147.exe" %DOWNLOAD_URL%/Media-Viewer-Module_0.1.1.147.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Media-Viewer-Module_0.1.1.147.exe" -o"%OMODULE_PATH%\Media-Viewer-Module\"


if /i [Development-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Development-Module
)

del /s /q "%OMODULE_PATH%\Development-Module\*.*"

wget -O "%temp%\OModules\Development-Module_0.3.0.166.exe" %DOWNLOAD_URL%/Development-Module_0.3.0.166.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Development-Module_0.3.0.166.exe" -o"%OMODULE_PATH%\Development-Module\"


if /i [FileSystem-Connector-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/FileSystem-Connector-Module
)

del /s /q "%OMODULE_PATH%\FileSystem-Connector-Module\*.*"

wget -O "%temp%\OModules\FileSystem-Connector-Module_0.1.0.115.exe" %DOWNLOAD_URL%/FileSystem-Connector-Module_0.1.0.115.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\FileSystem-Connector-Module_0.1.0.115.exe" -o"%OMODULE_PATH%\FileSystem-Connector-Module\"


if /i [Scenes-Literatur-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Scenes-Literatur-Module
)

del /s /q "%OMODULE_PATH%\Scenes-Literatur-Module\*.*"

wget -O "%temp%\OModules\Scenes-Literatur-Module_0.1.1.112.exe" %DOWNLOAD_URL%/Scenes-Literatur-Module_0.1.1.112.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Scenes-Literatur-Module_0.1.1.112.exe" -o"%OMODULE_PATH%\Scenes-Literatur-Module\"


if /i [Process-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Process-Module
)

del /s /q "%OMODULE_PATH%\Process-Module\*.*"

wget -O "%temp%\OModules\Process-Module_0.3.0.113.exe" %DOWNLOAD_URL%/Process-Module_0.3.0.113.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Process-Module_0.3.0.113.exe" -o"%OMODULE_PATH%\Process-Module\"


if /i [OutlookConnector-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/OutlookConnector-Module
)

del /s /q "%OMODULE_PATH%\OutlookConnector-Module\*.*"

wget -O "%temp%\OModules\OutlookConnector-Module_0.1.0.125.exe" %DOWNLOAD_URL%/OutlookConnector-Module_0.1.0.125.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\OutlookConnector-Module_0.1.0.125.exe" -o"%OMODULE_PATH%\OutlookConnector-Module\"


if /i [Partner-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Partner-Module
)

del /s /q "%OMODULE_PATH%\Partner-Module\*.*"

wget -O "%temp%\OModules\Partner-Module_0.3.0.114.exe" %DOWNLOAD_URL%/Partner-Module_0.3.0.114.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Partner-Module_0.3.0.114.exe" -o"%OMODULE_PATH%\Partner-Module\"


if /i [FileResourceModule] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/FileResourceModule
)

del /s /q "%OMODULE_PATH%\FileResourceModule\*.*"

wget -O "%temp%\OModules\FileResourceModule_0.1.0.118.exe" %DOWNLOAD_URL%/FileResourceModule_0.1.0.118.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\FileResourceModule_0.1.0.118.exe" -o"%OMODULE_PATH%\FileResourceModule\"


if /i [Report-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Report-Module
)

del /s /q "%OMODULE_PATH%\Report-Module\*.*"

wget -O "%temp%\OModules\Report-Module_0.1.1.162.exe" %DOWNLOAD_URL%/Report-Module_0.1.1.162.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Report-Module_0.1.1.162.exe" -o"%OMODULE_PATH%\Report-Module\"


if /i [Appointment-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Appointment-Module
)

del /s /q "%OMODULE_PATH%\Appointment-Module\*.*"

wget -O "%temp%\OModules\Appointment-Module_0.1.1.117.exe" %DOWNLOAD_URL%/Appointment-Module_0.1.1.117.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Appointment-Module_0.1.1.117.exe" -o"%OMODULE_PATH%\Appointment-Module\"


if /i [Schriftverkehrs-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Schriftverkehrs-Module
)

del /s /q "%OMODULE_PATH%\Schriftverkehrs-Module\*.*"

wget -O "%temp%\OModules\Schriftverkehrs-Module_0.1.0.156.exe" %DOWNLOAD_URL%/Schriftverkehrs-Module_0.1.0.156.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Schriftverkehrs-Module_0.1.0.156.exe" -o"%OMODULE_PATH%\Schriftverkehrs-Module\"


if /i [Bill-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Bill-Module
)

del /s /q "%OMODULE_PATH%\Bill-Module\*.*"

wget -O "%temp%\OModules\Bill-Module_0.1.0.129.exe" %DOWNLOAD_URL%/Bill-Module_0.1.0.129.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Bill-Module_0.1.0.129.exe" -o"%OMODULE_PATH%\Bill-Module\"


if /i [Literaturquellen-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Literaturquellen-Module
)

del /s /q "%OMODULE_PATH%\Literaturquellen-Module\*.*"

wget -O "%temp%\OModules\Literaturquellen-Module_0.1.0.171.exe" %DOWNLOAD_URL%/Literaturquellen-Module_0.1.0.171.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Literaturquellen-Module_0.1.0.171.exe" -o"%OMODULE_PATH%\Literaturquellen-Module\"


if /i [Change-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Change-Module
)

del /s /q "%OMODULE_PATH%\Change-Module\*.*"

wget -O "%temp%\OModules\Change-Module_0.1.0.132.exe" %DOWNLOAD_URL%/Change-Module_0.1.0.132.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Change-Module_0.1.0.132.exe" -o"%OMODULE_PATH%\Change-Module\"


if /i [Checklist-Module] EQU [Ontolog-Module] (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/OntologyManager
) else (
	SET DOWNLOAD_URL=https://sourceforge.net/projects/ontologymanager/files/Modules/Checklist-Module
)

del /s /q "%OMODULE_PATH%\Checklist-Module\*.*"

wget -O "%temp%\OModules\Checklist-Module_0.1.0.172.exe" %DOWNLOAD_URL%/Checklist-Module_0.1.0.172.exe/download
"%PROGRAMFILES%\7-Zip\7z.exe" x "%temp%\OModules\Checklist-Module_0.1.0.172.exe" -o"%OMODULE_PATH%\Checklist-Module\"
