CREATE PROCEDURE [dbo].[Job_CreateTask]
    @Title NVARCHAR(100),
    @Description NVARCHAR(MAX),
    @DueDate DATETIME,
    @Priority INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NewTaskID INT;

    INSERT INTO dbo.Tasks (Title, Description, DueDate, Priority)
    VALUES (@Title, @Description, @DueDate, @Priority);

    SET @NewTaskID = CAST(SCOPE_IDENTITY() AS INT);

    SELECT @NewTaskID AS TaskID;
END
