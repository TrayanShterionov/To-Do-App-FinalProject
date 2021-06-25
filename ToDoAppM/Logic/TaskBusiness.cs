using System.Collections.Generic;
using System.Linq;
using ToDoAppM.Data.Context;


namespace ToDoAppM
{
    public class TaskBusiness
    {
        private TasksContext tasksContext;

        public List<Tasks> GetAll()
        {
            using (tasksContext = new TasksContext())
            {
                return tasksContext.Tasks.ToList();
            }
        }

        public Tasks GetTask(int id)
        {
            using (tasksContext = new TasksContext())
            {
                return tasksContext.Tasks.Find(id);

            }
        }


        public void AddTask(Tasks tasks)
        {
            using (tasksContext = new TasksContext())
            {
                tasksContext.Tasks.Add(tasks);
                tasksContext.SaveChanges();
            }
        }

        public void Update(Tasks tasks)
        {
            using (tasksContext = new TasksContext())
            {

                var item = tasksContext.Tasks.Find(tasks.Id);
                if (item != null)
                {
                    tasksContext.Entry(item).CurrentValues.SetValues(tasks);
                    tasksContext.SaveChanges();
                }

            }
        }

        public void Delete(int id)
        {
            using (tasksContext = new TasksContext())
            {
                var tasks = tasksContext.Tasks.Find(id);
                if (tasks != null)
                {
                    tasksContext.Tasks.Remove(tasks);
                    tasksContext.SaveChanges();
                }
            }
        }

    }
}
