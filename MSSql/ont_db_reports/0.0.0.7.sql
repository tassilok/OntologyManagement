USE [ont_db_Reports]
GO
/****** Object:  StoredProcedure [dbo].[initialize_Table]    Script Date: 02/20/2013 16:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[initialize_Table]
	-- Add the parameters for the stored procedure here
	@Name_Table		nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SET @Name_Table = REPLACE(@Name_Table,'','_')
	SET @Name_Table = REPLACE(@Name_Table,' ','_')
	SET @Name_Table = REPLACE(@Name_Table,':','_')
	SET @Name_Table = REPLACE(@Name_Table,'-','_')
	SET @Name_Table = REPLACE(@Name_Table,'(','_')
	SET @Name_Table = REPLACE(@Name_Table,')','_')
	SET @Name_Table = REPLACE(@Name_Table,'/','_')
	SET @Name_Table = REPLACE(@Name_Table,'\','_')
	SET @Name_Table = REPLACE(@Name_Table,'>','_')
	SET @Name_Table = REPLACE(@Name_Table,'*','_')
	SET @Name_Table = REPLACE(@Name_Table,'.','_')

    -- Insert statements for procedure here
    DECLARE @SQL	nvarchar(max)
    
	SET @SQL = '
		IF OBJECT_ID(''' + @Name_Table + ''', N''U'') IS NOT NULL 
		BEGIN
			UPDATE ' + @Name_Table + '
			SET Exist=0
		END'
	
	EXEC(@SQL)
	
	SELECT 1 AS Done
END
GO
/****** Object:  StoredProcedure [dbo].[import_BulkFile_RelationType]    Script Date: 02/20/2013 16:22:36 ******/
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
	 @Ontology			nvarchar(255)
	,@Name_Table		nvarchar(128)
	,@SELECT			nvarchar(max)
	,@Join				nvarchar(max)
	,@Where				nvarchar(max)
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
		WHERE ' + @Where + '
		
		UPDATE [' + @Name_Table + '] 
		SET ' + @Set_Update + '
		FROM #tmp_xml tmp_table
		CROSS APPLY XMLCol.nodes(''/root/tmptbl'') AS xmlset(DS)
		INNER JOIN ' + @Join  + ' '

	exec(@SQL)

