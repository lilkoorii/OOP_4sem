USE [ELIBRARY]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[sp_InsertAddress]
		@StudentID = NULL,
		@Town = N'',
		@Index = NULL,
		@Street = N'',
		@House = NULL,
		@Flat = NULL

SELECT	@return_value as 'Return Value'

GO
