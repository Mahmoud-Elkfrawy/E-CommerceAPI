using Depitest.Model;

namespace Depitest.IRepository
{
    public interface IProductRepository
    {
        public List<Product> Get();
        public Product GetById(int id);
        public Product GetByName(string name);
        public void Add(Product product);
        public void Delete(int id);
        public void Update(Product product);
    }
}
