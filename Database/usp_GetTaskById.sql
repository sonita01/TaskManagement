CREATE PROCEDURE [dbo].[Job_GetTaskById]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM dbo.Tasks 
    WHERE Id = @Id;
END
