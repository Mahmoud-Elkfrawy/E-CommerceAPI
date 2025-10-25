using Depitest.IRepository;
using Depitest.Model;

namespace Depitest.Repository
{
    public class UserRepository : IUserRepository
    {
        AppDBContext context;
        public UserRepository(AppDBContext _context)
        {
            context = _context;
        }

        public List<User> Get()
        {
            List<User> users = context.Users?.ToList();
            return users;
        }

        public User GetById(int id)
        {
            User user = context.Users.Find(id);
            return user;
        }

        public User GetByName(string UserName)
        {
            User user = context.Users.FirstOrDefault(x => x.UserName == UserName);
            return user;
        }


        public void Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            User user = GetById(id);
            context.Users.Remove(user);
            context.SaveChanges();
        }
        public void Update(User user)
        {
            User oldUser = GetById(user.Id);
            context.Users.Update(oldUser);
            context.SaveChanges();
        }
    }
}
