CREATE PROCEDURE [dbo].[Job_DeleteTask]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.Tasks 
    WHERE Id = @Id;
END
