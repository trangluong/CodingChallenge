using CommissionFactory.Entities;
using CommissionFactory.Models;

namespace CommissionFactory.Repositories
{
    public interface ITaskRepository
    {
        /// <summary>
        /// get list of all tasks
        /// </summary>
        /// <returns></returns>
        IEnumerable<Tasks> GetAllTask();
        /// <summary>
        /// Get a task by task id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetTaskById(int id);
        /// <summary>
        /// Create a new task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Tasks CreateATask(CreateDto task);
        /// <summary>
        /// Update a task 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="task"></param>
        void UpdateATask(int id, UpdateDto task);
        /// <summary>
        /// Delete a task by task id
        /// </summary>
        /// <param name="id"></param>
        void DeleteATask(int id);
    }
}
