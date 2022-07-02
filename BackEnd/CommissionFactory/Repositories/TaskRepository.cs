using CommissionFactory.Entities;
using CommissionFactory.Models;

namespace CommissionFactory.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly MyDbContext _dbcontext;
        public TaskRepository(MyDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public Tasks CreateATask(CreateDto task)
        {
            Tasks createdTask = new Tasks
            {
                DateCreated = DateTime.Now,
                Completed = false,
                DateModified = DateTime.Now,
                Details = task.Details

            };
            _dbcontext.Tasks.Add(createdTask);
            _dbcontext.SaveChanges();
            return createdTask;
        }

        public void DeleteATask(int id)
        {
            var task = FindTask(id);

            task.DateDeleted = DateTime.Now;
            _dbcontext.Tasks.Update(task);
            _dbcontext.SaveChanges();
        }

        public IEnumerable<Tasks> GetAllTask()
        {
            // Get all tasks with DateDeleted == null and order by Id
            return _dbcontext.Tasks.Where(e=> e.DateDeleted == null).OrderBy(o => o.Id);
        }

        public string GetTaskById(int id)
        {
            
            return FindTask(id).Details;
  
        }

        public void UpdateATask(int id, UpdateDto updatedTask)
        {

            var task = FindTask(id);
            task.DateModified = DateTime.Now;
            task.Completed = updatedTask.Completed;
            if(updatedTask.Details != null)
            {
                task.Details = updatedTask.Details;

            }
            _dbcontext.Tasks.Update(task);
            _dbcontext.SaveChanges();

        }

        private Tasks FindTask(int id)
        {
            var task = _dbcontext.Tasks.Where(e => e.DateDeleted == null && e.Id == id).FirstOrDefault();
            if (task == null) throw new Exception("Cannot find a task");
            return task;
        }
    }
}
