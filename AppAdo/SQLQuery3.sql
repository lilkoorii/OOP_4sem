USE [ELIBRARY]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[sp_InsertStudent]
		@NAME = N'',
		@SPECIALTY = N'',
		@AGE = NULL,
		@BIRTHDAY = NULL,
		@COURSE = NULL,
		@SEX = N'',
		@AVGSCORE = NULL

SELECT	@return_value as 'Return Value'

GO
