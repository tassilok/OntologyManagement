USE [ont_db_Reports]
GO
/****** Object:  Table [dbo].[systbl_Tables]    Script Date: 02/17/2013 23:09:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[systbl_Tables](
	[Type] [nvarchar](128) NOT NULL,
	[Name_Table] [nvarchar](128) NOT NULL,
	[Exist] [bit] NOT NULL,
 CONSTRAINT [PK_systbl_Tables] PRIMARY KEY CLUSTERED 
(
	[Type] ASC,
	[Name_Table] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[insert_Object]    Script Date: 02/17/2013 23:09:54 ******/
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
/****** Object:  StoredProcedure [dbo].[import_BulkFile]    Script Date: 02/17/2013 23:09:54 ******/
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
	
	SET @SQL = @SQL_TMPTABLE + '
	
		BULK INSERT [#tmp_' + @Name_Table + '] 
		FROM  ''' + @Path_File + ''' 
		WITH (
			FIELDTERMINATOR=''@@'')
		
		INSERT INTO [' + @Name_Table + ']
		SELECT ' + @SELECT + '
		FROM [#tmp_' + @Name_Table + ']
		LEFT OUTER JOIN ' + @Join + ' '
		+ @WHERE_Insert
		+ '
		
		UPDATE [' + @Name_Table + '] 
		SET ' + @Set_Update + ' 
		FROM [#tmp_' + @Name_Table + ']
		INNER JOIN ' + @Join + ' '
	exec(@SQL)
END
GO
/****** Object:  StoredProcedure [dbo].[finalize_Tables]    Script Date: 02/17/2013 23:09:54 ******/
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
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM systbl_Tables
	WHERE Exist = 0
	
	SELECT	 Type
			,Name_Table
			,Exist
	FROM systbl_Tables
	WHERE Exist = 0
END
GO
/****** Object:  StoredProcedure [dbo].[create_Table_relT]    Script Date: 02/17/2013 23:09:54 ******/
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
	,@OrderID				nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @SQL		nvarchar(max)
	
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

	SET @SQL = 'IF OBJECT_ID(''relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + ''', N''U'') IS NOT NULL 
		DROP TABLE [relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType  + ']'
	EXEC(@SQL)
	
	SET @SQL = 'CREATE TABLE [relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + ']
	(
		[GUID_Class_Left] varchar(36) NOT NULL,
		[GUID_Class_Left] varchar(36) NOT NULL,
		[GUID_RelationType] varchar(36) NOT NULL,
		[OrderID] long NOT NULL,
		[Exist]	bit NOT NULL DEFAULT 1
	)  ON [PRIMARY];
ALTER TABLE [relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + '] ADD CONSTRAINT
	[PK_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + '] PRIMARY KEY CLUSTERED 
	(
	[GUID_Attribute]
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];
ALTER TABLE [relT_' + @Name_Class_Left + '_To_' + @Name_Class_Right + '_' + @Name_RelationType + '] SET (LOCK_ESCALATION = TABLE);'

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
/****** Object:  StoredProcedure [dbo].[create_Table_orgT]    Script Date: 02/17/2013 23:09:54 ******/
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

    -- Insert statements for procedure here
	DECLARE @SQL			nvarchar(max)
	DECLARE @SELECT			nvarchar(max)
	DECLARE @Name_Table		nvarchar(128)
	DECLARE @SET_UPdate		nvarchar(max)
	DECLARE @JOIN			nvarchar(max)
	DECLARE @WHERE_Insert	nvarchar(max)
	DECLARE @SQL_Table		nvarchar(max)
	
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
	

	SET @SQL = 'IF OBJECT_ID(''orgT_' + @Name_Class + ''', N''U'') IS NOT NULL 
		DROP TABLE [orgT_' + @Name_Class + ']'
	EXEC(@SQL)
	
	SET @SQL = 'CREATE TABLE [orgT_' + @Name_Class + ']
	(
		[GUID_' + @Name_Class +'] varchar(36) NOT NULL,
		[Name_' + @Name_Class + '] nvarchar(255) NOT NULL,
		[GUID_Class_' + @Name_Class + '] varchar(36) NOT NULL,
		[Exist]	bit NOT NULL DEFAULT 1
	)  ON [PRIMARY];
ALTER TABLE [orgT_' + @Name_Class + '] ADD CONSTRAINT
	[PK_' + @Name_Class + '] PRIMARY KEY CLUSTERED 
	(
	[GUID_' + @Name_Class + ']
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];
ALTER TABLE [orgT_' + @Name_Class + '] SET (LOCK_ESCALATION = TABLE);'

	
exec(@SQL)



IF (SELECT COUNT(*)
	FROM systbl_Tables
	WHERE Name_Table='orgT_' + @Name_Class)>0 
BEGIN
	UPDATE systbl_Tables
	SET Exist = 1
	WHERE Name_Table='orgT_' + @Name_Class
END
ELSE
BEGIN
	INSERT INTO systbl_Tables
	VALUES (@Ontology, 'orgT_' + @Name_Class, 1)
END

IF @Objects = 1
BEGIN
	SET @SQL_Table = 'CREATE TABLE #tmp_orgt_' + @Name_Class + '
		(
			[GUID_' + @Name_Class +'] varchar(36) NOT NULL,
			[Name_' + @Name_Class + '] nvarchar(255) NOT NULL,
			[GUID_Class_' + @Name_Class + '] varchar(36) NOT NULL,
			[Exist]	bit NOT NULL DEFAULT 1
		)'
	SET @SELECT = '#tmp_orgt_' + @Name_Class + '.GUID_' + @Name_Class +',#tmp_orgt_' + @Name_Class + '.Name_' + @Name_Class + ',#tmp_orgt_' + @Name_Class + '.GUID_Class_' + @Name_Class + ',#tmp_orgt_' + @Name_Class + '.Exist'
	SET @Name_Table = 'orgT_' + @Name_Class
	SET @SET_UPdate = '[orgT_' + @Name_Class + '].Name_' + @Name_Class + '=[#tmp_orgt_' + @Name_Class + '].Name_' + @Name_Class + ', '  + 
					'[orgT_' + @Name_Class + '].GUID_Class_' + @Name_Class + '=[#tmp_orgt_' + @Name_Class + '].GUID_Class_' + @Name_Class
	SET @WHERE_Insert = 'WHERE [orgT_' + @Name_Class + '].GUID_' + @Name_Class + ' IS NULL'
	SET @JOIN = '[orgT_' + @Name_Class + '] ON [orgT_' + @Name_Class + '].GUID_' + @Name_Class + ' = [#tmp_orgt_' + @Name_Class + '].GUID_' + @Name_Class
	
	execute import_BulkFile @Name_Table, @SQL_Table, @SELECT, @JOIN, @WHERE_Insert, @Set_Update, @Path_File
END

SELECT object_id
FROM sys.objects 
WHERE name='orgT_' + @Name_Class
AND type='U'

END
GO
/****** Object:  StoredProcedure [dbo].[create_Table_attT]    Script Date: 02/17/2013 23:09:54 ******/
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
	,@Name_Attribute		nvarchar(128)
	,@DataType				nvarchar(128)
	,@Length				nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @SQL		nvarchar(max)
	
	SET @Name_Attribute = REPLACE(@Name_Attribute,'','_')
	SET @Name_Attribute = REPLACE(@Name_Attribute,' ','_')
	SET @Name_Attribute = REPLACE(@Name_Attribute,':','_')
	SET @Name_Attribute = REPLACE(@Name_Attribute,'-','_')
	SET @Name_Attribute = REPLACE(@Name_Attribute,'(','_')
	SET @Name_Attribute = REPLACE(@Name_Attribute,')','_')
	SET @Name_Attribute = REPLACE(@Name_Attribute,'/','_')
	SET @Name_Attribute = REPLACE(@Name_Attribute,'\','_')
	SET @Name_Attribute = REPLACE(@Name_Attribute,'>','_')
	SET @Name_Attribute = REPLACE(@Name_Attribute,'*','_')
	

	SET @SQL = 'IF OBJECT_ID(''attT_' + @Name_Attribute + ''', N''U'') IS NOT NULL 
		DROP TABLE [attT_' + @Name_Attribute + ']'
	EXEC(@SQL)
	
	SET @SQL = 'CREATE TABLE [attT_' + @Name_Attribute + ']
	(
		[GUID_Attribute] varchar(36) NOT NULL,
		[GUID_AttributeType] varchar(36) NOT NULL,
		[Name_AttributeType] nvarchar(255) NOT NULL,
		[GUID_Object] varchar(36) NOT NULL,
		[OrderID] long NOT NULL,
		[val] ' + @DataType + '(' + @Length + ') NOT NULL,
		[Exist]	bit NOT NULL DEFAULT 1
	)  ON [PRIMARY];
ALTER TABLE [attT_' + @Name_Attribute + '] ADD CONSTRAINT
	[PK_' + @Name_Attribute + '] PRIMARY KEY CLUSTERED 
	(
	[GUID_Attribute]
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];
ALTER TABLE [attT_' + @Name_Attribute + '] SET (LOCK_ESCALATION = TABLE);'

IF (SELECT COUNT(*)
	FROM systbl_Tables
	WHERE Name_Table='attT_' + @Name_Attribute)>0 
BEGIN
	UPDATE systbl_Tables
	SET Exist = 1
	WHERE Name_Table='attT_' + @Name_Attribute
END
ELSE
BEGIN
	INSERT INTO systbl_Tables
	VALUES (@Ontology, 'attT_' + @Name_Attribute, 1)
END

SELECT object_id
FROM sys.objects 
WHERE name='attT_' + @Name_Attribute
AND type='U'

END
GO
/****** Object:  StoredProcedure [dbo].[initialize_Tables]    Script Date: 02/17/2013 23:09:54 ******/
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
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE systbl_Tables
	SET Exist=0
	
	SELECT COUNT(*) AS Count_NonExistant
	FROM systbl_Tables
	WHERE Exist=1
END
GO
