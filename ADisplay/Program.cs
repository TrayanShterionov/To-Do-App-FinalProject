using System;
using ToDoAppM;



namespace ADisplay
{
   
    class Program
    {   
        static void Main(string[] args)
        {
            LoginScreen();

        }

        private static void LoginScreen()
        {
            Console.Clear();
            Business business = new Business();
            TaskBusiness taskBusiness = new TaskBusiness();
            ToDoListBusiness toDoListBusiness = new ToDoListBusiness();
            Console.WriteLine("Username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Password: ");
            var password = Console.ReadLine();
            CheckAccount(username, password, business,taskBusiness,toDoListBusiness);
        }

        static void CheckAccount(string username, string password, Business business,TaskBusiness taskBusiness, ToDoListBusiness toDoListBusiness)
        {
            var loginUser = business.Get(1);

            if (loginUser == null)
            {
                loginUser = new Users()
                {
                    Username = "Admin0",
                    Password = "",
                    Role = "Admin"
                };
                business.Add(loginUser);

            }
          

            var users = business.GetAll();

            foreach (var user in users)
            {
                if (user.Username == username
                    && user.Password == password)
                    
                {


                    Console.WriteLine("You succssefully logged in!");
                    

                    if (user.Role == "Admin")
                    {
                        Console.WriteLine("admin");
                        Console.Clear();
                        AdminMenu(business, user.Id);
                    }
                    else
                    {
                        Console.WriteLine("User");
                        Console.Clear();
                        UserMenu(taskBusiness,toDoListBusiness, user.Id);

                    }
                  

                }
            }

        }
        static void AdminMenu(Business business, int id)
        {
            Console.Clear();
            Console.WriteLine("========================");
            Console.WriteLine("1. Delete user by Id");
            Console.WriteLine("2. Update user by Id");
            Console.WriteLine("3. Users Management View");
            Console.WriteLine("4. Create User");
            Console.WriteLine("5. log out");
            Console.WriteLine("========================");
            Console.WriteLine("Choose an option: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    DeleteUserById(business);
                    break;
                case "2":
                    UpdateUser(business, id);
                    break;
                case "3":
                    ShowUsers(business, id);
                    break;
                case "4":
                    CreateUser(business, id);
                    break;
                case "5":
                    LoginScreen();
                    break;
            }

        }

