using Depitest.Model;
using System.Linq.Expressions;

namespace Depitest.IRepository
{
    public interface ICategoryRepository
    {

        public List<Categoray> Get();
        public Categoray GetById(int id);
        public Categoray GetByName(string name);
        public void Add(Categoray categoray);
        public void Delete(int id);
        public void Update(Categoray categoray);

    }
}
