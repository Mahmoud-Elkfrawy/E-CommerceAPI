using Depitest.IRepository;
using Depitest.Model;
using Depitest.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Depitest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository _userRepository;
        public UserController(IUserRepository categoryRepository)
        {
            _userRepository = categoryRepository;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            List<User> User = _userRepository.Get();
            return Ok(User);
        }
        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            User user = _userRepository.GetById(id);
            return Ok(user);
        }
        [HttpGet("{name:alpha}")]
        public ActionResult GetByName(string UserName)
        {
            User user = _userRepository.GetByName(UserName);
            return Ok(user);
        }

        [HttpPost]
        public ActionResult Add(User User)
        {
            _userRepository.Add(User);
            return Created($"/api/User/{User.Id}", User);

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _userRepository.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public ActionResult Update(User user)
        {
            _userRepository.Update(user);
            return NoContent();
        }
        [HttpGet("Check/{UserName:alpha}")]
        public ActionResult CheckUserName(string UserName)
        {
            User user = _userRepository.GetByName(UserName);
            return Ok(user);
        }
    }
}