        static void UserMenu(TaskBusiness taskBusiness,ToDoListBusiness toDoListBusiness,int id)
        {

            Console.Clear();
            Console.WriteLine("========================");
            Console.WriteLine("1. To-Do Lists");
            Console.WriteLine("2. Create To-Do List");
            Console.WriteLine("3. Show Tasks");
            Console.WriteLine("4. Create Task");
            Console.WriteLine("5. Delete Task by Id");
            Console.WriteLine("6. Update Task by Id");
            Console.WriteLine("7. Complete Task by Id");
            Console.WriteLine("8. log out");
            Console.WriteLine("========================");
            Console.WriteLine("Choose an option: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    
                    break;
                case "2":
                    CreateToDoList(taskBusiness, toDoListBusiness, id);
                    break;
                case "3":
                    ShowTasks(taskBusiness,toDoListBusiness, id);
                    break;
                case "4":
                    CreateTask(taskBusiness,toDoListBusiness, id);
                    break;
                case "5":
                    DeleteTaskById(taskBusiness,toDoListBusiness);
                    break;
                case "6":
                    UpdateTask(taskBusiness,toDoListBusiness, id);
                    break;
                case "7":
                    CompleteTask(taskBusiness,toDoListBusiness, id);
                    break;
                case "8":
                    LoginScreen();
                    break;
               
            }
        }
        static void ShowToDoList(TaskBusiness taskBusiness,ToDoListBusiness toDoListBusiness, int id)
        {
            Console.Clear();
            var lists = toDoListBusiness.GetAll();
            foreach (var list in lists)
            {
                Console.WriteLine("To-Do-Lists -> {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} |\n", list.id, list.Title, list.DateOfCreation, list.IdOfTheCreator,
                    list.LastChange, list.IdOfTheChanger);
            }
            Console.WriteLine("Do you want to list again? Y/N");
            var answer = Console.ReadLine();
            switch (answer)
            {
                case "Y":
                    ShowToDoList(taskBusiness,toDoListBusiness, id);
                    break;
                case "y":
                    ShowToDoList(taskBusiness, toDoListBusiness, id);
                    break;
                case "n":
                    UserMenu(taskBusiness,toDoListBusiness, id);
                    break;
                case "N":
                    UserMenu(taskBusiness, toDoListBusiness, id);
                    break;
            }
        }
        static void CreateToDoList(TaskBusiness taskBusiness,ToDoListBusiness toDoListBusiness, int id)
        {
            Console.Clear();
            Console.WriteLine("Enter a Title:");
            var title = Console.ReadLine();
            if (title == null)
            {
                Console.Clear();
                Console.WriteLine("Title cant be empty! Try again.");
                CreateToDoList(taskBusiness,toDoListBusiness, id);
            }
            else
            {
                Console.WriteLine("Enter a description:");
                var description = Console.ReadLine();
                if (description == null)
                {
                    Console.Clear();
                    Console.WriteLine("Description cant be empty! Try again.");
                    CreateToDoList(taskBusiness,toDoListBusiness, id);
                }
                else
                {

                    var toDoList = new ToDoLists
                    {
                        Title = title,
                        TaskList = new System.Collections.Generic.List<Tasks>(),
                        DateOfCreation = DateTime.Now.ToString(),
                        IdOfTheCreator = id,

                    };
                    toDoListBusiness.AddToDoList(toDoList);
                    Console.Clear();
                    UserMenu(taskBusiness,toDoListBusiness, id);

                }

            }

        }
        static void CompleteTask(TaskBusiness taskBusiness,ToDoListBusiness toDoListBusiness,int id)
        {
            Console.Clear();
            Console.WriteLine("Enter the Id of the task you want to completeL: ");
            var completedTaskId = int.Parse(Console.ReadLine());
            taskBusiness.GetTask(completedTaskId).IsComplete = true;
            Console.Clear();
            Console.WriteLine("Task completed!");
            UserMenu(taskBusiness,toDoListBusiness, id);

        }
        static void ShowTasks(TaskBusiness taskBusiness,ToDoListBusiness toDoListBusiness,int id)
        {
            Console.Clear();
            var tasks = taskBusiness.GetAll();
            foreach (var task in tasks)
            {
                Console.WriteLine("Tasks -> {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} |\n", task.Id, task.IdOfTheList, task.Title, task.Description,
                    task.IsComplete, task.DateOfCreation, task.IdOfTheCreator, task.DateOfLastChange, task.IdOfTheChanger);
            }
            Console.WriteLine("Do you want to list again? Y/N");
            var answer = Console.ReadLine();
            switch (answer)
            {
                case "Y":
                    ShowTasks(taskBusiness,toDoListBusiness, id);
                    break;
                case "y":
                    ShowTasks(taskBusiness,toDoListBusiness, id);
                    break;
                case "n":
                    UserMenu(taskBusiness,toDoListBusiness, id);
                    break;
                case "N":
                    UserMenu(taskBusiness,toDoListBusiness,id);
                    break;
            }

        }
        static void DeleteTaskById(TaskBusiness taskBusiness,ToDoListBusiness toDoListBusiness)
        {
            Console.Clear();
            Console.WriteLine("Enter the Id of the task you want to delete: ");
            var TaskId = int.Parse(Console.ReadLine());
            if (IfTaskExistExist(taskBusiness, TaskId))
            {
                taskBusiness.Delete(TaskId);
                UserMenu(taskBusiness,toDoListBusiness, TaskId);
            }
            else
            {
                Console.WriteLine("Task does not exist with this Id!");
                DeleteTaskById(taskBusiness, toDoListBusiness);
            }
        }

