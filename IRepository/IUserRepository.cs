using Depitest.Model;

namespace Depitest.IRepository
{
    public interface IUserRepository
    {

        public List<User> Get();
        public User GetById(int id);
        public User GetByName(string name);
        public void Add(User user);
        public void Delete(int id);
        public void Update(User user);

    }
}
