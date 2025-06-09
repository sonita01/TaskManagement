using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using TaskManagement.Models;

namespace TaskManagement.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string _connectionString;

        public TaskRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<TaskModel>(
                "usp_GetAllTasks", 
                commandType: CommandType.StoredProcedure);
        }

        public async Task<TaskModel?> GetTaskByIdAsync(int id)
        {
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<TaskModel>(
                "usp_GetTaskById", 
                new { Id = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CreateTaskAsync(TaskModel task)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteScalarAsync<int>(
                "usp_CreateTask", 
                new 
                {
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    Priority = task.Priority
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateTaskAsync(TaskModel task)
        {
            using var connection = CreateConnection();
            var affectedRows = await connection.ExecuteAsync(
                "usp_UpdateTask", 
                new 
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    Priority = task.Priority
                },
                commandType: CommandType.StoredProcedure);

            return affectedRows > 0;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            using var connection = CreateConnection();
            var affectedRows = await connection.ExecuteAsync(
                "usp_DeleteTask", 
                new { Id = id }, 
                commandType: CommandType.StoredProcedure);

            return affectedRows > 0;
        }
    }
}
