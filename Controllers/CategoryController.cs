using Depitest.IRepository;
using Depitest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Depitest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryRepository _categoryRepository;
        [HttpGet]
        public ActionResult GetAll()
        {
            List<Categoray> category = _categoryRepository.Get();
            return Ok(category);
        }
        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            Categoray category = _categoryRepository.GetById(id);
            return Ok(category);
        }
        [HttpGet("{name:alpha}")]
        public ActionResult GetByName(string name)
        {
            Categoray category = _categoryRepository.GetByName(name);
            return Ok(category);
        }

        [HttpPost]
        public ActionResult Add(Categoray category)
        {
            _categoryRepository.Add(category);
            return Created($"/api/Category/{category.Id}", category);

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _categoryRepository.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public ActionResult Update(Categoray category)
        {
            _categoryRepository.Update(category);
            return NoContent();
        }

    }
}
