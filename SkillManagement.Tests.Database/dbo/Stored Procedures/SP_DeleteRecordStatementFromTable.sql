﻿-- =============================================
-- Author:		Mohamed Ramadan Fekry Mohamed
-- Create date: 8/28/2018
-- Description:	Generic stored procedure to delete specified record from specified table
-- =============================================
Create PROCEDURE [dbo].[SP_DeleteRecordStatementFromTable]
	-- Add the parameters for the stored procedure here
	@P_tableName nvarchar(50) = null,
	@P_Id nvarchar(50) = null
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @V_table nvarchar(50) = null
	if (@P_tableName is not null)
		select @V_table = QUOTENAME( TABLE_NAME )
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = @P_tableName

	declare @V_sql as nvarchar(MAX) = null
	if (@V_table is not null and @P_Id is not null)
		select @V_sql = 'delete from ' + @V_table + 'where Id = ' + @P_Id

	if(@V_sql is not null)
		select @V_sql
	else
		select 0;
END