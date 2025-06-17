CREATE PROCEDURE [dbo].[Job_GetTaskById]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        [Id],
        [Title],
        [Description],
        [DueDate],
        [Priority]
    FROM dbo.Tasks
    WHERE Id = @Id;
END
