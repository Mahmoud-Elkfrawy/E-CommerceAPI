using Depitest.IRepository;
using Depitest.Model;
using Microsoft.EntityFrameworkCore;

namespace Depitest.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        AppDBContext context;
        public CategoryRepository(AppDBContext _context)
        {
            context = _context;
        }

        public List<Categoray> Get() //return categorays
        {
            List<Categoray> categorays = context.Categories?.ToList();
            return categorays;
        }

        public Categoray GetById(int id) //return categoray by id
        {
            Categoray categoray = context.Categories.FirstOrDefault(s=> s.Id==id);
            return categoray;
        }

        public Categoray GetByName(string name)
        {
            Categoray categoray = context.Categories.FirstOrDefault(x => x.Name == name);
            return categoray;
        }

        
        public void Add(Categoray categoray)
        {
            context.Categories.Add(categoray);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Categoray categoray = GetById(id);
            context.Categories.Remove(categoray);
            context.SaveChanges();
        }
        public void Update(Categoray category)
        {
            Categoray categoray = GetById(category.Id);
            context.Categories.Update(categoray);

            context.SaveChanges();

        }
    }
}
