using System.Collections.Generic;
using System.Linq;
using ToDoAppM.Data.Context;

namespace ToDoAppM
{
    public class ToDoListBusiness
    {
        private ToDoListContext toDoListContext;

        public List<ToDoLists> GetAll()
        {
            using (toDoListContext = new ToDoListContext())
            {
                return toDoListContext.ToDoLists.ToList();
            }
        }

        public ToDoLists GetToDoList(int id)
        {
            using (toDoListContext = new ToDoListContext())
            {
                return toDoListContext.ToDoLists.Find(id);

            }
        }


        public void AddToDoList(ToDoLists toDoLists)
        {
            using (toDoListContext = new ToDoListContext())
            {
                toDoListContext.ToDoLists.Add(toDoLists);
                toDoListContext.SaveChanges();
            }
        }

        public void UpdateToDoList(ToDoLists toDoLists)
        {
            using (toDoListContext = new ToDoListContext())
            {

                var item = toDoListContext.ToDoLists.Find(toDoLists.id);
                if (item != null)
                {
                    toDoListContext.Entry(item).CurrentValues.SetValues(toDoLists);
                    toDoListContext.SaveChanges();
                }

            }
        }

        public void DeleteToDoList(int id)
        {
            using (toDoListContext = new ToDoListContext())
            {
                var toDoLists = toDoListContext.ToDoLists.Find(id);
                if (toDoLists != null)
                {
                    toDoListContext.ToDoLists.Remove(toDoLists);
                    toDoListContext.SaveChanges();
                }
            }
        }

    }
}
