using System.Collections.Generic;
using System.Linq;
using ToDoAppM;

namespace ToDoAppM
{
    public class Business
    {

        private UserContext userContext;

        public List<Users> GetAll()
        {
            using (userContext = new UserContext())
            {
                return userContext.Users.ToList();
            }
        }

        public Users Get(int id)
        {
            using (userContext = new UserContext())
            {
                return userContext.Users.Find(id);

            }
        }


        public void Add(Users users)
        {
            using (userContext = new UserContext())
            {
                userContext.Users.Add(users);
                userContext.SaveChanges();
            }
        }

        public void Update(Users users)
        {
            using (userContext = new UserContext())
            {

                var item = userContext.Users.Find(users.Id);
                if (item != null)
                {
                    userContext.Entry(item).CurrentValues.SetValues(users);
                    userContext.SaveChanges();
                }

            }
        }

        public void Delete(int id)
        {
            using (userContext = new UserContext())
            {
                var users = userContext.Users.Find(id);
                if (users != null)
                {
                    userContext.Users.Remove(users);
                    userContext.SaveChanges();
                }
            }
        }


    }
}
