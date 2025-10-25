using Depitest.IRepository;
using Depitest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Depitest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository _productRepository;
        [HttpGet]
        public ActionResult GetAll()
        {
            List<Product> product = _productRepository.Get();
            return Ok(product);    
        }
        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            Product product = _productRepository.GetById(id);
            return Ok(product);
        }
        [HttpGet("{name:alpha}")]
        public ActionResult GetByName(string name) {
            Product product = _productRepository.GetByName(name);
            return Ok(product);
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            _productRepository.Add(product);
            return Created($"/api/Product/{product.Id}", product); 

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            return NoContent();
        }
        
        [HttpPut]
        public ActionResult Update(Product product)
        {
            _productRepository.Update(product);
            return NoContent();
        }
        
    }
}
