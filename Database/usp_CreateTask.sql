CREATE PROCEDURE usp_CreateTask
    @Title NVARCHAR(100),
    @Description NVARCHAR(MAX),
    @DueDate DATETIME,
    @Priority INT
AS
BEGIN
    INSERT INTO Tasks (Title, Description, DueDate, Priority)
    VALUES (@Title, @Description, @DueDate, @Priority);

    SELECT CAST(SCOPE_IDENTITY() AS INT);
END

EXEC sp_helptext 'usp_CreateTask';


