using TaskManagement.Models;

namespace TaskManagement.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskModel>> GetAllTasksAsync();
        Task<TaskModel?> GetTaskByIdAsync(int id);
        Task<int> CreateTaskAsync(TaskModel task);
        Task<bool> UpdateTaskAsync(TaskModel task);
        Task<bool> DeleteTaskAsync(int id);
    }
}