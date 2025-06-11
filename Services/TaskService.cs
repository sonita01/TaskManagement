using TaskManagement.Models;
using TaskManagement.Repositories;

namespace TaskManagement.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
        {
            return await _repository.GetAllTasksAsync();
        }

        public async Task<TaskModel?> GetTaskByIdAsync(int id)
        {
            return await _repository.GetTaskByIdAsync(id);
        }

        public async Task<int> CreateTaskAsync(TaskModel task)
        {
            return await _repository.CreateTaskAsync(task);
        }

        public async Task<bool> UpdateTaskAsync(TaskModel task)
        {
            return await _repository.UpdateTaskAsync(task);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            return await _repository.DeleteTaskAsync(id);
        }
    }
}