        static void CreateTask(TaskBusiness taskBusiness,ToDoListBusiness toDoListBusiness, int id)
        {
            Console.Clear();
            Console.WriteLine("Enter a Title:");
            var title = Console.ReadLine();
            if (title == null)
            {
                Console.Clear();
                Console.WriteLine("Title cant be empty! Try again.");
                CreateTask(taskBusiness,toDoListBusiness, id);
            }
            else
            {
                Console.WriteLine("Enter a description:");
                var description = Console.ReadLine();
                if (description == null)
                {
                    Console.Clear();
                    Console.WriteLine("Description cant be empty! Try again.");
                    CreateTask(taskBusiness,toDoListBusiness, id);
                }
                else
                {

                    var task = new Tasks
                    {
                        Title = title,
                        Description = description,
                        IsComplete = false,  
                        DateOfCreation = DateTime.Now.ToString(),
                        IdOfTheCreator = id,

                    };
                    taskBusiness.AddTask(task);
                    Console.Clear();
                    UserMenu(taskBusiness,toDoListBusiness, id);

                }

            }
           
        }
        static bool IfTaskExistExist(TaskBusiness taskBusiness, int id)
        {
            var tasks = taskBusiness.GetAll();
            foreach (var task in tasks)
            {
                if (task.Id == id)
                {
                    return true;
                }

            }
            return false;
        }
        static bool IfTitleExist(TaskBusiness taskBusiness, string title)
        {
            var tasks = taskBusiness.GetAll();
            foreach (var task in tasks)
            {
                if (task.Title == title)
                {
                    return true;
                }

            }
            return false;
        }
        static void DeleteUserById(Business business)
        {   
            Console.Clear();
            Console.WriteLine("Enter the Id of the user you want to delete: ");
            var deleteUserId = int.Parse(Console.ReadLine());
            if (IfUserExist(business, deleteUserId))
            {
                business.Delete(deleteUserId);
                AdminMenu(business, deleteUserId);
            }
            else
            {
                Console.WriteLine("User does not exist with this Id!");
                DeleteUserById(business);
            }
        }

        static bool IfUserExist(Business business, int id)
        {
            var users = business.GetAll();
            foreach (var user in users)
            {
                if (user.Id == id)
                {
                    return true;
                }
                
            }
            return false;
        }
        static bool IfUsernameExist(Business business, string username)
        {
            var users = business.GetAll();
            foreach (var user in users)
            {
                if (user.Username == username)
                {
                    Console.WriteLine("Username already exist!");
                    return true;
                }

            }
            return false;
        }

