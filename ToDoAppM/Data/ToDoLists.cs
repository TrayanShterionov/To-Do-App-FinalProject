using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppM
{
    public class ToDoLists
    {
        public int id { get; set; }

        public string Title { get; set; }

        public string DateOfCreation { get; set; }

        public int IdOfTheCreator { get; set; }

        public string LastChange { get; set; }

        public int IdOfTheChanger{ get; set; }

        public List<Tasks> TaskList { get; set; }
    }
}