END
GO
/****** Object:  StoredProcedure [dbo].[import_BulkFile_Class]    Script Date: 02/20/2013 16:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[import_BulkFile_Class] 
	-- Add the parameters for the stored procedure here
	 @Ontology			nvarchar(255)
	,@Name_Class		nvarchar(255)
	,@Name_Table		nvarchar(128)
	,@SELECT			nvarchar(max)
	,@Join				nvarchar(max)
	,@Where_Insert		nvarchar(max)
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
		SELECT	 xmlset.DS.value(''GUID[1]'',''nvarchar(36)'') AS GUID
			,xmlset.DS.value(''Name[1]'',''nvarchar(max)'') AS Name
			,xmlset.DS.value(''GUID_Class[1]'',''nvarchar(36)'') AS GUID_Class
			,''' + @Name_Class + ''' AS Name_Class
			,xmlset.DS.value(''Exist[1]'',''bit'') AS Exist
		FROM #tmp_xml tmp_table
		CROSS APPLY XMLCol.nodes(''/root/tmptbl'') AS xmlset(DS)
		LEFT OUTER JOIN ' + @Join + ' '
		+ @WHERE_Insert
		+ '
		
		UPDATE [' + @Name_Table + '] 
		SET ' + @Set_Update + '
		FROM #tmp_xml tmp_table
		CROSS APPLY XMLCol.nodes(''/root/tmptbl'') AS xmlset(DS)
		INNER JOIN ' + @Join + ' '
	
	exec(@SQL)

END
GO
/****** Object:  StoredProcedure [dbo].[import_BulkFile_Attribute]    Script Date: 02/20/2013 16:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[import_BulkFile_Attribute] 
	-- Add the parameters for the stored procedure here
	 @Ontology			nvarchar(255)
	,@Name_Table		nvarchar(128)
	,@SQL_TMPTABLE		nvarchar(max)
	,@SELECT			nvarchar(max)
	,@Join				nvarchar(max)
	,@Where_Insert		nvarchar(max)
	,@Set_Update		nvarchar(max)
	,@Path_File			nvarchar(255)
	,@DataType			nvarchar(128)
	,@Length			nvarchar(128)
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
		SELECT	 xmlset.DS.value(''GUID_Attribute[1]'',''nvarchar(36)'') AS GUID_Attribute
			,xmlset.DS.value(''GUID_AttributeType[1]'',''nvarchar(36)'') AS GUID_AttributeType
			,xmlset.DS.value(''Name_AttributeType[1]'',''nvarchar(max)'') AS Name_AttributeType
			,xmlset.DS.value(''GUID_Object[1]'',''nvarchar(36)'') AS GUID_Object
			,xmlset.DS.value(''OrderID[1]'',''bigint'') AS OrderID'
		if Not @Length='0'
		BEGIN
		SET @SQL = @SQL + ',xmlset.DS.value(''val[1]'',''' + @DataType + '(' + @Length +')'') AS Val'
		END
		ELSE
		BEGIN
			SET @SQL = @SQL + ',xmlset.DS.value(''val[1]'',''' + @DataType +''') AS Val'
		END
			
		SET @SQL = @SQL + '
			,1 AS Exist
		FROM #tmp_xml tmp_table
		CROSS APPLY XMLCol.nodes(''/root/tmptbl'') AS xmlset(DS)
		LEFT OUTER JOIN ' + @Join + ' '
		+ @WHERE_Insert
		+ '
		
		UPDATE [' + @Name_Table + '] 
		SET ' + @Set_Update + '
		FROM #tmp_xml tmp_table
		CROSS APPLY XMLCol.nodes(''/root/tmptbl'') AS xmlset(DS)
		INNER JOIN ' + @Join + ' '
		PRINT @SQL
	exec(@SQL)

END
GO
/****** Object:  StoredProcedure [dbo].[import_BulkFile]    Script Date: 02/20/2013 16:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[import_BulkFile] 
	-- Add the parameters for the stored procedure here
	 @Name_Table		nvarchar(128)
	,@SQL_TMPTABLE		nvarchar(max)
	,@SELECT			nvarchar(max)
	,@Join				nvarchar(max)
	,@Where_Insert		nvarchar(max)
	,@Set_Update		nvarchar(max)
	,@Path_File			nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @SQL		nvarchar(max)
	
	EXEC(@SQL)
	
	SET @SQL = @SQL_TMPTABLE + '
		INSERT INTO #tmp_' + @Name_Table + '
		SELECT ' +  @SELECT + '
		FROM OPENROWSET(
		BULK ''' + @Path_File + ''',
		SINGLE_BLOB) AS tmp_Table
		
		INSERT INTO [' + @Name_Table + ']
		SELECT * FROM #tmp_' + @Name_Table + '
		LEFT OUTER JOIN ' + @Join + ' '
		+ @WHERE_Insert
		+ '
		
		UPDATE [' + @Name_Table + '] 
		SET ' + @Set_Update + '
		FROM #tmp_' + @Name_Table + '
		INNER JOIN ' + @Join + ' '
	print @SQL
	exec(@SQL)
	
	
END
GO
/****** Object:  Table [dbo].[systbl_Tables]    Script Date: 02/20/2013 16:22:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[systbl_Tables](
	[Type] [nvarchar](128) NOT NULL,
	[Name_Table] [nvarchar](128) NOT NULL,
	[Exist] [bit] NOT NULL,
	[Sync_Start] [datetime] NULL,
	[Sync_End] [datetime] NULL,
 CONSTRAINT [PK_systbl_Tables] PRIMARY KEY CLUSTERED 
(
	[Type] ASC,
	[Name_Table] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[insert_Object]    Script Date: 02/20/2013 16:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insert_Object] 
	-- Add the parameters for the stored procedure here
	 @GUID_Session		varchar(36)
	,@GUID_Class		varchar(36)
	,@GUID_Object		varchar(36)
	,@Name_Object		nvarchar(255)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @SQL		nvarchar(max)
	
	SET @SQL = 'INSERT INTO [@TABLE@] VALUES (''@GUID_OBJECT@'',''@NAME_OBJECT@'',''@GUID_CLASS@'')'
	
	SET @SQL = REPLACE(@SQL,'@TABLE@',@GUID_Session+@GUID_Class)
	SET @SQL = REPLACE(@SQL,'@GUID_OBJECT@',@GUID_Object)
	SET @SQL = REPLACE(@SQL,'@NAME_OBJECT@',@Name_Object)
	SET @SQL = REPLACE(@SQL,'@GUID_CLASS@',@GUID_Class)
	PRINT @SQL
	EXEC(@SQL)
END
GO
/****** Object:  StoredProcedure [dbo].[finalize_Table]    Script Date: 02/20/2013 16:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[finalize_Table]
	-- Add the parameters for the stored procedure here
	@Name_Table		nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @SQL	nvarchar(max)
    
    SET @Name_Table = REPLACE(@Name_Table,'','_')
	SET @Name_Table = REPLACE(@Name_Table,' ','_')
	SET @Name_Table = REPLACE(@Name_Table,':','_')
	SET @Name_Table = REPLACE(@Name_Table,'-','_')
	SET @Name_Table = REPLACE(@Name_Table,'(','_')
	SET @Name_Table = REPLACE(@Name_Table,')','_')
	SET @Name_Table = REPLACE(@Name_Table,'/','_')
	SET @Name_Table = REPLACE(@Name_Table,'\','_')
	SET @Name_Table = REPLACE(@Name_Table,'>','_')
	SET @Name_Table = REPLACE(@Name_Table,'*','_')
	SET @Name_Table = REPLACE(@Name_Table,'.','_')
    
	SET @SQL = 'DELETE FROM ' + @Name_Table + '
		WHERE Exist=0'
	EXEC(@SQL)
	
	SELECT 1 AS Done
END
GO
/****** Object:  StoredProcedure [dbo].[create_Table_relT]    Script Date: 02/20/2013 16:22:36 ******/
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
	DECLARE @Where		nvarchar(max)
	
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'','')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,' ','')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,':','')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'-','')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'(','')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,')','')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'/','')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'\','')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'>','')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'*','')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'.','')
	SET @Name_Class_Left = REPLACE(@Name_Class_Left,'_','')
	
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'','')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,' ','')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,':','')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'-','')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'(','')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,')','')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'/','')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'\','')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'>','')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'*','')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'.','')
	SET @Name_Class_Right = REPLACE(@Name_Class_Right,'_','')
	
	SET @Name_RelationType = REPLACE(@Name_RelationType,'','')
	SET @Name_RelationType = REPLACE(@Name_RelationType,' ','')
	SET @Name_RelationType = REPLACE(@Name_RelationType,':','')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'-','')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'(','')
	SET @Name_RelationType = REPLACE(@Name_RelationType,')','')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'/','')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'\','')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'>','')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'*','')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'.','')
	SET @Name_RelationType = REPLACE(@Name_RelationType,'_','')
	
	SET @SQL = 'IF OBJECT_ID(''[relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + ']'', N''U'') IS NULL 
	BEGIN
	
	CREATE TABLE [relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + ']
	(
		[GUID_L_' + @Name_Class_Left +'] varchar(36) NOT NULL,
		[GUID_R_' + @Name_Class_Right +'] varchar(36) NOT NULL,
		[GUID_RT_' + @Name_RelationType +'] varchar(36) NOT NULL,
		[Name_RT_' + @Name_RelationType +'] nvarchar(255) NOT NULL,
		[OrderID] bigint NOT NULL,
		[Exist]	bit NOT NULL DEFAULT 1
	)  ON [PRIMARY];
ALTER TABLE [relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + '] ADD CONSTRAINT
	[PK_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + '] PRIMARY KEY CLUSTERED 
	(
	[GUID_L_' + @Name_Class_Left +'],[GUID_R_' + @Name_Class_Right +'],[GUID_RT_' + @Name_RelationType +']
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];
ALTER TABLE [relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + '] SET (LOCK_ESCALATION = TABLE)
END'

	EXEC (@SQL)
	
	IF (SELECT COUNT(*)
	FROM systbl_Tables
	WHERE Name_Table='relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType)>0 
BEGIN
	UPDATE systbl_Tables
	SET Exist = 1, Sync_Start = GETDATE()
	WHERE Name_Table='relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType
END
ELSE
BEGIN
	INSERT INTO systbl_Tables (Type, Name_Table, Exist, Sync_Start)
	VALUES (@Ontology, 'relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType, 1, GETDATE())
END
	
	SET @SELECT = 'GUID_Object_Left,GUID_Object_Right,GUID_RelationType, Name_RelationType, OrderID, Exist'
	SET @SET_UPdate = 'relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType 
		+'.Name_RT_' + @Name_RelationType +'=xmlset.DS.value(''Name_RelationType[1]'',''nvarchar(255)''),'
		+'relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + '.OrderID=xmlset.DS.value(''OrderID[1]'',''bigint''),'
		+'relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + '.Exist=1'
	SET @JOIN = 'relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + ' ON relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType 
	+'.GUID_L_' + @Name_Class_Left +'=xmlset.DS.value(''GUID_Object_Left[1]'',''varchar(36)'') AND '
	+'relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType 
	+'.GUID_R_' + @Name_Class_Right +'=xmlset.DS.value(''GUID_Object_Right[1]'',''varchar(36)'') AND '
	+'relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType 
	+'.GUID_RT_' + @Name_RelationType +'=xmlset.DS.value(''GUID_RelationType[1]'',''varchar(36)'')'
	SET @Name_Table = 'relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType	
	SET @Where = @Name_Table + '.GUID_L_' + @Name_Class_Left + ' IS NULL
		AND ' + @Name_Table + '.GUID_R_' + @Name_Class_Right + ' IS NULL
		AND ' + @Name_Table + '.GUID_RT_' + @Name_RelationType + ' IS NULL'
	if @Objects=1
	BEGIN

		execute import_BulkFile_RelationType @Ontology, @Name_Table, @SELECT, @Join, @Where, @SET_UPdate, @Path_File
	END




UPDATE systbl_Tables
SET Sync_End=GETDATE()
WHERE Name_Table=@Name_Table
AND Type = @Ontology

SELECT object_id
FROM sys.objects 
WHERE name='relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType 
AND type='U'
END
GO
/****** Object:  StoredProcedure [dbo].[create_Table_orgT]    Script Date: 02/20/2013 16:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_Table_orgT]
	-- Add the parameters for the stored procedure here
	 @Ontology		nvarchar(128)
	,@Name_Class	nvarchar(255)
	,@Path_File		nvarchar(255)	
	,@Objects		bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @Name_Class_Orig	nvarchar(255)
    -- Insert statements for procedure here
	DECLARE @SQL			nvarchar(max)
	DECLARE @SELECT			nvarchar(max)
	DECLARE @Name_Table		nvarchar(128)
	DECLARE @SET_UPdate		nvarchar(max)
	DECLARE @JOIN			nvarchar(max)
	DECLARE @WHERE_Insert	nvarchar(max)
	
	SET @Name_Class_Orig = REPLACE(@Name_Class,'','''')
	
	
	SET @Name_Class = REPLACE(@Name_Class,'','_')
	SET @Name_Class = REPLACE(@Name_Class,' ','_')
	SET @Name_Class = REPLACE(@Name_Class,':','_')
	SET @Name_Class = REPLACE(@Name_Class,'-','_')
	SET @Name_Class = REPLACE(@Name_Class,'(','_')
	SET @Name_Class = REPLACE(@Name_Class,')','_')
	SET @Name_Class = REPLACE(@Name_Class,'/','_')
	SET @Name_Class = REPLACE(@Name_Class,'\','_')
	SET @Name_Class = REPLACE(@Name_Class,'>','_')
	SET @Name_Class = REPLACE(@Name_Class,'*','_')
	SET @Name_Class = REPLACE(@Name_Class,'.','_')
	


	SET @SQL = '
	IF OBJECT_ID(''orgT_' + @Name_Class + ''', N''U'') IS NULL 
	BEGIN
	CREATE TABLE [orgT_' + @Name_Class + ']
	(
		[GUID_' + @Name_Class +'] varchar(36) NOT NULL,
		[Name_' + @Name_Class + '] nvarchar(255) NOT NULL,
		[GUID_Class_' + @Name_Class + '] varchar(36) NOT NULL,
		[Name_Class] nvarchar(255) NOT NULL,
		[Exist]	bit NOT NULL DEFAULT 1
	)  ON [PRIMARY];
ALTER TABLE [orgT_' + @Name_Class + '] ADD CONSTRAINT
	[PK_cl' + @Name_Class + '] PRIMARY KEY CLUSTERED 
	(
	[GUID_' + @Name_Class + ']
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];
ALTER TABLE [orgT_' + @Name_Class + '] SET (LOCK_ESCALATION = TABLE);
	END'
	
exec(@SQL)



IF (SELECT COUNT(*)
	FROM systbl_Tables
	WHERE Name_Table='orgT_' + @Name_Class)>0 
BEGIN
	UPDATE systbl_Tables
	SET Exist = 1, Sync_Start = GETDATE()
	WHERE Name_Table='orgT_' + @Name_Class
END
ELSE
BEGIN
	INSERT INTO systbl_Tables (Type, Name_Table, Exist, Sync_Start)
	VALUES (@Ontology, 'orgT_' + @Name_Class, 1, GETDATE())
END

SET @Name_Table = 'orgT_' + @Name_Class

IF @Objects = 1
BEGIN
	SET @SELECT = 'GUID,Name,GUID_Class,Exist'	
	SET @SET_UPdate = '[orgT_' + @Name_Class + '].Name_' + @Name_Class + '=xmlset.DS.value(''Name[1]'',''nvarchar(max)''),[orgT_' + @Name_Class + '].Exist=1'
	SET @WHERE_Insert = 'WHERE [orgT_' + @Name_Class + '].GUID_' + @Name_Class + ' IS NULL'
	SET @JOIN = '[orgT_' + @Name_Class + '] ON [orgT_' + @Name_Class + '].GUID_' + @Name_Class + ' = xmlset.DS.value(''GUID[1]'',''nvarchar(36)'')'
	
	execute import_BulkFile_Class @Ontology, @Name_Class_Orig, @Name_Table, @SELECT, @JOIN, @WHERE_Insert, @Set_Update, @Path_File
END
	
	
	UPDATE systbl_Tables
	SET Sync_End=GETDATE()
	WHERE Name_Table=@Name_Table
	AND Type = @Ontology
	
SELECT object_id
FROM sys.objects 
WHERE name='orgT_' + @Name_Class
AND type='U'

END
GO
/****** Object:  StoredProcedure [dbo].[create_Table_attT]    Script Date: 02/20/2013 16:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_Table_attT]
	-- Add the parameters for the stored procedure here
	 @Ontology				nvarchar(128)
	,@Name_AttributeType	nvarchar(128)
	,@DataType				nvarchar(128)
	,@Length				nvarchar(128)
	,@Objects				bit
	,@Path_File				nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @SQL			nvarchar(max)
	DECLARE @SQL_Table		nvarchar(max)
	DECLARE @Name_Table		nvarchar(128)
	DECLARE @SET_UPdate		nvarchar(max)
	DECLARE @SELECT			nvarchar(max)
	DECLARE @WHERE_Insert	nvarchar(max)
	DECLARE @JOIN			nvarchar(max)
	
	
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,'','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,' ','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,':','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,'-','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,'(','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,')','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,'/','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,'\','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,'>','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,'*','_')
	SET @Name_AttributeType = REPLACE(@Name_AttributeType,'.','_')
	
	
	SET @SQL = '
	IF OBJECT_ID(''attT_' + @Name_AttributeType + ''', N''U'') IS NULL 
	BEGIN
	
	CREATE TABLE [attT_' + @Name_AttributeType + ']
	(
		[GUID_Attribute_' + @Name_AttributeType + '] nvarchar(36) NOT NULL,
		[GUID_AT_' + @Name_AttributeType + '] nvarchar(36) NOT NULL,
		[Name_AT_' + @Name_AttributeType + '] nvarchar(255) NOT NULL,
		[GUID_Object] nvarchar(36) NOT NULL,
		[OrderID] bigint NOT NULL,'
		
		if @Length='0'
		BEGIN
			SET @SQL = @SQL + '[val] ' + @DataType + ' NOT NULL,'
		END
		ELSE
		BEGIN
			SET @SQL = @SQL + '[val] ' + @DataType + '(' + @Length + ') NOT NULL,'
			
		END
		
		SET @SQL = @SQL + '[Exist]	bit NOT NULL DEFAULT 1
	)  ON [PRIMARY];
ALTER TABLE [attT_' + @Name_AttributeType + '] ADD CONSTRAINT
	[PK_' + @Name_AttributeType + '] PRIMARY KEY CLUSTERED 
	(
	[GUID_Attribute_' + @Name_AttributeType + ']
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];
ALTER TABLE [attT_' + @Name_AttributeType + '] SET (LOCK_ESCALATION = TABLE);
	END'

	EXEC(@SQL)
IF (SELECT COUNT(*)
	FROM systbl_Tables
	WHERE Name_Table='attT_' + @Name_AttributeType)>0 
BEGIN
	UPDATE systbl_Tables
	SET Exist = 1, Sync_Start=GETDATE()
	WHERE Name_Table='attT_' + @Name_AttributeType
END
ELSE
BEGIN
	INSERT INTO systbl_Tables (Type, Name_Table, Exist, Sync_Start)
	VALUES (@Ontology, 'attT_' + @Name_AttributeType, 1, GETDATE())
END

SET @Name_Table = 'attT_' + @Name_AttributeType

IF @Objects = 1
BEGIN
	SET @SQL_Table = 'CREATE TABLE #tmp_attt_' + @Name_AttributeType + '
		(
			[GUID_Attribute_' + @Name_AttributeType +'] nvarchar(36) NOT NULL,
			[GUID_AT_' + @Name_AttributeType +'] nvarchar(36) NOT NULL,
			[Name_AT_' + @Name_AttributeType +'] nvarchar(255) NOT NULL,
			[GUID_Object] nvarchar(36) NOT NULL,
			[OrderID] bigint NOT NULL,'
			if @Length='0'
		BEGIN
			SET @SQL_Table = @SQL_Table + '[val] ' + @DataType + ' NOT NULL,'
		END
		ELSE
		BEGIN
			SET @SQL_Table = @SQL_Table + '[val] ' + @DataType + '(' + @Length + ') NOT NULL,'
			
		END
		SET @SQL_Table = @SQL_Table + '
		[Exist]	bit NOT NULL DEFAULT 1
		)
		
		ALTER TABLE #tmp_attt_' + @Name_AttributeType + ' ADD CONSTRAINT
		[PK_tmp_' + @Name_AttributeType + '] PRIMARY KEY CLUSTERED 
		(
			[GUID_Attribute]
		)'

	SET @SELECT = 'GUID_Attribute,GUID_AttributeType,GUID_Object,OrderID,val,Exist'
	SET @SET_UPdate = '[attT_' + @Name_AttributeType + '].Name_AT_' + @Name_AttributeType +'=xmlset.DS.value(''Name_AttributeType[1]'',''nvarchar(max)''),[attT_' + @Name_AttributeType + '].Exist=1'
	SET @WHERE_Insert = 'WHERE [attT_' + @Name_AttributeType + '].GUID_Attribute_' + @Name_AttributeType +' IS NULL'
	SET @JOIN = '[attT_' + @Name_AttributeType + '] ON [attT_' + @Name_AttributeType + '].GUID_Attribute_' + @Name_AttributeType +'= xmlset.DS.value(''GUID_Attribute[1]'',''nvarchar(36)'')'
		
	execute import_BulkFile_Attribute @Ontology, @Name_Table, @SQL_Table, @SELECT, @JOIN, @WHERE_Insert, @Set_Update, @Path_File, @DataType, @Length
END

UPDATE systbl_Tables
	SET Sync_End=GETDATE()
	WHERE Name_Table=@Name_Table
	AND Type = @Ontology

SELECT object_id
FROM sys.objects 
WHERE name='attT_' + @Name_AttributeType
AND type='U'

END
GO
/****** Object:  StoredProcedure [dbo].[initialize_Tables]    Script Date: 02/20/2013 16:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[initialize_Tables] 
	-- Add the parameters for the stored procedure here
	@Type		nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE systbl_Tables
	SET Exist=0
	WHERE [Type] = @Type
	
	SELECT *
	FROM systbl_Tables
	WHERE Exist=1
	AND [Type] = @Type
END
GO
/****** Object:  StoredProcedure [dbo].[finalize_Tables]    Script Date: 02/20/2013 16:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[finalize_Tables] 
	-- Add the parameters for the stored procedure here
	@Type			nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @SQL		nvarchar(max)
    DECLARE @Name_Table	nvarchar(128)
    
    DECLARE cur_Tables CURSOR FOR
		SELECT Name_Table
		FROM systbl_Tables
		WHERE [Type] = @Type
		AND Exist = 0
		
	OPEN cur_Tables
	FETCH NEXT FROM cur_Tables INTO
		@Name_Table
		
	WHILE @@FETCH_STATUS=0
	BEGIN
		SET @SQL = 'DROP TABLE [' + @Name_Table + ']'
		
		exec(@SQL)
		
		FETCH NEXT FROM cur_Tables INTO
			@Name_Table
	END
	CLOSE cur_Tables
	DEALLOCATE cur_Tables
	
	DELETE FROM systbl_Tables
	WHERE Exist = 0
	AND [Type] = @Type
	
	SELECT	 Type
			,Name_Table
			,Exist
	FROM systbl_Tables
	WHERE Exist = 0
	AND [Type] = @Type
END
GO