        static void ShowUsers(Business business, int id)
        {
            Console.Clear();
            var employees = business.GetAll();
            foreach (var employee in employees)
            {
                Console.WriteLine("Employee -> {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} |\n", employee.Id, employee.Username, employee.Password, employee.FirstName,
                    employee.LastName, employee.Role,employee.DateOfCreation, employee.IdOfCreator, employee.LastChange, employee.UserThatDidTheLastChange);
            }
            Console.WriteLine("Do you want to list again? Y/N");
            var answer = Console.ReadLine();
            switch (answer)
            {
                case "Y":
                    ShowUsers(business, id);
                    break;
                case "y":
                    ShowUsers(business, id);
                    break;
                case "n":
                    AdminMenu(business, id);
                    break;
                case "N":
                    AdminMenu(business, id);
                    break;
            }
        }
        static void CreateUser(Business business,int id)
        {
            Console.Clear();
            Console.WriteLine("Enter a Username:");
            var username = Console.ReadLine();
            if (username == null)
            {
                Console.Clear();
                Console.WriteLine("Username cant be empty! Try again.");
                CreateUser(business, id);
            }
            else if (!IfUsernameExist(business, username))
            {
                Console.WriteLine("Enter a Password:");
                var password = Console.ReadLine();
                if (password == null)
                {
                    Console.Clear();
                    Console.WriteLine("Password cant be empty! Try again.");
                    CreateUser(business, id);
                }
                else
                {
                    Console.WriteLine("Enter the first name of the user:");
                    var firstName = Console.ReadLine();
                    if (firstName == null)
                    {
                        Console.Clear();
                        Console.WriteLine("FirstName cant be empty! Try again.");
                        CreateUser(business, id);
                    }
                    //produlji stulbata
                    Console.WriteLine("Enter the last name of the user:");
                    var lastName = Console.ReadLine();
                    if (lastName == null)
                    {
                        Console.Clear();
                        Console.WriteLine("LastName cant be empty! Try again.");
                        CreateUser(business, id);
                    }
                    Console.WriteLine("Enter the role of the user:");
                    var role = Console.ReadLine();
                    if (role != "Admin" && role != "User")
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong role! Try again.");
                        CreateUser(business, id);
                    }

                    var user = new Users
                    {
                        Role = role,
                        LastName = lastName,
                        FirstName = firstName,
                        Username = username,
                        Password = password,
                        IdOfCreator = id,
                        DateOfCreation = DateTime.Now.ToString()
                    };
                    business.Add(user);
                    Console.Clear();
                    AdminMenu(business, id);

                }

            }
            else 
            {
                Console.WriteLine("Username already exists!");
                CreateUser(business, id);
            }
          
        }
        static void UpdateTask(TaskBusiness taskBusiness,ToDoListBusiness toDoListBusiness, int id)
        {
            Console.WriteLine("Enter Id: ");
            int taskId = int.Parse(Console.ReadLine());
            var task = taskBusiness.GetTask(taskId);
            Console.WriteLine("Employee -> {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} |\n", task.Id, task.IdOfTheList, task.Title, task.Description,
                       task.IsComplete, task.DateOfCreation, task.IdOfTheCreator, task.DateOfLastChange, task.IdOfTheChanger);

            Console.WriteLine("Enter a Title:");
            var title = Console.ReadLine();
            if (title == null)
            {
                Console.Clear();
                Console.WriteLine("Title cant be empty! Try again.");
                UserMenu(taskBusiness,toDoListBusiness, id);
            }
            else if (!IfTitleExist(taskBusiness, title))
            {
                Console.WriteLine("Enter Description:");
                var description = Console.ReadLine();
                if (description == null)
                {
                    Console.Clear();
                    Console.WriteLine("Description cant be empty! Try again.");
                    UserMenu(taskBusiness,toDoListBusiness, id);
                }
                else
                {
                    Console.WriteLine("Enter if task is completed: Y/N");
                    var completed = Console.ReadLine();
                    if (completed == null)
                    {
                        Console.Clear();
                        Console.WriteLine("FirstName cant be empty! Try again.");
                        UserMenu(taskBusiness,toDoListBusiness, id);
                    }
                   
                    var newtTask = taskBusiness.GetTask(taskId);

                    newtTask.Title = title;
                    newtTask.Description = description;
                    switch (completed)
                    {
                        case "Y":
                            newtTask.IsComplete = true;
                            break;
                        case "N":
                            newtTask.IsComplete = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("wrong input!");
                            UserMenu(taskBusiness,toDoListBusiness, id);
                           
                            break;
                    }
                    newtTask.DateOfLastChange = DateTime.Now.ToString();
                    newtTask.IdOfTheChanger = id;
                   
                }
            }
        }
        static void UpdateUser(Business business,int id)
        {
            Console.WriteLine("Enter Id: ");
            int userId = int.Parse(Console.ReadLine());
            var employee = business.Get(userId);
            Console.WriteLine("Employee -> {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} |\n", employee.Id, employee.Username, employee.Password, employee.FirstName,
                       employee.LastName, employee.Role, employee.DateOfCreation, employee.IdOfCreator, employee.LastChange, employee.UserThatDidTheLastChange);

            Console.WriteLine("Enter a Username:");
            var username = Console.ReadLine();
            if (username == null)
            {
                Console.Clear();
                Console.WriteLine("Username cant be empty! Try again.");
                AdminMenu(business,id);
            }
            else if (!IfUsernameExist(business, username))
            {
                Console.WriteLine("Enter a Password:");
                var password = Console.ReadLine();
                if (password == null)
                {
                    Console.Clear();
                    Console.WriteLine("Password cant be empty! Try again.");
                    AdminMenu(business, id);
                }
                else
                {
                    Console.WriteLine("Enter the first name of the user:");
                    var firstName = Console.ReadLine();
                    if (firstName == null)
                    {
                        Console.Clear();
                        Console.WriteLine("FirstName cant be empty! Try again.");
                        AdminMenu(business, id);
                    }
                    //produlji stulbata
                    Console.WriteLine("Enter the last name of the user:");
                    var lastName = Console.ReadLine();
                    if (lastName == null)
                    {
                        Console.Clear();
                        Console.WriteLine("LastName cant be empty! Try again.");
                        AdminMenu(business, id);
                    }
                    Console.WriteLine("Enter the role of the user:");
                    var role = Console.ReadLine();
                    if (role != "Admin" && role != "User")
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong role! Try again.");
                        AdminMenu(business, id);
                    }

                    var user = business.Get(userId);

                    user.FirstName = firstName;
                    user.LastName = lastName;
                    user.Username = username;
                    user.Password = password;
                    user.Role = role;
                    business.Update(user);
                
                }
            }
        }

    }
}
