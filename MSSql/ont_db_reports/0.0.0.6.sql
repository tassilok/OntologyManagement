USE [ont_db_Reports]
GO
/****** Object:  StoredProcedure [dbo].[import_BulkFile_RelationType]    Script Date: 02/19/2013 22:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[import_BulkFile_RelationType] 
	-- Add the parameters for the stored procedure here
	 @Name_Table		nvarchar(128)
	,@SELECT			nvarchar(max)
	,@Join				nvarchar(max)
	,@Set_Update		nvarchar(max)
	,@Path_File			nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @SQL		nvarchar(max)

	
	SET @SQL = '
	
		CREATE TABLE #tmp_xml
		(
			XMLCol xml
		)
		
		INSERT INTO #tmp_xml
		SELECT *
		FROM OPENROWSET(
		BULK ''' + @Path_File + ''',
		SINGLE_BLOB) AS tmp_Table
		
		INSERT INTO [' + @Name_Table + ']
		SELECT	 xmlset.DS.value(''GUID_Object_Left[1]'',''varchar(36)'') AS GUID_Object_Left
			,xmlset.DS.value(''GUID_Object_Right[1]'',''varchar(36)'') AS GUID_Object_Right
			,xmlset.DS.value(''GUID_RelationType[1]'',''varchar(36)'') AS GUID_RelationType
			,xmlset.DS.value(''Name_RelationType[1]'',''varchar(36)'') AS Name_RelationType
			,xmlset.DS.value(''OrderID[1]'',''bigint'') AS OrderID
			,xmlset.DS.value(''Exist[1]'',''bit'') AS Exist
		FROM #tmp_xml tmp_table
		CROSS APPLY XMLCol.nodes(''/root/tmptbl'') AS xmlset(DS)
		LEFT OUTER JOIN ' + @Join + ' 
		WHERE ' + @Name_Table + '.GUID_Object_Left IS NULL
		AND ' + @Name_Table + '.GUID_Object_Right IS NULL
		AND ' + @Name_Table + '.GUID_RelationType IS NULL
		
		UPDATE [' + @Name_Table + '] 
		SET ' + @Set_Update + '
		FROM #tmp_xml tmp_table
		CROSS APPLY XMLCol.nodes(''/root/tmptbl'') AS xmlset(DS)
		INNER JOIN ' + @Join  

	PRINT @SQL	
	exec(@SQL)

END
GO
/****** Object:  StoredProcedure [dbo].[create_Table_relT]    Script Date: 02/19/2013 22:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_Table_relT]
	-- Add the parameters for the stored procedure here
	 @Ontology				nvarchar(128)
	,@Name_Class_Left		nvarchar(128)
	,@Name_Class_Right		nvarchar(128)
	,@Name_RelationType		nvarchar(128)
	,@Path_File				nvarchar(255)
	,@Objects				bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @SQL		nvarchar(max)
	DECLARE @SELECT		nvarchar(max)
	DECLARE @Name_Table	nvarchar(128)	
	DECLARE @SET_UPdate	nvarchar(max)
	DECLARE @JOIN		nvarchar(max)
	
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,' ','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,':','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'-','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'(','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,')','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'/','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'\','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'>','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'*','_')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'.','_')
	
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,' ','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,':','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'-','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'(','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,')','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'/','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'\','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'>','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'*','_')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'.','_')
	
	SET @Name_RelationType = REPLACE(@Name_RelationType,'','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,' ','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,':','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'-','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'(','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,')','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'/','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'\','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'>','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'*','_')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'.','_')
	
	SET @SQL = 'IF OBJECT_ID(''[relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + ']'', N''U'') IS NULL 
	BEGIN
	
	CREATE TABLE [relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + ']
	(
		[GUID_Object_Left] varchar(36) NOT NULL,
		[GUID_Object_Right] varchar(36) NOT NULL,
		[GUID_RelationType] varchar(36) NOT NULL,
		[Name_RelationType] nvarchar(255) NOT NULL,
		[OrderID] bigint NOT NULL,
		[Exist]	bit NOT NULL DEFAULT 1
	)  ON [PRIMARY];
ALTER TABLE [relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + '] ADD CONSTRAINT
	[PK_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + '] PRIMARY KEY CLUSTERED 
	(
	[GUID_Object_Left],[GUID_Object_Right],[GUID_RelationType]
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];
ALTER TABLE [relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + '] SET (LOCK_ESCALATION = TABLE)
END'

	EXEC (@SQL)
	SET @SELECT = 'GUID_Object_Left,GUID_Object_Right,GUID_RelationType, Name_RelationType, OrderID, Exist'
	SET @Name_Table = 'relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType
	SET @SET_UPdate = 'relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType 
		+'.Name_RelationType=xmlset.DS.value(''Name_RelationType[1]'',''nvarchar(255)''),'
		+'relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + '.OrderID=xmlset.DS.value(''OrderID[1]'',''bigint''),'
		+'relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + '.Exist=1'
	SET @JOIN = 'relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + ' ON relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType 
	+'.GUID_Object_Left=xmlset.DS.value(''GUID_Object_Left[1]'',''varchar(36)'') AND '
	+'relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType 
	+'.GUID_Object_Right=xmlset.DS.value(''GUID_Object_Right[1]'',''varchar(36)'') AND '
	+'relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType 
	+'.GUID_RelationType=xmlset.DS.value(''GUID_RelationType[1]'',''varchar(36)'')'
	
	if @Objects=1
	BEGIN
		execute import_BulkFile_RelationType @Name_Table, @SELECT, @Join, @SET_UPdate, @Path_File
	END

IF (SELECT COUNT(*)
	FROM systbl_Tables
	WHERE Name_Table='relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType)>0 
BEGIN
	UPDATE systbl_Tables
	SET Exist = 1
	WHERE Name_Table='relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType
END
ELSE
BEGIN
	INSERT INTO systbl_Tables
	VALUES (@Ontology, 'relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType, 1)
END

SELECT object_id
FROM sys.objects 
WHERE name='relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType 
AND type='U'
END
GO
