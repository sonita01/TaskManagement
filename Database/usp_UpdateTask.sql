CREATE PROCEDURE [dbo].[Job_UpdateTask]
    @Id INT,
    @Title NVARCHAR(100),
    @Description NVARCHAR(MAX),
    @DueDate DATETIME,
    @Priority INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Tasks
    SET Title = @Title,
        Description = @Description,
        DueDate = @DueDate,
        Priority = @Priority
    WHERE Id = @Id;
END
