using CommissionFactory.Entities;
using CommissionFactory.Models;
using CommissionFactory.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommissionFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpPost]
        public IActionResult CreateATask([FromBody] CreateDto task)
        {
            _taskRepository.CreateATask(task);
            return Ok(task);
        }

        [HttpGet]
        public IActionResult GetAllTask()
        {
            var tasks = _taskRepository.GetAllTask();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            try
            {
                var task = _taskRepository.GetTaskById(id);
                return Ok(task);
            }
            catch (Exception)
            {

                return NoContent();
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTaskById(int id, UpdateDto task)
        {
            try
            {
                _taskRepository.UpdateATask(id, task);
                return Ok(new { message = "Task updated" });
            }
            catch (Exception)
            {

                return BadRequest();
            }

           
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _taskRepository.DeleteATask(id);
                return Ok(new { message = "Task deleted" });

            }
            catch (Exception)
            {

                return BadRequest();
            }
            

        }


    }
}
