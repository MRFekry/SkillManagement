-- =============================================
-- Author:		Mohamed Ramadan Fekry Mohamed
-- Create date: 8/28/2018
-- Description:	Generic stored procedure to insert new record to specified table
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetInsertionRecordStatementToTable]
	-- Add the parameters for the stored procedure here
	@P_tableName nvarchar(50) = null,
	@P_columnsString nvarchar(MAX) = null, 
	@P_propertiesString nvarchar(MAX) = null
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @V_table nvarchar(50) = null
	if (@P_tableName is not null)
		select @V_table = QUOTENAME( TABLE_NAME )
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = @P_tableName

	declare @V_sql as nvarchar(MAX) = null
	if (@V_table is not null and @P_columnsString is not null and @P_propertiesString is not null)
		select @V_sql = 'insert into ' + @V_table + ' (' + @P_columnsString + ') values (' + @P_propertiesString + '); select SCOPE_iDENTITY();'

	if(@V_sql is not null)
		select @V_sql
	else
		select -1;
END