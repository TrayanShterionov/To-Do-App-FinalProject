using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppM
{
    public class Tasks

    {
        public int Id { get; set; }

        public int IdOfTheList { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public string DateOfCreation { get; set; }

        public int IdOfTheCreator { get; set; }

        public string DateOfLastChange { get; set; }

        public int IdOfTheChanger { get; set; }
    }
}
