CREATE PROCEDURE [dbo].[Job_GetAllTasks]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM dbo.Tasks;
END
