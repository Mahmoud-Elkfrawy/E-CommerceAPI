using Depitest.IRepository;
using Depitest.Model;

namespace Depitest.Repository
{
    public class ProductRepository : IProductRepository
    {

        AppDBContext context;
        public ProductRepository(AppDBContext _context)
        {
            context = _context;
        }

        public List<Product> Get()
        {
            List<Product> products = context.Products.ToList();
            return products;
        }

        public Product GetById(int id)
        {
            Product product = context.Products.Find(id);
            return product;
        }

        public Product GetByName(string name)
        {
            Product product = context.Products.FirstOrDefault(x => x.Name == name);
            return product;
        }


        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = GetById(id);
            context.Products.Remove(product);
            context.SaveChanges();
        }
        public void Update(Product _product)
        {
            Product oldProduct = GetById(_product.Id);
            context.Products.Update(oldProduct);

            context.SaveChanges();

        }
    }
}
