USE [ont_db_Reports]
GO
/****** Object:  StoredProcedure [dbo].[insert_Object]    Script Date: 01/31/2013 16:19:10 ******/
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
/****** Object:  StoredProcedure [dbo].[create_Table_orgT]    Script Date: 01/31/2013 16:19:10 ******/
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
	 @GUID_Session	varchar(36)
	,@GUID_Class	varchar(36)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @SQL	nvarchar(max)
	
	SET @SQL = 'IF OBJECT_ID(''' + @GUID_Session + @GUID_Class + ''', N''U'') IS NOT NULL 
		DROP TABLE [' + @GUID_Session + @GUID_Class + ']'
	EXEC(@SQL)
	
	SET @SQL = 'CREATE TABLE [' + @GUID_Session + @GUID_Class + ']
	(
		[GUID_' + @GUID_Class + '] uniqueidentifier NOT NULL,
		[Name_' + @GUID_Class + '] nvarchar(255) NOT NULL,
		[GUID_Class_' + @GUID_Class + '] uniqueidentifier NOT NULL
	)  ON [PRIMARY];
ALTER TABLE [' + @GUID_Session + @GUID_Class + '] ADD CONSTRAINT
	[PK_' + @GUID_Session + @GUID_Class + '] PRIMARY KEY CLUSTERED 
	(
	[GUID_' + @GUID_Class + ']
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];
ALTER TABLE [' + @GUID_Session + @GUID_Class + '] SET (LOCK_ESCALATION = TABLE);'

	
exec(@SQL)

SELECT object_id
FROM sys.objects 
WHERE name=@GUID_Session
AND type='U'
END
GO
