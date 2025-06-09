CREATE PROCEDURE usp_UpdateTask
    @Id INT,
    @Title NVARCHAR(100),
    @Description NVARCHAR(MAX),
    @DueDate DATETIME,
    @Priority INT
AS
BEGIN
    UPDATE Tasks
    SET Title = @Title,
        Description = @Description,
        DueDate = @DueDate,
        Priority = @Priority
    WHERE Id = @Id;
END
