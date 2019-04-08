CREATE PROCEDURE sp_insert_row
	@id NVARCHAR(50),
	@textVar TEXT,
	@timestamp DATETIME,
	@number1 INT
AS
	INSERT INTO [dbo].[InsertTable_sp] (id,textVar,timestamp,number1)
	VALUES(@id,@textVar,@timestamp,@number1);
GO