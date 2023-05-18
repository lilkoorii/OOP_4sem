CREATE PROCEDURE sp_InsertAuthors
(
@ID INT,
@Name NVARCHAR(50),
@Surname NVARCHAR(50),
@Lastname NVARCHAR(50),
@Country NVARCHAR(50)
)
AS
BEGIN
INSERT INTO AUTHORS(ID, Name, Surname, Lastname, Country)
VALUES (@ID, @Name, @Surname, @Lastname, @Country);
END