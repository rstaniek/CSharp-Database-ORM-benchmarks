CREATE PROCEDURE clear_insert_tables
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    BEGIN TRAN;
		DELETE FROM [dbo].[InsertTable];
		DELETE FROM [dbo].[InsertTable_ado];
		DELETE FROM [dbo].[InsertTable_sp];
		DELETE FROM [dbo].[InsertTable_Dapper];
	COMMIT
END
GO