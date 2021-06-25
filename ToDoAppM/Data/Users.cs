using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppM
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string DateOfCreation { get; set; }
        public int IdOfCreator { get; set; }
        public string LastChange { get; set; }

        public int UserThatDidTheLastChange { get; set; }
    }
}
