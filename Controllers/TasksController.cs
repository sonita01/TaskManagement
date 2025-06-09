using Microsoft.AspNetCore.Mvc;
using TaskManagement.Constants;
using TaskManagement.Helpers;
using TaskManagement.Models;
using TaskManagement.Repositories;

namespace TaskManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _repository;
        public TasksController(ITaskRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var tasks = await _repository.GetAllTasksAsync();
            return Ok(new
            {
                code = ResponseMessage.Success,
                message = ResponseMessageHelper.GetMessage(ResponseMessage.Success),
                data = tasks
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _repository.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound(new
                {
                    code = ResponseMessage.NotFound,
                    message = ResponseMessageHelper.GetMessage(ResponseMessage.NotFound)
                });
            }

            return Ok(new
            {
                code = ResponseMessage.Success,
                message = ResponseMessageHelper.GetMessage(ResponseMessage.Success),
                data = task
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskModel task)
        {
            var id = await _repository.CreateTaskAsync(task);
            task.Id = id;

            return CreatedAtAction(nameof(GetById), new { id }, new
            {
                code = ResponseMessage.Created,
                message = ResponseMessageHelper.GetMessage(ResponseMessage.Created),
                data = task
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskModel task)
        {
            if (id != task.Id)
            {
                return BadRequest(new
                {
                    code = ResponseMessage.ValidationError,
                    message = ResponseMessageHelper.GetMessage(ResponseMessage.ValidationError)
                });
            }

            var updated = await _repository.UpdateTaskAsync(task);
            if (!updated)
            {
                return NotFound(new
                {
                    code = ResponseMessage.NotFound,
                    message = ResponseMessageHelper.GetMessage(ResponseMessage.NotFound)
                });
            }

            return Ok(new
            {
                code = ResponseMessage.Updated,
                message = ResponseMessageHelper.GetMessage(ResponseMessage.Updated)
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteTaskAsync(id);
            if (!deleted)
            {
                return NotFound(new
                {
                    code = ResponseMessage.NotFound,
                    message = ResponseMessageHelper.GetMessage(ResponseMessage.NotFound)
                });
            }

            return Ok(new
            {
                code = ResponseMessage.Deleted,
                message = ResponseMessageHelper.GetMessage(ResponseMessage.Deleted)
            });
        }
    }
}