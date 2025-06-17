CREATE PROCEDURE [dbo].[Job_GetAllTasks]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        [Id],
        [Title],
        [Description],
        [DueDate],
        [Priority]
    FROM dbo.Tasks WITH (NOLOCK);
END